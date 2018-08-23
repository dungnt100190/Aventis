namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XDocument")]
    public partial class XDocument
    {
        [Key]
        public int DocumentID { get; set; }

        public DateTime DateCreation { get; set; }

        public int? UserID_Creator { get; set; }

        public DateTime DateLastSave { get; set; }

        public int? UserID_LastSave { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] FileBinary { get; set; }

        public int? DocFormatCode { get; set; }

        [StringLength(10)]
        public string FileExtension { get; set; }

        public bool DocReadOnly { get; set; }

        public int? DocTemplateID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XDocumentTS { get; set; }

        public int? DocTypeCode { get; set; }

        [StringLength(255)]
        public string DocTemplateName { get; set; }

        public int? CheckOut_UserID { get; set; }

        public DateTime? CheckOut_Date { get; set; }

        public string CheckOut_Filename { get; set; }

        public string CheckOut_Machine { get; set; }

        public int? UserID_LastRead { get; set; }

        public DateTime? DateLastRead { get; set; }
    }
}
