namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XTaskTypeAction")]
    public partial class XTaskTypeAction
    {
        public int XTaskTypeActionID { get; set; }

        public int XTaskTypeActionTypeCode { get; set; }

        public int TaskTypeCode { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        public int? BezeichnungTID { get; set; }

        public string Betreff { get; set; }

        public int? BetreffTID { get; set; }

        public string Text { get; set; }

        public int? TextTID { get; set; }

        public bool BenachrichtigungAktiv { get; set; }

        public bool ErstellerDarfAusfuehren { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XTaskTypeActionTS { get; set; }
    }
}
