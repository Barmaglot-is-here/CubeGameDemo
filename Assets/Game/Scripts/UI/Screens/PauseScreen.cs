using UnityEngine;
using UIManagement;
using UnityEngine.UI;
using StateManagement;

public class PauseScreen : BaseWindow
{
    [SerializeField] 
    private Button _unpauseButton;
    [SerializeField] 
    private Button _restartButton;
    [SerializeField] 
    private Button _homeButton;
    [SerializeField]
    private PlayModeScoreView _scoreView;

    private void Awake()
    {
        _unpauseButton  .onClick.AddListener(OnUnpauseButtonClick);
        _restartButton  .onClick.AddListener(OnRestartButtonClick);
        _homeButton     .onClick.AddListener(OnHomeButtonClick);
    }

    private void OnUnpauseButtonClick()
    {
        UIManager.Hide<PauseScreen>();
        UIManager.Show<PlayModeScreen>();

        StateManager.SetState<PlayState>();
    }

    private void OnRestartButtonClick()
    {
        UIManager.Hide<PauseScreen>();
        UIManager.Show<PlayModeScreen>();

        StateManager.SetState<IdleState>();
        StateManager.SetState<PlayState>();
    }

    private void OnHomeButtonClick()
    {
        UIManager.Hide<PauseScreen>();
        UIManager.Hide<PlayModeScreen>();
        UIManager.Show<MainScreen>();

        _scoreView.gameObject.SetActive(false);

        StateManager.SetState<IdleState>();
    }
}