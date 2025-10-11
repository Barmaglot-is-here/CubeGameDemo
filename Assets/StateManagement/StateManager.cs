using System;
using System.Collections.Generic;
using System.Linq;

namespace StateManagement
{
    public static class StateManager
    {
        private static readonly RunableCollection<IPlayable> _playProviders;
        private static readonly RunableCollection<IPausable> _pauseProviders;
        private static readonly RunableCollection<IResetable> _resetProviders;
        private static readonly RunableCollection<IStartable> _startProviders;

        private static readonly Dictionary<Type, BaseState> _states;

        private static BaseState _currentState;

        static StateManager()
        {
            _playProviders      = new((IPlayable provider)      => provider.Play());
            _pauseProviders     = new((IPausable provider)      => provider.Pause());
            _resetProviders     = new((IResetable provider)     => provider.Reset());
            _startProviders     = new((IStartable provider)     => provider.Start());

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

        private static void TryAdd<T>(RunableCollection<T> collection, IGameStateProvider provider)
        {
            if (provider is T TProvider)
                collection.Add(TProvider);
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

        internal static void Play()     => _playProviders.Run();
        internal static void Pause()    => _pauseProviders.Run();
        internal static void Reset()    => _resetProviders.Run();
        internal static void Start()    => _startProviders.Run();
    }
}