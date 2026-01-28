using UnityEngine;

namespace Game.Level
{
    public class AbilitySpawnBounds : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _levelConfig;
        [SerializeField]
        private Transform _floor;
        [SerializeField]
        private Transform _roof;
        [SerializeField]
        private float _paddingX;
        [SerializeField]
        private float _paddingY;

        private void Awake() => UpdateRect();


        [ContextMenu("UpdateRect")]
        private void UpdateRect()
        {
            var rect = GetRect();

            transform.localScale = new(rect.width, rect.height);
            transform.position = new(rect.x, rect.y);
        }

        private Rect GetRect()
        {
            var spawnPoint = LevelData.SpawnPoint;

            var width = _levelConfig.SpawnDistance - _paddingX * 2;
            var height = (_roof.position - _floor.position).y
                        - GetColliderHeight(_floor) / 2
                        - GetColliderHeight(_roof) / 2
                        - _paddingY * 2;
            var posX = spawnPoint.position.x + width / 2 + _paddingX;
            var posY = _floor.position.y + height / 2 + GetColliderHeight(_floor) / 2
                        + _paddingY;

            Rect bounds = new(posX, posY, width, height);

            return bounds;
        }

        private float GetColliderHeight(Transform transform)
            => transform.GetComponent<BoxCollider2D>().size.y;
    }
}