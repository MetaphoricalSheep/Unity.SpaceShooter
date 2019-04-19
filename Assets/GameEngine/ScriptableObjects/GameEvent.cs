using System.Collections.Generic;
using TwoBirds.GameEngine.Scripts;
using UnityEngine;

namespace TwoBirds.GameEngine.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

        public void Raise()
        {
            for (var i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
