namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KbBuchung")]
    public partial class KbBuchung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KbBuchung()
        {
            IkBetreibungAusgleiches = new HashSet<IkBetreibungAusgleich>();
            KbBuchung1 = new HashSet<KbBuchung>();
            KbBuchung11 = new HashSet<KbBuchung>();
            KbBuchungKostenarts = new HashSet<KbBuchungKostenart>();
            KbForderungAuszahlungs = new HashSet<KbForderungAuszahlung>();
            KbForderungAuszahlungs1 = new HashSet<KbForderungAuszahlung>();
            KbOpAusgleiches = new HashSet<KbOpAusgleich>();
            KbOpAusgleiches1 = new HashSet<KbOpAusgleich>();
            KbTransfers = new HashSet<KbTransfer>();
        }

        public int KbBuchungID { get; set; }

        public int? BaZahlungswegID { get; set; }

        public int? KbAuszahlungsArtCode { get; set; }

        public int? FlTypSourceCode { get; set; }

        public int? FlBelegStatusCode { get; set; }

        public int? IdSource { get; set; }

        public int? BelegNr { get; set; }

        public int? BarbelegUserID { get; set; }

        public DateTime ErstelltDatum { get; set; }

        public DateTime? TransferDatum { get; set; }

        public DateTime? BelegDatum { get; set; }

        public DateTime? ValutaDatum { get; set; }

        public DateTime? BarbelegDatum { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [StringLength(50)]
        public string Extern { get; set; }

        [StringLength(30)]
        public string ReferenzNummer { get; set; }

        [StringLength(16)]
        public string AggregateInfo { get; set; }

        [StringLength(500)]
        public string FibuFehlermeldung { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public int? Old_SourceID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KbBuchungTS { get; set; }

        public int KbPeriodeID { get; set; }

        public int KbBuchungTypCode { get; set; }

        public int? KbBuchungStatusCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [StringLength(10)]
        public string SollKtoNr { get; set; }

        [StringLength(10)]
        public string HabenKtoNr { get; set; }

        public int? EinzahlungsscheinCode { get; set; }

        [StringLength(50)]
        public string PCKontoNr { get; set; }

        [StringLength(50)]
        public string BankKontoNr { get; set; }

        [StringLength(50)]
        public string IBAN { get; set; }

        public int? BaBankID { get; set; }

        [StringLength(6)]
        public string BankBCN { get; set; }

        [StringLength(70)]
        public string BankName { get; set; }

        [StringLength(50)]
        public string BankStrasse { get; set; }

        [StringLength(10)]
        public string BankPLZ { get; set; }

        [StringLength(60)]
        public string BankOrt { get; set; }

        [StringLength(200)]
        public string Zahlungsgrund { get; set; }

        [StringLength(35)]
        public string MitteilungZeile1 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile2 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile3 { get; set; }

        [StringLength(35)]
        public string MitteilungZeile4 { get; set; }

        [StringLength(100)]
        public string BeguenstigtName { get; set; }

        [StringLength(200)]
        public string BeguenstigtName2 { get; set; }

        [StringLength(100)]
        public string BeguenstigtStrasse { get; set; }

        [StringLength(10)]
        public string BeguenstigtHausNr { get; set; }

        [StringLength(40)]
        public string BeguenstigtPostfach { get; set; }

        [StringLength(10)]
        public string BeguenstigtPLZ { get; set; }

        [StringLength(100)]
        public string BeguenstigtOrt { get; set; }

        public int? BeguenstigtLandCode { get; set; }

        public int? KbZahlungseingangID { get; set; }

        public int ErstelltUserID { get; set; }

        public int? MutiertUserID { get; set; }

        public DateTime? MutiertDatum { get; set; }

        public int? Schuldner_BaInstitutionID { get; set; }

        public int? Schuldner_BaPersonID { get; set; }

        public int? StorniertKbBuchungID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? BgBudgetID { get; set; }

        public int? IkPositionID { get; set; }

        public int? NeubuchungVonKbBuchungID { get; set; }

        public int? KbBelegKreisID { get; set; }

        public int? KbZahlungskontoID { get; set; }

        public int? IkForderungBgKostenartHistID { get; set; }

        public virtual BaBank BaBank { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaLand BaLand { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaZahlungsweg BaZahlungsweg { get; set; }

        public virtual BgBudget BgBudget { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkBetreibungAusgleich> IkBetreibungAusgleiches { get; set; }

        public virtual IkForderungBgKostenartHist IkForderungBgKostenartHist { get; set; }

        public virtual IkPosition IkPosition { get; set; }

        public virtual KbBelegKrei KbBelegKrei { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchung1 { get; set; }

        public virtual KbBuchung KbBuchung2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchung11 { get; set; }

        public virtual KbBuchung KbBuchung3 { get; set; }

        public virtual KbPeriode KbPeriode { get; set; }

        public virtual KbZahlungseingang KbZahlungseingang { get; set; }

        public virtual KbZahlungskonto KbZahlungskonto { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        public virtual XUser XUser2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchungKostenart> KbBuchungKostenarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbForderungAuszahlung> KbForderungAuszahlungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbForderungAuszahlung> KbForderungAuszahlungs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbOpAusgleich> KbOpAusgleiches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbOpAusgleich> KbOpAusgleiches1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbTransfer> KbTransfers { get; set; }
    }
}
