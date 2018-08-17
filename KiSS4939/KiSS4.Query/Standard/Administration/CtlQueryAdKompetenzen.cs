using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    partial class CtlQueryAdKompetenzen : KissQueryControl
    {
        #region Constructors

        public CtlQueryAdKompetenzen()
        {
            InitializeComponent();

            edtPermissionGroupID.LoadQuery(DBUtil.OpenSQL(@"
                SELECT
                  Code = PermissionGroupID,
                  Text = PermissionGroupName
                FROM dbo.XPermissionGroup WITH (READUNCOMMITTED)
            "));
        }

        #endregion

        #region EventHandlers

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            grdListe2.DataSource = qryQuery.DataSet.Tables[1];
            grdListe3.DataSource = qryQuery.DataSet.Tables[2];
        }

        #endregion
    }
}