using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreTracker
{
    public static int[] scores = { 0, 0, 0, 0 };
    public static Controls[] players;

    public static void UpdateScores(int[] list)//called at the end of each minigame
    {
        int o = 0;
        foreach (int i in list)
        {
            scores[o] += i;
            o++;
        }
    }
}
