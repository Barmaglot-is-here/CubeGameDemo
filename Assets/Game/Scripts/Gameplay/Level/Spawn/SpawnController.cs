using Game.Abilities;
using Game.Level.Entities;

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
            var spawnPoint      = LevelData.SpawnPoint.transform;

            _loader             = loader;
            _factory            = factory;
            _distanceTracker    = new(spawnPoint, spawnDistance, SpawnNext);
        }

        public void Update() => _distanceTracker.Update();

        private void SpawnNext()
        {
            var chunk = _loader.GetNext();

            _currentObstacle = Spawn(chunk.ObstacleData);

            if (chunk.Ability != null)
                Spawn(chunk.Ability);

            _distanceTracker.SetTarget(_currentObstacle.transform);
        }

        private Obstacle Spawn(ObstacleData data)
            => _factory.CreateObstacle(data);

        private AbilityContainer Spawn(BaseAbility ability)
        {
            var container = _factory.CreateContainer(ability);

            return container;
        }

        public void Start() => SpawnNext();
    }
}