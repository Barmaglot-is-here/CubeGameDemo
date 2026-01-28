using System;

namespace Game.Core
{
    public class Simulation
    {
        public event Action OnEnabled;
        public event Action OnDisabled;

        public event Action OnUpdate;
        public event Action OnFixedUpdate;

        public bool Enabled { get; private set; }

        public void Enable()
        {
            Enabled = true;

            OnEnabled?.Invoke();
        }

        public void Disable()
        {
            Enabled = false;

            OnDisabled?.Invoke();
        }

        public void Update()
        {
            if (!Enabled)
                return;

            OnUpdate?.Invoke();
        }

        public void FixedUpdate()
        {
            if (!Enabled)
                return;

            OnFixedUpdate?.Invoke();
        }
    }
}