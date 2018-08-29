namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BFSDossierPerson")]
    public partial class BFSDossierPerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BFSDossierPerson()
        {
            BFSWerts = new HashSet<BFSWert>();
        }

        public int BFSDossierPersonID { get; set; }

        public int BFSDossierID { get; set; }

        public int BFSPersonCode { get; set; }

        public int PersonIndex { get; set; }

        [StringLength(100)]
        public string PersonName { get; set; }

        public int? BaPersonID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BFSDossierPersonTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BFSDossier BFSDossier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSWert> BFSWerts { get; set; }
    }
}
