namespace KiSS4.Query.PI
{
    /// <summary>
    /// Control, used as query for Pro Infirmis "Aktvie Dossiers BW"
    /// </summary>
    public class CtlQueryFaAktiveDossiersBW : CtlQueryFaAktiveDossiersBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryFaAktiveDossiersBW"/> class.
        /// </summary>
        public CtlQueryFaAktiveDossiersBW()
        {
            // set name of base (for translation of columns)
            base.Name = "CtlQueryFaAktiveDossiersBW";

            // set base-rights
            base.RightNameKostenstelleHS = "QRYAktiveDossiersBWKostenstelleHS";
            base.RightNameKostenstelleKGS = "QRYAktiveDossiersBWKostenstelleKGS";

            // set base-result table
            base.QueryResultTable = "klientsozdatenbw";

            // setup search
            base.UseSearchFilterCheckboxOnlySB = false;
        }

        #endregion
    }
}