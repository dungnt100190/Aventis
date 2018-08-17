using Kiss.Model;

using FluentValidation;
using Kiss.Infrastructure.Validation;
using System.Collections.Generic;
using Kiss.Infrastructure.Constant;
using System;


namespace Kiss.BL.Wsh.Validation
{
    public class WshKontoAttributValidator : ValidatorBase<WshKontoAttribut, WshKontoAttributValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshKontoAttributValidator"/> class and validates the entity <see cref="TEntity"/> in memory.
        /// </summary>
        public WshKontoAttributValidator()
        {
            RuleFor(x => x.SysEditModeCode_BetrifftPerson).IsIn(
                new List<int>
                {
                    (int)LOVsGenerated.SysEditMode.Normal,
                    (int)LOVsGenerated.SysEditMode.ReadOnly,
                    (int)LOVsGenerated.SysEditMode.Required,
                });
        }

        #endregion
    }
}