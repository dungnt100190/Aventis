namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgPosition")]
    public partial class BgPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BgPosition()
        {
            BgAuszahlungPersons = new HashSet<BgAuszahlungPerson>();
            BgBewilligungs = new HashSet<BgBewilligung>();
            BgDokuments = new HashSet<BgDokument>();
            BgPosition1 = new HashSet<BgPosition>();
            BgPosition11 = new HashSet<BgPosition>();
            BgPosition12 = new HashSet<BgPosition>();
            KbBuchungKostenarts = new HashSet<KbBuchungKostenart>();
        }

        public int BgPositionID { get; set; }

        public int? BgPositionID_Parent { get; set; }

        public int? BgPositionID_CopyOf { get; set; }

        public int BgBudgetID { get; set; }

        public int? BaPersonID { get; set; }

        public int? BgPositionsartID { get; set; }

        public int? BgSpezkontoID { get; set; }

        public int? BaInstitutionID { get; set; }

        public int? DebitorBaPersonID { get; set; }

        public int? ErstelltUserID { get; set; }

        public int? MutiertUserID { get; set; }

        public int? BgPositionID_AutoForderung { get; set; }

        public int BgKategorieCode { get; set; }

        public int? ShBelegID { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Column(TypeName = "money")]
        public decimal Reduktion { get; set; }

        [Column(TypeName = "money")]
        public decimal Abzug { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragEff { get; set; }

        [Column(TypeName = "money")]
        public decimal MaxBeitragSD { get; set; }

        [StringLength(100)]
        public string Buchungstext { get; set; }

        public bool VerwaltungSD { get; set; }

        public string Bemerkung { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? OldID { get; set; }

        public DateTime? VerwPeriodeVon { get; set; }

        public DateTime? VerwPeriodeBis { get; set; }

        public DateTime? FaelligAm { get; set; }

        public DateTime? RechnungDatum { get; set; }

        public int BgBewilligungStatusCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragAnfrage { get; set; }

        public int? BgAuszahlungID { get; set; }

        public DateTime? DatumEff { get; set; }

        public string BemerkungSaldierung { get; set; }

        public bool Saldiert { get; set; }

        public DateTime? ErstelltDatum { get; set; }

        public DateTime? MutiertDatum { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgPositionTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaPerson BaPerson1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgAuszahlungPerson> BgAuszahlungPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBewilligung> BgBewilligungs { get; set; }

        public virtual BgBudget BgBudget { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgDokument> BgDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPosition1 { get; set; }

        public virtual BgPosition BgPosition2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPosition11 { get; set; }

        public virtual BgPosition BgPosition3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPosition12 { get; set; }

        public virtual BgPosition BgPosition4 { get; set; }

        public virtual BgPositionsart BgPositionsart { get; set; }

        public virtual BgSpezkonto BgSpezkonto { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchungKostenart> KbBuchungKostenarts { get; set; }
    }
}
