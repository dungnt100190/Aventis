using System;
using Kiss4Web.Infrastructure;

namespace Kiss4Web
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}