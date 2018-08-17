namespace KiSS4.Query.PI
{
    /// <summary>
    /// Control, used as query for Pro Infirmis "Aktvie Dossiers BW"
    /// </summary>
    public class CtlQueryFaAktiveDossiersAB : CtlQueryFaAktiveDossiersBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryFaAktiveDossiersAB"/> class.
        /// </summary>
        public CtlQueryFaAktiveDossiersAB()
        {
            // set name of base (for translation of columns)
            Name = "CtlQueryFaAktiveDossiersAB";

            // set base-rights
            RightNameKostenstelleHS = "QRYAktiveDossiersBWKostenstelleHS";
            RightNameKostenstelleKGS = "QRYAktiveDossiersBWKostenstelleKGS";

            // set base-result table
            QueryResultTable = "klientsozdatenab";

            // setup search
            UseSearchFilterCheckboxOnlySB = false;

        }
    }
}