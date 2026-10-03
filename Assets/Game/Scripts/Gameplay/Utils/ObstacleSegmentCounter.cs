using Game.Level.Entities;

namespace Game 
{
    internal static class ObstacleSegmentCounter
    {
        public static int Count(Obstacle obstacle) => obstacle.transform.childCount;
    }
}
