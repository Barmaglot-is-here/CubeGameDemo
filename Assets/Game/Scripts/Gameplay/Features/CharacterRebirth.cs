using Cysharp.Threading.Tasks;
using Game.Level;
using Game.Level.Entities;
using StateManagement;
using UnityEngine;

namespace Game
{
    public static class CharacterRebirth
    {
        private const float SAFE_TIME = 2.0f;

        private static readonly Character _character;

        static CharacterRebirth()
        {
            _character = Object.FindFirstObjectByType<Character>();
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

            Level.Level.Simulation.Disable();
        }

        private static void Disable()
        {
            Level.Level.Simulation.Enable();

            var spawnController = Level.Level.Services.Get<SpawnController>();

            spawnController.Start();
        }

        private static void DisableObstacles()
        {
            var obstacles = Object.FindObjectsByType<Obstacle>(FindObjectsInactive.Exclude,
                                                                   FindObjectsSortMode.None);

            foreach (var obstacle in obstacles)
                obstacle.gameObject.SetActive(false);
        }
    }
}