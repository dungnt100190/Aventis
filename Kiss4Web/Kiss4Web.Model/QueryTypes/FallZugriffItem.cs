namespace Kiss4Web.Model.QueryTypes
{
    public class FallZugriffItem
    {
        public bool MayRead { get; set; }
        public bool MayInsert { get; set; }
        public bool MayUpdate { get; set; }
        public bool MayDelete { get; set; }
        public bool? Closed { get; set; }
        public bool? Archieved { get; set; }
        public bool? MayClose { get; set; }
        public bool? MayReopen { get; set; }
    }
}