using System.Collections.Generic;

using FluentValidation;
using Kiss.Infrastructure.Validation;
using KiSS.Common.Validation;
using KiSS.KliBu.BL.DTO;

namespace KiSS.KliBu.BL.Validation
{
    /// <summary>
    /// Class to validate the content of a <see cref="Bank"/> object
    /// </summary>
    public class BankValidator : AbstractValidator<Bank>
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="BankValidator"/> object and set the validation rules
        /// </summary>
        public BankValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.ClearingNr).NotEmpty();
            RuleFor(b => b.FilialeNr).GreaterThanOrEqualTo(0).LessThanOrEqualTo(9999);
            RuleFor(b => b.GueltigAb).NotNull();

            RuleFor(b => b.Gruppe).IsBetween(1, 9).When(b => b.Gruppe != null);
            RuleFor(b => b.ClearingNrNeu).NotEmpty().When(b => b.ClearingNrNeu != null);
            RuleFor(b => b.SicNr).IsBetween(0, 999999).When(b => b.SicNr != null);
            RuleFor(b => b.HauptsitzBCL).NotEmpty().When(b => b.HauptsitzBCL != null);
            RuleFor(b => b.BcArt).IsBetween(1, 3).When(b => b.BcArt != null);
            RuleFor(b => b.TeilnahmecodeCHF).IsBetween(0, 3).When(b => b.TeilnahmecodeCHF != null);

            RuleFor(b => b.TeilnahmecodeEuro).IsIn(new List<int?> { 0, 1, 3 }).When(b => b.TeilnahmecodeEuro != null);

            RuleFor(b => b.Sprachcode).IsBetween(1, 3).When(b => b.Sprachcode != null);
            RuleFor(b => b.Landcode).Matches(Rgx.Landcode).When(b => b.Landcode != "");
            RuleFor(b => b.PCKontoNr).Matches(Rgx.PCKontoNr).When(b => b.PCKontoNr != "");
            RuleFor(b => b.SwiftAdresse).Matches(Rgx.SwiftAdresse).When(b => b.SwiftAdresse != "");
        }

        #endregion
    }
}