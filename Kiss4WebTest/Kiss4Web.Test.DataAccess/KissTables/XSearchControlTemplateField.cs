namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XSearchControlTemplateField")]
    public partial class XSearchControlTemplateField
    {
        public int XSearchControlTemplateFieldID { get; set; }

        public int XSearchControlTemplateID { get; set; }

        [Required]
        [StringLength(100)]
        public string ControlName { get; set; }

        [Required]
        [StringLength(100)]
        public string ControlType { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        public virtual XSearchControlTemplate XSearchControlTemplate { get; set; }
    }
}
