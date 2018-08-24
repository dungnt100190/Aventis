namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XPlausiFehler")]
    public partial class XPlausiFehler
    {
        [Key]
        [Column(Order = 0)]
        public int XPlausiFehlerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlausiNo { get; set; }

        [StringLength(50)]
        public string VarName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Text { get; set; }

        public int? PlausiFehlerTypCode { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Erledigt { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XPlausiFehlerTS { get; set; }

        public int? DossierID { get; set; }
    }
}
