using Kiss4Web.Infrastructure.Messaging;

namespace Kiss4Web.Infrastructure.Authentication
{
    public class UserAuthenticatedEvent : Event
    {
        public string User { get; set; }
    }
}