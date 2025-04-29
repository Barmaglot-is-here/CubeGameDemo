using System.Collections.Generic;
using UnityEngine;

public class LevelMovementController
{
    private readonly List<Rigidbody2D> _bodies;

    private readonly float _velocity;

    public LevelMovementController(float movementSpeed)
    {
        _bodies     = new();

        _velocity   = -movementSpeed;
    }

    public void Add(Rigidbody2D rigidbody) => _bodies.Add(rigidbody);

    public void FixedUpdate()
    {
        foreach (var body in _bodies)
            body.linearVelocityX = _velocity * GameTime.Scale;
    }
}