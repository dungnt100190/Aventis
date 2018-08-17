using System;
using System.Collections.Generic;
using FluentValidation;
using Kiss.DbContext;
using Kiss.Infrastructure.Validation;

namespace Kiss.DataAccess.Validation
{
    public class BaPersonValidator : ValidatorBase<BaPerson>
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="BaPersonValidator"/> object and set the validation rules
        /// </summary>
        public BaPersonValidator()
        {
            // Name and Vorname don't have to be empty
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.Vorname).NotNull().NotEmpty();

            // Sterbedatum >= Geburtsdatum
            RuleFor(p => p.Sterbedatum ?? DateTime.MaxValue)
                .GreaterThanOrEqualTo(p => p.Geburtsdatum ?? DateTime.MinValue)
                .When(p => p.Sterbedatum != null)
                .WithName("Sterbedatum");

            // Check LOV values
            RuleFor(p => p.GeschlechtCode).InclusiveBetween(1, 3).When(p => p.GeschlechtCode != null);
            //RuleFor(p => p.KonfessionCode.Value).IsIn(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 99999 }).When(p => p.KonfessionCode.HasValue);
            //RuleFor(p => p.ZivilstandCode.Value).IsIn(new List<int> { 1, 2, 3, 4, 5, 6, 7, 99999 }).When(p => p.ZivilstandCode.HasValue);

            //RuleFor(p => p.EMail).EmailAddress();
        }

        #endregion
    }
}