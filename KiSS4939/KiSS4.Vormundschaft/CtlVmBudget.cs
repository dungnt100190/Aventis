using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.BL;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmBudget : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "VmMfBudget";
        private const string USER_NAME_VORNAME = "UserNameVorname";

        #endregion

        #endregion

        #region Constructors

        public CtlVmBudget()
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

        private void edtAuthor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtAuthor.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryVmBudget[USER_NAME_VORNAME] = dlg["Name"];
                qryVmBudget[DBO.VmBudget.UserID] = dlg["UserID"];
            }
        }

        private void qryVmBudget_AfterFill(object sender, EventArgs e)
        {
            // raise event to prevent wrong display in some cases (0 rows, etc.)
            EnableDisableDetailPanel();
        }

        private void qryVmBudget_AfterInsert(object sender, EventArgs e)
        {
            qryVmBudget[DBO.VmBudget.FaLeistungID] = _faLeistungId;
            qryVmBudget[DBO.VmBudget.Stichworte] = BaPersonService.GetKlientNameVorname(_faLeistungId);

            qryVmBudget.SetCreator();

            // set focus
            edtErsterstellung.Focus();
        }

        private void qryVmBudget_BeforePost(object sender, EventArgs e)
        {
            qryVmBudget.SetModifierModified();
        }

        private void qryVmBudget_PositionChanged(object sender, EventArgs e)
        {
            EnableDisableDetailPanel();
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            EnableDisableDetailPanel();

            if (tabControlSearch.IsTabSelected(tpgListe))
            {
                // recall event to have proper display of control (e.g. button enabled state)
                qry_PositionChanged(this, EventArgs.Empty);
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
                case "VMBUDGETID":
                    if (qryVmBudget.IsEmpty || DBUtil.IsEmpty(qryVmBudget[DBO.VmBudget.VmBudgetID]))
                    {
                        return -1;
                    }

                    return qryVmBudget[DBO.VmBudget.VmBudgetID];

                case "FALEISTUNGID":
                    return _faLeistungId;
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
            edtSearchErsterstellungVon.Focus();
        }

        /// <summary>
        /// Enabled die Felder, je nachdem ob ein Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtErsterstellung.EditMode = editMode;
            edtBudgetTitel.EditMode = editMode;
            edtMutation.EditMode = editMode;
            edtMutationsGrund.EditMode = editMode;
            edtAuthor.EditMode = editMode;
            edtDocument.EditMode = editMode;
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
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmBudget.IsEmpty)
            {
                panDetail.Enabled = true;
            }
            else
            {
                panDetail.Enabled = false;
            }
            ctlCreatorModifier.RefreshState();
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
            edtErsterstellung.DataMember = DBO.VmBudget.DatumErstellung;
            edtBudgetTitel.DataMember = DBO.VmBudget.Stichworte;
            edtMutation.DataMember = DBO.VmBudget.DatumMutation;
            edtMutationsGrund.DataMember = DBO.VmBudget.Grund;
            edtAuthor.DataMember = USER_NAME_VORNAME;
            edtAuthor.DataMemberUserId = DBO.VmBudget.UserID;
            edtDocument.DataMember = DBO.VmBudget.DocumentID;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colErsterstellung.FieldName = DBO.VmBudget.DatumErstellung;
            colAuthor.FieldName = USER_NAME_VORNAME;
            colBudgetTitel.FieldName = DBO.VmBudget.Stichworte;
            colMutation.FieldName = DBO.VmBudget.DatumMutation;
            colMutationsGrund.FieldName = DBO.VmBudget.Grund;
            colIsDeleted.FieldName = DBO.VmBudget.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            // Positionierung der RadioGrp
            radGrpDeleted.Top = edtSearchErsterstellungVon.Top;
            SetupRadioGroup();

            // DrawZell render Methode hinzufügen.
            GridView = grvVmBudget;
            grvVmBudget.CustomDrawCell += gridView_CustomDrawCell;

            // query
            qryVmBudget.PositionChanged += qry_PositionChanged;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtErsterstellung.Tag = lblErsterstellung.Text;
            edtBudgetTitel.Tag = lblBudgetTitel.Text;
            edtMutation.Tag = lblMutation.Text;
            edtMutationsGrund.Tag = lblMutationsGrund.Text;
            edtAuthor.Tag = lblAuthor.Text;
            edtDocument.Tag = lblDocument.Text;
        }

        #endregion

        #endregion
    }
}