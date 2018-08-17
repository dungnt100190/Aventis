using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.DTA_EZAG;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Control, used for searching Zahlungslauf of KliBu
    /// </summary>
    public partial class CtlKbZahlungslauf : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string KEYPATH_GRUPPE_ZAHLUNGSKONTO_EINSCHRAENKEN = @"System\KliBu\ZahlungslaufGruppeUndZahlungskontoEinschraenken";
        private const string XRIGHT_ALLE_GRUPPEN_AUSWAEHLBAR = "CtlKbZahlungslauf_AlleGruppenAuswaehlbar";

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private string _aktivKonto;
        private int _aktivKontoId;
        private bool _hasGruppenSpezialrecht;
        private bool _isGruppeUndZahlungskontoEingeschraenkt;
        private int _kbPeriodeID;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlKbZahlungslauf"/> class.
        /// </summary>
        public CtlKbZahlungslauf()
        {
            InitializeComponent();
        }

        private void SetupGrid()
        {
            if (GuiConfig.Theme == GuiConfig.KissTheme.KissBlue)
            {
                grdZahllauf.GridStyle = GridStyleType.Editable;

                grdZahllauf.SetSelectionColor(false);

                grdZahllauf.SetColumnEditable(colBuchungID, false);
                grdZahllauf.SetColumnEditable(colValuta, false);
                grdZahllauf.SetColumnEditable(colTage, false);
                grdZahllauf.SetColumnEditable(colBuchungstext, false);
                grdZahllauf.SetColumnEditable(colBetrag, false);
                grdZahllauf.SetColumnEditable(colKreditor, false);
                grdZahllauf.SetColumnEditable(colStatus, false);
                grdZahllauf.SetColumnEditable(colSelektion, true);
            }
        }

        #endregion Constructors

        #region EventHandlers

        private void btnAlle_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                foreach (DataRow row in qryBuchung.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["Uebermitteln"]))
                    {
                        row["Uebermitteln"] = true;
                    }
                }

                CalculateTotal();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                foreach (DataRow r in qryBuchung.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(r["Uebermitteln"]))
                        r["Uebermitteln"] = false;
                }

                CalculateTotal();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            if (qryBuchung.Count == 0 || DBUtil.IsEmpty(qryBuchung["JumpToMBPfad"]))
            {
                return;
            }

            FormController.OpenForm("FrmFall",
                                    "Action", "JumpToNodeByFieldValue",
                                    "BaPersonID", qryBuchung["FallBaPersonID"],
                                    "ModulID", 5,
                                    "FieldValue", qryBuchung["JumpToMBPfad"]);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            bool reportGenerated = false;

            try
            {
                if (edtFaelligkeitsdatum.EditValue == null)
                {
                    KissMsg.ShowError(Name, "FaelligkeitsDatumNichtSpezifiziert", "Bitte setzen sie ein gültiges Bezahldatum.");

                    edtFaelligkeitsdatum.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                qryBuchung.First();

                DataRow row = qryZahlungskonto.DataTable.Rows[edtKbZahlungskonto.ItemIndex];
                KbZahlungskonto account = new KbZahlungskonto(row);

                qryAktivKonto.Fill(_kbPeriodeID, account.KbZahlungskontoID);

                _aktivKontoId = Utils.ConvertToInt(qryAktivKonto["KbKontoId"]);
                _aktivKonto = Utils.ConvertToString(qryAktivKonto["KontoNr"]);
                System.Diagnostics.Debug.WriteLine("AktivKonto : " + _aktivKonto + " / " + _aktivKontoId.ToString());

                if (_aktivKontoId == 0)
                {
                    KissMsg.ShowError(Name, "AktivKontoNichtSpezifiziert", "Das gewählte Zahlungskonto ist im Kontenplan keinem Konto zugewiesen.");
                    return;
                }

                // --- setze DTA nummer
                qryBuchung["DTAKontoNr"] = account.KontoNr;

                KlibuPaymentManager payment = new KlibuPaymentManager(
                    qryBuchung,
                    account,
                    _aktivKonto,
                    edtFaelligkeitsdatum.DateTime);

                // --- user Feedback: Create EZAG file?
                if (!KissMsg.ShowQuestion(Name, "ZahlungsauftragErzeugen", "Zahlungsauftrag erzeugen?"))
                {
                    System.Diagnostics.Debug.WriteLine("User aborted file creation");
                    return;
                }

                // FileInfo holen
                FileInfo fileInfo;
                string directory;
                var hasFileInfoOrDirectory = payment.GetFileInfo(out fileInfo, out directory);

                if (hasFileInfoOrDirectory)
                {
                    // --- Start the transaction.
                    Session.BeginTransaction();

                    try
                    {
                        payment.CreateOrders();
                        reportGenerated = payment.CreateFiles(null, edtSucheValutaBis.DateTime, null, fileInfo, directory);

                        Session.Commit();
                    }
                    catch (Exception exc)
                    {
                        Session.Rollback();
                        KissMsg.ShowInfo(exc.Message);
                    }
                }

                var errors = payment.GetErrors();
                foreach (int belegNr in errors.Keys)
                {
                    AktualisiereBuchungsStatus(belegNr, 5, errors[belegNr]);
                }
            }
            catch (PaymentFatalException ex)
            {
                ShowGenerationResult(reportGenerated, ex);
                System.Diagnostics.Debug.WriteLine("catch PaymentFatalException");

                if (ex.BelegNummer != 0)
                {
                    System.Diagnostics.Debug.WriteLine("Markiere Buchung mit Belegnummer " + ex.BelegNummer.ToString() + " als fehlerhaft");
                    AktualisiereBuchungsStatus(ex.BelegNummer, 5, ex.Message); // markiere Buchung mit dieser BelegNummer als "Zahlauftrag fehlerhaft"
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                ShowGenerationResult(reportGenerated, ex);
            }
            finally
            {
                qryBuchung.Refresh();
                Cursor = Cursors.Default;
                grdZahllauf.Focus();
            }
        }

        private void CtlKbZahlungslauf_Load(object sender, EventArgs e)
        {
            try
            {
                _kbPeriodeID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false,
                                                                              "Action", "KbPeriodeID"));
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(Name,
                                  "CouldNotGetKbPeriodeID",
                                  "Es ist ein Fehler in der Verarbeitung aufgetreten. Die KbPeriodeID konnte nicht ausgelesen werden.",
                                  ex);

                // reset id
                _kbPeriodeID = -1;

                // logging
                XLog.Create(GetType().FullName, LogLevel.ERROR, "Could not get KbPeriodeID!", ex.Message);
            }

            edtPeriodeID.Text = _kbPeriodeID.ToString();

            _isGruppeUndZahlungskontoEingeschraenkt = DBUtil.GetConfigBool(KEYPATH_GRUPPE_ZAHLUNGSKONTO_EINSCHRAENKEN, false);
            _hasGruppenSpezialrecht = DBUtil.UserHasRight(XRIGHT_ALLE_GRUPPEN_AUSWAEHLBAR);

            // ----
            edtFaelligkeitsdatum.EditValue = DateTime.Today.AddDays(1);

            // --- drop-downbox für Suche in Gruppe befüllen
            qryGruppe.Fill(_isGruppeUndZahlungskontoEingeschraenkt, _hasGruppenSpezialrecht, Session.User.UserID);
            edtGruppeX.LoadQuery(qryGruppe);
            edtGruppeX.ItemIndex = 0;

            //Wenn Gruppe eingeschränkt ist und Benutzer kein Spezialrecht hat, ist Control ReadOnly
            if (_isGruppeUndZahlungskontoEingeschraenkt && !_hasGruppenSpezialrecht)
            {
                edtGruppeX.EditMode = EditModeType.ReadOnly;
            }

            // --- drop-downbox für Zahlungskonto füllen
            UpdateEdtKbZahlungskonto(_kbPeriodeID, _isGruppeUndZahlungskontoEingeschraenkt, edtGruppeX.EditValue as int?);

            // --- Buchungsstatus laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL(@"
                SELECT Text,
                       Code,
                       Value1
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'KbBuchungsStatus'
                ORDER BY SortKey");

            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    Convert.ToInt32(row["Code"]),
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            SetupGrid();

            grvZahllauf.CellValueChanging += grvZahllauf_CellValueChanging;
            grvZahllauf.CustomRowCellEdit += grvZahllauf_CustomRowCellEdit;

            NewSearch();
        }

        private void edtGruppeX_EditValueChanged(object sender, EventArgs e)
        {
            //Wenn Konfig-Wert 'System\KliBu\ZahlungslaufGruppeUndZahlungskontoEinschraenken' true enthält,
            //muss edtKbZahlungskonto anhand der aktuell ausgewählten Gruppe/OrgUnit eingeschränkt werden

            UpdateEdtKbZahlungskonto(_kbPeriodeID, _isGruppeUndZahlungskontoEingeschraenkt, edtGruppeX.EditValue as int?);
        }

        private void grdZahllauf_Click(object sender, EventArgs e)
        {
            qryBuchung.EndCurrentEdit();
            CalculateTotal();
        }

        private void grvZahllauf_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colSelektion)
            {
                return;
            }

            grvZahllauf.SetRowCellValue(e.RowHandle, colSelektion, e.Value);
            CalculateTotal();
        }

        private void grvZahllauf_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSelektion)
            {
                if (DBUtil.IsEmpty(grvZahllauf.GetRowCellValue(e.RowHandle, e.Column)))
                {
                    e.RepositoryItem = repositoryItemTextEdit1;
                }
                else
                {
                    e.RepositoryItem = repositoryItemCheckEdit1;
                }
            }
        }

        private void qryBuchung_AfterFill(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void qryBuchung_PositionChanged(object sender, EventArgs e)
        {
            //btnMonatsbudget.Enabled = !DBUtil.IsEmpty(qryBuchung["JumpToMBPfad"]);
            //qryKgDokumente.Fill(qryBuchung["KgPositionID"]);
        }

        #endregion EventHandlers

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            // --- setze default datum für die suche.
            DateTime d = DateTime.Today.AddDays(2); //heute + 2 Tage

            if (Convert.ToInt32(d.DayOfWeek) == 6)
            {
                // --- Samstag -> Montag
                d = d.AddDays(2);
            }

            if (Convert.ToInt32(d.DayOfWeek) == 0)
            {
                // --- Sonntag -> Montag
                d = d.AddDays(1);
            }

            edtSucheValutaBis.EditValue = d;
            edtPeriodeID.Text = _kbPeriodeID.ToString();

            edtGruppeX.ItemIndex = 0;
            edtKbZahlungskonto.EditMode = EditModeType.Normal;
        }

        protected override void RunSearch()
        {
            kissSearch.SelectParameters = new[] { _isGruppeUndZahlungskontoEingeschraenkt, edtKbZahlungskonto.EditValue };

            base.RunSearch();

            if (_isGruppeUndZahlungskontoEingeschraenkt)
            {
                edtKbZahlungskonto.EditMode = EditModeType.ReadOnly;
            }
        }

        #endregion Protected Methods

        #region Private Static Methods

        /// <summary>
        /// Shows the result "Zahlungsauftrag"-generation.
        /// </summary>
        /// <param name="reportGenerated">if set to <c>true</c> [report generated].</param>
        /// <param name="ex">The thrown exception</param>
        private static void ShowGenerationResult(bool reportGenerated, Exception ex)
        {
            if (!reportGenerated)
            {
                KissMsg.ShowError("CtlFibuDTAZahlungsLauf",
                                  "ZahlungsauftragNichtGeneriert",
                                  "Fehler bei der Bearbeitung des Zahlungsauftrags. Der Zahlungsauftrag konnte nicht generiert werden\r\n{0}",
                                  ex.Message, ex, 0, 0, ex.Message);
            }
            else
            {
                KissMsg.ShowError("CtlFibuDTAZahlungsLauf",
                                  "ZahlungsauftragTrotzFehlerGeneriert",
                                  "Fehler bei der Bearbeitung des Zahlungsauftrags. Der Zahlungsauftrag wurde trotzdem generiert.",
                                  ex.Message, ex, 0, 0, ex.Message);
            }
        }

        #endregion Private Static Methods

        #region Private Methods

        private void AktualisiereBuchungsStatus(int belegNr, int buchungStatus, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine("AktualisiereBuchungsStatus (" + belegNr.ToString() + ", " + buchungStatus.ToString() + ")");

            if (errorMessage.Length > 500)
            {
                errorMessage = errorMessage.Substring(0, 500);
            }

            DBUtil.ExecuteScalarSQL(@"
                UPDATE KBB
                SET KBB.KbBuchungStatusCode = {0},
                    KBB.FibuFehlermeldung = {1}
                FROM dbo.KbBuchung KBB
                WHERE KBB.BelegNr = {2}
                  AND KBB.KbPeriodeID = {3}", buchungStatus, errorMessage, belegNr, _kbPeriodeID);
        }

        private void CalculateTotal()
        {
            int count = 0;
            decimal total = 0;

            foreach (DataRow row in qryBuchung.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Uebermitteln"]) && Convert.ToBoolean(row["Uebermitteln"]))
                {
                    count++;
                    total += Utils.ConvertToDecimal(row["Betrag"]);
                }
            }

            edtTotal.EditValue = total;
            edtAnzahl.EditValue = count;

            btnTransfer.Enabled = (count > 0);
        }

        private void UpdateEdtKbZahlungskonto(int kbPeriodeID, bool isGruppeUndZahlungskontoEingeschraenkt, int? orgUnitID)
        {
            qryZahlungskonto.Fill(kbPeriodeID, isGruppeUndZahlungskontoEingeschraenkt, orgUnitID);
            edtKbZahlungskonto.LoadQuery(qryZahlungskonto);
            edtKbZahlungskonto.ItemIndex = 0;
        }

        #endregion Private Methods

        #endregion Methods
    }
}