using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;
using KiSS4.Basis;
using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmSteuern : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "VmMfSteuernSteuererlass";

        #endregion

        #region Private Fields

        #endregion

        #endregion

        #region Constructors

        public CtlVmSteuern()
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

        private void qryVmSteuern_AfterFill(object sender, EventArgs e)
        {
            // raise event to prevent wrong display in some cases (0 rows, etc.)
            EnableDisableDetailPanel();
        }

        private void qryVmSteuern_AfterInsert(object sender, EventArgs e)
        {
            qryVmSteuern[DBO.VmSteuern.FaLeistungID] = _faLeistungId;
            qryVmSteuern.SetCreator();

            // set focus
            edtSteuerjahr.Focus();
        }

        private void qryVmSteuern_BeforePost(object sender, EventArgs e)
        {
            qryVmSteuern.SetModifierModified();
        }

        private void qryVmSteuern_PositionChanged(object sender, EventArgs e)
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
                case "VMSTEUERNID":
                    if (qryVmSteuern.IsEmpty || DBUtil.IsEmpty(qryVmSteuern[DBO.VmSteuern.VmSteuernID]))
                    {
                        return -1;
                    }

                    return qryVmSteuern[DBO.VmSteuern.VmSteuernID];

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
            edtSearchSteuerJahrVon.Focus();
        }

        /// <summary>
        /// Enabled die Felder, je nachdem ob ein Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtSteuerjahr.EditMode = editMode;
            chkSteuererklaerungExternErledigt.EditMode = editMode;
            chkSteuererklaerungInternErledigt.EditMode = editMode;
            edtErledigungDurch.EditMode = editMode;
            edtSteuererklaerungEingereicht.EditMode = editMode;
            chkArtikel41.EditMode = editMode;
            edtFristverlaengerungBeantragt.EditMode = editMode;
            edtEingangDefinitiveVeranlagung.EditMode = editMode;
            edtDatumEntscheidErlass.EditMode = editMode;
            chkErlass.EditMode = editMode;
            chkTeilerlass.EditMode = editMode;
            chkAbgelehnt.EditMode = editMode;
            edtDocument.EditMode = editMode;
            edtBemerkungen.EditMode = editMode;
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
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmSteuern.IsEmpty)
            {
                panDetail.Enabled = true;
            }
            else
            {
                panDetail.Enabled = false;
            }
            ctlLogischLoeschen.RefreshState();
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
            edtSteuerjahr.DataMember = DBO.VmSteuern.SteuerJahr;
            chkSteuererklaerungExternErledigt.DataMember = DBO.VmSteuern.SteuererklaerungExternErledigt;
            chkSteuererklaerungInternErledigt.DataMember = DBO.VmSteuern.SteuererklaerungInternErledigt;
            edtErledigungDurch.DataMember = DBO.VmSteuern.ErledigungDurch;
            edtSteuererklaerungEingereicht.DataMember = DBO.VmSteuern.SteuererklaerungEingereicht;
            chkArtikel41.DataMember = DBO.VmSteuern.Artikel41;
            edtFristverlaengerungBeantragt.DataMember = DBO.VmSteuern.FristverlaengerungBeantragt;
            edtEingangDefinitiveVeranlagung.DataMember = DBO.VmSteuern.EingangDefVeranlagung;
            edtDatumEntscheidErlass.DataMember = DBO.VmSteuern.DatumEntscheidErlass;
            chkErlass.DataMember = DBO.VmSteuern.Erlass;
            chkTeilerlass.DataMember = DBO.VmSteuern.Teilerlass;
            chkAbgelehnt.DataMember = DBO.VmSteuern.Abelehnt;
            edtDocument.DataMember = DBO.VmSteuern.DocumentID;
            edtBemerkungen.DataMember = DBO.VmSteuern.Bemerkungen;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colSteuerJahr.FieldName = DBO.VmSteuern.SteuerJahr;
            colErledigungExtern.FieldName = DBO.VmSteuern.SteuererklaerungExternErledigt;
            colErledigungIntern.FieldName = DBO.VmSteuern.SteuererklaerungInternErledigt;
            colSteuererklaerungEingereicht.FieldName = DBO.VmSteuern.SteuererklaerungEingereicht;
            colFristverlaengerungBeantragt.FieldName = DBO.VmSteuern.FristverlaengerungBeantragt;
            colEingangDefVeranlagung.FieldName = DBO.VmSteuern.EingangDefVeranlagung;
            colBemerkungen.FieldName = DBO.VmSteuern.Bemerkungen;
            colIsDeleted.FieldName = DBO.VmSteuern.IsDeleted;

            // set column as RTF
            colBemerkungen.DisplayFormat.Format = new GridColumnRTF();
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            // Positionierung der RadioGrp
            radGrpDeleted.Top = edtSearchFristverlaengerungBeantragtVon.Top;

            // DrawZell render Methode hinzufügen.
            GridView = grvVmSteuern;

        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtSteuerjahr.Tag = lblSteuerjahr.Text;
            edtErledigungDurch.Tag = lblErledigungDurch.Text;
            edtSteuererklaerungEingereicht.Tag = lblSteuererklaerungEingereicht.Text;
            edtFristverlaengerungBeantragt.Tag = lblFristverlaengerungBeantragt.Text;
            edtEingangDefinitiveVeranlagung.Tag = lblEingangDefinitiveVeranlagung.Text;
            edtDatumEntscheidErlass.Tag = lblDatumEntscheidErlass.Text;
            edtDocument.Tag = lblDocument.Text;
            edtBemerkungen.Tag = lblBemerkungen.Text;
        }

        #endregion

        #endregion
    }
}