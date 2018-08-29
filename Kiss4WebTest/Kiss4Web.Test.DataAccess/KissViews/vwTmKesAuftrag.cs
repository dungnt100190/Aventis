namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKesAuftrag")]
    public partial class vwTmKesAuftrag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KesAuftragID { get; set; }

        public DateTime? AuftragVom { get; set; }

        [StringLength(402)]
        public string AbklaerungDurch { get; set; }

        [StringLength(2000)]
        public string MeldungDurchD { get; set; }

        [StringLength(2000)]
        public string MeldungDurchF { get; set; }

        [StringLength(2000)]
        public string MeldungDurchI { get; set; }

        [StringLength(2000)]
        public string AuftragDurchD { get; set; }

        [StringLength(2000)]
        public string AuftragDurchF { get; set; }

        [StringLength(2000)]
        public string AuftragDurchI { get; set; }

        [StringLength(2000)]
        public string AbklaerungsartDE { get; set; }

        [StringLength(2000)]
        public string AbklaerungsartFR { get; set; }

        [StringLength(2000)]
        public string AbklaerungsartIT { get; set; }

        public string Anlass { get; set; }

        public string Auftrag { get; set; }

        public DateTime? DokumentDatum { get; set; }

        public DateTime? FristBis { get; set; }

        public DateTime? Abschluss { get; set; }

        [StringLength(2000)]
        public string AbschlussgrundD { get; set; }

        [StringLength(2000)]
        public string AbschlussgrundF { get; set; }

        [StringLength(2000)]
        public string AbschlussgrundI { get; set; }

        public DateTime? BeschlussRueckmeldung { get; set; }

        public string BetroffenePersonen { get; set; }

        [StringLength(4000)]
        public string KlientKindD { get; set; }

        [StringLength(4000)]
        public string KlientKindF { get; set; }

        [StringLength(4000)]
        public string KlientKindI { get; set; }

        [StringLength(4000)]
        public string KlientVaterD { get; set; }

        [StringLength(4000)]
        public string KlientVaterF { get; set; }

        [StringLength(4000)]
        public string KlientVaterI { get; set; }

        [StringLength(4000)]
        public string KlientMutterD { get; set; }

        [StringLength(4000)]
        public string KlientMutterF { get; set; }

        [StringLength(4000)]
        public string KlientMutterI { get; set; }

        [StringLength(4000)]
        public string KlientGeschwisterD { get; set; }

        [StringLength(4000)]
        public string KlientGeschwisterF { get; set; }

        [StringLength(4000)]
        public string KlientGeschwisterI { get; set; }

        public DateTime? DatumHeute { get; set; }
    }
}
