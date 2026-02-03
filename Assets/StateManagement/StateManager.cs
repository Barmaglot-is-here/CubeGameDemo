using System;
using System.Collections.Generic;
using System.Linq;

namespace StateManagement
{
    public static class StateManager
    {
        private static readonly List<IPlayable> _playProviders;
        private static readonly List<IPausable> _pauseProviders;
        private static readonly List<IResetable> _resetProviders;
        private static readonly List<IStartable> _startProviders;

        private static readonly Dictionary<Type, BaseState> _states;

        private static BaseState _currentState;

        static StateManager()
        {
            _playProviders      = new();
            _pauseProviders     = new();
            _resetProviders     = new();
            _startProviders     = new();

            _states = new()
            {
                {typeof(IdleState),     new IdleState() },
                {typeof(PlayState),     new PlayState() },
                {typeof(PauseState),    new PauseState() },
            };

            _currentState = _states[typeof(IdleState)];
        }

        public static void Register(IGameStateProvider provider)
        {
            TryAdd(_playProviders,  provider);
            TryAdd(_pauseProviders, provider);
            TryAdd(_resetProviders, provider);
            TryAdd(_startProviders, provider);
        }

        public static void Unregister(IGameStateProvider provider)
        {
            TryRemove(_playProviders, provider);
            TryRemove(_pauseProviders, provider);
            TryRemove(_resetProviders, provider);
            TryRemove(_startProviders, provider);
        }

        private static void TryAdd<T>(List<T> collection, IGameStateProvider provider)
        {
            if (provider is T TProvider)
                collection.Add(TProvider);
        }

        private static void TryRemove<T>(List<T> collection, IGameStateProvider provider)
        {
            if (provider is T TProvider)
                collection.Remove(TProvider);
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

        internal static void Play()     => _playProviders.ForEach(p => p.Play());
        internal static void Pause()    => _pauseProviders.ForEach(p => p.Pause());
        internal static void Reset()    => _resetProviders.ForEach(p => p.Reset());
        internal static void Start()    => _startProviders.ForEach(p => p.Start());
    }
}