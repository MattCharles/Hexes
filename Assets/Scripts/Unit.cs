using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card {
    public bool hidden;
    public string flavor;
    public int baseMight;
    public int baseMoney;
    public int baseMagic;
    public int bonusMight = 0;
    public int bonusMoney = 0;
    public int bonusMagic = 0;
    public int bonusInfluence = 0;
    public List<Tribe> tribes;
    public int Might
    {
        get
        {
            return baseMight + bonusMight;
        }
    }
    public int Money
    {
        get
        {
            return baseMoney + bonusMoney;
        }
    }
    public int Magic
    {
        get
        {
            return baseMagic + bonusMagic;
        }
    }

    public int getValue(Resource resource)
    {
        switch (resource)
        {
            case Resource.Might:
                return Might;
            case Resource.Money:
                return Money;
            case Resource.Magic:
                return Magic;
            default:
                throw new System.ArgumentException("Invalid resource selection");
        }
    }

    public override void Load(Dictionary<string, object> data)
    {
        base.Load(data);
        baseMight = System.Convert.ToInt32(data["might"]);
        baseMoney = System.Convert.ToInt32(data["money"]);
        baseMagic = System.Convert.ToInt32(data["magic"]);
    }

    public void Announce()
    {
        Reveal();
        //Activate Announce Effects
        //TODO: other stuff?
    }

    public void Reveal()
    {
        hidden = false;
        //TODO: other stuff? Def some UI stuff but anything else?
    }

    public void AddToDiscard()
    {
        owner.discard.Add(this);
    }
}
