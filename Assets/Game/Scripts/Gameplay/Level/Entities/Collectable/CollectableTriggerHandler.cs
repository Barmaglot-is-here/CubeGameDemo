using Game.Level.Entities;
using UnityEngine;

namespace Game.CollisionHandle
{
    internal class CollectableTriggerHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                var collectable = GetComponent<Collectable>();
                collectable.Collect();

                GameObject.Destroy(gameObject);
            }
        }
    }
}
