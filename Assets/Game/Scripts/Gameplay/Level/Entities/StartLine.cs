using StateManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    class StartLine : MonoBehaviour, IResetable
    {
        private void Awake()
        {
            StateManager.Register(this);
        }

        void IResetable.Reset() => gameObject.SetActive(true);
    }
}
