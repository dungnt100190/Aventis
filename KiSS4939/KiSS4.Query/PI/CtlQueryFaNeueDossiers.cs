using System;
using System.Windows.Forms;

namespace KiSS4.Query.PI
{
    public class CtlQueryFaNeueDossiers : KiSS4.Query.PI.CtlQueryFaAktiveNeueDossiersBase
    {
        #region Constructors

        public CtlQueryFaNeueDossiers()
        {
            // set name of base (for translation of columns)
            base.Name = "CtlQueryFaNeueDossiers";

            // set base-values
            base.OnlyNewClients = true;

            // set base-rights
            base.RightNameKostenstelleHS = "QRYNeueDossiersKostenstelleHS";
            base.RightNameKostenstelleKGS = "QRYNeueDossiersKostenstelleKGS";
        }

        #endregion
    }
}