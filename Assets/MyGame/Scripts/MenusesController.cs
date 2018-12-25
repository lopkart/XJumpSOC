using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenusesController : MonoBehaviour {

    [HideInInspector]
    public bool Resumed = false;
    public GameObject PauseMenu;

    
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
    }

    public void PreviousLevelBttn()
    {
        Application.LoadLevel(Application.loadedLevel - 1);
    }
}
