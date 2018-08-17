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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Utility;

namespace Kiss.Infrastructure.IoC
{
    /// <summary>
    /// An implementation of <see cref="IBuildKeyMappingPolicy"/> that can map
    /// generic types.
    /// </summary>
    public class GenericTypeBuildKeyMappingPolicy : IBuildKeyMappingPolicy
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly NamedTypeBuildKey _destinationKey;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new <see cref="GenericTypeBuildKeyMappingPolicy"/> instance
        /// that will map generic types.
        /// </summary>
        /// <param name="destinationKey">Build key to map to. This must be or contain an open generic type.</param>
        // FxCop suppression: Validation is done by Guard class
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public GenericTypeBuildKeyMappingPolicy(NamedTypeBuildKey destinationKey)
        {
            Guard.ArgumentNotNull(destinationKey, "destinationKey");
            if (!destinationKey.Type.IsGenericTypeDefinition)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture,
                                  "The supplied type {0} must be an open generic type.",
                                  destinationKey.Type.Name));
            }
            _destinationKey = destinationKey;
        }

        #endregion

        #region Properties

        private Type DestinationType
        {
            get { return _destinationKey.Type; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Maps the build key.
        /// </summary>
        /// <param name="buildKey">The build key to map.</param>
        /// <param name="context">Current build context. Used for contextual information
        /// if writing a more sophisticated mapping.</param>
        /// <returns>The new build key.</returns>
        public NamedTypeBuildKey Map(NamedTypeBuildKey buildKey, IBuilderContext context)
        {
            Guard.ArgumentNotNull(buildKey, "buildKey");
            Type originalType = buildKey.Type;
            GuardSameNumberOfGenericArguments(originalType);

            Type[] genericArguments = originalType.GetGenericArguments();

            Type resultType = _destinationKey.Type;

            // Workaround:
            // If context is null, the call comes from UnityContainer.Registrations[],
            // which does not specify the correct generic type constraints.
            // This will result in an annoying exception in Type.MakeGenericType().
            if (context != null)
            {
                try
                {
                    resultType = resultType.MakeGenericType(genericArguments);
                }
                catch
                {
                    resultType = _destinationKey.Type;
                }
            }

            return new NamedTypeBuildKey(resultType, _destinationKey.Name);
        }

        #endregion

        #region Private Methods

        private void GuardSameNumberOfGenericArguments(Type sourceType)
        {
            if (sourceType.GetGenericArguments().Length != DestinationType.GetGenericArguments().Length)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture,
                                  "The supplied type {0} does not have the same number of generic arguments as the target type {1}.",
                                  sourceType.Name, DestinationType.Name),
                    "sourceType");
            }
        }

        #endregion

        #endregion
    }
}