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

                data.Position = GetPosition(data.View);
            }

            return data;
        }

        private void CreateCoin(ref CollectableSpawnData data) => _coinCreationProvider.Create(out data.View, out data.OnCollect);
        private void CreateAbility(ref CollectableSpawnData data) => _abilityCreationProvider.Create(out data.View, out data.OnCollect);

        private Vector2 GetPosition(Sprite view)
        {
            var position = _spawnArea.GetRandomPosition();

            Bounds areaBounds = _spawnArea.Bounds;
            Bounds spriteBounds = view.bounds;
            Vector2 min = areaBounds.min - spriteBounds.min;
            Vector2 max = areaBounds.max - spriteBounds.max;

            if (min.x > max.x || min.y > max.y)
                throw new System.InvalidOperationException($"Sprite '{view.name}' does not fit inside the collectables spawn area.");

            return new(Mathf.Clamp(position.x, min.x, max.x),
                       Mathf.Clamp(position.y, min.y, max.y));
        }
    }
}
