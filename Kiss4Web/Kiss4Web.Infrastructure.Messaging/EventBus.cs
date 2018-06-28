using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Kiss4Web.Infrastructure.Messaging
{
    /// <summary>
    /// placeholder for real event bus like MassTransit
    /// </summary>
    public class EventBus : IEventBus
    {
        private IDictionary<Type, IList<object>> Subscriptions { get; } = new ConcurrentDictionary<Type, IList<object>>();

        public void Publish<TEvent>(TEvent @event)
            where TEvent : Event
        {
            var subscriptions = Subscriptions.Lookup(typeof(TEvent));
            subscriptions?.OfType<Subscription<TEvent>>()
                .Where(sub => sub.Filter == null || sub.Filter(@event))
                .DoForEach(sub => sub.EventHandler(@event));
        }

        public void Subscribe<TEvent>(Action<TEvent> eventHandler, Func<TEvent, bool> filter = null)
            where TEvent : Event
        {
            var subscriptionsForThisEvent = Subscriptions.LookupAddIfMissing(typeof(TEvent), () => new List<object>());
            subscriptionsForThisEvent.Add(new Subscription<TEvent> { EventHandler = eventHandler, Filter = filter });
        }

        private class Subscription<TEvent>
        {
            public Action<TEvent> EventHandler { get; set; }
            public Func<TEvent, bool> Filter { get; set; }
        }
    }
}