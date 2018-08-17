using FluentValidation;

using Kiss.DataAccess.LocalResources;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class KesAuftragValidator : ValidatorBase<KesAuftrag>
    {
        public KesAuftragValidator()
        {
            RuleFor(x => x.DatumAuftrag)
                .NotEmpty()
                .WithName(KesRes.DatumAuftrag);

            RuleFor(x => x.AbschlussDatum.Value)
                .GreaterThan(x => x.DatumAuftrag.Value)
                .When(x => x.DatumAuftrag.HasValue && x.AbschlussDatum.HasValue)
                .WithMessage(KesRes.AbschlussDatumGroesserDatumAuftrag);
        }
    }
}