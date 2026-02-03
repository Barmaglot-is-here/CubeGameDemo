using Game.Abilities;
using UnityEngine;

namespace Game.Level.Generation
{
    public class AbilitiesGenerator
    {
        private readonly Abilities.AbilitiesFactory _factory;

        public AbilitiesGenerator(Abilities.AbilitiesFactory factory)
        {
            _factory = factory;
        }

        public BaseAbility Generate()
        {
            var chance = Random.Range(0, 100);

            if (chance >= 50)
                return _factory.Create<GrowAbility>();
            else return null;
        }
    }
}