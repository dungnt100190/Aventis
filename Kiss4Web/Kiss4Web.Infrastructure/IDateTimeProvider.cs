using System;

namespace Kiss4Web.Infrastructure
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}