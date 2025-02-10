using UIManagement;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : BaseWindow
{
    [SerializeField] 
    private Button _homeButton;
    [SerializeField] 
    private Button _restartButton;
    [SerializeField] 
    private Button _watchAdButton;
    [SerializeField]
    private PlayModeScoreView _scoreView;
    private void Awake()
    {
        _homeButton.onClick.AddListener(OnHomeButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _watchAdButton.onClick.AddListener(OnWatchAdButtonClick);
    }

    private void OnHomeButtonClick()
    {
        UIManager.Hide<PauseScreen>();
        UIManager.Hide<DeathScreen>();
        UIManager.Show<MainScreen>();

        _scoreView.gameObject.SetActive(false);
    }

    private void OnRestartButtonClick()
    {
        UIManager.Hide<DeathScreen>();
    }

    private void OnWatchAdButtonClick()
    {
        UIManager.Hide<DeathScreen>();
    }
}