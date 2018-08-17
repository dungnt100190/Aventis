using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Wsh.Validation
{
    public class WshGrundbudgetPositionKreditorValidator : ValidatorBase<WshGrundbudgetPositionKreditor, WshGrundbudgetPositionKreditorValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshGrundbudgetPositionKreditorValidator"/> class and validates the entity <see cref="WshGrundbudgetPositionKreditor"/> in memory.
        /// </summary>
        public WshGrundbudgetPositionKreditorValidator()
        {
            RuleFor(x => x.BaZahlungswegID).Must(CheckDbConstraint).WithMessage(@"Eine der folgenden Informationen muss angegeben werden: Zahlungsweg, Referenznummer, Mitteilungszeile 1, 2, 3 oder 4");
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Db Constraint wird schon im Memory geprüft:
        ///  ALTER TABLE [dbo].[WshGrundbudgetPositionKreditor]  WITH CHECK ADD  CONSTRAINT [CK_WshGrundbudgetPositionKreditor_AtLeastOneInformation] CHECK  (([BaZahlungswegID] IS NOT NULL OR [ReferenzNummer] IS NOT NULL OR [MitteilungZeile1] IS NOT NULL OR [MitteilungZeile2] IS NOT NULL OR [MitteilungZeile3] IS NOT NULL OR [MitteilungZeile4] IS NOT NULL))
        /// </summary>
        /// <param name="kreditor"></param>
        /// <param name="baZahlungswegId"></param>
        /// <returns></returns>
        private bool CheckDbConstraint(WshGrundbudgetPositionKreditor kreditor, int? baZahlungswegId)
        {
            if ((kreditor.BaZahlungswegID == null || kreditor.BaZahlungswegID <= 0)
               && kreditor.ReferenzNummer == null
               && kreditor.MitteilungZeile1 == null
               && kreditor.MitteilungZeile2 == null
               && kreditor.MitteilungZeile3 == null
               && kreditor.MitteilungZeile4 == null)
            {
                return false;
            }
            return true;
        }

        #endregion

        #endregion
    }
}