using System;
using System.Linq;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public static class SchemaExtensionMethods
    {
        public static SchemaName GetDbSchemaName(this Type entityType)
        {
            return GetDbSchemaName(entityType?.Namespace);
        }

        public static SchemaName GetDbSchemaName(string @namespace)
        {
            // Convention: use module name as schema: Kiss4Web.[ModuleName].Interface...
            return new SchemaName(@namespace?.Split('.').Skip(2).FirstOrDefault()?.ToLowerInvariant());
        }
    }
}