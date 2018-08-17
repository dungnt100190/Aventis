using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS.Lookup.BL.DTO;

using FluentValidation;

namespace KiSS.Lookup.BL.Validation
{
    /// <summary>
    /// Class to validate the content of a <see cref="Log"/> object
    /// </summary>
    public class LogValidator : AbstractValidator<Log>
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="LogValidator"/> object and set the validation rules
        /// </summary>
        public LogValidator()
        {
            RuleFor(l => l.Creator).NotEmpty();
            RuleFor(l => l.Modifier).NotEmpty();
            RuleFor(l => l.Message).NotEmpty();
            RuleFor(l => l.Source).NotEmpty();
            RuleFor(l => l.Level).GreaterThan(0);
        }

        #endregion
    }
}