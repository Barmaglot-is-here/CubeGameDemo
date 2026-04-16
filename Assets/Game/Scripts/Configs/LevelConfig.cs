using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField]
        public float StartSpeed { get; private set; }
        [field: SerializeField]
        public float MaxSpeed { get; private set; }
        [field: SerializeField]
        public float SpeedGrow { get; private set; }
        [field: SerializeField]
        public float SpawnDistance { get; private set; }
    }
}