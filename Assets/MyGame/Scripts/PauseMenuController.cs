using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

    public GameObject PauseMenu;
    

    void Start ()
    {
        PauseMenu.SetActive(false);
    }
	

	void Update ()
    {
		if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
        {
            PauseMenu.SetActive(true);
        }
    }
}
