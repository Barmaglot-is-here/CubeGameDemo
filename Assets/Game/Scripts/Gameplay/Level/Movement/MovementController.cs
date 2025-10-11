using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private readonly Queue<Rigidbody2D> _bodies;
    private readonly float _movementSpeed;

    public MovementController(float speed)
    {
        _bodies         = new();
        _movementSpeed  = speed;
    }

    public void Add(Rigidbody2D rigidbody) => _bodies.Enqueue(rigidbody);

    public void FixedUpdate()
    {
        foreach (var body in _bodies)
            Move(body);
    }

    public void Pause()
    {
        foreach (var body in _bodies)
            Pause(body);
    }

    private void Move(Rigidbody2D rigidbody) 
        => SetSpeed(rigidbody , - _movementSpeed * GameTime.Scale);

    private void Pause(Rigidbody2D rigidbody)
        => SetSpeed(rigidbody, 0);

    private void SetSpeed(Rigidbody2D rigidbody, float speed)
        => rigidbody.linearVelocityX = speed;
}