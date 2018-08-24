namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BgGruppe_BFSFrage
    {
        public int BgGruppe_BFSFrageID { get; set; }

        public int BgGruppeCode { get; set; }

        [Required]
        [StringLength(10)]
        public string Variable { get; set; }
    }
}
