using System;
using System.Collections.Generic;
using Kiss4Web.Model.System;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public interface IOfficeDocument : IDisposable
    {
        string FileExtension { get; }

        DocFormat Format { get; }

        bool IsTemplate { get; }

        IEnumerable<string> GetDocumentProperties();

        byte[] GetFileBinary();

        bool SetDocumentProperty<T>(string propertyName, T value);
    }
}