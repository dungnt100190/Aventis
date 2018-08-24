namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKesMassnahmeBericht")]
    public partial class vwTmKesMassnahmeBericht
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KesMassnahmeID { get; set; }

        [StringLength(4000)]
        public string ArtikelNummer { get; set; }

        [StringLength(4000)]
        public string ArtikelTextKurz { get; set; }

        [StringLength(4000)]
        public string ArtikelTextLang { get; set; }

        [StringLength(4000)]
        public string ArtNmrTextKurz { get; set; }

        [StringLength(4000)]
        public string ArtNmrTextLang { get; set; }

        public DateTime? DatErchtsbschlss { get; set; }

        [StringLength(402)]
        public string MFPNameVorname { get; set; }

        [StringLength(401)]
        public string MFPNmVrnmOhnKmma { get; set; }

        [StringLength(401)]
        public string MFPVornameName { get; set; }

        [StringLength(1135)]
        public string MFPAdrssEinzeilg { get; set; }

        [StringLength(1135)]
        public string MFPAdrssMhrzeilg { get; set; }

        public DateTime? MFPErnanntSeit { get; set; }

        public DateTime? MFPPrmVrgchlSDAm { get; set; }

        public DateTime? MFPPrmRchfrngVon { get; set; }

        public DateTime? MFPPrmRchfrngBis { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(9)]
        public string SARFrauHerr { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string SARFrauHerrn { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(402)]
        public string SARNameVorname { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(401)]
        public string SARNamVrnmOhnKma { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(401)]
        public string SARVornameName { get; set; }

        [StringLength(100)]
        public string SARAbteilungEMai { get; set; }

        [StringLength(100)]
        public string SARAbteilungFax { get; set; }

        [StringLength(100)]
        public string SARAbteilungName { get; set; }

        [StringLength(100)]
        public string SARAbteilungTel { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(200)]
        public string SARNachname { get; set; }

        [StringLength(200)]
        public string SARVorname { get; set; }

        [StringLength(10)]
        public string SARKuerzel { get; set; }

        [StringLength(100)]
        public string SARTelephon { get; set; }

        [StringLength(100)]
        public string SAREMail { get; set; }

        [StringLength(200)]
        public string ElterlicheSorgeD { get; set; }

        [StringLength(200)]
        public string ElterlicheSorgeF { get; set; }

        [StringLength(200)]
        public string ElterlicheSorgeI { get; set; }

        public string MassAuftragstext { get; set; }

        public int? KesMassnahmeBerichtID { get; set; }

        public DateTime? PeriodeVon { get; set; }

        public DateTime? PeriodeBis { get; set; }

        public DateTime? Berichtsdatum { get; set; }

        public DateTime? Rechnungsdatum { get; set; }

        [StringLength(200)]
        public string BrchtArtDsBrchtD { get; set; }

        [StringLength(200)]
        public string BrchtArtDsBrchtF { get; set; }

        [StringLength(200)]
        public string BrchtArtDsBrchtI { get; set; }

        public int? KesMassnahmeAuftragID { get; set; }

        public string AuftragAuftrag { get; set; }

        [StringLength(200)]
        public string AuftrgrtGschftsD { get; set; }

        [StringLength(200)]
        public string AuftrgrtGschftsF { get; set; }

        [StringLength(200)]
        public string AuftrgrtGschftsI { get; set; }
    }
}
