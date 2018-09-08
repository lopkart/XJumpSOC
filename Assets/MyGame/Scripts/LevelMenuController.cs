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
    Animator Anim;

    void Start()
    {
        MovingUpCubeRb.velocity = new Vector2(0, 0);

        Anim = GetComponent<Animator>();
        Anim.SetBool("LevelMenuBttns", false);
    }

    private void Update()
    {
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
        SceneManager.LoadScene(Application.loadedLevel);
    }
}
