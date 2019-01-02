using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomController : MonoBehaviour {

    [SerializeField]
    private GameObject[] Objects;
    private Rigidbody2D[] RbOfObjects;

    [SerializeField]
    private int AmountToRandom;
    private List<int> usedValues = new List<int>();

    
    private void ChooseRandomObjects()
    {
        int numOfSelection;

        for (int i = 0; i < AmountToRandom; i++)
        {
            numOfSelection = Random.Range(0, RbOfObjects.Length);

            while (usedValues.Contains(numOfSelection))
            {
                numOfSelection = Random.Range(0, RbOfObjects.Length);
            }

            usedValues.Add(numOfSelection);
            RbOfObjects[numOfSelection].bodyType = RigidbodyType2D.Dynamic;
            Objects[numOfSelection].gameObject.tag = "MovingObject";
        }
    }
    
    // Use this for initialization
    void Awake ()
    {
        RbOfObjects = new Rigidbody2D[Objects.Length];

        for (int i = 0; i < Objects.Length; i++)
        {
            RbOfObjects[i] = Objects[i].GetComponent<Rigidbody2D>();
        }

        ChooseRandomObjects();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
