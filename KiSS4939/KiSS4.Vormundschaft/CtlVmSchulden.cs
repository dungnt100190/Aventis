using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmSchulden : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "VmMfSchuldenDokumente";

        #endregion

        #endregion

        #region Constructors

        public CtlVmSchulden()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();
            SetupContext();
            SetupLogischesLoeschen();
        }

        #endregion

        #region EventHandlers

        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            OnRestoreData();
        }

        private void qryVmSchulden_BeforePost(object sender, EventArgs e)
        {
            string creatorModifier = DBUtil.GetDBRowCreatorModifier();

            qryVmSchulden[DBO.VmSchulden.FaLeistungID] = _faLeistungId;
            qryVmSchulden[DBO.VmSchulden.Creator] = creatorModifier;
            qryVmSchulden[DBO.VmSchulden.Modifier] = creatorModifier;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Init(string title, Image icon, int baPersonId, int faLeistungId)
        {
            base.Init(title, icon, baPersonId, faLeistungId);

            colSchuldtitel.ColumnEdit = grdSchulden.GetLOVLookUpEdit("VmSchuldtitel");

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Je nach dem, ob ein Datensatz logisch gelöscht ist,
        /// sind die Felder auf der Maske disabled oder enabled.
        /// </summary>
        /// <param name="isActive">Ob der Datensatz aktiv ist oder nicht</param>
        /// <param name="editMode">Gäbiges hilfsfeld. bei isActive=true hat es den Wert Normal</param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtSchuldtitel.EditMode = editMode;
            edtSchuldtilgung.EditMode = editMode;
            dokSchulden.EditMode = editMode;
            edtBemerkungen.EditMode = editMode;
            edtDatum.EditMode = editMode;
            edtBetrag.EditMode = editMode;
        }

        /// <summary>
        /// Führt die Suche aus.  Hier werden dem Query die Parameter übergeben
        /// {0}, {1} ...
        /// </summary>
        protected override void RunSearch()
        {
            bool isDeleted1;
            bool isDeleted2;

            int editVal = Convert.ToInt32(radGrpDeleted.EditValue);

            //Nur aktive Dokumente anzeigen
            if (editVal == 1)
            {
                isDeleted1 = false;
                isDeleted2 = false;
            }

                //Alle (gelöschte und aktuelle Dokumente) anzeigen
            else if (editVal == 0)
            {
                isDeleted1 = true;
                isDeleted2 = false;
            }

                //Nur gelöschte Dokumente anzeigen
            else
            {
                isDeleted1 = true;
                isDeleted2 = true;
            }

            kissSearch.SelectParameters = new object[] { _faLeistungId, isDeleted1, isDeleted2 };

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Context von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupContext()
        {
            dokSchulden.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtSchuldtitel.DataMember = DBO.VmSchulden.VmSchuldtitelCode;
            edtSchuldtilgung.DataMember = DBO.VmSchulden.TilgungDatum;
            dokSchulden.DataMember = DBO.VmSchulden.DocumentID;
            edtBemerkungen.DataMember = DBO.VmSchulden.Bemerkungen;
            edtDatum.DataMember = DBO.VmSchulden.Datum;
            edtBetrag.DataMember = DBO.VmSchulden.Betrag;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colSchuldtitel.FieldName = DBO.VmSchulden.VmSchuldtitelCode;
            colDatum.FieldName = DBO.VmSchulden.Datum;
            colSchuldtilgung.FieldName = DBO.VmSchulden.TilgungDatum;
            colBetrag.FieldName = DBO.VmSchulden.Betrag;
            colBemerkungen.FieldName = DBO.VmSchulden.Bemerkungen;
            colIsDeleted.FieldName = DBO.VmSchulden.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtSchuldtitelSuchen.Top;
            SetupRadioGroup();

            //DrawZell render Methode hinzufügen.
            GridView = gvwSchulden;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtSchuldtitel.Tag = lblSchuldtitel.Text;
            edtSchuldtilgung.Tag = lblSchuldtilgung.Text;
            dokSchulden.Tag = lblDokument.Text;
            edtBemerkungen.Tag = lblBemerkungen.Text;
            edtDatum.Tag = lblDatum.Text;
            edtBetrag.Tag = lblBetrag.Text;
        }

        #endregion

        #endregion
    }
}