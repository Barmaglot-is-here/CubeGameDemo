using Game.Level;
using Game.Level.Generation;
using UnityEngine;

namespace Game.InGameDebug
{
    internal class CollectablesGenerationTest : MonoBehaviour
    {
        private CollectablesGenerator _generator;

        [SerializeField]
        private CollectablesFactory _factory;

        [SerializeField]
        private CollectableGenerationConfig _config;
        [SerializeField]
        private CollectablesSpawnArea _spawnArea;
        [SerializeField]
        private CoinCreationProvider _coinCreationProvider;
        [SerializeField]
        private AbilityCreationProvider _abilityCreationProvider;

        [ContextMenu("Generate")]
        private void Generate()
        {
            _generator = new(_config, _spawnArea, _coinCreationProvider, _abilityCreationProvider);

            for (int i = 0; i < 100; i++)
            {

                var collectable = _generator.Generate();

                if (collectable.IsEmpty)
                {
                    Debug.Log("Collectable generation skipped according to GeneralGenerationChance.", this);
                    return;
                }

                _factory.Create(collectable);
            }
        }
    }
}
