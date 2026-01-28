using UnityEngine;

namespace Game.Level
{
    public class LevelData : MonoBehaviour
    {
        private static LevelData _instance;
        private static LevelData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindFirstObjectByType<LevelData>();

                return _instance;
            }
        }

        [SerializeField]
        private Transform _spawnPoint;

        public static Transform SpawnPoint => Instance._spawnPoint;
    }
}