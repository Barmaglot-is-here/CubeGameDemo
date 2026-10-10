using Game.Abilities;
using Game.Level.Entities;
using System;
using UnityEngine;

namespace Game.Level
{
    public class AbilityCreationProvider : BaseCreationProvider
    {
        [SerializeField]
        private Character _character;

        [SerializeField]
        private AbilitySpriteSheet _spriteSheet;

        public override void Create(out Sprite sprite, out Action onCollect)
        {
            sprite = _spriteSheet.Get<GrowAbility>();

            onCollect = OnCollect;
        }

        private void OnCollect()
        {
            var creationUtility = Level.Services.Get<AbilityCreationUtility>();
            var ability = creationUtility.Create<GrowAbility>();

            ability.ApplyTo(_character);
        }
    }
}
