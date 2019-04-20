using UnityEditor;
using UnityEngine;

namespace TwoBirds.GameEngine.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Audio Volume", menuName = "Audio Volume", order = 51)]
    public class AudioVolume : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        [Range(0f, 1f)]
        private float _volume = 1f;

        public string Name => _name;
        public float Volume { get => _volume; set => _volume = value; }
    }
}
