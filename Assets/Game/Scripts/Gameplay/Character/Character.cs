using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterConfig _config;

    private float _moveForce;
    private IAbility _ability;

    public new Rigidbody2D rigidbody { get; private set; }

    public Action OnDeath { get; set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        _moveForce              = _config.MoveForce;
        rigidbody.mass          = _config.Mass;
        rigidbody.gravityScale  = _config.GravityScale;
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
}