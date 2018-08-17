using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuBelegKreditorValidator : ValidatorBase<KbuBelegKreditor, KbuBelegKreditorValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuBelegKreditorValidator"/> class and validates the entity <see cref="TEntity"/> in memory.
        /// </summary>
        public KbuBelegKreditorValidator()
        {
            //RuleFor(x => x.Name).NotNull().NotEmpty();
        }

        #endregion
    }
}