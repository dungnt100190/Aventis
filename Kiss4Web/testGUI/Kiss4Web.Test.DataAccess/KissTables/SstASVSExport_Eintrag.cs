namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SstASVSExport_Eintrag
    {
        public int SstASVSExport_EintragID { get; set; }

        public int SstASVSExportID { get; set; }

        public int WhASVSEintragID { get; set; }

        public int? ASVSExportCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        [Required]
        [StringLength(50)]
        public string Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] SstASVSExport_EintragTS { get; set; }

        public virtual SstASVSExport SstASVSExport { get; set; }

        public virtual WhASVSEintrag WhASVSEintrag { get; set; }
    }
}
