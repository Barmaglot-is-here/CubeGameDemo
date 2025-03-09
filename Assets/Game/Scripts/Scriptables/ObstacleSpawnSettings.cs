using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleSpawnSettings", menuName = "Configs/ObstacleSpawnSettings")]
public class ObstacleSpawnSettings : ScriptableObject
{
    [field: SerializeField]
    public GameObject Prefab { get; private set; }
    [field: SerializeField]
    public float SpawnDistance { get; private set; }
    [field: SerializeField]
    public float MovementSpeed { get; private set; }
}