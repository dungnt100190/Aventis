using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;

using FluentValidation;
using FluentValidation.Results;

using Kiss.DataAccess.LocalResources;
using Kiss.DataAccess.Properties;

namespace Kiss.DataAccess.Validation
{
    /// <summary>
    /// Base class to validate an entity. The Properties Creator, Created, Modifier and Modified are currently checked if they exists on the Entity.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ValidatorBase<TEntity> : AbstractValidator<TEntity>
        where TEntity : class
    {
        #region Constructors

        protected internal ValidatorBase()
        {
            Custom(CheckSqlTypeOverflow);
            //Custom(t => CheckPropertyNotNullOrEmpty<string>(t, Constant.CREATOR));
            //Custom(t => CheckPropertyNotNullOrEmpty<DateTime>(t, Constant.CREATED));
            //Custom(t => CheckPropertyNotNullOrEmpty<string>(t, Constant.MODIFIER));
            //Custom(t => CheckPropertyNotNullOrEmpty<DateTime>(t, Constant.MODIFIED));
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Validates an entity.
        /// </summary>
        /// <param name="entityEntry">The entity to validate</param>
        /// <param name="context"> </param>
        /// <returns></returns>
        public DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, System.Data.Entity.DbContext context)
        {
            var result = Validate(entityEntry.Entity as TEntity);
            var errors = ConvertErrors(result.Errors).ToList();
            var resultDB = ValidateOnDB(entityEntry.Cast<TEntity>(), context);
            if (resultDB != null)
            {
                errors.AddRange(resultDB);
            }

            return new DbEntityValidationResult(entityEntry, errors);
        }

        /// <summary>
        /// This method can be overloaded to dynamically (e.g. with accessing the DB inside the transaction) validate the entity
        /// This method gets automatically called from within base.SaveEntity() before the Entity gets updated in the DB
        /// => If this method returns KissServiceResult.Ok, then base.SaveEntity() will continue the update
        /// </summary>
        /// <param name="entityEntry"> </param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual IEnumerable<DbValidationError> ValidateOnDB(DbEntityEntry<TEntity> entityEntry, System.Data.Entity.DbContext context)
        {
            return null;
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
                    var failure = CheckTypesOverflow<int, int>(propertyInfo, entity, (int)SqlInt32.MinValue, (int)SqlInt32.MaxValue, Convert.ToInt32, Resources.Range_Int);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(int?))
                {
                    var failure = CheckTypesOverflow<int?, int>(propertyInfo, entity, (int)SqlInt32.MinValue, (int)SqlInt32.MaxValue, Convert.ToInt32, Resources.Range_Int);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(decimal))
                {
                    var failure = CheckTypesOverflow<decimal, decimal>(propertyInfo, entity, (decimal)SqlMoney.MinValue, (decimal)SqlMoney.MaxValue, Convert.ToDecimal, Resources.Range_Decimal);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(decimal?))
                {
                    var failure = CheckTypesOverflow<decimal?, decimal>(propertyInfo, entity, (decimal)SqlMoney.MinValue, (decimal)SqlMoney.MaxValue, Convert.ToDecimal, Resources.Range_Decimal);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    var failure = CheckTypesOverflow<DateTime, DateTime>(propertyInfo, entity, (DateTime)SqlDateTime.MinValue, (DateTime)SqlDateTime.MaxValue, Convert.ToDateTime, Resources.Range_DateTime);
                    if (failure != null)
                    {
                        return failure;
                    }
                }

                if (propertyInfo.PropertyType == typeof(DateTime?))
                {
                    var failure = CheckTypesOverflow<DateTime?, DateTime>(propertyInfo, entity, (DateTime)SqlDateTime.MinValue, (DateTime)SqlDateTime.MaxValue, Convert.ToDateTime, Resources.Range_DateTime);
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
            Func<object, TCompare> convert,
            string typeErrorText)
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
                return new ValidationFailure(propertyName, string.Format(Resources.ErrorPropertyValueNotInRange, typeErrorText));
            }

            return null;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts Fluent Validation Errors to EF Errors
        /// </summary>
        /// <param name="errors">Fluent Validation Errors</param>
        /// <returns>EF Errors</returns>
        private IEnumerable<DbValidationError> ConvertErrors(IEnumerable<ValidationFailure> errors)
        {
            return errors.Select(err => new DbValidationError(err.PropertyName, err.ErrorMessage));
        }

        #endregion

        #endregion
    }
}