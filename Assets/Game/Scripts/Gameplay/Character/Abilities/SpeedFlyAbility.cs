using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

[Serializable]
public class SpeedFlyAbility : IAbility
{
    private const int ABILITY_TIME_SCALE_MODIFIER = 3;
    private const int CHARACTER_SCALE_MODIFIER = 2;

    private readonly float _duration;

    private readonly Rigidbody2D _rigidbody;
    private readonly Transform _transform;

    public SpeedFlyAbility(float duration, Character character)
    {
        _duration   = duration;
        _rigidbody  = character.rigidbody;
        _transform  = character.transform;
    }

    void IAbility.Use() => AbilityTask().Forget();

    private async UniTask AbilityTask()
    {
        Apply();

        float time = 0;
        while (time < _duration)
        {
            time += Time.deltaTime * GameTime.Scale;

            await UniTask.Yield();
        }

        Disaply();
    }

    private void Apply()
    {
        _rigidbody.simulated = false;

        _transform.localScale /= CHARACTER_SCALE_MODIFIER;

        GameTime.Scale *= ABILITY_TIME_SCALE_MODIFIER;
    }

    private void Disaply()
    {
        _rigidbody.simulated = true;

        _transform.localScale *= CHARACTER_SCALE_MODIFIER;

        GameTime.Scale /= ABILITY_TIME_SCALE_MODIFIER;
    }
}