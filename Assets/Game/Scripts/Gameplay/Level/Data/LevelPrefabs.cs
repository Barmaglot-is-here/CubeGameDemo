using System;
using UnityEngine;

[Serializable]
public class LevelPrefabs
{
    [field: SerializeField]
    public GameObject ScoreTriggerPrefab { get; private set; }

    [field: SerializeField]
    public GameObject ObstaclePrefab { get; private set; }
}