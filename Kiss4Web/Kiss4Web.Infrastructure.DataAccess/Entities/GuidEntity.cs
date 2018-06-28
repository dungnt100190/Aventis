using System;

namespace Kiss4Web.Infrastructure.DataAccess.Entities
{
    public abstract class GuidEntity : IGuidEntity
    {
        public Guid Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}