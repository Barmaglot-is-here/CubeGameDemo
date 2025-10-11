using System.Collections.Generic;
using UnityEngine;

public class DeathRouter
{
    private readonly Dictionary<string, DeathHandler> _handlers;

    public DeathRouter()
    {
        _handlers = new();
    }

    public void Add(DeathHandler handler)
    {
        string tag = handler.Tag;

        _handlers.Add(tag, handler);
    }

    public void Route(GameObject gameObject)
    {
        if (!gameObject.activeSelf || gameObject.tag == "Untagged")
            return;

        _handlers[gameObject.tag].Handle(gameObject);
    }
}