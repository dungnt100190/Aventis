using System;
using System.Collections.Generic;
using FluentValidation;
using Kiss.Infrastructure.Validation;
using Kiss.Model;

namespace Kiss.BL.Ba.Validation
{
    public class BaPersonValidator : ValidatorBase<BaPerson, BaPersonValidator>
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
            RuleFor(p => p.GeschlechtCode).IsBetween(1, 2).When(p => p.GeschlechtCode != null);
            RuleFor(p => p.KonfessionCode).IsIn(new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 99999 }).When(p => p.KonfessionCode != null);
            RuleFor(p => p.ZivilstandCode).IsIn(new List<int?> { 1, 2, 3, 4, 5, 6, 7, 99999 }).When(p => p.ZivilstandCode != null);

            RuleFor(p => p.EMail).EmailAddress();
        }

        #endregion
    }
}