using System.Collections.Generic;
using UnityEngine;

public class ChemicalMixer : MonoBehaviour
{
    public Chemical[] chemicals;
    public Vector2[] startLocs;
    

    private void Start()
    {
        StartRound();
    }

    public Chemical[] GetChemicals()
    {
        return chemicals;
    }

    public void StartRound()
    {
        SaveStartLocations();
        ShuffleChemicals();
        PlaceChemicals();
    }

    public void ShuffleChemicals()
    {
        Chemical[] shuffled = GenerateShuffledChemicals();
        for (int i = 0; i < chemicals.Length; i++)
        {
            chemicals[i] = shuffled[i];
        }
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

    public Chemical[] GenerateShuffledChemicals()
    {
        List<int> used = new List<int>();
        Chemical[] assigned = chemicals;
        int[] rands = new int[assigned.Length];

        for (int i = 0; i < rands.Length; i++)
        {
            rands[i] = RandomDirection(used);
            used.Add(rands[i]);
        }
        for (int i = 0; i < rands.Length; i++)
        {
            assigned[i].direction = NameDirection(rands[i]);
        }

        return assigned;
    }

    public int RandomDirection(List<int> used)
    {
        int rand = Random.Range(0, 4);
        if (used.Contains(rand))
            RandomDirection(used);
        else
            return rand;
        return -1;
    }

    public string NameDirection(int i)
    {
        string d = "error in your face";
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
                Debug.LogError($"not enough directions: {i}");
                break;
        }
        return d;
    }

    public void SaveStartLocations()
    {
        for (int i = 0; i < chemicals.Length; i++)
            startLocs[i] = chemicals[i].gameObject.transform.position;
    }
}