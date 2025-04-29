using StateManagement;
using UnityEngine;

public class Level : MonoBehaviour, IPausable, IPlayable, IResetable
{
    [SerializeField]
    private LevelConfig _config;
    [SerializeField]
    private LevelPrefabs _prefabs;
    [SerializeField]
    private LevelData _data;

    [field: SerializeField]
    public Character Character { get; private set; }

    [Space]
    [SerializeField]
    private PlayModeScoreView _scoreView;

    private LevelMovementController _movementController;
    private ObstaclesController _obstaclesController;
    private StartLineController _startLineController;
    private ScoreCounter _scoreCounter;

    private bool _simulate;

    private void Awake()
    {
        _movementController     = new(_config.ObjectsSpeed);
        _obstaclesController    = new(_data.ObstaclesData, _config.ObstaclesSettings,
                                      _prefabs.ObstaclePrefab, _movementController);
        _startLineController    = new(_data.StartLine, _movementController);

        _scoreCounter           = new(_obstaclesController.Pool,
                                      _prefabs.ScoreTriggerPrefab);
        _scoreCounter.OnScoreChanged += _scoreView.Show;

        AbilitiesInitializer    .CreateFactory(_config.AbilitiesConfig, 
                                               out var abilitiesFactory);
        DeathHandleInitializer  .Init(_data.DeathZone);
        CharacterInitializer    .Init(Character, abilitiesFactory);

        StateManager.Register(this);
    }

    private void Start() => _obstaclesController.Start();

    void IPlayable.Play()
    {
        _simulate = true;

        GameTime.Continue();
    }

    void IPausable.Pause()
    {
        _simulate = false;

        GameTime.Pause();
    }

    void IResetable.Reset()
    {
        _obstaclesController.Reset();
        _startLineController.Reset();
        _scoreCounter       .Reset();
        _scoreView          .Reset();

        GameTime.Reset();
    }

    private void Update()
    {
        if (!_simulate)
            return;

        _obstaclesController.Update();
    }

    private void FixedUpdate()
    {
        if (!_simulate)
            return;

        _movementController.FixedUpdate();
        Character          .Move();
    }
}