using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "AbilitiesViewConfig", menuName = "Configs/AbilitiesViewConfig")]
    public class AbilitiesViewConfig : ScriptableObject
    {
        [field: SerializeField]
        public Sprite GrowAbilitySprite { get; private set; }
    }
}
