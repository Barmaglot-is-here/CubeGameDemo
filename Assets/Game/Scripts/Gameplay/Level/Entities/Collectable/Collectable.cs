using GameCycleManagement;
using System;
using UnityEngine;

namespace Game.Level.Entities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Collectable : MonoBehaviour
    {
        private SpriteRenderer _view;
        private Action _onCollect;


        private void Awake()
        {
            _view = GetComponent<SpriteRenderer>();

            GameLoop.Register(OnReset, FunctionType.Reset);
        }

        public void Setup(Action onCollect, Sprite sprite)
        {
            _onCollect      = onCollect;
            _view.sprite    = sprite;
        }

        public void Collect() => _onCollect.Invoke();

        private void OnReset() => Destroy(gameObject);

        private void OnDestroy() => GameLoop.Unregister(OnReset, FunctionType.Reset);
    }
}