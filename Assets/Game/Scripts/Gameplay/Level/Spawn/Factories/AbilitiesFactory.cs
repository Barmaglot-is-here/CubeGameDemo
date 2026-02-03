using Game.Abilities;
using Game.Level.Entities;
using UnityEngine;

namespace Game.Level
{
    public class AbilitiesFactory : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;
        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private Sprite _growAbilitySprite;

        private AbilityContainer Instantiate()
        {
            var instance    = Instantiate(_prefab, _container, true);
            var ability     = instance.GetComponent<AbilityContainer>();

            return ability;
        }

        public AbilityContainer Create(BaseAbility ability)
        {
            var container = Instantiate();

            var pos     = GetRandomPosition();
            var view    = _growAbilitySprite;

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

            var container = instance.GetComponent<AbilityContainer>();
        }
#endif

        private Vector3 GetRandomPosition()
        {
            float posX = Random.Range(-0.5f, 0.5f);
            float posY = Random.Range(-0.5f, 0.5f);

            return new(posX, posY);
        }
    }
}