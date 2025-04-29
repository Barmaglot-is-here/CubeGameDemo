using UnityEngine;

public static class AbilitiesInitializer
{
    public static void CreateFactory(AbilitiesConfig config, out AbilitiesFactory factory)
    {
        factory = new();

        factory.AddMethod(() => SpeedFlyAbility(config.SpeedFlyConfig));
    }

    private static SpeedFlyAbility SpeedFlyAbility(SpeedFlyConfig config)
    {
        Character character = GameObject.FindAnyObjectByType<Character>();

        return new(config.Duration, character);
    }
}