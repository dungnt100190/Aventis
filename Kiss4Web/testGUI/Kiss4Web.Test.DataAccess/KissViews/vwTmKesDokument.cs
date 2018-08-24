namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKesDokument")]
    public partial class vwTmKesDokument
    {
        public int? KesAuftragID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KesDokumentID { get; set; }

        public int? VerfasserInUserID { get; set; }

        [StringLength(9)]
        public string VerfasserFrauHerr { get; set; }

        [StringLength(10)]
        public string VerfasserFrauHerrn { get; set; }

        [StringLength(402)]
        public string VerfasserNameVorname { get; set; }

        [StringLength(401)]
        public string VerfasserNameVornameOhneKomma { get; set; }

        [StringLength(401)]
        public string VerfasserVornameName { get; set; }

        [StringLength(100)]
        public string VerfasserAbteilungEMail { get; set; }

        [StringLength(100)]
        public string VerfasserAbteilungFax { get; set; }

        [StringLength(100)]
        public string VerfasserAbteilungName { get; set; }

        [StringLength(100)]
        public string VerfasserAbteilungTelefon { get; set; }

        [StringLength(200)]
        public string VerfasserNachname { get; set; }

        [StringLength(200)]
        public string VerfasserVorname { get; set; }

        [StringLength(10)]
        public string VerfasserKuerzel { get; set; }

        [StringLength(100)]
        public string VerfasserTelephon { get; set; }

        [StringLength(100)]
        public string VerfasserEMail { get; set; }

        public string Stichwort { get; set; }

        [StringLength(2000)]
        public string ResultatD { get; set; }

        [StringLength(2000)]
        public string ResultatF { get; set; }

        [StringLength(2000)]
        public string ResultatI { get; set; }

        [StringLength(2000)]
        public string ArtDE { get; set; }

        [StringLength(2000)]
        public string ArtFR { get; set; }

        [StringLength(2000)]
        public string ArtIT { get; set; }

        public DateTime? VersandDatum { get; set; }

        public DateTime? DatumHeute { get; set; }
    }
}
