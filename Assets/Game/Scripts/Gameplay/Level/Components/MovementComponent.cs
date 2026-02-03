using UnityEngine;

namespace Game.Level
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class MovementComponent : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private MovementController _movementController;

        private void Awake()
        {
            _rigidbody          = GetComponent<Rigidbody2D>();
            _movementController = Level.Services.Get<MovementController>();

            _movementController.Add(_rigidbody);
        }

        private void OnDestroy() => _movementController.Remove(_rigidbody);
    }
}