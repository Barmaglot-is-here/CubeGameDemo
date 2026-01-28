using System;
using UnityEngine;

namespace Game.SkinSystem
{
    [Serializable]
    public struct ViewData
    {
        [field: SerializeField]
        public Sprite MainSprite { get; private set; }
        [field: SerializeField]
        public Sprite ShadowSprite { get; private set; }
    }
}
