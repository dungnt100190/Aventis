using System;
using Kiss4Web.Model.Entities;
using Kiss4Web.Model.System;

namespace Kiss4Web.Model
{
    public partial class XDocument : IEntity
    {
        public DateTime? CheckOutDate { get; set; }
        public string CheckOutFilename { get; set; }
        public string CheckOutMachine { get; set; }
        public int? CheckOutUserId { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateLastRead { get; set; }
        public DateTime DateLastSave { get; set; }
        public DocFormat? DocFormatCode { get; set; }
        public bool DocReadOnly { get; set; }
        public int? DocTemplateId { get; set; }
        public string DocTemplateName { get; set; }
        public int? DocTypeCode { get; set; }
        public int DocumentId { get; set; }
        public byte[] FileBinary { get; set; }
        public string FileExtension { get; set; }
        public int Id => DocumentId;
        public byte[] RowVersion => XdocumentTs;
        public int? UserIdCreator { get; set; }
        public int? UserIdLastRead { get; set; }
        public int? UserIdLastSave { get; set; }
        public byte[] XdocumentTs { get; set; }
    }
}