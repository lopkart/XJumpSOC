using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour {

    /* ked sa zapne gameObject do ktoreho je tento script vlozeny spusti sa animacia ktora je dopredu vlozena
     * a dalsie podprogramy maju na starosti co sa stane pri stlaceni tlacidiel
     */

    public GameObject MovingUpCube;

    private GameObject Player;
    private Vector3 HelpPosition;
    Animator Anim;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        HelpPosition = Player.transform.position;



        Anim = GetComponent<Animator>();
        Anim.SetBool("LevelMenuBttns", false);
    }

    private void Update()
    {
        Player.transform.position = HelpPosition;
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
