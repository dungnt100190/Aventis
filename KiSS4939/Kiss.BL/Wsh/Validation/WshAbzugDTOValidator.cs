using System.Linq;

using Kiss.Model.DTO.Wsh;

using FluentValidation;

namespace Kiss.BL.Wsh.Validation
{
    public class WshAbzugDTOValidator : ValidatorBase<WshAbzugDTO, WshAbzugDTOValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAbzugDTOValidator"/> class and validates the entity <see cref="WshAbzugDTO"/> in memory.
        /// </summary>
        public WshAbzugDTOValidator()
        {
            RuleFor(x => x.WshAbzug).NotNull();

            // Betrag grösser als 0
            RuleFor(x => x.WshAbzug.WshGrundbudgetPosition.BetragMonatlich)
                .GreaterThan(0)
                .When(x => x.WshAbzug != null && (!x.WshAbzug.WshGrundbudgetPosition.IstRueckerstattung || (x.WshAbzugDetailDto != null &&  x.WshAbzugDetailDto.Any())))
                .WithMessage("Betrag muss grösser als 0 sein.");

            // Totalbetrag grösser als 0 bei nicht monatlichWiederholende Abzuge
            RuleFor(x => x.WshAbzug.WshGrundbudgetPosition.BetragTotal)
                .NotNull()
                .WithMessage("Total muss grösser als 0 sein.")
                .GreaterThan(0)
                .When(x => x.WshAbzug != null && !x.WshAbzug.MonatlichWiederholend)
                .WithMessage("Total muss grösser als 0 sein.");

            // WshAbzug validieren
            RuleFor(x => x.WshAbzug).SetValidator(new WshAbzugValidator());
        }

        #endregion
    }
}