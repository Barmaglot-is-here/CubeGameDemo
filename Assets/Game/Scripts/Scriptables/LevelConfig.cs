using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField]
    public ObstacleSpawnSettings ObstacleSpawnSettings { get; private set; }
    [field: SerializeField]
    public AbilitiesConfig AbilitiesConfig { get; private set; }
}