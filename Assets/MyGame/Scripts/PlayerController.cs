using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Abilities")]
    public Transform[] side = new Transform[2];
    [HideInInspector]
    public bool LinedBool = false;

    [Header("Checkpoint & Respawning")]
    public float respawnPosition_Min;
    public float respawnPosition_Max;
    [HideInInspector]
    public Vector3 respawnPoint;
    [HideInInspector]
    public Vector3 startPoint;
    [HideInInspector]
    public bool checkpointReached = false;
    [HideInInspector]
    public bool Respawned = false;
    private Vector3 startPlayerScale;
    private Vector3 checkpointPlayerScale;
    private float startPlayerMass;
    private float checkpointPlayerMass;

    [Header("Coins")]
    public TextMeshProUGUI CoinText;
    private int coins = 0;

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

    /*
    void Shape()
    {
        //bool isSmall = false;

        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            rb.mass = 2;
        }

        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            rb.mass = 5;
        }
    }
    */

    //Checkpoint & Respawn when enemy touch Player
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "CheckPoint")
        {
            respawnPoint = col.transform.position + new Vector3(0, 3, 0);
            checkpointReached = true;
            checkpointPlayerMass = rb.mass;
            checkpointPlayerScale = transform.localScale;
        }

        if (col.tag == "TouchingObject")
        {
            if (checkpointReached)
            {
                rb.bodyType = RigidbodyType2D.Static;
                transform.position = respawnPoint;
                rb.bodyType = RigidbodyType2D.Dynamic;
                transform.localScale = checkpointPlayerScale;
                rb.mass = checkpointPlayerMass;
            }
            else
            {
                Respawned = true;
                rb.bodyType = RigidbodyType2D.Static;
                transform.position = startPoint;
                rb.bodyType = RigidbodyType2D.Dynamic;
                transform.localScale = startPlayerScale;
                rb.mass = startPlayerMass;
            }            
        }


        if (col.tag == "Coin")
        {
            Destroy(GameObject.FindGameObjectWithTag("Coin"));
            coins += 1;
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

    //Respawning
    public void Respawning()
    {
        if (Input.GetKeyDown(KeyCode.R) ||
            transform.position.y <= respawnPosition_Min || transform.position.y >= respawnPosition_Max)
        {
            if (checkpointReached)
            {
                rb.bodyType = RigidbodyType2D.Static;
                transform.position = respawnPoint;
                rb.bodyType = RigidbodyType2D.Dynamic;
                transform.localScale = checkpointPlayerScale;
                rb.mass = checkpointPlayerMass;
            }
            else
            {
                Respawned = true;
                rb.bodyType = RigidbodyType2D.Static;
                transform.position = startPoint;
                rb.bodyType = RigidbodyType2D.Dynamic;
                transform.localScale = startPlayerScale;
                rb.mass = startPlayerMass;
            }
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
        startPlayerScale = transform.localScale;
        startPoint = transform.position;

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        startPlayerMass = rb.mass;
    }

    void Update()
    {
        Movement();
        Jumping();
        //Shape();
        Respawning();

        CoinText.text = "Coins: " + coins;
    }
}
