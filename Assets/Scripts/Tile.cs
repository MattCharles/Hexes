using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile { 

    public int Value { get; set; }
    public string Name { get; set; }
    public Resource resource;

    public List<Unit> occupants = new List<Unit>();

    public Player FindWinner()
    {
        switch (resource)
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
}
