namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVmVaterschaft")]
    public partial class vwTmVmVaterschaft
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [StringLength(30)]
        public string AnerkennungDat { get; set; }

        [StringLength(100)]
        public string AnerkennungOrt { get; set; }

        [StringLength(30)]
        public string UHVDat { get; set; }

        [StringLength(30)]
        public string SgeVDat { get; set; }

        [StringLength(30)]
        public string GenehmDat { get; set; }
    }
}
