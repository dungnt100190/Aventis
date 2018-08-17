using System.Linq;

using FluentValidation.Results;

using Kiss.Infrastructure;
using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuBelegKreisValidator : ValidatorBase<KbuBelegKreis, KbuBelegKreisValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuBelegKreisValidator"/> class and validates the entity <see cref="TEntity"/> in memory.
        /// </summary>
        public KbuBelegKreisValidator()
        {
            RuleFor(x => x.NaechsteBelegNr).NotNull().WithMessage("BelegNummer darf nicht null sein");
            Custom(
                x => x.NaechsteBelegNr.HasValue && x.BelegNrBis.HasValue && 
                    x.NaechsteBelegNr > x.BelegNrBis
                         ? new ValidationFailure(PropertyName.GetPropertyName(() => x.NaechsteBelegNr), "Nächste Belegnummer muss kleiner sein als BelegNrBis.")
                         : null);
        }

        #endregion
    }
}