namespace Game
{
    public static class DeathManager
    {
        private static readonly DeathRouter _router;

        static DeathManager()
        {
            _router = new();
            _router.Add("Player", new CharacterDeathHandler());
            _router.Add("Obstacle", new UniversalDeathHandler());
            _router.Add("StartLine", new UniversalDeathHandler());
            _router.Add("Ability", new UniversalDeathHandler());
        }

        public static void Replace(string tag, DeathHandler handler) => _router[tag] = handler;

        public static void Add(DeathTrigger trigger)
        {
            trigger.OnTrigger += _router.Route;
        }
    }
}