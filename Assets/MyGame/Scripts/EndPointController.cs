using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour {

    /*
     * na zaciatku sa LevelMenu vypne a pri dotyku hraca s cielom
     * sa zapne. Pokracovanie je v scripte LevelMenuController
     */

    public GameObject LevelMenuUI;

    private void Start()
    {
        LevelMenuUI.SetActive(false);
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LevelMenuUI.SetActive(true);
        }
    }
}