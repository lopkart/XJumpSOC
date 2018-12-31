using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {

    public bool x;
    public bool y;
    public bool z;
    public int RotationSpeed;

	// Use this for initialization
	void Start () {
		if (RotationSpeed == 0)
        {
            RotationSpeed = 45;
        }
	}
	
	// Update is called once per frame
	void Update () {
        int helpX = 0;
        int helpY = 0;
        int helpZ = 0;

        if (x == false) helpX = 0; else helpX = 1;
        if (y == false) helpY = 0; else helpY = 1;
        if (z == false) helpZ = 0; else helpZ = 1;

        float movement = RotationSpeed * Time.deltaTime;
        gameObject.transform.Rotate(helpX * movement, helpY * movement, helpZ * movement);
	}
}
