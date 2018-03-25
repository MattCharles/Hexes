using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Pile<Card>
{
    public bool IsEmpty { get; }

    public Shop()
    {
        Capacity = 10;
    }

    public Shop(int capacity)
    {
        Capacity = capacity;
    }

    public Card Take()
    {
        if (!IsEmpty)
        {
            return this.Pop();
        }
        return null;
    }
}