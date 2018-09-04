using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBttns : MonoBehaviour
{
    Animator Anim;
  //  int StartBttnEvent = Animator.StringToHash("StartBttn");
    //int BackBttnEvent = Animator.StringToHash("BackBttn");


    void Start()
    {
        Anim = GetComponent<Animator>();

        Anim.SetBool("BackBttns", false);
        Anim.SetBool("StartBttns", false);
        Anim.SetBool("GameBttns", false);
        Anim.SetBool("OptionsBttns", false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        Anim.SetTrigger("OptionsBttns");
        Anim.SetBool("BackBttns", false);
    }

    public void GameButton()
    {
        Anim.SetBool("GameBttns", true);
        Anim.SetBool("BackBttns", false);
    }

    public void StartButton()
    {
        Anim.SetBool("StartBttns", true);
        Anim.SetBool("BackBttns", false);
    }
    
    public void BackButton()
    {
        Anim.SetBool("BackBttns", true);
        Anim.SetBool("StartBttns", false);
        Anim.SetBool("GameBttns", false);
        Anim.SetBool("OptionsBttns", false);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
