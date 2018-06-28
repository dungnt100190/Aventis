using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class XmenuItem
    {
        public XmenuItem()
        {
            InverseParentMenuItem = new HashSet<XmenuItem>();
        }

        public int MenuItemId { get; set; }
        public int? ParentMenuItemId { get; set; }
        public string ControlName { get; set; }
        public bool BeginMenuGroup { get; set; }
        public bool? Enabled { get; set; }
        public bool? Visible { get; set; }
        public string Caption { get; set; }
        public int? MenuTid { get; set; }
        public bool ItemShortcutCtrl { get; set; }
        public bool ItemShortcutShift { get; set; }
        public bool ItemShortcutAlt { get; set; }
        public string ItemShortcutKey { get; set; }
        public int ImageIndex { get; set; }
        public int ImageIndexDisabled { get; set; }
        public int? SortKey { get; set; }
        public string ClassName { get; set; }
        public bool ShowInToolbar { get; set; }
        public bool BeginToolbarGroup { get; set; }
        public int? ToolbarSortKey { get; set; }
        public bool System { get; set; }
        public bool HideLockedItems { get; set; }
        public string Description { get; set; }
        public byte[] XmenuItemTs { get; set; }
        public bool OnlyBiagadminVisible { get; set; }

        public XmenuItem ParentMenuItem { get; set; }
        public ICollection<XmenuItem> InverseParentMenuItem { get; set; }
    }
}
