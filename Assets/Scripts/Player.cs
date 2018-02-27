using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public const int maxDeck = 100;
    public const int maxHand = 10;

    public readonly int index;
    public Hand hand;
    public Pile<Card> deck;
    public Pile<Card> discard;

    public Card[] cardPlacements = new Card[Match.TileCount];

    public int Influence { get; set; }

    public Player(int index)
    {
        this.index = index;
    }
}
