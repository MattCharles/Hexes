using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile { 

    public int Influence { get; set; }
    public string Name { get; set; }
    public List<Tile> Neighbors { get; set; }
    public Vector3 Position { get; set; }
    public Resource Resource { get; private set; }
    public string id;
    public string text;
    static Dictionary<string, Resource> _mappings = new Dictionary<string, Resource>
    {
        {"Might", Resource.Might },
        {"Money", Resource.Money },
        {"Magic", Resource.Magic },
        {"Magic OR Money", Resource.notMight },
        {"Magic OR Might", Resource.notMoney },
        {"Might OR Money", Resource.notMagic },
        {"Any", Resource.All }
    };
    
    public Dictionary<Player, Corps> occupants;

    public List<Player> FindWinners()
    {
        //You can only win a tile you have at least one power over
        int currentMax = 1;
        List<Player> winners = null;
        foreach(Corps corps in occupants.Values)
        {
            if (corps.getTotal(Resource) > currentMax)
            {
                winners.Clear();
                winners.Add(corps.owner);
                currentMax = corps.getTotal(Resource);
            }
            //TODO: handle ties - for now, both win in a tie
            else if(corps.getTotal(Resource) == currentMax)
            {
                winners.Add(corps.owner);
            }
        }
        return winners;
    }

    public void AddUnit(Unit unit)
    {
        occupants[unit.owner].Add(unit);
    }

    public void Remove(Unit unit)
    {
        occupants[unit.owner].Remove(unit);
        unit.AddToDiscard();
    }

    //TODO: DeckFactory
    public virtual void Load(Dictionary<string, object> data)
    {
        id = (string)data["id"];
        Name = (string)data["name"];
        //text = (string)data["text"];
        Influence = System.Convert.ToInt32(data["influence"]);
        Resource = _mappings[(string)data["domain"]];
    }
}
