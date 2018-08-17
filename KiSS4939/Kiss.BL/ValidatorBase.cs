using System;
using System.Data.SqlTypes;
using System.Reflection;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;

using FluentValidation;
using FluentValidation.Results;

namespace Kiss.BL
{
    /// <summary>
    /// Base class to validate an entity. The Properties Creator, Created, Modifier and Modified are currently checked if they exists on the Entity.
    /// </summary>
    /// <typeparam name="TValidator"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class ValidatorBase<TEntity, TValidator> : AbstractValidator<TEntity>
        where TValidator : AbstractValidator<TEntity>, new()
    {
        #region Fields

        #region Protected Static Fields

        protected static TValidator _instance;

        #endregion

        #endregion

        #region Constructors

        static ValidatorBase()
        {
            _instance = new TValidator();
        }

        protected internal ValidatorBase()
        {
            Custom(CheckSqlTypeOverflow);
            Custom(t => CheckPropertyNotNullOrEmpty<string>(t, Constant.CREATOR));
            Custom(t => CheckPropertyNotNullOrEmpty<DateTime>(t, Constant.CREATED));
            Custom(t => CheckPropertyNotNullOrEmpty<string>(t, Constant.MODIFIER));
            Custom(t => CheckPropertyNotNullOrEmpty<DateTime>(t, Constant.MODIFIED));
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Validates an entity.
        /// </summary>
        /// <remarks>
        /// The field <see cref="_instance"/> has to be initialized before calling this.
        /// </remarks>
        /// <param name="entity">The entity to validate.</param>
        /// <returns></returns>
        public static KissServiceResult ValidateEntity(TEntity entity)
        {
            if (_instance == null)
            {
                throw new InvalidOperationException("You have to initialize the _instance field from the subclass!");
            }

            return new KissServiceResult(_instance.Validate(entity));
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Checks whether the Property is null or empty if the given <paramref name="propertyName"/> exists on the <paramref name="entity"/>.
        /// </summary>
        /// <typeparam name="TProperty">The property type</typeparam>
        /// <param name="entity">The entity to check</param>
        /// <param name="propertyName">The property to check</param>
        /// <returns>A <see cref="ValidationFailure"/> as validation result</returns>
        protected ValidationFailure CheckPropertyNotNullOrEmpty<TProperty>(TEntity entity, string propertyName)
        {
            var type = entity.GetType();
            var property = type.GetProperty(propertyName);

            if (property != null)
            {
                var value = property.GetValue(entity, null);

                if (value == null || value.Equals(string.Empty) || value.Equals(default(TProperty)))
                {
                    return new ValidationFailure(propertyName, string.Format("Internal error: Property '{0}' is empty.", propertyName));
                }

                if (type == typeof(DateTime) && (Convert.ToDateTime(value) < SqlDateTime.MinValue || Convert.ToDateTime(value) > SqlDateTime.MaxValue))
                {
                    return new ValidationFailure(propertyName, string.Format("Internal error: Property '{0}' is not in range of SqlDateTime.", propertyName));
                }
            }

            return null;
        }

        protected ValidationFailure CheckSqlTypeOverflow(TEntity entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.PropertyType == typeof(int))
                {
                    var failure = CheckTypesOverflow<int, int>(propertyInfo, entity, (int)SqlInt32.MinValue, (int)SqlInt32.MaxValue, Convert.ToInt32);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(int?))
                {
                    var failure = CheckTypesOverflow<int?, int>(propertyInfo, entity, (int)SqlInt32.MinValue, (int)SqlInt32.MaxValue, Convert.ToInt32);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(decimal))
                {
                    var failure = CheckTypesOverflow<decimal, decimal>(propertyInfo, entity, (decimal)SqlMoney.MinValue, (decimal)SqlMoney.MaxValue, Convert.ToDecimal);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(decimal?))
                {
                    var failure = CheckTypesOverflow<decimal?, decimal>(propertyInfo, entity, (decimal)SqlMoney.MinValue, (decimal)SqlMoney.MaxValue, Convert.ToDecimal);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    var failure = CheckTypesOverflow<DateTime, DateTime>(propertyInfo, entity, (DateTime)SqlDateTime.MinValue, (DateTime)SqlDateTime.MaxValue, Convert.ToDateTime);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(DateTime?))
                {
                    var failure = CheckTypesOverflow<DateTime?, DateTime>(propertyInfo, entity, (DateTime)SqlDateTime.MinValue, (DateTime)SqlDateTime.MaxValue, Convert.ToDateTime);
                    if (failure != null)
                    {
                        return failure;
                    }
                }
            }

            return null;
        }

        protected ValidationFailure CheckTypesOverflow<TProperty, TCompare>(
            PropertyInfo propertyInfo, 
            TEntity entity, 
            TCompare minValue, 
            TCompare maxValue, 
            Func<object, TCompare> convert)
            where TCompare : IComparable<TCompare>
        {
            var value = propertyInfo.GetValue(entity, null);
            if (value == null)
            {
                return null;
            }

            if (!propertyInfo.PropertyType.IsAssignableFrom(typeof(TProperty)))
            {
                var propertyName = propertyInfo.Name;
                return new ValidationFailure(propertyName, string.Format("Internal error: Property '{0}' is not assignable from {1}.", propertyName, typeof(TProperty).Name));
            }

            if ((convert(value).CompareTo(minValue) < 0 || convert(value).CompareTo(maxValue) > 0))
            {
                var propertyName = propertyInfo.Name;
                return new ValidationFailure(propertyName, string.Format("'{0}' ist nicht in gültigem Bereich.", propertyName));
            }

            return null;
        }

        #endregion

        #endregion
    }
}