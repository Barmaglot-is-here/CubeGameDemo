using UnityEngine;

namespace Game.Level
{
    public class CollectablesSpawnArea : MonoBehaviour
    {
        public Vector3 GetRandomPosition()
        {
            var scale = transform.localScale / 2;

            float posX = Random.Range(-scale.x, scale.x);
            float posY = Random.Range(-scale.y, scale.y);

            return transform.position + new Vector3 (posX, posY);
        }
    }
}
