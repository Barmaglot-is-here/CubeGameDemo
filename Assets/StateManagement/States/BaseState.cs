using System;

namespace StateManagement
{
    public abstract class BaseState
    {
        internal void Handle(Type nextState)
        {
            if (CanTransit(nextState))
                MakeTransition(nextState);
            else
                throw new InvalidTransitionException(this.GetType().ToString(), nextState.ToString());
        }

        protected abstract bool CanTransit(Type nextState);
        protected abstract void MakeTransition(Type nextState);
    }
}