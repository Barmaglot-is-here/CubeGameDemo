using StateManagement;
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

        _scoreCounter.OnCount += _scoreView.Show;

        _character.SetAbility(_abilitiesInitializer.Factory.Create<SpeedFlyAbility>());

        StateManager.Add(this);
    }

    public void Play() => _simulate = true;
    public void Pause() => _simulate = false;

    void IResetable.Reset() => _obstaclesController.Reset();

    private void Update()
    {
        if (!_simulate)
            return;

        _obstaclesController.Update();
        _character          .Move();
        _scoreCounter       .Update();
    }
}