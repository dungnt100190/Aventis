using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuBelegPositionValidator : ValidatorBase<KbuBelegPosition, KbuBelegPositionValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuBelegPositionValidator"/> class and validates the entity <see cref="TEntity"/> in memory.
        /// </summary>
        public KbuBelegPositionValidator()
        {
            //RuleFor(x => x.Name).NotNull().NotEmpty();
        }

        #endregion
    }
}