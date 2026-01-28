using Game.Abilities;
using Game.Level.Entities;
using UnityEngine;

namespace Game.Level
{
    public class AbilitiesFactory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private Transform _container;
        [SerializeField]
        private AbilitiesViewConfig _viewConfig;

        private ObjectPool<Ability> _pool;

        private void Awake()
        {
            _pool = new(Instantiate, Reset);
        }

        private Ability Instantiate()
        {
            var instance    = Instantiate(_prefab, _container, true);
            var ability     = instance.GetComponent<Ability>();

            return ability;
        }

        private void Reset(Ability container)
        {
            container.gameObject.SetActive(true);
        }

        public Ability Create(IAbility ability)
        {
            var container = _pool.GetNext();

            var pos     = GetRandomPosition();
            var view    = GetView(ability.GetType());

            container.transform.localPosition = pos;
            container.Setup(ability, view);

            return container;
        }

#if UNITY_EDITOR
        [ContextMenu("Spawn")]
        private void Spawn()
        {
            var pos = GetRandomPosition();

            var instance = Instantiate(_prefab, _container, true);
            instance.transform.localPosition = pos;

            var container = instance.GetComponent<Ability>();
        }
#endif

        private Sprite GetView(System.Type abilityType)
        {
            return _viewConfig.GrowAbilitySprite;
        }

        private Vector3 GetRandomPosition()
        {
            float posX = Random.Range(-0.5f, 0.5f);
            float posY = Random.Range(-0.5f, 0.5f);

            return new(posX, posY);
        }
    }
}