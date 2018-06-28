using System;

namespace Kiss4Web.Infrastructure.Messaging
{
    public class Event
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}