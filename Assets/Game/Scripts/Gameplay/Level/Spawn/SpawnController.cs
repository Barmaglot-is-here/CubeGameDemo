using Game.Level.Entities;
using Game.Level.Generation;

namespace Game.Level
{
    public class SpawnController
    {
        private readonly EntitiesFactory _factory;
        private readonly DistanceTracker _distanceTracker;

        private readonly ILevelLoader _loader;

        private Obstacle _currentObstacle;

        public SpawnController(ILevelLoader loader, float spawnDistance,
                               EntitiesFactory factory)
        {
            var spawnPoint      = SceneData.SpawnPoint.transform;

            _loader             = loader;
            _factory            = factory;
            _distanceTracker    = new(spawnPoint, spawnDistance, SpawnNext);
        }

        public void Update() => _distanceTracker.Update();

        private void SpawnNext()
        {
            var chunk = _loader.GetNext();

            _currentObstacle = Spawn(chunk.ObstacleData);

            if (!chunk.CollectableSpawnData.IsEmpty)
                Spawn(chunk.CollectableSpawnData);

            _distanceTracker.SetTarget(_currentObstacle.transform);
        }

        private Obstacle Spawn(ObstacleData data)
            => _factory.CreateObstacle(data);

        private Collectable Spawn(CollectableSpawnData data)
        {
            var container = _factory.CreateCollectable(data);

            return container;
        }

        public void Start() => SpawnNext();
    }
}