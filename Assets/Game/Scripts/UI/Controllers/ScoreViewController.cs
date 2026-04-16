using Game.Level;
using GameLoopManagement;
using UnityEngine;

namespace Game.UI
{
    public class ScoreViewController : MonoBehaviour
    {
        [SerializeField]
        private PlayModeScoreView _scoreView;

        private ScoreCounter _scoreCounter;

        private void Awake()
        {
            _scoreCounter = Level.Level.Services.Get<ScoreCounter>();

            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        private void OnEnable()
        {
            _scoreCounter.OnScoreChanged += _scoreView.Show;
        }

        private void OnDisable()
        {
            _scoreCounter.OnScoreChanged -= _scoreView.Show;
        }

        private void OnReset() => _scoreView.Reset();
    }
}