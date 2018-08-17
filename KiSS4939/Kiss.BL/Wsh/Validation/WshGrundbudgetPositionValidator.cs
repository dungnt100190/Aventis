using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Validation;
using Kiss.Model;

using FluentValidation;
using FluentValidation.Results;

namespace Kiss.BL.Wsh.Validation
{
    public class WshGrundbudgetPositionValidator : ValidatorBase<WshGrundbudgetPosition, WshGrundbudgetPositionValidator>
    {
        #region Fields

        #region Private Static Fields

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshGrundbudgetPositionValidator"/> class and validates the entity <see cref="WshGrundbudgetPosition"/> in memory.
        /// </summary>
        public WshGrundbudgetPositionValidator()
        {
            RuleFor(x => x.FaLeistungID).GreaterThan(0);
            RuleFor(x => x.KbuKontoID).NotEmpty().WithMessage("Kostenart muss ausgewählt sein.");
            RuleFor(x => x.Text).NotNull().NotEmpty().WithMessage("Text darf nicht leer sein.");
            RuleFor(x => x.DatumVon).IsBetween(Constant.SqlDateTimeMin, Constant.SqlDateTimeMax);
            Custom(
                x => x.DatumBis < x.DatumVon
                         ? new ValidationFailure(PropertyName.GetPropertyName(() => x.DatumBis), "Datum Bis darf nicht kleiner als Datum Von sein.")
                         : null);
        }

        #endregion

        #region Methods

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #endregion
    }
}