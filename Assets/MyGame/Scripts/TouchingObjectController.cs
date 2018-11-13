using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjectController : MonoBehaviour {

    /*
     * na zaciatku sa LevelMenu vypne a pri dotyku hraca s cielom
     * sa zapne. Pokracovanie je v scripte LevelMenuController.
     * Objekt sa pohybuje smerom nahor, ale ak sa LevelMenu zapne automaticky sa tento objekt zastaví.
     */
    //private static int EnemyCount = 2;
    private Vector3 startPosition;
    //private Vector3[] startPositionOfEnemies = new Vector3[EnemyCount];
    private LayerMask TouchingObject;

    //[HideInInspector]
    [HideInInspector]
    public float Multiplier = 0.12f;
    [HideInInspector]
    public Rigidbody2D rb2D;
    //public GameObject[] Enemies = new GameObject[EnemyCount];
    //public Rigidbody2D[] EnemiesRb2D = new Rigidbody2D[EnemyCount];


    private void Start()
    {
        startPosition = gameObject.transform.position;
        rb2D = GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();
        /*
        if (Enemies != null)
        {
            for (int i = 0; i < EnemyCount; i++)
            {
                startPositionOfEnemies[i] = Enemies[i].transform.position;
            }
        }*/
    }

    private void Update()
    {   
        if (gameObject.layer != 8)  // layer 8 = layer of enemies
        {
            Multiplier = 0.12f;
            rb2D.velocity += Vector2.up * Multiplier * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            /*
            if (Enemies != null)
            {
                for (int i = 0; i < EnemyCount; i++)
                {
                    rb2D.bodyType = RigidbodyType2D.Static;
                    EnemiesRb2D[i].bodyType = RigidbodyType2D.Static;

                    gameObject.transform.position = startPosition;
                    Enemies[i].transform.position = startPositionOfEnemies[i];

                    /*if(Enemies[EnemyCount-1].transform.position == startPositionOfEnemies[EnemyCount - 1])
                    {
                        playerTouched = false;
                    }
                }
                // rb2D.bodyType = RigidbodyType2D.Dynamic;
            }*/

            if (gameObject.layer != 8)
            {
                Multiplier = 0.0f;
                rb2D.bodyType = RigidbodyType2D.Static;
                gameObject.transform.position = startPosition;
                rb2D.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
