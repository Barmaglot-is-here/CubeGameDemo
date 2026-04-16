using GameLoopManagement;
using UnityEngine;

namespace Game.Features
{
    public class Autopause : MonoBehaviour
    {
#if !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            GameLoop.SetState<PauseState>();
    }
#endif
    }
}
