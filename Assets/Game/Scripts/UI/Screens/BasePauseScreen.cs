using StateManagement;
using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class BasePauseScreen : BaseWindow
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private PlayModeScoreView _scoreView;

    protected virtual void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _homeButton.onClick.AddListener(OnHomeButtonClick);
    }

    protected virtual void OnRestartButtonClick()
    {
        UIManager.Show<PlayModeScreen>();

        StateManager.SetState<IdleState>();
        StateManager.SetState<PlayState>();
    }

    protected virtual void OnHomeButtonClick()
    {
        UIManager.Hide<PlayModeScreen>();
        UIManager.Show<MainScreen>();

        _scoreView.gameObject.SetActive(false);

        StateManager.SetState<IdleState>();
    }
}