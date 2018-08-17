using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Validation;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

using FluentValidation;
using FluentValidation.Results;

namespace Kiss.BL.Wsh.Validation
{
    public class WshGrundbudgetPositionDTOValidator : ValidatorBase<WshGrundbudgetPositionDTO, WshGrundbudgetPositionDTOValidator>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string NON_PLANWERT_RULESET = "NonPlanwert";
        private const string PLANWERT_RULESET = "Planwert";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshGrundbudgetPositionDTOValidator"/> class and validates the entity <see cref="WshGrundbudgetPositionDTO"/> in memory.
        /// </summary>
        public WshGrundbudgetPositionDTOValidator()
        {
            RuleSet(
                NON_PLANWERT_RULESET,
                () =>
                {
                    CommonRules();
                    CheckNonPlanwert();
                });

            RuleSet(
                PLANWERT_RULESET,
                () =>
                {
                    CommonRules();
                    CheckPlanwert();
                });
        }

        #endregion

        #region Methods

        #region Public Methods

        public override ValidationResult Validate(WshGrundbudgetPositionDTO wshGrundbudgetPositionDto)
        {
            if (wshGrundbudgetPositionDto.WshGrundbudgetPosition.Planwert)
            {
                return _instance.Validate(wshGrundbudgetPositionDto, ruleSet: PLANWERT_RULESET);
            }

            return _instance.Validate(wshGrundbudgetPositionDto, ruleSet: NON_PLANWERT_RULESET);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Überprüft, ob es bei einer elektronischen Auszahlung 
        /// einen Zahlungsweg hat.
        /// </summary>
        /// <param name="positionDto"></param>
        /// <param name="kreditoren"></param>
        /// <returns></returns>
        private static bool CheckElektronischeAuszahlung(WshGrundbudgetPositionDTO positionDto, IList<WshGrundbudgetPositionKreditor> kreditoren)
        {
            if (positionDto.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor.Count == 0)
            {
                return false;
            }

            var kreditor = kreditoren.First();

            return kreditor.BaZahlungswegID != null && kreditor.BaZahlungswegID > 0;
        }

        #endregion

        #region Private Methods

        private void CheckNonPlanwert()
        {
            RuleFor(x => x.WshGrundbudgetPosition.WshPeriodizitaetCode).NotNull().WithMessage("Termin darf nicht leer sein.");

            RuleFor(x => x.WshGrundbudgetPosition.WshGrundbudgetPositionKreditor)
                .Must(CheckElektronischeAuszahlung)
                .When(x => x.WshGrundbudgetPosition.KbuAuszahlungArtCode == (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung)
                .WithMessage("Bei einer elektronischen Auszahlung muss der Zahlungsweg angegeben sein.");

            RuleFor(x => x.WshGrundbudgetPosition.WshGrundbudgetPositionDebitor.Count)
                .GreaterThanOrEqualTo(1)
                .When(
                    x =>
                    x.WshGrundbudgetPosition.WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme &&
                    x.WshGrundbudgetPosition.VerwaltungSD)
                .WithMessage("Bei einer abgetretenen Einnahme muss ein Debitor vorhanden sein.");

            RuleFor(x => x.WshGrundbudgetPosition.BetragMonatlich).GreaterThanOrEqualTo(0).WithMessage("Betrag monatlich muss positiv sein.");
            RuleFor(x => x.WshGrundbudgetPosition.BetragMonatlich)
                .NotEqual(0)
                .When(
                    x =>
                    x.WshGrundbudgetPosition.WshPeriodizitaetCode != (int)LOVsGenerated.WshPeriodizitaet.Quartal &&
                    x.WshGrundbudgetPosition.WshPeriodizitaetCode != (int)LOVsGenerated.WshPeriodizitaet.Semester)
                .WithMessage("Betrag monatlich darf nicht 0.00 sein.");

            RuleFor(x => x.WshGrundbudgetPosition.DatumEntscheid)
                .NotNull()
                .When(
                    x =>
                    x.WshGrundbudgetPosition.KbuKonto != null &&
                    x.WshGrundbudgetPosition.KbuKonto.WshSplittingartCode == (int)LOVsGenerated.WshSplittingart.Entscheid)
                .WithMessage("Geben Sie bitte ein Entscheid-Datum an.");

            RuleFor(x => x.WshGrundbudgetPosition.WshKategorieID).IsIn(
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

            RuleFor(x => x.WshGrundbudgetPosition.BetragTotal)
                .NotNull()
                .When(
                    x =>
                    x.WshGrundbudgetPosition.WshPeriodizitaetCode.HasValue &&
                    (x.WshGrundbudgetPosition.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Semester ||
                     x.WshGrundbudgetPosition.WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Quartal))
                .WithMessage("Bei Termin Quartal oder Semester muss der Betrag Total ausgefüllt werden.");
        }

        private void CheckPlanwert()
        {
            RuleFor(x => x.WshGrundbudgetPosition.Planwert).Equals(true);
            RuleFor(x => x.WshGrundbudgetPosition.WshKategorieID).Equals((int)LOVsGenerated.WshKategorie.Ausgabe);
            RuleFor(x => x.WshGrundbudgetPosition.BetragMonatlich).GreaterThanOrEqualTo(0).WithMessage(
                "Betrag monatlich darf nicht negativ sein.");
        }

        private void CommonRules()
        {
            RuleFor(x => x.WshGrundbudgetPosition).NotNull();

            RuleFor(x => x.WshGrundbudgetPosition.FaelligAm)
                .NotNull()
                .When(x => x.IstEinnahmeOrHatFaelligAmPeriodizität)
                .WithMessage("1. Fälligkeit muss angegeben sein.");
        }

        #endregion

        #endregion
    }
}