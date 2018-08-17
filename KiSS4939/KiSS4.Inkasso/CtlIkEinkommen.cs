using System;

using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso
{
    public partial class CtlIkEinkommen : KissSearchUserControl
    {
        private const string CLASSNAME = "CtlIkEinkommen";
        private int _faFallID;
        private int? _ikRechtstitelID;

        public CtlIkEinkommen()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
        }

        public void Init(int rechtstitelID, int fallID, bool canEdit)
        {
            _ikRechtstitelID = rechtstitelID;

            if (_ikRechtstitelID < 0)
            {
                _ikRechtstitelID = null;
            }

            _faFallID = fallID;

            qryBetrifftPerson.Fill(_faFallID);

            edtBetrifft.LoadQuery(qryBetrifftPerson, DBO.vwPerson.BaPersonID, DBO.vwPerson.NameVorname);
            colBetrifft.ColumnEdit = grdEinkommen.GetLOVLookUpEdit(qryBetrifftPerson, DBO.vwPerson.BaPersonID, DBO.vwPerson.NameVorname);
            colLeistung.ColumnEdit = grdEinkommen.GetLOVLookUpEdit("IkEinkommenTyp");

            var qryBetrifftPersonSuche = DBUtil.OpenSQL("SELECT BaPersonID = NULL, NameVorname = NULL" + Environment.NewLine +
                                                        "UNION ALL " + Environment.NewLine +
                                                        qryBetrifftPerson.SelectStatement, _faFallID);
            edtSucheBetrifft.LoadQuery(qryBetrifftPersonSuche, DBO.vwPerson.BaPersonID, DBO.vwPerson.NameVorname);

            NewSearchAndRun();
        }

        /// <summary>
        /// Führt eine neue Suche aus.
        /// </summary>
        protected void NewSearchAndRun()
        {
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        /// <summary>
        /// Führt die Suche aus.  Hier werden dem Query die Parameter übergeben
        /// {0}, {1} ...
        /// </summary>
        protected override void RunSearch()
        {
            kissSearch.SelectParameters = new[]
            {
                _ikRechtstitelID,
                edtSucheGueltigAb.EditValue,
                edtSucheGueltigBis.EditValue,
                edtSucheBetrifft.EditValue,
                edtSucheEinkommenTaggelderVersicherungen.EditValue,
                edtSucheBedarfsabhaengigeSozialleistungen.EditValue,
                edtSucheZusatzeinnahmen.EditValue
            };

            base.RunSearch();
        }

        private void CtlIkEinkommen_Load(object sender, EventArgs e)
        {
            grvEinkommen.OptionsView.ColumnAutoWidth = true;
        }

        private void edtIkEinkommenTyp_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            qryIkEinkommen[DBO.IkEinkommen.IkEinkommenTypCode] = ((KissLookUpEdit)sender).EditValue;
        }

        private void qryIkEinkommen_AfterInsert(object sender, EventArgs e)
        {
            qryIkEinkommen[DBO.IkEinkommen.IkRechtstitelID] = _ikRechtstitelID;
        }

        private void qryIkEinkommen_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtGueltigAb, lblGueltigAb.Text);
            DBUtil.CheckNotNullField(edtBetrifft, lblBetrifft.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            if (DBUtil.IsEmpty(qryIkEinkommen[DBO.IkEinkommen.IkEinkommenTypCode]))
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "IkEinkommenTypCodeNichtLeer",
                    "Das Feld '{0}', '{1}' oder '{2}' muss ein Wert haben !",
                    lblEinkommenTaggelderVersicherungen.Text,
                    lblBedarfsabhaengigeSozialleistungen.Text,
                    lblZusatzeinnahmen.Text);
                throw new KissCancelException(edtEinkommenTaggelderVersicherungen);
            }

            var gueltigBis = qryIkEinkommen[DBO.IkEinkommen.GueltigBis] as DateTime?;

            if (gueltigBis != null)
            {
                var gueltigVon = (DateTime)qryIkEinkommen[DBO.IkEinkommen.GueltigVon];

                if (gueltigVon > gueltigBis)
                {
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "GueltigBisVorGueltigVon",
                        "Das Datum '{0}' darf nicht vor dem Datum '{1}' liegen!",
                        lblGueltigBis.Text,
                        lblGueltigAb.Text);
                    throw new KissCancelException(edtGueltigBis);
                }
            }
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtGueltigAb.DataMember = DBO.IkEinkommen.GueltigVon;
            edtGueltigBis.DataMember = DBO.IkEinkommen.GueltigBis;
            edtBetrifft.DataMember = DBO.IkEinkommen.BaPersonID;
            edtEinkommenTaggelderVersicherungen.DataMember = DBO.IkEinkommen.IkEinkommenTypCode;
            edtBedarfsabhaengigeSozialleistungen.DataMember = DBO.IkEinkommen.IkEinkommenTypCode;
            edtZusatzeinnahmen.DataMember = DBO.IkEinkommen.IkEinkommenTypCode;
            edtBetrag.DataMember = DBO.IkEinkommen.Betrag;
            edtBemerkung.DataMember = DBO.IkEinkommen.Bemerkung;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colLeistung.FieldName = DBO.IkEinkommen.IkEinkommenTypCode;
            colGueltigAb.FieldName = DBO.IkEinkommen.GueltigVon;
            colGueltigBis.FieldName = DBO.IkEinkommen.GueltigBis;
            colBetrag.FieldName = DBO.IkEinkommen.Betrag;
            colBetrifft.FieldName = DBO.IkEinkommen.BaPersonID;
        }
    }
}