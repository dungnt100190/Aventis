using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiss4Web.Test.DataAccess
{
    public interface IAuditableEntity
    {
        DateTime Created { get; set; }
        string Creator { get; set; }
        DateTime Modified { get; set; }
        string Modifier { get; set; }
    }
}
