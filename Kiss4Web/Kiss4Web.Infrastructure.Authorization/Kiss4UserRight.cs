namespace Kiss4Web.Infrastructure.Authorization
{
    public class Kiss4UserRight
    {
        public string ClassName { get; set; }
        public string RightName { get; set; }
        public bool MayInsert { get; set; }
        public bool MayUpdate { get; set; }
        public bool MayDelete { get; set; }
    }
}