using System;
using System.Collections.Generic;

namespace StateManagement
{
    public static class StateManager
    {
        private static readonly RunableCollection<IPlayable>         _playProviders;
        private static readonly RunableCollection<IPausable>         _pauseProviders;
        private static readonly RunableCollection<IResetable>         _resetProviders;

        private static readonly Dictionary<Type, BaseState> _states;

        private static BaseState _currentState;

        static StateManager()
        {
            _playProviders          = new((IPlayable provider)      => provider.Play());
            _pauseProviders         = new((IPausable provider)      => provider.Pause());
            _resetProviders         = new((IResetable provider)     => provider.Reset());

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
            TryAdd(_playProviders,     provider);
            TryAdd(_pauseProviders,     provider);
            TryAdd(_resetProviders,     provider);
        }

        private static void TryAdd<T>(RunableCollection<T> collection, IGameStateProvider provider)
        {
            if (provider is T TProvider)
                collection.Add(TProvider);
        }

        public static void SetState<T>() where T : BaseState
        {
            Type nextState = typeof(T);

            _currentState.Handle(nextState);

            _currentState = _states[nextState];
        }

        internal static void Play()       => _playProviders.Run();
        internal static void Pause()       => _pauseProviders.Run();
        internal static void Reset()       => _resetProviders.Run();
    }
}