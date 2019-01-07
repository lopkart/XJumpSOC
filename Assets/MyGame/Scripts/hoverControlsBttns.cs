using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverControlsBttns : MonoBehaviour
{

    public GameObject BttnsToShow;

    public void Hover()
    {
        BttnsToShow.SetActive(true);
    }

    public void NotHover()
    {
        BttnsToShow.SetActive(false);
    }    

    private void Start()
    {
        BttnsToShow.SetActive(false);
    }
}
