using StateManagement;
using UnityEngine;

public class Autopause : MonoBehaviour
{
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            StateManager.SetState<PauseState>();
    }
}