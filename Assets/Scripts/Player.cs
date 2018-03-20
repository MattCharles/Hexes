using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public const int maxDeck = 20;
    public const int maxHand = 10;

    public readonly int index;
    public List<Card> hand;
    public Pile<Card> deck;
    public Pile<Card> discard;

    public Card[] cardPlacements = new Card[Match.TileCount];

    public int Influence { get; set; }

    public Player(int index)
    {
        this.index = index;
    }

    public void StartDraw()
    {
        this.Draw(4);
        //TODO: handle peasant
        //hand.Add(new Unit());
    }

    public void Draw(int numCards)
    {
        while (deck.Count > 0)
        {
            hand.Add(deck.Pop());
        }
    }
}
