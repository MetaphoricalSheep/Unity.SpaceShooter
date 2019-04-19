using TwoBirds.GameEngine.Scripts;

namespace TwoBirds.GameEngine.ScriptableObjects
{
    public interface IGameEvent
    {
        void Raise();
        void RegisterListener(IGameEventListener listener);
        void UnregisterListener(IGameEventListener listener);
    }
}