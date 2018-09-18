using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjectController : MonoBehaviour {

    /*
     * na zaciatku sa LevelMenu vypne a pri dotyku hraca s cielom
     * sa zapne. Pokracovanie je v scripte LevelMenuController.
     * Objekt sa pohybuje smerom nahor, ale ak sa LevelMenu zapne automaticky sa tento objekt zastaví.
     */
     
    [HideInInspector]
    public float Multiplier = 0.12f;
    [HideInInspector]
    public Rigidbody2D rb2D;

    private Vector3 startPosition;


    private void Start()
    {
        startPosition = gameObject.transform.position;
        rb2D = GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Multiplier = 0.12f;
        rb2D.velocity += Vector2.up * Multiplier * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Multiplier = 0.0f;
            rb2D.bodyType = RigidbodyType2D.Static;
            rb2D.bodyType = RigidbodyType2D.Dynamic;
            gameObject.transform.position = startPosition;
        }
    }
}
