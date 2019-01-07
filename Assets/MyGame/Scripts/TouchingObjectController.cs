using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjectController : MonoBehaviour {

    private int Speed = 2;
    private bool start = false;

    private void Update()
    {
        if (Input.anyKey) start = true;
        if (start == true) transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
}
