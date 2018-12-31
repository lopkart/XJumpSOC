using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour {

    public float timeToDestruct = 0.65f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeToDestruct);
	}
}
