namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwUserSimple")]
    public partial class vwUserSimple
    {
        [Key]
        [Column(Order = 0)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string LogonName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(402)]
        public string NameVorname { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(605)]
        public string DisplayText { get; set; }
    }
}
