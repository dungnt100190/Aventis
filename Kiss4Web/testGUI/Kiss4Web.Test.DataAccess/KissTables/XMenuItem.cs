namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XMenuItem")]
    public partial class XMenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XMenuItem()
        {
            XMenuItem1 = new HashSet<XMenuItem>();
        }

        [Key]
        public int MenuItemID { get; set; }

        public int? ParentMenuItemID { get; set; }

        [StringLength(255)]
        public string ControlName { get; set; }

        public bool BeginMenuGroup { get; set; }

        public bool Enabled { get; set; }

        public bool Visible { get; set; }

        [Required]
        [StringLength(100)]
        public string Caption { get; set; }

        public int? MenuTID { get; set; }

        public bool ItemShortcutCtrl { get; set; }

        public bool ItemShortcutShift { get; set; }

        public bool ItemShortcutAlt { get; set; }

        [StringLength(50)]
        public string ItemShortcutKey { get; set; }

        public int ImageIndex { get; set; }

        public int ImageIndexDisabled { get; set; }

        public int? SortKey { get; set; }

        [StringLength(255)]
        public string ClassName { get; set; }

        public bool ShowInToolbar { get; set; }

        public bool BeginToolbarGroup { get; set; }

        public int? ToolbarSortKey { get; set; }

        public bool System { get; set; }

        public bool HideLockedItems { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XMenuItemTS { get; set; }

        public bool OnlyBIAGAdminVisible { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XMenuItem> XMenuItem1 { get; set; }

        public virtual XMenuItem XMenuItem2 { get; set; }
    }
}
