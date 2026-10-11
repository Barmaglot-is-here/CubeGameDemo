using UnityEngine;

namespace Game.Level
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CollectablesSpawnArea : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        public Bounds Bounds => _spriteRenderer.bounds;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public Vector3 GetRandomPosition()
        {
            var scale = transform.localScale / 2;

            float posX = Random.Range(-scale.x, scale.x);
            float posY = Random.Range(-scale.y, scale.y);

            return transform.position + new Vector3 (posX, posY);
        }
    }
}
