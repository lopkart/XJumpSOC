using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour {
    
    public int endForGold;      // how much second will be when the Player can get gold medal
    public int endForSilver;    // how much second will be when the Player can get silver medal
    public int endForBronze;    // how much second will be when the Player can get bronze medal
    public Image Clock;
    public GameObject Player;
    public GameObject Menuses;
    [HideInInspector]
    public float tTime;
    [HideInInspector]
    public bool keepTiming = true;

    PlayerController playerCont;
    MenusesController menusesCont;
    private TextMeshProUGUI timerText;
    private Color colorForGoldMedal = new Color32(0, 255, 0, 255);
    private Color colorForSilverMedal = new Color32(255, 255, 0, 255);
    private Color colorForBronzeMedal = new Color32(255, 170, 0, 255);
    private Color endColor = Color.red;     // without medal
    private float lerpTime = 0.0f;
    private float startTime;


    void Timing()
    {
        if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.P)
        {
            keepTiming = false;
        }

        if(menusesCont.Resumed)
        {
            
        }

        if (keepTiming)
        {
            tTime = Time.time - startTime;

            // Changing time
            int minutes = ((int)tTime / 60);
            int seconds = ((int)tTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);                     // Formating and overwriting timerText each frame
        }
    }

    void Awake()
    {
        playerCont = Player.GetComponent<PlayerController>();
        menusesCont = Menuses.GetComponent<MenusesController>();
        timerText = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        timerText.color = colorForGoldMedal;
    }

    private void Start()
    {
        endForSilver -= 1;  // je potrebne vzdy znizit o 1 pretoze animacia zmeny farby zacina prave o 1 sekundu neskor
        endForBronze -= 1;

        startTime = Time.time;
    }

    void Update()
    {
        if (playerCont.Respawned)
        {
            startTime = Time.time;
            timerText.color = colorForGoldMedal;
            playerCont.Respawned = false;
        }

        Timing();

        //Changing color
        if ((int)tTime == endForSilver || (int)tTime == endForBronze)
        {
            lerpTime = 0.0f;
        }


        ColorChanging(endForGold, endForSilver, colorForGoldMedal, colorForSilverMedal);        // Change gold medal to silver medal

        ColorChanging(endForSilver, endForBronze, colorForSilverMedal, colorForBronzeMedal);    // Change silver medal to bronze medal

        ColorChanging(endForBronze, (int)tTime + 1, colorForBronzeMedal, endColor);             // Change bronze medal to potato medal


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
