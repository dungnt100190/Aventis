using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Gui;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

namespace KiSS4.Vormundschaft
{
    public partial class CtlVmKasse : KissSearchUserControl
    {
        #region Constructors

        public CtlVmKasse()
        {
            InitializeComponent();

            SqlQuery qryStatus = DBUtil.OpenSQL(@"
                SELECT Code, Text
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'FbBuchungStatus';");

            colStatus.ColumnEdit = grdBarzahlungen.GetLOVLookUpEdit(qryStatus, "Code", "Text");
        }

        #endregion

        #region EventHandlers

        private void btnAuszahlen_Click(object sender, EventArgs e)
        {
            // Validate Input
            DBUtil.CheckNotNullField(edtAuszNameVorname, lblAuszNameVorname.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBelegText.Text);
            DBUtil.CheckNotNullField(edtSoll, lblBelegSoll.Text);

            // SollKontoNr gültig für Mandant
            var dlg = new DlgAuswahl();
            bool successSoll = dlg.PeriodenKontoSuchen(
                edtSoll.Text,
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.BaPersonID].ToString(),
                DateTime.Now,
                false);

            if (!successSoll)
            {
                edtSoll.Focus();
                return;
            }

            int auftragId = Convert.ToInt32(qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBarauszahlungAuftragID]);
            int periodeId = Convert.ToInt32(qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbPeriodeID]);
            decimal betrag = Convert.ToDecimal(qryVmKasse[DBO.fnFbGetBarauszahlungListe.Betrag]);
            int zyklusId = Convert.ToInt32(qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBarauszahlungZyklusID]);
            string creatorModifier = DBUtil.GetDBRowCreatorModifier();
            DateTime stichtag = Convert.ToDateTime(qryVmKasse[DBO.fnFbGetBarauszahlungListe.Stichtag]);

            DateTime today = DateTime.Today;
            object buchungId = null;

            // Confirm the Payment
            bool confirmation = KissMsg.ShowQuestion(
                Name,
                "VmKasseConfirmAuszahlung",
                "Wollen Sie die Barauszahlung von CHF {0} an {1} jetzt auszahlen?",
                true,
                edtBetrag.Text,
                edtAuszNameVorname.Text);

            if (!confirmation)
            {
                return;
            }

            // save Concurrency Info for payment in list.
            var concurrencyAuftragTsBefore = qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBarauszahlungAuftragTS] as byte[];
            var concurrencyZyklusTsBefore = qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBarauszahlungZyklusTS] as byte[];

            RefreshCtlVmBarauszahlungGeplant();

            Session.BeginTransaction();
            try
            {
                // check concurrancy
                // Get Concurrency info for payment from db
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT BAA.FbBarauszahlungAuftragTS, BAZ.FbBarauszahlungZyklusTS
                    FROM dbo.FbBarauszahlungAuftrag BAA
                    INNER JOIN dbo.FbBarauszahlungZyklus BAZ ON BAZ.FbBarauszahlungAuftragID = BAA.FbBarauszahlungAuftragID
                        AND BAZ.FbBarauszahlungZyklusID = {1}
                    WHERE BAA.FbBarauszahlungAuftragID = {0}",
                    auftragId,
                    zyklusId);

                var concurrencyAuftragTsNew = qry[DBO.FbBarauszahlungAuftrag.FbBarauszahlungAuftragTS] as byte[];
                var concurrencyZyklusTsNew = qry[DBO.FbBarauszahlungZyklus.FbBarauszahlungZyklusTS] as byte[];

                // compare the concurrency info -> exception if not the same

                if (!DBUtil.BytesAreEqual(concurrencyAuftragTsBefore, concurrencyAuftragTsNew) ||
                    !DBUtil.BytesAreEqual(concurrencyZyklusTsBefore, concurrencyZyklusTsNew))
                {
                    throw new DBConcurrencyException(
                        "FbBarauszahlungAuftragTS or FbBarauszahlungZyklusTS were changed since the creation of the list.");
                }

                // Insert new FbBuchung
                buchungId = DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @PfixBelegNr varchar(25), @FbBelegNrID int, @BuchungID int;

                    SELECT @FbBelegNrID = FbBelegNrID
                    FROM FbBelegNr
                    WHERE BelegNrCode = 5; -- Barauszahlung

                    EXEC dbo.spFbNextBelegNr @FbBelegNrID, @PfixBelegNr OUT;

                    INSERT INTO FbBuchung(
                        FbPeriodeID, BuchungTypCode, BelegNr, BelegNrPos, BuchungsDatum, SollKtoNr,
                        HabenKtoNr, Betrag, Text, ValutaDatum, UserID, Name, Strasse, PLZ, Ort,
                        Creator, Modifier
                    )
                    VALUES (
                        {0}, 5, @PfixBelegNr, 0, {1}, {2}, {3}, {4}, {5}, {1}, {6}, {7}, {8}, {9}, {10}, {13}, {13}
                    );

                    SET @BuchungID = @@IDENTITY;

                    INSERT INTO FbBarauszahlungAusbezahlt(
                        FbBarauszahlungZyklusID, FbBuchungID, UserID,
                        Datum, Stichtag, Creator, Modifier
                    )
                    VALUES (
                        {11}, @BuchungID, {6}, {1}, {12}, {13}, {13}
                    );

                    UPDATE BAA SET BAA.AuszahlungenVorhanden = 1
                    FROM dbo.FbBarauszahlungAuftrag BAA
                    WHERE BAA.FbBarauszahlungAuftragID = {14};

                    SELECT @BuchungID;",
                    periodeId,
                    today,
                    edtSoll.Text,
                    edtHaben.Text,
                    betrag,
                    edtBuchungstext.Text,
                    Session.User.UserID,
                    edtAuszNameVorname.Text,
                    edtAuszStrasse.Text,
                    edtAuszPLZ.Text,
                    edtAuszOrt.Text,
                    zyklusId,
                    stichtag,
                    creatorModifier,
                    auftragId);

                if (buchungId == null || !Utils.IsNatural(buchungId.ToString()))
                {
                    throw new KissErrorException("FbBuchungID ist NULL. Es wurde keine Buchung angelegt.");
                }

                Session.Commit();
            }
            catch (KissErrorException ex)
            {
                Session.Rollback();

                KissMsg.ShowError(
                    Name,
                    "FrmVmKasseBuchungSpeichernError",
                    "Buchung konnte nicht gepeichert werden. Bitte laden Sie die Maske neu.",
                    ex);

                return;
            }
            catch (DBConcurrencyException ex)
            {
                Session.Rollback();

                KissMsg.ShowError(
                    Name,
                    "KasseBuchungConcurrencyError",
                    "Die Daten in der Maske sind nicht mehr aktuell. Bitte laden Sie die Maske neu.",
                    ex);

                RefreshCtlVmBarauszahlungGeplant();

                return;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(
                    Name,
                    "KasseBuchungGeneralError",
                    "Beim Auszahlen ist ein Fehler aufgetreten. Bitte informieren Sie den KiSS Support.",
                    ex);
            }

            RefreshCtlVmBarauszahlungGeplant();

            try
            {
                // Print receipt
                PrintKassenbeleg(chkDruckvorschau.Checked, Convert.ToInt32(buchungId));
            }
            catch (KissInfoException ex)
            {
                KissMsg.ShowError(
                    Name,
                    "PrintBelegAuszError",
                    "Fehler beim Ausdrucken des Belegs.",
                    ex);
            }
            finally
            {
                // Update Status
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT
                        FBU.BuchungsDatum,
                        FBU.BelegNr,
                        AuszahlungDurch = dbo.fnGetLastFirstName(FBU.UserID, NULL, NULL)
                    FROM FbBuchung FBU
                    WHERE FbBuchungID = {0}",
                    Convert.ToInt32(buchungId));

                qryVmKasse[DBO.fnFbGetBarauszahlungListe.StatusCode] = FbBuchungStatus.Ausbezahlt;
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.Auszahldatum] = qry[DBO.FbBuchung.BuchungsDatum];
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.BelegNr] = qry[DBO.FbBuchung.BelegNr];
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBuchungID] = Convert.ToInt32(buchungId);
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.AuszahlungDurch] = qry["AuszahlungDurch"];
                qryVmKasse.Row.AcceptChanges();
                qryVmKasse.RowModified = false;

                SetAllReadonly();
                UpdateButtons(FbBuchungStatus.Ausbezahlt);
            }
        }

        /// <summary>
        /// Print the 'Kassenbeleg'. Click event of btnBelegDrucken.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBelegDrucken_Click(object sender, EventArgs e)
        {
            var buchungId = qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBuchungID] as int?;
            if (Convert.ToInt32(qryVmKasse[DBO.fnFbGetBarauszahlungListe.StatusCode]) == (int)FbBuchungStatus.Ausbezahlt && buchungId.HasValue)
            {
                PrintKassenbeleg(chkDruckvorschau.Checked, buchungId.Value);
            }
        }

        private void btnZuBarauszahlung_Click(object sender, EventArgs e)
        {
            bool result = false;
            int faLeistungId = Convert.ToInt32(qryVmKasse[DBO.fnFbGetBarauszahlungListe.FaLeistungID]);
            int auftragId = Convert.ToInt32(qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBarauszahlungAuftragID]);
            int baPersonId = Convert.ToInt32(qryVmKasse[DBO.fnFbGetBarauszahlungListe.BaPersonID]);
            int modulId = DBUtil.ExecuteScalarSQL(@"
                SELECT ModulID
                FROM dbo.XModul MDL WITH (READUNCOMMITTED)
                WHERE MDL.Licensed = 1
                  AND MDL.ModulTree = 1
                  AND DB_Prefix = 'Kes'
                ") as int? ?? 5;

            // Create TreeNodeID
            var treeNodeId = DBUtil.ExecuteScalarSQL(@"
                DECLARE @ModulID INT;
                DECLARE @FaLeistungID INT;

                SET @ModulID = {1};
                SET @FaLeistungID = {0};

                ;WITH TreeCte AS
                (
                  SELECT
                    XMT.ModulTreeID,
                    XMT.ModulTreeID_Parent,
                    TreeNodeId = CONVERT(VARCHAR(MAX), XMT.ClassName),
                    ModulTreeID_start = ModulTreeID
                  FROM dbo.XModulTree XMT
                  WHERE XMT.ClassName LIKE 'CtlVmBarauszahlungGeplant'
                    AND ModulID = @ModulID

                  UNION ALL

                  SELECT
                    XMT.ModulTreeID,
                    XMT.ModulTreeID_Parent,
                    TreeNodeId = CASE WHEN XMT.ModulTreeID_Parent IS NOT NULL
                                   THEN ISNULL(XMT.ClassName, CONVERT(VARCHAR(MAX), XMT.ModulTreeID)) + '/' + CTE.TreeNodeId
                                   --THEN CONVERT(VARCHAR(MAX), XMT.ModulTreeID) + '/' + CTE.TreeNodeId
                                   --ELSE XMT.ClassName + CONVERT(VARCHAR(MAX), @FaLeistungID) + '/' + CTE.TreeNodeId
                                   ELSE CTE.TreeNodeId
                                 END,
                    ModulTreeID_start = CTE.ModulTreeID_start
                  FROM dbo.XModulTree XMT
                    INNER JOIN TreeCte CTE ON CTE.ModulTreeID_Parent = XMT.ModulTreeID
                )

                SELECT TOP 1
                  TreeNodeId = TRE.ClassName + CONVERT(VARCHAR(MAX), @FaLeistungID) + '/' + CTE.TreeNodeId
                FROM TreeCte CTE
                  INNER JOIN dbo.XModulTree TRE WITH (READUNCOMMITTED) ON TRE.ModulID = @ModulID
                                                                      AND TRE.ModulTreeID_Parent IS NULL
                                                                      AND TRE.ModulTreeID = @ModulID * 10000
                WHERE CTE.ModulTreeID_Parent IS NULL
                  AND CTE.ModulTreeID = (SELECT CASE
                                                  WHEN FaProzessCode = 501 AND @ModulID = 29 THEN 295000
                                                  ELSE TRE.ModulTreeID
                                                END
                                         FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                         WHERE FaLeistungID = @FaLeistungID)
                ORDER BY LEN(CTE.TreeNodeId)",
                faLeistungId,
                modulId);

            if (treeNodeId != null)
            {
                // Create Jump Path
                var jumpToPath = string.Format(
                    "ActiveSQLQuery.Find=FbBarauszahlungAuftragID = {0};BaPersonID={1};ModulID={4};TreeNodeID={2};FaLeistungID={3};FaFallID={1};ClassName=FrmFall;",
                    auftragId,
                    baPersonId,
                    treeNodeId.ToString(),
                    faLeistungId,
                    modulId);

                // Form Controller Send Message - Jump to VM BarzahlungsAuftrag
                var dic = FormController.ConvertToDictionary(jumpToPath);
                result = FormController.OpenForm(Convert.ToString(dic["ClassName"]), "Action", "JumpToPath", dic);
            }

            if (!result)
            {
                // show info due to failure of call!!
                KissMsg.ShowInfo(
                    Name,
                    "JumpToPathFailure",
                    "Es ist ein Fehler beim Aufrufen der gewünschten Maske aufgetreten. " +
                    "Wahrscheinlich werden nicht die richtigen Daten angezeigt.");
            }
        }

        private void chkAuszNichtKlient_CheckedChanged(object sender, EventArgs e)
        {
            AuszAdresseEnableDisable(((KissCheckEdit)sender).Checked);
        }

        private void edtHaben_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var periodeId = qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbPeriodeID] as int?;
            if (!periodeId.HasValue)
            {
                KissMsg.ShowError(Name, "HabenKontoNoPeriodError", "Keine aktive Periode gefunden.");
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(edtHaben.Text, periodeId.Value, true);

            if (!e.Cancel)
            {
                edtHaben.EditValue = dlg["KontoNr"];
                edtHaben.LookupID = dlg["FbKontoID"];
                edtHabenName.Text = dlg["KontoName"] != DBNull.Value ? Convert.ToString(dlg["KontoName"]) : string.Empty;
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.HabenKtoNr] = dlg["KontoNr"];
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.HabenKtoName] = dlg["KontoName"] != DBNull.Value
                                                                             ? Convert.ToString(dlg["KontoName"])
                                                                             : string.Empty;
                qryVmKasse.Row.AcceptChanges();
                qryVmKasse.RowModified = false;
            }
        }

        private void edtSoll_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var periodeId = qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbPeriodeID] as int?;

            if (!periodeId.HasValue)
            {
                KissMsg.ShowError(Name, "SollKontoNoPeriodError", "Keine aktive Periode gefunden.");
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(edtSoll.Text, periodeId.Value, true);

            if (!e.Cancel)
            {
                edtSoll.EditValue = dlg["KontoNr"];
                edtSoll.LookupID = dlg["FbKontoID"];
                edtSollName.Text = dlg["KontoName"] != DBNull.Value ? Convert.ToString(dlg["KontoName"]) : string.Empty;
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.SollKtoNr] = dlg["KontoNr"];
                qryVmKasse[DBO.fnFbGetBarauszahlungListe.SollKtoName] = dlg["KontoName"] != DBNull.Value
                                                                            ? Convert.ToString(dlg["KontoName"])
                                                                            : string.Empty;
                qryVmKasse.Row.AcceptChanges();
                qryVmKasse.RowModified = false;
            }
        }

        private void edtSucheMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(edtSucheMandant.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSucheMandant.EditValue = dlg["Name"];
                edtSucheMandant.LookupID = dlg["BaPersonID"];
            }
        }

        private void FrmVmKasse_Load(object sender, EventArgs e)
        {
            SetupDataMembers();
            SetupFieldNames();
            SetupRequiredFields();

            qryVmKasse.SelectStatement = @"
                DECLARE @DatumVon DATETIME, @DatumBis DATETIME, @MandantID INT, @Verbucht BIT, @NichtVerbucht BIT;
                --- SET @DatumVon = {edtSucheDatumVon};
                --- SET @DatumBis = {edtSucheDatumBis};
                --- SET @MandantID = {edtSucheMandant.LookupID};
                --- SET @Verbucht = {chkSucheVerbucht.Checked};
                --- SET @NichtVerbucht = {chkSucheNichtVerbucht.Checked};

                SELECT
                    FbBarauszahlungAuftragID,
                    FbBarauszahlungZyklusID,
                    FbPeriodeID,
                    FbBuchungID,
                    FaLeistungID,
                    BaPersonID,
                    Mandant,
                    MandantVornameName,
                    PersStrasse,
                    PersPLZ,
                    PersOrt,
                    PersGeburtsdatum,
                    PersAHVNummer,
                    PersVersNummer,
                    BelegNr,
                    Stichtag,
                    AuszahlungAb,
                    AuszahlungBis,
                    BewilligtDurch,
                    Betrag,
                    Auszahldatum,
                    StatusCode,
                    SollKtoNr,
                    SollKtoName,
                    HabenKtoNr,
                    HabenKtoName,
                    Buchungstext,
                    Mandatstraeger,
                    AuszahlungDurch,
                    FbBarauszahlungAuftragTS,
                    FbBarauszahlungZyklusTS
                FROM dbo.fnFbGetBarauszahlungListe(@DatumVon, @DatumBis, @Verbucht, @NichtVerbucht, @MandantID);";

            grvBarzahlungen.OptionsView.ColumnAutoWidth = true;
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);
        }

        private void qryVmKasse_AfterFill(object sender, EventArgs e)
        {
            // wenn keine Datensätze vorhanden sind, kann die Barauszahlung im Fall nicht angezeigt werden
            btnZuBarauszahlung.Enabled = (qryVmKasse.Count > 0);

            if (qryVmKasse.Count == 0)
            {
                // wenn keine Datensätze vorhanden sind, wird SqlQuery.OnPositionChanged nicht ausgelöst.
                // Damit Anzeige in Felder gelöscht wird und Buttons eingestellt serden,
                // muss SqlQuery.OnPositionChanged explizit gemacht werden:
                qryVmKasse_PositionChanged(sender, e);
            }
        }

        private void qryVmKasse_PositionChanged(object sender, EventArgs e)
        {
            FbBuchungStatus statusCode = 0;

            var statusCodeInt = qryVmKasse[DBO.fnFbGetBarauszahlungListe.StatusCode] as int?;
            if (statusCodeInt.HasValue)
            {
                statusCode = (FbBuchungStatus)statusCodeInt.Value;
            }

            SetAllReadonly();

            edtBuchungstext.Text = Utils.ConvertToString(qryVmKasse[DBO.fnFbGetBarauszahlungListe.Buchungstext]);

            // Status: Ausbezahlt
            if (statusCode == FbBuchungStatus.Ausbezahlt && qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBuchungID] != DBNull.Value)
            {
                chkAuszNichtKlient.CheckState = CheckState.Indeterminate;
                AuszAdresseEnableDisable(false);

                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT
                        FBU.Name,
                        FBU.Strasse,
                        FBU.PLZ,
                        FBU.Ort
                    FROM FbBuchung FBU
                    WHERE FbBuchungID = {0}",
                    qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBuchungID]);

                edtAuszNameVorname.EditValue = Convert.ToString(qry[DBO.FbBuchung.Name]);
                edtAuszStrasse.EditValue = Convert.ToString(qry[DBO.FbBuchung.Strasse]);
                edtAuszPLZ.EditValue = Convert.ToString(qry[DBO.FbBuchung.PLZ]);
                edtAuszOrt.EditValue = Convert.ToString(qry[DBO.FbBuchung.Ort]);

                if (string.IsNullOrEmpty(qryVmKasse[DBO.fnFbGetBarauszahlungListe.Auszahldatum].ToString()))
                {
                    edtDatumAuszahlung.Text = string.Empty;
                }
                else
                {
                    edtDatumAuszahlung.DateTime = Convert.ToDateTime(qryVmKasse[DBO.fnFbGetBarauszahlungListe.Auszahldatum]);
                }
            }
            // Status: Freigegeben
            else if (statusCode == FbBuchungStatus.Freigegeben)
            {
                chkAuszNichtKlient.CheckState = CheckState.Unchecked;

                chkAuszNichtKlient.EditMode = EditModeType.Normal;
                AuszAdresseEnableDisable(chkAuszNichtKlient.Checked);
                edtDatumAuszahlung.DateTime = DateTime.Today;
                edtSoll.EditMode = DBUtil.GetConfigBool(@"System\Fibu\VmKasse\SollEditierbar", false) ? EditModeType.Required : EditModeType.ReadOnly;
                edtHaben.EditMode = DBUtil.GetConfigBool(@"System\Fibu\VmKasse\HabenEditierbar", false)
                                        ? EditModeType.Required
                                        : EditModeType.ReadOnly;
                edtBuchungstext.EditMode = DBUtil.GetConfigBool(@"System\Fibu\VmKasse\TextEditierbar", false)
                                               ? EditModeType.Required
                                               : EditModeType.ReadOnly;
            }
            // Restliche Status
            else
            {
                chkAuszNichtKlient.CheckState = CheckState.Unchecked;
                AuszAdresseEnableDisable(false);
                edtDatumAuszahlung.Text = string.Empty;
            }

            UpdateButtons(statusCode);
        }

        private void qryVmKasse_PositionChanging(object sender, EventArgs e)
        {
            qryVmKasse.Row.AcceptChanges();
            qryVmKasse.RowModified = false;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            SetSearchDefaultValues();
            AuszAdresseEnableDisable(false);

            base.NewSearch();
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtSucheDatumVon, "Datum von");
            DBUtil.CheckNotNullField(edtSucheDatumBis, "Datum bis");

            base.RunSearch();
        }

        #endregion

        #region Private Static Methods

        private static void RefreshCtlVmBarauszahlungGeplant()
        {
            // refresh control
            FormController.SendMessage(
                "FrmFall",
                "Action",
                "RefreshControl",
                "ControlName",
                "CtlVmBarauszahlungGeplant");
        }

        #endregion

        #region Private Methods

        private void AuszAdresseEnableDisable(bool auszNichtPerson)
        {
            if (auszNichtPerson)
            {
                edtAuszNameVorname.EditMode = EditModeType.Required;
                edtAuszStrasse.EditMode = EditModeType.Normal;
                edtAuszPLZ.EditMode = EditModeType.Normal;
                edtAuszOrt.EditMode = EditModeType.Normal;

                edtAuszNameVorname.EditValue = string.Empty;
                edtAuszStrasse.EditValue = string.Empty;
                edtAuszPLZ.EditValue = string.Empty;
                edtAuszOrt.EditValue = string.Empty;
            }
            else
            {
                edtAuszNameVorname.EditMode = EditModeType.ReadOnly;
                edtAuszStrasse.EditMode = EditModeType.ReadOnly;
                edtAuszPLZ.EditMode = EditModeType.ReadOnly;
                edtAuszOrt.EditMode = EditModeType.ReadOnly;

                edtAuszNameVorname.EditValue = Convert.ToString(qryVmKasse[DBO.fnFbGetBarauszahlungListe.MandantVornameName]);
                edtAuszStrasse.EditValue = Convert.ToString(qryVmKasse[DBO.fnFbGetBarauszahlungListe.PersStrasse]);
                edtAuszPLZ.EditValue = Convert.ToString(qryVmKasse[DBO.fnFbGetBarauszahlungListe.PersPLZ]);
                edtAuszOrt.EditValue = Convert.ToString(qryVmKasse[DBO.fnFbGetBarauszahlungListe.PersOrt]);
            }
        }

        private void PrintKassenbeleg(bool showPrinterPreview, int buchungId)
        {
            // Print Report
            var prms = new NamedPrm[4];
            prms[0] = new NamedPrm("FbBuchungID", buchungId);
            prms[1] = new NamedPrm("FbBarauszahlungAuftragID", qryVmKasse[DBO.fnFbGetBarauszahlungListe.FbBarauszahlungAuftragID]);
            prms[2] = new NamedPrm("BaPersonID", qryVmKasse[DBO.fnFbGetBarauszahlungListe.BaPersonID]);
            prms[3] = new NamedPrm("Stichtag", qryVmKasse[DBO.fnFbGetBarauszahlungListe.Stichtag]);

            try
            {
                if (showPrinterPreview)
                {
                    RepUtil.ExecuteReport("VmFibuKassenbeleg", KissReportDestination.Viewer, prms);
                }
                else
                {
                    RepUtil.ExecuteReport("VmFibuKassenbeleg", KissReportDestination.Printer, prms);
                }
            }
            catch (Exception ex)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(Name, "PrintBelegError", "Fehler beim Drucken des Belegs."), ex, btnBelegDrucken);
            }
        }

        private void SetAllReadonly()
        {
            edtSoll.EditMode = EditModeType.ReadOnly;
            edtHaben.EditMode = EditModeType.ReadOnly;
            chkAuszNichtKlient.EditMode = EditModeType.ReadOnly;
            edtBuchungstext.EditMode = EditModeType.ReadOnly;
        }

        private void SetSearchDefaultValues()
        {
            edtSucheDatumVon.EditValue = DateTime.Today;
            edtSucheDatumBis.EditValue = DateTime.Today;
            chkSucheNichtVerbucht.Checked = true;
        }

        private void SetupDataMembers()
        {
            edtPersNameVorname.DataMember = DBO.fnFbGetBarauszahlungListe.Mandant;
            edtPersStrasse.DataMember = DBO.fnFbGetBarauszahlungListe.PersStrasse;
            edtPersPLZ.DataMember = DBO.fnFbGetBarauszahlungListe.PersPLZ;
            edtPersOrt.DataMember = DBO.fnFbGetBarauszahlungListe.PersOrt;
            edtPersGeburtsdatum.DataMember = DBO.fnFbGetBarauszahlungListe.PersGeburtsdatum;
            edtPersAHVNummer.DataMember = DBO.fnFbGetBarauszahlungListe.PersAHVNummer;
            edtPersVersNummer.DataMember = DBO.fnFbGetBarauszahlungListe.PersVersNummer;

            edtSoll.DataMember = DBO.fnFbGetBarauszahlungListe.SollKtoNr;
            edtSollName.DataMember = DBO.fnFbGetBarauszahlungListe.SollKtoName;
            edtHaben.DataMember = DBO.fnFbGetBarauszahlungListe.HabenKtoNr;
            edtHabenName.DataMember = DBO.fnFbGetBarauszahlungListe.HabenKtoName;
            edtBetrag.DataMember = DBO.fnFbGetBarauszahlungListe.Betrag;
            edtMandatstraeger.DataMember = DBO.fnFbGetBarauszahlungListe.Mandatstraeger;
            edtBewilligtDurch.DataMember = DBO.fnFbGetBarauszahlungListe.BewilligtDurch;
            edtAuszahlungDurch.DataMember = DBO.fnFbGetBarauszahlungListe.AuszahlungDurch;
        }

        private void SetupFieldNames()
        {
            colBelegNr.FieldName = DBO.fnFbGetBarauszahlungListe.BelegNr;
            colMandant.FieldName = DBO.fnFbGetBarauszahlungListe.Mandant;
            colStichtag.FieldName = DBO.fnFbGetBarauszahlungListe.Stichtag;
            colText.FieldName = DBO.fnFbGetBarauszahlungListe.Buchungstext;
            colAuszahlungAb.FieldName = DBO.fnFbGetBarauszahlungListe.AuszahlungAb;
            colAuszahlungBis.FieldName = DBO.fnFbGetBarauszahlungListe.AuszahlungBis;
            colBewilligtVon.FieldName = DBO.fnFbGetBarauszahlungListe.BewilligtDurch;
            colBetrag.FieldName = DBO.fnFbGetBarauszahlungListe.Betrag;
            colAuszahlungsdatum.FieldName = DBO.fnFbGetBarauszahlungListe.Auszahldatum;
            colStatus.FieldName = DBO.fnFbGetBarauszahlungListe.StatusCode;
        }

        private void SetupRequiredFields()
        {
            edtSucheDatumVon.EditMode = EditModeType.Required;
            edtSucheDatumBis.EditMode = EditModeType.Required;
        }

        private void UpdateButtons(FbBuchungStatus statusCode)
        {
            btnAuszahlen.Enabled = ((statusCode == FbBuchungStatus.Freigegeben) && (qryVmKasse.Count > 0));
            btnBelegDrucken.Enabled = ((statusCode == FbBuchungStatus.Ausbezahlt) && (qryVmKasse.Count > 0));
        }

        #endregion

        #endregion
    }
}