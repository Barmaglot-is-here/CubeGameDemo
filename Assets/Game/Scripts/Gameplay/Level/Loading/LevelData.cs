using System.Collections.Generic;

public struct LevelData_
{
    public readonly Queue<ObstacleData> ObstacleData;
    public readonly float Speed;

    public LevelData_(Queue<ObstacleData> obstacleData, float speed)
    {
        ObstacleData    = obstacleData;
        Speed           = speed;
    }
}