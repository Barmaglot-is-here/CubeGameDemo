using Game.UI;
using StateManagement;
using UIManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    internal class ObstacleCollisionHandler : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            string tag = collision.gameObject.tag;

            if (tag == "Player")
                OnDeath();
        }

        private void OnDeath()
        {
            StateManager.SetState<PauseState>();
            UIManager.Hide<PlayModeScreen>();
            UIManager.Show<DeathScreen>();
        }
    }
}
