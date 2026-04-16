using GameLoopManagement;
using UnityEngine;

namespace Game.Level
{
    public sealed class ResetPositionComponent : MonoBehaviour
    {
        private Vector2 _startPosition;

        private void Awake()
        {
            GameLoop.Register(OnReset, FunctionType.Reset);

            _startPosition = transform.position;
        }

        private void OnReset() => transform.position = _startPosition;
    }
}
