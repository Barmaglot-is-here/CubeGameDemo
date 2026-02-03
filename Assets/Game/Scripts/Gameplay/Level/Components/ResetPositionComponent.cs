using StateManagement;
using UnityEngine;

namespace Game.Level
{
    public sealed class ResetPositionComponent : MonoBehaviour, IResetable
    {
        private Vector2 _startPosition;

        private void Awake()
        {
            StateManager.Register(this);

            _startPosition = transform.position;
        }

        void IResetable.Reset() => transform.position = _startPosition;
    }
}
