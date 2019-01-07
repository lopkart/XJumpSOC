﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenusesController : MonoBehaviour {

    [HideInInspector]
    public bool Resumed = false;
    private GameObject PauseMenu;
    public TouchingObjectController MovingUpCubeCont;


    public void MainMenuBttn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevelBttn()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void ResetLevelBttn()
    {     
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void OptionsBttn()
    {
        // TODO: some animation
    }

    public void ResumeBttn()
    {
        PauseMenu.SetActive(false);
        Resumed = true;
        MovingUpCubeCont.enabled = true;
    }

    public void PreviousLevelBttn()
    {
        Application.LoadLevel(Application.loadedLevel - 1);
    }


    private void Start()
    {
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
        {
            PauseMenu.SetActive(true);
            MovingUpCubeCont.enabled = false;
        }
    }
}
