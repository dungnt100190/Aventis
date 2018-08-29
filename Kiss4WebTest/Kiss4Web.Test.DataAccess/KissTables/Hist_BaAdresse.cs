namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hist_BaAdresse
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaAdresseID { get; set; }

        public int? BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? UserID { get; set; }

        public int? PlatzierungInstID { get; set; }

        public int? VmMandantID { get; set; }

        public int? VmPriMaID { get; set; }

        public int? KaBetriebID { get; set; }

        public int? KaBetriebKontaktID { get; set; }

        public int? BaLandID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public bool AusEinwohnerregister { get; set; }

        public bool Gesperrt { get; set; }

        public int? AdresseCode { get; set; }

        [StringLength(200)]
        public string CareOf { get; set; }

        [StringLength(200)]
        public string Zusatz { get; set; }

        [StringLength(200)]
        public string ZuhandenVon { get; set; }

        [StringLength(100)]
        public string Strasse { get; set; }

        public int? StrasseCode { get; set; }

        [StringLength(10)]
        public string HausNr { get; set; }

        [StringLength(100)]
        public string Postfach { get; set; }

        public bool PostfachOhneNr { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        public int? OrtschaftCode { get; set; }

        [StringLength(10)]
        public string Kanton { get; set; }

        [StringLength(100)]
        public string Bezirk { get; set; }

        public string Bemerkung { get; set; }

        [StringLength(100)]
        public string InstitutionName { get; set; }

        public int? PlatzierungsartCode { get; set; }

        public int? WohnStatusCode { get; set; }

        public int? WohnungsgroesseCode { get; set; }

        public int? QuartierCode { get; set; }

        public int? MigrationKA { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        public int? VerID_DELETED { get; set; }
    }
}
