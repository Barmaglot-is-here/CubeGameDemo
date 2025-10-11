using StateManagement;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class Level : MonoBehaviour, IResetable, IPausable, IPlayable, IStartable
{
    [SerializeField]
    private LevelType _type;
    [SerializeField]
    private LevelConfig _config;

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
        _scoreCounter       = new();
        _speedController    = new(_config.MaxSpeed, _config.SpeedGrow);
        _movementController = new(_config.StartSpeed);
        _spawnController    = new(GetLoader(_type), _config.SpawnDistance,
                                  Services.Get<ObstacleFactory>());
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

        Simulation.OnUpdate         += _spawnController.Update;
        Simulation.OnFixedUpdate    += _movementController.FixedUpdate;
        Simulation.OnDisabled       += _movementController.Pause;
    }

    private ILevelLoader GetLoader(LevelType type)
    {
        return new ObstacleGenerator();
    }

    void IResetable.Reset()
    {
        _scoreCounter.Reset();
        _spawnController.Reset();

        GameTime.Reset();
    }

    void IStartable.Start() => _spawnController.Start();

    private void Update() => Simulation.Update();
    private void FixedUpdate() => Simulation.FixedUpdate();

    void IPausable.Pause()
    {
        Simulation.Disable();

        GameTime.Pause();
    }
    void IPlayable.Play()
    {
        Simulation.Enable();

        GameTime.Play();
    }
}