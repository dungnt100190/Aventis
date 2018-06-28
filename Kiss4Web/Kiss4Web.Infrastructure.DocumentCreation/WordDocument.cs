using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Kiss4Web.Model.System;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class WordDocument : OfficeDocument
    {
        public WordDocument(byte[] document, bool openAsTemplate = false)
            : base(DocFormat.Word, document)
        {
            if (document != null)
            {
                Document = WordprocessingDocument.Open(DocumentStream, true, new OpenSettings { AutoSave = true });
            }
            else
            {
                var doc = WordprocessingDocument.Create(DocumentStream, WordprocessingDocumentType.Document, true);
                var mainDocumentPart = doc.AddMainDocumentPart();
                mainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                mainDocumentPart.Document.Save();
                Document = doc;
            }
            WordprocessingDocument.ChangeDocumentType(openAsTemplate ? WordprocessingDocumentType.Template : WordprocessingDocumentType.Document);
        }

        public WordDocument(bool createAsTemplate = false)
            : this(null, createAsTemplate)
        {
        }

        public override string FileExtension => IsTemplate ? ".dotx" : ".docx";

        public override bool IsTemplate => WordprocessingDocument.DocumentType == WordprocessingDocumentType.Template;

        public WordprocessingDocument WordprocessingDocument => (WordprocessingDocument)Document;

        protected override CustomFilePropertiesPart GetCustomFilePropertiesPart()
        {
            return WordprocessingDocument.CustomFilePropertiesPart;
        }

        protected override DocumentSettingsPart GetDocumentSettingsPart()
        {
            return WordprocessingDocument.MainDocumentPart.DocumentSettingsPart;
        }
    }
}