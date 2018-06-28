using System;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class XConfig : IEntity
    {
        public int XconfigId { get; set; }
        public int? XnamespaceExtensionId { get; set; }
        public string KeyPath { get; set; }
        public int? KeyPathTid { get; set; }
        public bool System { get; set; }
        public DateTime? DatumVon { get; set; }
        public int ValueCode { get; set; }
        public string LOVName { get; set; }
        public string Description { get; set; }
        public int? DescriptionTid { get; set; }
        public bool? ValueBit { get; set; }
        public bool? OriginalValueBit { get; set; }
        public DateTime? ValueDateTime { get; set; }
        public DateTime? OriginalValueDateTime { get; set; }
        public decimal? ValueDecimal { get; set; }
        public decimal? OriginalValueDecimal { get; set; }
        public int? ValueInt { get; set; }
        public int? OriginalValueInt { get; set; }
        public decimal? ValueMoney { get; set; }
        public decimal? OriginalValueMoney { get; set; }
        public string ValueVarchar { get; set; }
        public string OriginalValueVarchar { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XconfigTs { get; set; }

        public XnamespaceExtension XnamespaceExtension { get; set; }
        public int Id => XconfigId;
        public byte[] RowVersion => XconfigTs;
    }
}