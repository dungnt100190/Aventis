using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmSozialversicherung : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string ADRESSAT_NAME = "AdressatName";
        private const string CONTEXT_DOC = "VmSozialversicherungenKorre";
        private const string LOV_BEZEICHNUNG = "VmSozialversicherungenBezeichnungen";

        #endregion

        #endregion

        #region Constructors

        public CtlVmSozialversicherung()
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

        /// <summary>
        /// Dokument wieder herstellen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            OnRestoreData();
        }

        private void qryVmSozialversicherung_AfterInsert(object sender, EventArgs e)
        {
            qryVmSozialversicherung[DBO.VmSozialversicherung.FaLeistungID] = _faLeistungId;
            qryVmSozialversicherung.SetCreator();
        }

        private void qryVmSozialversicherung_BeforePost(object sender, EventArgs e)
        {
            qryVmSozialversicherung.SetModifierModified();
        }

        private void qryVmSozialversicherung_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmSozialversicherung.IsEmpty)
            {
                tabControlDetail.Enabled = false;
            }
            else
            {
                tabControlDetail.Enabled = true;
            }
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmSozialversicherung.IsEmpty)
            {
                tabControlDetail.Enabled = true;
            }
            else
            {
                tabControlDetail.Enabled = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ADRESSAT":
                    return (DBUtil.IsEmpty(edtAdressat.LookupID) ? 0 : edtAdressat.LookupID);

                case "ADRESSATID":
                    return GetAdressatID(
                        ref qryVmSozialversicherung,
                        DBO.VmSozialversicherung.BaPersonID_Adressat,
                        DBO.VmSozialversicherung.BaInstitutionID_Adressat,
                        DBO.VmSozialversicherung.VmPriMaID_Adressat);

                case "VMSOZIALVERSICHERUNGID":
                    return (DBUtil.IsEmpty(qryVmSozialversicherung[DBO.VmSozialversicherung.VmSozialversicherungID]) ? 0 : Convert.ToInt32(qryVmSozialversicherung[DBO.VmSozialversicherung.VmSozialversicherungID]));
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

        /// <summary>
        /// Felder sind enabled oder disabled, je nachdem,
        /// ob der Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtBezeichnung.EditMode = editMode;
            edtGrund.EditMode = editMode;
            edtEingereichtAm.EditMode = editMode;
            edtVerfuegtVom.EditMode = editMode;
            edtBerechnungsGrundlage.EditMode = editMode;
            edtVerfuegungsbetragMtl.EditMode = editMode;
            edtDocument.EditMode = editMode;
            edtBemerkungen.EditMode = editMode;
            edtAdressat.EditMode = editMode;
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
            edtBezeichnung.DataMember = DBO.VmSozialversicherung.VmSozialversicherungenBezeichnungenCode;
            edtGrund.DataMember = DBO.VmSozialversicherung.Grund;
            edtEingereichtAm.DataMember = DBO.VmSozialversicherung.Eingereicht;
            edtVerfuegtVom.DataMember = DBO.VmSozialversicherung.VerfuegungVom;
            edtBerechnungsGrundlage.DataMember = DBO.VmSozialversicherung.Berechnungsgrundlage;
            edtVerfuegungsbetragMtl.DataMember = DBO.VmSozialversicherung.Verfuegungsbetrag;

            edtAdressat.DataMember = ADRESSAT_NAME;
            edtAdressat.DataMemberBaInstitution = DBO.VmSozialversicherung.BaInstitutionID_Adressat;
            edtAdressat.DataMemberBaPerson = DBO.VmSozialversicherung.BaPersonID_Adressat;
            edtAdressat.DataMemberFaLeistung = DBO.VmSozialversicherung.FaLeistungID;
            edtAdressat.DataMemberVmPriMa = "VmPriMaID_Adressat"; //todo DBO verwenden.

            edtDocument.DataMember = DBO.VmSozialversicherung.DocumentID_Korrespondenz;
            edtBemerkungen.DataMember = DBO.VmSozialversicherung.Bemerkungen;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colBezeichnung.FieldName = DBO.VmSozialversicherung.VmSozialversicherungenBezeichnungenCode;
            colBezeichnung.ColumnEdit = grdVmSozialversicherung.GetLOVLookUpEdit(LOV_BEZEICHNUNG);
            colGrund.FieldName = DBO.VmSozialversicherung.Grund;
            colGrundlage.FieldName = DBO.VmSozialversicherung.Berechnungsgrundlage;
            colEingereicht.FieldName = DBO.VmSozialversicherung.Eingereicht;
            colVerfuegung.FieldName = DBO.VmSozialversicherung.VerfuegungVom;
            colVerfuegungsBetrag.FieldName = DBO.VmSozialversicherung.Verfuegungsbetrag;
            colIsDeleted.FieldName = DBO.VmSozialversicherung.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            // Positionierung der RadioGrp
            radGrpDeleted.Top = edtBezeichnungSuche.Top;

            // DrawZell render Methode hinzufügen.
            GridView = grvVmSozialversicherung;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtBezeichnung.Tag = lblBezeichnung.Text;
            edtGrund.Tag = lblGrund.Text;
            edtEingereichtAm.Tag = lblEingereichtAm.Text;
            edtVerfuegtVom.Tag = lblVerfuegtVom.Text;
            edtBerechnungsGrundlage.Tag = lblBerechnungsGrundlage.Text;
            edtVerfuegungsbetragMtl.Tag = lblVerfuegungsbetragMtl.Text;
            edtDocument.Tag = lblKorrespondenz.Text;
            edtBemerkungen.Tag = lblBemerkungen.Text;
        }

        #endregion

        #endregion
    }
}