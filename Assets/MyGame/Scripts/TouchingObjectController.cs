using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjectController : MonoBehaviour {

    /*
     * na zaciatku sa LevelMenu vypne a pri dotyku hraca s cielom
     * sa zapne. Pokracovanie je v scripte LevelMenuController.
     * Objekt sa pohybuje smerom nahor, ale ak sa LevelMenu zapne automaticky sa tento objekt zastaví.
     */

    private Vector3 startPosition;
    private LayerMask TouchingObject;

    private int Speed = 2;
    [HideInInspector]
    public Rigidbody2D rb2D;


    private void Start()
    {
        startPosition = gameObject.transform.position;
        rb2D = GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();

    }

    private void Update()
    {   
        if (gameObject.layer != 10)  // layer 10 = layer of enemies
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (gameObject.layer != 10)
            {
                //Speed = 0;
                rb2D.bodyType = RigidbodyType2D.Static;
                gameObject.transform.position = startPosition;
                rb2D.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
