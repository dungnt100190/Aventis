using System;
using System.Drawing;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung
{
    public partial class CtlFaAktennotiz : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_FA_THEMENCODES = "FaThemaCodesText";
        private const string COL_USER = "User";
        private const string CONTEXT_FA_BERICHT = "FaDokBesprBericht";
        private const string CONTEXT_VM_AD_BERICHT = "VmAdoptionBesprBericht";
        private const string CONTEXT_VM_BS_BERICHT = "VmBsDokBesprBericht";

        //Prozesscodes
        private const int PC_FALLFUEHRUNG = 200;

        private const int PC_VM_ERBSCHAFT = 503;
        private const int PC_VM_VATERSCHAFTSABKLAERUNG = 502;
        private const int PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG = 505;
        private const int PC_VM_VORMUNDSCHTL_MASSNAHME = 501;

        #endregion

        #region Private Fields

        private bool _dauerAktiv;
        private int _faProzessCode;
        private string _klientName;

        #endregion

        #endregion

        #region Constructors

        public CtlFaAktennotiz()
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
        ///  Button Restore Document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestoreDocument_Click(object sender, EventArgs e)
        {
            //Dokument wieder herstellen.
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

        /// <summary>
        /// Wird nach einem Insert ausgeführt, aber bevor
        /// die Daten in die Db geschrieben werden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryFaAktennotiz_AfterInsert(object sender, EventArgs e)
        {
            qryFaAktennotiz[DBO.FaAktennotizen.FaLeistungID] = _faLeistungId;
            qryFaAktennotiz[DBO.FaAktennotizen.Datum] = DateTime.Today;
            qryFaAktennotiz[DBO.FaAktennotizen.UserID] = Session.User.UserID;
            qryFaAktennotiz[COL_USER] = Session.User.LastName + ", " + Session.User.FirstName;
            qryFaAktennotiz[DBO.FaAktennotizen.Vertraulich] = 0;
            qryFaAktennotiz[DBO.FaAktennotizen.Kontaktpartner] = _klientName;

            //Creator Setzen (Wer den Datensatz angelegt hat und wann er angelegt worden ist.)
            qryFaAktennotiz.SetCreator();

            edtDatum.Focus();
        }

        /// <summary>
        /// Is executed before the Data is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryFaAktennotiz_BeforePost(object sender, EventArgs e)
        {
            //Themenliste
            qryFaAktennotiz[COL_FA_THEMENCODES] = UtilsGui.GetKissCheckedLookupEditGridString(edtThemen);

            //Wir setzen den Modifier (wer den Datensatz verändert hat und wann).
            qryFaAktennotiz.SetModifierModified();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "THEMENFILTER":
                    return (lookupThemen.EditValue == "") ? "0" : lookupThemen.EditValue;
                case "FILTERAKTIV":
                    return chkThemenFilter.Checked;
                case "FAAKTENNOTIZID":
                    return qryFaAktennotiz["FaAktennotizID"];
                case "FALEISTUNGID":
                    return _faLeistungId;
                case "BAPERSONID":
                    return _baPersonId;
                case "USERID":
                    return qryFaAktennotiz["UserID"];
                case "OWNERUSERID":
                    return (int)DBUtil.ExecuteScalarSQL(@"
                        SELECT UserID
                        FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                        WHERE FaLeistungID = {0}", _faLeistungId);
                case "SEARCHDELETEDFILTER":
                    return (radGrpDeleted.SelectedIndex < 0) ? 0 : radGrpDeleted.SelectedIndex;
                case "SEARCHDATUMVON":
                    return (edtFaDokSucheDatumVon.EditValue == null) ? "0" : edtFaDokSucheDatumVon.DateTime.ToString("yyyyMMdd");
                case "SEARCHDATUMBIS":
                    return (edtFaDokSucheDatumBis.EditValue == null) ? "0" : edtFaDokSucheDatumBis.DateTime.ToString("yyyyMMdd");
                case "SEARCHKONTAKTART":
                    return (edtFaDokSucheKontaktart.EditValue == null) ? 0 : Utils.ConvertToInt(edtFaDokSucheKontaktart.EditValue);
                case "SEARCHUSERID":
                    return (edtFaDokSucheSAR.EditValue == null) ? 0 : Utils.ConvertToInt(edtFaDokSucheSAR.LookupID);
                case "SEARCHSTICHWORT":
                    return (edtFaDokSucheStichwort.EditValue == null) ? "0" : "%" + Utils.ConvertToString(edtFaDokSucheStichwort.EditValue) + "%";
            }
            return base.GetContextValue(fieldName);
        }

        public override void Init(string maskName, Image maskImage, int baPersonId, int faLeistungId)
        {
            base.Init(maskName, maskImage, baPersonId, faLeistungId);

            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Name = Name + ', ' + Vorname
                FROM dbo.BaPerson WITH(READUNCOMMITTED)
                WHERE BaPersonID = {0};", _baPersonId);

            _klientName = Utils.ConvertToString(qry["Name"]);

            SqlQuery faLeistg = DBUtil.OpenSQL(@"
                SELECT FaProzessCode
                FROM dbo.FaLeistung WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0};",
                 _faLeistungId);

            _faProzessCode = DBUtil.IsEmpty(faLeistg["FaProzessCode"]) ? 200 : Utils.ConvertToInt(faLeistg["FaProzessCode"]);

            // Feld Dauer je nach Konfigwert deaktivieren
            _dauerAktiv = DBUtil.GetConfigBool(@"System\Fallfuehrung\KorrespondenzDauer", true);

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Stellt die Controls auf ReadOnly oder auf Normal,
        /// je nach dem, ob das Dokument logisch gelöscht worden ist.
        /// </summary>
        /// <param name="isActive">Ob das Dokument aktiv ist (also nicht gelöscht)</param>
        /// <param name="editMode"></param>
        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtDatum.EditMode = editMode;
            edtFaDokBesprKontakPart.EditMode = editMode;
            edtFaDokBesprKontakArt.EditMode = editMode;
            edtFaDokBesprAutor.EditMode = editMode;
            edtStichwort.EditMode = editMode;
            edtThemen.EditMode = editMode;
            memInhalt.EditMode = editMode;

            edtDauer.EditMode = _dauerAktiv ? editMode : EditModeType.ReadOnly;

            //Der Button btnDokument ist immer enabled,
            //auch wenn der Datensatz logisch gelöscht ist oder oder wenn
            //das Grid keinen Treffer enthält. (#7067).
            //Mit Andi Fuchs besprochen.
            //btnDokument.Enabled = isActive;
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

            kissSearch.SelectParameters = new object[] { _faLeistungId, isDeleted1, isDeleted2, themen, alleThemen, Session.User.LanguageCode };

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
            //Auskommmentiert. Wird bei PI verwendet und eventuell später gebraucht.

            //PC_FALLFUEHRUNG, 200: Fallführung/Dokumentation/Korrespondenz
            //PC_VM_VORMUNDSCHTL_MASSNAHME, 501: Vormundschaftliche Massnahme/Behördenseketariat/Dokumentation/Korrespondenz
            //PC_VM_ERBSCHAFT, 503: Erbschaftsamt/Dokumentation/Korrespondenz
            //PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG, 505: Auftrag Jugendamt/Adoption/Korrespondenz
            switch (_faProzessCode)
            {
                case PC_VM_VORMUNDSCHTL_MASSNAHME:
                    btnDokument.Context = CONTEXT_VM_BS_BERICHT;
                    break;

                case PC_VM_ERBSCHAFT:
                    btnDokument.Context = CONTEXT_FA_BERICHT;
                    break;

                case PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG:
                    btnDokument.Context = CONTEXT_VM_AD_BERICHT;
                    break;

                case PC_FALLFUEHRUNG:
                    btnDokument.Context = CONTEXT_FA_BERICHT;
                    break;
            }
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtDatum.DataMember = DBO.FaAktennotizen.Datum;
            edtFaDokBesprKontakPart.DataMember = DBO.FaAktennotizen.Kontaktpartner;
            edtFaDokBesprKontakArt.DataMember = DBO.FaAktennotizen.FaKontaktartCode;
            edtDauer.DataMember = DBO.FaAktennotizen.FaDauerCode;
            edtFaDokBesprAutor.DataMember = COL_USER;
            edtStichwort.DataMember = DBO.FaAktennotizen.Stichwort;
            memInhalt.DataMember = DBO.FaAktennotizen.InhaltRTF;
            edtThemen.DataMember = DBO.FaDokumente.FaThemaCodes;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.FaAktennotizen.Datum;
            colThemen.FieldName = COL_FA_THEMENCODES;
            colKontaktpartner.FieldName = DBO.FaAktennotizen.Kontaktpartner;
            colMitarbeiter.FieldName = COL_USER;
            colStichwort.FieldName = DBO.FaAktennotizen.Stichwort;
            colIsDeleted.FieldName = DBO.FaAktennotizen.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            GridView = gvwFaAktennotiz;
            SetupRadioGroup();
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtDatum.Tag = lblDatum.Text;
            edtFaDokBesprKontakPart.Tag = lblKontaktpartner.Text;
            edtFaDokBesprKontakArt.Tag = lblKontaktart.Text;
            edtDauer.Tag = lblDauer.Text;
            edtFaDokBesprAutor.Tag = lblAutor.Text;
            edtStichwort.Tag = lblStichwort.Text;
            memInhalt.Tag = lblInhalt.Text;
            edtThemen.Tag = lblThemen.Text;
        }

        #endregion

        #endregion

        #region Other

        //Wird bei PI gebraucht, verwenden wir eventuell auch.
        //private const string CONTEXT_UEBERSICHT = "FaDokBesprUebersicht";

        #endregion
    }
}