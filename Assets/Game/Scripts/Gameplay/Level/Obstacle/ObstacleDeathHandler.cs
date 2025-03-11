using UnityEngine;

public class ObstacleDeathHandler : DeathHandler
{
    public override void Handle(GameObject gameObject) => gameObject.SetActive(false);
}