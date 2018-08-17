#region Header

//===============================================================================
// Microsoft patterns & practices
// Unity Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace Kiss.Infrastructure.IoC
{
    /// <summary>
    /// A custom constructor selection policy that also returns non-public constructors.
    /// </summary>
    internal class ConstructorSelectorPolicy : IConstructorSelectorPolicy
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Choose the constructor to call for the given type.
        /// </summary>
        /// <param name="context">Current build context</param>
        /// <param name="resolverPolicyDestination">The <see cref='IPolicyList'/> to add any
        /// generated resolver objects into.</param>
        /// <returns>The chosen constructor.</returns>
        public SelectedConstructor SelectConstructor(IBuilderContext context, IPolicyList resolverPolicyDestination)
        {
            Type typeToConstruct = context.BuildKey.Type;

            CheckResolvePermission(typeToConstruct);

            ConstructorInfo ctor = FindInjectionConstructor(typeToConstruct) ?? FindLongestConstructor(typeToConstruct);
            if (ctor != null)
            {
                return CreateSelectedConstructor(context, resolverPolicyDestination, ctor);
            }
            return null;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Create a <see cref="IDependencyResolverPolicy"/> instance for the given
        /// <see cref="ParameterInfo"/>.
        /// </summary>
        /// <remarks>
        /// This implementation looks for the Unity <see cref="DependencyAttribute"/> on the
        /// parameter and uses it to create an instance of <see cref="NamedTypeDependencyResolverPolicy"/>
        /// for this parameter.</remarks>
        /// <param name="parameter">Parameter to create the resolver for.</param>
        /// <returns>The resolver object.</returns>
        private static IDependencyResolverPolicy CreateResolver(ParameterInfo parameter)
        {
            // Resolve all DependencyAttributes on this parameter, if any
            var attrs = parameter.GetCustomAttributes(false).OfType<DependencyResolutionAttribute>().ToList();

            if (attrs.Count > 0)
            {
                // Since this attribute is defined with MultipleUse = false, the compiler will
                // enforce at most one. So we don't need to check for more.
                return attrs[0].CreateResolver(parameter.ParameterType);
            }

            // No attribute, just go back to the container for the default for that type.
            return new NamedTypeDependencyResolverPolicy(parameter.ParameterType, null);
        }

        private static SelectedConstructor CreateSelectedConstructor(
            IBuilderContext context,
            IPolicyList resolverPolicyDestination,
            ConstructorInfo ctor)
        {
            var result = new SelectedConstructor(ctor);

            foreach (ParameterInfo param in ctor.GetParameters())
            {
                string key = Guid.NewGuid().ToString();
                IDependencyResolverPolicy policy = CreateResolver(param);
                resolverPolicyDestination.Set(policy, key);
                DependencyResolverTrackerPolicy.TrackKey(resolverPolicyDestination, context.BuildKey, key);
                result.AddParameterKey(key);
            }
            return result;
        }

        private static ConstructorInfo FindInjectionConstructor(Type typeToConstruct)
        {
            ConstructorInfo[] injectionConstructors =
                typeToConstruct.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(ctor => ctor.IsDefined(typeof(InjectionConstructorAttribute), true))
                    .ToArray();

            switch (injectionConstructors.Length)
            {
                case 0:
                    return null;

                case 1:
                    return injectionConstructors[0];

                default:
                    throw new InvalidOperationException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            "Error: The type '{0}' contains multiple constructors with the InjectionConstructor attribute.",
                            typeToConstruct.Name));
            }
        }

        private static ConstructorInfo FindLongestConstructor(Type typeToConstruct)
        {
            ConstructorInfo[] constructors =
                typeToConstruct.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            Array.Sort(constructors, new ConstructorLengthComparer());

            switch (constructors.Length)
            {
                case 0:
                    return null;

                case 1:
                    return constructors[0];

                default:
                    int paramLength = constructors[0].GetParameters().Length;
                    if (constructors[1].GetParameters().Length == paramLength)
                    {
                        throw new InvalidOperationException(
                            string.Format(
                                CultureInfo.CurrentCulture,
                                "Error: Ambiguous constructors in type '{0}' (number of parameters: {1}.",
                                typeToConstruct.Name,
                                paramLength));
                    }
                    return constructors[0];
            }
        }

        #endregion

        #region Private Methods

        private void CheckResolvePermission(Type typeToConstruct)
        {
            var attributes = typeToConstruct.GetCustomAttributes(typeof(UsableByAttribute), true);

            if (attributes.Length > 0)
            {
                var attribute = attributes[0] as UsableByAttribute;

                if (attribute != null)
                {
                    var stackTrace = new System.Diagnostics.StackTrace();

                    bool isUsable = false;

                    var frames = stackTrace.GetFrames();

                    if (frames != null)
                    {
                        foreach (var stackFrame in frames)
                        {
                            var method = stackFrame.GetMethod();

                            if (method != null && attribute.IsUsableBy(method.DeclaringType))
                            {
                                isUsable = true;
                                break;
                            }
                        }
                    }

                    if (!isUsable)
                    {
                        var types = attribute.GetTypesString();
                        throw new InvalidOperationException(
                            "The calling class does not have permission to resolve an object this type. Valid calling types are: " + types);
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Nested Types

        private class ConstructorLengthComparer : IComparer<ConstructorInfo>
        {
            #region Methods

            #region Public Methods

            ///<summary>
            ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            ///</summary>
            ///
            ///<returns>
            ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
            ///</returns>
            ///
            ///<param name="y">The second object to compare.</param>
            ///<param name="x">The first object to compare.</param>
            public int Compare(ConstructorInfo x, ConstructorInfo y)
            {
                return y.GetParameters().Length - x.GetParameters().Length;
            }

            #endregion

            #endregion
        }

        #endregion
    }
}