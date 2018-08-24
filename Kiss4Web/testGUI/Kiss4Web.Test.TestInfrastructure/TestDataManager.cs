using Kiss4Web.Test.DataAccess;
using Kiss4Web.Test.DataAccess.KissPrograms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
            {"XModul", "ModulID"},
        };

        private static readonly List<string> _NoneIdentityEntities = new List<string>
        {
            "XModul"
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
                    var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                    if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                    {
                        // value of property is null
                        property.SetValue(entity, null);
                    }
                    else if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase) && !int.TryParse(value, out var id))
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

                result.Add(entity);
            }

            return result;
        }

        public TEntity GetLastRecord<TEntity>() where TEntity : class
        {
            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
            object[] attrs = typeof(TEntity).GetProperty(entityIdPropertyName).GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                KeyAttribute keyAttr = attr as KeyAttribute;
                if (keyAttr != null)
                {
                    var repository = new EntityRepository<TEntity>(_CreateDbContext());
                    var lastRecord = repository.GetAll().OrderByField(entityIdPropertyName, false).FirstOrDefault();
                    return lastRecord;
                }
            }
            return null;
        }

        public void Insert<TEntity>(Table table, Dictionary<string, string> fieldMapping = null, bool isView = false) where TEntity : class
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
                        var property = entityProperties.First(prp => string.Equals(prp.Name, prop, StringComparison.InvariantCultureIgnoreCase));
                        if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                        {
                            // value of property is null
                            property.SetValue(entity, null);
                        }
                        else if (prop.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase) && !int.TryParse(value, out var id))
                        {
                            // lookup instead of id
                            if (string.Equals(prop, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase) && !isView)
                            {
                                // value is the logical name of this entity that will be created
                                logicalNameLookup.Add(entity, value);

                                // determine that key of this entity is not identity => set key value for this new record = key value of last created record + 1
                                object[] attrs = typeof(TEntity).GetProperty(prop).GetCustomAttributes(true);
                                foreach (object attr in attrs)
                                {
                                    DatabaseGeneratedAttribute dbGenAttr = attr as DatabaseGeneratedAttribute;
                                    if (dbGenAttr != null && dbGenAttr.DatabaseGeneratedOption == DatabaseGeneratedOption.None)
                                    {
                                        var lastRecord = repository.GetAll().OrderByField(prop, false).FirstOrDefault();
                                        int lastRecordId = int.Parse(property.GetValue(lastRecord).ToString());
                                        property.SetValue(entity, lastRecordId + 1);
                                    }
                                }
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

                    switch (entityTypeName)
                    {
                        case "FaFall":
                            _InsertFaFall(entity as FaFall);
                            break;
                        default:
                            repository.Insert(entity); ;
                            break;
                    }
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

        private void _InsertFaFall(FaFall entity) 
        {
            if (entity != null)
            {
                var context = new KissProgramContext();
                context.spFaInsertFaFall(entity.UserID, entity.BaPersonID, entity.DatumVon, entity.DatumBis);
                context.SaveChanges();
            }
        }

        public void TrackEntity<TEntity>(TEntity entity) where TEntity : class
        {
            _createdEntities.Add(entity);
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
                        switch (createdEntity.GetType().Name)
                        {
                            case "FaFall":
                                _CleanupFaFall(createdEntity as FaFall);
                                break;
                            default:
                                if (createdEntity.GetType().Name.Equals(typeof(TEntity).Name))
                                {
                                    var entityTypeName = typeof(TEntity).Name;
                                    var entityIdPropertyName = _IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
                                    var entityIdValue = int.Parse(typeof(TEntity).GetProperty(entityIdPropertyName).GetValue(createdEntity).ToString());
                                    repository.Delete(entityIdValue);
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void _CleanupFaFall(FaFall entity)
        {
            if (entity != null)
            {
                var context = new KissProgramContext();
                context.spFaDeleteFaFall(entity.FaFallID);
                context.SaveChanges();
            }
        }

        private static string GetEntityNameFromHeader(string idProperty)
        {
            var exception = _IdConventionExceptions.Where(kvp => kvp.Value == idProperty)
                                                  .Select(kvp => kvp.Key)
                                                  .FirstOrDefault();
            return (exception ?? idProperty.Substring(0, idProperty.Length - 2)).Normalize();
        }

        private KissContext _CreateDbContext()
        {
            var commonAuditor = new CommonAuditor("Test GUI runner", DateTime.Now);
            var historyAuditor = new HistoryVersionCreator("Test GUI runner");
            return new KissContext(new IDbChangeAuditor[] { commonAuditor, historyAuditor });
        }
    }
}
