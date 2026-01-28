using DG.Tweening;
using UnityEngine;

namespace Game.UI
{
    public class DeathSceenAnimation : MonoBehaviour
    {
        [SerializeField]
        private GameObject _homeButton;
        [SerializeField]
        private GameObject _watchAdButton;
        [SerializeField]
        private GameObject _restartButton;
        [SerializeField]
        private GameObject _scoreView;

        private void OnEnable()
        {
            PlayShowAnimation(_homeButton.transform, 0.1f);
            PlayShowAnimation(_watchAdButton.transform, 0.2f);
            PlayShowAnimation(_restartButton.transform, 0.3f);

            foreach (Transform number in _scoreView.transform)
                PlayShowAnimation(number, 0.5f);
        }

        private void PlayShowAnimation(Transform target, float delay)
        {
            var defaultScale = target.localScale;
            target.localScale = Vector3.zero;

            DOVirtual.Vector3(Vector3.zero, defaultScale, 0.2f, newScale =>
            {
                target.localScale = newScale;
            }).SetDelay(delay);
        }

    }
}