using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corps : List<Unit> {
    
    public int getTotal(Resource resource)
    {
        int total = 0;
        foreach(Unit unit in this) {
            total += unit.getValue(resource);
        }
        return total;
    }
}