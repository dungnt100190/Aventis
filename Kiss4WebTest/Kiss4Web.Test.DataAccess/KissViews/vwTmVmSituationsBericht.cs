namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVmSituationsBericht")]
    public partial class vwTmVmSituationsBericht
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VmSituationsBerichtID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [StringLength(10)]
        public string AntragDatum { get; set; }

        [StringLength(200)]
        public string TypSHAntrag { get; set; }

        [StringLength(1000)]
        public string Themen { get; set; }

        public string BerichtFinanzen { get; set; }

        public string ZielPrognose { get; set; }

        public string AntragText { get; set; }

        [StringLength(401)]
        public string Autor { get; set; }
    }
}
