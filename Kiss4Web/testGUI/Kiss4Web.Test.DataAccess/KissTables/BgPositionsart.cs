namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgPositionsart")]
    public partial class BgPositionsart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgPositionsart()
        {
            BgPositions = new HashSet<BgPosition>();
            BgPositionsartBuchungstexts = new HashSet<BgPositionsartBuchungstext>();
            BgPositionsartBuchungstexts1 = new HashSet<BgPositionsartBuchungstext>();
            BgSpezkontoes = new HashSet<BgSpezkonto>();
            ShEinzelzahlungs = new HashSet<ShEinzelzahlung>();
            XPermissionValues = new HashSet<XPermissionValue>();
        }

        public int BgPositionsartID { get; set; }

        public int BgKategorieCode { get; set; }

        public int BgGruppeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string HilfeText { get; set; }

        public int SortKey { get; set; }

        public int? BgKostenartID { get; set; }

        public int? NrmKontoCode { get; set; }

        public bool? VerwaltungSD_Default { get; set; }

        public bool Spezkonto { get; set; }

        public bool ProPerson { get; set; }

        public bool ProUE { get; set; }

        public int Masterbudget_EditMask { get; set; }

        public int Monatsbudget_EditMask { get; set; }

        public int ModulID { get; set; }

        [StringLength(3000)]
        public string sqlRichtlinie { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgPositionsartTS { get; set; }

        [StringLength(50)]
        public string VarName { get; set; }

        public bool Verrechenbar { get; set; }

        public bool ErzeugtBfsDossier { get; set; }

        public string Bemerkung { get; set; }

        public int? NameTID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? BgPositionsartCode { get; set; }

        public int? BgPositionsartID_CopyOf { get; set; }

        public bool System { get; set; }

        public bool KreditorEingeschraenkt { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPositionsartBuchungstext> BgPositionsartBuchungstexts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPositionsartBuchungstext> BgPositionsartBuchungstexts1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgSpezkonto> BgSpezkontoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShEinzelzahlung> ShEinzelzahlungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XPermissionValue> XPermissionValues { get; set; }
    }
}
