using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public class ReferenceNavigationConfiguration<TEntityType, TTargetEntity> where TEntityType : class where TTargetEntity : class
    {
        private List<Action<ReferenceNavigationBuilder<TEntityType, TTargetEntity>>> _actions = new List<Action<ReferenceNavigationBuilder<TEntityType, TTargetEntity>>>();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public DependentNavigationPropertyConfiguration<TTargetEntity, TEntityType> WithMany()
        {
            var config = new DependentNavigationPropertyConfiguration<TTargetEntity, TEntityType>();
            _actions.Add(p =>
            {
                var builder = p.WithMany();
                config.Apply(builder);
            });

            return config;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="navigationPropertyExpression"></param>
        /// <returns></returns>
        public DependentNavigationPropertyConfiguration<TTargetEntity, TEntityType> WithMany(Expression<Func<TTargetEntity, IEnumerable<TEntityType>>> navigationPropertyExpression)
        {
            var config = new DependentNavigationPropertyConfiguration<TTargetEntity, TEntityType>();
            _actions.Add(p =>
            {
                var builder = p.WithMany(navigationPropertyExpression);
                config.Apply(builder);
            });

            return config;
        }

        internal void Apply(ReferenceNavigationBuilder<TEntityType, TTargetEntity> builder)
        {
            foreach (var a in _actions)
            {
                a(builder);
            }
        }
    }
}