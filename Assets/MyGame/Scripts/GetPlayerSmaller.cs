using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerSmaller : MonoBehaviour {

    public GameObject Player;
    public Rigidbody2D PlayerRb2D;

    private void OnTriggerEnter2D(Collider2D collisionRed)
    {
        if(collisionRed.tag == "Player")
        {
            Player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            PlayerRb2D.mass = 2;
        }
    }
}
