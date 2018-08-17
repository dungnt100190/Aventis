using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmSituationsbericht : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_FATHEMACODESTEXT = "FaThemaCodesText";
        private const string COL_USER_NAME_VORNAME = "UserNameVorname";

        /// <summary>
        /// Kontext vom Dokument.
        /// </summary>
        private const string CONTEXT_DOC = "VmMfSituationsberichtSH";
        private const string LOV_VMTYPSHANTRAG = "VMTypSHAntrag";

        #endregion

        #endregion

        #region Constructors

        public CtlVmSituationsbericht()
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
       

        private void qryVmSituationsbericht_AfterInsert(object sender, EventArgs e)
        {
            qryVmSituationsbericht[DBO.VmSituationsBericht.FaLeistungID] = _faLeistungId;
            qryVmSituationsbericht.SetCreator();
        }

        private void qryVmSituationsbericht_BeforePost(object sender, EventArgs e)
        {
            qryVmSituationsbericht[COL_FATHEMACODESTEXT] = UtilsGui.GetKissCheckedLookupEditGridString(edtThemen);
            qryVmSituationsbericht.SetModifierModified();
        }

        private void qryVmSituationsbericht_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmSituationsbericht.IsEmpty)
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
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmSituationsbericht.IsEmpty)
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

        public new void Init(string titleName, Image titleImage, int baPersonId, int faLeistungId)
        {
            base.Init(titleName, titleImage, baPersonId, faLeistungId);
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Bei einem logisch gelöschten Dokument gewisse Felder
        /// enablen / disablen.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtDate.EditMode = editMode;
            edtMfSituationsSHTyp.EditMode = editMode;
            edtThemen.EditMode = editMode;
            edtAktuelleSituation.EditMode = editMode;
            edtZielsetzung.EditMode = editMode;
            edtAntrag.EditMode = editMode;
            edtAutor.EditMode = editMode;
            edtDokument.EditMode = editMode;
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

            //Themen (ist ein String z.B. '2,3,4,10' mit den Codes) der ausgewählten Themen.
            string themen = lookupThemen.EditValue;

            //Alle Themen (Themenfilter ist ausgeschaltet)
            bool alleThemen = !(chkThemenFilter.Checked);

            kissSearch.SelectParameters = new object[] {_faLeistungId, isDeleted1, isDeleted2, themen, alleThemen};

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
            edtDokument.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtDate.DataMember = DBO.VmSituationsBericht.AntragDatum;
            edtMfSituationsSHTyp.DataMember = DBO.VmSituationsBericht.VMTypSHAntragCode;
            edtThemen.DataMember = DBO.VmSituationsBericht.FaThemaCodes;
            edtAktuelleSituation.DataMember = DBO.VmSituationsBericht.BerichtFinanzen;
            edtZielsetzung.DataMember = DBO.VmSituationsBericht.ZielPrognose;
            edtAntrag.DataMember = DBO.VmSituationsBericht.AntragText;
            edtAutor.DataMember = COL_USER_NAME_VORNAME;
            edtAutor.DataMemberUserId = DBO.VmSituationsBericht.UserID;
            edtDokument.DataMember = DBO.VmSituationsBericht.DocumentID;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colBerichtVom.FieldName = DBO.VmSituationsBericht.AntragDatum;
            colTyp.FieldName = DBO.VmSituationsBericht.VMTypSHAntragCode;
            colTyp.ColumnEdit = grdVmSituationsbericht.GetLOVLookUpEdit(LOV_VMTYPSHANTRAG);
            colThema.FieldName = COL_FATHEMACODESTEXT;
            colAuthor.FieldName = COL_USER_NAME_VORNAME;
            colIsDeleted.FieldName = DBO.VmSituationsBericht.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtVonSuche.Top;
            radGrpDeleted.Left = 650;

            //DrawZell render Methode hinzufügen.
            GridView = grvSituationsbericht;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtDate.Tag = lblBern.Text;
            edtAktuelleSituation.Tag = lblAktuelleSituation.Text;
            edtZielsetzung.Tag = lblZielsetzung.Text;
            edtAntrag.Tag = lblAntrag.Text;
            edtAutor.Tag = lblAutor.Text;
            edtDokument.Tag = lblDokument.Text;
        }

        #endregion

        #endregion
    }
}