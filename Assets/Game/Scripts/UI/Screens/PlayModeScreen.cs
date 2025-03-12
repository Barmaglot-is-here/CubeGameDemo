using StateManagement;
using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayModeScreen : BaseWindow
{
    [SerializeField] private Button _pauseButton;

    private void Awake() => _pauseButton.onClick.AddListener(OnPauseButtonClick);

    private void OnPauseButtonClick()
    {
        UIManager.Hide<PlayModeScreen>();
        UIManager.Show<PauseScreen>();

        StateManager.SetState<PauseState>();
    }
}