using System;

namespace StateManagement
{
    public class PauseState : BaseState
    {
        protected override bool CanTransit(Type nextState) 
            => nextState == typeof(IdleState) || nextState == typeof(PlayState);

        protected override void MakeTransition(Type nextState)
        {
            if (nextState == typeof(IdleState))
                StateManager.Reset();
            else
                StateManager.Play();
        }
    }
}