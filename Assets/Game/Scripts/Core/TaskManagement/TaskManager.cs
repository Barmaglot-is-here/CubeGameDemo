using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Game
{
    public static class TaskManager
    {
        private readonly static Dictionary<object, UniTask> _tasks;
        private readonly static Dictionary<object, CancellationTokenSource> _cs;

        static TaskManager()
        {
            _tasks = new();
            _cs = new();
        }

        public static void Run(object key, float duration, Action onEnter, 
                                                           Action onExit, 
                                                           Action<float> onUpdate = null)
        {
            _cs[key] = new();

            _tasks[key] = UpdateTask(duration, _cs[key], onEnter, onExit, onUpdate);
        }

        private static async UniTask UpdateTask(float duration, CancellationTokenSource cs, 
                                                Action onEnter, 
                                                Action onExit, 
                                                Action<float> onUpdate)
        {
            onEnter();

            float time = 0;
            while (time < duration && !cs.IsCancellationRequested)
            {
                time += Time.deltaTime * GameTime.Scale;

                onUpdate?.Invoke(time);

                await UniTask.Yield();
            }

            onExit();
        }

        public static void CancelIfRunning(object obj)
        {
            if (IsRunning(obj))
                _cs[obj].Cancel();
        }

        public static bool IsRunning(object key)
            => _tasks.ContainsKey(key) && _tasks[key].Status != UniTaskStatus.Succeeded;
    }
}