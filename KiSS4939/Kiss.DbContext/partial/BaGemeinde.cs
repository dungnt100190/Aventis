

namespace Kiss.DbContext
{
    public partial class BaGemeinde : IAutoIdentityEntity<int>
    {
        // HACK
        public int AutoIdentityID
        {
            get { return BaGemeindeID; }
        }

        public bool ArePropertiesSame(BaGemeinde other)
        {
            return BezirkAenderungDatum.Equals(other.BezirkAenderungDatum) &&
                   BezirkAufhebungDatum.Equals(other.BezirkAufhebungDatum) &&
                   BezirkAufhebungModus == other.BezirkAufhebungModus &&
                   BezirkAufhebungNummer == other.BezirkAufhebungNummer &&
                   BezirkAufnahmeDatum.Equals(other.BezirkAufnahmeDatum) &&
                   BezirkAufnahmeModus == other.BezirkAufnahmeModus &&
                   BezirkAufnahmeNummer == other.BezirkAufnahmeNummer &&
                   BezirkCode == other.BezirkCode &&
                   BezirkEintragArt == other.BezirkEintragArt &&
                   BezirkName.Equals(other.BezirkName) &&
                   BezirkNameLang.Equals(other.BezirkNameLang) &&
                   GemeindeAenderungDatum.Equals(other.GemeindeAenderungDatum) &&
                   GemeindeAufhebungDatum.Equals(other.GemeindeAufhebungDatum) &&
                   GemeindeAufhebungModus == other.GemeindeAufhebungModus &&
                   GemeindeAufhebungNummer == other.GemeindeAufhebungNummer &&
                   GemeindeAufnahmeDatum.Equals(other.GemeindeAufnahmeDatum) &&
                   GemeindeAufnahmeModus == other.GemeindeAufnahmeModus &&
                   GemeindeAufnahmeNummer == other.GemeindeAufnahmeNummer &&
                   GemeindeEintragArt == other.GemeindeEintragArt &&
                   GemeindeHistorisierungID == other.GemeindeHistorisierungID &&
                   GemeindeStatus == other.GemeindeStatus &&
                   Kanton.Equals(other.Kanton) &&
                   KantonID == other.KantonID &&
                   KantonNameLang.Equals(other.KantonNameLang) &&
                   Name.Equals(other.Name) &&
                   NameLang.Equals(other.NameLang);
        }
    }
}
