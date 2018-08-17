using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;
using KiSS4.Common;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmELKrankheitskosten : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONTEXT_DOC = "VmMfElKrankheitskostenWord";

        #endregion

        #endregion

        #region Constructors

        public CtlVmELKrankheitskosten()
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

        private void qryVmElKrankheitskosten_AfterInsert(object sender, EventArgs e)
        {
            qryVmElKrankheitskosten[DBO.VmELKrankheitskosten.FaLeistungID] = _faLeistungId;
            qryVmElKrankheitskosten.SetCreator();
        }

        private void qryVmElKrankheitskosten_BeforePost(object sender, EventArgs e)
        {
            qryVmElKrankheitskosten.SetModifierModified();
        }

        private void qryVmElKrankheitskosten_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmElKrankheitskosten.IsEmpty)
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
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmElKrankheitskosten.IsEmpty)
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

        protected override void NewSearch()
        {
            base.NewSearch();
            edtEingereicht.Focus();
        }

        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtEingereicht.EditMode = editMode;
            edtAbrechnungenVon.EditMode = editMode;
            edtVerfuegungVon.EditMode = editMode;
            edtBetrag.EditMode = editMode;
            edtAbrechnungBis.EditMode = editMode;
            edtLeistung.EditMode = editMode;
            edtDokument.EditMode = editMode;
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
            edtDokument.Context = CONTEXT_DOC;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtEingereicht.DataMember = DBO.VmELKrankheitskosten.Eingereicht;
            edtAbrechnungenVon.DataMember = DBO.VmELKrankheitskosten.AbrechnungenVom;
            edtVerfuegungVon.DataMember = DBO.VmELKrankheitskosten.VerfuegungVom;
            edtBetrag.DataMember = DBO.VmELKrankheitskosten.Betrag;
            edtAbrechnungBis.DataMember = DBO.VmELKrankheitskosten.AbrechnungenBis;
            edtLeistung.DataMember = DBO.VmELKrankheitskosten.VerfuegungLeistung;
            edtDokument.DataMember = DBO.VmELKrankheitskosten.DocumentID;
            edtBemerkungen.DataMember = DBO.VmELKrankheitskosten.Bemerkungen;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colEingereicht.FieldName = DBO.VmELKrankheitskosten.Eingereicht;
            colBetrag.FieldName = DBO.VmELKrankheitskosten.Betrag;
            colAbrechnungenBis.FieldName = DBO.VmELKrankheitskosten.AbrechnungenBis;
            colVerfuegung.FieldName = DBO.VmELKrankheitskosten.VerfuegungVom;
            colLeistung.FieldName = DBO.VmELKrankheitskosten.VerfuegungLeistung;
            colIsDeleted.FieldName = DBO.VmELKrankheitskosten.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtEingereichtVomSuche.Top;

            //DrawZell render Methode hinzufügen.
            GridView = grvVmELKrankheitskosten;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtEingereicht.Tag = lblEingereicht.Text;
            edtAbrechnungenVon.Tag = lblAbrechnungenVon.Text;
            edtVerfuegungVon.Tag = lblVerfuegungVom.Text;
            edtBetrag.Tag = lblBetrag.Text;
            edtAbrechnungBis.Tag = lblBis.Text;
            edtLeistung.Tag = lblLeistung.Text;
            edtDokument.Tag = lblDokument.Text;
            edtBemerkungen.Tag = lblBemerkungen.Text;
        }

        #endregion

        #endregion
    }
}