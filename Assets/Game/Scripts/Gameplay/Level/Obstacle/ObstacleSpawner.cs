using UnityEngine;

public class ObstacleSpawner
{
    private readonly GameObject _prefab;

    private readonly Transform _container;
    private readonly Transform _spawnPoint;

    public ObstacleSpawner(GameObject prefab, Transform container, 
                           Transform spawnPoint)
    {
        _prefab     = prefab;
        _container  = container;
        _spawnPoint = spawnPoint;
    }

    public Obstacle Spawn()
    {
        var spawnPosition   = GetSpawnPosition();
        var instance        = GameObject.Instantiate(_prefab, spawnPosition, 
                                                     Quaternion.identity, _container);

        return instance.GetComponent<Obstacle>();
    }

    public void Reset(Obstacle obstacle)
    {
        var spawnPosition = GetSpawnPosition();

        obstacle.transform.localPosition = spawnPosition;
    }

    private Vector2 GetSpawnPosition() => 
        new(_spawnPoint.localPosition.x, _prefab.transform.localPosition.y);
}