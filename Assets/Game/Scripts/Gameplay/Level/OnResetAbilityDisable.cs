using Game.Abilities;
using StateManagement;
using UnityEngine;

namespace Game.Level
{
    public class OnResetAbilityDisable : MonoBehaviour, IResetable
    {
        private void Awake()
        {
            StateManager.Register(this);
        }

        void IResetable.Reset() 
            => AbilitySystem.CurrentAbility?.Cancel();
    }
}
