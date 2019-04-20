using TwoBirds.GameEngine.ScriptableObjects;
using UnityEngine;

namespace TwoBirds.GameEngine.Controllers
{
    [System.Serializable]
    public abstract class AbstractGameController : MonoBehaviour
    {
        public void OnMasterVolumeChange(AudioVolume masterVolumeData)
        {
            Debug.Log($"RUNNING: {masterVolumeData.Volume}");
            AudioListener.volume = masterVolumeData.Volume;
        }
    }
}
