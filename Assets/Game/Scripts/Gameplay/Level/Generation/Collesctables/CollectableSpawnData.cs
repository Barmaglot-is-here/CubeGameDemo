using System;
using UnityEngine;

namespace Game.Level.Generation
{
    public struct CollectableSpawnData
    {
        public bool IsEmpty;
        public Vector2 Position;
        public Sprite View;
        public Action OnCollect;
    }
}
