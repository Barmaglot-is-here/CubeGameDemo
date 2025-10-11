using System;
using System.Collections.Generic;

namespace StateManagement
{
    public class IdleState : BaseState
    {
        internal override IEnumerable<Type> SupportedStates
        {
            get
            {
                yield return typeof(PlayState);
            }
        }

        internal override void Enter() => StateManager.Reset();
        internal override void Exit() => StateManager.Start();
    }
}