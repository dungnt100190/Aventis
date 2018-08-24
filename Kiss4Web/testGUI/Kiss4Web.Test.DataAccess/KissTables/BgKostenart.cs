namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgKostenart")]
    public partial class BgKostenart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgKostenart()
        {
            BgKostenart_WhGefKategorie = new HashSet<BgKostenart_WhGefKategorie>();
            BgPositionsarts = new HashSet<BgPositionsart>();
            BgSpezkontoes = new HashSet<BgSpezkonto>();
            GvPositionsarts = new HashSet<GvPositionsart>();
            IkForderung_BgKostenart = new HashSet<IkForderung_BgKostenart>();
            IkForderung_BgKostenart1 = new HashSet<IkForderung_BgKostenart>();
            IkForderungBgKostenartHists = new HashSet<IkForderungBgKostenartHist>();
            KbBuchungKostenarts = new HashSet<KbBuchungKostenart>();
            KbWVEinzelpostens = new HashSet<KbWVEinzelposten>();
        }

        public int BgKostenartID { get; set; }

        public int ModulID { get; set; }

        [StringLength(10)]
        public string KontoNr { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? NameTID { get; set; }

        public bool Quoting { get; set; }

        public int? BgSplittingArtCode { get; set; }

        public int? BaWVZeileCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgKostenartTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgKostenart_WhGefKategorie> BgKostenart_WhGefKategorie { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPositionsart> BgPositionsarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgSpezkonto> BgSpezkontoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvPositionsart> GvPositionsarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderung_BgKostenart> IkForderung_BgKostenart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderung_BgKostenart> IkForderung_BgKostenart1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderungBgKostenartHist> IkForderungBgKostenartHists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchungKostenart> KbBuchungKostenarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVEinzelposten> KbWVEinzelpostens { get; set; }
    }
}
