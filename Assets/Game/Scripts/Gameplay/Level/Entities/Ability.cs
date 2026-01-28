using Game.Abilities;
using StateManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Ability : MovableObject, IResetable
    {
        private SpriteRenderer _view;
        private IAbility _ability;

        private void Awake()
        {
            _view = GetComponent<SpriteRenderer>();

            StateManager.Register(this);
        }

        public void Setup(IAbility ability, Sprite sprite)
        {
            _ability = ability;

            _view.sprite = sprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Apply(collision.gameObject);

                gameObject.SetActive(false);
            }
        }

        private void Apply(GameObject gameObject)
        {
            var character = gameObject.GetComponent<Character>();

            _ability.ApplyTo(character);
        }

        void IResetable.Reset()
        {
            gameObject.SetActive(false);

            _ability.Cancel();
        }
    }
}