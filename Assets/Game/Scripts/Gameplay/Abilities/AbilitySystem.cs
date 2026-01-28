using System;

namespace Game.Abilities
{
    public static class AbilitySystem
    {
        private static IAbility _currentAbility;

        public static event Action<IAbility> OnUse;
        public static event Action<float> OnUpdate;
        public static event Action OnExit;

        public static void Run(IAbility ability, Action onEnter, Action onExit)
        {
            if (_currentAbility != null)
                Cancel(_currentAbility);

            OnExit = onExit;
            TaskManager.Run(ability, ability.Duration, onEnter, OnExit, OnUpdate);
            OnUse?.Invoke(ability);

            _currentAbility = ability;
        }

        public static void Cancel(IAbility ability)
        {
            if (TaskManager.IsRunning(ability))
                TaskManager.Cancel(ability);
        }
    }
}