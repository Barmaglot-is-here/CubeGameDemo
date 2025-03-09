using System.Collections.Generic;

public class ObstacleMovementController
{
    private readonly IEnumerable<Obstacle> _obstacles;

    private readonly float _velocity;

    public ObstacleMovementController(IEnumerable<Obstacle> obstacles, float movementSpeed)
    {
        _obstacles  = obstacles;
        _velocity   = -movementSpeed;
    }

    public void Update()
    {
        foreach (var obstacle in _obstacles)
            obstacle.rigidbody.linearVelocityX = _velocity * GameTime.Scale;
    }
}