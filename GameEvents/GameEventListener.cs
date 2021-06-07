using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] UnityEvent _unityEvent;
    [SerializeField] private GameEvent _gameEvent;

    void Awake() => _gameEvent.Register(this);
    private void OnDisable() => _gameEvent.Dregister(this);
    public void RaiseEvent() => _unityEvent.Invoke();
}