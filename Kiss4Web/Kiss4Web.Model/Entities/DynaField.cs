using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class DynaField
    {
        public DynaField()
        {
            DynaValue = new HashSet<DynaValue>();
        }

        public int DynaFieldId { get; set; }
        public string MaskName { get; set; }
        public string FieldName { get; set; }
        public int FieldCode { get; set; }
        public string DisplayText { get; set; }
        public int TabPosition { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Length { get; set; }
        public string Lovname { get; set; }
        public string Sql { get; set; }
        public string DefaultValue { get; set; }
        public bool? Mandatory { get; set; }
        public string TabName { get; set; }
        public string GridColTitle { get; set; }
        public int? GridColWidth { get; set; }
        public int? GridColPosition { get; set; }
        public string AppCode { get; set; }
        public byte[] DynaFieldTs { get; set; }
        public int? GridColTitleTid { get; set; }
        public int? DisplayTextTid { get; set; }

        public DynaMask MaskNameNavigation { get; set; }
        public ICollection<DynaValue> DynaValue { get; set; }
    }
}
