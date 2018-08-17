using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using Kiss.DataAccess.Interfaces;
using Kiss.DataAccess.Properties;
using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess
{
    public class Repository<T> : IRepository<T>, IRepository
        where T : class, IAutoIdentityEntity<int>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly IDbContext _dbContext;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new Repository
        /// </summary>
        ///// <remarks>restricted to internal so it is not possible for consumers to directly create a Repository.
        ///// It must not be possible to circumvent rules in a derived Repository</remarks>
        /// <param name="dbContext"></param>
        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }

        // nur für UnitTesting
        protected Repository()
        {
        }

        #endregion

        #region Properties

        protected IDbContext DbContext
        {
            get { return _dbContext; }
        }

        protected IDbSet<T> DbSet
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public virtual T[] GetAllEntities()
        {
            return DbSet.ToArray();
        }

        public virtual T GetById(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual void InsertOrUpdateEntitiesWithoutCheckIfChanged(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                return;
            }

            var detectChangesBefore = _dbContext.AutoDetectChangesEnabled;
            _dbContext.AutoDetectChangesEnabled = false;

            try
            {
                foreach (var entity in entities)
                {
                    DbSet.Attach(entity);

                    var entry = _dbContext.Entry(entity);
                    entry.State = entity.AutoIdentityID == 0 ? EntityState.Added : EntityState.Modified;
                }
            }
            finally
            {
                _dbContext.AutoDetectChangesEnabled = detectChangesBefore;
            }
        }

        public virtual EntityState InsertOrUpdateEntity(T entity)
        {
            if (entity == null)
            {
                return EntityState.Unchanged;
            }

            // Add entity to context
            DbSet.Attach(entity);

            var entry = _dbContext.Entry(entity);
            if (entity.AutoIdentityID == 0) // implizites Feststellen: Solange die Entität noch nicht in der DB ist, ist die ID 0
            {
                // new entity, INSERT
                entry.State = EntityState.Added;
            }
            else
            {
                var dbValues = entry.GetDatabaseValues();
                if (dbValues == null)
                {
                    // Entity wurde in der Zwischenzeit von einem anderen User (oder Context) gelöscht worden
                    throw new DbUpdateException(Resources.DeletedAlreadyFromAnotherUser);
                }

                // existing entity, UPDATE
                entry.State = EntityState.Unchanged;

                // check concurrency - if there is a rowversion column
                var rowversionPropertyName = ConstructRowversionPropertyNameByConvention(entity.GetType());
                if (dbValues.PropertyNames.FirstOrDefault(x => x == rowversionPropertyName) != null)
                {
                    var dbRV = (byte[])dbValues[rowversionPropertyName];
                    var entityRV = (byte[])entry.CurrentValues[rowversionPropertyName];
                    if (HasRowversionChanged(entityRV, dbRV))
                    {
                        // Error handling
                        throw new DBConcurrencyException(Resources.ChangedSinceLoadedFromDB);
                    }
                }

                // check with dbValues if modified or unchanged (DbContext sets state)
                //entry.OriginalValues.SetValues(dbValues); // does not work due to a bug in .NET 4.0. use this line when upgrade to .NET 4.5 is done
                if (entry.CurrentValues.PropertyNames.Any(prn => !Equals(entry.CurrentValues[prn], dbValues[prn]) && prn != rowversionPropertyName))
                {
                    entry.State = EntityState.Modified;
                }

                // long version to debug
                //foreach (var propertyName in entry.CurrentValues.PropertyNames)
                //{
                //    var current = entry.CurrentValues[propertyName];
                //    var db = dbValues[propertyName];
                //    if (!Equals(current, db) && propertyName != rowversionPropertyName)
                //    {
                //        entry.State = EntityState.Modified;
                //        break;

                //    }
                //}
            }

            return entry.State;
        }

        IEnumerable IRepository.GetAllEntities()
        {
            return GetAllEntities();
        }

        object IRepository.GetById(params object[] keys)
        {
            return GetById(keys);
        }

        EntityState IRepository.InsertOrUpdateEntity(object entity)
        {
            return InsertOrUpdateEntity(entity as T);
        }

        //object IRepository.Remove(params object[] keyValues)
        //{
        //    return Remove(keyValues);
        //}

        object IRepository.Remove(object entity)
        {
            return Remove(entity as T);
        }

        //public virtual T Remove(params object[] keyValues)
        //{
        //    var entityToDelete = DbSet.Find(keyValues);
        //    return RemoveExistingEntity(entityToDelete);
        //}

        public virtual T Remove(T entityToDelete)
        {
            // make sure the entity is in the context
            entityToDelete = DbSet.Find(entityToDelete.AutoIdentityID);

            CheckIfDbIsStillConsistentAfterDelete(entityToDelete);
            return entityToDelete != null ? DbSet.Remove(entityToDelete) : null;
        }

        protected void AddNewDependendEntities<TDependendEntity>(IEnumerable<TDependendEntity> entities)
            where TDependendEntity : class, IAutoIdentityEntity<int>
        {
            foreach (var entity in entities.Where(pos => pos.AutoIdentityID == 0))
            {
                DbContext.Entry(entity).State = EntityState.Added;
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void CheckIfDbIsStillConsistentAfterDelete(T entityToDelete)
        {
            // nop
        }

        protected void RegisterValidator(ValidatorBase<T> validator)
        {
            _dbContext.RegisterValidation(typeof(T), validator.ValidateEntity);
        }

        //protected virtual T RemoveExistingEntity(T entity)
        //{
        //    CheckIfDbIsStillConsistentAfterDelete(entity);
        //    return DbSet.Remove(entity);
        //}

        #endregion

        #region Private Static Methods

        private static long RowVersionToNumber(byte[] rowVersion)
        {
            long number = 0;
            const int byteSize = Byte.MaxValue + 1;
            for (var i = 0; i < rowVersion.Length; i++)
            {
                number += rowVersion[rowVersion.Length - 1 - i] * (long)Math.Pow(byteSize, i);
            }

            return number;
        }

        #endregion

        #region Private Methods

        private string ConstructRowversionPropertyNameByConvention(Type type)
        {
            return String.Format("{0}TS", type.Name);
        }

        private bool HasRowversionChanged(byte[] before, byte[] after)
        {
            if (before.Length != 8 || after.Length != 8)
            {
                throw new Exception(Resources.RowVersionMust8ByteArray);
            }

            return RowVersionToNumber(after) != RowVersionToNumber(before);
        }

        #endregion

        #endregion
    }
}