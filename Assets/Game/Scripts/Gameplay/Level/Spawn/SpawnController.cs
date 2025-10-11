public class SpawnController
{
    private readonly ObstacleFactory _factory;
    private readonly DistanceTracker _distanceTracker;

    private readonly ILevelLoader _loader;

    private Obstacle _current;

    public SpawnController(ILevelLoader loader, float spawnDistance, ObstacleFactory factory)
    {
        _factory            = factory;
        _distanceTracker    = new(_factory.SpawnPoint, spawnDistance, SpawnNext);

        _loader = loader;
    }

    public void Update() => _distanceTracker.Update();

    private void SpawnNext()
    {
        _current = Spawn();

        _distanceTracker.SetTarget(_current.transform);
    }

    private Obstacle Spawn()
    {
        var obstacle    = _factory.Create();
        var data        = _loader.GetNext();

        obstacle.Build(data);

        return obstacle;
    }

    public void Start() => SpawnNext();

    public void Reset()
    {
        foreach (var obstacle in _factory.Pool)
            obstacle.gameObject.SetActive(false);
    }
}