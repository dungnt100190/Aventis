namespace Kiss.Infrastructure.Document
{
    public class PdfPrintOptions
    {
        public bool DeleteMergedPdfAfterPrinting { get; set; }

        public int MaxDeleteAttemptOfMergedDocument { get; set; }

        public bool MergeBeforePrint { get; set; }

        public string PrinterName { get; set; }

        public string TempPath { get; set; }

        public int WaitTimeAfterPrint { get; set; }
    }
}