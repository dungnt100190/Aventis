namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FaPendenzgruppe_User
    {
        public int FaPendenzgruppe_UserID { get; set; }

        public int FaPendenzgruppeID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FaPendenzgruppe_UserTS { get; set; }

        public virtual FaPendenzgruppe FaPendenzgruppe { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
