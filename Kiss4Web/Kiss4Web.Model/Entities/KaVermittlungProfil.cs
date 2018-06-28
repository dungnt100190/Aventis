using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaVermittlungProfil
    {
        public int KaVermittlungProfilId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? AeussereErscheinungCode { get; set; }
        public string AktuelleTaetigkeit { get; set; }
        public string ArbeitsgebietBemerkungen { get; set; }
        public string ArbeitszeitenCodes { get; set; }
        public int? AusbildungCode { get; set; }
        public int? AusbildungstypWunschCode { get; set; }
        public string Bemerkungen { get; set; }
        public string BesondereFaehigkeiten { get; set; }
        public string BesondereWuensche { get; set; }
        public string BrancheCodes { get; set; }
        public int? DeutschMuendlichCode { get; set; }
        public int? DeutschSchriftlichCode { get; set; }
        public string EinsatzbereichCodes { get; set; }
        public int? Einsatzpensum { get; set; }
        public int? EinsatzpensumBis { get; set; }
        public int? EinsatzpensumVon { get; set; }
        public int? FuehrerausweisCode { get; set; }
        public int? FuehrerausweisKategorieCode { get; set; }
        public DateTime? GespraechDatum { get; set; }
        public string GesundheitBemerkung { get; set; }
        public int? GesundheitCode { get; set; }
        public string GesundheitEinschraenkungen { get; set; }
        public int? GesundheitKoerperlichBewertung { get; set; }
        public int? GesundheitKoerperlichCode { get; set; }
        public int? GesundheitPsychischBewertung { get; set; }
        public int? GesundheitPsychischCode { get; set; }
        public bool InfoAnSderfolgt { get; set; }
        public int? InizioErstgesprVerlaufDokId { get; set; }
        public DateTime? Interview { get; set; }
        public bool IstAngemeldet { get; set; }
        public string KaBetriebCodes { get; set; }
        public int? KaLaufendeBetreibungenCode { get; set; }
        public int? KaLohnabtretungSdcode { get; set; }
        public int? KaNachtarbeitCode { get; set; }
        public bool KannSichAmTelVerstaendigen { get; set; }
        public int? KaSchweizerdeutschCode { get; set; }
        public int? KaVerfuegbarkeitCode { get; set; }
        public int? Kinderbetreuung { get; set; }
        public int? LehrberufCode { get; set; }
        public int? Lehrberuf2Code { get; set; }
        public int? Lehrberuf3Code { get; set; }
        public int? LehrberufWunschCode { get; set; }
        public bool MigrationKa { get; set; }
        public int? MotivationBibipsibewertung { get; set; }
        public int? MotivationBibipsicode { get; set; }
        public int? MotivationInizioCode { get; set; }
        public int? PckenntnisseCode { get; set; }
        public bool Qjextern { get; set; }
        public bool SichtbarSdflag { get; set; }
        public DateTime? Sigespraech { get; set; }
        public int? SigespraechfuehrerinId { get; set; }
        public int? Sprachstandermittlung { get; set; }
        public int? SuchtartCode { get; set; }
        public int? SuchtCode { get; set; }
        public int? TherpieCode { get; set; }
        public string UnterstuetzungInizioCodes { get; set; }
        public string EinschraenkungMo { get; set; }
        public string EinschraenkungDi { get; set; }
        public string EinschraenkungMi { get; set; }
        public string EinschraenkungDo { get; set; }
        public string EinschraenkungFr { get; set; }
        public string EinschraenkungSa { get; set; }
        public string EinschraenkungSo { get; set; }
        public string VermittelbarkeitBemerkung { get; set; }
        public int? VermittelbarkeitBibipcode { get; set; }
        public int? VermittelbarkeitSicode { get; set; }
        public int? VermittlungsgespraechDokId { get; set; }
        public int? ZuverlaessigkeitBewertung { get; set; }
        public int? ZuverlaessigkeitCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaVermittlungProfilTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
