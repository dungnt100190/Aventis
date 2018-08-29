namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmErblasser")]
    public partial class vwTmErblasser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [StringLength(16)]
        public string AHVNr { get; set; }

        [StringLength(1)]
        public string DerDes { get; set; }

        [StringLength(1)]
        public string DerDesBesch { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string DieDer { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(7)]
        public string DieDerBesch { get; set; }

        [StringLength(30)]
        public string Todesdatum { get; set; }

        [StringLength(30)]
        public string TodesdatumBesch { get; set; }

        [StringLength(50)]
        public string TodesdatumOderBereich { get; set; }

        [StringLength(50)]
        public string Todesort { get; set; }

        [StringLength(182)]
        public string ErblasserAdresseEinzeln { get; set; }

        [StringLength(182)]
        public string ErblasserAdresseEinzelnBesch { get; set; }

        [StringLength(10)]
        public string ErblasserAnrede { get; set; }

        [StringLength(10)]
        public string ErblasserAnredeBesch { get; set; }

        [StringLength(100)]
        public string ErblasserElternnamen { get; set; }

        [StringLength(100)]
        public string ErblasserElternnamenBesch { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(100)]
        public string ErblasserFamilienNamen { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string ErblasserFamilienNamenBesch { get; set; }

        [StringLength(30)]
        public string ErblasserGeburtsdatum { get; set; }

        [StringLength(30)]
        public string ErblasserGeburtsdatumBesch { get; set; }

        [StringLength(150)]
        public string ErblasserHeimatorte { get; set; }

        [StringLength(150)]
        public string ErblasserHeimatorteBesch { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string ErblasserVornamen { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string ErblasserVornamenBesch { get; set; }

        [StringLength(200)]
        public string ErblasserZivilstand { get; set; }

        [StringLength(100)]
        public string ErblasserZivilstandBesch { get; set; }

        [StringLength(11)]
        public string lasserLasserin { get; set; }

        [StringLength(929)]
        public string ErblasserInfo1 { get; set; }

        [StringLength(797)]
        public string ErblasserInfo2 { get; set; }

        [StringLength(696)]
        public string ErblasserInfo3 { get; set; }

        [StringLength(602)]
        public string ErblasserInfo4 { get; set; }
    }
}
