using System;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public partial class CtlAyPerioden : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlAyPerioden()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public CtlAyPerioden(Image titelImage, int faLeistungID)
            : this(titelImage, "Übersicht über die Masterbudgets", faLeistungID)
        {
        }

        public CtlAyPerioden(Image titelImage, string titelText, int faLeistungID)
            : this()
        {
            picTitel.Image = titelImage;
            _faLeistungID = faLeistungID;
            lblTitel.Text = titelText;

            qryBgFinanzplan.Fill(_faLeistungID);
        }

        #endregion

        #region EventHandlers

        private void qryBgFinanzplan_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();

            qryBgFinanzplan.Refresh();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryBgFinanzplan_BeforeDelete(object sender, EventArgs e)
        {
            // HACK: Delete related Records
            Session.BeginTransaction();

            try
            {
                DBUtil.ExecSQLThrowingException(
                    "EXECUTE dbo.spAyFinanzplan_Delete {0}",
                    qryBgFinanzplan["BgFinanzplanID"]);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);

                throw new KissCancelException();
            }
        }

        private void qryBgFinanzplan_BeforeInsert(object sender, EventArgs e)
        {
            var qryCount = DBUtil.OpenSQL(@"
                SELECT TOP 1 1
                FROM dbo.BgFinanzplan WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0}
                  AND ISNULL(DatumBis, GeplantBis) IS NULL;", _faLeistungID);

            if (qryCount.Count > 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlAyPerioden",
                        "BudgetNeuNichtMoeglich",
                        "Es kann kein neues Masterbudget erstellt werden. Das letzte Masterbudget ist noch nicht abgeschlossen.",
                        KissMsgCode.MsgInfo));
            }

            SqlQuery qryBgFinanplan = DBUtil.OpenSQL(@"
                SELECT GeplantVon = DATEADD(D, 1, ISNULL(BFP.DatumBis, BFP.GeplantBis)),
                       GeplantBis = DATEADD(M, CONVERT(INT, dbo.fnXConfig('System\Asyl\MasterbudgetPeriodendauer', GETDATE())), dbo.fnDateOf(ISNULL(BFP.DatumBis, BFP.GeplantBis))),
                       CopyOfLast = CONVERT(BIT, 1)
                FROM dbo.BgFinanzplan    BFP WITH(READUNCOMMITTED)
                WHERE BFP.FaLeistungID = {0}
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM dbo.BgFinanzplan WITH(READUNCOMMITTED)
                                  WHERE FaLeistungID = {0}
                                    AND ISNULL(DatumBis, GeplantBis) > ISNULL(BFP.DatumBis, BFP.GeplantBis))
                UNION ALL
                SELECT GeplantVon = dbo.fnDateOf(GETDATE()),
                       GeplantBis = DATEADD(M, CONVERT(INT, dbo.fnXConfig('System\Asyl\MasterbudgetPeriodendauer', GETDATE())), DATEADD(D, -1, dbo.fnDateOf(GETDATE()))),
                       CopyOfLast = CONVERT(BIT, 0);",
                _faLeistungID);

            DBUtil.ExecSQLThrowingException(
                "EXECUTE dbo.spAyFinanzplan_Create {0}, {1}, {2}, {3}, {4};",
                _faLeistungID,
                qryBgFinanplan["GeplantVon"],
                qryBgFinanplan["GeplantBis"],
                DBNull.Value,
                qryBgFinanplan["CopyOfLast"]);

            qryBgFinanzplan.Refresh();
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            // jüngste Unterstützungsperiode expandieren
            KissModulTree modulTree = (KissModulTree)GetKissMainForm().GetTreeFall();

            if (modulTree.KissTree != null &&
                modulTree.KissTree.Nodes.Count > 0 &&
                modulTree.KissTree.Nodes[0].Nodes.Count > 0 &&
                modulTree.KissTree.Nodes[0].Nodes[0].Nodes.Count > 0 &&
                modulTree.KissTree.Nodes[0].Nodes[0].Nodes[0].Nodes.Count > 0)
            {
                modulTree.KissTree.Nodes[0].Nodes[0].Nodes[0].Expanded = true; // Unterst. Periode
            }

            throw new KissCancelException();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            return "AyFinanzplan";
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BGFINANZPLANID":
                    return qryBgFinanzplan["BgFinanzplanID"];
            }

            return base.GetContextValue(fieldName);
        }

        #endregion

        #endregion
    }
}