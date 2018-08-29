namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbOpAusgleich")]
    public partial class KbOpAusgleich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbOpAusgleich()
        {
            KbForderungAuszahlungs = new HashSet<KbForderungAuszahlung>();
        }

        public int KbOpAusgleichID { get; set; }

        public int OpBuchungID { get; set; }

        public int AusgleichBuchungID { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbOpAusgleichTS { get; set; }

        [Column("_mig_AiZahlungVsForderungID")]
        public int? C_mig_AiZahlungVsForderungID { get; set; }

        public virtual KbBuchung KbBuchung { get; set; }

        public virtual KbBuchung KbBuchung1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbForderungAuszahlung> KbForderungAuszahlungs { get; set; }
    }
}
