using StateManagement;
using UIManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class MainScreen : BaseWindow
    {
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _skinsButton;
        [SerializeField]
        private Button _levelsButton;
        [SerializeField]
        private Button _scoreTableButton;
        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private ScoreView _scoreView;
        [SerializeField]
        private PlayModeScoreView _playModeScoreView;

        private void Awake()
        {
            _settingsButton.onClick.AddListener(OnSettingsButtonCkick);
            _skinsButton.onClick.AddListener(OnSkinsButtonCkick);
            _levelsButton.onClick.AddListener(OnLevelsButtonCkick);
            _scoreTableButton.onClick.AddListener(OnScoreTableButtonCkick);
            _playButton.onClick.AddListener(OnPlayButtonCkick);
        }

        private void OnSettingsButtonCkick() => UIManager.Show<SettingsScreen>();
        private void OnSkinsButtonCkick() => UIManager.Show<SkinsScreen>();
        private void OnLevelsButtonCkick() => UIManager.Show<LevelsScreen>();
        private void OnScoreTableButtonCkick() => UIManager.Show<ScoreTableScreen>();

        private void OnEnable() => LoadScore();

        private void LoadScore()
        {
            int score = GameData.Score;

            _scoreView.Show(score);
        }

        private void OnPlayButtonCkick()
        {
            UIManager.Hide<MainScreen>();
            UIManager.Show<PlayModeScreen>();

            _playModeScoreView.gameObject.SetActive(true);

            StateManager.SetState<PlayState>();
        }
    }
}