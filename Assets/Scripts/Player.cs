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
        while (deck.Count > 0 && numCards > 0)
        {
            hand.Add(deck.Pop());
            numCards--;
            if (deck.Count == 0 && numCards > 0)
            {
                deck = discard.ShuffleAndClear();
            }
        }
    }

    public void Buy(Card card)
    {
        if (Influence > card.cost)
        {
            discard.Add(card);
            Influence -= card.cost;
            //TODO: Make the shop piles, remove the card from there.
                //If the cards are out then so be it they're out RIP
        }
        else
        {
            //TODO: Some sort of exception probably
        }

    }

    public void ActionPhase()
    {
        //TODO: allow player to play actions. Doesn't need granularity since all actions are played at once
    }

    public bool UnitPhase()
    {
        //TODO: Return true if the player took a turn. False if they could not or chose not to.
        return true;
    }

    public void BuyPhase()
    {
        //TODO: Allow a player to buy cards for which they have enough influence.
    }

    public void Deploy(Unit unit, Tile tile)
    {
        //TODO: ensure the hand has that unit?
        hand.Remove(unit);
        tile.AddUnit(index, unit);
    }

    public void Move(Unit unit, Tile source, Tile destination)
    {
        //TODO: Ensure source and destination are neighbors?
        unit.Reveal();
        source.Remove(index, unit);
        destination.AddUnit(index, unit);
    }
}
