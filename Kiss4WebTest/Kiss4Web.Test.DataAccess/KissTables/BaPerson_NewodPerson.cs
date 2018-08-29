namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BaPerson_NewodPerson
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewodPersonID { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool AuslaenderAktiveSozialhilfe { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool SchweizerAktiveSozialhilfe { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool SchweizerAktiveVormundschaft { get; set; }

        public DateTime? Aktualisiert { get; set; }

        public virtual BaPerson BaPerson { get; set; }
    }
}
