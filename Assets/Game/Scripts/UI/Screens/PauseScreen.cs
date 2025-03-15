using UnityEngine;
using UIManagement;
using UnityEngine.UI;
using StateManagement;

public class PauseScreen : BasePauseScreen
{
    [SerializeField] 
    private Button _unpauseButton;
    
    protected override void Awake()
    {
        base.Awake();

        _unpauseButton.onClick.AddListener(OnUnpauseButtonClick);
    }

    protected override void OnRestartButtonClick()
    {
        base.OnRestartButtonClick();

        UIManager.Hide<PauseScreen>();
    }

    protected override void OnHomeButtonClick()
    {
        base.OnHomeButtonClick();

        UIManager.Hide<PauseScreen>();
    }

    private void OnUnpauseButtonClick()
    {
        UIManager.Hide<PauseScreen>();
        UIManager.Show<PlayModeScreen>();

        StateManager.SetState<PlayState>();
    }
}