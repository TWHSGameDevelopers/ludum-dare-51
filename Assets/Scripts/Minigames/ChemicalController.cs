using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalController : MonoBehaviour
{
    public int[] scores = { 0, 0, 0, 0 };
    public int waterPts = 1, toxicLoss = 1;//points for drinking water and losing for toxin
    public bool toxicDeaths = true;
    public bool[] dead = { false, false, false, false };
    public float selectLag = 0.3f;

    public ChemicalMixer mix;
    public UIUpdater ui;

    private void Start()
    {
        ui.UpdateUIChem(scores, dead);
    }

    private void Update()
    {
        int p = GetPlayerInput();//player who selects
        int d = GetPlayerDirection();//direction selected
        if(p!=-1&&d!=-1)
        {
            if (ChemicalSelect(d))//if itsnt toxic
            {
                print("Player: " + p + " Direction: " + d + " Substance: " + mix.GetChemicals()[d]);
                scores[p] += waterPts;
                ui.UpdateUIChem(scores, dead);
            }
            else
            {
                dead[p] = true;
                scores[p] = 0;//-2 means you died
                ui.UpdateUIChem(scores, dead);
            }
            StartCoroutine(StartNextRound());
        }
    }

    IEnumerator StartNextRound()
    {
        yield return new WaitForSeconds(selectLag);
        mix.StartRound();
    }

    public int GetPlayerDirection()
    {
        int d = -1;
        bool up = (Input.GetKey(KeyCode.W)&&!dead[0]) || (Input.GetKey(KeyCode.UpArrow) && !dead[1]) || (Input.GetKey(KeyCode.I) && !dead[2]) || (Input.GetKey(KeyCode.Keypad8) && !dead[3]);
        bool right = (Input.GetKey(KeyCode.D) && !dead[0]) || (Input.GetKey(KeyCode.RightArrow) && !dead[1]) || (Input.GetKey(KeyCode.L) && !dead[2]) || (Input.GetKey(KeyCode.Keypad6) && !dead[3]);
        bool down = (Input.GetKey(KeyCode.S) && !dead[0]) || (Input.GetKey(KeyCode.DownArrow) && !dead[1]) || (Input.GetKey(KeyCode.K) && !dead[2]) || (Input.GetKey(KeyCode.Keypad5) && !dead[3]);
        bool left = (Input.GetKey(KeyCode.A) && !dead[0]) || (Input.GetKey(KeyCode.LeftArrow) && !dead[1]) || (Input.GetKey(KeyCode.J) && !dead[2]) || (Input.GetKey(KeyCode.Keypad4) && !dead[3]);
        if (up)
        {
            d = 0;
        }
        else if (right)
        {
            d = 1;
        }
        else if (down)
        {
            d = 2;
        }
        else if (left)
        {
            d = 3;
        }
        return d;
    }

    public int GetPlayerInput()
    {
        int p = -1;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!dead[0])//if isnt dead
                p = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!dead[0])
                p = 1;
        }
        else if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L))
        {
            if (!dead[0])
                p = 2;
        }
        else if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.Keypad5) || Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.Keypad8))
        {
            if (!dead[0])
                p = 3;
        }
        return p;
    }

    public bool ChemicalSelect(int d)//direction
    {
        if (mix.GetChemicals()[d].isToxic)
            return false;
        return true;
    }
}