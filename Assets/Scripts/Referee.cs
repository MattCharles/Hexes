using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee {
    public static int playerCount = 2;
    //TODO: add options to start matches with different numbers of players;
    public Match match = new Match(playerCount);

    public void StartGame()
    {
        match.Start();
    }
}
