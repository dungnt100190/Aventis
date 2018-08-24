namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewodPerson")]
    public partial class NewodPerson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewodPersonID { get; set; }

        [Required]
        [StringLength(100)]
        public string Vorname { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string AHVNummer { get; set; }

        [Required]
        [StringLength(20)]
        public string Versichertennummer { get; set; }

        [Required]
        [StringLength(50)]
        public string GeburtsdatumString { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        [Required]
        [StringLength(60)]
        public string Strasse { get; set; }

        [Required]
        [StringLength(10)]
        public string HausNr { get; set; }

        [Required]
        [StringLength(10)]
        public string HausNrZusatz { get; set; }

        [Required]
        [StringLength(10)]
        public string PLZ { get; set; }

        [Required]
        [StringLength(60)]
        public string Ort { get; set; }
    }
}
