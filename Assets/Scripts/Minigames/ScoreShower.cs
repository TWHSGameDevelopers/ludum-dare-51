using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreShower : MonoBehaviour
{
    public TMPro.TMP_Text[] scores;

    private void Start()
    {
        Show();
    }

    public void Show()//changes the ui to reflect score changes
    {
        int j = 0;
        foreach (int i in ScoreTracker.scores)
        {
            scores[j].text = "" + i;
            j++;
        }
    }
}