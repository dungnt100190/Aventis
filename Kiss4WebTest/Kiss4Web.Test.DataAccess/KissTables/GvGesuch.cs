namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GvGesuch")]
    public partial class GvGesuch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GvGesuch()
        {
            GvAbklaerendeStelles = new HashSet<GvAbklaerendeStelle>();
            GvAntragPositions = new HashSet<GvAntragPosition>();
            GvAuflages = new HashSet<GvAuflage>();
            GvAuszahlungPositions = new HashSet<GvAuszahlungPosition>();
            GvBewilligungs = new HashSet<GvBewilligung>();
            GvDocuments = new HashSet<GvDocument>();
        }

        public int GvGesuchID { get; set; }

        public int BaPersonID { get; set; }

        public int XUserID_Autor { get; set; }

        public int? UserIDBewilligt { get; set; }

        public int? DocumentID { get; set; }

        public int GvFondsID { get; set; }

        public int? ErfasstesGesuchgeprueftdurchIKS_UserID { get; set; }

        public int? AbgeschlossenesGesuchdurchIKS_UserID { get; set; }

        public int GvStatusCode { get; set; }

        public DateTime GesuchsDatum { get; set; }

        public DateTime? ErfassungAbgeschlossen { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragBewilligt { get; set; }

        public DateTime? BewilligtAm { get; set; }

        public string Begruendung { get; set; }

        [StringLength(2000)]
        public string Bemerkung { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragBewilligtKompetenzstufe1 { get; set; }

        public DateTime? DatumBewilligtKompetenzstufe1 { get; set; }

        public string BemerkungBewilligungKompetenzstufe1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragBewilligtKompetenzstufe2 { get; set; }

        public DateTime? DatumBewilligtKompetenzstufe2 { get; set; }

        public string BemerkungBewilligungKompetenzstufe2 { get; set; }

        public DateTime? AbschlussDatum { get; set; }

        public int? GvAbschlussgrundCode { get; set; }

        [Required]
        [StringLength(40)]
        public string Gesuchsgrund { get; set; }

        public bool IstEigenkompetenz { get; set; }

        public bool IstKompetenzBsl { get; set; }

        public bool IstKompetenzKanton { get; set; }

        public bool Extern { get; set; }

        public DateTime? ErfasstesGesuchgeprueftam { get; set; }

        public bool ErfasstesGesuchBesprechen { get; set; }

        public string ErfasstesGesuchBemerkung { get; set; }

        public DateTime? AbgeschlossenesGesuchgeprueftam { get; set; }

        public bool AbgeschlossenesGesuchBesprechen { get; set; }

        public string AbgeschlossenesGesuchBemerkung { get; set; }

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
        public byte[] GvGesuchTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAbklaerendeStelle> GvAbklaerendeStelles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAntragPosition> GvAntragPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAuflage> GvAuflages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAuszahlungPosition> GvAuszahlungPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvBewilligung> GvBewilligungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvDocument> GvDocuments { get; set; }

        public virtual GvFond GvFond { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        public virtual XUser XUser2 { get; set; }
    }
}
