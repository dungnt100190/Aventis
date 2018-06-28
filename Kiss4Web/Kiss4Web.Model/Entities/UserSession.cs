using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class UserSession
    {
        public int UserSessionId { get; set; }
        public int UserId { get; set; }
        public string LogonName { get; set; }
        public DateTime LoginDatum { get; set; }
        public DateTime? LogoutDatum { get; set; }
        public string UserName { get; set; }
        public string UserDomainName { get; set; }
        public string MachineName { get; set; }
        public string ClientVersion { get; set; }
        public string WindowsVersion { get; set; }
        public string DotNetVersion { get; set; }
        public int? AufloesungBreite { get; set; }
        public int? AufloesungHoehe { get; set; }
        public string OfficeVersionWord { get; set; }
        public string OfficeVersionExcel { get; set; }
        public string OfficeVersionOutlook { get; set; }
        public string CultureInfo { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] UserSessionTs { get; set; }

        public XUser User { get; set; }
    }
}
