using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class DbSeed : IDisposable
    {
        private static readonly Type[] _assemblyTypes;

        private readonly IDictionary<Type, List<IPocoEntity>> _createdEntities = new Dictionary<Type, List<IPocoEntity>>();
        private readonly IDictionary<Type, object> _dbSeeder = new Dictionary<Type, object>();

        private readonly Func<UnitOfWork> _unitOfWorkFactory;

        static DbSeed()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _assemblyTypes = assembly.GetTypes();
        }

        public DbSeed(Func<UnitOfWork> unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Add(IPocoEntity createdEntity)
        {
            Contract.Requires(createdEntity != null);
            if (createdEntity == null)
            {
                return;
            }
            var type = createdEntity.GetType();
            var list = GetOrCreateTypeList(type);
            list.Add(createdEntity);
        }

        public T CreateEntity<T>()
            where T : IPocoEntity
        {
            var seeder = GetOrCreateSeeder<T>();
            return seeder.CreateEntity();
        }

        public void CreateSeed()
        {
            using (var unitOfWork = _unitOfWorkFactory.Invoke())
            {
                foreach (var createdEntityOfType in _createdEntities)
                {
                    var entityType = createdEntityOfType.Key;
                    var repository = unitOfWork.Repository(entityType);
                    createdEntityOfType.Value.ForEach(entity => repository.InsertOrUpdateEntity(entity));
                }
                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // to debug

                    throw;
                }
            }
        }

        public void DeleteCreatedEntities()
        {
            using (var unitOfWork = _unitOfWorkFactory.Invoke())
            {
                foreach (var createdEntityOfType in _createdEntities)
                {
                    var entityType = createdEntityOfType.Key;
                    var repository = unitOfWork.Repository(entityType);
                    createdEntityOfType.Value.ForEach(entity => repository.Remove(entity));
                }
                unitOfWork.SaveChanges();
            }
            _createdEntities.Clear();
        }

        public void Dispose()
        {
            DeleteCreatedEntities();
        }

        public T GetOrCreateEntity<T>()
            where T : IPocoEntity
        {
            var list = GetOrCreateTypeList(typeof(T));
            if (list.Any())
            {
                return (T)list[0];
            }

            return CreateEntity<T>();
        }

        // ToDo: outsource in repositoryfactory/cache (srp)?
        public DbSeeder<T> GetOrCreateSeeder<T>()
            where T : IPocoEntity
        {
            var seeder = GetExistingSeeder<T>();
            if (seeder == null)
            {
                // search for specialized repository and construct it
                var types = from type in _assemblyTypes
                            where type.BaseType == typeof(DbSeeder<T>)
                            select type.GetConstructor(new[] { typeof(DbSeed) });
                var repositoryTypeConstructor = types.SingleOrDefault();
                if (repositoryTypeConstructor != null)
                {
                    seeder = (DbSeeder<T>)repositoryTypeConstructor.Invoke(new[] { (object)this });
                }
                else
                {
                    throw new SystemException(string.Format("no seeder found for type {0}", typeof(T)));
                }
                _dbSeeder[typeof(T)] = seeder;
            }
            return seeder;
        }

        private DbSeeder<T> GetExistingSeeder<T>()
            where T : IPocoEntity
        {
            object existingRepository;
            if (_dbSeeder.TryGetValue(typeof(T), out existingRepository))
            {
                return (DbSeeder<T>)existingRepository;
            }
            return null;
        }

        private List<IPocoEntity> GetOrCreateTypeList(Type type)
        {
            List<IPocoEntity> list;
            if (!_createdEntities.TryGetValue(type, out list))
            {
                list = new List<IPocoEntity>();
                _createdEntities.Add(type, list);
            }
            return list;
        }
    }
}