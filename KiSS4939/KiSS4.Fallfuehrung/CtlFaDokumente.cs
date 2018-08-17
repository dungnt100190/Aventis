using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung
{
    public partial class CtlFaDokumente : KissSearchLogischesLoeschenUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_ABSENDERNAME = "AbsenderName";
        private const string COL_ADRESSATNAME = "AdressatName";
        private const string COL_FATHEMACODESTEXT = "FaThemaCodesText";
        private const string CONTEXT_DOC_MERKBLATT = "VmVaterschaftenMerkblätter";

        //Für spaltennamen, welche nicht in Dbo.FaDokumente enthalten sind
        private const string FDO_ABSENDERNAME = "AbsenderName";

        private const string FDO_ADRESSATNAME = "AdressatName";
        private const string LOVNAME_DIENST = "VmErbDienst";

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
        private bool _isInitialized;

        #endregion

        #endregion

        #region Constructors

        public CtlFaDokumente()
        {
            InitializeComponent();
            SetupDataMembers();
            SetupFieldNames();
            SetupTags();
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

        /// <summary>
        /// Themenfilter ein / aus Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        private void qryFaDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryFaDokumente[DBO.FaDokumente.FaLeistungID] = _faLeistungId;
            qryFaDokumente[DBO.FaDokumente.Vertraulich] = 0;
            qryFaDokumente[DBO.FaDokumente.IstBericht] = 0;
            qryFaDokumente[DBO.FaDokumente.DatumErstellung] = DateTime.Today;
            qryFaDokumente[DBO.FaDokumente.BaPersonID_LT] = _baPersonId;

            //Creator Setzen (Wer den Datensatz angelegt hat und wann er angelegt worden ist.)
            qryFaDokumente.SetCreator();
        }

        /// <summary>
        /// Input Validierung.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryFaDokumente_BeforePost(object sender, EventArgs e)
        {
            //KorrespondenzDatum ist ein Mussfeld.
            DBUtil.CheckNotNullField(edtDatumErstellung, lblDatumErstellung.Text);

            //Wir setzen den Modifier (wer den Datensatz verändert hat und wann).
            qryFaDokumente.SetModifierModified();

            //Themen aufgelistet mit Komma.
            qryFaDokumente[COL_FATHEMACODESTEXT] = UtilsGui.GetKissCheckedLookupEditGridString(edtThemen);
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

                case "ADRESSAT":
                    return (DBUtil.IsEmpty(edtAdressat.LookupID) ? 0 : edtAdressat.LookupID);

                case "ADRESSATID":
                    return GetAdressatID(
                        ref qryFaDokumente,
                        DBO.FaDokumente.BaPersonID_Adressat,
                        DBO.FaDokumente.BaInstitutionID_Adressat,
                        DBO.FaDokumente.VmPriMaID_Adressat);

                case "FADOKUMENTEID":
                    return (DBUtil.IsEmpty(qryFaDokumente[DBO.FaDokumente.FaDokumenteID]) ? 0 : Convert.ToInt32(qryFaDokumente[DBO.FaDokumente.FaDokumenteID]));
            }

            return base.GetContextValue(fieldName);
        }

        public override void Init(string maskName, Image maskImage, int personID, int leistungID)
        {
            base.Init(maskName, maskImage, personID, leistungID);
            lblTitle.Text = maskName;
            imageTitle.Image = maskImage;

            tabControlSearch.SelectedTabIndex = 0;

            SqlQuery faLeistg = DBUtil.OpenSQL(
                "select FaProzessCode from dbo.FaLeistung where FaLeistungID = {0}",
                _faLeistungId);

            //Es gibt Datensätze, wo kein Prozesscode in der Fallführung vorhanden ist.
            //-> Gemäss Besprechung mit Christian und Rolf ist in diesem Falle der FaProzessCode 200 anzunehmen.
            _faProzessCode = DBUtil.IsEmpty(faLeistg["FaProzessCode"]) ? 200 : Utils.ConvertToInt(faLeistg["FaProzessCode"]);

            //Die Methoden SetVisibility und RePositionGUIElements sollten nur einmal ausgeführt werden.
            if (!_isInitialized)
            {
                SetupContext();

                //Sichtbarkeit der Controls setzen
                SetVisibility(_faProzessCode);

                //Controls Positionieren (weil einige Elemente je nach Prozess ausgeblendet werden).
                RePositionGUIElements();

                _isInitialized = true;
            }

            // Feld Dauer je nach Konfigwert deaktivieren
            _dauerAktiv = DBUtil.GetConfigBool(@"System\Fallfuehrung\KorrespondenzDauer", true);

            NewSearchAndRun();
        }

        #endregion

        #region Protected Methods

        protected override void OnEnableFields(bool isActive, EditModeType editMode)
        {
            edtDatumErstellung.EditMode = editMode;
            edtAdressat.EditMode = editMode;
            edtErbDienst.EditMode = editMode;
            edtAbsender.EditMode = editMode;
            edtThemen.EditMode = editMode;
            edtThema.EditMode = editMode;
            edtStichwort.EditMode = editMode;
            edtFaDokKorreDokument.EditMode = editMode;
            edtBericht.EditMode = editMode;
            memBemerkung.EditMode = editMode;

            edtDauer.EditMode = _dauerAktiv ? editMode : EditModeType.ReadOnly;
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

        #region Private Static Methods

        /// <summary>
        /// Fügt eine neue User-Interface-Row der Liste list hinzu.
        /// Siehe auch Methode RepositionControls.
        /// </summary>
        /// <param name="list">Die Liste (hier wird die Row hinzugefügt.</param>
        /// <param name="visible">Ob die Row sichtbar ist.</param>
        /// <param name="controls">Liste von Controls auf dieser Row</param>
        private static void AddUserInterfaceRow(IList<object[]> list, bool visible, params Control[] controls)
        {
            object[] uiRow = new object[controls.Length + 1];
            uiRow[0] = visible;
            for (int i = 0; i < controls.Length; i++)
            {
                uiRow[i + 1] = controls[i];
            }
            list.Add(uiRow);
        }

        /// <summary>
        /// Repositioniert die Controls auf dem UI,
        /// Je nach dem ob eine Row sichtbar ist oder nicht.
        /// Ein Eintrag ist wie folgt aufgebaut:
        /// row[0]: Ob Row sichtbar ist oder nicht.
        /// row[1]: Darauf folgen Controls. Column 1 ist in der Regel ein Label und
        ///         Column2 in der Regel ein Edit-Control.
        /// row[n]: Weitere Controls
        /// Der Return-Wert ist der Maximale Offset.
        /// </summary>
        /// <param name="rows"></param>
        /// <returns>Maximaler Offset</returns>
        private static int RepositionControls(IList<object[]> rows)
        {
            //Felder neu positionieren.
            //Da wir die Felder nach unten schieben, beginnen wir mit dem Ende der Liste.
            int offSet = 0;
            for (int i = rows.Count - 1; i >= 0; i--)
            {
                object[] row = rows[i];
                bool visible = (bool)row[0];

                int maxHeight = 0;

                for (int j = 1; j < row.Length; j++)
                {
                    Control control = (Control)row[j];
                    control.Top += offSet;

                    if (control is KissLabel)
                    {
                        //control.Visible = visible;
                    }
                    if (control.Height > maxHeight)
                    {
                        maxHeight = control.Height;
                    }
                }

                if (!visible)
                {
                    offSet += (maxHeight + 6);
                }
            }
            return offSet;
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///  Positioniert die Userinterface Elemente. Je nachdem, in welchem Prozess die Maske
        ///  aufgerufen wird, sind nicht alle Felder sichtbar. Für die Sichtbarkeit wird immer
        ///  das Edit-Kontrol konsultiert (edtXY.Visible) und nicht das Label.
        /// </summary>
        private void RePositionGUIElements()
        {
            IList<object[]> list = new List<object[]>();

            //Datum, Bericht, Themen
            AddUserInterfaceRow(list, edtDatumErstellung.Visible,
                lblDatumErstellung,
                edtDatumErstellung,
                edtBericht,
                edtThemen,
                lblThemen);

            //Absender
            AddUserInterfaceRow(list, edtAbsender.Visible, lblAbsender, edtAbsender);

            //Adressat
            AddUserInterfaceRow(list, edtAdressat.Visible, lblAdressat, edtAdressat);

            //Dienst
            AddUserInterfaceRow(list, edtErbDienst.Visible, lblErbDienst, edtErbDienst);

            //Dauer
            AddUserInterfaceRow(list, edtDauer.Visible, lblDauer, edtDauer);

            //Thema
            AddUserInterfaceRow(list, edtThema.Visible, lblThema, edtThema);

            //Stichwort
            AddUserInterfaceRow(list, edtStichwort.Visible, lblStichwort, edtStichwort);

            //Dokument
            AddUserInterfaceRow(list, edtFaDokKorreDokument.Visible, lblFaDokKorreDokument, edtFaDokKorreDokument);

            //Dokument Merkblätter
            AddUserInterfaceRow(list, edtDocMerkblaetter.Visible, lblMerkblaetter, edtDocMerkblaetter);

            //Handlung
            AddUserInterfaceRow(list, memBemerkung.Visible, lblBemerkung, memBemerkung);

            //CtlErfassungMutation
            AddUserInterfaceRow(list, ctlLogischLoeschen.Visible, ctlLogischLoeschen);

            int offSet = RepositionControls(list);

            //Wenn weniger Controls angezeigt werden,
            //machen wir das SearchControl grösser.
            tabControlSearch.Height = tabControlSearch.Height + offSet;
        }

        /// <summary>
        /// Context von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupContext()
        {
            //PC_FALLFUEHRUNG, 200: Fallführung/Dokumentation/Korrespondenz
            //PC_VM_VORMUNDSCHTL_MASSNAHME, 501: Vormundschaftliche Massnahme/Behördenseketariat/Dokumentation/Korrespondenz
            //PC_VM_ERBSCHAFT, 503: Erbschaftsamt/Dokumentation/Korrespondenz
            //PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG, 505: Auftrag Jugendamt/Adoption/Korrespondenz
            switch (_faProzessCode)
            {
                case PC_VM_VORMUNDSCHTL_MASSNAHME:
                    edtFaDokKorreDokument.Context = "VmBsKorrespondenz";
                    break;

                case PC_VM_ERBSCHAFT:
                    edtFaDokKorreDokument.Context = "VmErbeKorrespondenz";
                    break;

                case PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG:
                    edtFaDokKorreDokument.Context = "FaKorrespondenz";
                    break;

                case PC_FALLFUEHRUNG:
                    edtFaDokKorreDokument.Context = "FaKorrespondenz";
                    break;

                case PC_VM_VATERSCHAFTSABKLAERUNG:
                    edtFaDokKorreDokument.Context = "VmVaterschaftenDoku";
                    break;
            }
            edtDocMerkblaetter.Context = CONTEXT_DOC_MERKBLATT;
        }

        /// <summary>
        /// DataMember von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupDataMembers()
        {
            edtDatumErstellung.DataMember = DBO.FaDokumente.DatumErstellung;

            //Adressat.
            edtAdressat.DataMember = COL_ADRESSATNAME;
            edtAdressat.DataMemberBaInstitution = DBO.FaDokumente.BaInstitutionID_Adressat;
            edtAdressat.DataMemberBaPerson = DBO.FaDokumente.BaPersonID_Adressat;
            edtAdressat.DataMemberVmPriMa = "VmPriMaID_Adressat";//todo mit DBO ersetzen.
            edtAdressat.DataMemberFaLeistung = DBO.FaDokumente.FaLeistungID;

            edtAbsender.DataMember = COL_ABSENDERNAME;
            edtErbDienst.DataMember = DBO.FaDokumente.VmErbDienstCode;
            edtDauer.DataMember = DBO.FaDokumente.FaDauerCode;
            edtThema.DataMember = DBO.FaDokumente.ThemaCode;
            edtStichwort.DataMember = DBO.FaDokumente.Stichwort;
            edtFaDokKorreDokument.DataMember = DBO.FaDokumente.DocumentID;
            edtDocMerkblaetter.DataMember = DBO.FaDokumente.DocumentID_Merkblatt;
            memBemerkung.DataMember = DBO.FaDokumente.Bemerkung;
            edtThemen.DataMember = DBO.FaDokumente.FaThemaCodes;
        }

        /// <summary>
        /// FieldName für die Kolonen von Konstant nehmen und nicht als Text im Designer.
        /// So muss man nur an einem Ort der Spaltename ändern wenn es auf der DB eine Änderung gibt
        /// </summary>
        private void SetupFieldNames()
        {
            colDatum.FieldName = DBO.FaDokumente.DatumErstellung;
            colThemen.FieldName = COL_FATHEMACODESTEXT;

            colStichworte.FieldName = DBO.FaDokumente.Stichwort;
            colAbsender.FieldName = COL_ABSENDERNAME;
            colAdressat.FieldName = COL_ADRESSATNAME;

            colDienst.FieldName = DBO.FaDokumente.VmErbDienstCode;
            colDienst.ColumnEdit = grdDokumente.GetLOVLookUpEdit(LOVNAME_DIENST);

            colIsDeleted.FieldName = DBO.FaDokumente.IsDeleted;
        }

        /// <summary>
        /// Setup für das logische Löschen.
        /// </summary>
        private void SetupLogischesLoeschen()
        {
            GridView = gvwDokumente;
            radGrpDeleted.Top = chkThemenFilter.Top;
            SetupRadioGroup();
        }

        /// <summary>
        /// Tag benutzen um ein klaren Text anzuzeigen für die Mussfelder.
        /// </summary>
        private void SetupTags()
        {
            edtDatumErstellung.Tag = lblDatumErstellung.Text;
            edtAdressat.Tag = lblAdressat.Text;
            edtAbsender.Tag = lblAbsender.Text;
            edtErbDienst.Tag = lblErbDienst.Text;
            edtDauer.Tag = lblDauer.Text;
            edtThema.Tag = lblThema.Text;
            edtStichwort.Tag = lblStichwort.Text;
            edtFaDokKorreDokument.Tag = lblFaDokKorreDokument.Text;
            memBemerkung.Tag = lblBemerkung.Text;
            edtThemen.Tag = lblThemen.Text;
        }

        /// <summary>
        ///  Setzt die Sichtbarkeit von Controls anhand des ProzessCodes.
        /// </summary>
        /// <param name="prozessCode">Prozesscode</param>
        private void SetVisibility(int prozessCode)
        {
            //Die Sichtbarkeit muss nur für die Editcontrols gesetz werden.
            //Die Labels übernehmen die Sichtbarkeit  in der Methode RePositionGUIElements.
            //Die Prozesscodes bedeuten:
            //PC_FALLFUEHRUNG, 200: Fallführung/Dokumentation/Korrespondenz
            //PC_VM_VORMUNDSCHTL_MASSNAHME, 501: Vormundschaftliche Massnahme/Behördenseketariat/Dokumentation/Korrespondenz
            //PC_VM_ERBSCHAFT, 503: Erbschaftsamt/Dokumentation/Korrespondenz
            //PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG, 505: Auftrag Jugendamt/Adoption/Korrespondenz
            //PC_VM_VATERSCHAFTSABKLAERUNG: 502: Vaterschaftsabklärung / Dokumente Vaterschaft

            //Datum
            edtDatumErstellung.Visible = (
                prozessCode == PC_FALLFUEHRUNG ||
                prozessCode == PC_VM_VORMUNDSCHTL_MASSNAHME ||
                prozessCode == PC_VM_ERBSCHAFT ||
                prozessCode == PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG ||
                prozessCode == PC_VM_VATERSCHAFTSABKLAERUNG
            );

            lblDatumErstellung.Visible = edtDatumErstellung.Visible;

            //Bericht
            edtBericht.Visible = (prozessCode == PC_FALLFUEHRUNG ||
                prozessCode == PC_VM_VORMUNDSCHTL_MASSNAHME ||
                prozessCode == PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG);

            //Adressat
            edtAdressat.Visible = (prozessCode == PC_FALLFUEHRUNG ||
                prozessCode == PC_VM_VORMUNDSCHTL_MASSNAHME ||
                prozessCode == PC_VM_ERBSCHAFT ||
                prozessCode == PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG ||
                prozessCode == PC_VM_VATERSCHAFTSABKLAERUNG);
            lblAdressat.Visible = edtAdressat.Visible;
            colAdressat.Visible = edtAdressat.Visible;

            //Dienst
            edtErbDienst.Visible = (prozessCode == PC_VM_ERBSCHAFT);
            lblErbDienst.Visible = edtErbDienst.Visible;
            colDienst.Visible = edtErbDienst.Visible;

            //Dauer
            edtDauer.Visible = (prozessCode == PC_FALLFUEHRUNG ||
                prozessCode == PC_VM_VORMUNDSCHTL_MASSNAHME ||
                prozessCode == PC_VM_ERBSCHAFT ||
                prozessCode == PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG);
            lblDauer.Visible = edtDauer.Visible;

            //Thema
            //TODO Thema ist obsolete -> Themen.
            edtThema.Visible = false;
            lblThema.Visible = false;

            //Stichworte
            edtStichwort.Visible = (prozessCode == PC_FALLFUEHRUNG ||
                                    prozessCode == PC_VM_VORMUNDSCHTL_MASSNAHME ||
                                    prozessCode == PC_VM_ERBSCHAFT ||
                                    prozessCode == PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG ||
                                    prozessCode == PC_VM_VATERSCHAFTSABKLAERUNG);
            lblStichwort.Visible = edtStichwort.Visible;

            //Dokument
            edtFaDokKorreDokument.Visible = (prozessCode == PC_FALLFUEHRUNG ||
                prozessCode == PC_VM_VORMUNDSCHTL_MASSNAHME ||
                prozessCode == PC_VM_ERBSCHAFT ||
                prozessCode == PC_VM_VORMUNDSCHAFTLICHER_AUFTRAG ||
                prozessCode == PC_VM_VATERSCHAFTSABKLAERUNG);
            lblFaDokKorreDokument.Visible = edtFaDokKorreDokument.Visible;

            //Handlung / Bemerkung
            memBemerkung.Visible = false;
            lblBemerkung.Visible = memBemerkung.Visible;

            //Merkblatt
            edtDocMerkblaetter.Visible = (prozessCode == PC_VM_VATERSCHAFTSABKLAERUNG);
            lblMerkblaetter.Visible = edtDocMerkblaetter.Visible;

            //Themen nicht sichtbar bei Erbschaft.
            if (prozessCode == PC_VM_ERBSCHAFT)
            {
                edtThemen.Visible = false;
                lblThemen.Visible = false;

                chkThemenFilter.Visible = false;
                chkThemenFilter.Checked = false;
                lookupThemen.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}