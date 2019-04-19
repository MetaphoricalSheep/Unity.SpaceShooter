using TwoBirds.GameEngine.ScriptableObjects;
using UnityEngine;

namespace TwoBirds.GameEngine.Scripts.Controllers
{
    [System.Serializable]
    public abstract class AbstractGameController : MonoBehaviour
    {
        public void OnMasterVolumeChange(AudioVolume masterVolumeData)
        {
            AudioListener.volume = masterVolumeData.Volume;
        }
    }
}
