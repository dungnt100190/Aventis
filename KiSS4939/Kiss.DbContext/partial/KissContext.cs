using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;

using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.DbContext
{
    partial class KissContext : IKissContext
    {
        private readonly HashSet<Type> _tablesWithTriggers = new HashSet<Type> { typeof(BaPerson),
                                                                         typeof(BaAdresse),
                                                                         typeof(BDELeistungsart),
                                                                         typeof(BDESollStundenProJahr_XUser),
                                                                         typeof(XOrgUnit),
                                                                         typeof(XOrgUnit_User),
                                                                         typeof(XUser) };

        private readonly IDictionary<Type, Func<DbEntityEntry, System.Data.Entity.DbContext, DbEntityValidationResult>> _validations =
                      new Dictionary<Type, Func<DbEntityEntry, System.Data.Entity.DbContext, DbEntityValidationResult>>();

        public bool AutoDetectChangesEnabled
        {
            get { return Configuration.AutoDetectChangesEnabled; }
            set { Configuration.AutoDetectChangesEnabled = value; }
        }

        public ObjectContext ObjectContext
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }

        public void RegisterValidation(Type entityType, Func<DbEntityEntry, System.Data.Entity.DbContext, DbEntityValidationResult> validation)
        {
            if (_validations.ContainsKey(entityType))
            {
                // replace existing
                _validations[entityType] = validation;
            }
            else
            {
                _validations.Add(entityType, validation);
            }
        }

        public override int SaveChanges()
        {
            // Prevent entities from being unintentionally added
            // if an entity has state added but already has an ID, it was probably added through an object graph
            var unintentionallyAddedEntities = ChangeTracker
                                               .Entries<IAutoIdentityEntity<int>>()
                                               .Where(x => x.State == EntityState.Added &&
                                                           x.Entity.AutoIdentityID > 0);
            foreach (var unintentionallyAddedEntity in unintentionallyAddedEntities)
            {
                unintentionallyAddedEntity.State = EntityState.Unchanged;
            }

            //// Prevent entities from being unintentionally added
            //// if an entity has state added but already has an ID, it was probably added through an object graph
            //var unchangedEntities = ChangeTracker
            //                        .Entries<IAutoIdentityEntity<int>>()
            //                        .Where(x => x.State == EntityState.Unchanged).
            //                        ToList();
            //foreach (var unchangedEntity in unchangedEntities)
            //{
            //    unchangedEntity.State = EntityState.Detached;
            //}

            // Audit Logging
            var authenticatedUser = GetAuthenticatedUser();
            var now = DateTime.Now;

            // HistoryVersion - remove when triggers are replaced with EF
            InsertHistoryVersionIfNecessary(authenticatedUser);

            // INSERT
            var addedEntities = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Added);
            foreach (var auditableEntity in addedEntities.Select(addedEntity => addedEntity.Entity))
            {
                auditableEntity.Created = now;
                auditableEntity.Creator = authenticatedUser;
                auditableEntity.Modified = now;
                auditableEntity.Modifier = authenticatedUser;
            }
            
            // UPDATE
            var modifiedEntities = ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Modified);
            foreach (var auditableEntity in modifiedEntities.Select(addedEntity => addedEntity.Entity))
            {
                auditableEntity.Modified = now;
                auditableEntity.Modifier = authenticatedUser;
            }

            return base.SaveChanges();
        }


        public void ValidateUnchangedEntities()
        {
            //Check Unchanged entity
            var unchangedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Unchanged);
            IList<DbEntityValidationResult> results = new List<DbEntityValidationResult>();

            foreach (var auditableEntity in unchangedEntities)
            {
                results.Add(ValidateEntity(auditableEntity, new Dictionary<object, object>()));
            }

            if (results.Any(r => !r.IsValid))
            {
                throw new DbEntityValidationException("Fehler", results.ToArray());
            }
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }


        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var results = base.ValidateEntity(entityEntry, items);
            var type = entityEntry.Entity.GetType();
            Func<DbEntityEntry, System.Data.Entity.DbContext, DbEntityValidationResult> validation;
            if (_validations.TryGetValue(type, out validation))
            {
                var customResults = validation(entityEntry, this);
                foreach (var customValidationError in customResults.ValidationErrors)
                {
                    results.ValidationErrors.Add(customValidationError);
                }
            }
            return results;
        }

        private static string GetAuthenticatedUser()
        {
            var sessionService = Container.Resolve<ISessionService>();
            return sessionService.AuthenticatedUser.CreatorModifier;
        }

        private void InsertHistoryVersionIfNecessary(string authenticatedUser)
        {
            var historyVersionNecessary = ChangeTracker.Entries()
                                                       .Any(ent => (ent.State == EntityState.Added || ent.State == EntityState.Modified)
                                                                   && _tablesWithTriggers.Contains(ent.Entity.GetType())) &&
                                          !ChangeTracker.Entries<HistoryVersion>().Any(hiv => hiv.State == EntityState.Added);
            if (historyVersionNecessary)
            {
                // it is not possible to ensure that HistoryVersion is inserted first, so a separate Context is necessary
                using (var context = new KissContext(NameOrConnectionString))
                {
                    context.Configuration.ValidateOnSaveEnabled = false;
                    var historyVersion = new HistoryVersion
                                             {
                                                 AppUser = authenticatedUser,
                                                 VersionDate = DateTime.Now
                                             };
                    context.HistoryVersion.Add(historyVersion);
                    context.SaveChanges();
                }
            }
        }
    }
}