using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match {
    public int currentPlayerIndex;
    public List<Player> players;
    public Pile<Tile> tileDeck;
    public Pile<Tile> tileDiscard;
    public List<Tile> tileField;

    public Player CurrentPlayer
    {
        get
        {
            return players[currentPlayerIndex];
        }
    }

    public static int PlayerCount { get; set; }
    public static int TileCount { get; set; }
    public List<Player> Players
    {
        get
        {
            if (players == null)
            {
                List<Player> players = new List<Player>(PlayerCount);
                return players;
            }
            else
            {
                return players;
            }
        }
    }

    public Match(int playerCount)
    {
        for(int i = 0; i<playerCount; ++i)
        {
            players.Add(new Player(i));
        }
        PlayerCount = playerCount;
        //TODO: Adjust tiles by player, perhaps an array
        TileCount = 6;
    }

    //TODO: Maybe change up for eaches on players so we can change starting index
    public void Start()
    {
        //while nobody has won yet?
        //5 cards for both, action phase, unit phase
        foreach (Player player in players)
        {
            player.StartDraw();
        }

        tileDeck.Shuffle();
        for (int i = 0; i < TileCount; i++)
        {
            //initialize tiles so they have resources and influence values and stuff
            //tile.Initialize(PlayerCount);
            if (tileDeck.Peek()!=null)
            {
                tileField.Add(tileDeck.Pop());
            }
            else
            {
                tileDeck = tileDiscard.ShuffleAndClear();
                tileField.Add(tileDeck.Pop());
            }
        }

        foreach(Player player in players)
        {
            player.ActionPhase();
        }

        bool[] stillPlaying = new bool[PlayerCount];
        int numPlaying = PlayerCount;
        List<Player> playing = players;
        for (int i = 0; i < PlayerCount; i++)
        {
            stillPlaying[i] = true;
        }
        //while any player can take a turn
        while (playing.Count > 0)
        {
            //loop through valid players and let them take a turn
            foreach(Player player in playing){
                if (!player.UnitPhase())
                {
                    playing.Remove(player);
                }
            }
        }

        foreach (Tile tile in tileField)
        {
            foreach(Player winner in tile.FindWinners())
            {
                winner.Influence += tile.BaseInfluence;
            }
            //TODO: check for a winner? Or else the quest thing idk
            tileField.Remove(tile);
            tileDiscard.Add(tile);
        }

        foreach (Player player in players)
        {
            player.BuyPhase();
        }
    }
}
