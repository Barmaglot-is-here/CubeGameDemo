using System;
using UnityEngine;
using StateManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IPlayable, IPausable, IResetable
{
    [SerializeField]
    private CharacterConfig _config;

    private float _moveForce;
    private IAbility _ability;

    private Vector2 _startPosition;

    public new Rigidbody2D rigidbody { get; private set; }

    public Action OnDeath { get; set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        _moveForce              = _config.MoveForce;
        rigidbody.mass          = _config.Mass;
        rigidbody.gravityScale  = _config.GravityScale;
        rigidbody.simulated     = false;

        _startPosition = transform.position;

        StateManager.Register(this);
    }

    public void SetAbility(IAbility ability) => _ability = ability;

    public void ChangeDirectionUp()     => _moveForce = Math.Abs(_moveForce);
    public void ChangeDirectionDown()   => _moveForce = -Math.Abs(_moveForce);
    public void UseAbility()            => _ability?.Use();

    public void Move() => rigidbody.AddForceY(_moveForce * GameTime.Scale);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
            OnDeath?.Invoke();
    }

    public void Play() => rigidbody.simulated = true;
    public void Pause() => rigidbody.simulated = false;

    void IResetable.Reset()
    {
        transform.position          = _startPosition;
        rigidbody.linearVelocityY   = 0;
        ChangeDirectionUp();

        _ability.Cancel();
    }
}