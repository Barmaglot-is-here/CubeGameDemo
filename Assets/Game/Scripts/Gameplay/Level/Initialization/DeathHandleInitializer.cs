public static class DeathHandleInitializer
{
    public static void Init(DeathZone deathZone)
    {
        DeathManager deathManager = new();
        deathManager.Add("Obstacle",    new ObstacleDeathHandler());
        deathManager.Add("StartLine",   new StartLineDeathHandler());

        deathZone.OnTrigger += deathManager.Handle;
    }
}