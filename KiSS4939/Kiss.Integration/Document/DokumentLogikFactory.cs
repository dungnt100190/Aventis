using Kiss.Interfaces.UI;
using KiSS4.Dokument;

namespace Kiss.Integration.Document
{
    public static class DokumentLogikFactory
    {
        public static IXDocumentLogic CreateDocumentLogic()
        {
            return new XDokumentLogik();
        }
    }
}