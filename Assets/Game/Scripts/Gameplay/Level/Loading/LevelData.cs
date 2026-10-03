using Game.Level.Entities;
using System.Collections.Generic;

namespace Game.Level.Loading
{
    public struct LevelData
    {
        public readonly Queue<LevelChunk> Chuncks;
        public readonly float Speed;

        public LevelData(Queue<LevelChunk> chuncks, float speed)
        {
            Chuncks = chuncks;
            Speed = speed;
        }
    }
}