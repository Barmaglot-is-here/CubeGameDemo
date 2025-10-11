using UnityEngine;

namespace AudioButton
{
    [CreateAssetMenu(fileName = "SoundList", menuName = "Configs/SoundList")]
    public class SoundList : ScriptableObject
    {
        [field: SerializeField]
        public AudioClip[] Sounds { get; private set; }
    }
}
