using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator: MonoBehaviour {
    //light, Magnet, 

    public GameObject linePrefab;
    public EdgeCollider2D col;
    public PlayerController playerController;

    Line activeLine;
    

    void Update()
    {
        GameObject lineGO;

        if (Input.GetMouseButtonDown(0) && playerController.LinedBool)
        {
            lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>();

            Destroy(lineGO, 5f);
        }           

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }
}
