using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int score = 0;
    public int coinPts = 1;//point player gets from collecting 1 coin
    public int billPts = 3;
    public int lavaDiePts = 1;//the number of points you lose for dieing in lava
    public int lavaKillPts = 1;
    public int projPts = 1; //pts you lose from being hit wiht a projectile
    public Vector2 punchForce;
    public Controls controls;
    public Controls killer;
    public UIUpdater ui;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Coin"://coin collect gives coin pts
                Score(coinPts);
                Destroy(other.gameObject);
                break;
            case "Bill"://bill collect gives bill points
                Score(billPts);
                Destroy(other.gameObject);
                break;
            case "Lava":
                Score(-1*lavaDiePts);
                if(killer!=null)
                    killer.hitScript.Score(lavaKillPts);
                Respawn();
                break;
            case "Punch":
                killer =other.GetComponentInParent<Controls>();
                controls.rb.AddForce(punchForce);

            case "Bullet":
                Score(-1*lavaDiePts);

                break;
            default:
                Debug.LogError("Unknown trigger "+other.transform.name);
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Controls p;
        if (collision.collider.TryGetComponent<Controls>(out p))
        {
            killer = p;
        }
    }

    public int Score(int plus)//adds to player's score within minigame
    {
        score += plus;
        ui.UpdateUI();
        return score;
    }

    public void Respawn()
    { 
        transform.position = controls.startPos;
        controls.rb.velocity = Vector2.zero;
    }
}