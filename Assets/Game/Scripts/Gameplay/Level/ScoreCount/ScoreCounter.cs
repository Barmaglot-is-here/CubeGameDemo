using System;

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
            _scoreTrigger = UnityEngine.Object.FindFirstObjectByType<ScoreTrigger>();

            _scoreTrigger.OnTrigger += IncrementScore;
        }

        private void IncrementScore() => Score++;

        public void Reset() => Score = 0;
    }
}