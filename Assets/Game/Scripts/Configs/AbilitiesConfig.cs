using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "AbilitiesConfig", menuName = "Configs/AbilitiesConfig")]
    public class AbilitiesConfig : ScriptableObject
    {
        [field: SerializeField]
        public GrowAbilityConfig GrowAbilityConfig { get; private set; }
    }
}
