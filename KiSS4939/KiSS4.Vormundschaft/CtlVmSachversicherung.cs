using System;
using System.Drawing;

using SharpLibrary.WinControls;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;

using KiSS.DBScheme;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmSachversicherung : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string ADRESSAT_NAME = "AdressatName";
        private const string CONTEXT_DOC_AUFHEBUNG = "VmMfSachversicherungAufhebung";
        private const string CONTEXT_DOC_MITTEILUNG = "VmMfSachversicherungMitteilung";
        private const string CONTEXT_DOC_MUTATION = "VmMfSachversicherungMutation";
        private const string LOV_VERSICHERUNGSART = "VmVersicherungsartSachversicherung";
        private const string LOV_ZAHLUNGSTURNUS = "VmZahlungsturnus";

        #endregion

        #endregion

        #region Constructors

        public CtlVmSachversicherung()
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

        private void qryVmSachversicherung_AfterInsert(object sender, EventArgs e)
        {
            qryVmSachversicherung[DBO.VmSachversicherung.FaLeistungID] = _faLeistungId;
            qryVmSachversicherung.SetCreator();
        }

        private void qryVmSachversicherung_BeforePost(object sender, EventArgs e)
        {
            qryVmSachversicherung.SetModifierModified();
        }

        private void qryVmSachversicherung_PositionChanged(object sender, EventArgs e)
        {
            if (qryVmSachversicherung.IsEmpty)
            {
                panDetail.Enabled = false;
            }
            else
            {
                panDetail.Enabled = true;
            }

            ctlLogischLoeschen.RefreshState();
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (tabControlSearch.SelectedTab == tpgListe && !qryVmSachversicherung.IsEmpty)
            {
                panDetail.Enabled = true;
            }
            else
            {
                panDetail.Enabled = false;
            }

            ctlLogischLoeschen.RefreshState();
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
                        ref qryVmSachversicherung,
                        DBO.VmSachversicherung.BaPersonID,
                        DBO.VmSachversicherung.BaInstitutionID,
                        DBO.VmSachversicherung.VmPriMaID);

                case "VMSACHVERSICHERUNGID":
                    return (DBUtil.IsEmpty(qryVmSachversicherung[DBO.VmSachversicherung.VmSachversicherungID]) ? 0 : Convert.ToInt32(qryVmSachversicherung[DBO.VmSachversicherung.VmSachversicherungID]));
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
            edtVersicherungsart.Focus();
        }

        /// <summary>
        /// Felder sind enabled oder disabled, je nachdem,
        /// ob der Datensatz logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtVersicherungsart.EditMode = editMode;
            edtPoliceNr.EditMode = editMode;
            edtAdressat.EditMode = editMode;
            edtSelbsthalt.EditMode = editMode;
            edtGrundpraemie.EditMode = editMode;
            edtZahlungsturnus.EditMode = editMode;
            edtLaufzeitVon.EditMode = editMode;
            edtLaufzeitBis.EditMode = editMode;
            edtVersichertSeit.EditMode = editMode;
            edtDocMitteilungAnmeldung.EditMode = editMode;
            edtDocMutation.EditMode = editMode;
            edtDocAufhebungKuendigung.EditMode = editMode;
            edtZusaetzlichePerson.EditMode = editMode;
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
            edtDocMitteilungAnmeldung.Context = CONTEXT_DOC_MITTEILUNG;
            edtDocMutation.Context = CONTEXT_DOC_MUTATION;
            edtDocAufhebungKuendigung.Context = CONTEXT_DOC_AUFHEBUNG;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtVersicherungsart.DataMember = DBO.VmSachversicherung.VmVersicherungsartSachversicherungCode;
            edtPoliceNr.DataMember = DBO.VmSachversicherung.Policenummer;
            edtAdressat.DataMember = ADRESSAT_NAME;
            edtAdressat.DataMemberBaInstitution = DBO.VmSachversicherung.BaInstitutionID;
            edtAdressat.DataMemberBaPerson = DBO.VmSachversicherung.BaPersonID;
            edtAdressat.DataMemberFaLeistung = DBO.VmSachversicherung.FaLeistungID;
            edtAdressat.DataMemberVmPriMa = "VmPriMaID"; //todo mit DBO ersetzen.
            edtSelbsthalt.DataMember = DBO.VmSachversicherung.Selbstbehalt;
            edtGrundpraemie.DataMember = DBO.VmSachversicherung.Grundpraemie;
            edtZahlungsturnus.DataMember = DBO.VmSachversicherung.VmZahlungsturnusCode;
            edtLaufzeitVon.DataMember = DBO.VmSachversicherung.LaufzeitVon;
            edtLaufzeitBis.DataMember = DBO.VmSachversicherung.LaufzeitBis;
            edtVersichertSeit.DataMember = DBO.VmSachversicherung.VersichertSeit;
            edtDocMitteilungAnmeldung.DataMember = DBO.VmSachversicherung.DocumentID_MittAnm;
            edtDocMutation.DataMember = DBO.VmSachversicherung.DocumentID_Mutation;
            edtDocAufhebungKuendigung.DataMember = DBO.VmSachversicherung.DocumentID_AufhKuend;
            edtZusaetzlichePerson.DataMember = DBO.VmSachversicherung.Person;
            edtBemerkungen.DataMember = DBO.VmSachversicherung.Bemerkungen;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colVersicherungsart.FieldName = DBO.VmSachversicherung.VmVersicherungsartSachversicherungCode;
            colVersicherungsart.ColumnEdit = grdVmAntragEKSK.GetLOVLookUpEdit(LOV_VERSICHERUNGSART);
            colAdressat.FieldName = ADRESSAT_NAME;
            colGrundpraemie.FieldName = DBO.VmSachversicherung.Grundpraemie;
            colFaelligkeit.FieldName = DBO.VmSachversicherung.VmZahlungsturnusCode;
            colFaelligkeit.ColumnEdit = grdVmAntragEKSK.GetLOVLookUpEdit(LOV_ZAHLUNGSTURNUS);
            colLaufzeitBis.FieldName = DBO.VmSachversicherung.LaufzeitBis;
            colIsDeleted.FieldName = DBO.VmSachversicherung.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            //Positionierung der RadioGrp
            radGrpDeleted.Top = edtSearchVersicherungsart.Top;

            //DrawZell render Methode hinzufügen.
            GridView = grvVmAntragEKSK;
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtVersicherungsart.Tag = lblVersicherungsart.Text;
            edtPoliceNr.Tag = lblPoliceNr.Text;
            edtAdressat.Tag = lblAdressat.Text;
            edtSelbsthalt.Tag = lblSelbsthalt.Text;
            edtGrundpraemie.Tag = lblGrundpraemie.Text;
            edtZahlungsturnus.Tag = lblZahlungsturnuns.Text;
            edtLaufzeitVon.Tag = lblLaufzeitVon.Text;
            edtLaufzeitBis.Tag = lblLaufzeitBis.Text;
            edtVersichertSeit.Tag = lblVersichertSeit.Text;
            edtDocMitteilungAnmeldung.Tag = lblDocMitteilungAnmeldung.Text;
            edtDocMutation.Tag = lblDocMutation.Text;
            edtDocAufhebungKuendigung.Tag = lblDocAufhebungKuendigung.Text;
            edtZusaetzlichePerson.Tag = lblZusaetzlichePerson.Text;
            edtBemerkungen.Tag = lblBermerkungen.Text;
        }

        #endregion

        #endregion
    }
}