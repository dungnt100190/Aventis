using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public class PropertyConfiguration<T>
    {
        private readonly List<Action<PropertyBuilder<T>>> _actions = new List<Action<PropertyBuilder<T>>>();
        private readonly List<Action<EntityTypeBuilder>> _entityActions = new List<Action<EntityTypeBuilder>>();
        private readonly string _propertyName;

        public PropertyConfiguration(string propertyName)
        {
            _propertyName = propertyName;
        }

        public PropertyConfiguration<T> HasColumnAnnotation(string name, object value)
        {
            _actions.Add(p => p.HasAnnotation(name, value));
            return this;
        }

        public PropertyConfiguration<T> HasColumnName(string name)
        {
            _actions.Add(p => p.HasColumnName(name));
            return this;
        }

        public PropertyConfiguration<T> HasMaxLength(int maxLength)
        {
            _actions.Add(p => p.HasMaxLength(maxLength));
            return this;
        }

        public PropertyConfiguration<T> IsConcurrencyToken()
        {
            _actions.Add(p => p.IsConcurrencyToken());
            return this;
        }

        public PropertyConfiguration<T> IsOptional()
        {
            _actions.Add(p => p.IsRequired(false));
            return this;
        }

        public PropertyConfiguration<T> IsRequired()
        {
            _actions.Add(p => p.IsRequired());
            return this;
        }

        /// <summary>
        /// Adds a unique index to this column
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public PropertyConfiguration<T> IsUnique(string indexName)
        {
            _entityActions.Add(b => b.HasIndex($"IX_{_propertyName}"));
            return this;
        }

        public PropertyConfiguration<T> ValueGeneratedNever()
        {
            _actions.Add(p => p.ValueGeneratedNever());
            return this;
        }

        internal void Apply(PropertyBuilder<T> propertyBuilder)
        {
            foreach (var act in _actions)
            {
                act(propertyBuilder);
            }
        }

        internal void Apply<TEntity>(PropertyBuilder<T> propertyBuilder, EntityTypeBuilder<TEntity> entityBuilder)
            where TEntity : class
        {
            foreach (var act in _actions)
            {
                act(propertyBuilder);
            }
            foreach (var act in _entityActions)
            {
                act(entityBuilder);
            }
        }
    }
}