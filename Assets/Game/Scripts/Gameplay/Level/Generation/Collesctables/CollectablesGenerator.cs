using Game.Abilities;
using UnityEngine;

namespace Game.Level.Generation
{
    public class CollectablesGenerator
    {
        private readonly CollectableGenerationConfig _collectableGenerationConfig;

        private readonly CollectablesSpawnArea _spawnArea;

        private readonly CoinCreationProvider _coinCreationProvider;
        private readonly AbilityCreationProvider _abilityCreationProvider;

        public CollectablesGenerator(CollectableGenerationConfig config, CollectablesSpawnArea spawnArea, 
                                     CoinCreationProvider coinCreationProvider, AbilityCreationProvider abilityCreationProvider)
        {
            _collectableGenerationConfig    = config;
            _spawnArea                      = spawnArea;
            _coinCreationProvider           = coinCreationProvider;
            _abilityCreationProvider        = abilityCreationProvider;
        }

        public CollectableSpawnData Generate()
        {
            CollectableSpawnData data = new();

            int random = Random.Range(0, 100);

            if (random > _collectableGenerationConfig.GeneralGenerationChance)
                data.IsEmpty = true;
            else
            {
                random = Random.Range(0, 100);

                if (random < _collectableGenerationConfig.CoinSpawnChance)
                    CreateCoin(ref data);
                else
                    CreateAbility(ref data);

                data.Position = _spawnArea.GetRandomPosition();
            }

            return data;
        }

        private void CreateCoin(ref CollectableSpawnData data) => _coinCreationProvider.Create(out data.View, out data.OnCollect);
        private void CreateAbility(ref CollectableSpawnData data) => _abilityCreationProvider.Create(out data.View, out data.OnCollect);
    }
}
