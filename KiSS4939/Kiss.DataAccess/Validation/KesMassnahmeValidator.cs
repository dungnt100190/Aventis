using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

using FluentValidation;
using Kiss.DataAccess.LocalResources;
using Kiss.DataAccess.Properties;
using Kiss.DbContext;
using Kiss.Infrastructure;

namespace Kiss.DataAccess.Validation
{
    public class KesMassnahmeValidator : ValidatorBase<KesMassnahme>
    {
        public KesMassnahmeValidator()
        {
            //Allegmeinen Fehlermeldungen im Resources
            //Spezifischen Kes-Spez. in KesRes

            // Prüfung ob DatumVon < DatumBis
            RuleFor(x => x.DatumBis.Value)
                .GreaterThan(x => x.DatumVon.Value)
                .When(x => x.DatumVon.HasValue && x.DatumBis.HasValue)
                .WithMessage(Resources.DatumBisGroesserDatumVon);

            // Wenn es ein Änderungsdatum gibt brauchts auch einen Änderungsgrund
            RuleFor(x => x.KesAenderungsgrundCode)
                .NotEmpty()
                .When(x => x.AenderungVom_Datum.HasValue)
                .WithMessage(Resources.AenderungsgrundMuss);

            RuleFor(x => x.KesAenderungsgrundCode)
                 .GreaterThan(0)
                 .When(x => x.AenderungVom_Datum.HasValue && x.KesAenderungsgrundCode != null)
                 .WithMessage(Resources.AenderungsgrundMuss);

            // Wenn ein Bis-Datum existiert brauchts auch einen Aufhebungsgrund
            RuleFor(x => x.KesAufhebungsgrundCode)
                .NotEmpty()
                .When(x => x.DatumBis.HasValue)
                .WithMessage(Resources.AufhebungsgrundMuss);

            RuleFor(x => x.KesAufhebungsgrundCode)
                .GreaterThan(0)
                .When(x => x.DatumBis.HasValue && x.KesAufhebungsgrundCode != null)
                .WithMessage(Resources.AufhebungsgrundMuss);

            // Falls die Übernahme ausgefüllt ist muss eine dazugehörige Adresse oder eine KES-Behörde angegeben werden
            RuleFor(x => x.UebernahmeVon_Ort)
                .NotEmpty()
                .When(x => x.UebernahmeVon_Datum != null && x.UebernahmeVon_KesBehoerdeID == null)
                .WithMessage(KesRes.UebernahmeOrtBehoerdeFehlt);

            // Falls die Übertragung ausgefüllt ist muss eine dazugehörige Adresse oder eine KES-Behörde angegeben werden
            RuleFor(x => x.UebertragungAn_Ort)
                .NotEmpty()
                .When(x => x.UebertragungAn_Datum != null && x.UebertragungAn_KesBehoerdeID == null)
                .WithMessage(KesRes.UebertragungOrtBehoerdeFehlt);
        }

        protected override IEnumerable<DbValidationError> ValidateOnDB(DbEntityEntry<KesMassnahme> entityEntry, System.Data.Entity.DbContext context)
        {
            var massnahme = entityEntry.Entity;

            // Falls die Übernahme ausgefüllt ist, müssen der Kanton der Adresse sowie der Kanton der KES-Behörde übereinstimmen
            if (massnahme.UebernahmeVon_Kanton != null && massnahme.UebernahmeVon_KesBehoerdeID != null)
            {
                var behoerdeSet = context.Set<KesBehoerde>();
                var uebernahmeVonBehoerde = behoerdeSet.Find(massnahme.UebernahmeVon_KesBehoerdeID);
                if (massnahme.UebernahmeVon_Kanton != uebernahmeVonBehoerde.Kanton)
                {
                    yield return new DbValidationError(PropertyName.GetPropertyName(() => massnahme.UebernahmeVon_Kanton), KesRes.UebernahmeKantonOrtBehoerdeNichtUebereinstimmend);
                }
            }

            // Falls die Übertragung ausgefüllt ist, müssen der Kanton der Adresse sowie der Kanton der KES-Behörde übereinstimmen
            if (massnahme.UebertragungAn_Kanton != null && massnahme.UebertragungAn_KesBehoerdeID != null)
            {
                var behoerdeSet = context.Set<KesBehoerde>();
                var uebertragungAnBehoerde = behoerdeSet.Find(massnahme.UebertragungAn_KesBehoerdeID);
                if (massnahme.UebertragungAn_Kanton != uebertragungAnBehoerde.Kanton)
                {
                    yield return new DbValidationError(PropertyName.GetPropertyName(() => massnahme.UebertragungAn_Kanton), KesRes.UebertragungKantonOrtBehoerdeNichtUebereinstimmend);
                }
            }
        }
    }
}