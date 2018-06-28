using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xprofile
    {
        public Xprofile()
        {
            XdocTemplate = new HashSet<XDocTemplate>();
            XorgUnit = new HashSet<XOrgUnit>();
            XprofileXprofileTag = new HashSet<XprofileXprofileTag>();
            Xuser = new HashSet<XUser>();
        }

        public int XprofileId { get; set; }
        public int XprofileTypeCode { get; set; }
        public int? NameTid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XprofileTs { get; set; }

        public ICollection<XDocTemplate> XdocTemplate { get; set; }
        public ICollection<XOrgUnit> XorgUnit { get; set; }
        public ICollection<XprofileXprofileTag> XprofileXprofileTag { get; set; }
        public ICollection<XUser> Xuser { get; set; }
    }
}
