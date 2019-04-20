using TMPro;
using TwoBirds.GameEngine.Extensions;
using TwoBirds.GameEngine.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter.Entities.UI.Scripts.Controller
{
    public class VolumeSliderController : MonoBehaviour
    {
        [SerializeField]
        private AudioVolume _audioVolume;
        [SerializeField]
        private GameEvent _onVolumeChange;
        [SerializeField]
        private Slider _slider;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _valueText;

        public void OnVolumeSliderChange(float volume)
        {
            // Slider uses 0 to 100, but AudioVolume uses 0 to 1
            _audioVolume.Volume = volume.ToInterval();
            _valueText.text = volume.ToPercentageString();
            _onVolumeChange.Raise();
        }

        public void OnVolumeChange(AudioVolume audioVolume)
        {
            _slider.value = audioVolume.Volume.ToPercentage();
        }

        // ReSharper disable once UnusedMember.Local
        private void Start() => Setup();

        private void Setup()
        {
            var volumePercentage = _audioVolume.Volume.ToPercentage();
            _slider.value = volumePercentage;
            _nameText.text = _audioVolume.Name;
            _valueText.text = volumePercentage.ToPercentageString();
        }
    }
}
