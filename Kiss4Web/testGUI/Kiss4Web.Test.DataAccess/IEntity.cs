using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiss4Web.Test.DataAccess
{
    public interface IEntity
    {
        int Id { get; }
        byte[] RowVersion { get; }
    }
}
