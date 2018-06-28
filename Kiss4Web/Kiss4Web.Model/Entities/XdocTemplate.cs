using System;
using System.Collections.Generic;
using Kiss4Web.Model.System;

namespace Kiss4Web.Model
{
    public partial class XDocTemplate
    {
        public XDocTemplate()
        {
            XdocContextTemplate = new HashSet<XdocContextTemplate>();
            XorgUnitXdocTemplate = new HashSet<XorgUnitXdocTemplate>();
            XuserXdocTemplate = new HashSet<XuserXdocTemplate>();
        }

        public DateTime? CheckOutDate { get; set; }
        public string CheckOutFilename { get; set; }
        public string CheckOutMachine { get; set; }
        public XUser CheckOutUser { get; set; }
        public int? CheckOutUserId { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateLastSave { get; set; }
        public DocFormat? DocFormatCode { get; set; }
        public int DocTemplateId { get; set; }
        public string DocTemplateName { get; set; }
        public byte[] DocTemplateTs { get; set; }
        public byte[] FileBinary { get; set; }
        public string FileExtension { get; set; }
        public ICollection<XdocContextTemplate> XdocContextTemplate { get; set; }
        public ICollection<XorgUnitXdocTemplate> XorgUnitXdocTemplate { get; set; }
        public Xprofile Xprofile { get; set; }
        public int? XprofileId { get; set; }
        public ICollection<XuserXdocTemplate> XuserXdocTemplate { get; set; }
    }
}