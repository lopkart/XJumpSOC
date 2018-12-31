using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingArrowController : MonoBehaviour {

    [Header("Pointing arrow")]
    public GameObject Player;
    public Transform PointingArrow;
    public Transform EndCheckpoint;
    public Transform Coin;

    private Transform target;

	
	// Update is called once per frame
	void Update ()
    {
        //Oprava velkosti ukazovacej sipky pri zmene velkosti hraca
        if (Player.transform.localScale == new Vector3(1f, 1f, 1f)) PointingArrow.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);    
        else if (Player.transform.localScale == new Vector3(0.5f, 0.5f, 0.5f)) PointingArrow.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        //Nastavenie uhlu ukazovacej sipky
        if (Coin == null) target = EndCheckpoint;
        else target = Coin;

        Vector2 relative = transform.InverseTransformPoint(target.position);
        float angle = (Mathf.Atan2(relative.y, relative.x) - 89.5f) * Mathf.Rad2Deg;

        gameObject.transform.Rotate(0, 0, angle);
    }
}
