using Game.Level.Entities;
using UnityEngine;

namespace Game.Level
{
    public class ObstacleFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private Transform _container;

        private ObjectPool<Obstacle> _pool;

        private void Awake()
        {
            _pool = new(Instantiate, Reset);
        }

        public Obstacle Create(ObstacleData data)
        {
            var obstacle = _pool.GetNext();
            var spawnPosition = GetSpawnPosition();

            obstacle.transform.position = spawnPosition;
            obstacle.Build(data);

            return obstacle;
        }

        private Obstacle Instantiate()
        {
            var instance = Instantiate(_prefab, _container);

            return instance.GetComponent<Obstacle>();
        }

        private void Reset(Obstacle obstacle) => obstacle.gameObject.SetActive(true);

        private Vector2 GetSpawnPosition() =>
            new(LevelData.SpawnPoint.localPosition.x, _prefab.transform.localPosition.y);
    }
}