using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Xdbversion
    {
        public int XdbversionId { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }
        public DateTime VersionDate { get; set; }
        public string SqlserverVersionInfo { get; set; }
        public string ChangesSinceLastVersion { get; set; }
        public string BackwardCompatibleDownToClientVersion { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] XdbversionTs { get; set; }
    }
}
