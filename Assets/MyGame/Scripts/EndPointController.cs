using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndPointController : MonoBehaviour {

    /*
     * na zaciatku sa LevelMenu vypne a pri dotyku hraca s cielom
     * sa zapne. Pokracovanie je v scripte LevelMenuController
     */

    public TextMeshProUGUI Timer;
    public GameObject LevelMenuUI = GameObject.FindGameObjectWithTag("LevelMenuUI");
    [Tooltip("Check if it is last level to load Main Menu when Player touched this point!")]
    public bool lastLevel = false;

    TimeController timeCont;


    private void Awake()
    {
        timeCont = Timer.GetComponent<TimeController>();
        LevelMenuUI.SetActive(false);
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (timeCont.tTime < timeCont.endForTwoCoins) PlayerController.coins += 2;
        if (timeCont.tTime >= timeCont.endForTwoCoins && timeCont.tTime <= timeCont.endForOneCoin) PlayerController.coins++;

        if (lastLevel)
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (collision.tag == "Player")
        {
            timeCont.keepTiming = false;
            LevelMenuUI.SetActive(true);
        }
    }
}