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

        public ILevelLoader Create<T>() where T : ILevelLoader => typeof(T) switch
        {
            var type when type == typeof(LevelGenerator) => CreateGeneretor(),
            var type when type == typeof(LevelLoader) => CreateLoader(),
            _ => throw new NotImplementedException(),
        };

        private LevelGenerator CreateGeneretor()
        {
            int obstacleSegmentCount = ObstacleSegmentCounter.Count(_obstacle);

            return new LevelGenerator(_config, obstacleSegmentCount, Level.Services.Get<Abilities.AbilitiesFactory>());
        }

        private LevelLoader CreateLoader()
        {
            throw new NotImplementedException();
        }
    }
}