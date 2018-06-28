using System;

namespace Kiss4Web.Infrastructure.Configuration
{
    public class OptionalKeyAttribute : Attribute
    {
        public OptionalKeyAttribute(string key)
        {
            Key = key;
        }

        public string Key { get; set; }
    }
}