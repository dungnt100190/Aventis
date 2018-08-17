using System;
using System.Collections.Generic;
using FluentValidation;
using Kiss.Infrastructure.Validation;
using Kiss.Model;

namespace Kiss.BL.Ba.Validation
{
    public class BaAdresseValidator : ValidatorBase<BaAdresse, BaAdresseValidator>
    {
        /// <summary>
        /// Initializes the <see cref="BaAdresseValidator"/> object and set the validation rules
        /// </summary>
        public BaAdresseValidator()
        {
            // BaPersonID or BaInstitutionID have to be set but not both at the same time
            RuleFor(a => a.BaPersonID).NotNull().When(a => a.BaInstitutionID == null);
            RuleFor(a => a.BaInstitutionID).NotNull().When(a => a.BaPersonID == null);
            RuleFor(a => a.BaPersonID).Must(personID => personID == null).When(a => a.BaInstitutionID != null);
            RuleFor(a => a.BaInstitutionID).Must(institutionID => institutionID == null).When(a => a.BaPersonID != null);

            // DatumBis >= DatumVon
            RuleFor(a => a.DatumBis ?? DateTime.MaxValue)
                .GreaterThanOrEqualTo(a => a.DatumVon ?? DateTime.MinValue)
                .When(a => a.DatumVon != null)
                .WithName("DatumBis");

            // Check LOV values
            RuleFor(a => a.WohnStatusCode).IsIn(new List<int?> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 14, 15, 17, 18 }).When(a => a.WohnStatusCode != null);

            // Creator and Modifier must has to be set
            RuleFor(a => a.Creator).NotNull().NotEmpty();
            RuleFor(a => a.Modifier).NotNull().NotEmpty();
        }
    }
}