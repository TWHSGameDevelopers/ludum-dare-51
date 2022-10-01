using System;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private static MinigameManager _instance;
    public static MinigameManager Instance { get { return _instance; } }

    public Minigame[] minigames;
    public int currentMinigame;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
    public Minigame GetCurrentMinigame()
    {
        return minigames[currentMinigame];
    }
    public Minigame GetNextMinigame()
    {
        int i = currentMinigame;

        if (i == minigames.Length - 1)
            i = 0;
        else
            i += 1;

        return minigames[i];
    }
    public Minigame GetPreviousMinigame()
    {
        int i = currentMinigame;

        if (i == 0)
            i = minigames.Length - 1;
        else
            i -= 1;

        return minigames[i];
    }
    private void OnMinigameChange(Minigame previous, Minigame next)
    {
        previous.Disable();
        next.Enable();
    }
    public void SetMinigame(Minigame newMinigame)
    {
        currentMinigame = Array.IndexOf(minigames, newMinigame);
        OnMinigameChange(GetPreviousMinigame(), newMinigame);
    }
    public void NextMinigame()
    {
        SetMinigame(GetNextMinigame());
    }
    public void PreviousMinigame()
    {
        SetMinigame(GetPreviousMinigame());
    }
    private void Start()
    {
        SetMinigame(GetCurrentMinigame());
    }
}
