using FluentValidation;

using Kiss.DataAccess.LocalResources;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class KesVerlaufValidator : ValidatorBase<KesVerlauf>
    {
        public KesVerlaufValidator()
        {
            //RuleFor(x => x.UserID).NotEmpty().WithName(KesRes.VerlaufUndDokumentUser);
        }
    }
}