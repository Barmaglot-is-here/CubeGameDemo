using StateManagement;
using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class BasePauseScreen : BaseWindow
{
    [field: SerializeField]
    protected Button RestartButton;
    [field: SerializeField]
    protected Button HomeButton;
    [field: SerializeField]
    protected PlayModeScoreView ScoreView { get; private set; }

    protected virtual void Awake()
    {
        RestartButton.onClick.AddListener(OnRestartButtonClick);
        HomeButton.onClick.AddListener(OnHomeButtonClick);
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

        ScoreView.gameObject.SetActive(false);

        StateManager.SetState<IdleState>();
    }
}