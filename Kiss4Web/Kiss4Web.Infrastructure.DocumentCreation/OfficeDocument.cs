using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.CustomProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using Kiss4Web.Model;
using Kiss4Web.Model.System;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public abstract class OfficeDocument : IOfficeDocument
    {
        protected OfficeDocument(DocFormat format, byte[] document)
        {
            Format = format;
            DocumentStream = new MemoryStream();

            if (document != null)
            {
                DocumentStream.Write(document, 0, document.Length);
            }
        }

        protected OfficeDocument(DocFormat format)
            : this(format, null)
        {
        }

        ~OfficeDocument()
        {
            Dispose(false);
        }

        public OpenXmlPackage Document { get; protected set; }

        public MemoryStream DocumentStream { get; }

        public abstract string FileExtension { get; }

        public DocFormat Format { get; }

        public abstract bool IsTemplate { get; }

        public static IOfficeDocument Open(XDocument document)
        {
            switch (document.DocFormatCode)
            {
                case DocFormat.Word:
                    return new WordDocument(document.FileBinary);

                //case DocFormat.Excel:
                //    return new ExcelDocument(document.FileBinary);

                //case DocFormat.Powerpoint:
                //    return new PowerpointDocument(document.FileBinary);

                default:
                    return null;
            }
        }

        public static IOfficeDocument Open(XDocTemplate template, bool openAsTemplate = false)
        {
            byte[] unzippedTemplate;
            using (var stream = new MemoryStream(template.FileBinary))
            {
                //using (var zipStream = new DeflateStream(stream, CompressionMode.Decompress)) // .NET class doesn't work, so use SharpZipLib
                using (var zipStream = new InflaterInputStream(stream))
                {
                    using (var unzippedStream = new MemoryStream())
                    {
                        zipStream.CopyTo(unzippedStream);
                        unzippedTemplate = unzippedStream.ToArray();
                    }
                }
            }

            switch (template.DocFormatCode)
            {
                case DocFormat.Word:
                    return new WordDocument(unzippedTemplate, openAsTemplate);

                //case DocFormat.Excel:
                //    return new ExcelDocument(template.FileBinary, openAsTemplate);

                //case DocFormat.Powerpoint:
                //    return new PowerpointDocument(template.FileBinary, openAsTemplate);

                default:
                    return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<string> GetDocumentProperties()
        {
            var result = new List<string>();

            var propertiesPart = GetCustomFilePropertiesPart();
            if (propertiesPart != null)
            {
                var propertyNames = propertiesPart
                    .Properties
                    .OfType<CustomDocumentProperty>()
                    .Select(prp => prp.Name.Value);

                result.AddRange(propertyNames);
            }

            return result;
        }

        public byte[] GetFileBinary()
        {
            Document.Package.Flush();
            var result = new byte[DocumentStream.Length];
            var resultStream = new MemoryStream(result);
            DocumentStream.WriteTo(resultStream);
            return result;
        }

        public virtual bool SetDocumentProperty<T>(string propertyName, T value)
        {
            var propertiesPart = GetCustomFilePropertiesPart();
            if (propertiesPart != null)
            {
                var props = propertiesPart.Properties;
                var prop = props.OfType<CustomDocumentProperty>().FirstOrDefault(p => p.Name.Value == propertyName);
                if (prop == null)
                {
                    prop = new CustomDocumentProperty
                    {
                        Name = propertyName,
                        FormatId = "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}",  // siehe https://msdn.microsoft.com/en-us/library/office/hh674468.aspx
                        PropertyId = props.OfType<CustomDocumentProperty>().Max(prp => (int)prp.PropertyId) + 1
                    };
                    propertiesPart.Properties.AppendChild(prop);
                }
                //prop.SetProperty(value);
                props.Save();

                // Create object to update fields on open
                var settingsPart = GetDocumentSettingsPart();
                if (settingsPart != null)
                {
                    var updateFields = new UpdateFieldsOnOpen { Val = new OnOffValue(true) };
                    settingsPart.Settings.PrependChild(updateFields);
                    settingsPart.Settings.Save();
                }
                return true;
            }
            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Document != null)
                {
                    Document.Dispose();
                    DocumentStream.Close();
                }
            }
        }

        protected abstract CustomFilePropertiesPart GetCustomFilePropertiesPart();

        protected abstract DocumentSettingsPart GetDocumentSettingsPart();
    }
}