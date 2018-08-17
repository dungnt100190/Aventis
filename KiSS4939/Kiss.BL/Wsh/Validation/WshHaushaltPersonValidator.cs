using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Model;

using FluentValidation;
using FluentValidation.Results;

namespace Kiss.BL.Wsh.Validation
{
    public class WshHaushaltPersonValidator : ValidatorBase<WshHaushaltPerson, WshHaushaltPersonValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshHaushaltPersonValidator"/> class and validates the entity <see cref="WshHaushaltPerson"/> in memory.
        /// </summary>
        public WshHaushaltPersonValidator()
        {
            //RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(p => p.FaLeistungID).GreaterThan(0).WithMessage("Der Haushalt muss einer Wsh-Leistung zugeteilt sein.");
            RuleFor(p => p.BaPersonID).GreaterThan(0).WithMessage("Es muss eine Person ausgewählt werden.");
            RuleFor(p => p.DatumVon ?? Constant.SqlDateTimeMin)
                .GreaterThan(Constant.SqlDateTimeMin)
                .When(p => p.DatumVon != null)
                .WithName(PropertyName.GetPropertyName(() => new WshHaushaltPerson().DatumVon));
            Custom(p => p.DatumBis < p.DatumVon ?
                new ValidationFailure(PropertyName.GetPropertyName(() => p.DatumBis), "Datum Bis darf nicht kleiner als Datum Von sein.") :
                null);
        }

        #endregion
    }
}