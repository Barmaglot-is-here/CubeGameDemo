using System;
using UnityEngine;

namespace Game.Level
{
    public abstract class BaseCreationProvider : MonoBehaviour
    {
        public abstract void Create(out Sprite sprite, out Action onCollect);
    }
}
