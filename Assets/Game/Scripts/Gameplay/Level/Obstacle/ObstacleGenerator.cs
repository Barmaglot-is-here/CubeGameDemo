using System.Collections.Generic;
using System.Linq;

public class ObstacleGenerator
{
    private const int DISABLE_PERCENT_MAX = 70;
    private const int DISABLE_PERCENT_MIN = 50;

    public ObstacleData Generate(int sectionsCount)
    {
        bool[] bools            = new bool[sectionsCount];
        List<int> enableList    = new(Enumerable.Range(0, sectionsCount));
        
        int disabledSectionsCount   = CalculateDisabledSectionsCount(sectionsCount);

        Exclude(enableList, 5);

        Apply(ref bools, enableList);

        return new(bools);
    }

    private int CalculateDisabledSectionsCount(int sectionsCount)
    {
        int percent = UnityEngine.Random.Range(DISABLE_PERCENT_MIN, DISABLE_PERCENT_MAX);

        return sectionsCount * percent / 100;
    }

    private void Exclude(List<int> list, int count)
    {
        for (; count > 0; count--)
            ExcludeRandom(list);
    }

    private void ExcludeRandom(List<int> list)
    {
        int index = UnityEngine.Random.Range(0, list.Count);

        list.RemoveAt(index);
    }

    private void Apply(ref bool[] bools, List<int> enableList)
    {
        foreach (int index in enableList)
            bools[index] = true;
    }
}