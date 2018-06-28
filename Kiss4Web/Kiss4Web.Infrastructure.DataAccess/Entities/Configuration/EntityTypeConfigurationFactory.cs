using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public class EntityTypeConfigurationFactory
    {
        private readonly IEnumerable<Assembly> _assembliesWithModelBuilders;
        private readonly SchemaName _defaultSchemaName;

        public EntityTypeConfigurationFactory(IEnumerable<Assembly> assembliesWithModelBuilders, SchemaName defaultSchemaName)
        {
            _assembliesWithModelBuilders = assembliesWithModelBuilders;
            _defaultSchemaName = defaultSchemaName;
        }

        //public EntityTypeConfigurationFactory(Assembly assemblyWithModelBuilders)
        //    : this(new[] { assemblyWithModelBuilders }, SchemaExtensionMethods.GetDbSchemaName(assemblyWithModelBuilders.GetName().Name))
        //{
        //}

        public IEnumerable<IEntityTypeConfiguration> CreateEntityTypeConfigurations()
        {
            var result = _assembliesWithModelBuilders
                .GetTypesImplementing<IEntityTypeConfiguration>()
                .Select(typ => new
                {
                    typ,
                    DefaultConstructor = typ.GetConstructor(new Type[] { }),
                    SchemaConstructor = typ.GetConstructor(new[] { typeof(SchemaName) })
                })
                .Select(tmp => tmp.SchemaConstructor?.Invoke(new object[] { _defaultSchemaName }) ??
                               tmp.DefaultConstructor?.Invoke(new object[] { }) ??
                               throw new Exception($"Type {tmp.typ.Name} has no mactching public constructor"))
                .OfType<IEntityTypeConfiguration>()
                .ToList();
            return result;
        }
    }
}