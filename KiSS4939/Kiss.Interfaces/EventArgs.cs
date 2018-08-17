using System;

namespace Kiss.Interfaces
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T parameter)
        {
            Parameter = parameter;
        }

        public T Parameter { get; private set; }
    }
}
