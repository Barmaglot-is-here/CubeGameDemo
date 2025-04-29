using UnityEngine;

public class ObstaclesController
{
    private readonly ObstacleGenerator _generator;
    private readonly ObstacleSpawner _spawner;
    private readonly ObstacleSpawnController _spawnController;
    private readonly LevelMovementController _movementController;

    public readonly ObjectPool<Obstacle> Pool;

    public ObstaclesController(ObstaclesData obstaclesData, ObstaclesSettings setings, 
                               GameObject obstaclePrefab, 
                               LevelMovementController movementController)
    {
        _generator          = new();
        _spawner            = new(obstaclePrefab, 
                                  obstaclesData.Container,
                                  obstaclesData.SpawnPoint);
        _movementController = movementController;
        
        Pool                = new(SpawnObstacle);
        Pool.OnReset        += ResetObstacle;
        _spawnController    = new(Pool, _generator,
                                  setings.SpawnDistance);
    }

    public void Start() => _spawnController.Start();

    private Obstacle SpawnObstacle()
    {
        var obstacle = _spawner.Spawn();
        
        _movementController.Add(obstacle.rigidbody);

        return obstacle;
    }

    private void ResetObstacle(Obstacle obstacle)
    {
        _spawner           .Reset(obstacle);
        obstacle.gameObject.SetActive(true);
    }

    public void Update() => _spawnController.Update();

    public void Reset()
    {
        foreach (var obstacle in Pool)
        {
            _spawner.Reset(obstacle);

            obstacle.gameObject.SetActive(false);
        }
    }
}