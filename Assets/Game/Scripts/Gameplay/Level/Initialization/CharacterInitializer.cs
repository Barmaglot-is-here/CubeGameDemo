using StateManagement;
using UIManagement;

public static class CharacterInitializer
{
    public static void Init(Character character, AbilitiesFactory abilityFactory)
    {
        character.SetAbility(abilityFactory.Create<SpeedFlyAbility>());
        character.OnDeath += OnCharacterDeath;
    }

    private static void OnCharacterDeath()
    {
        StateManager.SetState<PauseState>();
        UIManager.Show<DeathScreen>();
    }
}