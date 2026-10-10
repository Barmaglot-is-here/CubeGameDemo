using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "CollectableGenerationConfig", menuName = "Configs/CollectableGenerationConfig")]
    public class CollectableGenerationConfig : ScriptableObject
    {
        [field: SerializeField]
        public int GeneralGenerationChance { get; private set; } = 2;
        [field: SerializeField]
        [Header("Шанс заспавнить монетку, когда прокнул GeneralGenerationChance, в противном случае спавнится способность")]
        public int CoinSpawnChance { get; private set; } = 80;
    }
}
