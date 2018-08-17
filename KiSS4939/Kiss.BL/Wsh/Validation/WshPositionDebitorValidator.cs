using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Wsh.Validation
{
    public class WshPositionDebitorValidator : ValidatorBase<WshPositionDebitor, WshPositionDebitorValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshPositionDebitorValidator"/> class and validates the entity <see cref="WshPositionDebitor"/> in memory.
        /// </summary>
        public WshPositionDebitorValidator()
        {
            RuleFor(x => x.BaInstitutionID).Must(CheckDbConstraint).WithMessage(@"Es muss eine Person oder eine Institution ausgewählt werden.");
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// ([BaInstitutionID] IS NULL AND [BaPersonID] IS NOT NULL OR [BaInstitutionID] IS NOT NULL AND [BaPersonID] IS NULL)
        /// </summary>
        private bool CheckDbConstraint(WshPositionDebitor debitor, int? baInstitutionId)
        {
            return (debitor.BaInstitutionID == null && debitor.BaPersonID != null) || (debitor.BaInstitutionID != null && debitor.BaPersonID == null);
        }

        #endregion

        #endregion
    }
}