using UnityEngine;

public class ObstacleSpawnController
{
    private readonly ObjectPool<Obstacle> _pool;
    private readonly ObstacleGenerator _generator;

    private readonly float _spawnDistance;

    private Obstacle _current;

    private float _startPosition;

    public ObstacleSpawnController(ObjectPool<Obstacle> pool, ObstacleGenerator generator, 
                                   float spawnDistance)
    {
        _pool           = pool;
        _generator      = generator;
        _spawnDistance  = spawnDistance;
        _current        = Spawn();
        _startPosition = _current.transform.localPosition.x;
    }

    public void Update()
    {
        float traveledDistance  = _current.transform.localPosition.x - _startPosition;
        traveledDistance        = Mathf.Abs(traveledDistance);

        if (traveledDistance >= _spawnDistance || !_current.gameObject.activeSelf)
        {
            _current        = Spawn();
            _startPosition  = _current.transform.localPosition.x;
        }
    }

    private Obstacle Spawn()
    {
        var obstacle    = _pool.GetNext();
        var data        = _generator.Generate(obstacle.transform.childCount);

        obstacle.Construct(data);

        return obstacle;
    }
}