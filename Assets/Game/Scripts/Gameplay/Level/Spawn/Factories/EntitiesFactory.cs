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
        public Ability CreateAbility(Abilities.IAbility ability)
            => _abilityFactory.Create(ability);
    }
}