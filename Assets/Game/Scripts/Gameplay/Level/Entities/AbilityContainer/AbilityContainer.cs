using Game.Abilities;
using GameLoopManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class AbilityContainer : MonoBehaviour
    {
        private SpriteRenderer _view;
        public BaseAbility Ability;

        private void Awake()
        {
            _view = GetComponent<SpriteRenderer>();

            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        public void Setup(BaseAbility ability, Sprite sprite)
        {
            Ability = ability;

            _view.sprite = sprite;
        }

        private void OnReset() => Destroy(gameObject);

        private void OnDestroy() => GameLoop.Unregister(OnReset, FunctionType.Reset);
    }
}