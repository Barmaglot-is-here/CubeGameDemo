namespace Game.Level
{
    public class LevelSpeedController
    {
        private readonly float _maxSpeed;
        private readonly float _speedGrow;

        public LevelSpeedController(float maxSpeed, float speedGrow)
        {
            _maxSpeed = maxSpeed;
            _speedGrow = speedGrow;
        }

        public void Update(int score)
        {
            GameTime.BaseScale = 1 + score * _speedGrow;

            if (GameTime.BaseScale >= _maxSpeed)
                GameTime.BaseScale = _maxSpeed;
        }

        public void Play() => GameTime.Play();
        public void Pause() => GameTime.Pause();
        public void Reset() => GameTime.Reset();
    }
}