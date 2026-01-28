using Game.Level.Entities;
using Game.Level.Generation;
using Game.Level.Loading;
using System;

namespace Game.Tools
{
    public class LevelDataGenerator
    {
        public void Generate(int count)
        {
            ObstacleGenerator obstacleGenerator = new(11);

            obstacleGenerator.Generate();
        }

        private LevelData GenerateLevel()
        {
            throw new NotImplementedException();
        }

        public ObstacleData GetNext() => throw new NotImplementedException();
    }
}