using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingBttnsController : MonoBehaviour {

    [HideInInspector]
    public Animator Anim;
    public TextMeshProUGUI resMaxTxt;
    public TextMeshProUGUI resMedTxt;
    public TextMeshProUGUI resMinTxt;

    FullScreenMode currentScreenMode;
    Resolution resMax;
    Resolution resMed;
    Resolution resMin;
    Resolution currentRes;


    private void Start()
    {
        //ScreenMode
        currentScreenMode = FullScreenMode.FullScreenWindow;

        //Resolutions
        resMax = Screen.resolutions[Screen.resolutions.Length - 1];
        resMaxTxt.text = (resMax.width + "\nx\n " + resMax.height);

        resMed = Screen.resolutions[Screen.resolutions.Length / 2];
        resMedTxt.text = (resMed.width + "\nx\n" + resMed.height);

        resMin = Screen.resolutions[0];
        resMinTxt.text = (resMin.width + "\nx\n" + resMin.height);

        //Animations
        Anim = GetComponent<Animator>();        

        Anim.SetBool("Resolution", false);
        Anim.SetBool("Graphics", false);
        Anim.SetBool("Screen", false);
        Anim.SetBool("Volume", false);
    }

    //MainSettingsButtons
    public void SetResolution()
    {
        Anim.SetBool("Resolution", true);
        Anim.SetBool("Graphics", false);
        Anim.SetBool("Screen", false);
        Anim.SetBool("Volume", false);
    }

    public void SetGraphics()
    {
        Anim.SetBool("Graphics", true);
        Anim.SetBool("Resolution", false);
        Anim.SetBool("Screen", false);
        Anim.SetBool("Volume", false);
    }

    public void SetScreen()
    {
        Anim.SetBool("Screen", true);
        Anim.SetBool("Graphics", false);
        Anim.SetBool("Resolution", false);
        Anim.SetBool("Volume", false);
    }

    public void SetVolume()
    {
        Anim.SetBool("Volume", true);
        Anim.SetBool("Graphics", false);
        Anim.SetBool("Screen", false);
        Anim.SetBool("Resolution", false);
    }

    //Quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //ScreenMode
    public void SetFullscreen()
    {
        currentScreenMode = FullScreenMode.FullScreenWindow;
        Screen.SetResolution(currentRes.width, currentRes.height, FullScreenMode.FullScreenWindow);
    }

    public void SetWindowedscreen()
    {
        currentScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(currentRes.width, currentRes.height, FullScreenMode.Windowed);
    }

    //Resolutions
    public void SetMaxResolution()
    {        
        currentRes = resMax;
        Screen.SetResolution(resMax.width, resMax.height, currentScreenMode);
    }

    public void SetMedResolution()
    {        
        currentRes = resMed;
        Screen.SetResolution(resMed.width, resMed.height, currentScreenMode);
    }

    public void SetMinResolution()
    {        
        currentRes = resMin;
        Screen.SetResolution(resMin.width, resMin.height, currentScreenMode);
    }
}
