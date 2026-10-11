using Codice.Client.Common;
using Cysharp.Threading.Tasks;
using Game.Level;
using Game.Level.Entities;
using GameCycleManagement;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Features
{
    public class CharacterRebirth : MonoBehaviour
    {
        [SerializeField]
        private CharacterRebirthConfig _config;

        private Character _character;
        private Level.Level _level;

        private static CharacterRebirth _instance;
       
        private IEnumerable<Obstacle> Obstacles => Object.FindObjectsByType<Obstacle>(FindObjectsInactive.Exclude,
                                                   FindObjectsSortMode.None);

        private void Awake()
        {
            _character  = Object.FindFirstObjectByType<Character>();
            _level      = Object.FindFirstObjectByType<Level.Level>();

            _instance = this;
        }

        public static void Invoke() => _instance.Run().Forget();

        private async UniTask Run()
        {
            Enable();

            await UniTask.WaitForSeconds(_config.SafeTimeDuration);

            Disable();
        }

        private void Enable()
        {
            DisableSimulation(Obstacles);

            GameLoop.SetState<PlayState>();
        }

        private void Disable() => EnableSimulation(Obstacles);

        private void DisableSimulation(IEnumerable<Obstacle> obstacles)
        {
            var spawnController = Level.Level.Services.Get<SpawnController>();

            GameLoop.Unregister(spawnController.Update, FunctionType.Update);

            foreach (var obstacle in obstacles)
            {
                obstacle.transform.position = SceneData.DeathZone.transform.position;

                obstacle.GetComponent<Rigidbody2D>().simulated = false;
            }
        }

        private void EnableSimulation(IEnumerable<Obstacle> obstacles)
        {
            var spawnController = Level.Level.Services.Get<SpawnController>();

            GameLoop.Register(spawnController.Update, FunctionType.Update);

            foreach (var obstacle in obstacles)
                obstacle.GetComponent<Rigidbody2D>().simulated = true;
        }
    }
}