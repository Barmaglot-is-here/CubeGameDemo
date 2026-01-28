using Game.Level;
using StateManagement;
using UnityEngine;

namespace Game.UI
{
    public class ScoreViewController : MonoBehaviour, IResetable
    {
        [SerializeField]
        private PlayModeScoreView _scoreView;

        private ScoreCounter _scoreCounter;

        private void Awake()
        {
            _scoreCounter = Level.Level.Services.Get<ScoreCounter>();

            StateManager.Register(this);
        }

        private void OnEnable()
        {
            _scoreCounter.OnScoreChanged += _scoreView.Show;
        }

        private void OnDisable()
        {
            _scoreCounter.OnScoreChanged -= _scoreView.Show;
        }

        void IResetable.Reset() => _scoreView.Reset();
    }
}