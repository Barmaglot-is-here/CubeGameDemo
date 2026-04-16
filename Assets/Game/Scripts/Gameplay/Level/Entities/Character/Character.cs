using GameLoopManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
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

            GameLoop.Register(Play, FunctionType.Play);
            GameLoop.Register(Pause, FunctionType.Pause);
            GameLoop.Register(OnReset, FunctionType.Reset);
            GameLoop.Register(OnFixedUpdate, FunctionType.FixedUpdate);
        }

        private void OnFixedUpdate() => movement.Move();

        public void ChangeDirectionUp() => movement.ChangeDirectionUp();
        public void ChangeDirectionDown() => movement.ChangeDirectionDown();
        public void Dash() => dash.Enter();
        public void Move() => movement.Move();

        private void Play() => rigidbody.simulated = true;
        private void Pause() => rigidbody.simulated = false;

        private void OnReset()
        {
            rigidbody.linearVelocityY = 0;

            ChangeDirectionUp();

            dash.Cancel();
        }
    }
}