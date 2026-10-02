using System;
using System.Linq;
using UnityEngine;

namespace AudioButton
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField]
        private SoundList _soundList;

        private AudioSource _audioSource;

        [field: SerializeField]
        public bool AutoEnumGeneration { get; private set; } = true;

        private static SoundList SoundList => Instance._soundList;
        private static AudioSource AudioSource => Instance._audioSource;

        public static SoundPlayer Instance { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetInstance() => Instance = null;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);

                throw new Exception("SoundPlayer can't be instantiated twice. It is Singleton");
            }

            Instance = this;

            _audioSource = gameObject.GetComponent<AudioSource>();

            _audioSource.playOnAwake = false;
            _audioSource.spatialBlend = 0f;
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }

        public static void Play(SoundId soundId)
        {
            if (Instance == null)
                throw new Exception("SoundPlayer is not initialized.");

            if (SoundList == null || SoundList.Sounds == null)
                new Exception("SoundList is not assigned or initialized.");

            string soundName    = soundId.ToString();
            var sound           = SoundList.Sounds.FirstOrDefault(s => s != null && s.name == soundName);

            if (sound == null)
                new Exception($"Sound '{soundName}' was not found in SoundList.");

            AudioSource.PlayOneShot(sound);
        }
    }
}
