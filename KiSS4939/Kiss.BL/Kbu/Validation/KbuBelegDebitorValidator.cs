using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuBelegDebitorValidator : ValidatorBase<KbuBelegDebitor, KbuBelegDebitorValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuBelegDebitorValidator"/> class and validates the entity <see cref="TEntity"/> in memory.
        /// </summary>
        public KbuBelegDebitorValidator()
        {
            //RuleFor(x => x.Name).NotNull().NotEmpty();
        }

        #endregion
    }
}