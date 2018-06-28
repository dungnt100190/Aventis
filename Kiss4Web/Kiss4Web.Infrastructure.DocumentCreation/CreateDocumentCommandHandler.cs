using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Kiss4Web.Model.System;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class CreateDocumentCommandHandler : TypedMessageHandler<CreateDocumentCommand, XDocument>
    {
        private readonly Kiss4BookmarkReplacer _bookmarkReplacer;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IRepository<XDocument> _documents;
        private readonly IQueryable<XDocTemplate> _templates;
        private readonly AuthenticatedUserId _userId;

        public CreateDocumentCommandHandler(IQueryable<XDocTemplate> templates,
                                            IRepository<XDocument> documents,
                                            IDateTimeProvider dateTimeProvider,
                                            AuthenticatedUserId userId,
                                            Kiss4BookmarkReplacer bookmarkReplacer)
        {
            _templates = templates;
            _documents = documents;
            _dateTimeProvider = dateTimeProvider;
            _userId = userId;
            _bookmarkReplacer = bookmarkReplacer;
        }

        public override async Task<XDocument> Handle(CreateDocumentCommand query)
        {
            var template = await _templates.FirstAsync(tpl => tpl.DocTemplateId == query.XDocTemplateId);
            if (template.DocFormatCode == DocFormat.Word)
            {
                using (var document = OfficeDocument.Open(template))
                {
                    await _bookmarkReplacer.ReplaceBookmarks((document as WordDocument)?.WordprocessingDocument, query.ContextValues);

                    var now = _dateTimeProvider.Now;
                    var xdocument = new XDocument
                    {
                        DocTemplateId = template.DocTemplateId,
                        DateCreation = now,
                        DateLastSave = now,
                        UserIdCreator = _userId,
                        UserIdLastSave = _userId,
                        DocFormatCode = DocFormat.Word,
                        FileExtension = "dotx",
                        DocTemplateName = template.DocTemplateName,
                        FileBinary = document.GetFileBinary()
                    };
                    await _documents.InsertOrUpdateEntity(xdocument);

                    File.WriteAllBytes($@"C:\temp\{Guid.NewGuid()}.dotx", document.GetFileBinary().ToArray());
                    return xdocument;
                }
            }

            throw new NotImplementedException("Only word document generation is implemented yet");
        }
    }
}