using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class DynaMask
    {
        public DynaMask()
        {
            DynaField = new HashSet<DynaField>();
            XmodulTree = new HashSet<XmodulTree>();
            XuserGroupRight = new HashSet<XUserGroupRight>();
        }

        public string MaskName { get; set; }
        public string ParentMaskName { get; set; }
        public int? ParentPosition { get; set; }
        public int ModulId { get; set; }
        public int? FaModulCode { get; set; }
        public int? FaPhaseCode { get; set; }
        public int? VmProzessCode { get; set; }
        public string DisplayText { get; set; }
        public int? IconId { get; set; }
        public string TabNames { get; set; }
        public int? GridHeight { get; set; }
        public bool? System { get; set; }
        public bool? Active { get; set; }
        public string AppCode { get; set; }
        public byte[] DynaMaskTs { get; set; }
        public int? KaProzessCode { get; set; }
        public int? DisplayTextTid { get; set; }

        public XModul Modul { get; set; }
        public ICollection<DynaField> DynaField { get; set; }
        public ICollection<XmodulTree> XmodulTree { get; set; }
        public ICollection<XUserGroupRight> XuserGroupRight { get; set; }
    }
}
