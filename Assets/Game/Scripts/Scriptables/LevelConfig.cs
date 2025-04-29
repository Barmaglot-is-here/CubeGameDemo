using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField]
    public float ObjectsSpeed { get; private set; }
    [field: SerializeField]
    public ObstaclesSettings ObstaclesSettings { get; private set; }
    [field: SerializeField]
    public AbilitiesConfig AbilitiesConfig { get; private set; }
}