using Game.Level.Generation;
using GameCycleManagement;
using System;
using UnityEngine;

namespace Game.Level
{
    [DefaultExecutionOrder(-1000)]
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _config;

        [SerializeField]
        private LevelLoaderFactory _loaderFactory;

        private ScoreCounter _scoreCounter;
        private LevelSpeedController _speedController;
        private MovementController _movementController;
        private SpawnController _spawnController;

        public static ServiceManager Services { get; private set; } = new();

        private void Awake()
        {
            InitFields();
            RegisterServices();
            RegisterEvents();
        }

        private void InitFields()
        {
            _scoreCounter           = new();
            _speedController        = new(_config.MaxSpeed, _config.SpeedGrow);
            _movementController     = new(_config.StartSpeed);
            _spawnController        = new(_loaderFactory.Create<LevelGenerator>(), _config.SpawnDistance,
                                          Services.Get<EntitiesFactory>());
        }

        private void RegisterServices()
        {
            Services.Add(_scoreCounter);
            Services.Add(_movementController);
            Services.Add(_spawnController);
        }

        private void RegisterEvents()
        {
            _scoreCounter.OnScoreChanged += _speedController.Update;

            GameLoop.Register(_spawnController.Start, FunctionType.Start);
            GameLoop.Register(_speedController.Play, FunctionType.Play);
            GameLoop.Register(_speedController.Reset, FunctionType.Reset);
            GameLoop.Register(_speedController.Pause, FunctionType.Pause);
            GameLoop.Register(_spawnController.Update, FunctionType.Update);
            GameLoop.Register(_movementController.FixedUpdate, FunctionType.FixedUpdate);
            GameLoop.Register(_movementController.Pause, FunctionType.Pause);
        }
    }
}