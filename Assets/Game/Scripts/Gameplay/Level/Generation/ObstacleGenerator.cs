using Game.Level.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Game.Level.Generation
{
    public class ObstacleGenerator
    {
        private readonly int _disablePercentMax;
        private readonly int _disablePercentMin;
        private readonly int _sectionsCount;

        public ObstacleGenerator(int disablePercentMax, int disablePercentMin, int sectionsCount)
        {
            _disablePercentMax = disablePercentMax;
            _disablePercentMin = disablePercentMin;
            _sectionsCount = sectionsCount;
        }

        public ObstacleData Generate()
        {
            bool[] bools = new bool[_sectionsCount];
            List<int> enableList = new(Enumerable.Range(0, _sectionsCount));

            int disabledSectionsCount = CalculateDisabledSectionsCount(_sectionsCount);

            Exclude(enableList, disabledSectionsCount);

            Apply(ref bools, enableList);

            return new(bools);
        }

        private int CalculateDisabledSectionsCount(int sectionsCount)
        {
            int percent = UnityEngine.Random.Range(_disablePercentMin, _disablePercentMax);

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