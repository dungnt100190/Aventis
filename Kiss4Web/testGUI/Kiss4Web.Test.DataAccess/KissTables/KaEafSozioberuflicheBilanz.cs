namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaEafSozioberuflicheBilanz")]
    public partial class KaEafSozioberuflicheBilanz
    {
        public int KaEafSozioberuflicheBilanzID { get; set; }

        public int FaLeistungID { get; set; }

        [StringLength(200)]
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

        public string AufnahmeZielsetzungenRAV { get; set; }

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

        public int? DocumentID_ProzessErmittlungsprogramm { get; set; }

        public int? DocumentID_ProzessFaehigkeitsprofilMelba { get; set; }

        public int? DocumentID_ProzessSchlussbericht { get; set; }

        public int? DocumentID_ProzessFaehigkeitsAnalyse { get; set; }

        public int? DocumentID_ProzessBewerbungskompetenz { get; set; }

        public int? DocumentID_InterventionenVereinbarung { get; set; }

        public int? DocumentID_InterventionenVerwarnung1 { get; set; }

        public int? DocumentID_InterventionenVerwarnung2 { get; set; }

        public int? DocumentID_InterventionenProgrammabbruch { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaEafSozioberuflicheBilanzTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
