using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;
using KiSS4.Common;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmBeschwerdeAnfrage : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "VmBsBeschwerdeDok";
        private const string LOVNAME_VMSCHULDTITEL = "VmSchuldtitel";

        #endregion

        #endregion

        #region Constructors

        public CtlVmBeschwerdeAnfrage()
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
            //Dokument wieder herstellen.
            OnRestoreData();
        }

        /// <summary>
        /// Wird vor dem Speichern in die Datenbank ausgeführt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryVmBeschwerdeAnfrage_AfterInsert(object sender, EventArgs e)
        {
            qryVmBeschwerdeAnfrage[DBO.VmBeschwerdeAnfrage.FaLeistungID] = _faLeistungId;
            qryVmBeschwerdeAnfrage.SetCreator();
            qryVmBeschwerdeAnfrage.SetModifierModified();
        }

        /// <summary>
        /// Wird vor dem Posten ausgeführt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryVmBeschwerdeAnfrage_BeforePost(object sender, EventArgs e)
        {
            //Wir setzen den Modifier (wer den Datensatz verändert hat und wann).
            qryVmBeschwerdeAnfrage.SetModifierModified();
        }

        /// <summary>
        /// Falls kein Treffer gefunden ist, dann soll das disabled sein.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryVmBeschwerdeAnfrage_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmBeschwerdeAnfrage.IsEmpty)
            {
                panDetail.Enabled = false;
            }
            else
            {
                panDetail.Enabled = true;
            }
        }

        /// <summary>
        /// Felder nur editierbar, wenn nicht im Suchen-Modus.
        /// </summary>
        /// <param name="page"></param>
        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmBeschwerdeAnfrage.IsEmpty)
            {
                panDetail.Enabled = true;
            }
            else
            {
                panDetail.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initialized the User-Control.
        /// </summary>
        /// <param name="maskName"></param>
        /// <param name="maskImage"></param>
        /// <param name="baPersonID"></param>
        /// <param name="faLeistungId"></param>
        public override void Init(string maskName, Image maskImage, int baPersonID, int faLeistungId)
        {
            base.Init(maskName, maskImage, baPersonID, faLeistungId);

            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Userinterface Elemente aktivieren oder 
        /// deaktivieren, je nachdem, ob ein gelöschter 
        /// Datensatz angewählt ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtAbschluss.EditMode = editMode;
            edtBearbeitung.EditMode = editMode;
            edtDocument.EditMode = editMode;
            edtStichworte.EditMode = editMode;
            edtEingang.EditMode = editMode;
            edtAbsender.EditMode = editMode;
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
            edtDocument.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtEingang.DataMember = DBO.VmBeschwerdeAnfrage.Eingang;
            edtAbsender.DataMember = DBO.VmBeschwerdeAnfrage.Absender;
            edtStichworte.DataMember = DBO.VmBeschwerdeAnfrage.Stichworte;
            edtBearbeitung.DataMember = DBO.VmBeschwerdeAnfrage.VmBsBeschwerdeBehandlungCode;
            edtAbschluss.DataMember = DBO.VmBeschwerdeAnfrage.Abschluss;
            edtDocument.DataMember = DBO.VmBeschwerdeAnfrage.DocumentID;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colEingang.FieldName = DBO.VmBeschwerdeAnfrage.Eingang;
            colStichworte.FieldName = DBO.VmBeschwerdeAnfrage.Stichworte;
            colBehandlung.FieldName = DBO.VmBeschwerdeAnfrage.VmBsBeschwerdeBehandlungCode;
            colBehandlung.ColumnEdit = grdBeschwAnfr.GetLOVLookUpEdit(LOVNAME_VMSCHULDTITEL);
            colAbschluss.FieldName = DBO.VmBeschwerdeAnfrage.Abschluss;
            colIsDeleted.FieldName = DBO.VmBeschwerdeAnfrage.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            GridView = gvwBeschAnfr;
            radGrpDeleted.Top = lblAbsenderSuche.Top;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtEingang.Tag = lblEingang.Text;
            edtAbsender.Tag = lblAbsender.Text;
            edtStichworte.Tag = lblStichworte.Text;
            edtBearbeitung.Tag = lblBearbeitung.Text;
            edtAbschluss.Tag = lblAbschluss.Text;
            edtDocument.Tag = lblDokument.Text;
        }

        #endregion

        #endregion
    }
}