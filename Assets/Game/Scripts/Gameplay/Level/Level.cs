using UnityEngine;

public class Level : MonoBehaviour
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

    private ObstaclesController _obstaclesController;
    private AbilitiesInitializer _abilitiesInitializer;
    private DeathHandleInitializer _deathHandleInitializer;

    private void Awake()
    {
        LevelData data          = new();
        data.ObstaclesContainer = _obstaclesContainer;
        data.ObstacleSpawnPoint = _obstaclesSpawnPoint;

        _obstaclesController    = new(data, _config.ObstacleSpawnSettings);
        _abilitiesInitializer   = new();
        _deathHandleInitializer = new(_deathZone);

        _character.SetAbility(_abilitiesInitializer.Factory.Create<SpeedFlyAbility>());
    }

    private void Update()
    {
        _obstaclesController.Update();
        _character          .Move();
    }
}