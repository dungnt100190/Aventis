using System;
using System.Collections.Generic;

namespace Kiss.Infrastructure.IoC
{
    public static class TypeLoader
    {
        #region Fields

        #region Private Static Fields

        private static readonly Dictionary<string, Type> _cache = new Dictionary<string, Type>();

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Loads a type using the specified class name, namespace and assembly name.
        /// </summary>
        /// <param name="className">The class/type name (without namespace).</param>
        /// <param name="nameSpace">The full namespace of the type (without class name).</param>
        /// <param name="assemblyName">The name of the assembly (optional).</param>
        /// <returns></returns>
        public static Type GetType(string className, string nameSpace, string assemblyName = null)
        {
            // check input
            if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(nameSpace))
            {
                return null;
            }

            if (className.Contains("."))
            {
                throw new ArgumentException("className must not include the namespace.", "className");
            }

            var fullName = string.Format("{0}.{1}{2}{3}", nameSpace, className, string.IsNullOrEmpty(assemblyName) ? string.Empty : ",", assemblyName);

            // check if type is already in cache
            var result = GetFromCache(className, nameSpace);

            if (result != null)
            {
                return result;
            }

            lock (_cache)
            {
                try
                {
                    result = GetFromCache(className, nameSpace);

                    if (result != null)
                    {
                        return result;
                    }

                    result = Type.GetType(fullName);

                    if (result != null)
                    {
                        AddToCache(result);
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("Could not create a Type for '{0}'.", fullName), ex);
                }
            }
        }

        #endregion

        #region Private Static Methods

        private static void AddToCache(Type type)
        {
            var fullName = type.Namespace + "." + type.Name;

            if (!string.IsNullOrEmpty(fullName))
            {
                _cache.Add(fullName, type);
            }
        }

        private static Type GetFromCache(string className, string nameSpace)
        {
            var fullName = nameSpace + "." + className;

            if (_cache.ContainsKey(fullName))
            {
                return _cache[fullName];
            }

            return null;
        }

        #endregion

        #endregion
    }
}