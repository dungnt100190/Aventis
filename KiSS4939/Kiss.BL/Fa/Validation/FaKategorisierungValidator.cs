using System;

using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Fa.Validation
{
    public class FaKategorisierungValidator : ValidatorBase<FaKategorisierung, FaKategorisierungValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaKategorisierungValidator"/> class and validates the entity <see cref="FaKategorisierung"/> in memory.
        /// </summary>
        public FaKategorisierungValidator()
        {
            RuleFor(x => x.BaPersonID).GreaterThan(0);
            RuleFor(x => x.UserID).GreaterThan(0);

            RuleFor(x => x.Abschlussdatum)
                .GreaterThanOrEqualTo(x => x.Datum)
                .When(x => x.Abschlussdatum != null)
                .WithMessage("Das Abschlussdatum darf nicht vor dem Anfangsdatum liegen.");

            RuleFor(x=> x.FaKategorisierungRessourcenCode).Must(ValidateFaKategorisierungRessourcenCode).WithMessage("Es müssen sowohl Kooperation als auch Ressourcen gesetzt sein.");
        }

        private bool ValidateFaKategorisierungRessourcenCode(FaKategorisierung faKategorisierung, int? faKategorisierungRessourcenCode)
        {
            return faKategorisierungRessourcenCode.HasValue && faKategorisierung.FaKategorisierungKooperationCode.HasValue
                   || (!faKategorisierungRessourcenCode.HasValue && !faKategorisierung.FaKategorisierungKooperationCode.HasValue);
        }

        #endregion
    }
}