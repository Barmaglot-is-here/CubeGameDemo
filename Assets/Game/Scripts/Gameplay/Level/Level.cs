using StateManagement;
using UIManagement;
using UnityEngine;

public class Level : MonoBehaviour, IPausable, IPlayable, IResetable
{
    [SerializeField]
    private LevelConfig _config;

    [SerializeField]
    private Character _character;

    [SerializeField]
    private Transform _obstaclesContainer;
    [SerializeField]
    private Transform _obstaclesSpawnPoint;

    [SerializeField]
    private DeathZone _deathZone;

    [SerializeField]
    private PlayModeScoreView _scoreView;

    private ObstaclesController _obstaclesController;
    private AbilitiesInitializer _abilitiesInitializer;
    private DeathHandleInitializer _deathHandleInitializer;
    private ScoreCounter _scoreCounter;

    private bool _simulate;

    private void Awake()
    {
        LevelData data          = new();
        data.ObstaclesContainer = _obstaclesContainer;
        data.ObstacleSpawnPoint = _obstaclesSpawnPoint;

        _obstaclesController    = new(data, _config.ObstaclesSettings);
        _abilitiesInitializer   = new(_config.AbilitiesConfig);
        _deathHandleInitializer = new(_deathZone);
        _scoreCounter           = new(_obstaclesController.Pool, 
                                      _config.ScoreCounterConfig.ScoreTriggerPrefab);

        _scoreCounter.OnScoreChanged += _scoreView.Show;

        _character.SetAbility(_abilitiesInitializer.Factory.Create<SpeedFlyAbility>());
        _character.OnDeath += OnCharacterDeath;

        StateManager.Register(this);
    }

    private void OnCharacterDeath()
    {
        StateManager.SetState<PauseState>();
        UIManager   .Show<DeathScreen>();
    }

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
        _scoreCounter       .Reset();
        _scoreView          .Reset();

        GameTime.Reset();
    }

    private void Update()
    {
        if (!_simulate)
            return;

        _obstaclesController.Update();
        _character          .Move();
        _scoreCounter       .Update();

        Debug.Log(GameTime.Scale);
    }
}