using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaEafSpezifischeErmittlung
    {
        public int KaEafSpezifischeErmittlungId { get; set; }
        public int FaLeistungId { get; set; }
        public string AnwesendTeilzeit { get; set; }
        public string Zielsetzungen { get; set; }
        public bool ProzessEinladungErfolgt { get; set; }
        public bool ProzessVereinbarung { get; set; }
        public DateTime? ProzessDatumVereinbarung { get; set; }
        public bool ProzessAustauschgespraech1 { get; set; }
        public DateTime? ProzessDatumAustauschgespraech1 { get; set; }
        public bool ProzessAustauschgespraech2 { get; set; }
        public DateTime? ProzessDatumAustauschgespraech2 { get; set; }
        public bool ProzessAustauschgespraech3 { get; set; }
        public DateTime? ProzessDatumAustauschgespraech3 { get; set; }
        public bool ProzessAbschlussgespraechErfolgt { get; set; }
        public bool ProzessSchlussbericht { get; set; }
        public bool ProzessAustrittsbefragungErfolgt { get; set; }
        public string ProzessBemerkungenAbschluss { get; set; }
        public DateTime? InterventionenDatumAufforderung1 { get; set; }
        public string InterventionenAufforderung1 { get; set; }
        public DateTime? InterventionenDatumAufforderung2 { get; set; }
        public string InterventionenAufforderung2 { get; set; }
        public DateTime? AustrittDatum { get; set; }
        public int? KaEafAustrittsgrundCode { get; set; }
        public int? KaEafAustrittsgrundMassnahmeBeendetCode { get; set; }
        public int? KaEafAustrittsgrundAbbruchAnbieterCode { get; set; }
        public int? DocumentIdProzessVereinbarung { get; set; }
        public int? DocumentIdProzessSchlussbericht { get; set; }
        public int? DocumentIdInterventionenAufforderung1 { get; set; }
        public int? DocumentIdInterventionenAufforderung2 { get; set; }
        public int? DocumentIdInterventionenAufforderung3 { get; set; }
        public int? DocumentIdInterventionenVereinbarung1 { get; set; }
        public int? DocumentIdInterventionenVereinbarung2 { get; set; }
        public int? DocumentIdInterventionenVerwarnung1 { get; set; }
        public int? DocumentIdInterventionenVerwarnung2 { get; set; }
        public int? DocumentIdInterventionenProgrammabbruch { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KaEafSpezifischeErmittlungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
