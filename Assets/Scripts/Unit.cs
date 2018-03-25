using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card {
    public int might;
    public int money;
    public int magic;
    public bool hidden;
    public string flavor;

    public int getValue(Resource resource)
    {
        switch (resource)
        {
            case Resource.Might:
                return might;
            case Resource.Money:
                return money;
            case Resource.Magic:
                return magic;
            default:
                throw new System.ArgumentException("Invalid resource selection");
        }
    }

    public override void Load(Dictionary<string, object> data)
    {
        base.Load(data);
        might = System.Convert.ToInt32(data["might"]);
        money = System.Convert.ToInt32(data["money"]);
        magic = System.Convert.ToInt32(data["magic"]);
    }
}
