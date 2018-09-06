using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour {

    /* 
     * ked sa zapne gameObject do ktoreho je tento script vlozeny spusti sa animacia ktora je dopredu vlozena
     * a dalsie podprogramy maju na starosti co sa stane pri stlaceni tlacidiel
     */

    public Rigidbody2D playerRb;
    public Rigidbody2D MovingUpCubeRb;
    public bool Resetted = false;
    Animator Anim;
    TimeController timeController;
    float tTimeHelp;

    private void Awake()
    {
        timeController = gameObject.AddComponent<TimeController>();
    }

    void Start()
    {
        tTimeHelp = timeController.tTime;

        MovingUpCubeRb.velocity = new Vector2(0, 0);

        Anim = GetComponent<Animator>();
        Anim.SetBool("LevelMenuBttns", false);
    }

    private void Update()
    {
        timeController.tTime = tTimeHelp;

        playerRb.velocity = new Vector2(0, 0);
        playerRb.gravityScale = 0;
        
        MovingUpCubeRb.velocity = new Vector2(0, 0);
    }

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
        Resetted = true;
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
