namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmVmSachversicherung")]
    public partial class vwTmVmSachversicherung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VmSachversicherungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [StringLength(200)]
        public string VerArt { get; set; }

        [StringLength(100)]
        public string Policenummer { get; set; }

        [StringLength(20)]
        public string Selbstbehalt { get; set; }

        [StringLength(100)]
        public string Grundpraemie { get; set; }

        [StringLength(200)]
        public string Zahlungsturnus { get; set; }

        [StringLength(10)]
        public string LaufzeitVon { get; set; }

        [StringLength(10)]
        public string LaufzeitBis { get; set; }

        [StringLength(10)]
        public string VersichertSeit { get; set; }

        [StringLength(200)]
        public string Person { get; set; }

        public string Bemerkungen { get; set; }

        [StringLength(500)]
        public string Adressat_NameVorname { get; set; }

        [StringLength(111)]
        public string Adressat_StrasseNr { get; set; }

        [StringLength(61)]
        public string Adressat_PLZOrt { get; set; }

        [StringLength(1135)]
        public string Adressat_AdrMehrzeilig { get; set; }

        [StringLength(1135)]
        public string Adressat_AdrEinzeilig { get; set; }
    }
}
