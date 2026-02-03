using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Level
{
    public class DeathZone : MonoBehaviour
    {
        private Dictionary<string, DeathHandler> _handlers;

        private void Awake()
        {
            _handlers = new();
            _handlers.Add("Obstacle",   new DisableDeathHandler());
            _handlers.Add("StartLine",  new DisableDeathHandler());
            _handlers.Add("Ability",    new DestroyDeathHandler());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var gameObject = collision.gameObject;

            if (!gameObject.activeSelf)
                return;

            string tag = gameObject.tag;

            if (!_handlers.ContainsKey(tag))
                throw new NotImplementedException($"Tag: {tag}, Name: {gameObject.name}");

            _handlers[tag].Handle(gameObject);
        }
    }
}