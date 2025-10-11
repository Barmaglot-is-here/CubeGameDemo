using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CustomControls
{
    public class Carousel : MonoBehaviour
    {
        [SerializeField]
        private ScrollRect _scrollRect;
        [SerializeField]
        private Transform _content;

        [SerializeField]
        private float _animationDuration;

        private int _currentItem;

        private int ItemsCount => _content.childCount;

        private IEnumerator _coroutine;

        public void ScrollNext()
        {
            if (_currentItem < ItemsCount - 1)
                _currentItem++;

            ScrollToCurrent();
        }

        public void ScrolLast()
        {
            if (_currentItem > 0)
                _currentItem--;

            ScrollToCurrent();
        }

        private void ScrollToCurrent()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            //Что здесь происходит:
            //Позиция скрола устанавливается в пределах от 1 до 0
            //Где 1 - верхнее положение, а 0 - нижнее
            //Скролл происходит сверху вниз
            //Соотвествтенно из 1 мы вычитаем позицию смещения
            //Тем самым получаем позицию относительно верха
            float targetPos = 1 - (float)_currentItem / (ItemsCount - 1);

            _coroutine = ScrollAnimation(targetPos);

            StartCoroutine(_coroutine);
        }

        private IEnumerator ScrollAnimation(float targetPosY)
        {
            float currentPosY   = _scrollRect.verticalNormalizedPosition;
            float time          = 0;

            while (time < _animationDuration)
            {
                float newPosY = Mathf.Lerp(currentPosY, targetPosY, time / _animationDuration);

                _scrollRect.verticalNormalizedPosition = newPosY;

                time += Time.deltaTime;

                yield return null;
            }

            _scrollRect.verticalNormalizedPosition = targetPosY;

            yield break;
        }
    }
}