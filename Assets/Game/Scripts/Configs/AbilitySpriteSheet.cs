using UnityEngine;
using System;

namespace Game.Abilities
{
    [CreateAssetMenu(fileName = "AbilitySpriteSheet", menuName = "Configs/AbilitySpriteSheet")]
    public class AbilitySpriteSheet : ScriptableObject
    {
        [SerializeField]
        private Entry[] _entries = Array.Empty<Entry>();

        public Sprite Get<T>() where T : BaseAbility => Get(typeof(T));

        public Sprite Get(Type type)
        {
            foreach (var entry in _entries)
                if (entry.AbilityTypeName == type.AssemblyQualifiedName)
                    return entry.Sprite;

            return null;
        }

        [Serializable]
        public struct Entry
        {
            [field: SerializeField]
            public string AbilityTypeName { get; private set; }
            [field: SerializeField]
            public Sprite Sprite { get; private set; }
        }
    }
}
