namespace KiSS4.Query.PI
{
    /// <summary>
    /// Control, used as query for Pro Infirmis "Aktvie Dossiers ED"
    /// </summary>
    public class CtlQueryFaAktiveDossiersED : CtlQueryFaAktiveDossiersBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryFaAktiveDossiersED"/> class.
        /// </summary>
        public CtlQueryFaAktiveDossiersED()
        {
            // set name of base (for translation of columns)
            base.Name = "CtlQueryFaAktiveDossiersED";

            // set base-rights
            base.RightNameKostenstelleHS = "QRYAktiveDossiersEDKostenstelleHS";
            base.RightNameKostenstelleKGS = "QRYAktiveDossiersEDKostenstelleKGS";

            // set base-result table
            base.QueryResultTable = "klientsozdatened";

            // setup search
            base.UseSearchFilterCheckboxOnlySB = false;
        }

        #endregion
    }
}