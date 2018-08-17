using System;
using System.Data;
using System.Linq;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlQueryWhBewilligungAbrechnung : KissQueryControl
    {
        #region Constructors

        public CtlQueryWhBewilligungAbrechnung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnJumpTo_Click(object sender, EventArgs e)
        {
            if (qryQuery.Row == null)
            {
                return;
            }

            var dic = FormController.ConvertToDictionary(GetJumpToPath(qryQuery.Row));
            FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private void edtWhSucheEmpfaengerX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            WhUtil.SearchEmpfaenger(edtWhSucheEmpfaengerX, e);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                foreach (var edt in UtilsGui.AllControls(tpgSuchen).OfType<KissButtonEdit>())
                {
                    edt.CheckPendingSearchValue();
                }

                if (DBUtil.IsEmpty(edtWhSucheEmpfaengerX.EditValue))
                {
                    KissMsg.ShowInfo("Das Feld Empfänger darf nicht leer bleiben");
                    edtWhSucheEmpfaengerX.Focus();
                    return;
                }
            }

            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            WhUtil.SetEmpfaengerDefault(edtWhSucheEmpfaengerX);
        }

        #endregion

        #region Private Static Methods

        private static string GetJumpToPath(DataRow row)
        {
            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=3;" +
                "TreeNodeID=CtlWhKlientenKontoabrechnung;" +
                "ActiveSQLQuery.Find=WhAbrechnungID={1};",
                row["FAL_BaPersonID"],
                row["WhAbrechnungID"]
            );

            return jumpToPath;
        }

        #endregion

        #endregion
    }
}