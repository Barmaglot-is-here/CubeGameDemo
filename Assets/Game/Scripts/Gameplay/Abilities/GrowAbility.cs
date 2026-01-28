using Game.Level.Entities;

namespace Game.Abilities
{
    public class GrowAbility : IAbility
    {
        private readonly float _growFactor;

        public float Duration { get; }

        public GrowAbility(GrowAbilityConfig config)
        {
            _growFactor = config.GrowFactor;
            Duration    = config.Duration;
        }

        public void ApplyTo(Character character) 
            => AbilitySystem.Run(this, () => Apply(character), () => Disaply(character));

        private void Apply(Character character)
        {
            character.dash.Cancel();
            character.dash.Lock();

            character.transform.localScale *= _growFactor;
        }

        private void Disaply(Character character)
        {
            character.dash.Unlock();

            character.transform.localScale /= _growFactor;
        }

        void IAbility.Cancel() => AbilitySystem.Cancel(this);
    }
}