﻿using FluentValidation;

using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Vm.Validation
{
    public class VmPositionValidator : ValidatorBase<VmPosition>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VmPositionValidator"/> class and validates the entity <see cref="VmPosition"/> in memory.
        /// </summary>
        public VmPositionValidator()
        {
            RuleFor(x => x.VmKlientenbudgetID).NotNull();
            //RuleFor(x => x.VmPositionsartID).GreaterThan(0); //...or VmPositionsart.NotNull()

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("'Name' darf nicht leer sein.");

            //Regeln nach Rückmeldung in KBE-1462 deaktiviert
            //RuleFor(x => x.BetragJaehrlich).GreaterThanOrEqualTo(0).WithMessage("'Betrag jährlich' muss grösser als 0 sein.");
            //RuleFor(x => x.BetragMonatlich).GreaterThanOrEqualTo(0).WithMessage("'Betrag monatlich' muss grösser als 0 sein.");
        }

        #endregion
    }
}