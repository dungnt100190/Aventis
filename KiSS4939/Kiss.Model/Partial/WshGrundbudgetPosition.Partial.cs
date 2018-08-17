using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;

namespace Kiss.Model
{
    public partial class WshGrundbudgetPosition
    {
        #region Constructors

        public WshGrundbudgetPosition()
        {
            //HatBemerkung
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => Bemerkung),
                PropertyName.GetPropertyName(() => HatBemerkung));

            //HatTotalBetrag
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshPeriodizitaetCode),
                PropertyName.GetPropertyName(() => HasTotalBetrag));

            //HatValutaTermin
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshPeriodizitaetCode),
                PropertyName.GetPropertyName(() => HatFaelligAmPeriodizität));

            //IstBewilligt
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshBewilligungStatusCode),
                PropertyName.GetPropertyName(() => IstBewilligt));

            // Kategorie
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => WshKategorieEnum));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstAbzahlung));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstAusgabe));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstEinnahme));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstKuerzung));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstRueckerstattung));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstSanktion));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstVermoegen));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstVerrechnung));
            AddPropertyMapping(
                PropertyName.GetPropertyName(() => WshKategorieID),
                PropertyName.GetPropertyName(() => IstVorabzug));

            // Ich baue mir mein eigenes ChangeTracking
            // Grund: ChangeTracker.OriginalValues merkt sich leider nur Fremdschlüssel
            // Alternative: STE/ChangeTracker umbauen

            //Eine Liste von RuntimePropertyInfo kann nicht serialisiert werden. Deshalb müssen wir es als
            //List<string> abspeichern und nach dem deserialisieren (wenn wir die PropertyInfos zum ersten Mal verwenden) neu holen.
            SubscribePropertyName(PropertyName.GetPropertyName(() => KbuKontoID));
            SubscribePropertyName(PropertyName.GetPropertyName(() => Text));
            SubscribePropertyName(PropertyName.GetPropertyName(() => BaPersonID));
            SubscribePropertyName(PropertyName.GetPropertyName(() => BetragMonatlich));
            SubscribePropertyName(PropertyName.GetPropertyName(() => BetragTotal));
            SubscribePropertyName(PropertyName.GetPropertyName(() => KbuAuszahlungArtCode));
            SubscribePropertyName(PropertyName.GetPropertyName(() => WshPeriodizitaetCode));
            SubscribePropertyName(PropertyName.GetPropertyName(() => FaelligAm));
            SubscribePropertyName(PropertyName.GetPropertyName(() => Bemerkung));
            SubscribePropertyName(PropertyName.GetPropertyName(() => VerwaltungSD));
            SubscribePropertyName(PropertyName.GetPropertyName(() => DatumVon));
        }

        #endregion

        #region Properties

        /// <summary>
        /// todo: refactoring in DTO. Why?
        /// </summary>
        public bool HasTotalBetrag
        {
            get
            {
                return WshPeriodizitaetCode.HasValue
                       && (WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Quartal ||
                           WshPeriodizitaetCode.Value == (int)LOVsGenerated.WshPeriodizitaet.Semester);
            }
        }

        /// <summary>
        /// Von Bemerkung abgeleitetes Property. Liefert <c>true</c> wenn eine Bemerkung erfasst wurde. Sonst <c>false</c>.
        /// </summary>
        public bool HatBemerkung
        {
            get { return !string.IsNullOrEmpty(Bemerkung); }
        }

        /// <summary>
        /// Prüft, ob 'Valuta', 'Quartal' oder 'Semester' als Periodizität ausgewählt wurde.
        /// </summary>
        public bool HatFaelligAmPeriodizität
        {
            get
            {
                return WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Valuta ||
                       WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Quartal ||
                       WshPeriodizitaetCode == (int)LOVsGenerated.WshPeriodizitaet.Semester;
            }
        }

        public bool IstAbzahlung
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Abzahlung; }
        }

        public bool IstAusgabe
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Ausgabe; }
        }

        /// <summary>
        /// Von WshBewilligungSTatusCode abgeleitetes Property. Liefert <c>true</c> wenn der Code '5: BewilligungErteilt' gesetzt ist. Sonst <c>false</c>.
        /// </summary>
        public bool IstBewilligt
        {
            get { return WshBewilligungStatusCode == (int)LOVsGenerated.WshBewilligungStatus.BewilligungErteilt; }
        }

        public bool IstEinnahme
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Einnahme; }
        }

        public bool IstKuerzung
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Kuerzung; }
        }

        public bool IstRueckerstattung
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Rueckerstattung; }
        }

        public bool IstSanktion
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Sanktion; }
        }

        public bool IstVermoegen
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Vermoegen; }
        }

        public bool IstVerrechnung
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Verrechnung; }
        }

        public bool IstVorabzug
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Vorabzug; }
        }

        public string PlanwertString
        {
            get
            {
                if (Planwert)
                {
                    return "P";
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the WshKategorieID as Enum <see cref="LOVsGenerated.WshKategorie"/>
        /// </summary>
        public LOVsGenerated.WshKategorie WshKategorieEnum
        {
            get { return (LOVsGenerated.WshKategorie)WshKategorieID; }
        }

        #endregion
    }
}