using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaEafSozioberuflicheBilanz
    {
        public int KaEafSozioberuflicheBilanzId { get; set; }
        public int FaLeistungId { get; set; }
        public string AnwesendTeilzeit { get; set; }
        public string Schwerpunkte { get; set; }
        public bool ProzessEinladungErfolgt { get; set; }
        public bool ProzessAufnahmeverfahrenErfolgt { get; set; }
        public bool ProzessErmittlungsprogrammErstellt { get; set; }
        public bool ProzessFaehigkeitsprofilMelba { get; set; }
        public bool ProzessZwischengespraech { get; set; }
        public DateTime? ProzessDatumZwischengespraech { get; set; }
        public bool ProzessVerzahnungsgespraech1 { get; set; }
        public DateTime? ProzessDatumVerzahnungsgespraech1 { get; set; }
        public bool ProzessVerzahnungsgespraech2 { get; set; }
        public DateTime? ProzessDatumVerzahnungsgespraech2 { get; set; }
        public bool ProzessVerzahnungsgespraech3 { get; set; }
        public DateTime? ProzessDatumVerzahnungsgespraech3 { get; set; }
        public bool ProzessAbschlussgespraechErfolgt { get; set; }
        public bool ProzessSchlussbericht { get; set; }
        public bool ProzessFaehigkeitsAnalyse { get; set; }
        public bool ProzessBewerbungskompetenz { get; set; }
        public bool ProzessAustrittsbefragungErfolgt { get; set; }
        public string ProzessBemerkungenAbschluss { get; set; }
        public string AufnahmeZielsetzungenRav { get; set; }
        public string AufnahmeErgebnisseInterview { get; set; }
        public string AufnahmeErgebnisseBewerbung { get; set; }
        public string AufnahmeErgebnisseAssessment { get; set; }
        public string AufnahmeErgebnisseWerkstatt { get; set; }
        public DateTime? InterventionenDatumAufforderung { get; set; }
        public string InterventionenAufforderung { get; set; }
        public DateTime? AustrittDatum { get; set; }
        public int? KaEafAustrittsgrundCode { get; set; }
        public int? KaEafAustrittsgrundMassnahmeBeendetCode { get; set; }
        public int? KaEafAustrittsgrundAbbruchAnbieterCode { get; set; }
        public int? DocumentIdProzessErmittlungsprogramm { get; set; }
        public int? DocumentIdProzessFaehigkeitsprofilMelba { get; set; }
        public int? DocumentIdProzessSchlussbericht { get; set; }
        public int? DocumentIdProzessFaehigkeitsAnalyse { get; set; }
        public int? DocumentIdProzessBewerbungskompetenz { get; set; }
        public int? DocumentIdInterventionenVereinbarung { get; set; }
        public int? DocumentIdInterventionenVerwarnung1 { get; set; }
        public int? DocumentIdInterventionenVerwarnung2 { get; set; }
        public int? DocumentIdInterventionenProgrammabbruch { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaEafSozioberuflicheBilanzTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
