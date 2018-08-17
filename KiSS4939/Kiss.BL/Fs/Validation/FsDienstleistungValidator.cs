using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Fs.Validation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FsDienstleistungValidator"/> class and validates the entity <see cref="FsDienstleistung"/> in memory.
    /// </summary>
    public class FsDienstleistungValidator : ValidatorBase<FsDienstleistung, FsDienstleistungValidator>
    {
        #region Constructors

        public FsDienstleistungValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(x => x.StandardAufwand).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.StandardAufwand).NotNull().LessThanOrEqualTo(744);
        }

        #endregion
    }
}