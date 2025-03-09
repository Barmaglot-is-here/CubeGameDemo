public class ObstaclesController
{
    private readonly ObstacleGenerator _obstacleGenerator;
    private readonly ObstacleSpawner _obstacleSpawner;
    private readonly ObjectPool<Obstacle> _obstaclePool;
    private readonly ObstacleSpawnController _obstacleSpawnController;
    private readonly ObstacleMovementController _obstacleMovementController;

    public ObstaclesController(LevelData levelData, ObstacleSpawnSettings setings)
    {
        _obstacleGenerator          = new();
        _obstacleSpawner            = new(setings.Prefab, 
                                          levelData.ObstaclesContainer,
                                          levelData.ObstacleSpawnPoint);
        _obstaclePool               = new(_obstacleSpawner.Spawn, ResetObstacle);
        _obstacleMovementController = new(_obstaclePool, setings.MovementSpeed);
        _obstacleSpawnController    = new(_obstaclePool, _obstacleGenerator,
                                          setings.SpawnDistance);
    }

    private void ResetObstacle(Obstacle obstacle)
    {
        _obstacleSpawner    .Reset(obstacle);
        obstacle.gameObject .SetActive(true);
    }

    public void Update()
    {
        _obstacleSpawnController    .Update();
        _obstacleMovementController .Update();
    }
}