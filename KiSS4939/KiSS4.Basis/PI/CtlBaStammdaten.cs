using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Basis.PI
{
    /// <summary>
    /// Control, used for accessing and managing root data of persons.
    /// Class is used in several modes and for accessing history-data, too.
    /// </summary>
    public partial class CtlBaStammdaten : KissUserControl
    {
        #region Fields

        #region Private Fields

        public const string SPEZIALRECHT_DEBITORNRBEARBEITEN = "CtlBaStammdaten_DebitorNrBearbeiten";
        private int _baPersonID = -1;
        private CtlBaPersonAdresse _ctlBaPersonAdresse;
        private CtlBaZahlungsweg _ctlBaZahlungsweg;
        private bool _hasHeimatGemeindeChanged;
        private bool _isColumnChanging;
        private bool _isCtlPersonenStammMode;
        private bool _isZeigeDetailsEditValueChanging;
        private int _mainBaPersonID = -1;
        private bool _needRefreshTree;
        private int _verID = -1;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBaStammdaten"/> class.
        /// </summary>
        public CtlBaStammdaten()
        {
            InitializeComponent();

            _ctlBaPersonAdresse.IsWohnstatusVisible = false;
            Common.PI.BaUtils.ApplyLOVBaLand(edtNationalitaetCode);
            picWichtigerHinweis.Image = KissImageList.GetSmallImage(84);
            InitRelationQueries();

            // init default values
            chkZeigeDetails.Checked = true;
            Init(null, null, -1, -1);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get instance of the query containing the main data
        /// </summary>
        public SqlQuery GetQuery
        {
            get { return qryBaPerson; }
        }

        #endregion

        #region EventHandlers

        private void _ctlBaPersonAdresse_AfterDelete(CtlBaPersonAdresse.AddressType addressType)
        {
            AddressHandlingColorFields(addressType);
        }

        private void _ctlBaPersonAdresse_AfterInsert(CtlBaPersonAdresse.AddressType addressType)
        {
            AddressHandlingColorFields(addressType);
        }

        private void _ctlBaPersonAdresse_PositionChanged(CtlBaPersonAdresse.AddressType addressType)
        {
            AddressHandlingColorFields(addressType);
        }

        private void btnIVBerechtigungBearbeiten_Click(object sender, EventArgs e)
        {
            if (!qryBaPerson.CanUpdate || !btnIVBerechtigungBearbeiten.Enabled)
            {
                KissMsg.ShowInfo(Name, "NoRightsToAlterIVBerechtigung", "Sie besitzen keine Rechte für diese Funktionalität.");
                return;
            }

            // check if person has already an id
            if (_baPersonID < 1)
            {
                KissMsg.ShowInfo(Name, "NoIDToAlterIVBerechtigung", "Die aktuelle Person hat keine ID, speichern Sie die Daten zuerst.");
                return;
            }

            // create and show dialog where user can alter data (parameters: current selected "BaPersonID")
            try
            {
                var dlg = new DlgBaIVBerechtigung();
                dlg.Init(_baPersonID,
                    Convert.ToString(qryBaPerson["Name"]),
                    Convert.ToString(qryBaPerson["Vorname"]));

                dlg.ShowDialog(this);

                // retrieve new BaIVBerechtigungCode
                qryBaPerson["IVBerechtigungAktuellerStatusCode"] = dlg.GetCurrentIVBerechtigungCode();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorShowingDialogIVBerechtigung", "Es ist ein Fehler im Bearbeiten der IV-Berechtigung aufgetreten.", ex);
            }
        }

        private void btnKZSAdd_Click(object sender, EventArgs e)
        {
            if (!qryBaPerson.CanUpdate)
            {
                return;
            }

            // validate first
            if (!btnKZSAdd.Enabled ||
                _baPersonID < 1 ||
                grdKZSVerfuegbar.DataSource == null ||
                ((SqlQuery)grdKZSVerfuegbar.DataSource).Count < 1)
            {
                return;
            }

            // get all rows the user selected
            int[] rowHandles = grdKZSVerfuegbar.View.GetSelectedRows();
            if (rowHandles == null)
            {
                return;
            }

            // insert all rows the user selected
            foreach (int rowHandle in rowHandles)
            {
                // get current id
                int baKantonalerZuschussID = Convert.ToInt32(grvKZSVerfuegbar.GetRowCellValue(rowHandle, grvKZSVerfuegbar.Columns["BaKantonalerZuschussID"]));
                KZSHandler.Create(_baPersonID, baKantonalerZuschussID);
            }

            DisplayKzsData();

            edtKZSFilter.EditValue = null;
            edtKZSFilter.Focus();
        }

        private void btnKZSRemove_Click(object sender, EventArgs e)
        {
            if (!qryBaPerson.CanUpdate)
            {
                return;
            }

            // validate first
            if (!btnKZSRemove.Enabled ||
                _baPersonID < 1 ||
                grdKZSZugeteilt.DataSource == null ||
                ((SqlQuery)grdKZSZugeteilt.DataSource).Count < 1)
            {
                return;
            }

            // get all rows the user selected
            int[] rowHandles = grdKZSZugeteilt.View.GetSelectedRows();
            if (rowHandles == null)
            {
                return;
            }

            // delete all rows the user selected
            foreach (int rowHandle in rowHandles)
            {
                // get current id
                int baKantonalerZuschussID = Convert.ToInt32(grvKZSZugeteilt.GetRowCellValue(rowHandle, grvKZSZugeteilt.Columns["BaKantonalerZuschussID"]));

                // remove
                KZSHandler.Delete(_baPersonID, baKantonalerZuschussID);
            }

            DisplayKzsData();
        }

        private void chkHELBKeinAntrag_CheckedChanged(object sender, EventArgs e)
        {
            HandleHelbKeinAntrag();
        }

        private void chkInCHSeitGeburt_EditValueChanged(object sender, EventArgs e)
        {
            SetupForeignerMode();
        }

        private void chkKurzManuelleAnrede_CheckedChanged(object sender, EventArgs e)
        {
            HandleKurzManuelleAnrede();
        }

        private void chkKurzPostfachOhneNr_CheckedChanged(object sender, EventArgs e)
        {
            UtilsGui.TogglePostfachOhneNrEdit(chkKurzPostfachOhneNr, edtKurzAdressePostfach, qryBaPerson.CanUpdate);
        }

        private void chkPersonManuelleAnrede_CheckedChanged(object sender, EventArgs e)
        {
            HandlePersonManuelleAnrede();
        }

        private void chkZeigeDetails_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool zeigeDetails = Convert.ToBoolean(chkZeigeDetails.Checked);

                // check if need to show values always
                if (_isCtlPersonenStammMode && !DBUtil.IsEmpty(qryBaPerson["ZeigeDetails"]))
                {
                    zeigeDetails = true;
                }

                // select tab page depending on value
                TabPageEx tabToSelect = zeigeDetails ? tpgPersonalien : tpgKurz;
                tabStammdaten.SelectTab(tabToSelect);

                // check if tab page could be selected (or post failed in selectedtabchanging)
                if (tabStammdaten.IsTabSelected(tabToSelect))
                {
                    tpgPersonalien.HideTab = !zeigeDetails;
                    tpgAdresse.HideTab = !zeigeDetails;
                    tpgKontaktBankPost.HideTab = !zeigeDetails;
                    tpgSozialversicherung.HideTab = !zeigeDetails;
                    tpgRechnungsadressen.HideTab = !zeigeDetails;
                    tpgKurz.HideTab = zeigeDetails;

                    tabStammdaten.SelectTab(tabToSelect);
                }

                // set value (only if not PersonenStamm)
                if (!_isCtlPersonenStammMode)
                {
                    // apply value only if not PersonenStamm (otherwise RowModified = true and display settings will be changed anyway)
                    chkZeigeDetails.Checked = tpgKurz.HideTab;
                    qryBaPerson["ZeigeDetails"] = chkZeigeDetails.Checked;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "FailedDetailChanged_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
        }

        private void chkZeigeDetails_EditValueChanging(object sender, ChangingEventArgs e)
        {
            try
            {
                if (_isZeigeDetailsEditValueChanging)
                {
                    return;
                }

                _isZeigeDetailsEditValueChanging = true;

                // HACK: prevent stackoverflow for non-client-persons in PersonenStamm...
                if (!_isCtlPersonenStammMode)
                {
                    // save changes first!
                    e.Cancel = !OnSaveData();
                }
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.ERROR, "Error switching details (chkZeigeDetails_EditValueChanging)", ex.Message);
                KissMsg.ShowError(Name, "FailedDetailChanging", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);

                e.Cancel = true;
            }
            finally
            {
                _isZeigeDetailsEditValueChanging = false;
            }
        }

        private void CtlBaStammdaten_Load(object sender, EventArgs e)
        {
            _needRefreshTree = false;
        }

        private void Edit_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var edit = (BaseEdit)sender;
            SqlQuery qry = ((IKissBindableEdit)sender).DataSource;

            string praefix;
            string baLandIDCol;
            string ortschaftCodeCol;

            if (sender == edtKurzAdressePLZ || sender == edtKurzAdresseOrt)
            {
                praefix = "";
                baLandIDCol = DBO.BaAdresse.BaLandID;
                ortschaftCodeCol = DBO.BaAdresse.OrtschaftCode;
            }
            else if ((sender == edtRechnungsadressePLZ) || (sender == edtRechnungsadresseOrt))
            {
                praefix = "Adresse";
                baLandIDCol = "LandCode";
                ortschaftCodeCol = "OrtCode";
            }
            else
            {
                // error, do not continue
                return;
            }

            if (!Utils.isSchweiz(qry[praefix + baLandIDCol]))
            {
                qry[((IKissBindableEdit)sender).DataMember] = edit.Text;
                return;
            }

            if (DBUtil.IsEmpty(edit.Text))
            {
                qry[praefix + DBO.BaAdresse.Ort] = DBNull.Value;
                qry[praefix + ortschaftCodeCol] = DBNull.Value;
                qry[praefix + DBO.BaAdresse.PLZ] = DBNull.Value;
                qry[praefix + DBO.BaAdresse.Bezirk] = DBNull.Value;
                qry[praefix + DBO.BaAdresse.Kanton] = DBNull.Value;

                qry.RefreshDisplay();
                return;
            }

            var dlg = new DlgAuswahl();

            if (edit.Name.IndexOf(DBO.BaAdresse.PLZ) != -1)
            {
                e.Cancel = !dlg.PLZSearch(edit.Text);
            }
            else
            {
                e.Cancel = !dlg.OrtSearch(edit.Text);
            }

            if (!e.Cancel)
            {
                qry[praefix + DBO.BaAdresse.Ort] = dlg["Text"];
                qry[praefix + ortschaftCodeCol] = dlg["Code"];
                qry[praefix + DBO.BaAdresse.PLZ] = dlg["Value1"];
                qry[praefix + DBO.BaAdresse.Bezirk] = dlg["Value3"];
                qry[praefix + DBO.BaAdresse.Kanton] = dlg["Value2"];

                _isColumnChanging = true;

                qry[praefix + baLandIDCol] = Session.BaLandCodeSchweiz; // Schweiz

                _isColumnChanging = false;
            }
        }

        private void edtGeburtsdatum_EditValueChanged(object sender, EventArgs e)
        {
            // need to refresh tree
            _needRefreshTree = true;

            HandlePersonManuelleAnrede();
        }

        private void edtGeschlechtCode_EditValueChanged(object sender, EventArgs e)
        {
            HandlePersonManuelleAnrede();
        }

        private void edtHauptBehinderungsartCode_EditValueChanged(object sender, EventArgs e)
        {
            // check if user is allowed to change data
            if (!qryBaPerson.CanUpdate)
            {
                return;
            }

            // request value for BSVBehinderungsart
            int bsvBehinderungsartCode = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                DECLARE @Value INT;

                SELECT TOP 1 @Value = LOV.Value1
                FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
                WHERE LOV.LOVName = 'BaBehinderungsart'
                  AND LOV.Code = {0};

                SELECT ISNULL(@Value, -1);", edtHauptBehinderungsartCode.EditValue));

            // apply value
            edtBSVBehinderungsartCode.EditValue = bsvBehinderungsartCode;
        }

        private void edtHeimatGemeinde_EditValueChanged(object sender, EventArgs e)
        {
            // data has changed
            _hasHeimatGemeindeChanged = true;
        }

        private void edtHeimatGemeinde_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogHeimatGemeinde(e);
        }

        private void edtKurzAdresseOrt_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            Edit_UserModifiedFld(sender, e);
        }

        private void edtKurzAdressePLZ_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            Edit_UserModifiedFld(sender, e);
        }

        private void edtKurzGeburtsdatum_EditValueChanged(object sender, EventArgs e)
        {
            HandleKurzManuelleAnrede();
        }

        private void edtKurzGeschlechtCode_EditValueChanged(object sender, EventArgs e)
        {
            HandleKurzManuelleAnrede();
        }

        private void edtKurzSterbedatum_EditValueChanged(object sender, EventArgs e)
        {
            HandleKurzManuelleAnrede();
        }

        private void edtKZSFilter_EditValueChanged(object sender, EventArgs e)
        {
            // check if we have a query set
            if (grdKZSVerfuegbar.DataSource == null)
            {
                return;
            }

            // apply filter
            ((SqlQuery)grdKZSVerfuegbar.DataSource).DataTable.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", colKZSVerfBaKantonalerZuschussBezeichnung.FieldName, edtKZSFilter.EditValue);
        }

        private void edtName_EditValueChanged(object sender, EventArgs e)
        {
            _needRefreshTree = true;
        }

        private void edtNationalitaetCode_EditValueChanged(object sender, EventArgs e)
        {
            SetupForeignerMode();
        }

        private void edtRechnungsadresseOrt_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            Edit_UserModifiedFld(sender, e);
        }

        private void edtRechnungsadressePLZ_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            Edit_UserModifiedFld(sender, e);
        }

        private void edtSterbedatum_EditValueChanged(object sender, EventArgs e)
        {
            HandlePersonManuelleAnrede();
        }

        private void edtVorname_EditValueChanged(object sender, EventArgs e)
        {
            _needRefreshTree = true;
        }

        private void edtWichtigerHinweis_EditValueChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtWichtigerHinweis.EditValue))
            {
                edtWichtigerHinweis.Width = memBemerkungenPersonalien.Width;
                picWichtigerHinweis.Visible = false;
            }
            else
            {
                edtWichtigerHinweis.Width = memBemerkungenPersonalien.Width - 23;
                picWichtigerHinweis.Visible = true;
            }
        }

        private void qryBaAdresseBezugsperson_AfterFill(object sender, EventArgs e)
        {
            InsertNewEntryAddresseBezugspersonIfAllowed();
        }

        private void qryBaAdresseBezugsperson_AfterInsert(object sender, EventArgs e)
        {
            qryBaAdresseBezugsperson[DBO.BaAdresse.BaPersonID] = qryBaPerson[DBO.BaPerson.BaPersonID];
            qryBaAdresseBezugsperson[DBO.BaAdresse.AdresseCode] = 1; // wohnsitz

            qryBaAdresseBezugsperson.SetCreator();
        }

        private void qryBaAdresseBezugsperson_BeforePost(object sender, EventArgs e)
        {
            qryBaAdresseBezugsperson.SetModifierModified();

            DBUtil.NewHistoryVersion();
        }

        private void qryBaPerson_AfterPost(object sender, EventArgs e)
        {
            SetupRelationDropdown(true);
        }

        private void qryBaPerson_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();
        }

        private void qryBaPerson_BeforePost(object sender, EventArgs e)
        {
            ValidateIDs();

            if (chkZeigeDetails.Checked)
            {
                CheckRequiredNotNullField(edtPersonAnrede, lblPersonAnrede.Text);
                CheckRequiredNotNullField(edtPersonBriefanrede, lblPersonBriefanrede.Text);
                DBUtil.CheckNotNullField(edtName, lblNameVorname.Text);
                DBUtil.CheckNotNullField(edtVorname, lblNameVorname.Text);

                if (!edtVersicherungsNr.ValidateVersNr(true, false))
                {
                    edtVersicherungsNr.Focus();
                    throw new KissCancelException();
                }
            }
            else
            {
                // bezugsperson (kurz)
                CheckRequiredNotNullField(edtKurzAnrede, lblKurzAnrede.Text);
                CheckRequiredNotNullField(edtKurzBriefanrede, lblKurzBriefanrede.Text);
                DBUtil.CheckNotNullField(edtKurzName, lblKurzNameVorname.Text);
                DBUtil.CheckNotNullField(edtKurzVorname, lblKurzNameVorname.Text);

                if (!edtKurzVersichertenNummer.ValidateVersNr(true, false))
                {
                    edtKurzVersichertenNummer.Focus();
                    throw new KissCancelException();
                }
            }

            // Geburtsdatum
            if (!DBUtil.IsEmpty(qryBaPerson["Geburtsdatum"]) && Convert.ToDateTime(qryBaPerson["Geburtsdatum"]) > DateTime.Today)
            {
                SetFocusDependingOnMode(edtGeburtsdatum, edtKurzGeburtsdatum);
                throw new KissInfoException(KissMsg.GetMLMessage(Name, "GeburtsdatumInvalidValue", "Das Geburtsdatum liegt in der Zukunft!"));
            }

            // Geburtsdatum within range
            if (!DBUtil.IsEmpty(qryBaPerson["Geburtsdatum"]) && !Common.PI.BaUtils.IsBirthdayDateValid(Convert.ToDateTime(qryBaPerson["Geburtsdatum"])))
            {
                // invalid birthday-date, do cancel, message already shown
                SetFocusDependingOnMode(edtGeburtsdatum, edtKurzGeburtsdatum);
                throw new KissCancelException();
            }

            // Sterbedatum
            if (!DBUtil.IsEmpty(qryBaPerson["Sterbedatum"]) && Convert.ToDateTime(qryBaPerson["Sterbedatum"]) > DateTime.Today)
            {
                SetFocusDependingOnMode(edtSterbedatum, edtKurzSterbedatum);
                throw new KissInfoException(KissMsg.GetMLMessage(Name, "SterbedatumInvalidValue", "Das Sterbedatum liegt in der Zukunft!"));
            }

            // Sterbedatum
            if (!DBUtil.IsEmpty(qryBaPerson["Sterbedatum"]) && !DBUtil.IsEmpty(qryBaPerson["Geburtsdatum"]))
            {
                if (Convert.ToDateTime(qryBaPerson["Sterbedatum"]) <= Convert.ToDateTime(qryBaPerson["Geburtsdatum"]))
                {
                    SetFocusDependingOnMode(edtSterbedatum, edtKurzSterbedatum);
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "InvalidSterbedatum", "Das Sterbedatum muss nach dem Geburtsdatum liegen."));
                }
            }

            // IVGrad
            if (!DBUtil.IsEmpty(qryBaPerson["IVGrad"]))
            {
                int ivGrad = Convert.ToInt32(qryBaPerson["IVGrad"]);

                if (ivGrad < 0 || ivGrad > 100)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "IVGradInvalidValue", "Das Feld 'IV-Grad' verlangt eine Eingabe zwischen 0 und 100!"), edtIVGrad);
                }
            }

            // SWITZERLAND
            if (IsSwitzerlandSelected())
            {
                // is switzerland, remove AuslaenderStatusCode,InCHSeit/Geburt
                qryBaPerson["AuslaenderStatusCode"] = DBNull.Value;
                qryBaPerson["InCHSeit"] = DBNull.Value;
                qryBaPerson["InCHSeitGeburt"] = 0; // bit: default value

                // validate buttonedits
                if (_hasHeimatGemeindeChanged && !DialogHeimatGemeinde(new UserModifiedFldEventArgs(false, false)))
                {
                    edtHeimatGemeinde.Focus();
                    throw new KissCancelException();
                }

                _hasHeimatGemeindeChanged = false;
            }
            else
            {
                // not switzerland, remove Heimatort
                qryBaPerson["HeimatgemeindeName"] = DBNull.Value;
                qryBaPerson["HeimatgemeindeBaGemeindeID"] = DBNull.Value;

                // reset flags
                _hasHeimatGemeindeChanged = false;

                // validate:
                // InCHSeit
                if (!DBUtil.IsEmpty(qryBaPerson["InCHSeitGeburt"]) && Convert.ToBoolean(qryBaPerson["InCHSeitGeburt"]))
                {
                    qryBaPerson["InCHSeit"] = DBNull.Value;
                }

                // InCHSeit
                if (!DBUtil.IsEmpty(qryBaPerson["InCHSeit"]) && !DBUtil.IsEmpty(qryBaPerson["Geburtsdatum"]))
                {
                    if (Convert.ToDateTime(qryBaPerson["InCHSeit"]) <= Convert.ToDateTime(qryBaPerson["Geburtsdatum"]))
                    {
                        // invalid date
                        edtInCHSeit.Focus();
                        throw new KissInfoException(KissMsg.GetMLMessage(Name, "InvalidInSchweizSeit", "Das Datum 'In Schweiz seit' muss nach dem Geburtsdatum liegen."), edtInCHSeit);
                    }
                }

                // InCHSeit
                if (!DBUtil.IsEmpty(qryBaPerson["InCHSeit"]) && !DBUtil.IsEmpty(qryBaPerson["Sterbedatum"]))
                {
                    if (Convert.ToDateTime(qryBaPerson["InCHSeit"]) > Convert.ToDateTime(qryBaPerson["Sterbedatum"]))
                    {
                        // invalid date
                        edtInCHSeit.Focus();
                        throw new KissInfoException(KissMsg.GetMLMessage(Name, "InvalidInSchweizSeitTod", "Das Datum 'In Schweiz seit' muss vor dem Sterbedatum liegen."), edtInCHSeit);
                    }
                }
            }

            // KONTOFUEHRUNG:
            // Kontofuehrung (can only be removed if no KlientenkontoNr)
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1 1
                FROM dbo.BaPerson WITH (READUNCOMMITTED)
                WHERE BaPersonID = ISNULL({0}, -1) AND
                      KlientenkontoNr IS NOT NULL", _baPersonID);

            // check if user has removed KlientenkontoNr (admin could do that)
            if (qry.Count > 0)
            {
                // if the admin has removed the KlientenkontoNr, an error will occure: a KlientenkontoNr cannot be deleted anymore only replaced or entered
                DBUtil.CheckNotNullField(edtPersonKlientenkontoNr, lblPersonKlientenkontoNr.Text);
            }

            bool hasKlientenkontoNr = !DBUtil.IsEmpty(qryBaPerson["KlientenkontoNr"]);

            // check if we have a KlientenkontoNr entered but checkbox not checked
            if ((qry.Count > 0 || hasKlientenkontoNr) && (DBUtil.IsEmpty(qryBaPerson["KontoFuehrung"]) || !Convert.ToBoolean(qryBaPerson["KontoFuehrung"])))
            {
                // set value and inform user
                qryBaPerson["KontoFuehrung"] = true;
                chkKontoFuehrung.EditMode = EditModeType.ReadOnly;
                KissMsg.ShowInfo(Name, "PersonAlreadyHasOrNewKlientenkontoNr", "Dieser Person wurde eine Klientenkonto-Nummer zugewiesen. Der Wert für 'hat Kontoführung' wurde automatisch angepasst.");
            }

            // KlientenkontoNr:
            if (hasKlientenkontoNr)
            {
                // check duplicate KlientenkontoNr (must be unique)
                SqlQuery qryKlientenkontoNr = DBUtil.OpenSQL(@"
                    SELECT TOP 1 1
                    FROM dbo.BaPerson WITH (READUNCOMMITTED)
                    WHERE ISNULL(KlientenkontoNr, -1) = {0} AND
                          BaPersonID <> ISNULL({1}, -1)", qryBaPerson["KlientenkontoNr"], _baPersonID);

                if (qryKlientenkontoNr.Count > 0)
                {
                    edtPersonKlientenkontoNr.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(Name,
                        "KlientenkontoNrBereitsVerwendet",
                        "Diese Klientenkonto-Nr. wird bereits bei einer anderen Person verwendet!",
                        KissMsgCode.MsgInfo));
                }
            }

            // KEIN SERIENBRIEF
            HandleKeinSerienbrief();

            // SAVE PREPARATIONS
            // Modifier/Modified
            qryBaPerson.SetModifierModified();

            // create a new history version
            DBUtil.NewHistoryVersion();
        }

        private void qryBaPerson_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryBaPerson.RowModified = true;

            if (_isColumnChanging)
            {
                return;
            }

            if (e.Column.ColumnName == "BaLandID")
            {
                var qry = (SqlQuery)sender;

                if ((Utils.isSchweiz(e.Row["BaLandID"]) && DBUtil.IsEmpty(e.Row["OrtschaftCode"])) ||
                    (!Utils.isSchweiz(e.Row["BaLandID"]) && !DBUtil.IsEmpty(e.Row["OrtschaftCode"])))
                {
                    e.Row["OrtschaftCode"] = DBNull.Value;
                    e.Row["PLZ"] = DBNull.Value;
                    e.Row["Ort"] = DBNull.Value;
                    e.Row["Kanton"] = DBNull.Value;

                    qry.RefreshDisplay();
                }
            }
        }

        /// <summary>
        /// Eventhandler: Post on datasource completed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void qryBaPerson_PostCompleted(object sender, EventArgs e)
        {
            InsertNewEntryAddresseBezugspersonIfAllowed();

            if (_needRefreshTree)
            {
                _needRefreshTree = false;
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            }

            // refresh person info title (place, age, tel) and icon
            FormController.SendMessage("FrmFall", "Action", "RefreshPersonInfoTitle");
        }

        private void qryPersonRelation_BeforePost(object sender, EventArgs e)
        {
            // validate stored ids
            ValidateIDs();

            if (!DBUtil.IsEmpty(qryPersonRelation["RelationID"]))
            {
                // get relation id and store it in query
                int relationID = Convert.ToInt32(qryPersonRelation["RelationID"]);

                qryPersonRelation["BaRelationID"] = relationID % 100;

                // setup person
                if (relationID >= 1000)
                {
                    // person 1 is main person
                    qryPersonRelation["BaPersonID_1"] = _mainBaPersonID;
                    qryPersonRelation["BaPersonID_2"] = _baPersonID;
                }
                else
                {
                    // person 2 is main person
                    qryPersonRelation["BaPersonID_1"] = _baPersonID;
                    qryPersonRelation["BaPersonID_2"] = _mainBaPersonID;
                }
            }
        }

        private void qryRechnungsadressen_AfterInsert(object sender, EventArgs e)
        {
            // set focus
            edtRechnungsadresseDL.Focus();
        }

        private void qryRechnungsadressen_AfterPost(object sender, EventArgs e)
        {
            qryRechnungsadressen["Dienstleistung"] = edtRechnungsadresseDL.Text;
            qryRechnungsadressen["StrasseNr"] = string.Format("{0} {1}", qryRechnungsadressen["AdresseStrasse"], qryRechnungsadressen["AdresseHausNr"]).Trim();
            qryRechnungsadressen["PLZOrt"] = string.Format("{0} {1}", qryRechnungsadressen["AdressePLZ"], qryRechnungsadressen["AdresseOrt"]).Trim();
        }

        private void qryRechnungsadressen_BeforePost(object sender, EventArgs e)
        {
            // check if we have a valid person id
            if (_baPersonID < 1)
            {
                throw new KissCancelException();
            }

            DBUtil.CheckNotNullField(edtRechnungsadresseDL, lblRechnungsadresseDL.Text);
            DBUtil.CheckNotNullField(edtRechnungsadresseVornameName, lblRechnungsadresseNameVorname.Text);

            // check if we already have a Rechnungsadresse with this Dienstleistung
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(1)
                FROM dbo.BaRechnungsadresse REA WITH (READUNCOMMITTED)
                WHERE REA.BaPersonID = {0} AND
                      REA.DienstleistungCode = {1} AND
                      REA.BaRechnungsadresseID <> ISNULL({2}, -1);",
                _baPersonID,
                qryRechnungsadressen["DienstleistungCode"],
                qryRechnungsadressen["BaRechnungsadresseID"])) > 0)
            {
                // cannot have duplicate Rechnungsadressen with same Dienstleistung
                edtRechnungsadresseDL.Focus();
                KissMsg.ShowInfo(Name, "DuplicateServiceCodeCalcAdr", "Pro Dienstleistung darf nur eine Rechnungsadresse erfasst werden.");
                throw new KissCancelException();
            }

            // setup values (only if not empty)
            if (DBUtil.IsEmpty(qryRechnungsadressen["BaPersonID"]))
            {
                qryRechnungsadressen["BaPersonID"] = _baPersonID;
            }
        }

        private void tabStammdaten_SelectedTabChanged(TabPageEx page)
        {
            // change active sqlquery
            if (tabStammdaten.IsTabSelected(tpgKontaktBankPost))
            {
                ActiveSQLQuery = _ctlBaZahlungsweg.qryBaZahlungsweg;
            }
            else if (tabStammdaten.IsTabSelected(tpgRechnungsadressen))
            {
                ActiveSQLQuery = qryRechnungsadressen;
            }
            else
            {
                ActiveSQLQuery = qryBaPerson;
            }

            // refresh addresses as they might have changed within other tpg
            if (tabStammdaten.IsTabSelected(tpgAdresse))
            {
                _ctlBaPersonAdresse.OnRefreshData();

                // setup foreigner depending fields
                SetupForeignerMode();
            }
            else if (tabStammdaten.IsTabSelected(tpgKurz))
            {
                LoadAndInitAdresseBezugsperson();
            }
        }

        private void tabStammdaten_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (ActiveSQLQuery.CanUpdate)
            {
                e.Cancel = !OnSaveData();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Show and update the KantonalerZuschuss data of the given person
        /// </summary>
        public void DisplayKzsData()
        {
            try
            {
                // reset datasource to ensure empty data
                grdKZSVerfuegbar.DataSource = null;
                grdKZSZugeteilt.DataSource = null;

                // load data
                grdKZSVerfuegbar.DataSource = KZSHandler.RetrieveAvailable(_baPersonID);
                grdKZSZugeteilt.DataSource = KZSHandler.RetrieveAssigned(_baPersonID);

                // reset filter
                edtKZSFilter.EditValue = null;
            }
            catch (ArgumentOutOfRangeException aex)
            {
                // show error only if current BaPersonID != -1 (-1 means init...)
                if (_baPersonID != -1)
                {
                    KissMsg.ShowError(Name, "ErrLoadKZSData", "Es ist ein Fehler beim Laden der Kantonalen Zuschüsse aufgetreten. Die Anzeige ist möglicherweise nicht korrekt.", aex);
                }
            }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ADRESSATID":
                case "BAPERSONID":
                    return qryBaPerson[DBO.BaPerson.BaPersonID];
            }

            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Init control with title panel and no history
        /// </summary>
        /// <param name="titleName">The title to show in title panel</param>
        /// <param name="titleImage">The icon to show in title panel</param>
        /// <param name="baPersonID">The id of the person</param>
        /// <param name="mainBaPersonID">The id of the main person (used for relationship of related persons)</param>
        public void Init(string titleName, Image titleImage, int baPersonID, int mainBaPersonID)
        {
            // by default show panel title and do not use history
            Init(titleName, titleImage, baPersonID, mainBaPersonID, true);
        }

        /// <summary>
        /// Init control with or without title panel and no history
        /// </summary>
        /// <param name="titleName">The title to show in title panel</param>
        /// <param name="titleImage">The icon to show in title panel</param>
        /// <param name="baPersonID">The id of the person</param>
        /// <param name="mainBaPersonID">The id of the main person (used for relationship of related persons)</param>
        /// <param name="showTitlePanel"><c>True</c> if title panel has to be shown, otherwise <c>False</c></param>
        public void Init(string titleName, Image titleImage, int baPersonID, int mainBaPersonID, bool showTitlePanel)
        {
            // by default do not use history
            Init(titleName, titleImage, baPersonID, mainBaPersonID, showTitlePanel, false, -1);
        }

        /// <summary>
        /// Init control with or without title panel and with or without history
        /// </summary>
        /// <param name="titleName">The title to show in title panel</param>
        /// <param name="titleImage">The icon to show in title panel</param>
        /// <param name="baPersonID">The id of the person</param>
        /// <param name="mainBaPersonID">The id of the main person (used for relationship of related persons)</param>
        /// <param name="showTitlePanel"><c>True</c> if title panel has to be shown, otherwise <c>False</c></param>
        /// <param name="useHistory"><c>True</c> if data has to be taken from history with corresponding version id, otherwise <c>False</c></param>
        /// <param name="verID">The id of the history entry if history has to be used</param>
        public void Init(
            string titleName,
            Image titleImage,
            int baPersonID,
            int mainBaPersonID,
            bool showTitlePanel,
            bool useHistory,
            int verID)
        {
            // apply icon (title is not important)
            if (showTitlePanel)
            {
                picTitel.Image = titleImage;
            }

            // apply value
            _isCtlPersonenStammMode = !showTitlePanel;
            _verID = verID;

            // show controls
            panTitel.Visible = !_isCtlPersonenStammMode;
            lblKurzBeziehung.Visible = !_isCtlPersonenStammMode;
            edtKurzBeziehung.Visible = !_isCtlPersonenStammMode;
            chkKurzGleicherHaushalt.Visible = !_isCtlPersonenStammMode;

            // set ids
            _baPersonID = baPersonID;
            _mainBaPersonID = mainBaPersonID;

            // RIGHTS
            // setup flags (insert, update, delete)
            bool canUpdatePersonModifyAdresses = !useHistory && qryBaPerson.CanUpdate;

            qryBaPerson.CanInsert = false;
            qryBaPerson.CanUpdate = canUpdatePersonModifyAdresses;
            qryBaPerson.CanDelete = false;

            qryPersonRelation.CanInsert = false;
            qryPersonRelation.CanUpdate = canUpdatePersonModifyAdresses;
            qryPersonRelation.CanDelete = false;

            qryRechnungsadressen.CanInsert = canUpdatePersonModifyAdresses;
            qryRechnungsadressen.CanUpdate = canUpdatePersonModifyAdresses;
            qryRechnungsadressen.CanDelete = canUpdatePersonModifyAdresses;

            qryBaAdresseBezugsperson.CanInsert = false; // can not insert within this query!
            qryBaAdresseBezugsperson.CanUpdate = canUpdatePersonModifyAdresses;
            qryBaAdresseBezugsperson.CanDelete = false; // can not delete within this query!

            _ctlBaPersonAdresse.SetRights(canUpdatePersonModifyAdresses);

            _ctlBaZahlungsweg.qryBaZahlungsweg.CanInsert = canUpdatePersonModifyAdresses;
            _ctlBaZahlungsweg.qryBaZahlungsweg.CanUpdate = canUpdatePersonModifyAdresses;
            _ctlBaZahlungsweg.qryBaZahlungsweg.CanDelete = canUpdatePersonModifyAdresses;

            // CONTROLS
            // setup buttons and non-bound-controls
            btnIVBerechtigungBearbeiten.Enabled = canUpdatePersonModifyAdresses && DlgBaIVBerechtigung.CanReadData();	// check if user has access to control, too!

            btnKZSAdd.Enabled = canUpdatePersonModifyAdresses;
            btnKZSRemove.Enabled = canUpdatePersonModifyAdresses;
            edtKZSFilter.EditMode = canUpdatePersonModifyAdresses ? edtKZSFilter.EditMode : EditModeType.ReadOnly;		// can only be used if modify is allowed

            //DebitorNr bearbeiten
            edtPersonDebitorNr.EditMode = DBUtil.UserHasRight(SPEZIALRECHT_DEBITORNRBEARBEITEN) ? EditModeType.Normal : EditModeType.ReadOnly;

            // init db-select vars
            string readFromTable = "BaPerson";
            string historyWhere = "";

            // check if need to load history data
            if (useHistory)
            {
                // history view
                readFromTable = "Hist_BaPerson";
                historyWhere = string.Format("AND PRS.VerID = {0}", DBUtil.SqlLiteral(_verID));
            }

            // get data for desired parameters
            qryBaPerson.Fill(string.Format(@"--SQLCHECK_IGNORE--
                SELECT PRS.*,
                       BaPersonIDVISNumber = CONVERT(VARCHAR(255), PRS.BaPersonID) + ' ' + dbo.fnBaGetVISDossierNr(PRS.BaPersonID),
                       HeimatgemeindeName  = GDE.Name + ISNULL(' ' + GDE.Kanton, ''),
                       IVBerechtigungAktuellerStatusCode = dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, NULL, 0)
                FROM dbo.{0} PRS WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
                WHERE PRS.BaPersonID = {1}
                      {2}", readFromTable, DBUtil.SqlLiteral(baPersonID), historyWhere));

            // update fields
            qryBaPerson.EnableBoundFields();
            qryPersonRelation.EnableBoundFields();
            qryRechnungsadressen.EnableBoundFields();
            qryBaAdresseBezugsperson.EnableBoundFields();

            // init per row (also used for CtlPersonenStamm)
            InitPerRow(baPersonID, mainBaPersonID);
        }

        /// <summary>
        /// Init control for every changed person
        /// </summary>
        /// <param name="baPersonID">The id of the person</param>
        /// <param name="mainBaPersonID">The id of the main person (used for relationship of related persons)</param>
        public void InitPerRow(int baPersonID, int mainBaPersonID)
        {
            // INIT:
            // reapply ids
            InitPerRowSetIDs(baPersonID, mainBaPersonID);

            // check if normal mode
            if (!_isCtlPersonenStammMode)
            {
                // check if this person is mainperson
                if (baPersonID == mainBaPersonID)
                {
                    // fallbearbeitung and mainperson
                    chkZeigeDetails.Checked = true;
                }
                else
                {
                    chkZeigeDetails.Checked = !DBUtil.IsEmpty(qryBaPerson["ZeigeDetails"]) && Convert.ToBoolean(qryBaPerson["ZeigeDetails"]);
                }

                // setup editmode
                chkZeigeDetails.EditMode = baPersonID == mainBaPersonID ? EditModeType.ReadOnly : EditModeType.Normal;
            }

            // INIT CONTROLS
            _ctlBaPersonAdresse.BaPersonID = baPersonID;
            _ctlBaZahlungsweg.BaPersonID = baPersonID;

            // KANTONALE ZUSCHUESSE:
            DisplayKzsData();

            // RECHUNGSADRESSEN:
            qryRechnungsadressen.Fill(@"
                SELECT ADR.*,
                       Dienstleistung = dbo.fnGetLOVMLText('BaRechnungsadresseModule', ADR.DienstleistungCode, {1}),
                       StrasseNr = ISNULL(ADR.AdresseStrasse + ' ', '') + ISNULL(ADR.AdresseHausNr, ''),
                       PLZOrt = ISNULL(ADR.AdressePLZ + ' ', '') + ISNULL(ADR.AdresseOrt, '')
                FROM dbo.BaRechnungsadresse ADR WITH (READUNCOMMITTED)
                WHERE ADR.BaPersonID = {0}
                ORDER BY Dienstleistung ASC, PLZOrt ASC;", baPersonID, Session.User.LanguageCode);

            // RELATIONS:
            // check if need to setup relation
            if (!_isCtlPersonenStammMode)
            {
                // Person_Beziehung
                qryPersonRelation.Fill(@"
                    DECLARE @BaPersonID INT
                    DECLARE @BaMainPersonID INT
                    SET @BaPersonID = {0}
                    SET @BaMainPersonID = {1}

                    SELECT BRE.*,
                           PersonID   = PRS.BaPersonID,
                           RelationID = BRL.BaRelationID +
                                          CASE WHEN BRE.BaPersonID_1 = @BaMainPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2) THEN 1000
                                               ELSE 0
                                          END +
                                          CASE PRS.GeschlechtCode WHEN 1 THEN 100
                                                                  WHEN 2 THEN 200
                                                                  ELSE 0
                                          END,
                           PRS.GeschlechtCode,
                           ImGleichenHaushalt = dbo.fnBaGleicheAdresse(@BaMainPersonID, PRS.BaPersonID, 1, NULL), -- compare: wohnsitz addresses
                           BRL.NameRelation
                    FROM dbo.BaPerson_Relation BRE WITH (READUNCOMMITTED)
                      INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID IN (BRE.BaPersonID_1, BRE.BaPersonID_2)
                      LEFT  JOIN dbo.BaRelation BRL WITH (READUNCOMMITTED) ON BRL.BaRelationID = BRE.BaRelationID
                    WHERE (BRE.BaPersonID_1 = @BaMainPersonID OR BRE.BaPersonID_2 = @BaMainPersonID) AND
                          PRS.BaPersonID = @BaPersonID AND
                          @BaPersonID <> @BaMainPersonID
                    ORDER BY RelationID ASC;", baPersonID, mainBaPersonID);

                // init relation dropdown
                SetupRelationDropdown(false);
            }

            // ADDRESS OF RELATEDPERSON
            LoadAndInitAdresseBezugsperson();

            // KONTOFUEHRUNG/KlientenkontoNr:
            // setup hat kontofuehrung
            if (DBUtil.IsEmpty(qryBaPerson["KlientenkontoNr"]))
            {
                // no KlientenkontoNr set, can remove flag if update is enabled
                chkKontoFuehrung.EditMode = qryBaPerson.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                // KlientenkontoNr is already set, cannot remove flag again
                chkKontoFuehrung.EditMode = EditModeType.ReadOnly;
            }

            // setup KlientenkontoNr (admin can alter KlientenkontoNr, others can't)
            edtPersonKlientenkontoNr.EditMode = Session.User.IsUserAdmin && qryBaPerson.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;

            // FINISH
            // setup foreigner depending fields
            SetupForeignerMode();

            // handle > flags and fields
            HandleKeinSerienbrief();
            HandleHelbKeinAntrag();

            // update fields
            qryBaPerson.EnableBoundFields();
            qryPersonRelation.EnableBoundFields();
            qryRechnungsadressen.EnableBoundFields();

            // show specific tab
            chkZeigeDetails_EditValueChanged(this, EventArgs.Empty);

            // check tpg to update anrede
            if (tabStammdaten.IsTabSelected(tpgPersonalien))
            {
                HandlePersonManuelleAnrede();
            }
            else if (tabStammdaten.IsTabSelected(tpgKurz))
            {
                HandleKurzManuelleAnrede();
            }

            _hasHeimatGemeindeChanged = false;
        }

        /// <summary>
        /// Init used control ids for every changed person
        /// </summary>
        /// <param name="baPersonID">The id of the person</param>
        /// <param name="mainBaPersonID">The id of the main person (used for relationship of related persons)</param>
        public void InitPerRowSetIDs(int baPersonID, int mainBaPersonID)
        {
            _baPersonID = baPersonID;
            _mainBaPersonID = mainBaPersonID;
        }

        /// <summary>
        /// Check if the nationality of the person is Switzerland
        /// </summary>
        /// <returns><c>True</c> if nationality of person is Switzerland, otherwise <c>False</c></returns>
        public bool IsSwitzerlandSelected()
        {
            if (!DBUtil.IsEmpty(edtNationalitaetCode.EditValue) &&
                Convert.ToInt32(edtNationalitaetCode.EditValue) != Session.BaLandCodeSchweiz)
            {
                return false;
            }

            return true;
        }

        public override bool OnAddData()
        {
            // if adding on address > focus control to prevent insert-failure message
            if (tabStammdaten.IsTabSelected(tpgAdresse))
            {
                _ctlBaPersonAdresse.Focus();
            }

            return base.OnAddData();
        }

        public override void OnRefreshData()
        {
            // refresh all data-queries (only updatable ones)
            qryBaPerson.Refresh();
            qryRechnungsadressen.Refresh();
            qryBaAdresseBezugsperson.Refresh();
            qryPersonRelation.Refresh();

            // refresh data on other controls
            _ctlBaPersonAdresse.OnRefreshData();
            _ctlBaZahlungsweg.OnRefreshData();

            // refresh Kantonale Zuschüsse
            DisplayKzsData();

            // setup foreigner depending fields
            SetupForeignerMode();
        }

        public override bool OnSaveData()
        {
            // check if need to save data
            if (!ActiveSQLQuery.CanUpdate)
            {
                // do not save pending data to prevent error (but return as success)
                return true;
            }

            // save address on rechnungsadressen
            if (!qryRechnungsadressen.Post())
            {
                return false;
            }

            // save address
            if (tabStammdaten.IsTabSelected(tpgKurz))
            {
                if (!qryBaAdresseBezugsperson.Post())
                {
                    return false;
                }
            }
            else
            {
                // save addresses
                if (!_ctlBaPersonAdresse.OnSaveData())
                {
                    return false;
                }
            }

            // save relation
            if (!qryPersonRelation.Post())
            {
                return false;
            }

            // save zahlwege
            if (!_ctlBaZahlungsweg.OnSaveData())
            {
                return false;
            }

            // finally, save changes on person
            if (!qryBaPerson.Post())
            {
                InsertNewEntryAddresseBezugspersonIfAllowed();
                return false;
            }

            return true;
        }

        public override void OnUndoDataChanges()
        {
            if (tabStammdaten.IsTabSelected(tpgKurz))
            {
                qryBaAdresseBezugsperson.Cancel();
            }

            base.OnUndoDataChanges();
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            var baseResult = base.ReceiveMessage(parameters);
            if (parameters["Tab"] != null)
            {
                switch (parameters["Tab"].ToString())
                {
                    case "tpgSozialversicherung":
                        tabStammdaten.SelectTab(tpgSozialversicherung);
                        break;

                    case "tpgPersonalien":
                        tabStammdaten.SelectTab(tpgPersonalien);
                        break;

                    default:
                        tabStammdaten.SelectTab(tpgPersonalien);
                        break;
                }
            }

            return baseResult;
        }

        /// <summary>
        /// Setup control depending on current person's nationality and states
        /// </summary>
        public void SetupForeignerMode()
        {
            // check if update is allowed
            if (!qryBaPerson.CanUpdate)
            {
                SetupColorRequiredFields();
                return;
            }

            // get current settings
            bool isSwitzerland = IsSwitzerlandSelected();

            //enable/disable fields depending on isCH or not
            edtHeimatGemeinde.EditMode = !isSwitzerland ? EditModeType.ReadOnly : EditModeType.Normal;
            edtAuslaenderStatusCode.EditMode = isSwitzerland ? EditModeType.ReadOnly : EditModeType.Normal;
            edtInCHSeit.EditMode = isSwitzerland ? EditModeType.ReadOnly : EditModeType.Normal;
            chkInCHSeitGeburt.EditMode = isSwitzerland ? EditModeType.ReadOnly : EditModeType.Normal;

            // edtInCHSeit depends on chkInCHSeitGeburt and can only be edited if allowed and chkInCHSeitGeburt is not checked
            edtInCHSeit.EditMode = chkInCHSeitGeburt.Checked ? EditModeType.ReadOnly : edtInCHSeit.EditMode;

            // setup tabstops
            edtHeimatGemeinde.TabStop = edtHeimatGemeinde.EditMode == EditModeType.Normal;
            edtAuslaenderStatusCode.TabStop = edtAuslaenderStatusCode.EditMode == EditModeType.Normal;
            edtInCHSeit.TabStop = edtInCHSeit.EditMode == EditModeType.Normal;
            chkInCHSeitGeburt.TabStop = chkInCHSeitGeburt.EditMode == EditModeType.Normal;

            // setup colors
            SetupColorRequiredFields();
        }

        /// <summary>
        /// Translate the instance and do sorting of LOVs
        /// </summary>
        public override void Translate()
        {
            base.Translate();

            // load bigger LOVs only once
            edtRechnungsadresseLand.LoadQuery((SqlQuery)edtNationalitaetCode.Properties.DataSource);
            edtKurzAdresseLand.LoadQuery((SqlQuery)edtNationalitaetCode.Properties.DataSource);

            // do sorting of LOVs
            edtHauptBehinderungsartCode.SortByFirstColumn();
            edtBehinderungsart2Code.SortByFirstColumn();
            edtNationalitaetCode.SortByFirstColumn();
            edtRechnungsadresseLand.SortByFirstColumn();
            edtKurzAdresseLand.SortByFirstColumn();
        }

        #endregion

        #region Protected Methods

        protected override bool ProcessMnemonic(char charCode)
        {
            // can only use Mnemonic if not details
            if (!chkZeigeDetails.Checked)
            {
                return true;
            }

            return base.ProcessMnemonic(charCode);
        }

        #endregion

        #region Private Static Methods

        private static int? CalculateAge(DateTime? birthDay, DateTime? refDate)
        {
            if (!birthDay.HasValue ||
                birthDay.Value < (DateTime)SqlDateTime.MinValue)
            {
                return null;
            }

            if (!refDate.HasValue ||
                refDate.Value < (DateTime)SqlDateTime.MinValue)
            {
                refDate = DateTime.Today;
            }

            if (birthDay >= refDate)
            {
                return 0;
            }

            return Convert.ToInt32(((refDate.Value - birthDay.Value).Days + 0.5) / 365.25);
        }

        private static void CheckRequiredNotNullField(KissTextEdit edt, string labelText)
        {
            if (edt.EditMode == EditModeType.Required)
            {
                DBUtil.CheckNotNullField(edt, labelText);
            }
        }

        #endregion

        #region Private Methods

        private void AddressHandlingColorFields(CtlBaPersonAdresse.AddressType addressType)
        {
            if (addressType == CtlBaPersonAdresse.AddressType.WohnMeldeAdresse)
            {
                SetupColorRequiredFields();
            }
        }

        private bool DialogHeimatGemeinde(UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (edtHeimatGemeinde.Properties.ReadOnly || !qryBaPerson.CanUpdate || qryBaPerson.Count < 1)
                {
                    return true;
                }

                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edtHeimatGemeinde.EditValue))
                {
                    searchString = edtHeimatGemeinde.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        qryBaPerson["HeimatgemeindeName"] = DBNull.Value;
                        qryBaPerson["HeimatgemeindeBaGemeindeID"] = DBNull.Value;
                        return true;
                    }
                }

                var dlg = new DlgAuswahl();

                // show dialog and check if user selected something
                if (dlg.HeimatortSuchen(searchString, e.ButtonClicked))
                {
                    qryBaPerson["HeimatgemeindeName"] = dlg["Heimatort"];
                    qryBaPerson["HeimatgemeindeBaGemeindeID"] = dlg["Code"];

                    _hasHeimatGemeindeChanged = false;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorIKissUserModified_v01", "Es ist ein Fehler bei der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private int GetBaPersonID()
        {
            int baPersonID = -1;

            if (!qryBaPerson.IsEmpty)
            {
                baPersonID = Convert.ToInt32(qryBaPerson[DBO.BaPerson.BaPersonID]);
            }

            return baPersonID;
        }

        private void HandleHelbKeinAntrag()
        {
            if (!qryBaPerson.CanUpdate)
            {
                return;
            }

            // confirm deleting values (if any defined already)
            if (chkHelbKeinAntrag.Checked &&
                (!DBUtil.IsEmpty(qryBaPerson[edtHelbAnmeldung.DataMember]) ||
                 !DBUtil.IsEmpty(qryBaPerson[edtHelbDatumEntscheid.DataMember]) ||
                 !DBUtil.IsEmpty(qryBaPerson[edtHelpEntscheid.DataMember]) ||
                 !DBUtil.IsEmpty(qryBaPerson[edtHelbAbWann.DataMember])))
            {
                if (KissMsg.ShowQuestion(Name,
                                         "ConfirmClearHELBDataOnNoAntrag_v02",
                                         "Die Option 'Kein Antrag' für HELB ist ausgewählt und es sind noch weitere HELB-Daten vorhanden.\r\n\r\nSollen diese weiteren HELB-Daten nun gelöscht werden, damit die Option 'Kein Antrag' aktiviert werden kann?"))
                {
                    qryBaPerson[edtHelbAnmeldung.DataMember] = DBNull.Value;
                    qryBaPerson[edtHelbDatumEntscheid.DataMember] = DBNull.Value;
                    qryBaPerson[edtHelpEntscheid.DataMember] = DBNull.Value;
                    qryBaPerson[edtHelbAbWann.DataMember] = DBNull.Value;

                    edtHelbAnmeldung.EditValue = null;
                    edtHelbDatumEntscheid.EditValue = null;
                    edtHelpEntscheid.EditValue = null;
                    edtHelbAbWann.EditValue = null;

                    // due to unknown behaviour, the flag gets sometimes lost > reapply value
                    ApplicationFacade.DoEvents();
                    chkHelbKeinAntrag.Checked = true;
                }
                else
                {
                    chkHelbKeinAntrag.Checked = false;
                    return;
                }
            }

            // set editmodes depending on current selection
            var editModeHelb = chkHelbKeinAntrag.Checked ? EditModeType.ReadOnly : EditModeType.Normal;

            edtHelbAnmeldung.EditMode = editModeHelb;
            edtHelbDatumEntscheid.EditMode = editModeHelb;
            edtHelpEntscheid.EditMode = editModeHelb;
            edtHelbAbWann.EditMode = editModeHelb;
        }

        private void HandleKeinSerienbrief()
        {
            if (qryBaPerson.IsEmpty)
            {
                return;
            }

            bool hasMortalDate = !DBUtil.IsEmpty(qryBaPerson[DBO.BaPerson.Sterbedatum]);

            // set flag depending on value and rights
            if (hasMortalDate && qryBaPerson.CanUpdate)
            {
                qryBaPerson[DBO.BaPerson.KeinSerienbrief] = true;
            }
            else if (qryBaPerson.CanUpdate &&
                     qryBaPerson.ColumnModified(DBO.BaPerson.Sterbedatum) &&
                     !hasMortalDate &&
                     Convert.ToBoolean(qryBaPerson[DBO.BaPerson.KeinSerienbrief]))
            {
                // ask to remove flag
                if (KissMsg.ShowQuestion(Name, "ConfirmRemoveKeinSerBrief_v01", "Soll die Person Serienbriefe erhalten?", true))
                {
                    qryBaPerson[DBO.BaPerson.KeinSerienbrief] = false;
                }
            }

            // handle checkboxes: only editable if person has no mortal date
            chkPersonKeinSerienbrief.EditMode = hasMortalDate ? EditModeType.ReadOnly : EditModeType.Normal;
            chkKurzKeinSerienbrief.EditMode = chkPersonKeinSerienbrief.EditMode;
        }

        private void HandleKurzManuelleAnrede()
        {
            int? age = CalculateAge(edtKurzGeburtsdatum.DateTime, edtKurzSterbedatum.DateTime);
            UtilsGui.ToggleManuelleAnredeTextFields(chkKurzManuelleAnrede.Checked, edtKurzAnrede, edtKurzBriefanrede, age, edtKurzGeschlechtCode.EditValue as int?);
        }

        private void HandlePersonManuelleAnrede()
        {
            int? age = CalculateAge(edtGeburtsdatum.DateTime, edtSterbedatum.DateTime);
            UtilsGui.ToggleManuelleAnredeTextFields(chkPersonManuelleAnrede.Checked, edtPersonAnrede, edtPersonBriefanrede, age, edtGeschlechtCode.EditValue as int?);
        }

        private void InitRelationQueries()
        {
            // INIT RELATION QUERIES (SAME CODE AS IN CTLBAKLIENTENSYSTEM!)
            qryRelationGeneric.Fill(@"
                SELECT Code = BaRelationID,
                       Text = dbo.fnGetMLTextByDefault(NameGenerisch1TID, {0}, NameGenerisch1)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 1000,
                       Text = dbo.fnGetMLTextByDefault(NameGenerisch2TID, {0}, NameGenerisch2)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameGenerisch1 <> NameGenerisch2
                ORDER BY [Text];", Session.User.LanguageCode);

            qryRelationMale.Fill(@"
                SELECT Code = BaRelationID + 100,
                       Text = dbo.fnGetMLTextByDefault(NameMaennlich1TID, {0}, NameMaennlich1)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 1000 + 100,
                       Text = dbo.fnGetMLTextByDefault(NameMaennlich2TID, {0}, NameMaennlich2)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameMaennlich1 <> NameMaennlich2
                ORDER BY [Text];", Session.User.LanguageCode);

            qryRelationFemale.Fill(@"
                SELECT Code = BaRelationID + 200,
                       Text = dbo.fnGetMLTextByDefault(NameWeiblich1TID, {0}, NameWeiblich1)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)

                UNION ALL

                SELECT Code = BaRelationID + 1000 + 200,
                       Text = dbo.fnGetMLTextByDefault(NameWeiblich2TID, {0}, NameWeiblich2)
                FROM dbo.BaRelation WITH (READUNCOMMITTED)
                WHERE NameWeiblich1 <> NameWeiblich2
                ORDER BY [Text];", Session.User.LanguageCode);
        }

        private void InsertNewEntryAddresseBezugspersonIfAllowed()
        {
            int baPersonID = GetBaPersonID();

            // check if we have an entry
            if (qryBaAdresseBezugsperson.IsEmpty &&
                qryBaAdresseBezugsperson.CanUpdate &&
                baPersonID > 0)
            {
                qryBaAdresseBezugsperson.Insert(null);
            }
        }

        private void LoadAndInitAdresseBezugsperson()
        {
            int baPersonID = GetBaPersonID();

            // save changes first
            if (!qryBaAdresseBezugsperson.Post())
            {
                KissMsg.ShowError(Name,
                    "FailureSavingChangesBeforeLoadAddress",
                    "Es ist ein Fehler beim Speichern der Adresse der Bezugsperson aufgetreten. Die Adressdaten können nicht neu geladen werden.");
                return;
            }

            // load current address
            qryBaAdresseBezugsperson.Fill(@"
                SELECT BaAdresseID,
                       BaPersonID,
                       BaLandID,
                       DatumVon,
                       DatumBis,
                       Gesperrt,
                       AdresseCode,
                       Zusatz,
                       Strasse,
                       HausNr,
                       Postfach,
                       PostfachOhneNr,
                       PLZ,
                       Ort,
                       OrtschaftCode,
                       Kanton,
                       Bezirk,
                       VerID,
                       Creator,
                       Created,
                       Modifier,
                       Modified,
                       BaAdresseTS
                FROM dbo.BaAdresse
                WHERE BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', {0}, 1, NULL);", baPersonID);

            InsertNewEntryAddresseBezugspersonIfAllowed();
        }

        private void SetFocusDependingOnMode(Control edtDefault, Control edtShort)
        {
            if (chkZeigeDetails.Checked)
            {
                edtDefault.Focus();
            }
            else
            {
                edtShort.Focus();
            }
        }

        private void SetupColorRequiredFields()
        {
            // always required
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtName, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtVorname, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(_ctlBaPersonAdresse.WohnsitzEdtOrt, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(_ctlBaPersonAdresse.WohnsitzEdtLand, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtIVBerechtigungAktuellerStatus, qryBaPerson.CanUpdate, qryBaPerson.CanUpdate);	// do only have color if canupdate is true
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtHauptBehinderungsartCode, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtGeburtsdatum, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtGeschlechtCode, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtNationalitaetCode, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtVersicherungsNr, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtAusbildungCode, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtErwerbssituationCode, qryBaPerson.CanUpdate);
            Common.PI.BaUtils.SetupColorOfRequiredFields(edtRentenstufe, qryBaPerson.CanUpdate);
        }

        private void SetupRelationDropdown(bool forceReload)
        {
            // check if need to save data and reload values
            if (forceReload)
            {
                qryPersonRelation.Refresh();
            }

            // get gender of current person
            object geschlechtCode = qryPersonRelation["GeschlechtCode"];

            // gender depending dropdown values
            if (geschlechtCode is int && Convert.ToInt32(geschlechtCode) == 1)
            {
                edtKurzBeziehung.LoadQuery(qryRelationMale);
            }
            else if (geschlechtCode is int && Convert.ToInt32(geschlechtCode) == 2)
            {
                edtKurzBeziehung.LoadQuery(qryRelationFemale);
            }
            else
            {
                edtKurzBeziehung.LoadQuery(qryRelationGeneric);
            }
        }

        private void ValidateIDs()
        {
            if (_baPersonID < 1 || _mainBaPersonID < 1)
            {
                throw new KissErrorException("Programming error - invalid member value for _baPersonID or _mainBaPersonID, cannot continue!");
            }
        }

        #endregion

        #endregion
    }
}