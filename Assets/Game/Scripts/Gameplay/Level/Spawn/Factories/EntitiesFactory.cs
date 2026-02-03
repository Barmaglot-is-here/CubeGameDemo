using Game.Level.Entities;
using UnityEngine;

namespace Game.Level
{
    public class EntitiesFactory : MonoBehaviour
    {
        [SerializeField]
        private ObstacleFactory _obstacleFactory;
        [SerializeField]
        private AbilitiesFactory _abilityFactory;

        public Obstacle CreateObstacle(ObstacleData data)
            => _obstacleFactory.Create(data);
        public AbilityContainer CreateContainer(Abilities.BaseAbility ability)
            => _abilityFactory.Create(ability);
    }
}