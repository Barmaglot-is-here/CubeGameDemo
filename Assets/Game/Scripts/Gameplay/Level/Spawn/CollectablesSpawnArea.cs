using UnityEngine;

namespace Game.Level
{
    public class CollectablesSpawnArea : MonoBehaviour
    {
        public Vector3 GetRandomPosition()
        {
            float posX = Random.Range(-0.5f, 0.5f);
            float posY = Random.Range(-0.5f, 0.5f);

            return transform.position + new Vector3 (posX, posY);
        }
    }
}
