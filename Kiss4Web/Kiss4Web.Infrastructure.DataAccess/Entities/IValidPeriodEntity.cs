using System;

namespace Kiss4Web.Infrastructure.DataAccess.Entities
{
    public interface IValidPeriodEntity
    {
        DateTime ValidFrom { get; set; }
        DateTime ValidTill { get; set; }
    }
}