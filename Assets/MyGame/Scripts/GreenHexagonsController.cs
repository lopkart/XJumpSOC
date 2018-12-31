using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHexagonsController : MonoBehaviour {


    //Collider, trigger
    private Collider2D Col2D;


    void ChangeColorAndTrigger()
    {
        // GREEN
        if (Input.GetKey(KeyCode.Q))
        {
            Col2D.isTrigger = false;
        }

        // YELLOW
        if (Input.GetKey(KeyCode.E))
        {
            Col2D.isTrigger = true;
        }

        // BLUE
        if (Input.GetKey(KeyCode.X))
        {
            Col2D.isTrigger = true;
        }
    }


    // Use this for initialization
    void Start()
    {
        Col2D = GetComponent<Collider2D>();
        Col2D.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorAndTrigger();
    }
}
