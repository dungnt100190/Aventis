
namespace KiSS4.Query.PI
{
    public class CtlQueryFaNeueDossiersBSV : KiSS4.Query.PI.CtlQueryFaAktiveNeueDossiersBase
    {
        #region Constructors

        public CtlQueryFaNeueDossiersBSV()
        {
            // set name of base (for translation of columns)
            base.Name = "CtlQueryFaNeueDossiersBSV";

            // set base-values
            base.OnlyNewClients = true;

            // set base-rights
            base.RightNameKostenstelleHS = "QRYNeueDossiersBSVKostenstelleHS";
            base.RightNameKostenstelleKGS = "QRYNeueDossiersBSVKostenstelleKGS";
        }

        #endregion

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.SuspendLayout();
            // 
            // xDocument
            // 
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // CtlQueryFaNeueDossiersBSV
            // 
            this.Name = "CtlQueryFaNeueDossiersBSV";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}