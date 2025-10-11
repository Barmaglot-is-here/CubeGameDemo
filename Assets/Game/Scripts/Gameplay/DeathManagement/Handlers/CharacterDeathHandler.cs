using StateManagement;
using UIManagement;
using UnityEngine;

public class CharacterDeathHandler : DeathHandler
{
    public override string Tag => "Player";

    public override void Handle(GameObject gameObject)
    {
        StateManager.SetState<PauseState>();
        UIManager.Hide<PlayModeScreen>();
        UIManager.Show<DeathScreen>();
    }
}