using UnityEngine;

[DefaultExecutionOrder(-9000)]
public class FactoriesRegistrator : MonoBehaviour
{
    [SerializeField]
    private ObstacleFactory _obstacleFactory;
    [SerializeField]
    private AbilitiesFactory _abilitiesFactory;

    private void Awake()
    {
        var services = Level.Services;

        services.Add(_obstacleFactory);
        services.Add(_abilitiesFactory);
    }
}