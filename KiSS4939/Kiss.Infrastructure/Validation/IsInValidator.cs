using System.Collections;
using System.Collections.Generic;

using FluentValidation.Attributes;
using FluentValidation.Internal;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace Kiss.Infrastructure.Validation
{
    /// <summary>
    /// Class to validate a property where the value is in the given list
    /// </summary>
    internal class IsInValidator : PropertyValidator
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="IsInValidator"/> object
        /// </summary>
        /// <param name="list"></param>
        public IsInValidator(IList list)
            : base("IsIn error")
        {
            List = list;
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of possible value the property should have
        /// </summary>
        public IList List
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Validates the property
        /// </summary>
        /// <param name="context"><see cref="PropertyValidatorContext<T, TProperty>"/></param>
        /// <returns><see cref="PropertyValidatorResult"/></returns>
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (!List.Contains(context.PropertyValue))
            {
                context.MessageFormatter
                    .AppendArgument("Value", context.PropertyValue)
                    .AppendArgument("List", List);

                return false;
            }
            return true;
        }

        #endregion

        #endregion
    }
}