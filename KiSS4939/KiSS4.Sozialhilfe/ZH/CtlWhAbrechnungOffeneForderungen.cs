using System;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhAbrechnungOffeneForderungen : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _whAbrechnungID;

        #endregion

        #endregion

        #region Constructors

        public CtlWhAbrechnungOffeneForderungen()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public bool HasOffeneForderungen
        {
            get { return qryWhAbrechnungOffeneForderung.Count > 0; }
        }

        #endregion

        #region EventHandlers

        private void qryWhDetailblattKorrekturPosition_AfterInsert(object sender, EventArgs e)
        {

            //cgl: Hack, siehe SetEditMode
            edtBetragBudget.EditMode = EditModeType.Normal;
            edtGrund.EditMode = EditModeType.Normal;
            

            //default-werte setzen
            qryWhAbrechnungOffeneForderung["WhAbrechnungID"] = _whAbrechnungID;
            edtBetragBudget.Focus();
        }

        private void qryWhDetailblattKorrekturPosition_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBetragBudget, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtGrund, lblGrund.Text);

            //validate Betrag
            var betrag = Utils.ConvertToDecimal(qryWhAbrechnungOffeneForderung["Betrag"]);
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

        public void Init(int whAbrechnungID)
        {
            _whAbrechnungID = whAbrechnungID;
            qryWhAbrechnungOffeneForderung.Fill(whAbrechnungID);
        }

        public override bool OnAddData()
        {
            //check if we can add data
            if (_whAbrechnungID == -1)
            {
                KissMsg.ShowInfo("Es ist keine Abrechnung ausgewählt.");
                return false;
            }

            return base.OnAddData();
        }

        public void SetEditMode(EditModeType editMode)
        {
            bool enabled = editMode == EditModeType.Normal;

            //cgl: Ich bin verwirrt, welche Datenquelle nun für EditMode gilt.
            //Manchmal gehts übers Query, manchmal funktionierts nicht, es ist zum verzweifeln.

            if (!qryWhAbrechnungOffeneForderung.IsEmpty)
            {
                edtBetragBudget.EditMode = editMode;
                edtGrund.EditMode = editMode;
            }
            else
            {
                edtBetragBudget.EditMode = EditModeType.ReadOnly;
                edtGrund.EditMode = EditModeType.ReadOnly;
            }

            qryWhAbrechnungOffeneForderung.CanUpdate = enabled;
            qryWhAbrechnungOffeneForderung.CanInsert = enabled;
            qryWhAbrechnungOffeneForderung.CanDelete = enabled;

        }

        #endregion

        #endregion
    }
}