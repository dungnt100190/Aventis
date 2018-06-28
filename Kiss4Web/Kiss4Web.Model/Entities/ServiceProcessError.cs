using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class ServiceProcessError
    {
        public ServiceProcessError()
        {
            ServiceProcessErrorMessage = new HashSet<ServiceProcessErrorMessage>();
        }

        public int ServiceProcessErrorId { get; set; }
        public int? UserId { get; set; }
        public int? BaPersonId { get; set; }
        public string FremdsystemId { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Info { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] ServiceProcessErrorTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public XUser User { get; set; }
        public ICollection<ServiceProcessErrorMessage> ServiceProcessErrorMessage { get; set; }
    }
}
