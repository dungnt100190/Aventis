using Kiss.Model;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuKontoValidator : ValidatorBase<KbuKonto, KbuKontoValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuKontoValidator"/> class and validates the entity <see cref="TEntity"/> in memory.
        /// </summary>
        public KbuKontoValidator()
        {
            //RuleFor(x => x.Name).NotNull().NotEmpty();
        }

        #endregion
    }
}