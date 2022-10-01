using UnityEngine;

public class Minigame : MonoBehaviour
{
    public string gameName;
    public GameObject parent;

    public void Enable()
    {
        Debug.Log($"{gameName} enabled");
    }
    public void Disable()
    {
        Debug.Log($"{gameName} disabled");
    }
}
