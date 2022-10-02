using System.Collections.Generic;
using UnityEngine;

public class ChemicalMixer : MonoBehaviour
{
    public Chemical[] fakeChemicals;
    private Chemical[] chemicals =new Chemical[4];

    public Vector2[] startLocs;
    

    private void Start()
    {
        for(int i=0; i<fakeChemicals.Length;i++)
        {
            chemicals[i] = fakeChemicals[i];
        }
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
            print(shuffled[i].gameObject.name);
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
        Chemical[] assigned = new Chemical[4];
        for (int i = 0; i < chemicals.Length; i++)
        {
            assigned[i] = chemicals[i];
        }
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
            return RandomDirection(used);
        else
            return rand;
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