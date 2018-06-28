using System;

namespace Kiss4Web.Infrastructure.DataAccess.Entities
{
    public class DateTimeTypeAttribute : Attribute
    {
        public DateTimeTypeAttribute(DateTimeType dateTimeType)
        {
            DateTimeType = dateTimeType;
        }

        public DateTimeType DateTimeType { get; private set; }
    }
}