using Kiss.DbContext;
using FluentValidation;

namespace Kiss.DataAccess.Validation
{
    public class FsReduktionValidator : ValidatorBase<FsReduktion>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FsReduktionValidator"/> class and validates the entity <see cref="FsReduktion"/> in memory.
        /// </summary>
        public FsReduktionValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.StandardAufwand).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(p => p.StandardAufwand).NotNull().LessThanOrEqualTo(8760); // 365 * 24
        }

        #endregion
    }
}