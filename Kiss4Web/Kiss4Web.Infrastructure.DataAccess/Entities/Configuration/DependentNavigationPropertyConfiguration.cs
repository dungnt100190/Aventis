using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public class DependentNavigationPropertyConfiguration<TPrincipalEntity, TDependentEntity>
        where TPrincipalEntity : class
        where TDependentEntity : class
    {
        private readonly List<Action<ReferenceCollectionBuilder<TPrincipalEntity, TDependentEntity>>> _actions = new List<Action<ReferenceCollectionBuilder<TPrincipalEntity, TDependentEntity>>>();

        internal void Apply(ReferenceCollectionBuilder<TPrincipalEntity, TDependentEntity> builder)
        {
            foreach (var a in _actions)
            {
                a(builder);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="foreignKeyExpression"></param>
        /// <returns></returns>
        public DependentNavigationPropertyConfiguration<TPrincipalEntity, TDependentEntity> HasForeignKey(Expression<Func<TDependentEntity, object>> foreignKeyExpression)
        {
            _actions.Add(p =>
            {
                var builder = p.HasForeignKey(foreignKeyExpression);
            });

            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="principalKeyExpression"></param>
        /// <returns></returns>
        public DependentNavigationPropertyConfiguration<TPrincipalEntity, TDependentEntity> HasPrincipalKey(Expression<Func<TPrincipalEntity, object>> principalKeyExpression)
        {
            _actions.Add(p =>
            {
                var builder = p.HasPrincipalKey(principalKeyExpression);
            });

            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public DependentNavigationPropertyConfiguration<TPrincipalEntity, TDependentEntity> IsRequired()
        {
            _actions.Add(p =>
            {
                var builder = p.IsRequired();
            });

            return this;
        }
    }
}