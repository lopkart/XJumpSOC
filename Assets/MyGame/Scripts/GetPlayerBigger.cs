using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerBigger : MonoBehaviour {

    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collisionBlue)
    {
        if (collisionBlue.tag == "Player")
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
