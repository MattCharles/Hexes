using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
    public int cost;
    public int might;
    public int money;
    public int magic;
    public string text;
    public int orderOfPlay = int.MaxValue;

    public string Name { get; set; }
    public int OwnerIndex { get; set; }
}
