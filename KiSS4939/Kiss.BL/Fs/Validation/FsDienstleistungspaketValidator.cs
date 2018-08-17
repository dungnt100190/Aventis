using Kiss.Infrastructure;
using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Fs.Validation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FsDienstleistungspaketValidator"/> class and validates the entity <see cref="FsDienstleistungspaket"/> in memory.
    /// </summary>
    public class FsDienstleistungspaketValidator : ValidatorBase<FsDienstleistungspaket, FsDienstleistungspaketValidator>
    {
        #region Constructors

        public FsDienstleistungspaketValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(x => x.MaximaleLaufzeit ?? -1)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MaximaleLaufzeit != null)
                .WithName(PropertyName.GetPropertyName<FsDienstleistungspaket>(x => x.MaximaleLaufzeit));
        }

        #endregion
    }
}