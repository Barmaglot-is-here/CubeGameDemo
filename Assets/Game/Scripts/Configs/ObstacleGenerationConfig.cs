using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "ObstacleGenerationConfig", menuName = "Configs/ObstacleGenerationConfig")]
    public class ObstacleGenerationConfig : ScriptableObject
    {
        [field: SerializeField]
        public int DisablePercentMax { get; private set; } = 70;
        [field: SerializeField]
        public int DisablePercentMin { get; private set; } = 50;
        public int SectionsCount { get; set; }
    }
}
