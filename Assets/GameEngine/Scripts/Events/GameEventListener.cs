using UnityEngine;
using UnityEngine.Events;
using TwoBirds.GameEngine.ScriptableObjects;

namespace TwoBirds.GameEngine.Scripts.Events
{
    public class GameEventListener : AbstractEventListener, IGameEventListener
    {
        [SerializeField]
        private GameEvent _gameEvent;
        [SerializeField]
        private UnityEvent _response;

        public void OnEventRaised()
        {
            _response.Invoke();
        }

        protected override void OnEnable()
        {
            _gameEvent.RegisterListener(this);
        }

        protected override void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }
    }
}
