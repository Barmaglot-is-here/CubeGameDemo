using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GrowAbilityConfig", menuName = "Configs/GrowAbilityConfig")]
    public class GrowAbilityConfig : ScriptableObject
    {
        [field: SerializeField]
        public float GrowFactor { get; private set; }
        [field: SerializeField]
        public float Duration { get; private set; }
    }
}
