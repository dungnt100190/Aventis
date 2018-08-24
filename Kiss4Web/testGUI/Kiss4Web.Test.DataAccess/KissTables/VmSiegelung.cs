namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmSiegelung")]
    public partial class VmSiegelung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmSiegelung()
        {
            VmErbes = new HashSet<VmErbe>();
        }

        public int VmSiegelungID { get; set; }

        public int FaLeistungID { get; set; }

        public bool? Gesperrt { get; set; }

        public int? UserID { get; set; }

        public int? BezirkNr { get; set; }

        public int? LaufNr { get; set; }

        public int? Jahr { get; set; }

        public DateTime? TodesmeldungDatum { get; set; }

        public DateTime? SiegelungsDatum { get; set; }

        public bool? SiegelungsFristEingehalten { get; set; }

        public DateTime? VersandDatum { get; set; }

        public bool? KopieErbschaftsdienst { get; set; }

        public bool? KopieTestamentsdienst { get; set; }

        [StringLength(100)]
        public string KopieAndere { get; set; }

        public int? VerfuegungsSperren { get; set; }

        public int? Durchsuchungen { get; set; }

        [StringLength(50)]
        public string PliQuittung { get; set; }

        public bool? GesuchUeBestattung { get; set; }

        public bool? Ausschlagung { get; set; }

        public int? VmErbschaftInventarCode { get; set; }

        public int? NotarID { get; set; }

        [StringLength(100)]
        public string MassaVerwalter { get; set; }

        public DateTime? EntsiegelungsDatum { get; set; }

        public bool? OhneGebuehr { get; set; }

        [StringLength(50)]
        public string RechnungsNr { get; set; }

        public DateTime? RechnungsDatum { get; set; }

        [Column(TypeName = "money")]
        public decimal? RechnungsBetrag { get; set; }

        [StringLength(100)]
        public string RechnungAn { get; set; }

        public int? SiegelungsProtokollDokID { get; set; }

        public bool? SDabgeschlossen { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmSiegelungTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErbe> VmErbes { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
