using System.Collections.Generic;
using UnityEngine;

public class DeathManager
{
    private readonly Dictionary<string, DeathHandler> _handlers;

    public DeathManager()
    {
        _handlers = new();
    }

    public void Add(string tag, DeathHandler handler) => _handlers.Add(tag, handler);

    public void Handle(GameObject gameObject) => _handlers[gameObject.tag].Handle(gameObject);
}