using FluentValidation;
using Kiss.DataAccess.LocalResources;
using Kiss.DataAccess.Properties;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class KesMassnahmeAuftragValidator : ValidatorBase<KesMassnahmeAuftrag>
    {
        public KesMassnahmeAuftragValidator()
        {
            RuleFor(x => x.ErledigungBis).NotEmpty().When(x => x.BeschlussVom.HasValue).WithName(KesRes.MassnahmeAuftragErledigungBis);
        }
    }
}