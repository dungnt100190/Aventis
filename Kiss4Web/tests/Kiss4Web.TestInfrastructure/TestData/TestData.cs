using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.TestInfrastructure.TestData
{
    public class TestData<TEntity> : ITestData
        where TEntity : class, IEntity, new()
    {
        protected readonly IList<TEntity> EntitiesToInsert = new List<TEntity>();
        private List<TEntity> _testEntities;
        protected Func<TEntity, Expression<Func<TEntity, bool>>> IsSameEntity { get; set; }

        public async Task InsertTestData(IDbContext context)
        {
            var repository = new Repository<TEntity>(context);

            var autoDetectEntities = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                                              .Where(prp => prp.FieldType == typeof(TEntity))
                                              .Select(prp => prp.GetValue(this))
                                              .OfType<TEntity>();
            _testEntities = EntitiesToInsert.Concat(autoDetectEntities).ToList();

            foreach (var entity in _testEntities)
            {
                if (IsSameEntity != null)
                {
                    var existingEntity = await repository.FirstOrDefaultAsync(IsSameEntity(entity));
                    if (existingEntity != null)
                    {
                        if (CopyProperties(existingEntity, entity))
                        {
                            await repository.InsertOrUpdateEntity(entity);
                        }

                        continue;
                    }

                    ResetAutoIdentity(entity);
                }

                await repository.InsertOrUpdateEntity(entity);
            }
        }

        protected virtual void ResetAutoIdentity(TEntity entity)
        {
        }

        protected virtual bool CopyProperties(TEntity existingEntity, TEntity testDataEntity)
        {
            return false;
        }

        public void RemoveTestData(IDbContext context)
        {
            if (_testEntities == null)
            {
                return;
            }
            var repository = new Repository<TEntity>(context);
            foreach (var entity in _testEntities.Where(ent => ent != null))
            {
                repository.Remove(entity);
            }
        }
    }
}