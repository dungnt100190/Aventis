namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BFSFarbCode")]
    public partial class BFSFarbCode
    {
        public int BFSFarbCodeID { get; set; }

        public int Leistungsfilter { get; set; }

        public int ExcelFarbCode { get; set; }

        public int BFSFrageID { get; set; }

        public virtual BFSFrage BFSFrage { get; set; }
    }
}
