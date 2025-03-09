public class ObstacleGenerator
{
    public ObstacleData Generate(int sectionsCount)
    {
        bool[] bools = new bool[sectionsCount];

        sectionsCount--;

        for (; sectionsCount > 0; sectionsCount--)
            bools[sectionsCount] = true;

        return new(bools);
    }
}