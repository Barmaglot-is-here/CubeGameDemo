using Cysharp.Threading.Tasks;
using StateManagement;
using UnityEngine;

public static class CharacterRebirth
{
    private const float SAFE_TIME = 2.0f;

    private static readonly Character _character;

    static CharacterRebirth()
    {
        _character = GameObject.FindFirstObjectByType<Character>();
    }

    public static void Invoke() => Run().Forget();

    private static async UniTask Run()
    {
        Enable();

        await Update(SAFE_TIME);

        Disable();
    }

    private static async UniTask Update(float time)
    {
        float timeElapsed = 0;

        while (timeElapsed < time)
        {
            timeElapsed += Time.deltaTime;

            _character.Move();

            await UniTask.WaitForFixedUpdate();
        }
    }

    private static void Enable()
    {
        DisableObstacles();

        StateManager.SetState<PlayState>();

        Level.Simulation.Disable();
    }

    private static void Disable()
    {
        Level.Simulation.Enable();

        var spawnController = Level.Services.Get<SpawnController>();

        spawnController.Start();
    }

    private static void DisableObstacles()
    {
        var obstacles = GameObject.FindObjectsByType<Obstacle>(FindObjectsInactive.Exclude,
                                                               FindObjectsSortMode.None);

        foreach (var obstacle in obstacles)
            obstacle.gameObject.SetActive(false);
    }
}