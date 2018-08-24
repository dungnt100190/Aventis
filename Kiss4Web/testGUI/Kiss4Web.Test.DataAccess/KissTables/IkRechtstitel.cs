namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkRechtstitel")]
    public partial class IkRechtstitel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IkRechtstitel()
        {
            IkBetreibungs = new HashSet<IkBetreibung>();
            IkEinkommen = new HashSet<IkEinkomman>();
            IkForderungs = new HashSet<IkForderung>();
            IkGlaeubigers = new HashSet<IkGlaeubiger>();
            IkPositions = new HashSet<IkPosition>();
            IkRatenplanForderungs = new HashSet<IkRatenplanForderung>();
            IkVerrechnungskontoes = new HashSet<IkVerrechnungskonto>();
        }

        public int IkRechtstitelID { get; set; }

        public int FaLeistungID { get; set; }

        public int? IkBezugKinderzulagenCode { get; set; }

        public int? IkRechtstitelStatusCode { get; set; }

        public int? IkRechtstitelTypCode { get; set; }

        [StringLength(50)]
        public string InkassoFallName { get; set; }

        [StringLength(2048)]
        public string RechtstitelInfo { get; set; }

        public DateTime? RechtstitelDatumVon { get; set; }

        public DateTime? RechtstitelRechtskraeftig { get; set; }

        public int? IkElterlicheSorgeCode { get; set; }

        [StringLength(200)]
        public string ElterlicheSorgeBemerkung { get; set; }

        public int? BaPersonID { get; set; }

        public int? IkIndexTypCode { get; set; }

        public double? IndexStandPunkte { get; set; }

        public DateTime? IndexStandVom { get; set; }

        public int? IkIndexRundenCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasisKinderalimente { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasisEhegattenalimente { get; set; }

        public int? IkInkassoBemuehungCode { get; set; }

        public DateTime? VerjaehrungAm { get; set; }

        public string Bemerkung { get; set; }

        public bool? SchuldnerMahnen { get; set; }

        public int? IkAlimenteUnterartCode { get; set; }

        public int? IkRueckerstattungTypCode { get; set; }

        public DateTime? IkRechtstitelGueltigVon { get; set; }

        public DateTime? IkRechtstitelGueltigBis { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkRechtstitelTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkBetreibung> IkBetreibungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkEinkomman> IkEinkommen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderung> IkForderungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkGlaeubiger> IkGlaeubigers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkPosition> IkPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkRatenplanForderung> IkRatenplanForderungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkVerrechnungskonto> IkVerrechnungskontoes { get; set; }
    }
}
