namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgDokument")]
    public partial class BgDokument
    {
        public int BgDokumentID { get; set; }

        public int? BgFinanzplanID { get; set; }

        public int? BgBudgetID { get; set; }

        public int? BgPositionID { get; set; }

        public int? BgDokumentTypCode { get; set; }

        public int? DocumentID { get; set; }

        [StringLength(200)]
        public string Stichwort { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgDocumentTS { get; set; }

        public virtual BgBudget BgBudget { get; set; }

        public virtual BgFinanzplan BgFinanzplan { get; set; }

        public virtual BgPosition BgPosition { get; set; }
    }
}
