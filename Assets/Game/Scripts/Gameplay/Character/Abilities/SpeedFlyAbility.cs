using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class SpeedFlyAbility : IAbility
{
    private const int ABILITY_TIME_SCALE_MODIFIER = 3;
    private const int CHARACTER_SCALE_MODIFIER = 2;

    private readonly float _duration;

    private readonly Rigidbody2D _rigidbody;
    private readonly Transform _transform;

    private UniTask _currentTask;
    private CancellationTokenSource _cs;

    public SpeedFlyAbility(float duration, Character character)
    {
        _duration   = duration;
        _rigidbody  = character.rigidbody;
        _transform  = character.transform;
    }

    void IAbility.Use()
    {
        if (_currentTask.Status != UniTaskStatus.Succeeded)
            return;

        _cs = new();

        _currentTask = AbilityTask(_cs);
    }

    void IAbility.Cancel() => _cs?.Cancel();

    private async UniTask AbilityTask(CancellationTokenSource cs)
    {
        Apply();

        float time = 0;
        while (time < _duration && !cs.IsCancellationRequested)
        {
            time += Time.deltaTime * GameTime.Scale;

            await UniTask.Yield();
        }

        Disaply();
    }

    private void Apply()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

        _transform.localScale /= CHARACTER_SCALE_MODIFIER;

        GameTime.Multiplier = ABILITY_TIME_SCALE_MODIFIER;
    }

    private void Disaply()
    {
        _rigidbody.constraints = _rigidbody.constraints ^ RigidbodyConstraints2D.FreezePositionY;

        _transform.localScale *= CHARACTER_SCALE_MODIFIER;

        GameTime.Multiplier = 1;
    }
}