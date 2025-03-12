public class ObstaclesController
{
    private readonly ObstacleGenerator _generator;
    private readonly ObstacleSpawner _spawner;
    private readonly ObstacleSpawnController _spawnController;
    private readonly ObstacleMovementController _movementController;

    public readonly ObjectPool<Obstacle> Pool;

    public ObstaclesController(LevelData levelData, ObstaclesSettings setings)
    {
        _generator          = new();
        _spawner            = new(setings.Prefab, 
                                          levelData.ObstaclesContainer,
                                          levelData.ObstacleSpawnPoint);
        Pool                = new(_spawner.Spawn, ResetObstacle);
        _movementController = new(Pool, setings.MovementSpeed);
        _spawnController    = new(Pool, _generator,
                                          setings.SpawnDistance);
    }

    private void ResetObstacle(Obstacle obstacle)
    {
        _spawner           .Reset(obstacle);
        obstacle.gameObject.SetActive(true);
    }

    public void Update()
    {
        _spawnController    .Update();
        _movementController .Update();
    }

    public void Reset()
    {
        foreach (var obstacle in Pool)
        {
            _spawner.Reset(obstacle);

            obstacle.gameObject.SetActive(false);
        }
    }
}