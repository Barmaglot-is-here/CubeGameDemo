using UnityEngine;

public class StartLineDeathHandler : DeathHandler
{
    public override void Handle(GameObject gameObject) => gameObject.SetActive(false);
}