using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Wsh.Validation
{
    public class WshAbzugDetailValidator : ValidatorBase<WshAbzugDetail, WshAbzugDetailValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAbzugDetailValidator"/> class and validates the entity <see cref="WshAbzugDetail"/> in memory.
        /// </summary>
        public WshAbzugDetailValidator()
        {
            RuleFor(x => x.WshAbzugID).GreaterThan(0);
            RuleFor(x => x.Betrag).GreaterThan(0).WithMessage("Der Betrag muss grösser als 0 sein.");
            RuleFor(x => x.KbuKontoID).GreaterThan(0).WithMessage("Kostenart muss ausgewählt sein.");
        }

        #endregion
    }
}