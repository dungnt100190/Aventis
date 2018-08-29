namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmAbklPhasen")]
    public partial class vwTmAbklPhasen
    {
        public int? KaAKPhasenID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IstIntake { get; set; }

        public string Fragestellungen { get; set; }

        [StringLength(200)]
        public string GrundDossier { get; set; }

        [StringLength(200)]
        public string IntegBeurteilung { get; set; }

        public DateTime? DatumIntegBeurteilung { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string KursDatumBis { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string KursDatumVon { get; set; }

        [StringLength(200)]
        public string Phase { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string PhaseDatum { get; set; }

        public string Rueckfragen { get; set; }

        [StringLength(25)]
        public string Kursnummer { get; set; }

        [StringLength(200)]
        public string EinsatzIn { get; set; }

        public DateTime? EinsatzVon { get; set; }

        public DateTime? EinsatzBis { get; set; }

        public DateTime? Gespraechtstermin { get; set; }
    }
}
