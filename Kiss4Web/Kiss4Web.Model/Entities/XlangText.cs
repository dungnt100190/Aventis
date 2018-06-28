using Kiss4Web.Infrastructure;

namespace Kiss4Web.Model
{
    public partial class XLangText
    {
        public int Tid { get; set; }
        public LanguageCode LanguageCode { get; set; }
        public string Text { get; set; }
        public string LargeText { get; set; }
        public byte[] XlangTextTs { get; set; }
    }
}