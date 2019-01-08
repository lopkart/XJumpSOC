using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {

    /****************************************
    *          V A R I A B L E S           *
    ****************************************/
    [Header("MOVEMENT")]
    public static float moveSpeed = 9f;                        // rýchlosť pohybu

    [Header("JUMPING")]
    [Range(5, 20)]
    public static float JumpVelocity = 14f;                          // sila skoku
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

    //Enemies
    //public LayerMask EnemiesMask;

    [Header("Checkpoint & Respawning")]
    public float respawnPosition_Min;
    public float respawnPosition_Max;  //
    [HideInInspector]
    public Vector3 respawnPoint;    //
    [HideInInspector]
    public Vector3 startPoint;  //
    [HideInInspector]
    public bool checkpointReached = false;
    [HideInInspector]
    public bool Respawned = false;  // used in TimeController
    [HideInInspector]
    public Vector3 startPlayerScale;
    [HideInInspector]
    public Vector3 checkpointPlayerScale;
    [HideInInspector]
    public float startPlayerMass;
    [HideInInspector]
    public float checkpointPlayerMass;

    //Respawnings
    [HideInInspector]
    public GameObject[] respawningObjs;
    [HideInInspector]
    public Rigidbody2D[] respawningRbs;
    [HideInInspector]
    public Vector2[] startPositionOfRespawningObjs;
    [HideInInspector]
    public Quaternion[] startRotationOfRespawningObjs;

    //Line
    public LineCreator lineCreator;

    [Header("Coins")]
    public TextMeshProUGUI CoinText;
    //public TextMeshProUGUI mainMenuCoinText;
    [HideInInspector]
    public static int coins;
    public bool coinCatched = false;
    public GameObject CoinPrefab;
    private static GameObject currentCoin;
    private Vector2 startCoinPosition;
    private Quaternion startCoinRotation;

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

        if (col.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            PlayerWasRespawned(true);

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
            coinCatched = true;
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
            PlayerWasRespawned(true);

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

    public void PlayerWasRespawned(bool TrueFalse)
    {
        if (TrueFalse)
        {
            if (coins != 0 && coinCatched)
            {
                coins -= 1;
            }

            if (coinCatched)
            {
                currentCoin = CoinPrefab;
                Instantiate(currentCoin, startCoinPosition, startCoinRotation);
                coinCatched = false;
            }

            for (int i = 0; i < respawningObjs.Length; i++)
            {
                respawningRbs[i].bodyType = RigidbodyType2D.Static;
                respawningRbs[i].bodyType = RigidbodyType2D.Dynamic;
                respawningObjs[i].transform.position = startPositionOfRespawningObjs[i];
                respawningObjs[i].transform.rotation = startRotationOfRespawningObjs[i];
            }
            
            if(lineCreator != null)
            {
                Destroy(lineCreator.lineGO);
            }          
        }
    }

    public void coinsToTexts()
    {
        if (CoinText != null)
        {
            CoinText.text = "COINS: " + coins;
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
        //Initialization of respawning objects
        respawningObjs = GameObject.FindGameObjectsWithTag("MovingObject");
        respawningRbs = new Rigidbody2D[respawningObjs.Length];
        startPositionOfRespawningObjs = new Vector2[respawningObjs.Length];
        startRotationOfRespawningObjs = new Quaternion[respawningObjs.Length];

        for (int i = 0; i < respawningObjs.Length; i++)
        {
            respawningRbs[i] = respawningObjs[i].GetComponent<Rigidbody2D>();
            startPositionOfRespawningObjs[i] = respawningObjs[i].transform.position;
            startRotationOfRespawningObjs[i] = respawningObjs[i].transform.rotation;
        }

        //Initialization of player rigidbody and collider
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        //Initialization of player scale, position and mass
        startPlayerScale = transform.localScale;
        startPoint = transform.position;
        startPlayerMass = rb.mass;

        //Initialization of coins
        startCoinPosition = GameObject.FindGameObjectWithTag("Coin").transform.position;
        startCoinRotation = GameObject.FindGameObjectWithTag("Coin").transform.rotation;
    }

    void Update()
    {
        Movement();
        Jumping();
        //Shape();
        Respawning();
        coinsToTexts();
        rb.gravityScale = ShopController.PlayerGravityScale;
    }
}
