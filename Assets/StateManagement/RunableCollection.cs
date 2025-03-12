using System;
using System.Collections.Generic;

namespace StateManagement
{
    internal class RunableCollection <T>
    {
        private readonly Queue<T> Members;
        private readonly Action<T> Action;

        public RunableCollection(Action<T> action)
        {
            Members = new();
            Action  = action;
        }

        public void Run()
        {
            foreach (var member in Members)
                Action.Invoke(member);
        }

        public void Add(T member) => Members.Enqueue(member);
    }
}