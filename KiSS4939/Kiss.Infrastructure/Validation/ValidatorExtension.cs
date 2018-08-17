using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace Kiss.Infrastructure.Validation
{
    /// <summary>
    /// Class containg extensions methods to set custom validation rules
    /// </summary>
    public static class ValidatorExtension
    {
        public static string GetMessage(this ValidationResult validationResult)
        {
            if (validationResult.Errors == null || validationResult.Errors.Count == 0)
                return string.Empty;

            StringBuilder stringBuilder = new StringBuilder("Errors:");
            stringBuilder.AppendLine();
            validationResult.Errors.ToList().ForEach(va => stringBuilder.AppendLine(va.ErrorMessage));
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Rule to know if a value is in a range
        /// </summary>
        /// <typeparam name="T">Type of object to validate</typeparam>
        /// <typeparam name="TProperty">Type of the property to validate</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined <see cref="IRuleBuilder{T, TProperty}"/></param>
        /// <param name="min">The min value</param>
        /// <param name="max">The max value</param>
        /// <returns>an instance of <see cref="IRuleBuilderOptions{T, TProperty}" /></returns>
        public static IRuleBuilderOptions<T, TProperty> IsBetween<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
            TProperty min,
            TProperty max)
            where T : class
            where TProperty : class, IComparable
        {
            return ruleBuilder.SetValidator(new InclusiveBetweenValidator(min, max));
        }

        /// <summary>
        /// Rule to know if a value is in a range
        /// </summary>
        /// <typeparam name="T">Type of object to validate</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined <see cref="IRuleBuilder{T, TProperty}"/></param>
        /// <param name="min">The min value</param>
        /// <param name="max">The max value</param>
        /// <returns>an instance of <see cref="IRuleBuilderOptions{T, TProperty}" /></returns>
        public static IRuleBuilderOptions<T, DateTime> IsBetween<T>(this IRuleBuilder<T, DateTime> ruleBuilder,
            DateTime min,
            DateTime max)
        {
            return ruleBuilder.SetValidator(new InclusiveBetweenValidator(min, max));
        }

        /// <summary>
        /// Rule to know if a value is in a range
        /// </summary>
        /// <typeparam name="T">Type of object to validate</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined <see cref="IRuleBuilder{T, Int32}"/></param>
        /// <param name="min">The min value</param>
        /// <param name="max">The max value</param>
        /// <returns>an instance of <see cref="IRuleBuilderOptions{T, Int32}" /></returns>
        public static IRuleBuilderOptions<T, int?> IsBetween<T>(this IRuleBuilderInitial<T, int?> ruleBuilder, int min, int max)
        {
            return ruleBuilder.SetValidator(new InclusiveBetweenValidator(min, max));
        }

        /// <summary>
        /// Rule to know if a value is in the list.
        /// </summary>
        /// <typeparam name="T">Type of object to validate</typeparam>
        /// <typeparam name="TProperty">Type of property to validate</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined <see cref="IRuleBuilder{T,TProperty}"/></param>
        /// <param name="list">List of possible values</param>
        /// <returns>an instance of <see cref="FluentValidation.IRuleBuilderOptions{T, TProperty}"/></returns>
        public static IRuleBuilderOptions<T, TProperty> IsIn<T, TProperty>(this IRuleBuilderInitial<T, TProperty> ruleBuilder, List<TProperty> list)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return ruleBuilder.SetValidator(new IsInValidator(list));
        }

        /// <summary>
        /// Rule to know if a value is in the list.
        /// </summary>
        /// <typeparam name="T">Type of object to validate</typeparam>
        /// <typeparam name="TProperty">Non-Nullable type of the property to validate</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined <see cref="IRuleBuilder{T,TProperty}"/></param>
        /// <param name="list">List of possible values</param>
        /// <returns>an instance of <see cref="FluentValidation.IRuleBuilderOptions{T, TProperty}"/></returns>
        public static IRuleBuilderOptions<T, TProperty?> IsIn<T, TProperty>(this IRuleBuilderInitial<T, TProperty?> ruleBuilder, List<TProperty?> list)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return ruleBuilder.SetValidator(new IsInValidator(list));
        }
    }
}