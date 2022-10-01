using UnityEngine;

public class Chemical : MonoBehaviour
{
    public string direction;//can be set as up down left or right

    public bool isToxic = true;

    public Chemical(string d, bool t)
    {
        direction = d;
        isToxic = t;
    }
}