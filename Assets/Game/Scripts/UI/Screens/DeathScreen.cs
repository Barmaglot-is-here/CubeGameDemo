using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : BasePauseScreen
{
    [SerializeField] 
    private Button _watchAdButton;

    protected override void Awake()
    {
        base.Awake();

        _watchAdButton.onClick.AddListener(OnWatchAdButtonClick);
    }

    protected override void OnRestartButtonClick()
    {
        base.OnRestartButtonClick();

        UIManager.Hide<DeathScreen>();
    }

    protected override void OnHomeButtonClick()
    {
        base.OnHomeButtonClick();

        UIManager.Hide<DeathScreen>();
    }

    private void OnWatchAdButtonClick()
    {
        UIManager.Hide<DeathScreen>();
    }
}