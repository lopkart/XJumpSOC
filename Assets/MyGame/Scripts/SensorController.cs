using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour {

    // Sensor that Player enteres to some area
    private static int EnemyCount = 1;

    public Rigidbody2D[] EnemyRb2D = new Rigidbody2D[EnemyCount];

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for(int i = 0; i < EnemyCount; i++)
            {
                EnemyRb2D[i].bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
