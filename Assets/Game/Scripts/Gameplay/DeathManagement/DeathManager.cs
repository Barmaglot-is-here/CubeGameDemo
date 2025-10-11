public static class DeathManager
{
    private static readonly DeathRouter _router;

    static DeathManager()
    {
        _router = new();
        _router.Add(new CharacterDeathHandler());
        _router.Add(new ObstacleDeathHandler());
        _router.Add(new StartLineDeathHandler());
    }

    public static void Add(DeathTrigger trigger)
    {
        trigger.OnTrigger += _router.Route;
    }
}