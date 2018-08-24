namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKesVerlauf")]
    public partial class vwTmKesVerlauf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KesVerlaufID { get; set; }

        public DateTime? Datum { get; set; }

        [StringLength(200)]
        public string KontaktartDE { get; set; }

        [StringLength(200)]
        public string KontaktartFR { get; set; }

        [StringLength(200)]
        public string KontaktartIT { get; set; }

        [StringLength(200)]
        public string DienstleistungD { get; set; }

        [StringLength(200)]
        public string DienstleistungF { get; set; }

        [StringLength(200)]
        public string DienstleistungI { get; set; }

        public string Stichwort { get; set; }

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

        [StringLength(200)]
        public string DauerD { get; set; }

        [StringLength(200)]
        public string DauerF { get; set; }

        [StringLength(200)]
        public string DauerI { get; set; }

        public string Inhalt { get; set; }
    }
}
