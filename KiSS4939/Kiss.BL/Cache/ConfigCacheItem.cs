using System;

namespace Kiss.BL.Cache
{
    internal class ConfigCacheItem
    {
        public string KeyPath { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }

        public string ValueVarchar { get; set; }
        public decimal? ValueDecimal { get; set; }
        public int? ValueInt { get; set; }
        public bool? ValueBool { get; set; }
        public DateTime? ValueDateTime { get; set; }
        public string LovName { get; set; }
    }
}
