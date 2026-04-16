using Game.Abilities;
using GameLoopManagement;
using UnityEngine;

namespace Game.Level
{
    public class OnResetAbilityDisable : MonoBehaviour
    {
        private void Awake()
        {
            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        private void OnReset() => AbilitySystem.CurrentAbility?.Cancel();
    }
}
