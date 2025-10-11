using System;
using UnityEngine;

public class CharacterMovementComponent
{
    private const float MOVE_FORCE_FACTOR = 1.5f;

    private readonly Rigidbody2D _rigidbody;
    private float _moveForce;

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
        if (IsPositive(_moveForce) && IsNegative(_rigidbody.linearVelocityY) ||
            IsNegative(_moveForce) && IsPositive(_rigidbody.linearVelocityY))
            _rigidbody.AddForceY(_moveForce * MOVE_FORCE_FACTOR * GameTime.Scale);
        else
            _rigidbody.AddForceY(_moveForce * GameTime.Scale);
    }

    private bool IsPositive(float f) => f >= 0;
    private bool IsNegative(float f) => !IsPositive(f);
}