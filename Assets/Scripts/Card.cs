using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
    public int cost;

    public string text;
    public int orderOfPlay = int.MaxValue;

    public string Name { get; set; }
    public int OwnerIndex { get; set; }
}
