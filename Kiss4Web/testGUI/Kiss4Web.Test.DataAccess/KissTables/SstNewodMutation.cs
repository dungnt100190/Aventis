namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SstNewodMutation")]
    public partial class SstNewodMutation
    {
        [Key]
        public int NewodMutationID { get; set; }

        public int NewodNummer { get; set; }

        public string Data { get; set; }

        [StringLength(4)]
        public string Mutationsart { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime Imported { get; set; }

        public bool Processed { get; set; }
    }
}
