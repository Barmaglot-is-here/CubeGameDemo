using StateManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour, IPlayable, IPausable, IResetable
    {
        [SerializeField]
        private CharacterConfig _config;

        public CharacterMovementComponent movement { get; private set; }
        public Dash dash { get; private set; }
        public new Rigidbody2D rigidbody { get; private set; }

        private void Awake()
        {
            rigidbody       = GetComponent<Rigidbody2D>();
            movement        = new(rigidbody, _config);
            dash            = new(_config.DashDuration, this);

            rigidbody.simulated = false;

            Level.Simulation.OnFixedUpdate += OnFixedUpdate;

            StateManager.Register(this);
        }

        private void OnFixedUpdate() => movement.Move();

        public void ChangeDirectionUp() => movement.ChangeDirectionUp();
        public void ChangeDirectionDown() => movement.ChangeDirectionDown();
        public void Dash() => dash.Enter();
        public void Move() => movement.Move();

        void IPlayable.Play() => rigidbody.simulated = true;
        void IPausable.Pause() => rigidbody.simulated = false;

        void IResetable.Reset()
        {
            rigidbody.linearVelocityY = 0;

            ChangeDirectionUp();

            dash.Cancel();
        }
    }
}