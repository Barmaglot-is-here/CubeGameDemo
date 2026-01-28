using Game.Level.Entities;

namespace Game.Abilities
{
    public interface IAbility
    {
        float Duration { get; }
        void ApplyTo(Character character);
        void Cancel();
    }
}