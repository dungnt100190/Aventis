using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class ServiceProcessErrorMessage
    {
        public int ServiceProcessErrorMessageId { get; set; }
        public int ServiceProcessErrorId { get; set; }
        public string Message { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] ServiceProcessErrorMessageTs { get; set; }

        public ServiceProcessError ServiceProcessError { get; set; }
    }
}
