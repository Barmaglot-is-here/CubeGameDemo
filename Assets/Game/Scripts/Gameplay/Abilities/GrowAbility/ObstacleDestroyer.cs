using System.Collections.Generic;
using UnityEngine;

namespace Game.Abilities
{
    [RequireComponent(typeof(Collider2D))]
    public class ObstacleDestroyer : MonoBehaviour
    {
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var contacts = GetContactObjects(collision);

            foreach (var transform in contacts)
                transform.gameObject.SetActive(false);
        }

        private IEnumerable<Transform> GetContactObjects(Collider2D collision)
        {
            var colliderBounds = _collider.bounds;

            //Чтобы все пересечения гарантированно отработали
            colliderBounds.Expand(0.1f);

            foreach (Transform child in collision.transform)
            {
                if (!child.gameObject.activeSelf)
                    continue;

                var spriteRenderer  = child.GetComponent<SpriteRenderer>();
                var transformBounds = spriteRenderer.bounds;

                if (transformBounds.Intersects(colliderBounds))
                    yield return child;
            }
        }
    }
}
