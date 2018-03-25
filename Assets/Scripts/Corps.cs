using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corps : List<Unit> {

    public Player owner;
    private int numCommoners = 0;
    public bool ContainsCommoner
    {
        get
        {
            return numCommoners > 0;
        }
    }

    public int getTotal(Resource resource)
    {
        int total = 0;
        foreach(Unit unit in this) {
            total += unit.getValue(resource);
        }
        return total;
    }

    public new void Add(Unit unit)
    {
        base.Add(unit);
        if(unit.GetType() == typeof(Commoner))
        {
            numCommoners++;
        }
    }
    
    public new void Remove(Unit unit)
    {
        base.Remove(unit);
        if (unit.GetType() == typeof(Commoner))
        {
            numCommoners--;
        }
    }
}