using FluentValidation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Validation
{
    public class FaDokumentAblageValidator : ValidatorBase<FaDokumentAblage>
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="BaPersonValidator"/> object and set the validation rules
        /// </summary>
        public FaDokumentAblageValidator()
        {
            RuleFor(p => p.UserID).NotNull().NotEmpty().WithMessage("Der Autor darf nicht leer sein.");
        }

        #endregion Constructors
    }
}