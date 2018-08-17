using System;
using System.Reflection;
using System.Text;
using log4net;

namespace KiSSSvc.Logging
{
    /// <summary>
    /// A helper class to simplify the logging.
    /// The logger contains the name of the class.
    /// </summary>
    /// <remarks>
    /// Logging is done by Log4Net
    /// </remarks>
    public class ServerVersion
    {
        // Die AssemblyVersion wird in den AssemblyInfo.cs files verwendet,
        // um die Assembly-Version und File-Version bei jedem Build eindeutig festzulegen
        public const string AssemblyVersion = Version + "." + Revision;

        // Die letzte Ziffer ist eine manuell inkrementierte Revision, die anzeigt, welche Inkrementversion nach dem Release es ist, z.B. 4
        // Diese Revision muss vor jedem neuen Release inkrementiert werden, resp. falls die ServerVersion erhöht wird, kann die Revision wieder auf 0 gesetzt werden
        private const string Revision = "100";

        // Die 3 ersten Stellen der Version des Services sollte immer mit der KiSS-Client-Version des Releases zusammenstimmen, z.B. 4.2.33
        private const string Version = "4.9.39";
    }
}