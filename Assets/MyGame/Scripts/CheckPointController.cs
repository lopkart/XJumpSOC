using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

    public Sprite RedFlag;
    public Sprite GreenFlag;

    private SpriteRenderer checkpointRend;


    void Start ()
    {
        checkpointRend = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            checkpointRend.sprite = GreenFlag;
        }
    }
}
