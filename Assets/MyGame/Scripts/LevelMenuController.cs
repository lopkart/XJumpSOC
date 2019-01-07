using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour {

    /* 
     * ked sa zapne gameObject do ktoreho je tento script vlozeny spusti sa animacia ktora je dopredu vlozena
     * a dalsie podprogramy maju na starosti co sa stane pri stlaceni tlacidiel
     */
    private GameObject Player;
    private Rigidbody2D playerRb;
    public TouchingObjectController MovingUpCubeCont;
    Animator Anim;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerRb = Player.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        MovingUpCubeCont.enabled = false;

        Anim = GetComponent<Animator>();
        Anim.SetBool("LevelMenuBttns", false);
    }

    private void Update()
    {
        playerRb.velocity = new Vector2(0, 0);
        playerRb.gravityScale = 0;
    }
}
