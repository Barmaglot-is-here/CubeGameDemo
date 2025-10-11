using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Transform _container;
    [field: SerializeField]
    public Transform SpawnPoint { get; private set; }

    private ObjectPool<Obstacle> _pool;

    public IReadOnlyList<Obstacle> Pool => _pool;

    private void Awake()
    {
        _pool = new(Instantiate, Reset);
    }

    public Obstacle Create() => _pool.GetNext();

    private Obstacle Instantiate()
    {
        var spawnPosition   = GetSpawnPosition();
        var instance        = GameObject.Instantiate(_prefab, spawnPosition, 
                                                     Quaternion.identity, _container);

        return instance.GetComponent<Obstacle>();
    }

    private void Reset(Obstacle obstacle)
    {
        var spawnPosition = GetSpawnPosition();

        obstacle.transform.localPosition = spawnPosition;
        obstacle.gameObject.SetActive(true);
    }

    private Vector2 GetSpawnPosition() => 
        new(SpawnPoint.localPosition.x, _prefab.transform.localPosition.y);
}