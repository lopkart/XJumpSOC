using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorController : MonoBehaviour {

    // Sensor that Player enteres to some area
    private static int EnemyCount = 3;

    public Rigidbody2D[] Enemy = new Rigidbody2D[EnemyCount];


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for(int i = 0; i < EnemyCount; i++)
            {
                Enemy[i].bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }


    // TODO: dokoncit enemy
    void Start ()
    {
        //foreach (Rigidbody2D rb in Enemy)
    }
	
	void Update () {
		
	}
}
