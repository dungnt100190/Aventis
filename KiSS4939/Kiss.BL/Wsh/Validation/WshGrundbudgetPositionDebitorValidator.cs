using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Wsh.Validation
{
    public class WshGrundbudgetPositionDebitorValidator : ValidatorBase<WshGrundbudgetPositionDebitor, WshGrundbudgetPositionDebitorValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshGrundbudgetPositionDebitorValidator"/> class and validates the entity <see cref="WshGrundbudgetPositionDebitor"/> in memory.
        /// </summary>
        public WshGrundbudgetPositionDebitorValidator()
        {
            RuleFor(x => x.BaInstitutionID).Must(CheckDbConstraint).WithMessage(@"Es muss eine Person oder eine Institution ausgewählt werden.");
        }

        #endregion

        #region Methods

        #region Private Methods

        private bool CheckDbConstraint(WshGrundbudgetPositionDebitor debitor, int? baInstitutionId)
        {
            return (debitor.BaInstitutionID == null && debitor.BaPersonID != null) || (debitor.BaInstitutionID != null && debitor.BaPersonID == null);
        }

        #endregion

        #endregion
    }
}