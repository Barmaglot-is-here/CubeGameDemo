using UnityEngine;

public struct ObstaclesData
{
    public readonly Transform Container;
    public readonly Transform SpawnPoint;

    public ObstaclesData(Transform container, Transform spawnPoint)
    {
        Container   = container;
        SpawnPoint  = spawnPoint;
    }
}