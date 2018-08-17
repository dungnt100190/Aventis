using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Fa.Validation
{
    public class FaLeistungValidator : ValidatorBase<FaLeistung, FaLeistungValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaLeistungValidator"/> class and validates the entity <see cref="TEntity"/> in memory.
        /// </summary>
        public FaLeistungValidator()
        {
            RuleFor(x => x.BaPersonID).GreaterThan(0).WithMessage("Es muss ein/e Leistungsträger/in ausgewählt sein");
            RuleFor(x => x.FaFallID).GreaterThan(0).WithMessage("Die Leistung muss einem Fall zugeordnet sein");
            RuleFor(x => x.ModulID).GreaterThan(0).WithMessage("Die Leistung muss einem Modul zugeordnet sein");
            RuleFor(x => x.UserID).GreaterThan(0).WithMessage("Die Leistung muss einem SA zugeordnet sein");
        }

        #endregion
    }
}