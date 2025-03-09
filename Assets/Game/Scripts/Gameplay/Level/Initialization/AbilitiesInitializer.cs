using UnityEngine;

public class AbilitiesInitializer
{
    public AbilityFactory Factory { get; }

    public AbilitiesInitializer()
    {
        Factory = new();
        Factory.AddMethod(SpeedFlyAbility);
    }

    private SpeedFlyAbility SpeedFlyAbility()
    {
        Character character = GameObject.FindAnyObjectByType<Character>();

        return new(0.9f, character);
    }
}