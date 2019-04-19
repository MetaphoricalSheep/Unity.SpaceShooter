using UnityEngine;

namespace TwoBirds.GameEngine.Events
{
    public abstract class AbstractEventListener :  MonoBehaviour
    {
        protected abstract void OnEnable();
        protected abstract void OnDisable();
    }
}