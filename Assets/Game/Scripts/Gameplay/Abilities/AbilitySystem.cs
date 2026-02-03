using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Game.Abilities
{
    public static class AbilitySystem
    {
        public static BaseAbility CurrentAbility;

        public static event Action<BaseAbility> OnUse;
        public static event Action<float> OnUpdate;
        public static event Action OnExit;

        private static UniTask _task;

        static AbilitySystem()
        {
            OnExit += () => CurrentAbility = null;
        }

        public static void Run(BaseAbility ability, CancellationToken cs, Action onEnter, Action onExit)
        {
            CurrentAbility?.Cancel();

            onExit += OnExit;

            _task = UpdateTask(ability.Duration, cs, onEnter, onExit, OnUpdate);

            OnUse?.Invoke(ability);

            CurrentAbility = ability;
        }


        private static async UniTask UpdateTask(float duration, CancellationToken cs,
                                                Action onEnter,
                                                Action onExit,
                                                Action<float> onUpdate)
        {
            onEnter();

            float time = 0;
            while (time < duration)
            {
                time += Time.deltaTime * GameTime.Scale;

                onUpdate.Invoke(time);

                await UniTask.Yield(cs);
            }

            onExit();
        }
    }
}