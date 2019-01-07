using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndPointController : MonoBehaviour {

    /*
     * na zaciatku sa LevelMenu vypne a pri dotyku hraca s cielom
     * sa zapne. Pokracovanie je v scripte LevelMenuController
     */

    public TextMeshProUGUI Timer;
    public GameObject LevelMenuUI = GameObject.FindGameObjectWithTag("LevelMenuUI");

    TimeController timeCont;


    private void Awake()
    {
        timeCont = Timer.GetComponent<TimeController>();
        LevelMenuUI.SetActive(false);
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timeCont.keepTiming = false;
            LevelMenuUI.SetActive(true);
        }
    }
}