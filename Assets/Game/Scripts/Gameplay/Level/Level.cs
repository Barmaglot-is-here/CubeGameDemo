using Game.Level.Generation;
using StateManagement;
using UnityEngine;

namespace Game.Level
{
    [DefaultExecutionOrder(-1000)]
    public class Level : MonoBehaviour, IResetable, IPausable, IPlayable, IStartable
    {
        [SerializeField]
        private LevelConfig _config;

        [SerializeField]
        private ScoreCounter _scoreCounter;
        private LevelSpeedController _speedController;
        private MovementController _movementController;
        private SpawnController _spawnController;

        public static ServiceManager Services { get; private set; } = new();
        public static Simulation Simulation { get; private set; } = new();

        private void Awake()
        {
            InitFields();
            RegisterServices();
            RegisterEvents();

            StateManager.Register(this);
        }

        private void InitFields()
        {
            _speedController        = new(_config.MaxSpeed, _config.SpeedGrow);
            _movementController     = new(_config.StartSpeed);
            _spawnController        = new(DefaultLoader(), _config.SpawnDistance,
                                          Services.Get<EntitiesFactory>());
        }

        //Temp
        private ILevelLoader DefaultLoader()
            => new LevelGenerator(11, Services.Get<Abilities.AbilitiesFactory>());

        private void RegisterServices()
        {
            Services.Add(_scoreCounter);
            Services.Add(_movementController);
            Services.Add(_spawnController);
        }

        private void RegisterEvents()
        {
            _scoreCounter.OnScoreChanged += _speedController.Update;

            Simulation.OnUpdate += _spawnController.Update;
            Simulation.OnFixedUpdate += _movementController.FixedUpdate;
            Simulation.OnDisabled += _movementController.Pause;
        }

        void IResetable.Reset()
        {
            _speedController.Reset();
        }

        void IStartable.Start() => _spawnController.Start();

        private void Update() => Simulation.Update();
        private void FixedUpdate() => Simulation.FixedUpdate();

        void IPausable.Pause()
        {
            Simulation.Disable();

            _speedController.Pause();
        }

        void IPlayable.Play()
        {
            Simulation.Enable();

            _speedController.Play();
        }
    }
}