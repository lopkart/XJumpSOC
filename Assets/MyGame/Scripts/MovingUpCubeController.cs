using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpCubeController : MonoBehaviour {

    public GameObject LevelMenuUI;


    // Use this for initialization
    void Start () {
        //LevelMenuUI = GameObject.FindGameObjectWithTag("LevelMenuUI");
        LevelMenuUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            LevelMenuUI.SetActive(true);
        }
    }
}
