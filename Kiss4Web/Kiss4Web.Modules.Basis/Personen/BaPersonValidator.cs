using FluentValidation;
using Kiss4Web.Infrastructure;
using Kiss4Web.Model;

namespace Kiss4Web.Modules.Basis.Personen
{
    public class BaPersonValidator : AbstractValidator<BaPerson>
    {
        public BaPersonValidator(IDateTimeProvider dateTime)
        {
            RuleFor(p => p.Vorname)
                .NotEmpty();

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.Geburtsdatum)
                .LessThanOrEqualTo(dateTime.Now)
                .When(p => p.Geburtsdatum.HasValue);

            RuleFor(p => p.Geburtsdatum)
                .LessThanOrEqualTo(p => p.Sterbedatum)
                .When(p => p.Geburtsdatum.HasValue && p.Sterbedatum.HasValue);

            RuleFor(p => p.Sterbedatum)
                .LessThanOrEqualTo(dateTime.Now)
                .When(p => p.Geburtsdatum.HasValue);

            //RuleFor(p => p.Versichertennummer)
            //    .Must(v => VersichertennummerValidator.IsValidVersichertennummer(v))
            //    .WithMessage("{0}", z => string.Format(Resources.Validation_ValueInvalid,
            //        Resources.StaPerson_Versichertennummer));
        }
    }
}