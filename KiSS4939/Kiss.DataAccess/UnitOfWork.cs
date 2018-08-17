using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        #region Private Static Fields

        private static readonly Type[] RepositoryTypes;

        #endregion

        #region Private Constant/Read-Only Fields

        protected readonly IDbContext _context;
        private readonly IDictionary<Type, object> _createdRepositories = new Dictionary<Type, object>();

        #endregion

        #endregion

        #region Constructors

        static UnitOfWork()
        {
            var assembly = Assembly.GetExecutingAssembly();
            RepositoryTypes = assembly.GetTypes().Where(typ => typ.GetInterfaces().Contains(typeof(IRepository))).ToArray();
        }

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _context.Dispose();
        }

        #endregion

        #region Methods

        #region Public Methods

        // ToDo: outsource in repositoryfactory/cache (srp)?
        public IRepository<T> Repository<T>()
            where T : class
        {
            return (IRepository<T>)Repository(typeof(T));
        }

        public IRepository Repository(Type entityType)
        {
            var repository = GetExistingRepository(entityType);
            if (repository == null)
            {
                // search for specialized repository and construct it
                var types = from type in RepositoryTypes
                            where type.BaseType == typeof(Repository<>).MakeGenericType(entityType)
                            select type.GetConstructor(new[] { typeof(IDbContext) });
                var repositoryTypeConstructor = types.SingleOrDefault() ?? typeof(Repository<>).MakeGenericType(entityType).GetConstructor(new[] { typeof(IDbContext) });
                if (repositoryTypeConstructor != null)
                {
                    repository = (IRepository)repositoryTypeConstructor.Invoke(new[] { (object)_context });
                }
                else
                {
                    throw new SystemException(string.Format("Creation of Repository<{0}> failed, type or constructor not found", entityType.FullName));
                }
                _createdRepositories[entityType] = repository;
            }
            return repository;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        public virtual void ValidateUnChangedEntities()
        {
            _context.ValidateUnchangedEntities();
        }


        #endregion

        #region Private Methods

        private IRepository GetExistingRepository(Type entityType)
        {
            object existingRepository;
            if (_createdRepositories.TryGetValue(entityType, out existingRepository))
            {
                return (IRepository)existingRepository;
            }
            return null;
        }

        #endregion

        #endregion
    }
}