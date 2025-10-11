using UnityEngine;

public class StartLineDeathHandler : DeathHandler
{
    public override string Tag => "StartLine";

    public override void Handle(GameObject gameObject) => gameObject.SetActive(false);
}