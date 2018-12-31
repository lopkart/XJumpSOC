using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour {

    //Player
    public GameObject Player;
    private Renderer PlayerRend;

    //Color
    public Material PlayerBlue;
    public Material PlayerYellow;
    public Material PlayerGreen;


    void ChangeColorAndTrigger()
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


    // Use this for initialization
    void Start () {
        PlayerRend = Player.GetComponent<Renderer>();
        PlayerRend.material = PlayerBlue;
    }
	
	// Update is called once per frame
	void Update () {
        ChangeColorAndTrigger();
    }
}
