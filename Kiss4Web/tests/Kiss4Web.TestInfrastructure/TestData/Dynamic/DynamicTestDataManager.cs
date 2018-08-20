using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.DataAccess;
using Kiss4Web.Infrastructure;
using Kiss4Web.Infrastructure.DataAccess;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Model.Entities;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Kiss4Web.TestInfrastructure.TestData.Dynamic
{
    public class DynamicTestDataManager : IDisposable
    {
        private static readonly IDictionary<string, string> IdConventionExceptions = new Dictionary<string, string>
        {
            {"XUser", "UserID"},
            {"XUserGroup", "UserGroupID"},
            {"XRight", "RightID"},
        };

        private readonly ConnectionString _connectionString;
        private readonly List<object> _createdEntities = new List<object>();
        private readonly IDateTimeProvider _dateTimeProvider;

        private readonly IDictionary<string, IDictionary<string, int>> _identifierLookup =
            new Dictionary<string, IDictionary<string, int>>();

        public DynamicTestDataManager(ConnectionString connectionString, IDateTimeProvider dateTimeProvider)
        {
            _connectionString = connectionString;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task Cleanup()
        {
            using (var context = CreateDbContext())
            {
                foreach (var createdEntity in _createdEntities)
                {
                    context.Remove(createdEntity);
                }

                await context.SaveChangesAsync();
            }
        }

        public IEnumerable<T> CreateSetWithLookup<T>(Table table)
            where T : new()
        {
            var entities = table.CreateSet<T>().ToList();
            var idProperties = table.Header
                                    .Where(hdr => hdr.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase))
                                    .ToList();
            var entityProperties = typeof(T).GetProperties();
            var result = new List<T>();
            for (var i = 0; i < table.RowCount; i++)
            {
                var entity = entities[i];
                foreach (var idProperty in idProperties)
                {
                    var value = table.Rows[i][idProperty];
                    if (!int.TryParse(value, out var id))
                    {
                        // value is the logical name of another entity (which should already be created)
                        var entityName = GetEntityNameFromHeader(idProperty);
                        var lookup = _identifierLookup.Lookup(entityName);
                        var referencedEntityId = lookup.Lookup(value.Normalize());
                        if (referencedEntityId == default(int))
                        {
                            throw new KeyNotFoundException($"Logical name {value} not found. Have you set up test data?");
                        }
                        var property = entityProperties.First(prp => string.Equals(prp.Name, idProperty, StringComparison.InvariantCultureIgnoreCase));
                        property.SetValue(entity, referencedEntityId);
                    }
                }

                result.Add(entity);
            }

            return result;
        }

        public IEnumerable<T> CreateSetWithLookupForEntity<T>(Table table)
            where T : new()
        {
            var entities = table.CreateSet<T>().ToList();
            var idProperties = table.Header
                                    .Where(hdr => hdr.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase))
                                    .ToList();
            var entityProperties = typeof(T).GetProperties();
            var entityTypeName = typeof(T).Name;
            var result = new List<T>();

            for (var i = 0; i < table.RowCount; i++)
            {
                var entity = entities[i];
                foreach (var idProperty in idProperties)
                {
                    var value = table.Rows[i][idProperty];
                    if (!int.TryParse(value, out var id))
                    {
                        var property = entityProperties.First(prp => string.Equals(prp.Name, idProperty, StringComparison.InvariantCultureIgnoreCase));
                        if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(entity, null);
                        }
                        else
                        {
                            // value is the logical name of entity (which should already be created)
                            var entityName = GetEntityNameFromHeader(idProperty);
                            if (entityName.Equals("XTask")) entityName = "Xtask";
                            // apply for XTask
                            if (entityTypeName.Equals("Xtask"))
                            {
                                if (idProperty.Equals("SenderID") || idProperty.Equals("ReceiverID"))
                                {
                                    entityName = "XUser";
                                }
                                if (idProperty.Equals("FaFallID"))
                                {
                                    entityName = "BaPerson";
                                }
                            }
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

                result.Add(entity);
            }

            return result;
        }

        public void Dispose()
        {
            Cleanup().Wait();
        }

        public async Task Insert<TEntity>(Table table)
            where TEntity : class
        {
            var entities = table.CreateSet<TEntity>().ToList(); // Assumption: order remains as in the table
            var idProperties = table.Header
                                    .Where(hdr => hdr.EndsWith("ID", StringComparison.InvariantCultureIgnoreCase))
                                    .ToList();
            var entityProperties = typeof(TEntity).GetProperties();
            var entityTypeName = typeof(TEntity).Name;
            var entityIdPropertyName = IdConventionExceptions.Lookup(entityTypeName) ?? $"{entityTypeName}ID"; // convention
            var logicalNameLookup = new Dictionary<object, string>();

            using (var context = CreateDbContext())
            {
                for (var i = 0; i < table.RowCount; i++)
                {
                    var entity = entities[i];
                    foreach (var idProperty in idProperties)
                    {
                        var value = table.Rows[i][idProperty];
                        if (!int.TryParse(value, out var id))
                        {
                            // lookup instead of id
                            if (string.Equals(idProperty, entityIdPropertyName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                // value is the logical name of the entity yet to be created
                                logicalNameLookup.Add(entity, value);
                            }
                            else
                            {
                                var property = entityProperties.First(prp => string.Equals(prp.Name, idProperty, StringComparison.InvariantCultureIgnoreCase));
                                if (string.Equals(value, "NULL", StringComparison.OrdinalIgnoreCase))
                                {
                                    property.SetValue(entity, null);
                                }
                                else
                                {
                                    // value is the logical name of another entity (which should already be created)
                                    var entityName = GetEntityNameFromHeader(idProperty);
                                    // apply for XTask
                                    if (entityTypeName.Equals("Xtask"))
                                    {
                                        if (idProperty.Equals("SenderID") || idProperty.Equals("ReceiverID"))
                                        {
                                            entityName = "XUser";
                                        }
                                        if (idProperty.Equals("FaFallID"))
                                        {
                                            entityName = "BaPerson";
                                        }
                                    }
                                    // apply for FaLeistung
                                    if (entityTypeName.Equals("FaLeistung"))
                                    {
                                        if (idProperty.Equals("FaFallID"))
                                        {
                                            entityName = "BaPerson";
                                        }
                                    }
                                    var lookup = _identifierLookup[entityName];
                                    var referencedEntityId = lookup[value.Normalize()];
                                    property.SetValue(entity, referencedEntityId);
                                }
                            }
                        }
                    }

                    context.Add(entity);
                }

                await context.SaveChangesAsync();
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

        public async Task<TEntity> Insert<TEntity>(TEntity entity)
            where TEntity : class
        {
            using (var context = CreateDbContext())
            {
                context.Add(entity);
                await context.SaveChangesAsync();
                _createdEntities.Add(entity);
                return entity;
            }
        }

        public bool Delete<TEntity>(object key) where TEntity : class
        {
            var context = CreateDbContext();
            var dbSet = context.Set<TEntity>();
            TEntity entity = dbSet.Find(key);
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return context.SaveChanges() >= 1;
        }

        public int Lookup<TEntity>(string logicalName)
        {
            var id = _identifierLookup.Lookup(typeof(TEntity).Name.Normalize())?.Lookup(logicalName);
            if (id == null)
            {
                throw new KeyNotFoundException($"Logical name {logicalName} not found. Have you set up test data?");
            }

            return id.Value;
        }

        public void TrackEntity(IEntity entity)
        {
            _createdEntities.Add(entity);
        }

        private static string GetEntityNameFromHeader(string idProperty)
        {
            var exception = IdConventionExceptions.Where(kvp => kvp.Value == idProperty)
                                                  .Select(kvp => kvp.Key)
                                                  .FirstOrDefault();
            return (exception ?? idProperty.Substring(0, idProperty.Length - 2)).Normalize();
        }

        private Kiss4DbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(_connectionString);
            var ccmmAuditor = new CcmmAuditor("Test runner", _dateTimeProvider);
            var historyAuditor = new HistoryVersionCreator("Test runner");
            return new Kiss4DbContext(options.Options, new IDbChangeAuditor[] { ccmmAuditor, historyAuditor });
        }
    }
}