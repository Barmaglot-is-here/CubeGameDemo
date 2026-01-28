using Game.Level.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Game.Level.Generation
{
    public class ObstacleGenerator
    {
        private const int DISABLE_PERCENT_MAX = 70;
        private const int DISABLE_PERCENT_MIN = 50;

        private readonly int _sectionsCount;

        public ObstacleGenerator(int sectionsCount)
        {
            _sectionsCount = sectionsCount;
        }

        public ObstacleData Generate()
        {
            bool[] bools = new bool[_sectionsCount];
            List<int> enableList = new(Enumerable.Range(0, _sectionsCount));

            int disabledSectionsCount = CalculateDisabledSectionsCount(_sectionsCount);

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
}