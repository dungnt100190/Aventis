using Kiss.Infrastructure.Constant;

namespace Kiss.Model
{
    public partial class WshKategorie
    {
        /// <summary>
        /// Gets the WshKategorieID as Enum <see cref="LOVsGenerated.WshKategorie"/>
        /// </summary>
        public LOVsGenerated.WshKategorie WshKategorieEnum
        {
            get { return (LOVsGenerated.WshKategorie)WshKategorieID; }
        }

        public bool IstAbzahlung
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Abzahlung; }
        }

        public bool IstAusgabe
        {
            get { return WshKategorieEnum == LOVsGenerated.WshKategorie.Ausgabe; }
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
    }
}
