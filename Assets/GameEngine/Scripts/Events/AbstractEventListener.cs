using UnityEngine;

namespace TwoBirds.GameEngine.Scripts.Events
{
    public abstract class AbstractEventListener :  MonoBehaviour
    {
        protected abstract void OnEnable();
        protected abstract void OnDisable();
    }
}