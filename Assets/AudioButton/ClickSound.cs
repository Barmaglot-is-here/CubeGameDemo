using UnityEngine;
using UnityEngine.UI;

namespace AudioButton
{
    [RequireComponent(typeof(Button))]
    public class ClickSound : MonoBehaviour
    {
        [SerializeField]
        private SoundId _soundId;

        private void Awake()
        {
            var button = GetComponent<Button>();

            button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            var button = GetComponent<Button>();

            button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick() => SoundPlayer.Play(_soundId);
    }
}