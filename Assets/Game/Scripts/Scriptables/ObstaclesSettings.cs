using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclesSettings", menuName = "Configs/ObstaclesSettings")]
public class ObstaclesSettings : ScriptableObject
{
    [field: SerializeField]
    public float SpawnDistance { get; private set; }
}