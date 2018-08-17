using FluentValidation;
using Kiss.DataAccess.Properties;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class KesMassnahmeBerichtValidator : ValidatorBase<KesMassnahmeBericht>
    {
        public KesMassnahmeBerichtValidator()
        {
            RuleFor(x => x.DatumBis).NotEmpty().WithName(Resources.DatumBis);

            RuleFor(x => x.DatumBis.Value)
                .GreaterThan(x => x.DatumVon.Value)
                .When(x => x.DatumVon.HasValue && x.DatumBis.HasValue)
                .WithMessage(Resources.DatumBisGroesserDatumVon);
        }
    }
}