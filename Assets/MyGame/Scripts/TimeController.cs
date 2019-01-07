using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour {
    
    public int endForTwoCoins;      // how much second will be when the Player can get gold medal
    public int endForOneCoin;    // how much second will be when the Player can get bronze medal
    public Image Clock;
    private GameObject Player;
    private GameObject Menuses;
    [HideInInspector]
    public float tTime;
    [HideInInspector]
    public bool keepTiming = true;

    PlayerController playerCont;
    MenusesController menusesCont;
    private TextMeshProUGUI timerText;
    private Color colorForTwoCoins = new Color32(0, 255, 0, 255);
    private Color colorForOneCoin = new Color32(255, 200, 0, 255);
    private Color endColor = Color.red;     // without coin
    private float lerpTime = 0.0f;
    private float startTime;


    void Timing()
    {
        if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P))
        {
            keepTiming = false;

            playerCont.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if(menusesCont.Resumed)
        {
            keepTiming = true;
            startTime = Time.time - tTime;

            playerCont.rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }

        if (keepTiming)
        {
            menusesCont.Resumed = false;
            tTime = Time.time - startTime;

            // Changing time
            int minutes = ((int)tTime / 60);
            int seconds = ((int)tTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);           // Formating and overwriting timerText each frame
        }
    }

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Menuses = GameObject.FindGameObjectWithTag("Menuses");

        playerCont = Player.GetComponent<PlayerController>();
        menusesCont = Menuses.GetComponent<MenusesController>();
        timerText = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        timerText.color = colorForTwoCoins;
    }

    private void Start()
    {
        endForOneCoin -= 1; // je potrebne vzdy znizit o 1 pretoze animacia zmeny farby zacina prave o 1 sekundu neskor

        startTime = Time.time;
    }

    void Update()
    {
        if (playerCont.Respawned)
        {
            startTime = Time.time;
            timerText.color = colorForTwoCoins;
            playerCont.Respawned = false;
        }

        Timing();

        //Changing color
        if ((int)tTime == endForOneCoin)
        {
            lerpTime = 0.0f;
        }

        ColorChanging(endForTwoCoins, endForOneCoin, colorForTwoCoins, colorForOneCoin);        // Change gold medal to silver medal
        ColorChanging(endForOneCoin, (int)tTime + 1, colorForOneCoin, endColor);             // Change bronze medal to potato medal

        Clock.color = timerText.color;                                                          // Change color of Clock Image to color of TimerText
    }


    void ColorChanging(int startTime, int endTime, Color colorOne, Color colorTwo)              // Change color of medal to another color of medal
    {
        if (tTime >= startTime && tTime < endTime)
        {
            lerpTime += 0.025f;
            timerText.color = Color.Lerp(colorOne, colorTwo, lerpTime);
        }
    }
}
