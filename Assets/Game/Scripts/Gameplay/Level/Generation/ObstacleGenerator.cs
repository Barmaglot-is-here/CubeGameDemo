using Game.Level.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Game.Level.Generation
{
    public class ObstacleGenerator
    {
        private readonly ObstacleGenerationConfig _config;

        public ObstacleGenerator(ObstacleGenerationConfig config)
        {
            _config = config;
        }

        public ObstacleData Generate()
        {
            bool[] bools = new bool[_config.SectionsCount];
            List<int> enableList = new(Enumerable.Range(0, _config.SectionsCount));

            int disabledSectionsCount = CalculateDisabledSectionsCount(_config.SectionsCount);

            Exclude(enableList, disabledSectionsCount);

            Apply(ref bools, enableList);

            return new(bools);
        }

        private int CalculateDisabledSectionsCount(int sectionsCount)
        {
            int percent = UnityEngine.Random.Range(_config.DisablePercentMin, _config.DisablePercentMax);

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