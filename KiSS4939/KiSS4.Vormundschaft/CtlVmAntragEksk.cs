using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;
using KiSS4.Common;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmAntragEksk : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "VmMfAntragEKSK";
        private const string USER_NAME_VORNAME = "UserNameVorname";

        #endregion

        #endregion

        #region Constructors

        public CtlVmAntragEksk()
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

        private void qryVmAntragEksk_AfterInsert(object sender, EventArgs e)
        {
            qryVmAntragEksk[DBO.VmAntragEKSK.FaLeistungID] = _faLeistungId;
            qryVmAntragEksk.SetCreator();
        }

        private void qryVmAntragEksk_BeforePost(object sender, EventArgs e)
        {
            qryVmAntragEksk.SetModifierModified();
        }

        private void qryVmAntragEksk_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmAntragEksk.IsEmpty)
            {
                panDetail.Enabled = false;
            }
            else
            {
                panDetail.Enabled = true;
            }
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmAntragEksk.IsEmpty)
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

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "VMANTRAGEKSKID": return qryVmAntragEksk["VmAntragEKSKID"];
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
            edtSearchTitel.Focus();
        }

        /// <summary>
        /// Enabled die Felder, je nachdem ob ein Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtTitelAntrag.EditMode = editMode;
            edtBegruendung.EditMode = editMode;
            edtDatumAntrag.EditMode = editMode;
            edtAntrag.EditMode = editMode;
            edtDocument.EditMode = editMode;
            edtDatumGenehmigtEksk.EditMode = editMode;
            edtAuthor.EditMode = editMode;
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
            edtTitelAntrag.DataMember = DBO.VmAntragEKSK.Titel;
            edtBegruendung.DataMember = DBO.VmAntragEKSK.Begruendung;
            edtDatumAntrag.DataMember = DBO.VmAntragEKSK.DatumAntrag;
            edtAntrag.DataMember = DBO.VmAntragEKSK.Antrag;
            edtDocument.DataMember = DBO.VmAntragEKSK.DocumentID;
            edtAuthor.DataMember = USER_NAME_VORNAME;
            edtAuthor.DataMemberUserId = DBO.VmAntragEKSK.UserID;
            edtDatumGenehmigtEksk.DataMember = DBO.VmAntragEKSK.DatumGenehmigtEKSK;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstante nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colAntragVom.FieldName = DBO.VmAntragEKSK.DatumAntrag;
            colTitel.FieldName = DBO.VmAntragEKSK.Titel;
            colAuthor.FieldName = USER_NAME_VORNAME;
            colGenehmigtEksk.FieldName = DBO.VmAntragEKSK.DatumGenehmigtEKSK;
            colIsDeleted.FieldName = DBO.VmAntragEKSK.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtSearchDatumAntragVon.Top;

            //DrawZell render Methode hinzufügen.
            GridView = grvVmAntragEKSK;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtTitelAntrag.Tag = lblTitelAntrag.Text;
            edtBegruendung.Tag = lblBegruendung.Text;
            edtDatumAntrag.Tag = lblAntrag.Text;
            edtAntrag.Tag = lblAntrag.Text;
            edtDocument.Tag = lblDocument.Text;
            edtAuthor.Tag = lblAuthor.Text;
            edtDatumGenehmigtEksk.Tag = lblDatumGenehmigtEksk.Text;
        }

        #endregion

        #endregion
    }
}