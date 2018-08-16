using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Model.QueryTypes
{
    public class ErstellerItem
    {
        public string Typ { get; set; }
        public string Kurzel { get; set; }
        public string Name { get; set; }
        public string Abteilung { get; set; }
        public int? Id { get; set; }
        public int TypeCode { get; set; }
        public string DisplayText { get; set; }
    }
}
