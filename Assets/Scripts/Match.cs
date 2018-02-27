using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match {
    public int currentPlayerIndex;
    public List<Player> players;
    public Pile<Tile> tiles;

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

    public List<Tile> Tiles
    {
        get
        {
            if(tiles == null)
            {
                return null;
            } else
            {
                return tiles;
            }
        }
    }

    public Match(int playerCount)
    {
        for(int i = 0; i<playerCount; ++i)
        {
            players.Add(new Player(i));
        }
    }
}
