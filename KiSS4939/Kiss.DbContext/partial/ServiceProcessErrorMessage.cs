using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.DbContext
{
    public partial class ServiceProcessErrorMessage
    {
        public ServiceProcessErrorMessage()
        {
        }

        public ServiceProcessErrorMessage(string message)
        {
            Message = message;
        }
    }
}