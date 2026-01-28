using Game.Level;
using UnityEngine;

namespace Game.Level.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovableObject : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            Register(_rigidbody);
        }

        private void Register(Rigidbody2D rigidbody)
        {
            var controller = Level.Services.Get<MovementController>();

            controller.Add(rigidbody);
        }
    }
}