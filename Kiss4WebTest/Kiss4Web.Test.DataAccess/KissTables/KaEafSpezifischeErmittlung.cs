namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaEafSpezifischeErmittlung")]
    public partial class KaEafSpezifischeErmittlung
    {
        public int KaEafSpezifischeErmittlungID { get; set; }

        public int FaLeistungID { get; set; }

        [StringLength(200)]
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

        public int? DocumentID_ProzessVereinbarung { get; set; }

        public int? DocumentID_ProzessSchlussbericht { get; set; }

        public int? DocumentID_InterventionenAufforderung1 { get; set; }

        public int? DocumentID_InterventionenAufforderung2 { get; set; }

        public int? DocumentID_InterventionenAufforderung3 { get; set; }

        public int? DocumentID_InterventionenVereinbarung1 { get; set; }

        public int? DocumentID_InterventionenVereinbarung2 { get; set; }

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
        public byte[] KaEafSpezifischeErmittlungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
