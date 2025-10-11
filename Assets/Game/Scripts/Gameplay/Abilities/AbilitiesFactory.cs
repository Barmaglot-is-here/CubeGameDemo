using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesFactory : MonoBehaviour
{
    [field: SerializeField]
    private AbilitiesConfig _config;

    private Dictionary<Type, object> _factoryMethods;

    private void Awake()
    {
        _factoryMethods = new();

        Add(() => SpeedFlyAbility(_config.SpeedFlyConfig));
    }

    private void Add<T>(Func<T> func) where T : IAbility
    {
        Type type = typeof(T);

        _factoryMethods.Add(type, func);
    }

    private static SpeedFlyAbility SpeedFlyAbility(SpeedFlyConfig config)
    {
        Character character = GameObject.FindAnyObjectByType<Character>();

        return new(config.Duration, character);
    }

    public IAbility Create<T>() where T : IAbility
    {
        Type type = typeof(T);
        object @delegate = _factoryMethods[type];

        return ((Func<T>)@delegate).Invoke();
    }
}