namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaWeisungWorkflow")]
    public partial class FaWeisungWorkflow
    {
        public int FaWeisungWorkflowID { get; set; }

        public int? XTaskTemplateID_RD { get; set; }

        public int? XTaskTemplateID_SAR { get; set; }

        public int StatusCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Aktion { get; set; }

        public int? AktionTID { get; set; }

        public int NeuerStatusCode { get; set; }

        public int ZustaendigCode { get; set; }

        public bool TerminMuss { get; set; }

        public int? NaechsterTerminCode { get; set; }

        public bool NaechsterTerminAnpassen { get; set; }

        public bool PendenzSAR { get; set; }

        public bool PendenzRD { get; set; }

        public bool SARPendenzAnpassen { get; set; }

        public bool WeisungErfuellt { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FaWeisungWorkflowTS { get; set; }

        public virtual XTaskTemplate XTaskTemplate { get; set; }

        public virtual XTaskTemplate XTaskTemplate1 { get; set; }
    }
}
