using System;
using System.Collections.Generic;
using System.Text;

namespace KiSS4.DB
{
    /// <summary>
    /// Version des Kiss-Clients (Major.Minor.Build.Revision), die einmal zentral hier ge�ndert werden kann und dann in allen Assemblies �bernommen wird beim Kompilieren
    /// </summary>
    public class Version
    {
        /// <summary>
        /// Die MainVersion muss manuell nachgef�hrt werden (MajorVersion.MinorVersion.Build)
        /// - Major wird offensichtlich nur bei grossen �berarbeitungen inkrementiert
        /// - Minor wird dann inkrementiert, wenn neue Funktionalit�t im KiSS-Core dazugekommen ist, die f�r den Benutzer relevant und/oder sichtbar ist
        /// - Build wird mindestens f�r jeden Build, der an einen Kunden ausgeliefert wird (auch f�r Testing), inkrementiert. 
        /// </summary>
        public const String MainVersion = "4.1.14";

        /// <summary>
        /// Die AssemblyVersion wird in den AssemblyInfo.cs files verwendet, um die Assembly-Version und File-Version bei jedem Build eindeutig festzulegen
        /// - Die Revision-Nummer am Schluss wird automatisch vom Compiler generiert und entspricht der Anzahl Sekunden seit Mitternacht dividiert durch 2
        ///     => Das f�hrt dazu, dass die Assemblies eines Builds nicht alle die exakt gleiche Revision-Nummer haben, da der Kompiliervorgang typischerweise l�nger als 2 Sekunden geht :-)
        /// </summary>
        public const String AssemblyVersion = MainVersion + ".*";
    }
}