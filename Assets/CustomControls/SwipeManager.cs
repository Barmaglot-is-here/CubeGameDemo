using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace CustomControls
{
    public class SwipeManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 _beginPosition;

        public Action<SwipeDirection> OnSwipe { get; set; }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            _beginPosition = eventData.position;
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData data)
        {
            Vector2 endPosition = data.position;

            float xDifference = _beginPosition.x - endPosition.x;
            float yDifference = _beginPosition.y - endPosition.y;

            SwipeDirection direction;

            if (Math.Abs(xDifference) < Math.Abs(yDifference))
                direction = _beginPosition.y > endPosition.y ? SwipeDirection.Down 
                                                             : SwipeDirection.Up;
            else
                direction = _beginPosition.x > endPosition.x ? SwipeDirection.Left 
                                                             : SwipeDirection.Right;

            OnSwipe?.Invoke(direction);
        }
    }
}