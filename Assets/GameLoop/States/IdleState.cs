using System;
using System.Collections.Generic;

namespace GameLoopManagement
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

        internal override void Enter() => GameLoop.Invoke(FunctionType.Reset);
        internal override void Exit() => GameLoop.Invoke(FunctionType.Start);
    }
}