using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLoopManagement
{
    public class GameLoop : MonoBehaviour
    {
        private static GameLoop _instance;

        private readonly static List<Action> _startActions;
        private readonly static List<Action> _playActions;
        private readonly static List<Action> _pauseActions;
        private readonly static List<Action> _resetActions;
        private readonly static List<Action> _updateActions;
        private readonly static List<Action> _fixedActions;

        private static readonly Dictionary<Type, BaseState> _states;

        private static BaseState _currentState;

        private static bool IsUpdateEnabled => _currentState.GetType() == typeof(PlayState);

        static GameLoop()
        {
            _startActions   = new();
            _playActions    = new();
            _pauseActions   = new();
            _resetActions   = new();
            _updateActions  = new();
            _fixedActions   = new();

            _states = new()
            {
                {typeof(IdleState),     new IdleState() },
                {typeof(PlayState),     new PlayState() },
                {typeof(PauseState),    new PauseState() },
            };

            _currentState = _states[typeof(IdleState)];
        }

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                throw new Exception("GameLoop can't be instantiate twice");
        }

        public static void SetState<T>() where T : BaseState
        {
            Type nextState = typeof(T);

            if (!_currentState.SupportedStates.Contains(nextState))
                throw new InvalidTransitionException(_currentState.GetType().ToString(),
                                                     nextState.ToString());

            _currentState.Exit();

            _currentState = _states[nextState];

            _currentState.Enter();
        }

        public static void Register(Action action, FunctionType type)
        {
            var list = GetList(type);

            list.Add(action);
        }

        public static void Unregister(Action action, FunctionType type)
        {
            var list = GetList(type);

            list.Remove(action);
        }

        private static List<Action> GetList(FunctionType type)
        {
            var list = type switch
            {
                FunctionType.Start => _startActions,
                FunctionType.Play => _playActions,
                FunctionType.Pause => _pauseActions,
                FunctionType.Reset => _resetActions,
                FunctionType.Update => _updateActions,
                FunctionType.FixedUpdate => _fixedActions,
                _ => throw new NotImplementedException(),
            };

            return list;
        }

        private void Update()
        {
            if (IsUpdateEnabled)
                _updateActions.ForEach(action => action.Invoke());
        }

        private void FixedUpdate()
        {
            if (IsUpdateEnabled)
                _fixedActions.ForEach(action => action.Invoke());
        }

        internal static void Invoke(FunctionType type)
        {
            var list = GetList(type);

            list.ForEach(action => action.Invoke());
        }
    }
}
