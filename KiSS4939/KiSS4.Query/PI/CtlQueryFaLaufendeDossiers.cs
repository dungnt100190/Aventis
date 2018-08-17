namespace KiSS4.Query.PI
{
    public class CtlQueryFaLaufendeDossiers : KiSS4.Query.PI.CtlQueryFaLaufendeAbgeschlosseneDossiersBase
    {
        #region Constructors

        public CtlQueryFaLaufendeDossiers()
        {
            // set name of base (for translation of columns)
            Name = "CtlQueryFaLaufendeDossiers";

            // set base-values
            OpenCases = true;      // only open cases

            // set base-rights
            RightNameKostenstelleHS = "QRYLaufendeDossiersKostenstelleHS";
            RightNameKostenstelleKGS = "QRYLaufendeDossiersKostenstelleKGS";

            // hide checkbox: chkSucheNurEndgueltigGeschlosseneDossiers
            ChkSucheNurEndgueltigGeschlosseneDossiersVisible = false;

            Load += CtlQueryFaLaufendeDossiers_Load;
        }

        #endregion

        #region EventHandlers

        private void CtlQueryFaLaufendeDossiers_Load(object sender, System.EventArgs e)
        {
            qryQuery.AfterFill += qryQuery_AfterFill;
        }

        private void qryQuery_AfterFill(object sender, System.EventArgs e)
        {
            HideColumn("Abschlussgrund IN");
            HideColumn("Abschlussgrund SB");
            HideColumn("Abschlussgrund CM");
            HideColumn("Abschlussgrund BW");
            HideColumn("Abschlussgrund ED");
        }

        #endregion

        #region Methods

        #region Private Methods

        private void HideColumn(string columnName)
        {
            var column = grvQuery1.Columns[columnName];
            if (column != null)
            {
                column.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}