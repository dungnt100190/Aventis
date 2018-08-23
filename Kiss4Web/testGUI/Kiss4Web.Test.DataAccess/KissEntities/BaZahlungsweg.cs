namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaZahlungsweg")]
    public partial class BaZahlungsweg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaZahlungsweg()
        {
            BgAuszahlungPersons = new HashSet<BgAuszahlungPerson>();
            BgFinanzplan_BaPerson = new HashSet<BgFinanzplan_BaPerson>();
            BgZahlungsmodus = new HashSet<BgZahlungsmodu>();
            GvAbklaerendeStelles = new HashSet<GvAbklaerendeStelle>();
            GvAuszahlungPositions = new HashSet<GvAuszahlungPosition>();
            IkGlaeubigers = new HashSet<IkGlaeubiger>();
            KbBuchungs = new HashSet<KbBuchung>();
        }

        public int BaZahlungswegID { get; set; }

        public int? BaPersonID { get; set; }

        public int? BaInstitutionID { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public int? EinzahlungsscheinCode { get; set; }

        public int? BaBankID { get; set; }

        [StringLength(50)]
        public string BankKontoNummer { get; set; }

        [StringLength(50)]
        public string IBANNummer { get; set; }

        [StringLength(20)]
        public string PostKontoNummer { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        [StringLength(35)]
        public string AdresseName { get; set; }

        [StringLength(35)]
        public string AdresseName2 { get; set; }

        [StringLength(35)]
        public string AdresseStrasse { get; set; }

        [StringLength(35)]
        public string AdresseHausNr { get; set; }

        [StringLength(35)]
        public string AdressePostfach { get; set; }

        [StringLength(10)]
        public string AdressePLZ { get; set; }

        [StringLength(25)]
        public string AdresseOrt { get; set; }

        public int? AdresseLandCode { get; set; }

        [StringLength(20)]
        public string BaZahlwegModulStdCodes { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaZahlungswegTS { get; set; }

        public virtual BaBank BaBank { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual BaLand BaLand { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgAuszahlungPerson> BgAuszahlungPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgFinanzplan_BaPerson> BgFinanzplan_BaPerson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgZahlungsmodu> BgZahlungsmodus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAbklaerendeStelle> GvAbklaerendeStelles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvAuszahlungPosition> GvAuszahlungPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkGlaeubiger> IkGlaeubigers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }
    }
}
