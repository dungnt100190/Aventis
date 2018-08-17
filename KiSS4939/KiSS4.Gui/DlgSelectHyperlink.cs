using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui.Layout;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for DlgSelectHyperlink.
    /// </summary>
    [ToolboxItem(false)]
    public partial class DlgSelectHyperlink : KissDialog
    {
        #region Fields

        #region Private Fields

        private string _context;
        private DataRow _resultRow;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref= "KiSS4.Gui.DlgSelectHyperlink"/> class
        /// </summary>
        public DlgSelectHyperlink()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            colUserProfileCode.ColumnEdit = treXHyperLink.GetLOVLookUpEdit((SqlQuery)edtUserProfileCode.Properties.DataSource);
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Provides access to the ResultRow which contains the row selected by the user
        /// </summary>
        /// <param name="columnName">Queried column</param>
        /// <returns>Content of the queried column</returns>
        public object this[string columnName]
        {
            get
            {
                if (_resultRow == null)
                {
                    return DBNull.Value;
                }

                try
                {
                    return _resultRow[columnName];
                }
                catch
                {
                    return DBNull.Value;
                }
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the CheckedChanged event of the chkFoldersExpanded control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkFoldersExpanded_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFoldersExpanded.Checked)
            {
                treXHyperLink.ExpandAll();
            }
            else
            {
                treXHyperLink.CollapseAll();
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the edtUserProfileCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void edtUserProfileCode_EditValueChanged(object sender, EventArgs e)
        {
            DisplayTree();
        }

        /// <summary>
        /// Handles the PositionChanged event of the qryXHyperLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryXHyperLink_PositionChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = qryXHyperLink.Count > 0 && DBUtil.IsEmpty(qryXHyperLink["FolderName"]);
        }

        /// <summary>
        /// Handles the DoubleClick event of the treXHyperLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void treXHyperLink_DoubleClick(object sender, EventArgs e)
        {
            if (btnCreate.Enabled)
            {
                btnCreate.PerformClick();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets a link from all links related to a context
        /// If only one link is related, this one is selected
        /// If there are more, the user can selecte one in the dialog
        /// If there is none, a messagebox appears
        /// </summary>
        /// <param name="dialogOwner">Owner window</param>
        /// <param name="context">Link context</param>
        /// <returns>true if a link could be determined</returns>
        public bool SelectHyperlink(IWin32Window dialogOwner, string context)
        {
            if (DBUtil.IsEmpty(context))
            {
                KissMsg.ShowInfo("DlgSelecHyperlink", "KeinKontext", "Kein Link-Kontext definiert!\r\n\r\n(Muss durch KiSS-Administrator eingerichtet werden)");
                return false;
            }

            _context = context;

            //check ob keine oder genau eine Vorlage definiert ist für den aktuellen Kontext
            SqlQuery qry = DBUtil.OpenSQL(qryXHyperLink.SelectStatement, _context, null);

            switch (qry.Count)
            {
                case 0:
                    KissMsg.ShowInfo("DlgSelecHyperlink", "KeineVorlage", "Kein Link für den Kontext '{0}' definiert!\r\n\r\n(Muss durch KiSS-Administrator eingerichtet werden)", 0, 0, context);
                    return false;

                case 1:
                    _resultRow = qry.Row;
                    return true;

                default:
                    // get default modulcode for current user and set modul filter
                    edtUserProfileCode.EditValue = DBUtil.ExecuteScalarSQL(@"
                        SELECT UserProfileCode = IsNull(USR.UserProfileCode, ORG.UserProfileCode)
                        FROM XUser                  USR
                          LEFT  JOIN XOrgUnit_User  OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
                          LEFT  JOIN XOrgUnit       ORG ON ORG.OrgUnitID = OUU.OrgUnitID
                        WHERE USR.UserID = {0}",
                        Session.User.UserID);

                    //display templates
                    DisplayTree();

                    if (ShowDialog(dialogOwner) == DialogResult.OK)
                    {
                        _resultRow = qryXHyperLink.Row;
                        return true;
                    }

                    userCancel = true;
                    return false;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the GettingLayout event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout.SaveSimpleProperty(e, colItemName.Name, colItemName, "Width");
            KissControlLayout.SaveSimpleProperty(e, colUserProfileCode.Name, colUserProfileCode, "Width");

            KissControlLayout.SaveSimpleProperty(e, chkFoldersExpanded, "Checked");
        }

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the SettingLayout event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout.ReadSimpleProperty(e, colItemName.Name, colItemName, "Width");
            KissControlLayout.ReadSimpleProperty(e, colUserProfileCode.Name, colUserProfileCode, "Width");

            KissControlLayout.ReadSimpleProperty(e, chkFoldersExpanded, "Checked");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Displays the tree.
        /// </summary>
        private void DisplayTree()
        {
            qryXHyperLink.Fill(qryXHyperLink.SelectStatement, _context, edtUserProfileCode.EditValue);

            if (chkFoldersExpanded.Checked)
            {
                treXHyperLink.ExpandAll();
            }
            else
            {
                treXHyperLink.CollapseAll();
            }
        }

        #endregion

        #endregion
    }
}