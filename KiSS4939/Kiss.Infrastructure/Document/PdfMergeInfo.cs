using System.IO;

namespace Kiss.Infrastructure.Document
{
    public class PdfFileInfo
    {
        public PdfFileInfo()
        {
        }

        public PdfFileInfo(FileInfo fileInfo, bool includeFirstPage = true)
        {
            FileInfo = fileInfo;
            IncludeFirstPage = includeFirstPage;
        }

        public FileInfo FileInfo { get; set; }

        public bool IncludeFirstPage { get; set; }
    }
}