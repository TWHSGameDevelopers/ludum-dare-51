using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalMixer : MonoBehaviour
{
    public Chemical[] chemicals;
    public Vector2[] startLocs;
    

    private void Start()
    {
        SaveStartLocations();
        chemicals=ShuffleChemicals();
        PlaceChemicals();
    }

    public void PlaceChemicals()
    {
        for (int i = 0; i < chemicals.Length; i++)
        {
            Chemical c = chemicals[i];
            c.transform.position = c.direction switch
            {
                "up" => startLocs[0],
                "right" => startLocs[1],
                "down" => startLocs[2],
                _ => startLocs[3],
            };
        }
    }

    public Chemical[] ShuffleChemicals()
    {
        Chemical[] assigned = new Chemical[chemicals.Length];
        for(int i=0; i<chemicals.Length;i++)
        {
            assigned[i] = chemicals[i];
        }
        for(int i=0; i< chemicals.Length;i++)
        {
            assigned[i].direction=RandomDirection();
        }
        return assigned;
    }

    public string RandomDirection()
    {
        return NameDirection(Mathf.FloorToInt(Random.value * (4 - Mathf.Epsilon)));
    }

    public string NameDirection(int i)
    {
        string d="error in your face";
        switch (i)
        {
            case 0:
                d = "up";
                break;
            case 1:
                d = "right";
                break;
            case 2:
                d = "down";
                break;
            case 3:
                d = "left";
                break;
            default:
                Debug.LogError("not enought directions: " + i);
                break;
        }
        return d;
    }

    public void SaveStartLocations()
    {
        int i = 0;
        foreach (Chemical c in chemicals)
        {
            startLocs[i] = c.transform.position;
            i++;
        }
    }
}