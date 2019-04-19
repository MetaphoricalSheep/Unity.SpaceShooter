using UnityEngine;

namespace TwoBirds.GameEngine.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Audio Volume", menuName = "Audio Volume", order = 51)]
    public class AudioVolume : ScriptableObject
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float _volume = 1f;

        public float Volume => _volume;
    }
}
