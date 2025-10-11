using System.Collections.Generic;
using UnityEngine;

namespace AudioButton
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]
        private SoundList _soundList;

        private static Dictionary<SoundId, AudioClip> _sounds;

#if UNITY_EDITOR
        [ContextMenu("Generate enum")]
        private void Generate() => SourceGenerator.Generate(_soundList.Sounds);
#endif

        private void Awake()
        {
            _sounds = new();
        }

        public static void Play(SoundId soundId)
        {
            var sound = _sounds[soundId];
        }
    }
}