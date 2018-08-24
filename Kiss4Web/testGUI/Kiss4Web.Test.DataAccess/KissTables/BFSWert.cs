namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BFSWert")]
    public partial class BFSWert
    {
        public int BFSWertID { get; set; }

        public int BFSDossierID { get; set; }

        public int? BFSDossierPersonID { get; set; }

        public int BFSFrageID { get; set; }

        public string PlausiFehler { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BFSWertTS { get; set; }

        public virtual BFSDossier BFSDossier { get; set; }

        public virtual BFSDossierPerson BFSDossierPerson { get; set; }

        public virtual BFSFrage BFSFrage { get; set; }
    }
}
