using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile { 

    public int Value { get; set; }
    public string Name { get; set; }
    public List<Tile> Neighbors { get; set; }
    public Vector3 Position { get; set; }
    public Resource Resource { get; private set; }

    public Corps[] occupants;

    public Player FindWinner(int numPlayers)
    {
        switch (Resource)
        {
            case Resource.Might:

                break;
            case Resource.Money:

                break;
            case Resource.Magic:

                break;
            case Resource.xMight:

                break;
            case Resource.xMoney:

                break;
            case Resource.xMagic:

                break;
            case Resource.All:

                break;
            default:
                break;
        }
        return null;
    }

    public void Initialize(int numPlayers)
    {
        occupants = new Corps[numPlayers];
        for(int i = 0; i<numPlayers; i++)
        {
            occupants[i] = new Corps();
        }
    }

    public void AddUnit(int player, Unit unit)
    {
        occupants[player].Add(unit);
    }
}
