using System;
using UnityEngine;

namespace Game.Level.Entities
{
    public class CharacterMovementComponent
    {
        private const float MOVE_FORCE_FACTOR = 1.5f;

        private readonly Rigidbody2D _rigidbody;
        private float _moveForce;

        private bool _isLocked;

        public CharacterMovementComponent(Rigidbody2D rigidbody, CharacterConfig config)
        {
            _rigidbody              = rigidbody;
            _rigidbody.mass         = config.Mass;
            _rigidbody.gravityScale = config.GravityScale;
            _moveForce              = config.MoveForce;
        }

        public void ChangeDirectionUp() => _moveForce = Math.Abs(_moveForce);
        public void ChangeDirectionDown() => _moveForce = -Math.Abs(_moveForce);

        public void Move()
        {
            if (_isLocked)
                return;

            if (IsPositive(_moveForce) && IsNegative(_rigidbody.linearVelocityY) ||
                IsNegative(_moveForce) && IsPositive(_rigidbody.linearVelocityY))
                _rigidbody.AddForceY(_moveForce * MOVE_FORCE_FACTOR * GameTime.Scale);
            else
                _rigidbody.AddForceY(_moveForce * GameTime.Scale);
        }

        public void Lock() => _isLocked = true;
        public void Unlock() => _isLocked = false;

        private bool IsPositive(float f) => f >= 0;
        private bool IsNegative(float f) => !IsPositive(f);
    }
}