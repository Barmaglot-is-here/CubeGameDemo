using CustomControls;
using StateManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    public class InputManager : MonoBehaviour, IPausable, IPlayable
    {
        [SerializeField]
        private Character _character;
        [SerializeField]
        private SwipeManager _swipeManager;

        private bool _isPaused;

        private void Awake()
        {
            StateManager.Register(this);
        }

        private void OnEnable()
        {
            _swipeManager.OnSwipe += OnSwipe;
        }

        private void OnDisable()
        {
            _swipeManager.OnSwipe -= OnSwipe;
        }

        void IPlayable.Play() => _isPaused = false;
        void IPausable.Pause() => _isPaused = true;

        private void OnSwipe(SwipeDirection direction)
        {
            if (_isPaused)
                return;

            switch (direction)
            {
                case SwipeDirection.Up:
                    _character.ChangeDirectionUp();

                    break;
                case SwipeDirection.Down:
                    _character.ChangeDirectionDown();

                    break;
                case SwipeDirection.Right:
                    _character.Dash();

                    break;
            }
        }
    }
}