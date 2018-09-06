using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    /****************************************
    *          V A R I A B L E S           *
    ****************************************/
    [Header("MOVEMENT")]
    public float moveSpeed = 9f;                        // rýchlosť pohybu

    [Header("JUMPING")]
    [Range(5, 20)]
    public float JumpVelocity;                          // sila skoku
    [SerializeField]
    private float fallMultiplier;                       // úprava veľkosti pádu zo skoku --> väčšia ako lowJumpMultiplier
    [SerializeField]
    private float lowJumpMultiplier;                    // úprava veľkosti skoku --> menšia ako fallMultiplier

    [Header("Jumping - Ground Check Options")]
    public LayerMask whatIsGround;                      // nastavenie objektov ako vrstva Ground --> na tejto vrstve môže Hráč skákať len raz
    public LayerMask whatIsNonGround;                   // nastavenie objektov ako vrstva NonGround --> na tejto vrstve nemôže Hráč skákať               // nastavenie objektov ako vrstva JumpingWall --> na tejto vrstve môže Hráč skákať bokom
    public Transform groundCheck;                       // dieťa Hráča v hierarchii --> pre dotyk vrstvy Ground
    public float groundCheckRadius;                     // veľkosť dieťaťa            
    private bool isJumping;                             // bool na to či Hráč práve skáče alebo nie --> úprava na dvojitý skok

    [Header("Ability")]
    public Transform[] side = new Transform[2];

    [HideInInspector]
    public bool LinedBool = false;

    [Header("Checkpoint")]
    [HideInInspector]
    public bool checkpointReached = false;
    public float respawnPosition_Min = -15f;
    public float respawnPosition_Max = 60f;
    private Vector3 respawnPoint;
    private Vector3 startPoint;

    [HideInInspector]
    public Rigidbody2D rb;
    protected Collider2D coll;


    /****************************************
     *         P R O C E D U R E S          *
     ****************************************/

    public void Jumping()                  // skakanie hráča
    {
        bool Jump = Input.GetButtonDown("Vertical") || Input.GetKeyDown(KeyCode.Space);      // deklarácia vstupu klávesnice na výskok

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;    // úprava reálnejšieho skoku
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; // úprava reálnejšieho skoku
        }

            
        if (Jump && Grounded())                             // ak je Hráč na zemi (vrstva Ground) môže skákať
        {
            rb.velocity = Vector2.up * JumpVelocity;
            isJumping = false;
        }

        if (Jump && !Grounded() && !isJumping)              // úprava na dvojitý skok
        {
            if(!GroundedNonGround())
            {
                rb.velocity = Vector2.up * JumpVelocity;
                isJumping = true;
            }
        }

        if(TouchedLeft() || TouchedRight())
        {
            isJumping = false;
        }
    }


    public void Movement()             // pohyb a rýchlosť Hráča
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 Movement = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
        rb.velocity = Movement;
    }


    void Shape()
    {
        //bool isSmall = false;

        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }


    //Checkpoint
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CheckPoint")
        {
            respawnPoint = col.transform.position + new Vector3(0, 3, 0);
            checkpointReached = true;
        }
    }
    
    //LinedArea
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "LinedArea")
        {
            LinedBool = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "LinedArea")
        {
            LinedBool = false;
        }
    }
    

    /****************************************
     *          F U N C T I O N S           *
     ****************************************/
    bool Grounded()     // bool na to či je Hráč na zemi
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    bool TouchedLeft()
    {
        return Physics2D.OverlapCircle(side[0].position, groundCheckRadius, whatIsGround);
    }

    bool TouchedRight()
    {
        return Physics2D.OverlapCircle(side[1].position, groundCheckRadius, whatIsGround);
    }


    bool GroundedNonGround()    // bool na to, aby Hráč nemohol skákať na modrom podklade
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsNonGround);
    }


    /****************************************
     *      M A I N  P R O G R A M S        *
     ****************************************/
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        startPoint = transform.position;        
    }

    void Update()
    {
        Movement();
        Jumping();
        Shape();

        if (transform.position.y <= respawnPosition_Min || transform.position.y >= respawnPosition_Max)
        {
            if (checkpointReached)
            {
                transform.position = respawnPoint;
            }
            else
            {
                transform.position = startPoint;
            }   
        }
    }
}
