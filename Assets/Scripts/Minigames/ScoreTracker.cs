using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int[] scores = { 0, 0, 0, 0 };
    public Controls[] players;

    void UpdateScores()//called at the end of each minigame
    {
        foreach(Controls p in players)
        {
            scores[p.playerNum]+=p.hitScript.score;
        }
    }
}
