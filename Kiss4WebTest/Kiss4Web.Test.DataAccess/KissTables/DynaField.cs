namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DynaField")]
    public partial class DynaField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DynaField()
        {
            DynaValues = new HashSet<DynaValue>();
        }

        public int DynaFieldID { get; set; }

        [Required]
        [StringLength(100)]
        public string MaskName { get; set; }

        [Required]
        [StringLength(100)]
        public string FieldName { get; set; }

        public int FieldCode { get; set; }

        [StringLength(200)]
        public string DisplayText { get; set; }

        public int TabPosition { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? Length { get; set; }

        [StringLength(100)]
        public string LOVName { get; set; }

        [StringLength(4000)]
        public string SQL { get; set; }

        [StringLength(200)]
        public string DefaultValue { get; set; }

        public bool? Mandatory { get; set; }

        [StringLength(50)]
        public string TabName { get; set; }

        [StringLength(100)]
        public string GridColTitle { get; set; }

        public int? GridColWidth { get; set; }

        public int? GridColPosition { get; set; }

        [StringLength(200)]
        public string AppCode { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] DynaFieldTS { get; set; }

        public int? GridColTitleTID { get; set; }

        public int? DisplayTextTID { get; set; }

        public virtual DynaMask DynaMask { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DynaValue> DynaValues { get; set; }
    }
}
