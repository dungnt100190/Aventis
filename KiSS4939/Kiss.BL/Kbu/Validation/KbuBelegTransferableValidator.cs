using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Validation;
using Kiss.Model;

using FluentValidation;

namespace Kiss.BL.Kbu.Validation
{
    public class KbuBelegTransferableValidator : ValidatorBase<KbuBeleg, KbuBelegTransferableValidator>
    {
        #region Constructors

        /// <summary>
        /// Validator für an PSCD transferierbarer KbuBeleg.
        /// </summary>
        public KbuBelegTransferableValidator()
        {
            //Belegstatuscode
            RuleFor(x => x.KbuBelegstatusCode).NotNull().Equal((int)LOVsGenerated.KbuBelegstatus.Verbucht).WithMessage("Belegstatus muss 'verbucht' sein");

            //BelegKreis darf nicht leer sein
            RuleFor(x => x.KbuBelegKreisCode).NotNull();

            //Belegnummer muss gelöst sein
            RuleFor(x => x.BelegNr).NotNull();

            //Valutadatum darf nicht leer sein
            RuleFor(x => x.ValutaDatum).NotNull();

            //Belegdatum darf nicht leer sein
            RuleFor(x => x.BelegDatum).NotNull();

            //Beleg darf noch nicht transferiert sein
            RuleFor(x => x.TransferDatum).Equal((System.DateTime?)null);

            //Belegartcode
            RuleFor(x => x.KbuBelegartCode).NotNull().IsIn(
                new List<int>(new int[] { (int)LOVsGenerated.KbuBelegart.Auszahlung, (int)LOVsGenerated.KbuBelegart.Einzahlung }));

            //mindestens zwei Detailpositionen müssen vorhanden sein: genau ein Kreditor und mindestens eine Aufwandsbuchung
            RuleFor(x => x.KbuBelegPosition.Count).GreaterThanOrEqualTo(2).When(x => x.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung).WithMessage("Bei einer Auszahlung müssen mindestes 2 Belegpositionen vorhanden sein");

            //genau ein Kreditor
            RuleFor(x => x.KbuBelegKreditor.Count).Equal(1).When(x => x.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung).WithMessage("Bei einer Auszahlung muss genau ein Belegkreditor vorhanden sein");

            //Einzahlungsschein darf nicht leer sein
            RuleFor(x => x.KbuBelegKreditor.Single().BgEinzahlungsscheinCode).NotNull().When(x => x.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung);

            //minimale Begünstigtenangaben
            RuleFor(x => x.KbuBelegKreditor.Single().BeguenstigtName).NotNull().When(x => x.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung);
            RuleFor(x => x.KbuBelegKreditor.Single().BeguenstigtStrasse).NotNull().When(x => x.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung);
            RuleFor(x => x.KbuBelegKreditor.Single().BeguenstigtPLZ).NotNull().When(x => x.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung);
            RuleFor(x => x.KbuBelegKreditor.Single().BeguenstigtOrt).NotNull().When(x => x.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Auszahlung);

            //genau ein Konto
            RuleFor(x => x.KbuBelegPosition.Count(pos => pos.PositionImBeleg > 0 && pos.KbuKonto == null)).Equal(0).WithMessage("Kostenart ist nicht definiert");

            //Sachkonto und Innenauftrag-Datensatz vorhanden
            // Bei Einzahlungsverbuchungen braucht es für die Klärfallposition (=Hauptposition) keinen Innenauftrag
            RuleFor(x => x.KbuBelegPosition.Count(pos => pos.PositionImBeleg > 0 && (pos.SstPscdBelegPosition.Count != 1 || (!pos.HauptPosition && pos.SstPscdBelegPosition.Single().Innenauftrag == null)))).Equal(0).WithMessage("Sachkonto und Innenauftrag müssen definiert sein");

            //Zahlstapel-Referenz gesetzt bei Zahlungseingangsverbuchungen
            RuleFor(x => x.KbuZahlungseingang)
                .Must(ze => ze.SstZahlungseingangSingleItem != null &&
                      ze.SstZahlungseingangSingleItem.PAYMENT_LOT != null &&
                      ze.SstZahlungseingangSingleItem.PAYMENT_LOT_POS != null)
                .When(pos => pos.KbuBelegartCode == (int)LOVsGenerated.KbuBelegart.Einzahlung)
                .WithMessage("Bei Einzahlungsverbuchungen muss eine Referenz zu Zahlstapel und -Position möglich sein");
        }

        #endregion
    }
}