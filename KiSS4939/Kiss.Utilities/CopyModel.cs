namespace Kiss.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///   Util to copy objeccts
    /// </summary>
    /// <typeparam name = "TResult"></typeparam>
    /// <typeparam name = "T"></typeparam>
    public static class CopyModel<T, TResult>
        where T : class
        where TResult : class
    {
        private static WeakReference<Func<T, Dictionary<object, object>, TResult>> _cache;

        private static WeakReference<Action<T, Dictionary<object, object>, TResult>> _copyCache;

        /// <summary>
        ///   Convert Object to result object
        /// </summary>
        /// <param name = "source"></param>
        /// <param name = "onBaseType"></param>
        /// <returns></returns>
        public static TResult Convert(T source, bool onBaseType)
        {
            if (source == null)
                return null;

            var instances = new Dictionary<object, object>();

            var generateFunc = GetConverterFunc(onBaseType);
            return generateFunc(source, instances);
        }

        /// <summary>
        ///   Convert Object to result object
        /// </summary>
        /// <param name = "source"></param>
        /// <param name = "instances"></param>
        /// <param name = "onBaseType"></param>
        /// <returns></returns>
        public static TResult Convert(T source, Dictionary<object, object> instances, bool onBaseType)
        {
            if (source == null)
                return null;

            if (instances == null)
                instances = new Dictionary<object, object>();
            object value;
            if (instances.TryGetValue(source, out value)) // used to solve cyclic object graph
                return (TResult)value;

            var generateFunc = GetConverterFunc(onBaseType);
            return generateFunc(source, instances);
        }

        /// <summary>
        ///   Convert Object to result object
        /// </summary>
        /// <param name = "source"></param>
        /// <param name = "result"></param>
        /// <returns></returns>
        public static void Convert(T source, TResult result)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (result == null) throw new ArgumentNullException("result");

            var instances = new Dictionary<object, object>();

            var generateAction = GetConverterAction();
            generateAction(source, instances, result);
        }

        /// <summary>
        ///   Returns a T2Collection of T2Item initialized with a collection of T1Item converted
        /// </summary>
        private static TCollection CreateAndInitializeCollection<TCollection>(IEnumerable<T> collectionSource, Func<T, TResult> selector)
            where TCollection : class, ICollection<TResult>, new()
        {
            if (collectionSource == null)
                return null;
            var value = new TCollection();
            foreach (var item in collectionSource.Select(selector))
                value.Add(item);
            return value;
        }

        private static Action<T, Dictionary<object, object>, TResult> GenerateAction()
        {
            var type = typeof(T);
            var sourceParameter = Expression.Parameter(type);
            var instancesParameter = Expression.Parameter(typeof(Dictionary<object, object>));
            var typeResult = typeof(TResult);
            var resultParameter = Expression.Parameter(typeResult);

            // We set every property that we can
            var props = from property in type.GetProperties()
                        let propResult = typeResult.GetProperty(property.Name)
                        where property != null && property.CanRead && propResult != null && (propResult.CanWrite || GetCollectionType(propResult.PropertyType) != null) && !propResult.DeclaringType.IsAbstract
                        select GetSetPropertyExpression(resultParameter, propResult, property, sourceParameter);

            if (props.Count() > 1)
            {
                var blockExpression = Expression.Block(
                    // ReflectionExtension.GetMethod((Dictionary<object, object> d) => d.Add(null, null)) is equivalent to typeof(Dictionary<object, object>).GetMethod("Add")
                    Expression.Call(instancesParameter, ReflectionExtension.GetMethod((Dictionary<object, object> d) => d.Add(string.Empty, string.Empty)), sourceParameter, resultParameter),
                    Expression.Block(props)
                    );

                var expression = Expression.Lambda<Action<T, Dictionary<object, object>, TResult>>(
                    blockExpression,
                    sourceParameter,
                    instancesParameter,
                    resultParameter
                    );
                return expression.Compile();
            }

            return Expression.Lambda<Action<T, Dictionary<object, object>, TResult>>(Expression.Block(), sourceParameter, instancesParameter, resultParameter).Compile();
        }

        private static Func<T, Dictionary<object, object>, TResult> GenerateFunc(bool onBaseType)
        {
            var type = onBaseType ? (typeof(T).BaseType ?? typeof(T)) : typeof(T);
            var sourceParameter = Expression.Parameter(type);
            var instancesParameter = Expression.Parameter(typeof(Dictionary<object, object>));
            var typeResult = typeof(TResult);
            var result = Expression.Parameter(typeResult);

            // We set every property that we can
            var props = from property in type.GetProperties()
                        let propResult = typeResult.GetProperty(property.Name)
                        where property != null && property.CanRead && propResult != null && (propResult.CanWrite || IsCollection(propResult)) && !propResult.DeclaringType.IsAbstract
                        select GetSetPropertyExpression(result, propResult, property, sourceParameter, instancesParameter);

            if (props.Count() > 1)
            {
                var blockExpression = Expression.Block(
                    new[] { result },
                    Expression.Assign(result, Expression.New(typeof(TResult))), // new TOut
                    // Add result in instances dictionary (to solve cyclic object graph)
                    // ReflectionExtension.GetMethod((Dictionary<object, object> d) => d.Add(null, null)) is equivalent to typeof(Dictionary<object, object>).GetMethod("Add")
                    Expression.Call(instancesParameter, ReflectionExtension.GetMethod((Dictionary<object, object> d) => d.Add(string.Empty, string.Empty)), sourceParameter, result),
                    Expression.Block(props),
                    result
                    );
                var expression = Expression.Lambda<Func<T, Dictionary<object, object>, TResult>>(
                    blockExpression,
                    sourceParameter,
                    instancesParameter
                    );
                return expression.Compile();
            }

            return Expression.Lambda<Func<T, Dictionary<object, object>, TResult>>(Expression.Block(), sourceParameter, instancesParameter).Compile();
        }

        private static bool IsCollection(PropertyInfo propResult)
        {
            return propResult.PropertyType != typeof(string) && GetCollectionType(propResult.PropertyType) != null;
        }

        /// <summary>
        ///   Gets collection elements type
        /// </summary>
        /// <param name = "collectionType">The type of the collection</param>
        /// <returns>Collection elements type</returns>
        /// <exception cref = "System.NotImplementedException">Thrown if the collectionType does not implement IEnumerable&lt;T&gt;"/></exception>
        private static Type GetCollectionElementType(Type collectionType)
        {
            var iEnumerableOfTType = GetCollectionType(collectionType);

            if (iEnumerableOfTType == null)
                throw new NotImplementedException();
            return iEnumerableOfTType.GetGenericArguments()[0];
        }

        /// <summary>
        ///   Gets Expression to get TOut property value converted from the TIn collection property
        /// </summary>
        private static Expression GetCollectionProperty(MemberExpression getTInPropertyValueExpression, PropertyInfo setProperty, PropertyInfo getProperty, ParameterExpression instancesParameter)
        {
            // Get initial collection element type
            var tInElementType = GetCollectionElementType(getProperty.PropertyType);
            // Get result collection element type
            var tOutElementType = GetCollectionElementType(setProperty.PropertyType);
            var initialChildParameter = Expression.Parameter(tInElementType);
            // Convert collection and chidren objects
            return Expression.Call(
                null, // Static method
                // Get CreateAndInitializeCollection MethodInfo for related types
                GetGenericCollectionMethod(tInElementType, tOutElementType),
                // collectionSource
                getTInPropertyValueExpression,
                // selector
                Expression.Lambda(
                    Expression.Call(
                        null, // Static method
                        // Get Convert MethodInfo for related types
                        GetConvertMethod(tInElementType, tOutElementType),
                        initialChildParameter,
                        instancesParameter,
                        Expression.Constant(false)
                        ),
                    initialChildParameter
                    )
                );
        }

        private static Type GetCollectionType(Type collectionType)
        {
            if (collectionType.IsGenericType && collectionType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return collectionType;

            var iEnumerableOfTType = collectionType.GetInterfaces().FirstOrDefault(
                interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                );
            return iEnumerableOfTType;
        }

        private static MethodInfo GetConvertMethod(Type inTypeofProperty, Type resultTypeofProperty)
        {
            var makeGenericType = typeof(CopyModel<,>).MakeGenericType(inTypeofProperty, resultTypeofProperty);
            var ret = makeGenericType.
                GetMethod(
                    ReflectionExtension.GetMethod(() => Convert(null, null, false)).Name,
                    BindingFlags.Static | BindingFlags.Public,
                    null,
                    new[] { inTypeofProperty, typeof(Dictionary<object, object>), typeof(bool) },
                    null
                );
            return ret;
        }

        private static Action<T, Dictionary<object, object>, TResult> GetConverterAction()
        {
            Action<T, Dictionary<object, object>, TResult> generateAction = null;

            if (_copyCache != null && _copyCache.IsAlive)
                generateAction = _copyCache.Target;

            if (generateAction == null)
            {
                generateAction = GenerateAction();
                _copyCache = new WeakReference<Action<T, Dictionary<object, object>, TResult>>(generateAction);
            }
            return generateAction;
        }

        private static Func<T, Dictionary<object, object>, TResult> GetConverterFunc(bool onBaseType)
        {
            Func<T, Dictionary<object, object>, TResult> generateFunc = null;

            if (_cache != null && _cache.IsAlive)
                generateFunc = _cache.Target;

            if (generateFunc == null)
            {
                generateFunc = GenerateFunc(onBaseType);
                _cache = new WeakReference<Func<T, Dictionary<object, object>, TResult>>(generateFunc);
            }
            return generateFunc;
        }

        private static MethodInfo GetGenericCollectionMethod(Type tInElementType, Type tOutElementType)
        {
            var makeGenericType = typeof(CopyModel<,>).MakeGenericType(tInElementType, tOutElementType);
            var method = makeGenericType.
                GetMethod(
                    ReflectionExtension.GetMethod(() => CreateAndInitializeCollection<List<TResult>>(new T[0], null)).Name,
                    BindingFlags.Static | BindingFlags.NonPublic,
                    null,
                    new[] { typeof(IEnumerable<>).MakeGenericType(tInElementType), typeof(Func<,>).MakeGenericType(tInElementType, tOutElementType) },
                    null
                );
            return method.MakeGenericMethod(typeof(List<>).MakeGenericType(tOutElementType));
        }

        /// <summary>
        ///   Gets Expression to get TOut property value converted from the TIn instance property
        /// </summary>
        private static Expression GetInstanceProperty(MemberExpression getTInPropertyValueExpression, PropertyInfo setProperty, PropertyInfo getProperty, ParameterExpression instancesParameter)
        {
            // Convert the child object
            return Expression.Call(
                null, // Static method
                // Get Convert MethodInfo for related types
                GetConvertMethod(setProperty.PropertyType, getProperty.PropertyType),
                getTInPropertyValueExpression,
                instancesParameter, Expression.Constant(false));
        }

        private static Expression GetSetPropertyExpression(ParameterExpression result, PropertyInfo setProperty, PropertyInfo getProperty, ParameterExpression sourceParameter)
        {
            Expression propertyGetValueExpression = Expression.MakeMemberAccess(sourceParameter, getProperty);
            Expression propertySetValueExpression = Expression.MakeMemberAccess(result, setProperty);
            // Assign the TResult property
            return Expression.Assign(propertySetValueExpression, propertyGetValueExpression);
        }

        private static Expression GetSetPropertyExpression(ParameterExpression result, PropertyInfo setProperty, PropertyInfo getProperty, ParameterExpression sourceParameter, ParameterExpression instancesParameter)
        {
            Expression propertGetValueExpression; // TOut property value expression
            var getTInPropertyValueExpression = Expression.MakeMemberAccess(sourceParameter, getProperty);
            if (setProperty.PropertyType.IsValueType)
                propertGetValueExpression = getTInPropertyValueExpression;
            else if (setProperty.PropertyType == typeof(string))
                propertGetValueExpression = getTInPropertyValueExpression;
            else if (IsCollection(setProperty))
                propertGetValueExpression = GetCollectionProperty(getTInPropertyValueExpression, setProperty, getProperty, instancesParameter);
            else if (setProperty.PropertyType.IsClass)
                propertGetValueExpression = GetInstanceProperty(getTInPropertyValueExpression, setProperty, getProperty, instancesParameter);
            else
                throw new NotImplementedException(setProperty.PropertyType.ToString());

            Expression propertySetValueExpression = Expression.MakeMemberAccess(result, setProperty);

            return Expression.Assign(propertySetValueExpression, propertGetValueExpression);
        }
    }

    /// <summary>
    ///   Reflection methods using Expression to avoid to use member's name
    /// </summary>
    public static class ReflectionExtension
    {
        /// <summary>
        ///   Returns MethodInfo from an expression
        /// </summary>
        /// <typeparam name = "T">The method type</typeparam>
        /// <param name = "exp">The expression</param>
        /// <returns>The MethodInfo</returns>
        public static MethodInfo GetMethod<T>(Expression<Action<T>> exp)
        {
            return GetMethod((LambdaExpression)exp);
        }

        /// <summary>
        ///   Returns MethodInfo from an expression
        /// </summary>
        /// <param name = "exp">The expression</param>
        /// <returns>The MethodInfo</returns>
        public static MethodInfo GetMethod(Expression<Action> exp)
        {
            return GetMethod((LambdaExpression)exp);
        }

        /// <summary>
        ///   Returns MethodInfo from an expression
        /// </summary>
        /// <param name = "exp">The expression</param>
        /// <returns>The MethodInfo</returns>
        private static MethodInfo GetMethod(LambdaExpression exp)
        {
            var methodCallExpression = exp.Body as MethodCallExpression;
            if (methodCallExpression == null)
                throw new ArgumentException();
            return methodCallExpression.Method;
        }
    }
}