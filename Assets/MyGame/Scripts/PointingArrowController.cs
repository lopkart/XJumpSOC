using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingArrowController : MonoBehaviour {

    [Header("Pointing arrow")]
    private GameObject Player;
    private Transform PointingArrow;
    private Transform EndCheckpoint;

    private Transform Coin = GameObject.FindGameObjectWithTag("Coin").transform;
    private Transform target;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PointingArrow = transform.GetChild(0);
        EndCheckpoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
    }

    // Update is called once per frame
    void Update ()
    {
        //Oprava velkosti ukazovacej sipky pri zmene velkosti hraca
        if (Player.transform.localScale == new Vector3(1f, 1f, 1f)) PointingArrow.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);    
        else if (Player.transform.localScale == new Vector3(0.5f, 0.5f, 0.5f)) PointingArrow.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                
        if(Coin == null && GameObject.FindGameObjectWithTag("Coin") != null)
        {
            Coin = GameObject.FindGameObjectWithTag("Coin").transform;
        }

        //Nastavenie uhlu ukazovacej sipky
        if (Coin == null)
        {
            target = EndCheckpoint;            
        }
        else target = Coin;

        Vector2 relative = transform.InverseTransformPoint(target.position);
        float angle = (Mathf.Atan2(relative.y, relative.x) - 89.5f) * Mathf.Rad2Deg;

        gameObject.transform.Rotate(0, 0, angle);
    }
}
