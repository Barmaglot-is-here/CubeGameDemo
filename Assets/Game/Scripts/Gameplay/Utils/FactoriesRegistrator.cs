using Game.Level;
using UnityEngine;

namespace Game
{
    [DefaultExecutionOrder(-9000)]
    public class FactoriesRegistrator : MonoBehaviour
    {
        [SerializeField]
        private EntitiesFactory _entitiesFactory;
        [SerializeField]
        private Abilities.AbilitiesFactory _abilitiesFactory;

        private void Awake()
        {
            var services = Level.Level.Services;

            services.Add(_entitiesFactory);
            services.Add(_abilitiesFactory);
        }
    }
}
