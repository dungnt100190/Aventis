namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaKategorisierungEksProdukt")]
    public partial class FaKategorisierungEksProdukt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaKategorisierungEksProdukt()
        {
            FaKategorisierungs = new HashSet<FaKategorisierung>();
        }

        public int FaKategorisierungEksProduktID { get; set; }

        public int OrgUnitID { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        [Required]
        [StringLength(50)]
        public string ShortText { get; set; }

        public int FaKategorieCode { get; set; }

        public int? Frist { get; set; }

        public int FaKategorisierungEksProduktFristTypCode { get; set; }

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
        public byte[] FaKategorisierungEksProduktTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaKategorisierung> FaKategorisierungs { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }
    }
}
