using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclesSettings", menuName = "Configs/ObstaclesSettings")]
public class ObstaclesSettings : ScriptableObject
{
    [field: SerializeField]
    public GameObject Prefab { get; private set; }
    [field: SerializeField]
    public float SpawnDistance { get; private set; }
    [field: SerializeField]
    public float MovementSpeed { get; private set; }
}