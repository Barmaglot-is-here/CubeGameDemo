using UnityEngine;

public class ObstacleDeathHandler : DeathHandler
{
    public override void Handle(GameObject gameObject) => gameObject.SetActive(false);

    public void Alive(Obstacle obstacle) => obstacle.gameObject.SetActive(true);
}