using Game.Level.Entities;
using System.Threading;

namespace Game.Abilities
{
    public abstract class BaseAbility
    {
        private readonly CancellationTokenSource _cs;

        private Character _character;

        public float Duration { get; }

        protected BaseAbility(float duration) 
        {
            _cs         = new();
            Duration    = duration;
        }

        public void ApplyTo(Character character)
        {
            _character = character;

            AbilitySystem.Run(this, _cs.Token, () => Apply(_character), () => Disapply(_character));
        }

        protected abstract void Apply(Character character);
        protected abstract void Disapply(Character character);

        public void Cancel()
        {
            _cs.Cancel();

            Disapply(_character);
        }
    }
}
