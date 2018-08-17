using Kiss.Model;

using FluentValidation;
using FluentValidation.Results;

namespace Kiss.BL.Wsh.Validation
{
    public class WshAbzugValidator : ValidatorBase<WshAbzug, WshAbzugValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAbzugValidator"/> class and validates the entity <see cref="WshAbzug"/> in memory.
        /// </summary>
        public WshAbzugValidator()
        {
            Custom(CheckAbschluss);
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static ValidationFailure CheckAbschluss(WshAbzug wshAbzug)
        {
            var datum = wshAbzug.AbschlussDatum == null;
            var grund = string.IsNullOrEmpty(wshAbzug.AbschlussGrund);
            var aktion = wshAbzug.WshAbzugAbschlussAktionCode == null;

            if (datum && grund && aktion || !datum && !grund && !aktion)
            {
                return null;
            }

            return new ValidationFailure(null, "Es müssen alle Abschluss-Felder ausgefüllt sein.");
        }

        #endregion

        #endregion
    }
}