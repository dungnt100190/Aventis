using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    /// <summary>
    /// Base class to simplify EF Core entity configurations
    /// </summary>
    /// <see href="https://github.com/rorymurphy/EntityFramework/tree/feature/entitytypeconfiguration/src/Microsoft.EntityFrameworkCore.Design"/>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration
        where TEntity : class
    {
        private readonly List<Action<EntityTypeBuilder<TEntity>>> _actions = new List<Action<EntityTypeBuilder<TEntity>>>();

        public void BuildModel(ModelBuilder builder)
        {
            Apply(builder.Entity<TEntity>());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        internal virtual void Apply(EntityTypeBuilder<TEntity> builder)
        {
            foreach (var a in _actions)
            {
                a(builder);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        protected KeyConfiguration HasAlternateKey(params string[] propertyNames)
        {
            var keyConfig = new KeyConfiguration();
            _actions.Add(b =>
            {
                var builder = b.HasAlternateKey(propertyNames);
                keyConfig.Apply(builder);
            });
            return keyConfig;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="annotation"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected EntityTypeConfiguration<TEntity> HasAnnotation(string annotation, object value)
        {
            _actions.Add(b => b.HasAnnotation(annotation, value));
            return this;
        }

        protected IndexConfiguration HasIndex(params string[] propertyNames)
        {
            var indexConfiguration = new IndexConfiguration();
            _actions.Add(b =>
            {
                var i = b.HasIndex(propertyNames);
                indexConfiguration.Apply(i);
            });
            return indexConfiguration;
        }

        protected IndexConfiguration HasIndex(Expression<Func<TEntity, object>> indexExpression)
        {
            var indexConfiguration = new IndexConfiguration();
            _actions.Add(b =>
            {
                var i = b.HasIndex(indexExpression);
                indexConfiguration.Apply(i);
            });
            return indexConfiguration;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        protected EntityTypeConfiguration<TEntity> HasKey(Expression<Func<TEntity, object>> selector)
        {
            var keyConfig = new KeyConfiguration();
            _actions.Add(b =>
            {
                var keyBuilder = b.HasKey(selector);
                keyConfig.Apply(keyBuilder);
            });
            return this;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TTargetEntity"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        protected ManyNavigationPropertyConfiguration<TEntity, TTargetEntity> HasMany<TTargetEntity>(Expression<Func<TEntity, IEnumerable<TTargetEntity>>> selector)
            where TTargetEntity : class
        {
            var config = new ManyNavigationPropertyConfiguration<TEntity, TTargetEntity>();

            _actions.Add(b =>
            {
                var builder = b.HasMany(selector);
                config.Apply(builder);
            });

            return config;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TTargetEntity"></typeparam>
        /// <param name="navigationPropertyExpression"></param>
        /// <returns></returns>
        protected ReferenceNavigationConfiguration<TEntity, TTargetEntity> HasOne<TTargetEntity>(Expression<Func<TEntity, TTargetEntity>> navigationPropertyExpression)
            where TTargetEntity : class
        {
            var config = new ReferenceNavigationConfiguration<TEntity, TTargetEntity>();
            _actions.Add(b =>
            {
                var builder = b.HasOne(navigationPropertyExpression);
                config.Apply(builder);
            });

            return config;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="selector"></param>
        protected void Ignore(Expression<Func<TEntity, object>> selector)
        {
            _actions.Add(b =>
            {
                b.Ignore(selector);
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        protected PropertyConfiguration<T> Property<T>(Expression<Func<TEntity, T>> selector)
        {
            var pConfig = new PropertyConfiguration<T>(selector.Name);
            _actions.Add(b =>
            {
                var p = b.Property(selector);
                pConfig.Apply(p, b);
            });
            return pConfig;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //protected PropertyConfiguration<T> Property<T>(string name)
        //{
        //    PropertyConfiguration<T> pConfig = new PropertyConfiguration<T>();
        //    _actions.Add(b =>
        //    {
        //        var p = b.Property<T>(name);
        //        pConfig.Apply(p);
        //    });
        //    return pConfig;
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        protected void ToTable(string name)
        {
            _actions.Add(b => b.ToTable(name));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="schema"></param>
        protected void ToTable(string name, string schema)
        {
            _actions.Add(b => b.ToTable(name, schema));
        }
    }
}