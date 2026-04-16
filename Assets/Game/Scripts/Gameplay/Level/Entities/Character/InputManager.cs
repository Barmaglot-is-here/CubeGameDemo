using CustomControls;
using GameLoopManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private Character _character;
        [SerializeField]
        private SwipeManager _swipeManager;

        private bool _isPaused;

        private void Awake()
        {
            GameLoop.Register(Play, FunctionType.Play);
            GameLoop.Register(Pause, FunctionType.Pause);
        }

        private void OnEnable()
        {
            _swipeManager.OnSwipe += OnSwipe;
        }

        private void OnDisable()
        {
            _swipeManager.OnSwipe -= OnSwipe;
        }

        private void Play() => _isPaused = false;
        private void Pause() => _isPaused = true;

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