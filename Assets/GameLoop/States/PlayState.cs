using System;
using System.Collections.Generic;

namespace GameLoopManagement
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

        internal override void Enter() => GameLoop.Invoke(FunctionType.Play);
    }
}