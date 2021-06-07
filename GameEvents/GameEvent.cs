using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public partial class GameEvent : ScriptableObject
{
    private static HashSet<GameEvent> _listenedEvents = new HashSet<GameEvent>();
    
    private HashSet<GameEventListener> _gameEventListeners = new HashSet<GameEventListener>();

    public void Register(GameEventListener gameEventListener)
    {
        _gameEventListeners.Add(gameEventListener);
        _listenedEvents.Add(this);
    }

    public void Dregister(GameEventListener gameEventListener)
    {
        _gameEventListeners.Remove(gameEventListener);
        if(_gameEventListeners.Count == 0)
            _listenedEvents.Remove(this);
    }

    public void Invoke()
    {
        foreach (var gameEventListener in _gameEventListeners)
        {
            gameEventListener.RaiseEvent();
        }
    }

    public static void RaiseEvent(string eventName)
    {
        foreach (var gameEvent in _listenedEvents)
        {
            if (gameEvent.name == eventName)
            {
                gameEvent.Invoke();
            }
        }
    }

    public static void RaiseEvent(List<GameEvent> gameEvents)
    {
        foreach (var gameEvent in gameEvents)
        {
            gameEvent.Invoke();
        }
    }
}