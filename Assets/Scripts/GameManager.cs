using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameManager : MonoBehaviour
{
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> pawns;
    private List<GameObject> activePawns;

    private Quaternion orientation = Quaternion.Euler(0, 180, 0);

    public string[] masks = { "PawnLayer", "TileLayer", "HandLayer", "ShopLayer" };

    private void Start()
    {
        //TODO: allow other numbers of players
        Match match = new Match(2);
        match.Start();
    }

    private void Update()
    {
        UpdateSelection();
        DrawTiles();
    }

    private void UpdateSelection()
    {
        if (!Camera.main)
        {
            return;
        }

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask(masks)))
        {
            Debug.Log(hit.point);
        }
    }
}
