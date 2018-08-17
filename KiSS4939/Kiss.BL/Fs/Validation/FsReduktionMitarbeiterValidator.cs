using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Fs.Validation
{
    public class FsReduktionMitarbeiterValidator : ValidatorBase<FsReduktionMitarbeiter, FsReduktionMitarbeiterValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FsReduktionMitarbeiterValidator"/> class and validates the entity <see cref="FsReduktionMitarbeiter"/> in memory.
        /// </summary>
        public FsReduktionMitarbeiterValidator()
        {
            RuleFor(x => x.UserID).NotEmpty();
            RuleFor(x => x.FsReduktionID).NotEmpty();
            RuleFor(x => x.Jahr).NotEmpty().GreaterThan(1900);
            RuleFor(x => x.Monat).LessThanOrEqualTo(12).GreaterThanOrEqualTo(1);
            RuleFor(x => x.OriginalReduktionZeit).NotNull();
        }

        #endregion
    }
}