using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjectController : MonoBehaviour {

    [SerializeField]
    private int Speed = 2;

    private void Update()
    {   
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
}
