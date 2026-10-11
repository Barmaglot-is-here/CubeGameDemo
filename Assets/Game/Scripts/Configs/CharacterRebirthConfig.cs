using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "CharacterRebirthConfig", menuName = "Configs/CharacterRebirthConfig")]
    public class CharacterRebirthConfig : ScriptableObject
    {
        [field: SerializeField]
        public float SafeTimeDuration { get; private set; } = 3;
    }
}