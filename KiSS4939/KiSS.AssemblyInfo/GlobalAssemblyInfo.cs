namespace BIAG.AssemblyInfo
{
    /// <summary>
    /// Klasse, welche die globalen Assembly-Informationen definiert. Diese Klasse wird vom AssemblyInfoTask vor dem Kompilieren automatisch
    /// angepasst uns muss deshalb nicht mehr manuell veraendert werden.
    ///
    /// Achtung: Ist diese Klasse im VisualStudio-Editor waehrend dem Kopilieren geoeffnet, so werden die Versionsnummern erst nach dem
    ///          Kompilieren gesetzt und sind somit nicht aktuell! Deshalb diese Klasse immer vor dem Kompilieren schliessen!
    /// </summary>
    public class GlobalAssemblyInfo
    {
        /// <summary>
        /// Die AssemblyCompany fuer alle BIAG-Assemblies
        /// </summary>
        public const string AssemblyCompany = "Diartis AG";

        /// <summary>
        /// Das AssemblyCopyright fuer alle BIAG-Assemblies
        /// </summary>
        public const string AssemblyCopyright = "(c) 2018 Diartis AG";

        /// <summary>
        /// Die AssemblyFileVersion fuer alle KiSS-Assemblies.
        /// </summary>
        /// <remarks>Siehe Remarks in AssemblyVersion!</remarks>
        public const string AssemblyFileVersion = "4.9.39.106";

        /// <summary>
        /// Die default-culture für alle KiSS-Assemblies
        /// </summary>
        /// <remarks>Damit findet der ResourceManager die default-Resourcen (Ressources.resx) auch nach einem dynamischen Laden der Assemby
        /// MSDN: Informs the resource manager of an app's default culture</remarks>
        public const string AssemblyNeutralResourcesLanguage = "de-CH";

        /// <summary>
        /// Die AssemblyVersion fuer alle KiSS-Assemblies.
        /// </summary>
        /// <remarks>
        /// Hier wird die AssemblyVersion fuer alle BIAG-Assemblies definiert.
        /// Dieser Wert wird mit Hilfe der AssemblyInfoTask-Erweiterung automatisch
        /// berechnet und gesetzt. Es ist somit kein manuelles Anpassen von Build
        /// und Revision mehr noetig.
        ///
        /// Per Definiton wird die AssemblyVersion nach folgendem Muster generiert:
        ///   Major.Minor.KalenderWoche.WochenTag und StundenImWochentag,
        ///   wobei Major und Minor hier und Build und Revision in der Datei
        ///   Microsoft.VersionNumber.targets gesetzt werden.
        ///   Beispiel: Fuer Dienstag, 14.4.2009 (KW=16) um 13:22: "Major.Minor.16.213"
        ///
        /// Achtung: An dieser Konstaten nur Major und Minor nachfuehren, sonst nichts mehr veraendern.
        ///          Es sollte immer der Wert "Major.Minor.0.0" gesetzt sein (z.B.: "4.1.0.0").
        /// </remarks>
        public const string AssemblyVersion = "4.9.39.106";

        /// <summary>
        /// Die aelteste noch kompatible DB-Version.
        /// </summary>
        /// <remarks>
        /// Diese Version wird mit der DBVersion (Aktuellster Eintrag in Tabelle XDBVersion) verglichen.
        /// Wenn die DBVersion diese Version (oder neuer) hat, dann ist die DB mit dem Client kompatibel. Diese Pruefung finden beim Verbinden der Session statt.
        ///
        /// Der XDBVersion-Eintrag in der DB hat ebenfalls eine BackwardCompatibleDownToClientVersion, die beim Verbinden der Session ebenfalls geprueft wird, hier allerdings umgekehrt,
        /// d.h. nur wenn der Client diese Version (oder neuer) hat, dann ist der Client mit der DB kompatibel.
        ///
        /// Ein neuer XDBVersion-Eintrag wird mit der Stored Procedure spXDBVersionAddEntry erstellt, z.B.
        ///
        ///     EXEC dbo.spXDBVersionAddEntry @MajorVersion=4, @MinorVersion=1, @Build=37, @Revision=803, @BackwardCompatibleDownToClientVersion='4.1.37.803', @Description='Build fuer FAMOZ ZH'
        ///
        /// Der aktuelle XDBVersion-Eintrag kann mit der Stored Procedure spXDBVersionGetCurrentVersion ausgelesen werden
        /// </remarks>
        public const string BackwardCompatibleDownToDBVersion = "4.9.39.0";
    }
}