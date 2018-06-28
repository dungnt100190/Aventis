using System;
using Kiss4Web.Infrastructure;

namespace Kiss4Web.TestInfrastructure.TestServer
{
    public class TestDateTimeProvider : IDateTimeProvider
    {
        public TestDateTimeProvider()
        {
            // set defaults
            Now = DateTime.Now;
            UtcNow = Now.ToUniversalTime();
        }

        public void SetLocalTime(DateTime dateTime)
        {
            Now = dateTime;
            UtcNow = dateTime.ToUniversalTime();
        }

        public DateTime Now { get; private set; }
        public DateTime UtcNow { get; private set; }
    }
}