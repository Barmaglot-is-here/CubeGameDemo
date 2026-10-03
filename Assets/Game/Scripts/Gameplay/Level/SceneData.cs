using UnityEngine;

namespace Game.Level
{
    public class SceneData : MonoBehaviour
    {
        private static SceneData _instance;
        private static SceneData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindFirstObjectByType<SceneData>();

                return _instance;
            }
        }

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private ScoreTrigger _scoreTrigger;

        public static Transform SpawnPoint => Instance._spawnPoint;
        public static ScoreTrigger ScoreTrigger => Instance._scoreTrigger;
    }
}