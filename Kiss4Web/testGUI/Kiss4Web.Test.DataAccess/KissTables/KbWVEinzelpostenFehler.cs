namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbWVEinzelpostenFehler")]
    public partial class KbWVEinzelpostenFehler
    {
        public int KbWVEinzelpostenFehlerID { get; set; }

        public int KbWVLaufID { get; set; }

        public int KbBuchungKostenartID { get; set; }

        public int BaPersonID { get; set; }

        [Required]
        [StringLength(2000)]
        public string WVFehlermeldung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbWVEinzelpostenFehlerTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual KbBuchungKostenart KbBuchungKostenart { get; set; }

        public virtual KbWVLauf KbWVLauf { get; set; }
    }
}
