public class DeathHandleInitializer
{
    private readonly DeathHandlersHub _handlersHub;

    public DeathHandleInitializer(DeathZone deathZone)
    {
        _handlersHub = new();
        _handlersHub.Add("Obstacle", new ObstacleDeathHandler());

        deathZone.OnTrigger += _handlersHub.Handle;
    }
}