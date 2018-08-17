
namespace KiSS4.Query.PI
{
    public class CtlQueryFaAbgeschlosseneDossiers : KiSS4.Query.PI.CtlQueryFaLaufendeAbgeschlosseneDossiersBase
    {
        #region Constructors

        public CtlQueryFaAbgeschlosseneDossiers()
        {
            // set name of base (for translation of columns)
            base.Name = "CtlQueryFaAbgeschlosseneDossiers";

            // set base-values
            base.OpenCases = false;     // only closed cases

            // set base-rights
            base.RightNameKostenstelleHS = "QRYAbgeschlosseneDossiersKostenstelleHS";
            base.RightNameKostenstelleKGS = "QRYAbgeschlosseneDossiersKostenstelleKGS";
        }

        #endregion
    }
}