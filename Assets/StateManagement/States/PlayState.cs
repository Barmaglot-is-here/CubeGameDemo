using System;

namespace StateManagement
{
    public class PlayState : BaseState
    {
        protected override bool CanTransit(Type nextState) 
            => nextState == typeof(PauseState) || nextState == typeof(IdleState);

        protected override void MakeTransition(Type nextState)
        {
            StateManager.Pause();

            if (nextState == typeof(IdleState))
                StateManager.Reset();
        }
    }
}