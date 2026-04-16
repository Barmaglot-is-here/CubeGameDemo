using System;
using System.Collections.Generic;

namespace GameLoopManagement
{
    public abstract class BaseState
    {
        internal abstract IEnumerable<Type> SupportedStates { get; }

        internal virtual void Enter() { }
        internal virtual void Exit() { }
    }
}