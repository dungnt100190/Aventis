using FluentValidation;

using Kiss.DataAccess.LocalResources;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class KesDokumentValidator : ValidatorBase<KesDokument>
    {
        public KesDokumentValidator()
        {
            //RuleFor(x => x.UserID).NotEmpty().WithName(KesRes.VerlaufUndDokumentUser);
        }
    }
}