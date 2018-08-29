namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbPeriode")]
    public partial class KbPeriode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbPeriode()
        {
            KbBelegKreis = new HashSet<KbBelegKrei>();
            KbBuchungs = new HashSet<KbBuchung>();
            KbKontoes = new HashSet<KbKonto>();
            KbPeriode_User = new HashSet<KbPeriode_User>();
            KbWVLaufs = new HashSet<KbWVLauf>();
        }

        public int KbPeriodeID { get; set; }

        public int KbMandantID { get; set; }

        public DateTime PeriodeVon { get; set; }

        public DateTime PeriodeBis { get; set; }

        public int PeriodeStatusCode { get; set; }

        public DateTime? VerbuchtBis { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbPeriodeTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBelegKrei> KbBelegKreis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbKonto> KbKontoes { get; set; }

        public virtual KbMandant KbMandant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbPeriode_User> KbPeriode_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVLauf> KbWVLaufs { get; set; }
    }
}
