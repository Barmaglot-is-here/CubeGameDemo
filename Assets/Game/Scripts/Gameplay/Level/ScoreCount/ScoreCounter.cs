using GameLoopManagement;
using System;
using UnityEngine;

namespace Game.Level
{
    public class ScoreCounter
    {
        private readonly ScoreTrigger _scoreTrigger;

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

        public ScoreCounter()
        {
            _scoreTrigger = GameObject.FindFirstObjectByType<ScoreTrigger>();

            _scoreTrigger.OnTrigger += IncrementScore;

            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        private void IncrementScore() => Score++;

        private void OnReset() => Score = 0;
    }
}