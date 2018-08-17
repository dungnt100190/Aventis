using System;
using System.Collections.ObjectModel;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL
{
    /// <summary>
    /// Copied from http://blogs.msdn.com/b/stuartleeks/archive/2009/04/24/improving-objectquery-t-include-updated.aspx and slightly enhanced
    /// </summary>
    public static class ObjectQueryExtensions
    {
        #region Fields

        #region Private Static Fields

        private static readonly MethodInfo[] _subIncludeMethods;

        #endregion

        #endregion

        #region Constructors

        static ObjectQueryExtensions()
        {
            Type type = typeof(ObjectQueryExtensions);
            _subIncludeMethods = type.GetMethods().Where(mi => mi.Name == "SubInclude").ToArray();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static IQueryable<TSource> Include<TSource, TPropType>(this IQueryable<TSource> source, Expression<Func<TSource, TPropType>> propertySelector)
        {
            if (source is ObjectQuery<TSource>)
            {
                string includeString = BuildString(propertySelector);
                return (source as ObjectQuery<TSource>).Include(includeString);
            }

            return source;
        }

        public static IQueryable<TSource> Include<TSource, TPropType>(this IRepository<TSource> source, Expression<Func<TSource, TPropType>> propertySelector)
            where TSource : class, IObjectWithChangeTracker
        {
            if (source is ObjectQuery<TSource>)
            {
                string includeString = BuildString(propertySelector);
                return (source as ObjectQuery<TSource>).Include(includeString);
            }

            if (source.ObjectSet is ObjectQuery<TSource>)
            {
                string includeString = BuildString(propertySelector);
                return ((ObjectQuery<TSource>)source.ObjectSet).Include(includeString);
            }

            return source;
        }

        public static TPropType SubInclude<TSource, TPropType>(this ObservableCollection<TSource> source, Expression<Func<TSource, TPropType>> propertySelector)
            where TSource : class
            where TPropType : class
        {
            throw new InvalidOperationException("This method is only intended for use with ObjectQueryExtensions.Include to generate expressions trees"); // no actually using this - just want the expression!
        }

        public static TPropType SubInclude<TSource, TPropType>(this TSource source, Expression<Func<TSource, TPropType>> propertySelector)
            where TSource : class
            where TPropType : class
        {
            throw new InvalidOperationException("This method is only intended for use with ObjectQueryExtensions.Include to generate expressions trees"); // no actually using this - just want the expression!
        }

        #endregion

        #region Private Static Methods

        private static string BuildString(Expression propertySelector)
        {
            switch (propertySelector.NodeType)
            {
                case ExpressionType.Lambda:
                    LambdaExpression lambdaExpression = (LambdaExpression)propertySelector;
                    return BuildString(lambdaExpression.Body);

                case ExpressionType.Quote:
                    UnaryExpression unaryExpression = (UnaryExpression)propertySelector;
                    return BuildString(unaryExpression.Operand);

                case ExpressionType.MemberAccess:

                    MemberExpression memberExpression = (MemberExpression)propertySelector;
                    MemberInfo propertyInfo = memberExpression.Member;

                    if (memberExpression.Expression is ParameterExpression)
                    {
                        return propertyInfo.Name;
                    }

                    // we've got a nested property (e.g. MyType.SomeProperty.SomeNestedProperty)
                    return BuildString(memberExpression.Expression) + "." + propertyInfo.Name;

                case ExpressionType.Call:
                    MethodCallExpression methodCallExpression = (MethodCallExpression)propertySelector;
                    if (IsSubInclude(methodCallExpression.Method)) // check that it's a SubInclude call
                    {
                        // argument 0 is the expression to which the SubInclude is applied (this could be member access or another SubInclude)
                        // argument 1 is the expression to apply to get the included property
                        // Pass both to BuildString to get the full expression
                        return BuildString(methodCallExpression.Arguments[0]) + "." +
                               BuildString(methodCallExpression.Arguments[1]);
                    }
                    // else drop out and throw
                    break;
            }
            throw new InvalidOperationException("Expression must be a member expression or an SubInclude call: " + propertySelector);
        }

        private static bool IsSubInclude(MethodInfo methodInfo)
        {
            if (methodInfo.IsGenericMethod)
            {
                if (!methodInfo.IsGenericMethodDefinition)
                {
                    methodInfo = methodInfo.GetGenericMethodDefinition();
                }
            }
            return _subIncludeMethods.Contains(methodInfo);
        }

        #endregion

        #endregion
    }
}