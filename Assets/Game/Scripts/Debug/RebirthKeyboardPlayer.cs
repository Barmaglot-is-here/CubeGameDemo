using Game.Features;
using Game.UI;
using UIManagement;
using UnityEngine;

namespace Game.InGameDebug
{
    internal class RebirthKeyboardPlayer : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                Rebirth();
        }

        private void Rebirth()
        {
            UIManager.Hide<AddScreen>();
            UIManager.Show<PlayModeScreen>();
            UIManager.Hide<DeathScreen>();

            CharacterRebirth.Invoke();
        }
    }
}
