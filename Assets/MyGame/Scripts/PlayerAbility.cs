using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour {


    public bool EnableScript = true;

    //Player
    public static Renderer PlayerRend;

    //Color
    public static Material PlayerBlueSkin;
    public static Material PlayerYellowSkin;
    public static Material PlayerGreenSkin;

    public Material PlayerBlue;
    public Material PlayerYellow;
    public Material PlayerGreen;
 

    void ChangeColorAndTrigger()
    {    
        if(EnableScript)
        {
            // GREEN
            if (Input.GetKey(KeyCode.Q))
            {
                PlayerRend.material = PlayerGreen;
            }

            // YELLOW
            if (Input.GetKey(KeyCode.E))
            {
                PlayerRend.material = PlayerYellow;
            }

            // BLUE
            if (Input.GetKey(KeyCode.X))
            {
                PlayerRend.material = PlayerBlue;
            }
        }        
    }

    
    void Start () {

        PlayerRend = GetComponent<Renderer>();

        if (PlayerBlueSkin != null)
        {
            PlayerBlue = PlayerBlueSkin;
            PlayerYellow = PlayerYellowSkin;
            PlayerGreen = PlayerGreenSkin;
        }

        PlayerRend.material = PlayerBlue;
    }
	
	void Update () {
        ChangeColorAndTrigger();        

        if(PlayerBlueSkin != null)
        {
            PlayerBlue = PlayerBlueSkin;
            PlayerYellow = PlayerYellowSkin;
            PlayerGreen = PlayerGreenSkin;
        }        
    }
}
