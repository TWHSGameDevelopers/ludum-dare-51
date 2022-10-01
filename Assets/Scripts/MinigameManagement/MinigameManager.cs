using System;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public Minigame[] minigames;
    public Minigame currentMinigame;
    public int currentMinigameIndex;

    public Minigame GetCurrentMinigame()
    {
        return minigames[currentMinigameIndex];
    }
    public Minigame GetNextMinigame()
    {
        int i = currentMinigameIndex;

        if (i == minigames.Length - 1)
            i = 0;
        else
            i += 1;

        return minigames[i];
    }
    public Minigame GetPreviousMinigame()
    {
        int i = currentMinigameIndex;

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
        currentMinigameIndex = Array.IndexOf(minigames, newMinigame);
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
