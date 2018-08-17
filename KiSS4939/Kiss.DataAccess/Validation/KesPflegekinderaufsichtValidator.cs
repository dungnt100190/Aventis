using FluentValidation;

using Kiss.DataAccess.Properties;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class KesPflegekinderaufsichtValidator : ValidatorBase<KesPflegekinderaufsicht>
    {
        public KesPflegekinderaufsichtValidator()
        {
            RuleFor(x => x.DatumBis.Value)
                .GreaterThan(x => x.DatumVon.Value)
                .When(x => x.DatumVon.HasValue && x.DatumBis.HasValue)
                .WithMessage(Resources.DatumBisGroesserDatumVon);
        }
    }
}