namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BFSKatalogVersion")]
    public partial class BFSKatalogVersion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BFSKatalogVersion()
        {
            BFSDossiers = new HashSet<BFSDossier>();
            BFSFrages = new HashSet<BFSFrage>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BFSKatalogVersionID { get; set; }

        public int? Jahr { get; set; }

        [StringLength(50)]
        public string PlausexVersion { get; set; }

        public string DossierXML { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSDossier> BFSDossiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSFrage> BFSFrages { get; set; }
    }
}
