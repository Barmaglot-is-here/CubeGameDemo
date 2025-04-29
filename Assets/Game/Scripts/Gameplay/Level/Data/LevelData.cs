using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    [field: SerializeField]
    public Transform ObstaclesContainer { get; private set; }
    [field: SerializeField]
    public Transform ObstacleSpawnPoint { get; private set; }

    [field: SerializeField]
    public DeathZone DeathZone { get; private set; }
    [field: SerializeField]
    public GameObject StartLine { get; private set; }

    public ObstaclesData ObstaclesData => new(ObstaclesContainer, ObstacleSpawnPoint);
}