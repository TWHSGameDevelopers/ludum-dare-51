using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public TMPro.TMP_Text[] scores;
    public Controls[] players;

    private void Start()
    {
        UpdateUI();
    }

    public int[] UpdateUI()//changes the ui to reflect score changes
    {
        int[] scoreInts = { -1, -1, -1, -1 };
        foreach(Controls p in players)
        {
            scores[p.playerNum].text = "" +p.hitScript.score;
            scoreInts[p.playerNum] = p.hitScript.score;
        }
        return scoreInts;
    }
}