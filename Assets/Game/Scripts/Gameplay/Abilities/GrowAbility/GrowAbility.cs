using Game.Level.Entities;
using System.Threading;

namespace Game.Abilities
{
    public class GrowAbility : BaseAbility
    {
        private readonly float _growFactor;

        private readonly CancellationTokenSource _cs;

        public GrowAbility(GrowAbilityConfig config) : base(config.Duration)
        {
            _growFactor = config.GrowFactor;

            _cs = new();
        }

        protected override void Apply(Character character)
        {
            character.dash.Cancel();
            character.dash.Lock();

            character.transform.localScale *= _growFactor;

            SetActiveObstacleDestroyer(character, true);
        }

        protected override void Disapply(Character character)
        {
            character.dash.Unlock();

            character.transform.localScale /= _growFactor;

            SetActiveObstacleDestroyer(character, false);
        }

        private void SetActiveObstacleDestroyer(Character character, bool value)
        {
            var obstacleDestroyer = character.GetComponentInChildren<ObstacleDestroyer>(true);

            obstacleDestroyer.gameObject.SetActive(value);
        }
    }
}