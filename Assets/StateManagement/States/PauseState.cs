using System;
using System.Collections.Generic;

namespace StateManagement
{
    public class PauseState : BaseState
    {
        internal override IEnumerable<Type> SupportedStates
        {
            get
            {
                yield return typeof(IdleState);
                yield return typeof(PlayState);
            }
        }

        internal override void Enter() => StateManager.Pause();
    }
}