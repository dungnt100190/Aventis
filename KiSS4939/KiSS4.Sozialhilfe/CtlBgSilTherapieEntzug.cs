using System;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe
{
    public partial class CtlBgSilTherapieEntzug : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly int _bgBudgetID;
        private readonly int _bgFinanzplanID;
        private readonly SqlQuery _qryBgFinanzplan;
        private readonly SqlQuery _qryBgPositionsart;

        private const LOV.BgGruppeCode BG_GRUPPE_CODE = LOV.BgGruppeCode.Leistungen_fuer_Therapie_und_Entzugsmassnahmen;

        #endregion

        #region Private Fields

        private DateTime _anpassenVon;
        private bool _bAnpassen;
        private int _bgPositionID;

        #endregion

        #endregion

        #region Constructors

        public CtlBgSilTherapieEntzug(Image titelImage, string titelText, int bgBudgetID)
            : this()
        {
            picTitle.Image = titelImage;
            _bgBudgetID = bgBudgetID;

            _qryBgFinanzplan = DBUtil.OpenSQL(@"
                SELECT FLE.FaFallID, FLE.FaLeistungID, SFP.BgFinanzplanID,
                  BgBewilligungStatusCode = CASE WHEN FLE.DatumBis IS NOT NULL THEN 9 ELSE SFP.BgBewilligungStatusCode END,
                  FinanzplanVon = IsNull(SFP.DatumVon, SFP.GeplantVon),
                  FinanzplanBis = IsNull(SFP.DatumBis, SFP.GeplantBis),
                  AnpassenVon   = IsNull((SELECT MAX(DATEADD(m, 1, dbo.fnDateSerial(Jahr, Monat, 1))) FROM BgBudget
                                          WHERE BgFinanzplanID = SFP.BgFinanzplanID AND MasterBudget = 0
                                            AND BgBewilligungStatusCode >= 5), SFP.GeplantVon),
                  AnpassenBis   = SFP.DatumBis
                FROM BgBudget             BBG
                  INNER JOIN BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = SFP.FaLeistungID
                WHERE BBG.BgBudgetID = {0}"
                , bgBudgetID);
            _bgFinanzplanID = Utils.ConvertToInt(_qryBgFinanzplan["BgFinanzplanID"]);
            lblTitel.Text = string.Format(lblTitel.Text, _qryBgFinanzplan["FinanzplanVon"], _qryBgFinanzplan["FinanzplanBis"], titelText);

            btnAnpassen.Enabled = false;
            btnBewilligung.Enabled = false;

            if ((int)_qryBgFinanzplan["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt)
            {
                btnAnpassen.Enabled = qryBgPosition.CanUpdate;
                qryBgPosition.CanUpdate = false;

                edtDatumVon.EditMode = EditModeType.ReadOnly;
            }
            else if ((int)_qryBgFinanzplan["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Gesperrt)
            {
                qryBgPosition.CanInsert = false;
                qryBgPosition.CanUpdate = false;
                qryBgPosition.CanDelete = false;
            }
            else
            {
                edtBetrag.EditMode = EditModeType.Required;
                edtBgPositionsartID.EditMode = EditModeType.Required;
                edtInstitution.EditMode = EditModeType.Required;
                edtDatumVon.EditMode = EditModeType.Required;
                edtDatumBis.EditMode = EditModeType.Required;
            }

            //zur Bestimmung der gültigen BgPositionsartIDs wird der Gültigkeitsbereich des Finanzplans verwendet.
            DateTime datumVon = Utils.ConvertToDateTime(_qryBgFinanzplan["FinanzplanVon"]);
            DateTime datumBis = Utils.ConvertToDateTime(_qryBgFinanzplan["FinanzplanBis"]);

            _qryBgPositionsart = ShUtil.GetSqlQueryShPositionTyp(BG_GRUPPE_CODE, datumVon, datumBis, true);
            colBgPositionsartID.ColumnEdit = grdBgPosition.GetLOVLookUpEdit(_qryBgPositionsart);
            edtBgPositionsartID.LoadQuery(_qryBgPositionsart);

            colBewStatus.ColumnEdit = grdBgPosition.GetLOVLookUpEdit("BgBewilligungStatus");

            SqlQuery qry = ShUtil.GetPersonen_Unterstuetzt(_bgBudgetID);
            colBaPersonID.ColumnEdit = grdBgPosition.GetLOVLookUpEdit(qry, "BaPersonID", "NameVorname");
            edtBaPersonID.LoadQuery(qry, "BaPersonID", "NameVorname");

            qryBgPosition.Fill(qryBgPosition.SelectStatement, _bgBudgetID, BG_GRUPPE_CODE);
        }

        public CtlBgSilTherapieEntzug()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnAnpassen_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            if (_bAnpassen)
            {
                _bAnpassen = false;

                btnAnpassen.Text = "bewilligte Beträge anpassen...";
                colDatumVon.VisibleIndex = 0;

                // Das Benutzen von DataTable.DefaultView.RowFilter führt zu unerwünschten Effekten,
                // deshalb wird diese Zeile vorerst ausgeschaltet
                //qryBgPosition.DataTable.DefaultView.RowFilter = "";

                qryBgPosition.CanUpdate = false;
                qryBgPosition.EnableBoundFields(false);

                qryBgPosition.Refresh();
                return;
            }

            DlgWhPositionAnpassen dlg = new DlgWhPositionAnpassen("Anpassung Ambulante erzieherische Hilfe",
                "Die neuen Ansätze werden automatisch im Masterbudget sowie in sämtlichen noch nicht freigegebenen Monatsbudgets vom unten stehenden Monat an nachgeführt.",
                "Die neue Ambulante erz. Hilfe gilt ab"
                , (DateTime)_qryBgFinanzplan["AnpassenVon"], (DateTime)_qryBgFinanzplan["AnpassenBis"]);

            dlg.ShowDialog(this);

            if (dlg.UserCancel)
                return;

            _bAnpassen = true;
            _anpassenVon = dlg.DatumVon;

            btnAnpassen.Text = "Bearbeitung abschliessen";
            colDatumVon.VisibleIndex = -1;

            // Das Benutzen von DataTable.DefaultView.RowFilter führt zu unerwünschten Effekten,
            // deshalb wird diese Zeile vorerst ausgeschaltet
            //qryBgPosition.DataTable.DefaultView.RowFilter = string.Format("Anpassung = 1 OR (IsNull(DatumVon, {0}) <= {0} AND (DatumBis > {0} OR DatumBis IS NULL))"
            //    , AnpassenVon.ToString(@"\#MM\/dd\/yyyy\#"));

            qryBgPosition.CanUpdate = true;
            qryBgPosition.EnableBoundFields(true);

            if (qryBgPosition.Count == 0)
            {
                qryBgPosition.Insert();
            }
        }

        private void btnBewilligung_Click(object sender, EventArgs e)
        {
            if (_bAnpassen)
            {
                btnAnpassen.PerformClick();
                if (_bAnpassen)
                    return;
            }

            BgBewilligungStatus bewilligungStatus = (BgBewilligungStatus)qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode];
            DlgBewilligung dlg = new DlgBewilligung(BewilligungTyp.SIL, _bgPositionID, bewilligungStatus, HasPermission);
            dlg.ShowDialog(this);

            if (!dlg.UserCancel)
            {
                ShUtil.ApplyActionSil(dlg, qryBgPosition, (int)_qryBgFinanzplan[DBO.BgFinanzplan.BgFinanzplanID]);
            }
        }

        private void edtInstitution_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtInstitution.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BaInstitutionID"] = DBNull.Value;
                    qryBgPosition["InstitutionName"] = DBNull.Value;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            DateTime stichTag = _bAnpassen ? _anpassenVon : (DateTime)_qryBgFinanzplan["FinanzplanVon"];
            e.Cancel = !dlg.InstitutionSuchenWh(searchString, true, stichTag, e.ButtonClicked);

            if (!e.Cancel)
            {
                qryBgPosition[DBO.BgPosition.BaInstitutionID] = dlg["ID$"];
                qryBgPosition["InstitutionName"] = dlg["Institution"];
            }
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryBgPosition["BgBudgetID"] = _bgBudgetID;
            qryBgPosition["BgKategorieCode"] = 2;

            if (_bAnpassen)
                qryBgPosition["DatumVon"] = _anpassenVon;
            else
                qryBgPosition["DatumVon"] = _qryBgFinanzplan["FinanzplanVon"];

            //qryBgPosition["DatumBis"] = qryBgFinanzplan["FinanzplanBis"];

            edtBaPersonID.Focus();
        }

        private void qryBgPosition_AfterPost(object sender, EventArgs e)
        {
            Session.Commit();

            //Budget runden
            DBUtil.ExecSQLThrowingException("EXEC spWhBudget_Runden {0}", _bgBudgetID);

            //Die StoredProcedure überprüft die editierte Masterbudget-Position und erstellt gegebenenfalls eine Nachfolge-Position,
            //falls eine Positionsart verwendet wurde, die während der Finanzplan-Laufzeit terminiert wurde.
            DBUtil.ExecSQLThrowingException("EXEC spWhPositionsart_Masterbudget_Terminieren {0}, {1}", _bgFinanzplanID, qryBgPosition["BgPositionsartID"]);

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            qryBgPosition.RowModified = false;
            qryBgPosition.Refresh();
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if ((int)qryBgPosition["BgBewilligungStatusCode"] >= (int)BgBewilligungStatus.Erteilt
                || 0 < (int)DBUtil.ExecuteScalarSQL("SELECT COUNT(*) FROM BgPosition WHERE BgBudgetID = {0} AND BgPositionID_CopyOf = {1}",
                    qryBgPosition["BgBudgetID"], qryBgPosition["BgPositionID"]))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlBgSilTherapieEntzug", "NichtLoeschen",
                        "Bewilligte oder angepasste Positionen können nicht mehr gelöscht werden",
                        KissMsgCode.MsgInfo)
                    );
            }
        }

        private void qryBgPosition_BeforeInsert(object sender, EventArgs e)
        {
            if (btnAnpassen.Enabled && !_bAnpassen)
            {
                btnAnpassen.PerformClick();
            }

            if (!_bAnpassen && (int)_qryBgFinanzplan["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Erteilt)
            {
                throw new KissCancelException();
            }
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);
            DBUtil.CheckNotNullField(edtBgPositionsartID, lblBgPositionsartID.Text);
            DBUtil.CheckNotNullField(edtInstitution, lblInstitution.Text);
            DBUtil.CheckNotNullField(edtDatumVon, lblVon.Text);
            DBUtil.CheckNotNullField(edtDatumBis, lblBis.Text);

            if (!DBUtil.IsEmpty(edtDatumVon.EditValue))
            {
                if (
                    (DateTime)_qryBgFinanzplan["FinanzPlanVon"] > (DateTime)edtDatumVon.EditValue ||
                    (DateTime)_qryBgFinanzplan["FinanzPlanBis"] < (DateTime)edtDatumVon.EditValue
                )
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            "CtlBgSilTherapieEntzug",
                            "GeplantInnerhFinanzpl",
                            "Geplant von muss innerhalb von Zeitspanne des Finanzplanes liegen ({0:d} - {1:d}).",
                            KissMsgCode.MsgInfo,
                            _qryBgFinanzplan["FinanzPlanVon"],
                            _qryBgFinanzplan["FinanzPlanBis"]
                        )
                    );
                }

                if (!DBUtil.IsEmpty(edtDatumBis.EditValue))
                {
                    if ((DateTime)edtDatumBis.EditValue < (DateTime)edtDatumVon.EditValue)
                    {
                        edtDatumVon.Focus();
                        throw new KissInfoException(
                            KissMsg.GetMLMessage(
                                "CtlBgSilTherapieEntzug",
                                "GeplantVonZuGross",
                                "Geplant von muss kleiner sein als geplant bis."
                            )
                        );
                    }
                }
            }

            if (Utils.ConvertToDecimal(edtBetrag.EditValue) <= (decimal)0.0)
            {
                edtBetrag.Focus();
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        "CtlBgSilTherapieEntzug",
                        "BetragGroesserNull",
                        "Der Betrag muss grösser als 0.00 sein."
                    )
                );
            }

            if ((DBUtil.IsEmpty(qryBgPosition["Buchungstext"]) || qryBgPosition.ColumnModified("BgPositionsartID"))
                && _qryBgPositionsart.Find(string.Format("BgPositionsartID = {0}", qryBgPosition["BgPositionsartID"])))
            {
                qryBgPosition["Buchungstext"] = _qryBgPositionsart["Name"];
            }

            Session.BeginTransaction();
            try
            {
                if (_bAnpassen)
                {
                    qryBgPosition["DatumVon"] = _anpassenVon;
                    qryBgPosition["Anpassung"] = 1;

                    if (!DBUtil.IsEmpty(qryBgPosition["BgPositionID"]))
                    {
                        SqlQuery qry = DBUtil.OpenSQL(@"
                        SELECT DISTINCT BgPositionID AS Pk, BgPositionID_Parent AS Parent, CONVERT(int, NULL) AS KeyNew
                        INTO #BgPosition
                        FROM BgPosition WHERE BgBudgetID = {0} AND (BgPositionID = {1} OR BgPositionID_Parent = {1})

                        EXECUTE spXParentChildCopy '#BgPosition',
                                                   'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                                                   'BgPositionID_CopyOf', 'BgPositionID', 'OldID, BgBewilligungStatusCode'

                        SELECT BPO.*, TMP.Pk
                        FROM #BgPosition           TMP
                          INNER JOIN vwBgPosition  BPO ON BPO.BgPositionID = TMP.KeyNew
                        ORDER BY CASE WHEN Pk = {0} THEN 0 ELSE 1 END

                        DROP TABLE #BgPosition"
                                , _bgBudgetID, qryBgPosition["BgPositionID"]);

                        string[] columnNames = new string[] { "BgPositionID", "BgPositionID_CopyOf", "BgBewilligungStatusCode", "BgPositionTS" };

                        object[] currentValue = qryBgPosition.Row.ItemArray;

                        qryBgPosition.Row.RejectChanges();

                        foreach (string columnName in columnNames)
                        {
                            if (qryBgPosition.DataTable.Columns.Contains(columnName))
                                qryBgPosition[columnName] = qry[columnName];
                        }

                        qryBgPosition.Row.AcceptChanges();

                        qryBgPosition.Row.ItemArray = currentValue;

                        foreach (string columnName in columnNames)
                        {
                            if (qryBgPosition.DataTable.Columns.Contains(columnName))
                                qryBgPosition[columnName] = qry[columnName];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            int bgBewilligungStatusCode;

            try
            {
                bgBewilligungStatusCode = (int)qryBgPosition["BgBewilligungStatusCode"];
            }
            catch
            {
                bgBewilligungStatusCode = (int)BgBewilligungStatus.Erteilt;
            }

            if (!qryBgPosition.IsEmpty && qryBgPosition[DBO.BgPosition.BgPositionID] != DBNull.Value)
            {
                _bgPositionID = (int)qryBgPosition[DBO.BgPosition.BgPositionID];
            }

            btnBewilligung.Enabled = btnAnpassen.Enabled && bgBewilligungStatusCode < (int)BgBewilligungStatus.Erteilt;
        }

        #endregion

        #region Methods

        #region Private Methods

        private bool HasPermission()
        {
            return ShUtil.HasPermissionSil(_bgPositionID);
        }

        #endregion

        #endregion
    }
}