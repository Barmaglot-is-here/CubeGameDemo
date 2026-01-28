using System;
using UnityEngine;

namespace Game
{
    public class DeathTrigger : MonoBehaviour
    {
        public Action<GameObject> OnTrigger { get; set; }

        private void Awake() => DeathManager.Add(this);

        private void OnTriggerEnter2D(Collider2D collision)
            => OnTrigger.Invoke(collision.gameObject);
    }
}