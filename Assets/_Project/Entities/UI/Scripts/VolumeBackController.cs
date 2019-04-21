using TwoBirds.GameEngine.ScriptableObjects;
using UnityEngine;

public class VolumeBackController : MonoBehaviour
{
    [SerializeField]
    private Canvas _settingsMenu;

    [SerializeField] private GameEvent _onGameResumed;

    public void OnBackButtonClicked()
    {
        _settingsMenu.enabled = false;
        _onGameResumed.Raise();
    }
}
