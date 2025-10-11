using UnityEngine;

public class ObstacleDeathHandler : DeathHandler
{
    public override string Tag => "Obstacle";

    public override void Handle(GameObject gameObject) => gameObject.SetActive(false);
}