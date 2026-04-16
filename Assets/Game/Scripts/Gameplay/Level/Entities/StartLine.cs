using GameLoopManagement;
using UnityEngine;

namespace Game.Level.Entities
{
    class StartLine : MonoBehaviour
    {
        private void Awake()
        {
            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        private void OnReset() => gameObject.SetActive(true);
    }
}
