using UnityEngine;

namespace Game.Level.Entities
{
    public class Dash
    {
        private const int TIME_SCALE_MODIFIER = 3;
        private const int CHARACTER_SCALE_MODIFIER = 2;

        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;

        private readonly float _duration;

        private bool _isLocked;

        public Dash(float duration, Character character)
        {
            _duration   = duration;

            _rigidbody  = character.rigidbody;
            _transform  = character.transform;
        }

        public void Enter()
        {
            if (!_isLocked && !TaskManager.IsRunning(this))
                TaskManager.Run(this, _duration, Apply, Disaply);
        }

        public void Lock() => _isLocked = true;
        public void Unlock() => _isLocked = false;

        private void Apply()
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

            _transform.localScale /= CHARACTER_SCALE_MODIFIER;

            GameTime.Multiplier = TIME_SCALE_MODIFIER;
        }

        private void Disaply()
        {
            _rigidbody.constraints ^= RigidbodyConstraints2D.FreezePositionY;

            _transform.localScale *= CHARACTER_SCALE_MODIFIER;

            GameTime.Multiplier = 1;
        }

        public void Cancel() => TaskManager.Cancel(this);
    }
}