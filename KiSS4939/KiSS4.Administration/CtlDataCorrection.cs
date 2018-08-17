using KiSS4.Common;

namespace KiSS4.Administration
{
    public class CtlDataCorrection : KissNavBarUserControl
    {
        #region Fields

        #region Private Fields

        private KissNavBarItem itmDoubleInstitution = new KissNavBarItem("Doppel-Institutionen", 171, typeof(CtlDoubleInstitution), new object[] { (int)0, (int)0 });
        private KissNavBarItem itmDoublePerson = new KissNavBarItem("Doppel-Personen", 134, typeof(CtlDoublePerson), new object[] { (int)0, (int)0 });
        private KissNavBarItem itmDoublePersonPI = new KissNavBarItem("Doppel-Personen", 134, typeof(PI.CtlDoublePerson), new object[] { (int)0, (int)0 });

        #endregion

        #endregion

        #region Constructors

        public CtlDataCorrection()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // panDetail
            // 
            this.panDetail.Size = new System.Drawing.Size(819, 622);
            // 
            // panTitle
            // 
            this.panTitle.Size = new System.Drawing.Size(819, 29);
            // 
            // splitterNavControl
            // 
            this.splitterNavControl.Size = new System.Drawing.Size(3, 651);
            // 
            // CtlDataCorrection
            // 
            this.ClientSize = new System.Drawing.Size(992, 651);
            this.Name = "CtlDataCorrection";
            this.Text = "Datenbereinigung";
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="parameters">Specific messages as key/value pair for current form</param>
        /// <returns>True, if successfully handles message call, else false</returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (parameters["Action"] as string)
            {
                case "ShowDoublePerson":
                    return this.ShowDoublePerson((int)parameters["BaPersonID_A"], (int)parameters["BaPersonID_B"], (string)parameters["NamespaceExtension"]);

                case "ShowDoubleInstitution":
                case "ShowDoubleOrganisation":
                    return this.ShowDoubleInstitution((int)parameters["BaInstitutionID_A"], (int)parameters["BaInstitutionID_B"]);
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Show CtlDoubleOrganisation with defined values
        /// </summary>
        /// <param name="baInstitutionID_A"></param>
        /// <param name="baInstitutionID_B"></param>
        /// <returns>True if control could be loaded, else false</returns>
        private bool ShowDoubleInstitution(int baInstitutionID_A, int baInstitutionID_B)
        {
            if (itmDoubleInstitution != null &&
                itmDoubleInstitution.Enabled &&
                itmDoubleInstitution.Visible &&
                navBar.Items.IndexOf(itmDoubleInstitution) > -1)
            {
                picTitle.Image = itmDoubleInstitution.SmallImage;
                lblTitle.Text = itmDoubleInstitution.Caption;

                picTitle.Visible = true;
                lblTitle.Visible = true;

                return ActivateUserControl(new CtlDoubleInstitution(baInstitutionID_A, baInstitutionID_B), panDetail, true);
            }

            // item is not active
            return false;
        }

        /// <summary>
        /// Show CtlDoublePerson with defined values
        /// </summary>
        /// <param name="baPersonID_A"></param>
        /// <param name="baPersonID_B"></param>
        /// <param name="nameSpaceExtension">The namespace extension of the control to show (e.g. PI)</param>
        /// <returns>True if control could be loaded, else false</returns>
        private bool ShowDoublePerson(int baPersonID_A, int baPersonID_B, string namespaceExtension)
        {
            if (namespaceExtension == "PI")
            {
                // PI:
                if (itmDoublePersonPI != null &&
                    itmDoublePersonPI.Enabled &&
                    itmDoublePersonPI.Visible &&
                    navBar.Items.IndexOf(itmDoublePersonPI) > -1)
                {
                    picTitle.Image = itmDoublePersonPI.SmallImage;
                    lblTitle.Text = itmDoublePersonPI.Caption;

                    picTitle.Visible = true;
                    lblTitle.Visible = true;

                    return ActivateUserControl(new PI.CtlDoublePerson(baPersonID_A, baPersonID_B), panDetail, true);
                }
            }
            else
            {
                // Standard:
                if (itmDoublePerson != null &&
                    itmDoublePerson.Enabled &&
                    itmDoublePerson.Visible &&
                    navBar.Items.IndexOf(itmDoublePerson) > -1)
                {
                    picTitle.Image = itmDoublePerson.SmallImage;
                    lblTitle.Text = itmDoublePerson.Caption;

                    picTitle.Visible = true;
                    lblTitle.Visible = true;

                    return ActivateUserControl(new CtlDoublePerson(baPersonID_A, baPersonID_B), panDetail, true);
                }
            }

            // item is not active
            return false;
        }

        #endregion

        #endregion
    }
}