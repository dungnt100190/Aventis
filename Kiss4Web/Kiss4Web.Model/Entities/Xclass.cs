using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XClass : IEntity
    {
        public XClass()
        {
            Xright = new HashSet<XRight>();
            XuserGroupRight = new HashSet<XUserGroupRight>();
        }

        public int XclassId { get; set; }
        public string ClassName { get; set; }
        public string ClassNameViewModel { get; set; }
        public int ModulId { get; set; }
        public string MaskName { get; set; }
        public string BaseType { get; set; }
        public int? ClassCode { get; set; }
        public int? ClassTid { get; set; }
        public string PropertiesXml { get; set; }
        public int Designer { get; set; }
        public string Description { get; set; }
        public string CodeGenerated { get; set; }
        public byte[] Resource { get; set; }
        public byte[] Assembly { get; set; }
        public string Branch { get; set; }
        public int BuildNr { get; set; }
        public bool System { get; set; }
        public int? CheckOutUserId { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string NamespaceExtension { get; set; }
        public byte[] XclassTs { get; set; }

        public XModul Modul { get; set; }
        public ICollection<XRight> Xright { get; set; }
        public ICollection<XUserGroupRight> XuserGroupRight { get; set; }
        public int Id => XclassId;
        public byte[] RowVersion => XclassTs;
    }
}