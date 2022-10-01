using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int score = 0;
    public int coinPts = 1;//point player gets from collecting 1 coin
    public int billPts = 3;
    public Controls controls;
    public UIUpdater ui;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Coin"://coin collect gives coin pts
                Score(coinPts);
                Destroy(other.gameObject);
                break;
            case "Bill"://bill collect gives bill points
                Score(billPts);
                Destroy(other.gameObject);
                break;
            default:
                Debug.LogError("Unknown trigger "+other.transform.name);
                break;
        }
    }

    public int Score(int plus)//adds to player's score within minigame
    {
        score += plus;
        ui.UpdateUI();
        return score;
    }
}
