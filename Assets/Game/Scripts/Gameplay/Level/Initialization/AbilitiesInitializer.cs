using UnityEngine;

public class AbilitiesInitializer
{
    public AbilityFactory Factory { get; }

    public AbilitiesInitializer(AbilitiesConfig config)
    {
        Factory = new();
        Factory.AddMethod(() => SpeedFlyAbility(config.SpeedFlyConfig));
    }

    private SpeedFlyAbility SpeedFlyAbility(SpeedFlyConfig config)
    {
        Character character = GameObject.FindAnyObjectByType<Character>();

        return new(config.Duration, character);
    }
}