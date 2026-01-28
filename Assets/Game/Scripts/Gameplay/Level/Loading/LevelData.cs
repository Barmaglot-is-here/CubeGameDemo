using Game.Level.Entities;
using System.Collections.Generic;

namespace Game.Level.Loading
{
    public struct LevelData
    {
        public readonly Queue<ObstacleData> ObstacleData;
        public readonly float Speed;

        public LevelData(Queue<ObstacleData> obstacleData, float speed)
        {
            ObstacleData = obstacleData;
            Speed = speed;
        }
    }
}