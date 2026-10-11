using Game.Level.Entities;
using UnityEngine;

namespace Game.InGameDebug
{
    public class KeyboardCharacterControl : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                _character.ChangeDirectionUp();

            if (Input.GetKeyDown(KeyCode.S))
                _character.ChangeDirectionDown();

            if (Input.GetKeyDown(KeyCode.D))
                _character.Dash();
        }
    }
}
