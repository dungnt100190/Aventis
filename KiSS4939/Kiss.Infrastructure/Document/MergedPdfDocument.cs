using System.Collections.Generic;
using System.IO;

using Kiss.Interfaces.BL;

namespace Kiss.Infrastructure.Document
{
    public class MergedPdfDocument
    {
        public MergedPdfDocument()
        {
            MergeResult = KissServiceResult.Ok();
        }

        public List<FileInfo> ErrorInputDocuments { get; set; }

        public byte[] MergedDocument { get; set; }

        public IServiceResult MergeResult { get; set; }

        public List<FileInfo> SuccessedInputDocuments { get; set; }
    }
}