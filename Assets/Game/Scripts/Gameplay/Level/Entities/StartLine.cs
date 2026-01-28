using StateManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    public class StartLine : MovableObject, IResetable
    {
        private Vector2 _startPosition;

        private void Awake()
        {
            _startPosition = transform.localPosition;

            StateManager.Register(this);
        }

        void IResetable.Reset()
        {
            transform.localPosition = _startPosition;

            gameObject.SetActive(true);
        }
    }
}