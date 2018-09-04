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

    private TextMeshProUGUI timerText;
    private Color colorForGoldMedal = new Color32(0, 255, 0, 255);
    private Color colorForSilverMedal = new Color32(255, 255, 0, 255);
    private Color colorForBronzeMedal = new Color32(255, 170, 0, 255);
    private Color endColor = Color.red;     // without medal
    private float lerpTime = 0.0f;


    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        timerText.color = colorForGoldMedal;
    }

    private void Start()
    {
        endForSilver -= 1;
        endForBronze -= 1;
    }

    void Update ()
    {
        // Changing time
        int minutes = ((int) Time.time / 60);                                                   
        int seconds = ((int) Time.time % 60);

        timerText.text =  string.Format("{0:00}:{1:00}", minutes, seconds);                     // Formating and overwriting timerText each frame


        //Changing color
        if ((int)Time.time == endForSilver || (int)Time.time == endForBronze)
        {
            lerpTime = 0.0f;
        }

        ColorChanging(endForGold, endForSilver, colorForGoldMedal, colorForSilverMedal);        // Change gold medal to silver medal

        ColorChanging(endForSilver, endForBronze, colorForSilverMedal, colorForBronzeMedal);    // Change silver medal to bronze medal

        ColorChanging(endForBronze, (int)Time.time + 1, colorForBronzeMedal, endColor);         // Change bronze medal to potato medal


        Clock.color = timerText.color;                                                          // Change color of Clock Image to color of TimerText
    }


    void ColorChanging(int startTime, int endTime, Color colorOne, Color colorTwo)              // Change color of medal to another color of medal
    {
        if (Time.time >= startTime && Time.time < endTime)
        {
            lerpTime += 0.025f;
            timerText.color = Color.Lerp(colorOne, colorTwo, lerpTime);
        }
    }
}
