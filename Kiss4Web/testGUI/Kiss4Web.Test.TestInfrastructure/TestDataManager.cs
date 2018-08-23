using Kiss4Web.Test.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Kiss4Web.Test.TestInfrastructure
{
    public class TestDataManager
    {
        private static readonly IDictionary<string, string> _IdConventionExceptions = new Dictionary<string, string>
        {
            {"XUser", "UserID"},
            {"XUserGroup", "UserGroupID"},
            {"XRight", "RightID"},
        };

        private readonly List<object> _createdEntities = new List<object>();
        private readonly IDictionary<string, IDictionary<string, int>> _identifierLookup = new Dictionary<string, IDictionary<string, int>>();

        public int Lookup<TEntity>(string logicalName)
        {
            var id = _identifierLookup.Lookup(typeof(TEntity).Name.Normalize())?.Lookup(logicalName);
            if (id == null)
            {
                throw new KeyNotFoundException($"Logical name {logicalName} not found. Have you set up test data?");
            }

            return id.Value;
        }

        public IEnumerable<T> CreateSetWithLookup<T>(Table table, Dictionary<string, string> fieldMapping = null) where T : class
        {
            var entities = table.CreateSet<T>().ToList();
            var properties = table.Header.ToList();
            var entityProperties = typeof(T).GetProperties();
            var result = new List<T>();

            for (var i = 0; i < table.RowCount; i++)
            {
                var entity = entities[i];
                foreach (var prop in properties)
                {
                    var value = table.Rows[i][prop];
                    if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (!int.TryParse(value, out var id))
                        {
                            var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                            if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(entity, null);
                            }
                            else
                            {
                                // value is the logical name of entity (which should already be created)
                                var fieldMapName = prop;
                                if (fieldMapping != null && fieldMapping.ContainsKey(prop))
                                {
                                    fieldMapName = fieldMapping[prop];
                                }
                                var entityName = GetEntityNameFromHeader(prop);
                                var lookup = _identifierLookup.Lookup(entityName);
                                var referencedEntityId = lookup.Lookup(value.Normalize());
                                if (referencedEntityId == default(int))
                                {
                                    throw new KeyNotFoundException($"Logical name {value} not found. Have you set up test data?");
                                }
                                property.SetValue(entity, referencedEntityId);
                            }
                        }
                    }
                    else
                    {
                        var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                        if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(entity, null);
                        }
                    }
                }

                result.Add(entity);
            }

            return result;
        }

        public void Insert<TEntity>(Table table, Dictionary<string, string> fieldMapping = null) where TEntity : class
        {
            var entities = table.CreateSet<TEntity>().ToList(); // Assumption: order remains as in the table
            var properties = table.Header.ToList();
            var entityProperties = typeof(TEntity).GetProperties();
            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
            var logicalNameLookup = new Dictionary<object, string>();

            using (var context = _CreateDbContext())
            {
                var repository = new EntityRepository<TEntity>(context);
                for (var i = 0; i < table.RowCount; i++)
                {
                    var entity = entities[i];
                    foreach (var prop in properties)
                    {
                        var value = table.Rows[i][prop];
                        if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (!int.TryParse(value, out var id))
                            {
                                // lookup instead of id
                                if (string.Equals(prop, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    // value is the logical name of this entity that will be created
                                    logicalNameLookup.Add(entity, value);
                                }
                                else
                                {
                                    var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                                    if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                                    {
                                        property.SetValue(entity, null);
                                    }
                                    else
                                    {
                                        // value is the logical name of another entity (which should already be created)
                                        var fieldMapName = prop;
                                        if (fieldMapping != null && fieldMapping.ContainsKey(prop))
                                        {
                                            fieldMapName = fieldMapping[prop];
                                        }
                                        var entityName = GetEntityNameFromHeader(fieldMapName);
                                        var lookup = _identifierLookup[entityName];
                                        var referencedEntityId = lookup[value.Normalize()];
                                        property.SetValue(entity, referencedEntityId);
                                    }
                                }
                            }
                        }
                        else
                        {
                            var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                            if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(entity, null);
                            }
                        }
                    }
                    repository.Insert(entity);
                }
            }

            // get ids for lookup
            var entityLookup = _identifierLookup.LookupAddIfMissing(typeof(TEntity).Name.Normalize(), () => new Dictionary<string, int>());
            foreach (var entity in entities.OfType<IEntity>())
            {
                var logicalName = logicalNameLookup.Lookup(entity);
                if (logicalName != null)
                {
                    entityLookup.Add(logicalName.Normalize(), entity.Id);
                }
            }

            _createdEntities.AddRange(entities);
        }

        private static string GetEntityNameFromHeader(string idProperty)
        {
            var exception = _IdConventionExceptions.Where(kvp => kvp.Value == idProperty)
                                                  .Select(kvp => kvp.Key)
                                                  .FirstOrDefault();
            return (exception ?? idProperty.Substring(0, idProperty.Length - 2)).Normalize();
        }

        public void Cleanup<TEntity>() where TEntity : class
        {
            if (_createdEntities != null && _createdEntities.Count > 0)
            {
                using (var context = _CreateDbContext())
                {
                    var repository = new EntityRepository<TEntity>(context);
                    foreach (var createdEntity in _createdEntities)
                    {
                        if (createdEntity.GetType().Name.Equals(typeof(TEntity).Name))
                        {
                            repository.Delete((TEntity)createdEntity);
                        }
                    }
                }
            }
        }

        private KissContext _CreateDbContext()
        {
            var commonAuditor = new CommonAuditor("Test GUI runner", DateTime.Now);
            var historyAuditor = new HistoryVersionCreator("Test GUI runner");
            return new KissContext(new IDbChangeAuditor[] { commonAuditor, historyAuditor });
        }
    }
}
