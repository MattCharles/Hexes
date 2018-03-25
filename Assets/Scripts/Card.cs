using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
    public int cost;

    public string text;
    public int orderOfPlay = int.MaxValue;
    public string id;

    public string Name { get; set; }
    public Player owner;

    public virtual void Load (Dictionary<string, object> data)
    {
        id = (string)data["id"];
        Name = (string)data["name"];
        text = (string)data["text"];
        cost = System.Convert.ToInt32(data["cost"]);
    }
}
