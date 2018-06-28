namespace Kiss4Web.Model
{
    public partial class XLovCode
    {
        public int? Bfscode { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string LovcodeName { get; set; }
        public string Lovname { get; set; }
        public Xlov LovnameNavigation { get; set; }
        public string ShortText { get; set; }
        public int? ShortTextTid { get; set; }
        public int? SortKey { get; set; }
        public bool System { get; set; }
        public string Text { get; set; }
        public int? TextTid { get; set; }
        public string Value1 { get; set; }
        public int? Value1Tid { get; set; }
        public string Value2 { get; set; }
        public int? Value2Tid { get; set; }
        public string Value3 { get; set; }
        public int? Value3Tid { get; set; }
        public Xlov Xlov { get; set; }
        public int XlovcodeId { get; set; }
        public byte[] XlovcodeTs { get; set; }
        public int Xlovid { get; set; }
    }
}