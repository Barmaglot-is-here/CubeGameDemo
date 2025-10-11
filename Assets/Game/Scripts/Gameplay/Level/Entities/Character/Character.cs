using StateManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IPlayable, IPausable, IResetable
{
    [SerializeField]
    private CharacterConfig _config;
    
    private AbilitiesFactory _abilitiesFactory;
    private CharacterMovementComponent _movementComponent;

    private IAbility _ability;

    private Vector2 _startPosition;

    public new Rigidbody2D rigidbody { get; private set; }

    private void Awake()
    {
        _abilitiesFactory   = Level.Services.Get<AbilitiesFactory>();
        rigidbody           = GetComponent<Rigidbody2D>();
        _movementComponent  = new(rigidbody, _config);
        _startPosition      = transform.position;

        rigidbody.simulated = false;

        Level.Simulation.OnFixedUpdate += OnFixedUpdate;

        StateManager.Register(this);
    }

    private void Start()
    {
        _ability = _abilitiesFactory.Create<SpeedFlyAbility>();
    }

    private void OnFixedUpdate() => _movementComponent.Move();

    public void SetAbility(IAbility ability) => _ability = ability;

    public void ChangeDirectionUp() => _movementComponent.ChangeDirectionUp();
    public void ChangeDirectionDown() => _movementComponent.ChangeDirectionDown();
    public void Move() => _movementComponent.Move();
    public void UseAbility() => _ability?.Use();

    void IPlayable.Play() => rigidbody.simulated = true;
    void IPausable.Pause() => rigidbody.simulated = false;

    void IResetable.Reset()
    {
        transform.position          = _startPosition;
        rigidbody.linearVelocityY   = 0;

        ChangeDirectionUp();

        _ability.Cancel();
    }
}