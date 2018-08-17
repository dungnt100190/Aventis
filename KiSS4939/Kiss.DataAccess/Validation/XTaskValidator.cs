using FluentValidation;

using Kiss.DataAccess.Properties;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class XTaskValidator : ValidatorBase<XTask>
    {
        public XTaskValidator()
        {
            RuleFor(x => x.ExpirationDate.Value)
                .GreaterThan(x => x.StartDate.Value)
                .When(x => x.StartDate.HasValue && x.ExpirationDate.HasValue)
                .WithMessage(Resources.DatumBisGroesserDatumVon);
        }
    }
}