using Game.Level.Entities;
using UnityEngine;

namespace Game.CollisionHandle
{
    internal class AbilityTriggerHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                var container   = GetComponent<AbilityContainer>();
                var ability     = container.Ability;
                var character   = collision.gameObject.GetComponent<Character>();

                ability.ApplyTo(character);

                GameObject.Destroy(gameObject);
            }
        }
    }
}
