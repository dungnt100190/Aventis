using System;

namespace Kiss4Web.Infrastructure.Messaging
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event)
            where TEvent : Event;

        void Subscribe<TEvent>(Action<TEvent> eventHandler, Func<TEvent, bool> filter = null)
            where TEvent : Event;
    }
}