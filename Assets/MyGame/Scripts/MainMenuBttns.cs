using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBttns : MonoBehaviour
{
    Animator Anim;
    public SettingBttnsController SettingsCont;


    void Start()
    {
        Anim = GetComponent<Animator>();

        Anim.SetBool("BackBttns", false);
        Anim.SetBool("StartBttns", false);
        Anim.SetBool("GameBttns", false);
        Anim.SetBool("LevelsBttns", false);
        Anim.SetBool("OptionsBttns", false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        Anim.SetBool("OptionsBttns", true);
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

    public void Level1()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void Level3()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void Level4()
    {
        SceneManager.LoadScene("LevelFour");
    }

    public void Level5()
    {
        SceneManager.LoadScene("LevelFive");
    }

    public void GoToLevels()
    {
        Anim.SetBool("LevelsBttns", true);
        Anim.SetBool("GameBttns", false);
    }

    public void BackToMenu()
    {
        Anim.SetBool("BackBttns", true);
        Anim.SetBool("LevelsBttns", false);
        Anim.SetBool("ControlsBttns", false);
        Anim.SetBool("SettingsBttns", false);
        Anim.SetBool("SkinsToFeaturesBttns", false);
        Anim.SetBool("ShopSkinsBttns", false);
        Anim.SetBool("FeaturesToSkinsBttns", false);
    }

    public void BackToMenuFromSettings()
    {
        Anim.SetBool("BackBttns", true);
        Anim.SetBool("SettingsBttns", false);
        CloseOpenSettingsBttns();
    }

    public void Controls()
    {
        Anim.SetBool("ControlsBttns", true);
        Anim.SetBool("OptionsBttns", false);
    }

    public void Settings()
    {
        Anim.SetBool("SettingsBttns", true);
        Anim.SetBool("OptionsBttns", false);
    }

    public void CloseOpenSettingsBttns()
    {
        SettingsCont.Anim.SetBool("Resolution", false);
        SettingsCont.Anim.SetBool("Graphics", false);
        SettingsCont.Anim.SetBool("Screen", false);
        SettingsCont.Anim.SetBool("Volume", false);
    }

    public void ShopSkins()
    {
        Anim.SetBool("ShopSkinsBttns", true);
        Anim.SetBool("GameBttns", false);
    }

    public void SkinsToFeatures()
    {
        Anim.SetBool("SkinsToFeaturesBttns", true);
        Anim.SetBool("ShopSkinsBttns", false);
        Anim.SetBool("FeaturesToSkinsBttns", false);
    }

    public void FeaturesToSkins()
    {
        Anim.SetBool("FeaturesToSkinsBttns", true);
        Anim.SetBool("SkinsToFeaturesBttns", false);
    }
}
