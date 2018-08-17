using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Kiss.Infrastructure
{
    public static class PropertyName
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets a specified property using a lambda expression.
        /// An instance of the enclosing type is required.
        /// </summary>
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T>> exp)
        {
            var memberExpression = exp.Body as MemberExpression;

            if (memberExpression != null)
            {
                return memberExpression.Member as PropertyInfo;
            }

            return null;
        }

        /// <summary>
        /// Gets a specified property using a lambda expression.
        /// An instance of the enclosing type is NOT required.
        /// </summary>
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> exp)
        {
            var memberExpression = exp.Body as MemberExpression;

            if (memberExpression != null)
            {
                return memberExpression.Member as PropertyInfo;
            }

            var unaryExpression = exp.Body as UnaryExpression;

            if (unaryExpression != null)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;

                if (memberExpression != null)
                {
                    return memberExpression.Member as PropertyInfo;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the name of a specified property using a lambda expression.
        /// An instance of the enclosing type is required.
        /// </summary>
        public static string GetPropertyName<T>(Expression<Func<T>> exp)
        {
            var propertyInfo = GetPropertyInfo(exp);
            return propertyInfo != null ? propertyInfo.Name : null;
        }

        /// <summary>
        /// Gets the name of a specified property using a lambda expression.
        /// An instance of the enclosing type is NOT required.
        /// </summary>
        public static string GetPropertyName<T>(Expression<Func<T, object>> exp)
        {
            var propertyInfo = GetPropertyInfo(exp);
            return propertyInfo != null ? propertyInfo.Name : null;
        }

        #endregion

        #endregion
    }
}