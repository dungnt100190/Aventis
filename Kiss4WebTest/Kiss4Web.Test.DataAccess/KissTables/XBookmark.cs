namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XBookmark")]
    public partial class XBookmark
    {
        [Key]
        [StringLength(40)]
        public string BookmarkName { get; set; }

        public int? BookmarkNameTID { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public int? CategoryTID { get; set; }

        public int? BookmarkCode { get; set; }

        public string SQL { get; set; }

        public string Description { get; set; }

        public int? DescriptionTID { get; set; }

        [StringLength(100)]
        public string TableName { get; set; }

        public int? ModulID { get; set; }

        public bool AlwaysVisible { get; set; }

        public bool System { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XBookmarkTS { get; set; }

        public virtual XModul XModul { get; set; }
    }
}
