using GameLoopManagement;
using UIManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
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

            GameLoop.SetState<IdleState>();
            GameLoop.SetState<PlayState>();
        }

        protected virtual void OnHomeButtonClick()
        {
            UIManager.Hide<PlayModeScreen>();
            UIManager.Show<MainScreen>();

            ScoreView.gameObject.SetActive(false);

            GameLoop.SetState<IdleState>();
        }
    }
}