using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public TMPro.TMP_Text[] scores;
    public Controls[] players;
    public bool isChem = false;

    private void Start()
    {
        if(!isChem)
            UpdateUI();
        //if is chem, chemical controller calls udpateuichem
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

    public int[] UpdateUIChem(int[] scoreNums, bool[] dead)
    {
        for (int i=0; i< 4;i++)
        {
            scores[i].text = "" + scoreNums[i];
            if (dead[i])
                scores[i].text = "DEAD! " + scoreNums[i];
        }
        return scoreNums;
    }
}