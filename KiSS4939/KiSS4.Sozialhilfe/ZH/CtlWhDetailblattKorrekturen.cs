using System;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhDetailblattKorrekturen : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _whDetailblattID;

        #endregion

        #endregion

        #region Constructors

        public CtlWhDetailblattKorrekturen()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public bool HasErgaenzungen
        {
            get { return qryWhDetailblattKorrekturPosition.Count > 0; }
        }

        #endregion

        #region EventHandlers

        private void edtLeistungsart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtLeistungsart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryWhDetailblattKorrekturPosition["BgKostenartID"] = DBNull.Value;
                    return;
                }
            }

            using (var dlg = new KissLookupDialog())
            {
                string sql = @"
                    SELECT  KontoNr             = KontoNr,
                            Name                = Name,
                            KontoNrName$        = KontoNr + ' ' + Name,
                            BgKostenartID$      = BgKostenartID
                    FROM dbo.BgKostenart BKA WITH(READUNCOMMITTED)
                    WHERE KontoNr + ' ' + Name LIKE {0} + '%'
                      OR NAME LIKE {0} + '%'
                    ORDER BY KontoNrName$";

                e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked);

                if (!e.Cancel)
                {
                    qryWhDetailblattKorrekturPosition["BgKostenartID"] = dlg["BgKostenartID$"];
                    qryWhDetailblattKorrekturPosition["Leistungsart"] = dlg["KontoNrName$"];
                }
            }
        }

        private void qryWhDetailblattKorrekturPosition_AfterFill(object sender, EventArgs e)
        {
            colVorzeichen.ColumnEdit = grdWhDetailblattKorrekturen.GetLOVLookUpEdit("WhDetailblattKorrekturVorzeichen");
            colBgKategorie.ColumnEdit = grdWhDetailblattKorrekturen.GetLOVLookUpEdit("BgKategorie");
        }

        private void qryWhDetailblattKorrekturPosition_AfterInsert(object sender, EventArgs e)
        {
            //default-werte setzen
            qryWhDetailblattKorrekturPosition["WhDetailblattID"] = _whDetailblattID;
            qryWhDetailblattKorrekturPosition["WhDetailblattKorrekturVorzeichenCode"] = 1; //1: Reduktion;
            qryWhDetailblattKorrekturPosition["BgKategorieCode"] = 2; //2: Ausgabe;
        }

        private void qryWhDetailblattKorrekturPosition_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtLeistungsart, lblLeistungsart.Text);
            DBUtil.CheckNotNullField(edtBetragBudget, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtKorrekturtext, lblKorrekturtext.Text);

            //validate Betrag
            var betrag = Utils.ConvertToDecimal(qryWhDetailblattKorrekturPosition["Betrag"]);
            if (betrag <= 0)
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        Name,
                        "BetragMussPositivSein",
                        "Bitte geben Sie einen positiven Betrag ein.",
                        KissMsgCode.MsgInfo),
                    edtBetragBudget);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(int whDetailblattID)
        {
            _whDetailblattID = whDetailblattID;
            qryWhDetailblattKorrekturPosition.Fill(whDetailblattID);
        }

        public override bool OnAddData()
        {
            //check if we can add data
            if (_whDetailblattID == -1)
            {
                KissMsg.ShowInfo("Es ist kein Detailblatt ausgewählt.");
                return false;
            }

            return base.OnAddData();
        }

        public void SetEditMode(EditModeType editMode)
        {
            bool enabled = editMode == EditModeType.Normal;

            qryWhDetailblattKorrekturPosition.CanUpdate = enabled;
            qryWhDetailblattKorrekturPosition.CanInsert = enabled;
            qryWhDetailblattKorrekturPosition.CanDelete = enabled;
            

        }

        #endregion

        #endregion
    }
}