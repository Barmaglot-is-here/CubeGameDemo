using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private float _moveForce;
    [SerializeField]
    private float _abilityDuration;

    private IEnumerator _coroutine;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirectionUp() => _moveForce = Math.Abs(_moveForce);
    public void ChangeDirectionDown() => _moveForce = -Math.Abs(_moveForce);

    public void UseAbility()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
            
        _coroutine = Ability();

        StartCoroutine(_coroutine);
    }

    private void Update()
    {
        _rigidbody.AddForceY(_moveForce * GameTime.Value);
    }

    private IEnumerator Ability()
    {
        float time = 0;

        while (time < _abilityDuration)
        {
            time += GameTime.Value;
        }

        yield break;
    }
}