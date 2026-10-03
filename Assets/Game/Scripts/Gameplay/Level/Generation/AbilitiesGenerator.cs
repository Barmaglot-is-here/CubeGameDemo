using Game.Abilities;
using UnityEngine;

namespace Game.Level.Generation
{
    public class AbilitiesGenerator
    {
        private readonly Abilities.AbilitiesFactory _factory;
        private readonly int _generationChance;

        public AbilitiesGenerator(Abilities.AbilitiesFactory factory, int generationChance = 50)
        {
            _factory = factory;
            _generationChance = generationChance;
        }

        public BaseAbility Generate()
        {
            var chance = Random.Range(0, 100);

            if (chance >= _generationChance)
                return _factory.Create<GrowAbility>();
            else return null;
        }
    }
}