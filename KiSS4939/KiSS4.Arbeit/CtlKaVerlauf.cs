using System;
using System.Collections.Specialized;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class CtlKaVerlauf : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_AUTOR = "Autor";
        private const string COL_KAALLGEMTHEMACODES_TEXT = "KaAllgemThemaCodesText";

        #endregion

        #region Private Fields

        private int _baPersonID;
        private int _faLeistungID;

        #endregion

        #endregion

        #region Constructors

        public CtlKaVerlauf()
        {
            InitializeComponent();
            SetupDataMember();
        }

        #endregion

        #region EventHandlers

        private void chkThemenFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThemenFilter.Checked)
            {
                lookupThemen.EditMode = EditModeType.Normal;
            }
            else
            {
                lookupThemen.EditMode = EditModeType.ReadOnly;
            }
        }

        private void CtlKaVerlauf_Load(object sender, EventArgs e)
        {
            qryKaVerlauf.Last();
        }

        private void qryKaVerlauf_AfterFill(object sender, EventArgs e)
        {
            BestFitColumns();
        }

        private void qryKaVerlauf_AfterInsert(object sender, EventArgs e)
        {
            qryKaVerlauf[DBO.KaVerlauf.FaLeistungID] = _faLeistungID;
            qryKaVerlauf[DBO.KaVerlauf.Datum] = DateTime.Today;
            qryKaVerlauf[DBO.KaVerlauf.Kontaktperson] = DBUtil.ExecuteScalarSQL(@"
                SELECT NameVorname
                FROM dbo.vwPersonSimple
                WHERE BaPersonID = {0};",
                _baPersonID);
            qryKaVerlauf[DBO.KaVerlauf.UserID] = Session.User.UserID;
            qryKaVerlauf[COL_AUTOR] = Session.User.LastFirstName;
            qryKaVerlauf[DBO.KaVerlauf.SichtbarSDFlag] = KaUtil.IsVisibleSD(_baPersonID);
        }

        private void qryKaVerlauf_AfterPost(object sender, EventArgs e)
        {
            BestFitColumns();
        }

        private void qryKaVerlauf_BeforePost(object sender, EventArgs e)
        {
            qryKaVerlauf[COL_KAALLGEMTHEMACODES_TEXT] = UtilsGui.GetKissCheckedLookupEditGridString(edtThema);
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void JumpToPath(int? baPersonId)
        {
            var leistungIdKaAllgemein = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                SELECT FaLeistungID
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = 7
                  AND FaProzessCode = 700;",
                baPersonId));

            var treeNodeID = string.Format("{0}/{1}", leistungIdKaAllgemein, typeof(CtlKaVerlauf).Name);

            FormController.OpenForm(
                FormController.Forms.FALL,
                FormController.Param.ACTION,
                FormController.Action.JUMP_TO_PATH,
                FormController.Param.BA_PERSON_ID,
                baPersonId,
                FormController.Param.MODUL_ID,
                ModulID.K,
                FormController.Param.FA_LEISTUNG_ID,
                leistungIdKaAllgemein,
                FormController.Param.TREE_NODE_ID,
                treeNodeID);
        }

        #endregion

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonID;
                case "FALEISTUNGID":
                    return _faLeistungID;
                default:
                    return base.GetContextValue(fieldName);
            }
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, int baPersonID)
        {
            lblTitle.Text = titleName;
            picTitle.Image = titleImage;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;

            NewSearchAndRun();
        }

        public override bool ReceiveMessage(HybridDictionary parameters)
        {
            if (parameters[DBO.KaVerlauf.Datum] != null)
            {
                var kontaktArt = parameters[DBO.KaVerlauf.KaAllgemKontaktartCode];
                var datum = (DateTime)parameters[DBO.KaVerlauf.Datum];

                qryKaVerlauf.Insert();
                qryKaVerlauf[DBO.KaVerlauf.Datum] = datum;

                if (!DBUtil.IsEmpty(kontaktArt))
                {
                    qryKaVerlauf[DBO.KaVerlauf.KaAllgemKontaktartCode] = kontaktArt;
                }
            }

            return base.ReceiveMessage(parameters);
        }

        /// <summary>
        /// Führt eine neue Suche aus.
        /// </summary>
        private void NewSearchAndRun()
        {
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            //Themen (ist ein String z.B. '2,3,4,10' mit den Codes) der ausgewählten Themen.
            var themen = lookupThemen.EditValue;

            //Alle Themen (Themenfilter ist ausgeschaltet)
            var alleThemen = !(chkThemenFilter.Checked);

            kissSearch.SelectParameters = new object[] { _faLeistungID, Session.User.IsUserKA ? 0 : 1, themen, alleThemen };

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void BestFitColumns()
        {
            grvVerlauf.BestFitColumns();
            colThema.Width = 200;
        }

        private void SetupDataMember()
        {
            colDatum.FieldName = DBO.KaVerlauf.Datum;
            colKontaktperson.FieldName = DBO.KaVerlauf.Kontaktperson;
            colStichwort.FieldName = DBO.KaVerlauf.Stichwort;
            colThema.FieldName = COL_KAALLGEMTHEMACODES_TEXT;
            colAutor.FieldName = COL_AUTOR;

            edtSichtbarSD.DataMember = DBO.KaVerlauf.SichtbarSDFlag;
            edtDatum.DataMember = DBO.KaVerlauf.Datum;
            edtAutor.DataMember = COL_AUTOR;
            edtAutor.DataMemberUserId = DBO.KaVerlauf.UserID;
            edtKontaktart.DataMember = DBO.KaVerlauf.KaAllgemKontaktartCode;
            edtKontaktperson.DataMember = DBO.KaVerlauf.Kontaktperson;
            edtStichwort.DataMember = DBO.KaVerlauf.Stichwort;
            edtThema.DataMember = DBO.KaVerlauf.KaAllgemThemaCodes;
            edtInhalt.DataMember = DBO.KaVerlauf.InhaltRTF;
        }

        #endregion

        #endregion
    }
}