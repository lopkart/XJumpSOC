using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour {

    public TextMeshProUGUI mainMenuCoinText;

    [HideInInspector]
    public static int allCoins;


	void Start ()
    {
        
	}
	
	void Update ()
    {
        if (mainMenuCoinText != null)
        {
            mainMenuCoinText.text = "YOUR\nCOINS:\n" + allCoins;
        }
    }
}
