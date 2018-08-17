using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Kiss.Infrastructure.IoC
{
    #region Enumerations

    /// <summary>
    /// The scope/lifetime of an object in the IoC-Container.
    /// </summary>
    public enum InstanceScope
    {
        /// <summary>
        /// A new instance is created for each resolve call.
        /// </summary>
        PerResolve = 1,

        /// <summary>
        /// A single instance is used for all resolve calls.
        /// </summary>
        Singleton = 2,

        /// <summary>
        /// A new instance is created for each requesting thread.
        /// </summary>
        PerThread = 3
    }

    #endregion

    ///<summary>
    /// IoC-Abstrahierung
    /// </summary>
    public static class Container
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const InstanceScope DEFAULT_SCOPE = InstanceScope.Singleton;

        #endregion

        #region Private Static Fields

        private static readonly IUnityContainer _unityContainer;

        #endregion

        #endregion

        #region Constructors

        static Container()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.AddNewExtension<KissUnityExtension>();
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Gets the registered concrete type for the specified lookup type.
        /// </summary>
        /// <param name="lookupType"></param>
        /// <returns></returns>
        public static Type GetConcreteType(Type lookupType)
        {
            return (from reg in _unityContainer.Registrations
                    where reg.RegisteredType == lookupType ||
                          (reg.RegisteredType.IsGenericType && reg.RegisteredType.GetGenericTypeDefinition() == lookupType) ||
                          (lookupType.IsGenericType && lookupType.GetGenericTypeDefinition() == reg.RegisteredType)
                    select reg.MappedToType).FirstOrDefault();
        }

        /// <summary>
        /// Checks whether the type <typeparamref name="T"/> is registered in the container.
        /// </summary>
        public static bool IsRegistered<T>()
        {
            return _unityContainer.IsRegistered<T>();
        }

        /// <summary>
        /// Loads the configuration from an app/web.config file.
        /// </summary>
        public static void LoadAppConfiguration()
        {
            _unityContainer.LoadConfiguration();
        }

        /// <summary>
        /// Registers a single IoC entry.
        /// </summary>
        /// <param name="entry"></param>
        public static void RegisterEntry(IoCEntry entry)
        {
            var lookupType = TypeLoader.GetType(entry.LookupTypeName, entry.LookupTypeNamespace, entry.LookupTypeAssemblyName);
            var concreteType = TypeLoader.GetType(entry.ConcreteTypeName, entry.ConcreteTypeNamespace, entry.ConcreteTypeAssemblyName);

            if (lookupType == null || concreteType == null)
            {
                var ex = new InvalidOperationException("Could register the entry. See the event data for additional information.");
                ex.Data.Add("entry", entry);
                throw ex;
            }

            RegisterType(lookupType, concreteType, entry.InstanceScope);
        }

        /// <summary>
        /// Registers all types inheriting from <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The base type of the types to register.</typeparam>
        public static void RegisterInheritingTypes<T>(InstanceScope scope = DEFAULT_SCOPE)
        {
            var t = typeof(T);

            var assembly = Assembly.GetAssembly(t);

            foreach (var type in assembly.GetTypes().Where(t.IsAssignableFrom))
            {
                RegisterType(type, scope);
            }
        }

        /// <summary>
        /// Registers a singleton object instance for the given lookup type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="scope"></param>
        public static void RegisterInstance<T>(T instance, InstanceScope scope = DEFAULT_SCOPE)
        {
            var ltm = GetLifetimeManager(scope) ?? new ContainerControlledLifetimeManager();
            _unityContainer.RegisterInstance(typeof(T), null, instance, ltm);
        }

        /// <summary>
        /// Registers a type with itself as lookup type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RegisterType<T>(InstanceScope scope = DEFAULT_SCOPE)
        {
            RegisterType(typeof(T), scope);
        }

        /// <summary>
        /// Registers a type with itself as lookup type.
        /// </summary>
        public static void RegisterType(Type t, InstanceScope scope = DEFAULT_SCOPE)
        {
            RegisterType(null, t, scope);
        }

        /// <summary>
        /// Registers the concrete type <paramref name="concreteType"/> for the given lookup type <paramref name="lookupType"/>.
        /// </summary>
        /// <param name="lookupType"></param>
        /// <param name="concreteType"></param>
        /// <param name="scope"></param>
        public static void RegisterType(Type lookupType, Type concreteType, InstanceScope scope = DEFAULT_SCOPE)
        {
            var ltm = GetLifetimeManager(scope);
            _unityContainer.RegisterType(lookupType, concreteType, null, ltm);
        }

        /// <summary>
        /// Registers the concrete type <typeparamref name="TConcrete"/> for the given lookup type <typeparamref name="TLookup"/>.
        /// </summary>
        /// <typeparam name="TLookup"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        public static void RegisterType<TLookup, TConcrete>(InstanceScope scope = DEFAULT_SCOPE)
            where TConcrete : TLookup
        {
            RegisterType(typeof(TLookup), typeof(TConcrete), scope);
        }

        /// <summary>
        /// Returns an instance for the registered type <paramref name="t"/>.
        /// Throws ConfigurationErrorsException if <paramref name="t"/> could not be resolved.
        /// </summary>
        /// <param name="t">The lookup type.</param>
        /// <param name="arguments">
        /// An optional list of arguments to pass to the constructor.
        /// </param>
        /// <returns></returns>
        public static object Resolve(Type t, params object[] arguments)
        {
            try
            {
                // get parameter names and create overrides
                var overrides = new ResolverOverride[arguments.Length];

                if (arguments.Length > 0)
                {
                    // create argument type array
                    var types = new Type[arguments.Length];

                    for (int i = 0; i < arguments.Length; i++)
                    {
                        types[i] = arguments[i].GetType();
                    }

                    // get the registered concrete type and it's constructor
                    var concreteType = GetConcreteType(t);
                    var ctor = concreteType.GetConstructor(types);

                    // validate constructor
                    if (ctor == null)
                    {
                        throw new ArgumentException("No constructor found for the specified arguments.", "arguments");
                    }

                    // get the constructor parameters
                    var cParams = ctor.GetParameters();

                    for (int i = 0; i < arguments.Length; i++)
                    {
                        overrides[i] = new ParameterOverride(cParams[i].Name, arguments[i]);
                    }
                }

                return _unityContainer.Resolve(t, null, overrides);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException(string.Format("Type {0} could not be resolved", t), ex);
            }
        }

        /// <summary>
        /// Returns an instance of the type <typeparamref name="T"/> based on the given lookuptype <typeparamref name="T"/>.
        /// Throws ConfigurationErrorsException if Type could not be resolved.
        /// </summary>
        /// <param name="arguments">
        /// An optional list of arguments to pass to the constructor.
        /// </param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>(params object[] arguments)
        {
            return (T)Resolve(typeof(T), arguments);
        }

        /// <summary>
        /// Returns an instance of the type <typeparamref name="T"/> based on the given lookuptype <typeparamref name="T"/>.
        /// or null if Type could not be resolved.
        /// </summary>
        /// <param name="arguments">
        /// An optional list of arguments to pass to the constructor.
        /// </param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T TryResolve<T>(params object[] arguments)
            where T : class
        {
            try
            {
                return Resolve<T>(arguments);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Returns a specific <see cref="LifetimeManager"/> for the requested instance scope.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        private static LifetimeManager GetLifetimeManager(InstanceScope scope)
        {
            switch (scope)
            {
                case InstanceScope.Singleton:
                    return new ContainerControlledLifetimeManager();
                case InstanceScope.PerThread:
                    return new PerThreadLifetimeManager();
                case InstanceScope.PerResolve:
                    return new TransientLifetimeManager();
                default:
                    return null;
            }
        }

        #endregion

        #endregion
    }
}