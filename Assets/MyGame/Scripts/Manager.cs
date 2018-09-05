using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    [Header("Change size of ChangingObjects in the script too!")]
    public GameObject[] ChangingObjects;
    public GameObject Player;
    public float respawnPosition_Min;
    public float respawnPosition_Max;

    private static int ChangingObjectsAmount = 39;  // <---
    private Vector2[] ChangingObjectsHelpP = new Vector2[ChangingObjectsAmount];
    private Quaternion[] ChangingObjectsHelpR = new Quaternion[ChangingObjectsAmount];
    private Rigidbody2D[] rb = new Rigidbody2D[ChangingObjectsAmount];


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
        if (Player.transform.position.y <= respawnPosition_Min || Player.transform.position.y >= respawnPosition_Max)
        {
            for (int i = 0; i < ChangingObjectsAmount; i++)
            {
                rb[i].bodyType = RigidbodyType2D.Static;
                rb[i].bodyType = RigidbodyType2D.Dynamic;

                ChangingObjects[i].transform.position = ChangingObjectsHelpP[i];
                ChangingObjects[i].transform.rotation = ChangingObjectsHelpR[i];
            }
        }
    }
}
