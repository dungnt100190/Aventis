using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Vm.Validation
{
    public class VmKlientenbudgetValidator : ValidatorBase<VmKlientenbudget, VmKlientenbudgetValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VmKlientenbudgetValidator"/> class and validates the entity <see cref="VmKlientenbudget"/> in memory.
        /// </summary>
        public VmKlientenbudgetValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().GreaterThan(0);
            RuleFor(x => x.FaLeistungID).NotEmpty().GreaterThan(0);
            RuleFor(x => x.GueltigAb).NotEmpty().WithMessage("'Gültig ab' darf nicht leer sein.");
            RuleFor(x => x.VmKlientenbudgetMutationsgrundCode).NotEmpty().WithMessage("'Grund' darf nicht leer sein.");
            RuleFor(x => x.VmKlientenbudgetStatusCode).NotEmpty().InclusiveBetween(1,3);
        }

        #endregion
    }
}