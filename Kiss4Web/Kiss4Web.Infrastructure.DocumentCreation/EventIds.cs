using Microsoft.Extensions.Logging;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    internal static class EventIds
    {
        internal static readonly EventId BookmarkDefinitionNotFoundEventId = new EventId(60001, "BookmarkDefinitionNotFound");
        internal static readonly EventId ContextValueNotProvidedEventId = new EventId(60002, "ContextValueNotProvided");
        //internal static readonly EventId ContextValueNotProvidedEventId = new EventId(60002, "ContextValueNotProvided");
    }
}