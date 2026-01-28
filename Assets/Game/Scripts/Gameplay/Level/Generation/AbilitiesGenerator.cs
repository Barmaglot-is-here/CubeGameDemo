using Game.Abilities;

namespace Game.Level.Generation
{
    public class AbilitiesGenerator
    {
        private readonly Abilities.AbilitiesFactory _factory;

        public AbilitiesGenerator(Abilities.AbilitiesFactory factory)
        {
            _factory = factory;
        }

        public IAbility Generate()
        {
            return _factory.Create<GrowAbility>();
        }
    }
}