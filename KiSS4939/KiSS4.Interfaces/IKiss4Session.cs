using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Interfaces
{
    public interface IKiss4Session
    {
        /// <summary>
        /// Returns the DB-Connectionstring from the KiSS4.DB.Session-Object
        /// </summary>
        string ConnectionString { get; }
    }
}
