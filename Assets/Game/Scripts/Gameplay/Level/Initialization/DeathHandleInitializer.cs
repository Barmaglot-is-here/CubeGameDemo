public class DeathHandleInitializer
{
    private readonly DeathManager _deathManager;

    public DeathHandleInitializer(DeathZone deathZone)
    {
        _deathManager = new();
        _deathManager.Add("Obstacle", new ObstacleDeathHandler());

        deathZone.OnTrigger += _deathManager.Handle;
    }
}