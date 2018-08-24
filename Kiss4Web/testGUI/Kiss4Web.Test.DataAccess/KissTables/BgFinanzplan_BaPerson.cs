namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BgFinanzplan_BaPerson
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BgFinanzplanID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        public bool IstUnterstuetzt { get; set; }

        public int? BaZahlungswegID { get; set; }

        [StringLength(50)]
        public string ReferenzNummer { get; set; }

        public int? KbKostenstelleID { get; set; }

        public int? KbKostenstelleID_KVG { get; set; }

        public int ShNrmVerrechnungsbasisID { get; set; }

        [StringLength(10)]
        public string PrsNummerKanton { get; set; }

        [StringLength(10)]
        public string PrsNummerHeimat { get; set; }

        public DateTime? NrmVerrechnungVon { get; set; }

        public DateTime? NrmVerrechnungBis { get; set; }

        public int? NrmVerrechnungsAnteilCode { get; set; }

        public bool IstAuslandCh { get; set; }

        public DateTime? AuslandChVon { get; set; }

        public DateTime? AuslandChBis { get; set; }

        public DateTime? AuslandChMeldungAm { get; set; }

        [StringLength(50)]
        public string AuslandChReferenzNrBund { get; set; }

        public int? BurgergemeindeID { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgFinanzplan_BaPersonTS { get; set; }

        public virtual BaGemeinde BaGemeinde { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaZahlungsweg BaZahlungsweg { get; set; }

        public virtual BgFinanzplan BgFinanzplan { get; set; }

        public virtual KbKostenstelle KbKostenstelle { get; set; }

        public virtual KbKostenstelle KbKostenstelle1 { get; set; }
    }
}
