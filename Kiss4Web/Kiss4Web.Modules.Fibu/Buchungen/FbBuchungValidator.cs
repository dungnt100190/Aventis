using FluentValidation;
using Kiss4Web.Model;

namespace Kiss4Web.Modules.Fibu.Buchungen
{
    public class FbBuchungValidator : AbstractValidator<FbBuchung>
    {
        public FbBuchungValidator()
        {
            RuleFor(buc => buc.BelegNr)
                .NotNull();
            RuleFor(buc => buc.SollKtoNr)
                .NotNull();
            RuleFor(buc => buc.HabenKtoNr)
                .NotNull();
            RuleFor(buc => buc.Text)
                .NotNull();
        }
    }
}