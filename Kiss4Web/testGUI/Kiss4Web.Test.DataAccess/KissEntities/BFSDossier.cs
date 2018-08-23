namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BFSDossier")]
    public partial class BFSDossier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BFSDossier()
        {
            BFSDossierPersons = new HashSet<BFSDossierPerson>();
            BFSWerts = new HashSet<BFSWert>();
        }

        public int BFSDossierID { get; set; }

        public int BFSKatalogVersionID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int LaufNr { get; set; }

        public int ZustaendigeGemeinde { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int Jahr { get; set; }

        public bool Stichtag { get; set; }

        public int? BFSDossierStatusCode { get; set; }

        public int BFSLeistungsartCode { get; set; }

        public DateTime? ImportDatum { get; set; }

        public DateTime? PlausibilisierungDatum { get; set; }

        public DateTime? ExportDatum { get; set; }

        public string XML { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BFSDossierTS { get; set; }

        public virtual BFSKatalogVersion BFSKatalogVersion { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSDossierPerson> BFSDossierPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSWert> BFSWerts { get; set; }
    }
}
