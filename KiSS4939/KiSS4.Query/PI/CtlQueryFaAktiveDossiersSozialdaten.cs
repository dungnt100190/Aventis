using System;

using KiSS4.Common.PI;
using KiSS4.DB;

namespace KiSS4.Query.PI
{
    /// <summary>
    /// Control, used as query for Pro Infirmis "Aktvie Dossiers Sozialdaten"
    /// </summary>
    public class CtlQueryFaAktiveDossiersSozialdaten : KiSS4.Query.PI.CtlQueryFaAktiveDossiersBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryFaAktiveDossiersSozialdaten"/> class.
        /// </summary>
        public CtlQueryFaAktiveDossiersSozialdaten()
        {
            // set name of base (for translation of columns)
            base.Name = "CtlQueryFaAktiveDossiersSozialdaten";

            // set base-rights
            base.RightNameKostenstelleHS = "QRYAktiveDossiersSozialdatenKostenstelleHS";
            base.RightNameKostenstelleKGS = "QRYAktiveDossiersSozialdatenKostenstelleKGS";

            // set base-result table
            base.QueryResultTable = "klientsozdaten";

            // setup search
            base.UseSearchFilterCheckboxOnlySB = true;
        }

        #endregion
    }
}