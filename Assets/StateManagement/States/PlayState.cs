using System;
using System.Collections.Generic;

namespace StateManagement
{
    public class PlayState : BaseState
    {
        internal override IEnumerable<Type> SupportedStates
        {
            get
            {
                yield return typeof(PauseState);
                yield return typeof(IdleState);
            }
        }

        internal override void Enter() => StateManager.Play();
    }
}