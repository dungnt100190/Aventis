using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmInventar : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "VmBsInventar";
        private const string USER_NAME_VORNAME = "UserNameVorname";

        #endregion

        #endregion

        #region Constructors

        public CtlVmInventar()
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

        private void qryVmInventar_AfterFill(object sender, EventArgs e)
        {
            // raise event to prevent wrong display in some cases (0 rows, etc.)
            EnableDisableDetailPanel();
            HandleDokuSperre();
        }

        private void qryVmInventar_AfterInsert(object sender, EventArgs e)
        {
            qryVmInventar[DBO.VmInventar.FaLeistungID] = _faLeistungId;
            qryVmInventar.SetCreator();

            // set focus
            edtEroeffnung.Focus();
        }

        private void qryVmInventar_BeforePost(object sender, EventArgs e)
        {
            HandleDokuSperre();
            qryVmInventar.SetModifierModified();
        }

        private void qryVmInventar_PositionChanged(object sender, EventArgs e)
        {
            EnableDisableDetailPanel();
            HandleDokuSperre();
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            EnableDisableDetailPanel();

            if (tabControlSearch.IsTabSelected(tpgListe))
            {
                // recall event to have proper display of control (e.g. button enabled state)
                qry_PositionChanged(this, EventArgs.Empty);
                HandleDokuSperre();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get the desired context value for given parameter
        /// </summary>
        /// <param name="fieldName">The fieldname to get context value for</param>
        /// <returns>The value found if any found</returns>
        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "VMINVENTARID":
                    if (qryVmInventar.IsEmpty || DBUtil.IsEmpty(qryVmInventar[DBO.VmInventar.VmInventarID]))
                    {
                        return -1;
                    }

                    return qryVmInventar[DBO.VmInventar.VmInventarID];
            }

            return base.GetContextValue(fieldName);
        }

        public override void Init(string titleName, Image titleImage, int baPersonId, int faLeistungId)
        {
            base.Init(titleName, titleImage, baPersonId, faLeistungId);

            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtSearchEroeffnungVon.Focus();
        }

        /// <summary>
        /// Enabled die Felder, je nachdem ob ein Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtEroeffnung.EditMode = editMode;
            edtErstkontaktMT.EditMode = editMode;
            edtMahnung.EditMode = editMode;
            edtGenehmigung.EditMode = editMode;
            edtVersand.EditMode = editMode;
            edtAutor.EditMode = editMode;
            edtDocument.EditMode = editMode;
            edtInventarAufgenommen.EditMode = editMode;
            edtBemerkung.EditMode = editMode;

            HandleDokuSperre();
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

            // nur aktive Dokumente anzeigen
            if (editVal == 1)
            {
                isDeleted1 = false;
                isDeleted2 = false;
            }

            // alle (gelöschte und aktuelle Dokumente) anzeigen
            else if (editVal == 0)
            {
                isDeleted1 = true;
                isDeleted2 = false;
            }

            // nur gelöschte Dokumente anzeigen
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

        private void EnableDisableDetailPanel()
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmInventar.IsEmpty)
            {
                panDetail.Enabled = true;
            }
            else
            {
                panDetail.Enabled = false;
            }
        }

        private void HandleDokuSperre()
        {
            bool canUpdate = qryVmInventar.CanUpdate &&
                             !qryVmInventar.IsEmpty &&
                             !IsCurrentRowMarkedAsDeleted();

            if (canUpdate)
            {
                qryVmInventar.EndCurrentEdit();
            }

            Dokument.Utilities.GuiUtilities.HandleDokuSperre(canUpdate, panDetail, edtGenehmigung, !IsCurrentRowMarkedAsGenehmigt());
        }

        private bool IsCurrentRowMarkedAsDeleted()
        {
            if (qryVmInventar.IsEmpty || DBUtil.IsEmpty(qryVmInventar[DBO.VmInventar.IsDeleted]))
            {
                return false;
            }

            return Convert.ToBoolean(qryVmInventar[DBO.VmInventar.IsDeleted]);
        }

        private bool IsCurrentRowMarkedAsGenehmigt()
        {
            if (qryVmInventar.IsEmpty)
            {
                return false;
            }

            return !DBUtil.IsEmpty(qryVmInventar[DBO.VmInventar.Genehmigung]);
        }

        /// <summary>
        /// Context von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupContext()
        {
            edtDocument.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtEroeffnung.DataMember = DBO.VmInventar.Eroeffnung;
            edtErstkontaktMT.DataMember = DBO.VmInventar.ErstKontakt;
            edtMahnung.DataMember = DBO.VmInventar.Mahnung;
            edtGenehmigung.DataMember = DBO.VmInventar.Genehmigung;
            edtVersand.DataMember = DBO.VmInventar.Versand;
            edtAutor.DataMember = USER_NAME_VORNAME;
            edtAutor.DataMemberUserId = DBO.VmInventar.UserID;

            edtDocument.DataMember = DBO.VmInventar.DocumentID;
            edtInventarAufgenommen.DataMember = DBO.VmInventar.InventarAufgenommen;
            edtBemerkung.DataMember = DBO.VmInventar.Bemerkung;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colEroeffnung.FieldName = DBO.VmInventar.Eroeffnung;
            colErstkontaktMT.FieldName = DBO.VmInventar.ErstKontakt;
            colMahnung.FieldName = DBO.VmInventar.Mahnung;
            colGenehmigung.FieldName = DBO.VmInventar.Genehmigung;
            colVersand.FieldName = DBO.VmInventar.Versand;
            colInventarAufgenommen.FieldName = DBO.VmInventar.InventarAufgenommen;
            colAuthor.FieldName = USER_NAME_VORNAME;
            colIsDeleted.FieldName = DBO.VmInventar.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            // Positionierung der RadioGrp
            radGrpDeleted.Top = edtSearchMahnungVon.Top;

            // DrawZell
            GridView = grvVmInventar;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtEroeffnung.Tag = lblEroeffnung.Text;
            edtErstkontaktMT.Tag = lblErstkontaktMT.Text;
            edtMahnung.Tag = lblMahnung.Text;
            edtGenehmigung.Tag = lblGenehmigung.Text;
            edtVersand.Tag = lblVersand.Text;
            edtAutor.Tag = lblAuthor.Text;
            edtDocument.Tag = lblDocument.Text;
            edtInventarAufgenommen.Tag = lblInventarAufgenommen.Text;
            edtBemerkung.Tag = lblBemerkung.Text;
        }

        #endregion

        #endregion
    }
}