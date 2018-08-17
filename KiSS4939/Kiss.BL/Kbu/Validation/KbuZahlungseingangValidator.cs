using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuZahlungseingangValidator : ValidatorBase<KbuZahlungseingang, KbuZahlungseingangValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuZahlungseingangValidator"/> class and validates the entity <see cref="KbuZahlungseingang"/> in memory.
        /// </summary>
        public KbuZahlungseingangValidator()
        {
            // TODO: Add some validation
            //RuleFor(x => x.Name).NotNull().NotEmpty();
        }

        #endregion
    }
}