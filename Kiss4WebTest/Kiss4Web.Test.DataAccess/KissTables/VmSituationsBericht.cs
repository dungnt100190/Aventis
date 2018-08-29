namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmSituationsBericht")]
    public partial class VmSituationsBericht
    {
        public int VmSituationsBerichtID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public DateTime? AntragDatum { get; set; }

        public int? VMTypSHAntragCode { get; set; }

        [StringLength(255)]
        public string FaThemaCodes { get; set; }

        public string BerichtFinanzen { get; set; }

        public string ZielPrognose { get; set; }

        public string AntragText { get; set; }

        public int? DocumentID { get; set; }

        public bool IsDeleted { get; set; }

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
        public byte[] VmSituationsBerichtTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
