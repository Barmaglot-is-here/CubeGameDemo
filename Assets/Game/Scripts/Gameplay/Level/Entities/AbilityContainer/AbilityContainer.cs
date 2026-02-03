using Game.Abilities;
using StateManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class AbilityContainer : MonoBehaviour, IResetable
    {
        private SpriteRenderer _view;
        public BaseAbility Ability;

        private void Awake()
        {
            _view = GetComponent<SpriteRenderer>();

            StateManager.Register(this);
        }

        public void Setup(BaseAbility ability, Sprite sprite)
        {
            Ability = ability;

            _view.sprite = sprite;
        }

        void IResetable.Reset() => Destroy(gameObject);

        private void OnDestroy() => StateManager.Unregister(this);
    }
}