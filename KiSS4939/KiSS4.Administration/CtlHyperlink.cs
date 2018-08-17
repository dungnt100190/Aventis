using System;
using System.ComponentModel;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Administration
{
    /// <summary>
    /// Mask to define Hyperlinks
    /// </summary>
    [ToolboxItem(false)]
    public partial class CtlHyperlink : KissUserControl
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref= "KiSS4.Administration.CtlHyperlink"/> class
        /// </summary>
        public CtlHyperlink()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlHyperlink_Load(object sender, EventArgs e)
        {
            qryHyperlink.Fill();
        }

        private void qryTemplate_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.ExecSQL(@"
                DELETE FROM dbo.XHyperlinkContext_Hyperlink
                WHERE XHyperlinkID = {0};",
                qryHyperlink[DBO.XHyperlink.XHyperlinkID]);
        }

        private void qryTemplate_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(editHyperlinkName, lblLinkName.Text);
            DBUtil.CheckNotNullField(editHyperlink, lblLink.Text);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Occurs when the user wants to insert a new record
        /// fills the record with default data
        /// </summary>
        /// <returns></returns>
        public override bool OnAddData()
        {
            if (!qryHyperlink.Post())
            {
                return false;
            }

            qryHyperlink.Insert();
            qryHyperlink["Name"] = "Neuer Link";
            qryHyperlink["Hyperlink"] = string.Empty;

            editHyperlinkName.Focus();

            return true;
        }

        #endregion

        #endregion
    }
}