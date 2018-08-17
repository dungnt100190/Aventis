using System;
using System.ComponentModel;

using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

using KiSS.DBScheme;

namespace KiSS4.Query
{
    /// <summary>
    /// Summary description for DlgReportMenu.
    /// </summary>
    public partial class DlgReportMenu : KissDialog
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly IKissContext _cp;

        #endregion

        #endregion

        #region Constructors

        public DlgReportMenu(IKissContext cp)
        {
            InitializeComponent();

            _cp = cp;
        }

        #endregion

        #region EventHandlers

        private void DlgReportMenu_Closing(object sender, CancelEventArgs e)
        {
            SaveLayout();
        }

        private void DlgReportMenu_Print(object sender, EventArgs e)
        {
            btnPrint.PerformClick();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DlgReportParameter dlg = new DlgReportParameter(_cp, qryMenu[DBO.XQuery.QueryName].ToString());
            dlg.ShowParameter();

            if (!chkOffenhalten.Checked)
            {
                Close();
            }
        }

        private void grdReportKontext_DoubleClick(object sender, EventArgs e)
        {
            btnPrint.PerformClick();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout.SaveSimpleProperty(e, chkOffenhalten, "Checked");
        }

        protected override void OnLoad(EventArgs e)
        {
            qryMenu.Fill(@"
                SELECT QRY.QueryName, QRY.UserText
                FROM dbo.XQuery QRY WITH(READUNCOMMITTED)
                WHERE QRY.QueryCode = 1
                  AND QRY.ParentReportName IS NULL
                  AND ({0} = 1 OR
                       EXISTS (SELECT 1
                               FROM XUser_UserGroup          UUG WITH(READUNCOMMITTED)
                                 INNER JOIN XUserGroup       UGR WITH(READUNCOMMITTED) ON UGR.UserGroupID = UUG.UserGroupID
                                 INNER JOIN XUserGroup_Right URI WITH(READUNCOMMITTED) ON URI.UserGroupID = UGR.UserGroupID
                                                                                      AND URI.QueryName = QRY.QueryName
                               WHERE  UUG.UserID = {1}))
                  AND (',' + ISNULL(QRY.ContextForms, '') + ',' LIKE '%,,%' OR ',' + QRY.ContextForms + ',' LIKE {2})
                  ORDER BY QRY.ReportSortKey, QRY.UserText;",
                Session.User.IsUserAdmin ? 1 : 0,
                Session.User.UserID,
                "%," + _cp.GetContextName() + ",%");

            if (qryMenu.Count == 0)
            {
                KissMsg.ShowInfo(typeof(DlgReportMenu).Name, "ReportsNichtVerfuegbar", "Keine Reports verfügbar in diesem Kontext oder fehlende Berechtigung");
                Close();
            }

            if (qryMenu.Count == 1)
            {
                DlgReportParameter dlg = new DlgReportParameter(_cp, qryMenu[DBO.XQuery.QueryName].ToString());
                dlg.ShowParameter();
                Close();
            }

            base.OnLoad(e);
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout.ReadSimpleProperty(e, chkOffenhalten, "Checked");
        }

        #endregion

        #endregion
    }
}