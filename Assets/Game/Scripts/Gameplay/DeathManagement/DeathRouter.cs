using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DeathRouter
    {
        private readonly Dictionary<string, DeathHandler> _handlers;

        public DeathHandler this[string tag] { get => _handlers[tag]; set => _handlers[tag] = value; }

        public DeathRouter()
        {
            _handlers = new();
        }

        public void Add(string tag, DeathHandler handler)
            => _handlers.Add(tag, handler);

        public void Route(GameObject gameObject)
        {
            if (!gameObject.activeSelf || gameObject.tag == "Untagged")
                return;

            _handlers[gameObject.tag].Handle(gameObject);
        }
    }
}