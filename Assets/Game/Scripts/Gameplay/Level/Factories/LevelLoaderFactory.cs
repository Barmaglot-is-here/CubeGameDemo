using Game.Level.Entities;
using Game.Level.Generation;
using Game.Level.Loading;
using System;
using UnityEngine;

namespace Game.Level
{
    public class LevelLoaderFactory : MonoBehaviour
    {
        [SerializeField]
        private Obstacle _obstacle;

        [SerializeField]
        private ObstacleGenerationConfig _config;
        [SerializeField]
        private CollectableGenerationConfig _config2;

        [Space]
        [SerializeField]
        private CoinCreationProvider _creationProvider;
        [SerializeField]
        private AbilityCreationProvider _abilityCreationProvider;

        public ILevelLoader Create<T>() where T : ILevelLoader => typeof(T) switch
        {
            var type when type == typeof(LevelGenerator) => CreateGeneretor(),
            var type when type == typeof(LevelLoader) => CreateLoader(),
            _ => throw new NotImplementedException(),
        };

        private LevelGenerator CreateGeneretor()
        {
            _config.SectionsCount = ObstacleSegmentCounter.Count(_obstacle);

            return new LevelGenerator(_config, _config2, SceneData.CollectablesSpawnArea, _creationProvider, _abilityCreationProvider);
        }

        private LevelLoader CreateLoader()
        {
            throw new NotImplementedException();
        }
    }
}