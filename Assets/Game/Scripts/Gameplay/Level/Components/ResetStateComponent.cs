using GameCycleManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    class ResetStateComponent : MonoBehaviour
    {
        private void Awake()
        {
            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        private void OnReset() => gameObject.SetActive(true);
    }
}
