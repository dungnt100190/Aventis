using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuKreditor.
    /// </summary>
    public partial class CtlFibuKreditor : Gui.KissUserControl
    {
        #region Constructors

        public CtlFibuKreditor()
        {
            InitializeComponent();
            grdFbZahlungsweg.View.Columns["PCKontoNr"].DisplayFormat.Format = new GridColumnPCKontoFormatter();

            //Spezialrechte abfragen
            grdFbKreditor.View.OptionsBehavior.Editable = DBUtil.UserHasRight("CtlFibuKreditor_KreditorInTabelleDeaktivieren");
            btnAlleKreditorenDeaktivieren.Enabled = DBUtil.UserHasRight("CtlFibuKreditor_AlleKreditorenDeaktivieren");
        }

        #endregion

        #region EventHandlers

        private void btnAlleKreditorenDeaktivieren_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion(
                this.Name,
                "AlleKreditorenDeaktivieren",
                "Alle angezeigten Kreditoren werden deaktiviert.\r\nDiese Aktion kann nicht rückgängig gemacht werden.\r\nSind Sie sicher, dass Sie weiterfahren möchten?"))
            {
                try
                {
                    Session.BeginTransaction();
                    foreach (DataRow row in qryFbKreditor.DataTable.Rows)
                    {
                        DBUtil.ExecSQLThrowingException(
                            @"
                            UPDATE FbZahlungsweg SET IsActive = {0} WHERE FbKreditorID = {1};
                            UPDATE FbKreditor SET Aktiv = {0} WHERE FbKreditorID = {1};",
                            false, row[DBO.FbKreditor.FbKreditorID]);
                    }
                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }
                finally
                {
                    qryFbKreditor.Refresh();
                }
            }
        }

        private void ctlFibuBuchung_Load(object sender, EventArgs e)
        {
            tabControlSearch.SelectedTabIndex = 0;

            colZahlungsArt.ColumnEdit = grdFbZahlungsweg.GetLOVLookUpEdit("FbZahlungsArtCode");

            qryFbKreditor.Fill(@"
                SELECT
                  FBK.*,
                  AufwandKontoName = FBK1.KontoName
                FROM dbo.FbKreditor      FBK
                  LEFT  JOIN dbo.FBKonto FBK1 ON FBK1.KontoNr = FBK.AufwandKonto
                                             AND FBK1.FbPeriodeID IS NULL
                ORDER BY Name;");

            grdFbKreditor.Focus();
        }

        private void CtlFibuKreditor_Search(object sender, EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 0)
            {
                if (qryFbKreditor.Post())
                {
                    tabControlSearch.SelectedTabIndex = 1;
                    NeueKreditorSuche();
                }
            }
            else
            {
                Suchen();
            }
        }

        private void editAufwandKonto_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.StandardKontoSuchen(editAufwandKonto.Text, e.ButtonClicked, (int)KontoKlasse.Aufwand);
            if (!e.Cancel)
            {
                qryFbKreditor["AufwandKonto"] = dlg["KontoNr"];
                qryFbKreditor["AufwandKontoName"] = dlg["KontoName"];
            }
        }

        private void editPostKontoNr_Properties_FormatEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;
                e.Value = Utils.FormatPCKontoNummerToUserFormat(e.Value.ToString());
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void editPostKontoNr_Properties_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;
                e.Value = Utils.FormatPCKontoNummerToDBFormat(e.Value.ToString());
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void edtBank_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            FibuUtilities.BankSuchen(edtBank.Text, e.ButtonClicked, qryFbZahlungsweg);
        }

        private void edtZahlungsArt_EditValueChanged(object sender, EventArgs e)
        {
            int dataSourceValue = 0;
            int cboValue = 0;

            if (qryFbZahlungsweg.IsEmpty)
            {
                edtZahlungsArt.EditValueChanged -= edtZahlungsArt_EditValueChanged;
                edtZahlungsArt.EditValue = null;
                edtZahlungsArt.EditValueChanged += edtZahlungsArt_EditValueChanged;
                edtBank.EditMode = EditModeType.ReadOnly;
                edtBankKontoNr.EditMode = EditModeType.ReadOnly;
                edtPostKontoNr.EditMode = EditModeType.ReadOnly;
                edtIBAN.EditMode = EditModeType.ReadOnly;
                edtBank.EditMode = EditModeType.ReadOnly;
                return;
            }

            if (!DBUtil.IsEmpty(qryFbZahlungsweg["ZahlungsArtCode"]))
            {
                dataSourceValue = Convert.ToInt32(qryFbZahlungsweg["ZahlungsArtCode"]);
            }

            if (!DBUtil.IsEmpty(edtZahlungsArt.EditValue))
            {
                cboValue = Convert.ToInt32(edtZahlungsArt.EditValue);
            }

            if (dataSourceValue != cboValue && qryFbZahlungsweg.Row.RowState != DataRowState.Added)
            {
                if (!KissMsg.ShowQuestion("CtlFibuKreditor", "DatenGehenVerloren", "Existierende Daten werden verloren wenn Sie die Zahlungsart ändern\r\n\r\nWollen Sie es trotzdem ändern"))
                {
                    return;
                }

                ReinitialiseZahlungsArtEditValues();
            }

            switch (cboValue)
            {
                case 1:
                case 3:
                    //ES orange + ES rot (Post)
                    edtBank.EditMode = EditModeType.ReadOnly;
                    edtBankKontoNr.EditMode = EditModeType.ReadOnly;
                    edtPostKontoNr.EditMode = EditModeType.Normal;
                    edtIBAN.EditMode = EditModeType.ReadOnly;
                    edtBank.EditMode = EditModeType.ReadOnly;
                    break;

                case 2: //inaktiv
                case 4:
                    //Blau/Orange ESR über Bank (inaktiv) + Roter Einzahlungsschein Bank
                    edtBank.EditMode = EditModeType.Normal;
                    edtBankKontoNr.EditMode = EditModeType.Normal;
                    edtPostKontoNr.EditMode = EditModeType.ReadOnly;
                    edtIBAN.EditMode = EditModeType.Normal;
                    edtBank.EditMode = EditModeType.Normal;
                    break;

                case 5:
                    //Bankzahlung Schweiz (inaktiv)
                    edtBank.EditMode = EditModeType.Normal;
                    edtBankKontoNr.EditMode = EditModeType.Normal;
                    edtPostKontoNr.EditMode = EditModeType.ReadOnly;
                    edtIBAN.EditMode = EditModeType.Normal;
                    edtBank.EditMode = EditModeType.Normal;
                    break;

                case 6:
                    //Postmandat
                    edtBank.EditMode = EditModeType.ReadOnly;
                    edtBankKontoNr.EditMode = EditModeType.ReadOnly;
                    edtPostKontoNr.EditMode = EditModeType.ReadOnly;
                    edtIBAN.EditMode = EditModeType.ReadOnly;
                    edtBank.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    edtBank.EditMode = EditModeType.Normal;
                    edtBankKontoNr.EditMode = EditModeType.Normal;
                    edtPostKontoNr.EditMode = EditModeType.Normal;
                    edtIBAN.EditMode = EditModeType.Normal;
                    edtBank.EditMode = EditModeType.Normal;
                    break;
            }
        }

        private void grvFbKreditor_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == DBO.FbKreditor.Aktiv)
            {
            }
        }

        private void grvFbKreditor_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == DBO.FbKreditor.Aktiv)
            {
                qryFbKreditor[DBO.FbKreditor.Aktiv] = e.Value;
                qryFbKreditor.Post(true, true);
            }
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            // Test if post erfolgreich
            if (qryFbKreditor.Post())
            {
                ActiveSQLQuery = qryFbZahlungsweg;
            }
        }

        private void qryFbKreditor_AfterPost(object sender, EventArgs e)
        {
            try
            {
                if (qryFbZahlungsweg != null && qryFbZahlungsweg.Count > 0)
                {
                    int oldPosition = qryFbZahlungsweg.Position;
                    qryFbZahlungsweg.Position = 0;

                    do
                    {
                        if (!IsInaktiveZahlungsart())
                        {
                            qryFbZahlungsweg["IsActive"] = qryFbKreditor["Aktiv"];
                            qryFbZahlungsweg.Post();
                        }
                    }
                    while (qryFbZahlungsweg.Next());

                    qryFbZahlungsweg.Position = oldPosition;
                }

                //Transaktion committen
                Session.Commit();

                if (qryFbZahlungsweg != null)
                {
                    qryFbZahlungsweg.RefreshDisplay();
                }
            }
            catch (Exception)
            {
                Session.Rollback();
                throw;
            }
        }

        private void qryFbKreditor_PositionChanged(object sender, EventArgs e)
        {
            if (qryFbZahlungsweg.Row != null)
            {
                qryFbZahlungsweg.Row.EndEdit();
                if (qryFbZahlungsweg.Row.RowState != DataRowState.Unchanged)
                {
                    if (!qryFbZahlungsweg.Post())
                    {
                        qryFbKreditor.Last();
                        return;
                    }
                }
            }

            qryFbZahlungsweg.Fill(@"
                SELECT
                  ZLW.*,
                  Finanzinstitut  = ISNULL(BNK.Name, 'PostFinance'),
                  BNK.ClearingNr,
                  BNK.BaBankId
                FROM dbo.FbZahlungsweg ZLW
                  LEFT JOIN dbo.BaBank BNK ON BNK.BaBankID = ZLW.BaBankID
                WHERE FbKreditorID = {0}
                ORDER BY BNK.Name;", qryFbKreditor["FbKreditorID"]);
        }

        private void qryFbZahlungsweg_PositionChanged(object sender, EventArgs e)
        {
            edtIBANErrorMsg.Text = "";
            edtIBANErrorMsg.Visible = false;

            if (IsInaktiveZahlungsart())
            {
                //allow every LOV-Code in the Lookup-Field
                edtZahlungsArt.LOVFilter = string.Empty;
                edtZahlungsArt.LOVFilterWhereAppend = true;
                edtZahlungsArt.ReadLOV();

                edtZahlungsArt.EditMode = EditModeType.ReadOnly;
                IsActive.EditMode = EditModeType.ReadOnly; //Ein Zahlungsweg mit einer inaktiven Zahlungsart darf nicht reaktiviert werden
            }
            else
            {
                //Filter out inactive LOV-Codes in the Lookup-Field
                edtZahlungsArt.LOVFilter = string.Format("Code NOT IN ({0}, {1})", (int)ZahlungsArt.Blau_Orange_ESR_ueber_Bank, (int)ZahlungsArt.BankUeberweisung);
                edtZahlungsArt.LOVFilterWhereAppend = true;
                edtZahlungsArt.ReadLOV();

                edtZahlungsArt.EditMode = EditModeType.Normal;
                IsActive.EditMode = EditModeType.Normal;
            }
        }

        private void qryKreditor_AfterFill(object sender, EventArgs e)
        {
            if (qryFbKreditor.Count == 0)
            {
                qryFbZahlungsweg.Fill(@"
                    SELECT
                      Z.*,
                      Finanzinstitut  = ISNULL(B.Name, 'PostFinance'),
                      B.ClearingNr,
                      B.BaBankId
                    FROM FbZahlungsweg Z
                      LEFT JOIN BaBank B ON B.BaBankID = Z.BaBankID
                    WHERE 1 = -1
                    ORDER BY B.Name;");
            }
        }

        private void qryKreditor_AfterInsert(object sender, EventArgs e)
        {
            qryFbKreditor["Aktiv"] = true;
            qryFbKreditor[DBO.FbKreditor.BaLandID] = Session.BaLandCodeSchweiz;
        }

        private void qryKreditor_BeforePost(object sender, EventArgs e)
        {
            kissPLZOrt1.DoValidate();

            DBUtil.CheckNotNullField(editName, lblName.Text);
            DBUtil.CheckNotNullField(kissPLZOrt1.EdtPLZ, KissMsg.GetMLMessage("CtlFibuKreditor", "Plz", "PLZ"));
            DBUtil.CheckNotNullField(kissPLZOrt1.EdtOrt, KissMsg.GetMLMessage("CtlFibuKreditor", "Ort", "Ort"));

            //Transaktion öffnen
            Session.BeginTransaction();
        }

        private void qryZahlungsweg_AfterInsert(object sender, EventArgs e)
        {
            qryFbZahlungsweg["IsActive"] = true;
        }

        private void qryZahlungsweg_BeforePost(object sender, EventArgs e)
        {
            qryFbZahlungsweg["FbKreditorID"] = qryFbKreditor["FbKreditorID"];

            bool isZahlungswegAktiv = (bool)qryFbZahlungsweg["IsActive"];
            if (isZahlungswegAktiv)
            {
                TryGenerateIban();

                //DataRow kredi= qryZahlungsweg.Row ;
                string error = FibuUtilities.CheckZahlungsWeg(qryFbZahlungsweg.Row, qryFbKreditor.Row, qryFbZahlungsweg["BaBankId"]);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    throw new KissInfoException(error);
                }
            }

            if (!DBUtil.IsEmpty(qryFbZahlungsweg["IBAN"]))
            {
                qryFbZahlungsweg["IBAN"] = ((string)qryFbZahlungsweg["IBAN"]).Replace(" ", string.Empty);
            }

            if (DBUtil.IsEmpty(qryFbZahlungsweg["Finanzinstitut"]))
            {
                qryFbZahlungsweg["Finanzinstitut"] = "PostFinance";
            }
        }

        private void xTabControl1_Enter(object sender, EventArgs e)
        {
            if (qryFbZahlungsweg.Post())
            {
                ActiveSQLQuery = qryFbKreditor;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            return "VmFibu";
        }

        public override void OnUndoDataChanges()
        {
            var isCanceled = qryFbZahlungsweg.Cancel();
            if (isCanceled)
            {
                qryFbKreditor.DataSet.RejectChanges();
                qryFbKreditor.RowModified = false;
                qryFbKreditor.Refresh();
            }
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            if (!DBUtil.IsEmpty(parameters["FbKreditorID"]))
            {
                bool foundKreditor = qryFbKreditor.Find("FbKreditorID=" + parameters["FbKreditorID"]);
                if (!foundKreditor)
                {
                    if (qryFbKreditor.Post())
                    {
                        tabControlSearch.SelectedTabIndex = 1;
                        NeueKreditorSuche();
                    }

                    Suchen();
                    qryFbKreditor.Find("FbKreditorID=" + parameters["FbKreditorID"]);
                }
            }

            if (!DBUtil.IsEmpty(parameters["FbZahlungswegID"]))
            {
                qryFbZahlungsweg.Find("FbZahlungswegID=" + parameters["FbZahlungswegID"]);
            }

            return true;
        }

        #endregion

        #region Private Methods

        private bool IsInaktiveZahlungsart()
        {
            return Utils.ConvertToInt(qryFbZahlungsweg[DBO.FbZahlungsweg.ZahlungsArtCode]) == (int)ZahlungsArt.Blau_Orange_ESR_ueber_Bank ||
                   Utils.ConvertToInt(qryFbZahlungsweg[DBO.FbZahlungsweg.ZahlungsArtCode]) == (int)ZahlungsArt.BankUeberweisung;
        }

        private void NeueKreditorSuche()
        {
            editSearchAktiv.Checked = true;
            editSearchAufwandKonto.Text = string.Empty;
            editSearchName.Text = string.Empty;
            editSearchPlz.Text = string.Empty;
            editSearchOrt.Text = string.Empty;
            editSearchStrasse.Text = string.Empty;
            editSearchName.Focus();
        }

        private void ReinitialiseZahlungsArtEditValues()
        {
            qryFbZahlungsweg["ZahlungsArtCode"] = edtZahlungsArt.EditValue;
            qryFbZahlungsweg["BaBankId"] = DBNull.Value;
            qryFbZahlungsweg["Finanzinstitut"] = DBNull.Value;
            qryFbZahlungsweg["BankKontoNr"] = DBNull.Value;
            qryFbZahlungsweg["PCKontoNr"] = DBNull.Value;
            qryFbZahlungsweg["ZahlungsFrist"] = DBNull.Value;
            qryFbZahlungsweg["IBAN"] = DBNull.Value;
        }

        private void Suchen()
        {
            string sql = string.Empty;

            // Name
            if (!string.IsNullOrWhiteSpace(editSearchName.Text))
            {
                string suchbegriff = editSearchName.Text;

                suchbegriff = suchbegriff.Replace("*", "%");
                sql += " AND NAME LIKE " + DBUtil.SqlLiteralLike("%" + suchbegriff + "%");
            }

            // Strasse
            if (!string.IsNullOrWhiteSpace(editSearchStrasse.Text))
            {
                string suchbegriff = editSearchStrasse.Text;

                suchbegriff = suchbegriff.Replace("*", "%");
                sql += " AND Strasse LIKE " + DBUtil.SqlLiteralLike("%" + suchbegriff + "%");
            }

            // PLZ
            if (!string.IsNullOrWhiteSpace(editSearchPlz.Text))
            {
                string plzSuchbegriff = editSearchPlz.Text.Replace("*", "%");
                sql += " AND PLZ LIKE " + DBUtil.SqlLiteralLike("%" + plzSuchbegriff + "%");
            }

            // Ort
            if (!string.IsNullOrWhiteSpace(editSearchOrt.Text))
            {
                string ortSuchbegriff = editSearchOrt.Text.Replace("*", "%");
                sql += " AND Ort LIKE " + DBUtil.SqlLiteralLike("%" + ortSuchbegriff + "%");
            }

            // AufwandKonto
            if (!string.IsNullOrWhiteSpace(editSearchAufwandKonto.Text))
            {
                sql += " AND AufwandKonto = " + DBUtil.SqlLiteral(editSearchAufwandKonto.Text);
            }

            // Aktiv
            if (editSearchAktiv.CheckState != CheckState.Indeterminate)
            {
                sql += " AND Aktiv = " + Convert.ToInt32(editSearchAktiv.Checked);
            }

            // Stichtag
            if (!DBUtil.IsEmpty(edtStichtag.EditValue))
            {
                // Buchungsdatum vor Stichtag
                string helperString = string.Format(" WHERE TMP.Buchungsdatum <= {0} ", DBUtil.SqlLiteral(edtStichtag.DateTime));

                sql = @"--SQLCHECK_IGNORE--
                    SELECT
                      FbKreditorID,
                      Name,
                      KurzName,
                      Zusatz,
                      Strasse,
                      PLZ,
                      Ort,
                      Aktiv,
                      AufwandKonto,
                      FbKreditorTS,
                      Buchungsdatum
                    FROM (SELECT
                            KRE.FbKreditorID,
                            KRE.Name,
                            KRE.KurzName,
                            KRE.Zusatz,
                            KRE.Strasse,
                            KRE.PLZ,
                            KRE.Ort,
                            KRE.Aktiv,
                            KRE.AufwandKonto,
                            KRE.Creator,
                            KRE.Created,
                            KRE.Modifier,
                            KRE.Modified,
                            KRE.FbKreditorTS,
                            Buchungsdatum = (SELECT TOP 1 BUC.BuchungsDatum
                                             FROM dbo.FbBuchung BUC
                                               INNER JOIN dbo.FbZahlungsweg ZAH ON ZAH.FbZahlungswegID = BUC.FbZahlungswegID
                                             WHERE ZAH.FbKreditorID = KRE.FbKreditorID
                                             ORDER BY BUC.buchungsdatum DESC)
                          FROM dbo.FbKreditor KRE
                          WHERE 1 = 1 " + sql + @") TMP " + helperString + " ORDER BY TMP.Name;";

                //Spalte colLetzteBuchung sichtbar machen
                colLetzteBuchung.Visible = true;
                btnAlleKreditorenDeaktivieren.Visible = true;
            }
            else
            {
                sql = @"SELECT
                          FbKreditorID,
                          Name,
                          KurzName,
                          Zusatz,
                          Strasse,
                          PLZ,
                          Ort,
                          Aktiv,
                          AufwandKonto,
                          Creator,
                          Created,
                          Modifier,
                          Modified,
                          FbKreditorTS
                        FROM dbo.FbKreditor WHERE 1=1 " + sql + " ORDER BY Name;";
                colLetzteBuchung.Visible = false;
                btnAlleKreditorenDeaktivieren.Visible = false;
            }

            qryFbKreditor.Fill(sql);

            tabControlSearch.SelectedTabIndex = 0;
        }

        private void TryGenerateIban()
        {
            int ezCode = Utils.ConvertToInt(edtZahlungsArt.EditValue);

            if (ezCode == 0)
            {
                return;
            }

            edtIBANErrorMsg.Text = "";
            edtIBANErrorMsg.Visible = false;

            try
            {
                string iban;

                if (ezCode == 3)
                {
                    //Roter Einzahlungsschein Post

                    //Entgegen früherer Meinung darf bei Roter ES Post keine IBAN generiert werden.
                    //Das kommt erst mit den neuen Einzahlungsscheinen (mit QR Code).
                    //Sonst schlägt die Validierung im neuen Zahlungsformat ISO 20022 fehl.

                    //IBAN generieren für PC-Konti, Format ist "xx-yyyyyy-p"
                    //iban = Belegleser.IBANConvert(edtPostKontoNr.Text, "9000");
                    //qryFbZahlungsweg[DBO.FbZahlungsweg.IBAN] = iban;
                }
                else if (ezCode == 5 || ezCode == 4)
                {
                    //Bankzahlung Schweiz + Roter Einzahlungsschein Bank

                    if (!string.IsNullOrEmpty(edtBankKontoNr.Text) && !string.IsNullOrEmpty(Utils.ConvertToString(qryFbZahlungsweg["ClearingNr"])))
                    {
                        // KontoNr und BCL vorhanden
                        // IBAN aus Bankkontonummer und Bank (Clearingnummer)
                        iban = Belegleser.IBANConvert(edtBankKontoNr.Text, Utils.ConvertToString(qryFbZahlungsweg["ClearingNr"]));
                        var ibanBefore = qryFbZahlungsweg[DBO.FbZahlungsweg.IBAN] as string;

                        if (string.IsNullOrEmpty(ibanBefore))
                        {
                            qryFbZahlungsweg[DBO.FbZahlungsweg.IBAN] = iban;
                        }
                        else
                        {
                            // neue IBAN mit bestehender vergleichen
                            if (iban.Replace(" ", "") != ibanBefore.Replace(" ", ""))
                            {
                                throw new Exception(KissMsg.GetMLMessage(Name, "NonMatchingIBANWithPrevious", "Generierte IBAN {0} stimmt nicht mir bisheriger ({1}) überein. Löschen Sie die bestehende IBAN oder korrigieren Sie die Kontonummer / Clearingnummer.", iban, ibanBefore));
                            }

                            // sonst stimmts ja, also kein Speichern der IBAN nötig
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                edtIBANErrorMsg.Text = ex.Message;
                edtIBANErrorMsg.Visible = true;
            }
        }

        #endregion

        #endregion
    }
}