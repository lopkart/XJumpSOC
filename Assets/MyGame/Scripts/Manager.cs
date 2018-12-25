using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    private static int ChangingObjectsAmount = 39;  // <---
    private Vector2[] ChangingObjectsHelpP = new Vector2[ChangingObjectsAmount];        // position of the objects
    private Quaternion[] ChangingObjectsHelpR = new Quaternion[ChangingObjectsAmount];  // rotation of the objects
    private Rigidbody2D[] rb = new Rigidbody2D[ChangingObjectsAmount];

    [Header("Change size of ChangingObjects in the script too!")]
    public GameObject[] ChangingObjects;
    public GameObject Player;
    PlayerController playerCont;


    private void Awake()
    {
        playerCont = Player.GetComponent<PlayerController>();
    }

    void Start()
    {
        for (int i = 0; i < ChangingObjectsAmount; i++)
        {
            rb[i] = ChangingObjects[i].GetComponent<Rigidbody2D>() ?? ChangingObjects[i].AddComponent<Rigidbody2D>();
            ChangingObjectsHelpP[i] = ChangingObjects[i].transform.position;
            ChangingObjectsHelpR[i] = ChangingObjects[i].transform.rotation;
        }
    }

    void Update()
    {
        //Respawning moving objects after respawning player
        if (Input.GetKeyDown(KeyCode.R) || // press 'R' or player touches object with tag 'TouchingObject'
        Player.transform.position.y <= playerCont.respawnPosition_Min ||    // player reaches respawn position 
        Player.transform.position.y >= playerCont.respawnPosition_Max)
        {
            for (int i = 0; i < ChangingObjectsAmount; i++)
            {
                rb[i].bodyType = RigidbodyType2D.Static;

                if(ChangingObjects[i].layer != 10)
                {
                    rb[i].bodyType = RigidbodyType2D.Dynamic;
                }

                ChangingObjects[i].transform.position = ChangingObjectsHelpP[i];
                ChangingObjects[i].transform.rotation = ChangingObjectsHelpR[i];
            }
        }
    }
}
