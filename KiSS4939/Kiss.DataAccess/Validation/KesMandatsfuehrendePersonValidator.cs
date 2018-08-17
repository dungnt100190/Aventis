using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using FluentValidation;

using Kiss.DataAccess.LocalResources;
using Kiss.DataAccess.Properties;
using Kiss.DbContext;
using Kiss.Infrastructure;

namespace Kiss.DataAccess.Validation
{
    public class KesMandatsfuehrendePersonValidator : ValidatorBase<KesMandatsfuehrendePerson>
    {
        public KesMandatsfuehrendePersonValidator()
        {
            RuleFor(x => x.DatumMandatBis.Value)
                .GreaterThan(x => x.DatumMandatVon.Value)
                .When(x => x.DatumMandatVon.HasValue && x.DatumMandatBis.HasValue)
                .WithMessage(Resources.DatumBisGroesserDatumVon);

            RuleFor(x => x.DatumRechnungsfuehrungBis.Value)
                .GreaterThan(x => x.DatumRechnungsfuehrungVon.Value)
                .When(x => x.DatumRechnungsfuehrungVon.HasValue && x.DatumRechnungsfuehrungBis.HasValue)
                .WithMessage(Resources.DatumBisGroesserDatumVon);
        }
    }
}