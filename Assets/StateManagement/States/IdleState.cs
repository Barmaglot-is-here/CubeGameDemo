using System;

namespace StateManagement
{
    public class IdleState : BaseState
    {
        protected override bool CanTransit(Type nextState) 
            => nextState == typeof(PlayState);
        protected override void MakeTransition(Type nextState) 
            => StateManager.Play();
    }
}