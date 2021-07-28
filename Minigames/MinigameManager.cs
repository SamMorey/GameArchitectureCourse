using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    Action _completeInspection;
    public static MinigameManager Instance { get; private set; }

    void Awake() => Instance = this;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _completeInspection?.Invoke();
            _completeInspection = null;
        }
    }

    public void StartMinigame(Action completeInspection)
    {
        WinLoseMinigame.Instance.StartMinigame(completeInspection);
        _completeInspection = completeInspection;
        
    }
}