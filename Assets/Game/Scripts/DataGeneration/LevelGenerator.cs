using System;

public class LevelGenerator : ILevelLoader
{
    public void Generate(int count)
    {
        ObstacleGenerator obstacleGenerator = new ();

        obstacleGenerator.GetNext();
    }

    private LevelData_ GenerateLevel()
    {
        throw new NotImplementedException();
    }

    public ObstacleData GetNext() => throw new NotImplementedException();
}