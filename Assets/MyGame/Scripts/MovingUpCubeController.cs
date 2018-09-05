using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpCubeController : MonoBehaviour {

    /*
     * na zaciatku sa LevelMenu vypne a pri dotyku hraca s cielom
     * sa zapne. Pokracovanie je v scripte LevelMenuController
     */

    public GameObject LevelMenuUI;

    private float Multiplier = 0.1f;
    private Rigidbody2D rb2D;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>() ?? gameObject.AddComponent<Rigidbody2D>();
        LevelMenuUI.SetActive(false);
    }

    private void Update()
    {
        rb2D.velocity += Vector2.up * Multiplier * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            LevelMenuUI.SetActive(true);
        }
    }
}
