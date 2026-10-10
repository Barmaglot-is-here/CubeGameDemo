using System;
using UnityEngine;

namespace Game.Level
{
    public class CoinCreationProvider : BaseCreationProvider
    {
        [SerializeField]
        private Sprite _sprite;

        private void IncrementsCoins() => GameData.Coins++;

        public override void Create(out Sprite sprite, out Action onCollect)
        {
            sprite = _sprite;

            onCollect = IncrementsCoins;
        }
    }
}
