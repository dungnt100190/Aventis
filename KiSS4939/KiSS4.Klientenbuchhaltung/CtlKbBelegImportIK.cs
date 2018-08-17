using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using DevExpress.XtraGrid.Views.Base;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbBelegImportIK : KissSearchUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string BEARBEITET = "Bearbeitet";
        private const string CLASSNAME = "CtlKbBelegImportIK";
        private const string IST_AUSZAHLUNG = "IstAuszahlung";
        private const string IST_AUSZAHLUNG_ALBV = "IstAuszahlungALBV";
        private readonly string _lblMonat;
        private readonly string _titel;

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private int? _baPersonID;
        private int? _kbFolgeperiodeId;
        private int _kbPeriodeId;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        public CtlKbBelegImportIK()
        {
            InitializeComponent();

            _titel = KissMsg.GetMLMessage(CLASSNAME, "Titel", "Sollstellung");
            _lblMonat = KissMsg.GetMLMessage(CLASSNAME, "lblMonat", "Monat");
        }

        public CtlKbBelegImportIK(int baPersonID)
            : this()
        {
            _baPersonID = baPersonID;
        }

        #endregion Constructors

        #region EventHandlers

        private void btnBelegeImportieren_Click(object sender, EventArgs e)
        {
            // --- get all rows the user selected
            int[] rowHandles = grvListe.GetSelectedRows();

            if (rowHandles == null || (rowHandles.Length == 0))
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineZeilenSelektiertVerbuchen", "Es sind keine Zeilen selektiert, welche verbucht werden können.");
                return;
            }

            if (DBUtil.IsEmpty(edtBuchungsDatum.EditValue) || edtBuchungsDatum.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo(CLASSNAME, "BuchungsdatumDarfNichtLeerSein", "Das Buchungsdatum darf nicht leer bleiben.");
                edtBuchungsDatum.Focus();
                return;
            }

            if (DBUtil.IsEmpty(edtValutaDatum.EditValue) || edtValutaDatum.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo(CLASSNAME, "ValutadatumDartNichtLeerSein", "Das Valutadatum darf nicht leer bleiben.");
                edtValutaDatum.Focus();
                return;
            }

            if (edtSollstellungsDatumX.EditValue.ToString() == "")
            {
                KissMsg.ShowInfo(CLASSNAME, "SollstellungsmonatDarfNichtLeerSein", "Der Sollstellungsmonat darf nicht leer bleiben.");
                edtSollstellungsDatumX.Focus();
                return;
            }

            if (!KliBuUtil.HasValidBelegDatum(_kbPeriodeId, edtBuchungsDatum.EditValue as DateTime?))
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "BuchungsdatumIstUngueltig",
                    "Das Buchungsdatum ist ungültig. Möglicherweise ist die Periode nicht aktiv.",
                    KissMsgCode.MsgInfo);
                edtBuchungsDatum.Focus();
                return;
            }

            var rowData = rowHandles.Select(rowHandle => grvListe.GetDataRow(rowHandle)).ToList();

            // Wenn der Beleg von der Folgeperiode ist und diese Importe abgelehnt wurden dann den Import überspringen
            if (KliBuUtil.CheckImportBelegeOfFollowingPeriod(rowData, _kbPeriodeId, _kbFolgeperiodeId))
            {
                bool created = false;
                int anzahl = 0;
                //TODO? Transaktion sollte wohl eigentlich pro Zeile gemacht werden
                // pro:     weniger lange aufs mal gelocket
                // kontra:  ständig neue Transaktion die lockt
                // fazig:   weiss nicht was besser ist!
                Session.BeginTransaction();
                // hier darf kein Code stehen!
                try
                {
                    string errorText = String.Empty;

                    // --- update all rows the user selected
                    foreach (var row in rowData)
                    {
                        var qry = new SqlQuery();

                        if (!(row[BEARBEITET] as bool? ?? false))
                        {
                            // Forderung + ALBV Auszahlung
                            if (edtSelektionTypX.SelectedIndex == 0)
                            {
                                if (!((bool)row["ErledigterMonat"]))
                                {
                                    qry = DBUtil.OpenSQL(@"
                                        EXEC dbo.spIkSollstellung_KbBuchung_Create {0}, {1}, {2}, {3}, {4}, {5}, {6} ",
                                        Utils.ConvertToInt(row["IkPositionID"]),
                                        ((DateTime)edtBuchungsDatum.EditValue).ToString("yyyyMMdd"),
                                        ((DateTime)edtValutaDatum.EditValue).ToString("yyyyMMdd"),
                                        ((DateTime)edtGeneriertAm.EditValue).ToString("yyyyMMdd"),
                                        edtBuchungsText.Text,
                                        Session.User.UserID,
                                        _kbPeriodeId);

                                    row[BEARBEITET] = true;
                                }
                            }
                            else // ALV Auszahlung
                            {
                                qry = DBUtil.OpenSQL(@"
                                    DECLARE @naechsteBelegNr INT;
                                    EXECUTE @naechsteBelegNr = spKbGetBelegNr {5}, 3, null, 1; -- KbBelegkreis	3 = Belegimport Inkasso

                                    DECLARE @UserID              INT,
                                            @PraefixBuchungstext VARCHAR(200);
                                    SET @UserID = {4};
                                    SELECT @PraefixBuchungstext = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\PraefixBuchungstextAuszahlung', GETDATE())), '');

                                    DECLARE @KbBelegKreisID INT;
                                    SELECT @KbBelegKreisID = KbBelegKreisID
                                    FROM dbo.KbBelegKreis BLK WITH (READUNCOMMITTED)
                                    WHERE KbPeriodeID = {5}
                                      AND KbBelegKreisCode = 3;

                                    UPDATE BUC
                                      SET KbBuchungStatusCode = 13, -- verbucht
                                          BelegNr             = @naechsteBelegNr,
                                          KbBelegKreisID      = @KbBelegKreisID,
                                          BelegDatum          = {1},
                                          ValutaDatum         = {2},
                                          [Text]              = ISNULL(LEFT(@PraefixBuchungstext + ' ' + {3}, 200), [Text]),-- TODO
                                          MutiertUserID       = @UserID,
                                          MutiertDatum        = GETDATE(),
                                          KbPeriodeID         = {5}
                                    FROM dbo.KbBuchung                     BUC
                                      INNER JOIN dbo.KbForderungAuszahlung FAZ WITH (READUNCOMMITTED) ON FAZ.KbBuchungID_Auszahlung = BUC.KbBuchungID
                                    WHERE BUC.IkPositionID = {0}
                                      AND BUC.KbBuchungStatusCode = 2; -- freigegeben

                                    SELECT HasErrors = 0, AnzahlErstellt = @@ROWCOUNT;",
                                    Utils.ConvertToInt(row["IkPositionID"]),
                                    ((DateTime)edtBuchungsDatum.EditValue).ToString("yyyyMMdd"),
                                    ((DateTime)edtValutaDatum.EditValue).ToString("yyyyMMdd"),
                                    edtBuchungsText.Text,
                                    Session.User.UserID,
                                    _kbPeriodeId);

                                row[BEARBEITET] = true;
                            }

                            created = (Utils.ConvertToInt(qry["HasErrors"]) == 0);
                            if (!created)
                            {
                                row[BEARBEITET] = false;
                                errorText = Utils.ConvertToString(qry["ErrorText"]);
                                break;
                            }

                            anzahl += Utils.ConvertToInt(qry["AnzahlErstellt"]);
                        }
                    }

                    if (!created)
                    {
                        throw new KissInfoException(errorText);
                    }

                    Session.Commit();
                    // hier darf kein Code stehen!
                }
                catch (Exception ex)
                {
                    // catch über alle Typen von Exceptions muss immer vorhanden sein!
                    // hier darf kein Code stehen!
                    // Reihenfolge darf hier nicht vertauscht werden!
                    Session.Rollback();
                    KissMsg.ShowError(CLASSNAME, "ErrorInBelegImport", "Die Buchung konnte nicht importiert werden!", ex.InnerException);
                }
                finally
                {
                    if (created)
                    {
                        KissMsg.ShowInfo(CLASSNAME, "AnzahlBuchungenErstellt", "Es wurde(n) {0} Buchung(en) erstellt.", anzahl);
                    }

                    ShowLastAction();
                    SetEditMode();

                    qryKbBuchung.Fill(qryListe["IkPositionID"]);

                    grvListe.SelectRow(qryListe.Position);
                    grvBuchung.SelectRow(qryKbBuchung.Position);
                }
            }
        }

        private void btnMonatszahlen_Click(object sender, EventArgs e)
        {
            String strTotal;
            String msg = String.Empty;

            int intAnzahl = 0;
            int anzErrors = 0;
            int anzSuccess = 0;

            DateTime zeitStart = DateTime.Now;
            DateTime zeitEnde;
            lblProgress.Text = "";

            try
            {
                // entweder wird leistung oder rechtstitel übergeben (falls rechtstitel --> faleistung null)
                SqlQuery qryAll = DBUtil.OpenSQL(@"
                    SELECT FaLeistungID    = CASE
                                               WHEN RTT.IkRechtstitelID IS NULL THEN LST.FaLeistungID
                                               ELSE NULL
                                             END,
                           IkRechtstitelID = RTT.IkRechtstitelID
                    FROM dbo.FaLeistung            LST WITH (READUNCOMMITTED)
                      LEFT  JOIN dbo.IkRechtstitel RTT WITH (READUNCOMMITTED) ON RTT.FaLeistungID = LST.FaLeistungID
                    WHERE LST.ModulID = 4 AND LST.DatumBis IS NULL
                      AND ({0} IS NULL OR LST.BaPersonID = {0}) -- nur einen Fall wenn BaPersonID gegeben ist",
                    _baPersonID);

                strTotal = qryAll.Count.ToString();

                string anzahlVon = KissMsg.GetMLMessage(CLASSNAME, "Von", "{0} von {1}");

                foreach (DataRow row in qryAll.DataTable.Rows)
                {
                    // Progress anzeigen
                    intAnzahl += 1;
                    lblProgress.Text = string.Format(anzahlVon, intAnzahl, strTotal);
                    lblProgress.Refresh();

                    SqlQuery qry = DBUtil.OpenSQL(
                        "EXEC dbo.spIkMonatszahlen_DetailAll {0}, {1}, 1",
                        row["FaLeistungID"],
                        row["IkRechtstitelID"]);

                    if (Utils.ConvertToInt(qry["HasErrors"]) == 1)
                    {
                        anzErrors += 1;
                    }
                    else
                    {
                        anzSuccess += 1;
                    }
                }

                zeitEnde = DateTime.Now;
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                return;
            }

            TimeSpan ts = zeitEnde - zeitStart;
            lblProgress2.Text = ts.ToString();

            if (!String.IsNullOrEmpty(msg))
            {
                KissMsg.ShowInfo(msg);
            }

            KissMsg.ShowInfo(
                CLASSNAME,
                "BerechnungMonatszahlenBeendet",
                "Berechnung der Monatszahlen beendet.\r\n" +
                "{0} Rechtstitel/Leistungen erstellt oder korrigiert.\r\n" +
                "{1} erfolgreich, {2} fehlerhaft.",
                strTotal,
                anzSuccess,
                anzErrors);
        }

        private void btnRueckgaengig_Click(object sender, EventArgs e)
        {
            // get all rows the user selected
            int[] rowHandles = grvListe.GetSelectedRows();
            if (rowHandles == null || (rowHandles.Length == 0))
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "KeineZeilenSelektiertRueckgaengig",
                    "Es sind keine Zeilen selektiert, welche rückgängig gemacht werden können.");
                return;
            }

            // get all booking rows the user selected
            int[] rowHandlesBuchung = grvBuchung.GetSelectedRows();
            var selectedBuchungen = new List<DataRow>();
            if (edtSelektionTypX.SelectedIndex == 1)
            {
                if (rowHandlesBuchung == null || (rowHandlesBuchung.Length == 0))
                {
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "KeineAuszahlbelegSelektiert",
                        "Es sind keine Auszahlbelege selektiert, welche rückgängig gemacht werden können.");
                    return;
                }

                selectedBuchungen.AddRange(rowHandlesBuchung.Select(rowHandelBuchung => grvBuchung.GetDataRow(rowHandelBuchung)));

                if (selectedBuchungen.Exists(x => !((int)x[DBO.KbBuchung.KbBuchungStatusCode] == 13 && (bool)x[IST_AUSZAHLUNG] && !(bool)x[IST_AUSZAHLUNG_ALBV])))
                {
                    KissMsg.ShowInfo(
                        CLASSNAME,
                        "NurAuszahlungRueckgaengigMachen",
                        "nur verbuchte Auszahlungen (nicht ALBV) können rückgängig gemacht werden.");
                }
            }

            if (!KissMsg.ShowQuestion(
                CLASSNAME,
                "FrageZeilenRueckgaengigMachen",
                "Wollen Sie die selektierten Zeilen wirklich rückgängig machen?"))
            {
                return;
            }

            string errorText = "";
            bool undoWasOk = false;
            int intAnzahl = 0;

            //TODO? Transaktion sollte wohl eigentlich pro Zeile gemacht werden
            // pro:     weniger lange aufs mal gelocket
            // kontra:  ständig neue Transaktion die lockt
            // fazig:   weiss nicht was besser ist!
            Session.BeginTransaction();
            // hier darf kein Code stehen!
            try
            {
                // update all rows the user selected
                foreach (int rowHandle in rowHandles)
                {
                    DataRow row = grvListe.GetDataRow(rowHandle);
                    var qry = new SqlQuery();

                    if (!(row[BEARBEITET] as bool? ?? false))
                    {
                        // Forderung + ALBV Auszahlung
                        if (edtSelektionTypX.SelectedIndex == 0)
                        {
                            if (((bool)row["ErledigterMonat"]) && (!(bool)row["ZahlauftragErstellt"]))
                            {
                                qry = DBUtil.OpenSQL(@"
                                    EXEC dbo.spIkSollstellung_KbBuchung_Undo {0};",
                                    Utils.ConvertToInt(row["IkPositionID"]));
                                undoWasOk = (Utils.ConvertToInt(qry["HasErrors"]) == 0);
                                if (!undoWasOk)
                                {
                                    errorText = Utils.ConvertToString(qry["ErrorText"]);
                                    row[BEARBEITET] = false;
                                    break;
                                }

                                grvBuchung.SelectAll();
                                RecycleBelegNummern();
                                intAnzahl += Utils.ConvertToInt(qry["UndoCount"]);
                                row[BEARBEITET] = true;
                            }
                        }
                        else // ALV Auszahlung
                        {
                            foreach (DataRow rowBuchung in selectedBuchungen.Where(x => (bool)x[IST_AUSZAHLUNG] && !(bool)x[IST_AUSZAHLUNG_ALBV]))
                            {
                                qry = DBUtil.OpenSQL(@"
                                    DECLARE @UserID               INT,
                                            @KbBuchungID_Selected INT;
                                    SET @UserID = {1};
                                    SET @KbBuchungID_Selected = {0};

                                    DECLARE @KbBuchungID         INT,
                                            @KbPeriodeID         INT,
                                            @BelegNr             INT,
                                            @Buchungstext_orig   VARCHAR(200),
                                            @PraefixBuchungstext VARCHAR(200);

                                    SELECT @PraefixBuchungstext = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig('System\KliBu\PraefixBuchungstextAuszahlung', GETDATE())), '');

                                    SELECT
                                      @KbBuchungID       = BUC.KbBuchungID,
                                      @KbPeriodeID       = BUC.KbPeriodeID,
                                      @BelegNr           = BUC.BelegNr,
                                      @Buchungstext_orig = BUCF.Text
                                    FROM dbo.KbBuchung                     BUC  WITH (READUNCOMMITTED)
                                      INNER JOIN dbo.KbForderungAuszahlung FAZ  WITH (READUNCOMMITTED) ON FAZ.KbBuchungID_Auszahlung = BUC.KbBuchungID
                                                                                                     AND FAZ.KbOpAusgleichID IS NOT NULL -- nicht ALBV
                                      INNER JOIN dbo.KbBuchung             BUCF WITH (READUNCOMMITTED) ON BUCF.KbBuchungID = FAZ.KbBuchungID_Forderung
                                    WHERE BUC.KbBuchungID = @KbBuchungID_Selected
                                      AND BUC.KbBuchungStatusCode = 13; -- verbucht

                                    -- Rückgängig machen wenn die Buchung verbucht ist und es nicht eine ALBV-Zahlung ist.
                                    IF (@KbBuchungID IS NOT NULL)
                                    BEGIN
                                      -- recycle BelegNr
                                      exec dbo.spKbRecycleBelegNr @KbPeriodeID, 3, NULL, @BelegNr;

                                      -- reset data on KbBuchung
                                      UPDATE BUC
                                        SET KbBuchungStatusCode = 2, -- freigegeben
                                            BelegNr             = NULL,
                                            KbBelegKreisID      = NULL,
                                            BelegDatum          = NULL,
                                            ValutaDatum         = NULL,
                                            [Text]              = LEFT(@PraefixBuchungstext + ' ' + @Buchungstext_orig, 200),-- TODO
                                            MutiertUserID       = @UserID,
                                            MutiertDatum        = GETDATE()
                                      FROM dbo.KbBuchung BUC
                                      WHERE BUC.KbBuchungID = @KbBuchungID;
                                    END;

                                    SELECT HasErrors = 0, UndoCount = 1;",
                                    Utils.ConvertToInt(rowBuchung["KbBuchungID"]),
                                    Session.User.UserID);

                                intAnzahl += Utils.ConvertToInt(qry["UndoCount"]);
                                row[BEARBEITET] = true;
                            }

                            undoWasOk = (Utils.ConvertToInt(qry["HasErrors"]) == 0);

                            if (!undoWasOk)
                            {
                                errorText = Utils.ConvertToString(qry["ErrorText"]);
                                row[BEARBEITET] = false;
                                break;
                            }
                        }
                    }
                }

                if (!undoWasOk)
                {
                    throw new KissInfoException(errorText);
                }

                Session.Commit();
                // hier darf kein Code stehen!
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
            finally
            {
                if (undoWasOk)
                {
                    KissMsg.ShowInfo(CLASSNAME, "AnzahlBuchungRueckgaengig", "Es wurde(n) {0} Buchung(en) rückgängig gemacht.", intAnzahl.ToString());
                }

                ShowLastAction();
                SetEditMode();

                qryKbBuchung.Fill(qryListe["IkPositionID"]);

                grvListe.SelectRow(qryListe.Position);
                grvBuchung.SelectRow(qryKbBuchung.Position);
            }
        }

        private void CtlKbBelegImportIK_Load(object sender, EventArgs e)
        {
            edtSollstellungsDatumX.DateTime = DateTime.Today;
            edtGeneriertAm.DateTime = DateTime.Today;
            tabControlSearch.SelectedTabIndex = tpgSuchen.TabIndex;

            try
            {
                _kbPeriodeId = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID");
                _kbFolgeperiodeId = KliBuUtil.GetFolgeperiodeId(_kbPeriodeId);
            }
            catch
            {
                _kbPeriodeId = 0;
            }

            colBuchung_BelegStatus.ColumnEdit = grdBuchung.GetLOVLookUpEdit("KbBuchungsStatus");
            colBuchung_KbAuszahlungsArtCode.ColumnEdit = grdBuchung.GetLOVLookUpEdit("KbAuszahlungsArt");
            colListe_Status.ColumnEdit = grdListe.GetLOVLookUpEdit("KbBuchungsStatus");
            kissSearch.SelectParameters = new object[] { Session.User.UserID, _baPersonID };

            SetKbPeriodeIDIfBaPersonIDHasValue();
            SetTitel();
            SetLblMonat();
            ShowLastAction();
        }

        private void edtSelektionSucheX_EditValueChanged(object sender, EventArgs e)
        {
            SetLblMonat();
        }

        private void edtSelektionTypX_EditValueChanged(object sender, EventArgs e)
        {
            SetTitel();
        }

        private void grvBuchung_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (grvBuchung.IsRowSelected(e.RowHandle))
            {
                e.Appearance.BackColor = SystemColors.Highlight;
                e.Appearance.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                e.Appearance.BackColor = GuiConfig.GridRowReadOnly;
                e.Appearance.ForeColor = SystemColors.WindowText;
            }
        }

        private void grvListe_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "IstSelektiert")
            {
                e.Appearance.BackColor = GuiConfig.GridEditable;
                e.Appearance.ForeColor = SystemColors.WindowText;
            }
            else if (grvListe.IsRowSelected(e.RowHandle))
            {
                e.Appearance.BackColor = SystemColors.Highlight;
                e.Appearance.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                e.Appearance.BackColor = GuiConfig.GridRowReadOnly;
                e.Appearance.ForeColor = SystemColors.WindowText;
            }
        }

        private void qryKbBuchung_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void qryListe_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();

            qryKbBuchung.Fill(qryListe["IkPositionID"]);
        }

        #endregion EventHandlers

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtSollstellungsDatumX.EditValue = DateTime.Today;
            edtSelektionTypX.EditValue = "1";
            edtSelektionFallX.EditValue = "2";
            edtSelektionMonatX.EditValue = "1";
            edtSelektionStatusX.EditValue = "1";
            edtSelektionSucheX.EditValue = "1";
        }

        protected override void RunSearch()
        {
            base.RunSearch();

            qryKbBuchung.Fill(DBNull.Value);
        }

        #endregion Protected Methods

        #region Private Methods

        ///<summary>
        ///
        ///</summary>
        private Boolean BelegeVorhanden()
        {
            return (qryListe.Count > 0);
        }

        private Int32 GetStatusBuchung()
        {
            Int32 status = Utils.ConvertToInt(qryKbBuchung[DBO.KbBuchung.KbBuchungStatusCode]);

            Debug.WriteLine("GetStatusBuchung() : " + status);

            return status;
        }

        ///<summary>
        ///
        ///</summary>
        private Int32 GetStatusListe()
        {
            Int32 status = Utils.ConvertToInt(qryListe["Status"]);

            Debug.WriteLine("GetStatusListe() : " + status);

            return status;
        }

        private bool IstAuszahlungNichtAlbv()
        {
            return (qryKbBuchung[IST_AUSZAHLUNG] as bool? ?? false) && !(qryKbBuchung[IST_AUSZAHLUNG_ALBV] as bool? ?? false);
        }

        private void RecycleBelegNummern()
        {
            Int32[] buchungen = grvBuchung.GetSelectedRows();
            if (buchungen == null)
            {
                Debug.WriteLine("Keine Buchungen vorhanden.");
                return;
            }

            foreach (int buchung in buchungen)
            {
                DataRow row = grvBuchung.GetDataRow(buchung);
                Int32 belegNr = Utils.ConvertToInt(row["BelegNr"]);

                if (belegNr == 0)
                {
                    Debug.WriteLine("Buchung hat keine BelegNummer.");
                }
                else
                {
                    Debug.WriteLine("Recycle BelegNummer " + belegNr);

                    DBUtil.ExecuteScalarSQLThrowingException(
                        @"exec dbo.spKbRecycleBelegNr {0}, {1}, {2}, {3}",
                        row["KbPeriodeID"],
                        3,
                        // KbBelegkreis	3 : Belegimport Inkasso
                        null,
                        // KontoID
                        belegNr);
                }
            }
        }

        ///<summary>
        ///
        ///</summary>
        private void SetBelegImportButton()
        {
            SetButton(btnBelegeImportieren, true, 2); // Knopf Beleg importieren aktivieren wenn Status = freigegeben
        }

        private void SetButton(KissButton btn, bool belegImportieren, int statusAktiv)
        {
            if (qryListe[BEARBEITET] as bool? ?? false)
            {
                btn.Enabled = false;
                return;
            }

            bool enable;
            bool erledigterMonat = qryListe["ErledigterMonat"] as bool? ?? false;

            // Belegvorhanden und Beleg importieren oder Rückgängig und Monat ist erledigt
            if (BelegeVorhanden() && (belegImportieren || erledigterMonat))
            {
                Int32 status;
                bool selektionTypIstForderungAlbv = edtSelektionTypX.SelectedIndex == 0;

                // Selektionstyp Forderung + ALBV oder Alimentenvermittlung
                if (selektionTypIstForderungAlbv)
                {
                    status = GetStatusListe();
                }
                else
                {
                    status = GetStatusBuchung();
                }

                // Knopf aktivieren
                if (status == statusAktiv)
                {
                    enable = selektionTypIstForderungAlbv || IstAuszahlungNichtAlbv();
                }
                else
                {
                    enable = false;
                }
            }
            else
            {
                enable = false;
            }

            btn.Enabled = enable;
        }

        ///<summary>
        ///
        ///</summary>
        private void SetEditMode()
        {
            SetBelegImportButton();
            SetRueckgaengigButton();
        }

        private void SetKbPeriodeIDIfBaPersonIDHasValue()
        {
            if (_baPersonID.HasValue)
            {
                _kbPeriodeId = (int)DBUtil.ExecuteScalarSQLThrowingException(
                    "SELECT dbo.fnKbGetPeriodeIDByDate(1, {0}, NULL, 1)",
                    DateTime.Now.ToString("yyyyMMdd"));
            }
        }

        private void SetLblMonat()
        {
            if (edtSelektionSucheX.SelectedIndex >= 0)
            {
                lblMonat.Text = _lblMonat + " " + edtSelektionSucheX.Properties.Items[edtSelektionSucheX.SelectedIndex].Description;
            }
        }

        private void SetRueckgaengigButton()
        {
            SetButton(btnRueckgaengig, false, 13); // Knopf Rückgängig aktivieren wenn Status = verbucht
        }

        private void SetTitel()
        {
            if (edtSelektionTypX.SelectedIndex >= 0)
            {
                lblTitel.Text = _titel + " " + edtSelektionTypX.Properties.Items[edtSelektionTypX.SelectedIndex].Description;
            }
        }

        private void ShowLastAction()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT TOP 1
                  POS.Jahr,
                  POS.Monat
                FROM dbo.IkPosition POS WITH (READUNCOMMITTED)
                WHERE POS.ErledigterMonat = 1
                ORDER BY POS.Jahr DESC, POS.Monat DESC");

            if (qry.Count == 0)
            {
                lblLetzteSollstellung.Text = KissMsg.GetMLMessage(CLASSNAME, "keineSollstellung", "keine Sollstellung gefunden");
            }
            else
            {
                DateTime dt = Convert.ToDateTime("01." + qry["Monat"] + "." + qry["Jahr"]);
                lblLetzteSollstellung.Text = KissMsg.GetMLMessage(
                    CLASSNAME,
                    "letzteSollstellungIm",
                    "Letzte Sollstellung im {0}",
                    dt.ToString("MMMM yyyy"));
            }
        }

        #endregion Private Methods

        #endregion Methods
    }
}