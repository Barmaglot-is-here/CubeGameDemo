using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Abilities
{
    public class AbilitiesFactory : MonoBehaviour
    {
        [field: SerializeField]
        private AbilitiesConfig _config;

        private Dictionary<Type, object> _factoryMethods;

        private void Awake()
        {
            _factoryMethods = new();

            Add(() => new GrowAbility(_config.GrowAbilityConfig));
        }

        private void Add<T>(Func<T> func) where T : BaseAbility
        {
            Type type = typeof(T);

            _factoryMethods.Add(type, func);
        }

        public T Create<T>() where T : BaseAbility
        {
            Type type = typeof(T);
            object @delegate = _factoryMethods[type];

            return ((Func<T>)@delegate).Invoke();
        }
    }
}