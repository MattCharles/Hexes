using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapEditor : MonoBehaviour {

    public Color[] colors;

    public HexGrid hexGrid;

    private Color activeColor;

    private void Awake()
    {
        System.Random r = new System.Random();
        int numColors = colors.GetLength(0);
        int randomIndex = r.Next(numColors);
        //SelectColor(randomIndex);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay, out hit))
        {
            hexGrid.ColorCell(hit.point, activeColor);
        }
    }


}
