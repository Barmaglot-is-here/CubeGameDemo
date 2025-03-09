using System;
using System.Collections.Generic;

public class AbilityFactory
{
    private readonly Dictionary<Type, object> _factoryMethods;

    public AbilityFactory()
    {
        _factoryMethods = new();
    }

    public void AddMethod<T>(Func<T> func) where T : IAbility
    {
        Type type = typeof(T);

        _factoryMethods.Add(type, func);
    }

    public IAbility Create<T>() where T : IAbility
    {
        Type type = typeof(T);
        object @delegate = _factoryMethods[type];


        return ((Func<T>)@delegate).Invoke();
    }
}