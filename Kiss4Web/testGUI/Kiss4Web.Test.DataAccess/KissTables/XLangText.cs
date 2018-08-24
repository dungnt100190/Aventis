namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XLangText")]
    public partial class XLangText
    {
        [Key]
        [Column(Order = 0)]
        public int TID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LanguageCode { get; set; }

        [StringLength(2000)]
        public string Text { get; set; }

        public string LargeText { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XLangTextTS { get; set; }
    }
}
