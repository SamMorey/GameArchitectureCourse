using System;
using UnityEngine;

public class WinLoseMinigame : MonoBehaviour{
    Action _completeInspection;
    public static WinLoseMinigame Instance { get; private set; }

    private void Awake() => Instance = this;
    private void Start() => gameObject.SetActive(false);

    public void StartMinigame(Action completeInspection)
    {
        _completeInspection = completeInspection;
        gameObject.SetActive(true);
    }

    public void Win()
    {
        _completeInspection?.Invoke();
        _completeInspection = null;
        gameObject.SetActive(false);
    }
    
    public void Lose()
    {
        _completeInspection = null;
        gameObject.SetActive(false);
    }
}