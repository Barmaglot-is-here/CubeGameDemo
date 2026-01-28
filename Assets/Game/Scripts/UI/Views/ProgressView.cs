using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ProgressView : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        public void SetMaximum(float value)
        {
            _slider.maxValue = value;
        }

        public void Show(float progress)
        {
            _slider.value = progress;
        }
    }
}