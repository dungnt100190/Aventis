using System;

namespace Kiss4Web.Infrastructure.DataAccess.Entities
{
    public interface IGuidEntity
    {
        Guid Id { get; }
        byte[] RowVersion { get; }
    }
}