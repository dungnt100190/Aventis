using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmGefaehrdungsmeldung : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_NSBCODE_TEXT = "VmGefaehrdungNSBCodesText";
        private const string COL_THEMENCODES_TEXT = "FaThemaCodesText";
        private const string CONTEXT_DOC = "VmJAGefaehrdungsmeldung";
        private const string LOVNAME_FAKONTAKTVERANLASSER = "FaKontaktveranlasser";

        #endregion

        #endregion

        #region Constructors

        public CtlVmGefaehrdungsmeldung()
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

        private void qryVmGefaehrdungsmeldung_AfterInsert(object sender, EventArgs e)
        {
            qryVmGefaehrdungsmeldung[DBO.VmGefaehrdungsMeldung.FaLeistungID] = _faLeistungId;
            qryVmGefaehrdungsmeldung.SetCreator();
        }

        private void qryVmGefaehrdungsmeldung_BeforePost(object sender, EventArgs e)
        {
            qryVmGefaehrdungsmeldung[COL_THEMENCODES_TEXT] = UtilsGui.GetKissCheckedLookupEditGridString(edtThemen);
            qryVmGefaehrdungsmeldung.SetModifierModified();
        }

        private void qryVmGefaehrdungsmeldung_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmGefaehrdungsmeldung.IsEmpty)
            {
                panelDetail.Enabled = false;
            }
            else
            {
                panelDetail.Enabled = true;
            }
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmGefaehrdungsmeldung.IsEmpty)
            {
                panelDetail.Enabled = true;
            }
            else
            {
                panelDetail.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Init(string titleName, Image titleImage, int baPersonId, int faLeistungId)
        {
            base.Init(titleName, titleImage, baPersonId, faLeistungId);
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Felder werden aktiv oder inaktiv, jenachdem, ob der 
        /// Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtEingangsDatum.EditMode = editMode;
            edtMelderin.EditMode = editMode;
            edtNSB.EditMode = editMode;
            edtThemen.EditMode = editMode;
            edtAusgangslage.EditMode = editMode;
            edtAuflagen.EditMode = editMode;
            edtUeberpruefungen.EditMode = editMode;
            edtKonsequenzen.EditMode = editMode;
            edtAuflagenAufg.EditMode = editMode;
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

            kissSearch.SelectParameters = new object[] { _faLeistungId, isDeleted1, isDeleted2, themen, alleThemen };

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
            edtEingangsDatum.DataMember = DBO.VmGefaehrdungsMeldung.DatumEingang;
            edtMelderin.DataMember = DBO.VmGefaehrdungsMeldung.FaKontaktveranlasserCode;
            edtNSB.DataMember = DBO.VmGefaehrdungsMeldung.VmGefaehrdungNSBCodes;
            edtThemen.DataMember = DBO.VmGefaehrdungsMeldung.FaThemaCodes;
            edtAusgangslage.DataMember = DBO.VmGefaehrdungsMeldung.Ausgangslage;
            edtAuflagen.DataMember = DBO.VmGefaehrdungsMeldung.Auflagen;
            edtUeberpruefungen.DataMember = DBO.VmGefaehrdungsMeldung.Ueberpruefung;
            edtKonsequenzen.DataMember = DBO.VmGefaehrdungsMeldung.Konsequenzen;
            edtAuflagenAufg.DataMember = DBO.VmGefaehrdungsMeldung.AuflageDatum;
            edtDokument.DataMember = DBO.VmGefaehrdungsMeldung.DocumentID;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.VmGefaehrdungsMeldung.DatumEingang;
            colMelder.FieldName = DBO.VmGefaehrdungsMeldung.FaKontaktveranlasserCode;
            colMelder.ColumnEdit = grdVmGefaehrdungsmeldung.GetLOVLookUpEdit(LOVNAME_FAKONTAKTVERANLASSER);
            colNSB.FieldName = COL_NSBCODE_TEXT;
            colThemen.FieldName = COL_THEMENCODES_TEXT;
            colAuflageDatum.FieldName = DBO.VmGefaehrdungsMeldung.AuflageDatum;
            colIsDeleted.FieldName = DBO.VmGefaehrdungsMeldung.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtEingangsdatumVonSuche.Top;

            //DrawZell render Methode hinzufügen.
            GridView = grvVmGefaehrdungsmeldung;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtEingangsDatum.Tag = lblEingangsdatum.Text;
            edtMelderin.Tag = lblMelder.Text;
            edtNSB.Tag = lblNSB.Text;
            edtThemen.Tag = lblThemen.Text;
            edtAusgangslage.Tag = lblAusgangslage.Text;
            edtAuflagen.Tag = lblAuflagen.Text;
            edtUeberpruefungen.Tag = lblUeberpruefungen.Text;
            edtKonsequenzen.Tag = lblKonsequenzen.Text;
            edtAuflagenAufg.Tag = lblAuflagenAufg.Text;
        }

        #endregion

        #endregion
    }
}