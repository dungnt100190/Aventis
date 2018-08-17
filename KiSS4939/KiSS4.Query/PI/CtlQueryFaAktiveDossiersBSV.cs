namespace KiSS4.Query.PI
{
    public class CtlQueryFaAktiveDossiersBSV : CtlQueryFaAktiveNeueDossiersBase
    {
        #region Constructors

        public CtlQueryFaAktiveDossiersBSV()
        {
            // set name of base (for translation of columns)
            Name = "CtlQueryFaAktiveDossiersBSV";

            // set base-values
            OnlyNewClients = false;

            // set base-rights
            RightNameKostenstelleHS = "QRYAktiveDossiersBSVKostenstelleHS";
            RightNameKostenstelleKGS = "QRYAktiveDossiersBSVKostenstelleKGS";
        }

        #endregion
    }
}