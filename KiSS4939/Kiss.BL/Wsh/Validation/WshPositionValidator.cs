using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Validation;
using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Wsh.Validation
{
    public class WshPositionValidator : ValidatorBase<WshPosition, WshPositionValidator>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshPositionValidator"/> class and validates the entity <see cref="WshPosition"/> in memory.
        /// </summary>
        public WshPositionValidator()
        {
            RuleFor(x => x.KbuKontoID).GreaterThan(0).WithMessage("Es muss eine Kostenart ausgewählt sein.");
            RuleFor(x => x.WshKategorieID).IsIn(
                new List<int>
                {
                    (int)LOVsGenerated.WshKategorie.Abzahlung,
                    (int)LOVsGenerated.WshKategorie.Ausgabe,
                    (int)LOVsGenerated.WshKategorie.Einnahme,
                    (int)LOVsGenerated.WshKategorie.Kuerzung,
                    (int)LOVsGenerated.WshKategorie.Vermoegen,
                    (int)LOVsGenerated.WshKategorie.Verrechnung,
                    (int)LOVsGenerated.WshKategorie.Vorabzug,
                    (int)LOVsGenerated.WshKategorie.Sanktion,
                    (int)LOVsGenerated.WshKategorie.Rueckerstattung,
                    (int)LOVsGenerated.WshKategorie.Unbekannt,                    
                    
                });
            RuleFor(x => x.VerwPeriodeVon).IsBetween(Constant.SqlDateTimeMin, Constant.SqlDateTimeMax);

            //Betrag muss grösser als 0 sein.
            //Sanktionen, Rückerstattungen können einen Betrag von 0 aufweisen. Siehe User-Story 7472-019.
            RuleFor(x => x.Betrag).GreaterThan(0).When(
                x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe
                || x.WshPositionID == (int)LOVsGenerated.WshKategorie.Einnahme
               ).WithMessage("Betrag muss grösser als 0 sein.");

            RuleFor(x => x.Betrag).GreaterThanOrEqualTo(0).WithMessage("Betrag darf nicht negativ sein.");

            RuleFor(x => x.VerwPeriodeBis).IsBetween(Constant.SqlDateTimeMin, Constant.SqlDateTimeMax);
            RuleFor(x => x.Text).NotNull().NotEmpty().WithMessage("Text darf nicht leer sein.");

            RuleFor(x => x.WshPositionKreditor.Count).GreaterThanOrEqualTo(1).When(
                x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe).WithMessage(
                    "Bei einer Auszahlung muss ein Kreditor vorhanden sein.");

            RuleFor(x => x.WshPositionKreditor)
                .Must(CheckElektronischeAuszahlung).When(x => x.KbuAuszahlungArtCode == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
                .WithMessage("Bei einer elektronischen Auszahlung muss der Zahlungsweg angegeben sein.");

            RuleFor(x => x.WshPositionDebitor.Count).GreaterThanOrEqualTo(1).When(
                x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme && x.VerwaltungSD).WithMessage(
                    "Bei einer abgetretenen Einnahme muss ein Debitor vorhanden sein.");

            RuleFor(x => x.FaelligAm).NotNull().Must(x => x.HasValue && x.Value >= Constant.SqlDateTimeMin).
                                                When(x => (x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe ||
                                                           x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme) &&
                                                           x.WshPeriodizitaetCode.HasValue &&
                                                           !Kbu.KbuZahlungslaufValutaService.IsWshPeriodizitaetCalculated((LOVsGenerated.WshPeriodizitaet)x.WshPeriodizitaetCode.Value));

            RuleFor(x => x.BetragTotal).NotNull().When(
                x => x.WshPeriodizitaetCode.HasValue && (x.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Semester
                    || x.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Quartal)).WithMessage("Bei Termin Quartal oder Semester muss der Betrag Total ausgefüllt werden.");

            RuleFor(x => x.WshPeriodizitaetCode).IsIn(
                new List<int?>
                {
                    null,
                    (int) LOVsGenerated.WshPeriodizitaet._1xProMonat,
                    (int) LOVsGenerated.WshPeriodizitaet._14Taeglich,
                    (int) LOVsGenerated.WshPeriodizitaet._2xProMonat,
                    (int) LOVsGenerated.WshPeriodizitaet.Valuta,
                    (int) LOVsGenerated.WshPeriodizitaet.Wochentage,
                    (int) LOVsGenerated.WshPeriodizitaet.Woechentlich,
                }
                ).When(x => x.WshGrundbudgetPositionID.HasValue == false).WithMessage("Positionen mit Termin Quartal und Semester können nur im Grundbudget erstellt werden.");

        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Überprüft, ob es bei einer elektronischen Auszahlung 
        /// einen Zahlungsweg hat.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="kreditoren"></param>
        /// <returns></returns>
        private bool CheckElektronischeAuszahlung(WshPosition position, IList<WshPositionKreditor> kreditoren)
        {
            if (position.WshPositionKreditor.Count == 0)
            {
                return false;
            }
            var kreditor = kreditoren.First();
            if (kreditor.BaZahlungswegID == null || kreditor.BaZahlungswegID <= 0)
            {
                return false;
            }
            return true;
        }

        #endregion

        #endregion
    }
}