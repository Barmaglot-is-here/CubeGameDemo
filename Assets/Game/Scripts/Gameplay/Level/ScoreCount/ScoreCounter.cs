using StateManagement;
using System;
using UnityEngine;

namespace Game.Level
{
    public class ScoreCounter : MonoBehaviour, IResetable
    {
        [SerializeField]
        private ScoreTrigger _scoreTrigger;

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;

                OnScoreChanged?.Invoke(_score);
            }
        }

        public event Action<int> OnScoreChanged;

        private void Awake()
        {
            _scoreTrigger.OnTrigger += IncrementScore;

            StateManager.Register(this);
        }

        private void IncrementScore() => Score++;

        void IResetable.Reset() => Score = 0;
    }
}