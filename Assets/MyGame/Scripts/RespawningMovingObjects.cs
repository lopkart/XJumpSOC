using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningMovingObjects : MonoBehaviour {

    private Transform startTransform;
    private Rigidbody2D rb;


    public void PlayerWasRespawned(bool TrueFalse)
    {
        if(TrueFalse)
        {
            if (rb == null)
            {
                transform.position = startTransform.position;
                transform.rotation = startTransform.rotation;
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Static;
                transform.position = startTransform.position;
                transform.rotation = startTransform.rotation;
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        startTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
