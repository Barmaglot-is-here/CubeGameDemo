using Game.Level.Entities;
using Game.Level.Generation;
using UnityEngine;

namespace Game.Level
{
    public class EntitiesFactory : MonoBehaviour
    {
        [SerializeField]
        private ObstacleFactory _obstacleFactory;
        [SerializeField]
        private CollectablesFactory _collectablesFactory;

        public Obstacle CreateObstacle(ObstacleData data)
            => _obstacleFactory.Create(data);
        public Collectable CreateCollectable(CollectableSpawnData data)
            => _collectablesFactory.Create(data);
    }
}