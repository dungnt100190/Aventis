using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Xceed.Words.NET;

namespace Kiss4Web.Infrastructure.DocumentCreation.Test
{
    public class Kiss4BookmarkReplacerTest
    {
        ////[Fact]
        //public void TestGetBookmarks()
        //{
        //    var stream = new MemoryStream(Resources.Bericht_Vorlage);
        //    var document = WordprocessingDocument.Open(stream, true);
        //    document.ChangeDocumentType(WordprocessingDocumentType.Document);
        //    //var document = WordprocessingDocument.Open(@"c:\temp\Bericht.docx", true);
        //    var replacer = new Kiss4BookmarkReplacer(null, new RequestLanguageCode(LanguageCode.Deutsch));

        //    var documentResult = replacer.ReplaceBookmarks(document);

        //    var filePath = $@"C:\temp\{Guid.NewGuid()}.docx";
        //    document.Package.Flush();
        //    var result = new byte[stream.Length];
        //    var resultStream = new MemoryStream(result);
        //    stream.WriteTo(resultStream);
        //    File.WriteAllBytes(filePath, result);

        //    //Process.Start(filePath);
        //    document.SaveAs(filePath);
        //    document.Package.Flush();
        //}

        //[Fact]
        public void TestGetBookmarksDocXFromDoc()
        {
            var filePath = $@"C:\temp\{Guid.NewGuid()}.docx";
            //using (var document = DocX.Load(new MemoryStream(Resources.Bericht)))
            using (var document = DocX.Load(@"C:\Code\Kiss4Web\tests\Kiss4Web.Infrastructure.DocumentCreation.Test\Resources\Bericht.docx"))
            {
                //document.ApplyTemplate(new MemoryStream(Resources.Bericht));
                //document.se
                var replacer = new Kiss4BookmarkReplacerDocX();

                replacer.ReplaceBookmarks(document);

                document.SaveAs(filePath);
            }
        }

        //[Fact]
        public void TestGetBookmarksDocXFromTemplate()
        {
            //using (var document = DocX.Load(@"C:\Code\Kiss4Web\tests\Kiss4Web.Infrastructure.DocumentCreation.Test\Resources\Vorlage_Standard_Brief.dotx"))
            using (var templateStream = new MemoryStream(Resources.Bericht_Vorlage))
            {
                var template = WordprocessingDocument.Open(templateStream, true);
                template.ChangeDocumentType(WordprocessingDocumentType.Document);
                template.Package.Flush();

                var filePath = $@"C:\temp\{Guid.NewGuid()}.docx";
                using (var document = DocX.Create(templateStream))
                {
                    //using (var documentTemplate = DocX.Load(new MemoryStream(Resources.Bericht)))
                    {
                        //document.ApplyTemplate(new MemoryStream(Resources.Bericht));
                        //document.se
                        var replacer = new Kiss4BookmarkReplacerDocX();

                        replacer.ReplaceBookmarks(document);

                        document.SaveAs(filePath);
                    }
                }
            }
        }

        //private Stream ConvertTemplateToDocument(byte[] )
        //{
        //    var stream = new MemoryStream(Resources.Bericht_Vorlage);
        //    var document = WordprocessingDocument.Open(stream, true);
        //    document.ChangeDocumentType(WordprocessingDocumentType.Document);
        //    return stream;
        //}
    }
}