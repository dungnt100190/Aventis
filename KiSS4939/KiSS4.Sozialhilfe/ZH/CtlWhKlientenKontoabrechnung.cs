using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhKlientenKontoabrechnung : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly int _baPersonID = -1;
        private readonly int _faFallID;

        #endregion

        #region Private Fields

        private int _adressatID = -1;
        private Dictionary<int, Color> _colors;

        #endregion

        #endregion

        #region Constructors

        public CtlWhKlientenKontoabrechnung(Image titelImage, string titelText, int baPersonID, int faFallID)
            : this()
        {
            SetColors();
            picTitel.Image = titelImage;
            lblTitel.Text = titelText;
            _baPersonID = baPersonID;
            _faFallID = faFallID;
            qryAbrechnung.Fill(_baPersonID, Session.User.UserID);

            var abrechnungID = qryAbrechnung["WhAbrechnungID"] as int?;
            InitDetailViewsForAbrechnung(abrechnungID ?? -1);

            //make sure, the first tab (Abrechnung) is selected (regardless of the selected tab in the designer)
            tabAbrechnung.SelectTab(tpgAbrechnung);
        }

        public CtlWhKlientenKontoabrechnung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnDokumenteDrucken_Click(object sender, EventArgs e)
        {
            if (qryAbrechnung.Position < 0)
            {
                KissMsg.ShowInfo("Es wurde keine Abrechnung ausgewählt.");
                return;
            }

            string drucker = (string)edtDrucker.SelectedItem;
            string dokument = "des Abrechnungsblatts";
            try
            {
                var currentCursor = Cursor.Current;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    CheckIfDocumentsAreOpen();

                    var printTasks = new List<Task>();

                    printTasks.Add(docAbrechnung.PrintDoc(drucker));

                    dokument = "der Detailblätter";
                    printTasks.AddRange(DruckenDetailblaetter(drucker));

                    dokument = "des Ergänzungsblatts";
                    printTasks.Add(docErgaenzung.PrintDoc(drucker));

                    dokument = "der offenen Forderungen";
                    printTasks.Add(docForderung.PrintDoc(drucker));

                    Task.WaitAll(printTasks.Where(x => x != null).ToArray());
                }
                finally
                {
                    Cursor.Current = currentCursor;
                }
            }
            catch (KissInfoException ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
            catch (KissErrorException ex)
            {
                KissMsg.ShowError(string.Format("Fehler beim Drucken {0}: \r\n{1}", dokument, ex.Message), ex);
            }
        }

        private void btnVisumAnfragen_Click(object sender, EventArgs e)
        {
            if (qryAbrechnung.Position < 0)
            {
                KissMsg.ShowInfo("Es wurde keine Abrechnung ausgewählt.");
                return;
            }

            if (DBUtil.IsEmpty(qryAbrechnung["DocumentID"]))
            {
                KissMsg.ShowInfo("Das Abrechnungsdokument wurde noch nicht erstellt.");
                return;
            }

            if ((int)qryAbrechnung["WhAbrechnungVisumCode"] != 1 &&
                (int)qryAbrechnung["WhAbrechnungVisumCode"] != 2 &&
                (int)qryAbrechnung["WhAbrechnungVisumCode"] != 4) // in Vorbereitung, angefragt, abgelehnt
            {
                if ((int)qryAbrechnung["WhAbrechnungVisumCode"] == 3)
                {
                    KissMsg.ShowInfo("Das Visum wurde bereits erteilt.");
                }
                else
                {
                    KissMsg.ShowInfo("Die Abrechnung befindet sich in einem ungültigen Zustand.");
                }

                return;
            }

            //sicherstellen, dass der Datensatz unverändert ist, sonst gibt beim speichern der Visum-Anfrage eine Concurrent-Modification-Exception
            qryAbrechnung.Post();

            try
            {
                using (var dlg = new DlgWhKontoabrechnungAnfragen((int)qryAbrechnung["WhAbrechnungID"]))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        qryAbrechnung.Refresh();
                        ctlErgaenzungen.SetEditMode(EditModeType.ReadOnly);
                        ctlOffeneForderungen.SetEditMode(EditModeType.ReadOnly);
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void btnVisumErteilen_Click(object sender, EventArgs e)
        {
            if (qryAbrechnung.Position < 0)
            {
                KissMsg.ShowInfo("Es wurde keine Abrechnung ausgewählt.");
                return;
            }

            if ((int)qryAbrechnung["WhAbrechnungVisumCode"] != 2) // angefragt
            {
                if ((int)qryAbrechnung["WhAbrechnungVisumCode"] == 1)
                {
                    KissMsg.ShowInfo("Das Visum muss zuerst angefragt werden bevor es erteilt werden kann.");
                }
                else if ((int)qryAbrechnung["WhAbrechnungVisumCode"] == 3)
                {
                    KissMsg.ShowInfo("Das Visum wurde bereits erteilt.");
                }
                else if ((int)qryAbrechnung["WhAbrechnungVisumCode"] == 4)
                {
                    KissMsg.ShowInfo("Das Visum wurde bereits abgelehnt.");
                }
                else
                {
                    KissMsg.ShowInfo("Die Abrechnung befindet sich in einem ungültigen Zustand.");
                }

                return;
            }

            bool isSachbearbeiter = WhUtil.IsSachbearbeiter();
            bool isNotMemberOfGleichesQt = !WhUtil.IsMemberOfGleichesQt(Utils.ConvertToInt(qryAbrechnung["UserID_AnfrageAn"]), Session.User.UserID, Utils.ConvertToInt(qryAbrechnung["UserID_Fall"]));
            bool isMemberOfGleichesSz = WhUtil.IsMemberOfGleichesSz(Utils.ConvertToInt(qryAbrechnung["UserID_AnfrageAn"]), Session.User.UserID, Utils.ConvertToInt(qryAbrechnung["UserID_Fall"]));

            if (isMemberOfGleichesSz && isSachbearbeiter && Session.User.UserID == (int)qryAbrechnung["UserID_AnfrageVon"])
            {
                KissMsg.ShowInfo("Sie können ihre eigenen Abrechnungen nicht selber bewilligen (4-Augen Prinzip)");
                return;
            }

            if (isSachbearbeiter ||
                !isMemberOfGleichesSz ||
                (Utils.ConvertToInt(qryAbrechnung["UserAnPermissionGroup"]) != 4 && // ist nicht Stellenleiter
                 Utils.ConvertToInt(qryAbrechnung["UserID_AnfrageAn"]) != Session.User.UserID && // ist nicht angefragt
                 isNotMemberOfGleichesQt))
            {
                KissMsg.ShowInfo("Sie haben nicht die nötigen Berechtigungen, um die Abrechnung zu visieren.");
                return;
            }

            //sicherstellen, dass der Datensatz unverändert ist, sonst gibt beim Visum-Erteilen eine Concurrent-Modification-Exception
            qryAbrechnung.Post();

            try
            {
                using (var dlg = new DlgWhKontoabrechnungVisieren(Utils.ConvertToInt(qryAbrechnung["WhAbrechnungID"])))
                {
                    if (dlg.ShowDialog(this) != DialogResult.Cancel)
                    {
                        qryAbrechnung.Refresh();
                        SetEditModeAbrechnung();
                        qryDetailblatt.Refresh();
                        SetEditModeDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void docAbrechnung_DocumentCreated(object sender, EventArgs e)
        {
            SetEditModeAbrechnung();
            SetEditModeDetail();
        }

        private void docAbrechnung_DocumentCreating(object sender, CancelEventArgs e)
        {
            object abrechnungID = qryAbrechnung["WhAbrechnungID"];
            if (!DBUtil.IsEmpty(abrechnungID))
            {
                edtAdressat.CheckPendingSearchValue();
                //edtAbrechnungVon.CompleteChanges();
                qryAbrechnung.Post();
                qryCheck.Fill(abrechnungID);
                if (qryCheck.Count > 0)
                {
                    qryCheck.Position = 0;
                    KissMsg.ShowInfo((string)qryCheck["Fehlermeldung"]);
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel = true;
                KissMsg.ShowInfo("Keine Abrechnung ausgewählt.");
            }
        }

        private void docAbrechnung_DocumentDeleted(object sender, EventArgs e)
        {
            qryAbrechnung["DocumentID"] = DBNull.Value;
            qryPersonenInkl.Post();
            qryPersonenInkl.Fill(qryDetailblatt["WhDetailblattID"]);
            SetEditModeAbrechnung();
            SetEditModeDetail();
        }

        private void docDetail_DocumentCreating(object sender, CancelEventArgs e)
        {
            if (qryDetailblatt.Position < 0)
            {
                KissMsg.ShowInfo("Kein Detailblatt ausgewählt!");
                e.Cancel = true;
                return;
            }
            // work-around für z.T. fehlerhaftes Data-Binding
            edtDetailVon.DoValidate();
            qryDetailblatt["DatumVon"] = edtDetailVon.EditValue;
            edtDetailBis.DoValidate();
            qryDetailblatt["DatumBis"] = edtDetailBis.EditValue;
            // Ende work-around
            if (!qryDetailblatt.Post())
            {
                e.Cancel = true;
                return;
            }
            if (DBUtil.IsEmpty(qryDetailblatt["DatumVon"]) || DBUtil.IsEmpty(qryDetailblatt["DatumBis"]) ||
                ((DateTime)qryDetailblatt["DatumVon"]).Day != 1 || ((DateTime)qryDetailblatt["DatumBis"]).AddDays(1).Day != 1)
            {
                KissMsg.ShowInfo("Eine Periode eines Detailblatts muss am ersten Tag eines Monats anfangen und am letzten Tag eines Monats enden.");
                e.Cancel = true;
                return;
            }
            try
            {
                qryPersonenInkl.Post();
                e.Cancel = false;
                int detailblattID = (int)qryDetailblatt["WhDetailblattID"];
                qryDetailblatt["TotalAusgabenKlient"] =
                    DBUtil.ExecuteScalarSQLThrowingException("SELECT CASE WHEN SUM(Betrag) IS NULL THEN 0 ELSE ABS(SUM(Betrag)) END FROM dbo.fnWhAbrechnung({0}, 'A', '', NULL, '2,100,101')",
                        detailblattID);
                qryDetailblatt["TotalAusgabenDritte"] =
                    DBUtil.ExecuteScalarSQLThrowingException("SELECT CASE WHEN SUM(Betrag) IS NULL THEN 0 ELSE ABS(SUM(Betrag)) END FROM dbo.fnWhAbrechnung({0}, 'A', 'D', NULL, '2,100,101')",
                    detailblattID);
                qryDetailblatt["TotalVerrechnungRueckerstattung"] =
                    DBUtil.ExecuteScalarSQLThrowingException("SELECT CASE WHEN SUM(Betrag) IS NULL THEN 0 ELSE ABS(SUM(Betrag)) END FROM dbo.fnWhAbrechnung({0}, 'E', '', NULL, '3')",
                    detailblattID);
                qryDetailblatt["TotalEinnahmenKlient"] =
                    DBUtil.ExecuteScalarSQLThrowingException("SELECT CASE WHEN SUM(Betrag) IS NULL THEN 0 ELSE ABS(SUM(Betrag)) END FROM dbo.fnWhAbrechnung({0}, 'E', '', '', '1')",
                    detailblattID);
                qryDetailblatt["TotalEinnahmenSD"] =
                    DBUtil.ExecuteScalarSQLThrowingException("SELECT CASE WHEN SUM(Betrag) IS NULL THEN 0 ELSE ABS(SUM(Betrag)) END FROM dbo.fnWhAbrechnung({0}, 'E', '', 'S', '1')",
                    detailblattID);

                qryDetailblatt.Post();
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                e.Cancel = true;
            }
        }

        private void docDetail_DocumentDeleted(object sender, EventArgs e)
        {
            qryDetailblatt["DocumentID"] = DBNull.Value;
            SetEditModeAbrechnung();
            SetEditModeDetail();
        }

        private void docErgaenzung_DocumentCreated(object sender, EventArgs e)
        {
            //qryAbrechnung.Refresh(); //löst exception in xdocoument.OnButtonNewDoc aus
            // work-around: manell das Flag setzen:
        }

        private void docErgaenzung_DocumentCreating(object sender, CancelEventArgs e)
        {
            if (qryDetailblatt.Position < 0)
            {
                KissMsg.ShowInfo("Kein Detailblatt ausgewählt!");
                e.Cancel = true;
                return;
            }
            qryDetailblatt.Post();
            qryPersonenInkl.Post();
        }

        private void docForderung_DocumentCreated(object sender, EventArgs e)
        {
            qryAbrechnung.Refresh();
        }

        private void edtAdressat_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = null;
            if (edtAdressat.EditValue != null)
            {
                searchString = edtAdressat.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            }

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    _adressatID = -1;
                    edtAdressat.EditValue = null;
                    return;
                }
            }

            string sql;
            if (searchString == ".")
            {
                // Wenn nur ein Punkt eingegeben wurde,
                // dann soll nur in den FallPersonen und involvierten Institutionen gesucht werden:
                sql = @"
                    DECLARE @faFallID int
                    SET @faFallID = {1}

                    SELECT BaPersonID$ = PRS.BaPersonID,
                           Name        = PRS.VornameName,
                           Strasse     = PRS.WohnsitzStrasseHausNr,
                           Ort         = PRS.WohnsitzPLZOrt
                    FROM dbo.FaFallPerson FPR WITH (READUNCOMMITTED)
                      INNER JOIN dbo.vwPerson2 PRS WITH (READUNCOMMITTED) on PRS.BaPersonID = FPR.BaPersonID
                    WHERE FPR.FaFallID = @faFallID
                    ORDER BY Name";
            }
            else
            {
                sql = @"
                    SELECT BaPersonID$ = PRS.BaPersonID,
                           Name        = PRS.NameVorname,
                           Strasse     = PRS.WohnsitzStrasseHausNr,
                           Ort         = PRS.WohnsitzPLZOrt
                    FROM dbo.vwPerson2 PRS WITH (READUNCOMMITTED)
                    WHERE PRS.NameVorname LIKE '%' + {0} + '%'
                    ORDER BY PRS.NameVorname";
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql,
              searchString,
              e.ButtonClicked, _faFallID, null);

            if (!e.Cancel)
            {
                _adressatID = (int)dlg["BaPersonID$"];
                //edtAdressat.EditValue = dlg["Name"];
                qryAbrechnung["BaPersonID"] = _adressatID;
                qryAbrechnung.RowModified = true;
                qryAbrechnung.Post();
                qryAbrechnung.Refresh();
            }
        }

        private void edtDatumBis_Validated(object sender, EventArgs e)
        {
            ValidateBis(sender);
        }

        private void edtDatumVon_Validated(object sender, EventArgs e)
        {
            ValidateVon(sender);
        }

        private void grdKlientenabrechnung_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Base.BaseView newView = e.View;
                qryDetailblatt.Post();
                qryPersonenInkl.Post();
                if (newView != null && newView != grvAbrechnung)
                {
                    if (newView.SourceRowHandle >= 0 && newView.SourceRowHandle < qryAbrechnung.Count)
                    {
                        // zum debuggen abgewählt
                        qryAbrechnung.Position = newView.SourceRowHandle; // master row handle
                    }
                    int focusedRowHandle = ((DevExpress.XtraGrid.Views.Grid.GridView)newView).FocusedRowHandle;
                    if (focusedRowHandle >= 0 && !newView.IsLoading)
                    {
                        DataRowView row = (DataRowView)newView.GetRow(focusedRowHandle);
                        if (row != null)
                        {
                            int detailblattID = (int)row["WhDetailblattID"];
                            InitDetailViewsForDetailblatt(detailblattID);
                        }
                        else
                        {
                            InitDetailViewsForDetailblatt(-1);
                        }
                    }
                    else
                    {
                        InitDetailViewsForDetailblatt(-1);
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void grvDetail_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            qryDetailblatt.Post();
            qryPersonenInkl.Post();
        }

        private void grvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                qryDetailblatt.Post();
                qryPersonenInkl.Post();

                int rowNr = e.FocusedRowHandle;
                DevExpress.XtraGrid.Views.Grid.GridView detailView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
                if (!detailView.IsLoading)
                {
                    DataRowView row = (DataRowView)detailView.GetRow(rowNr);
                    if (row != null)
                    {
                        int? detailID = (int?)row["WhDetailblattID"];
                        InitDetailViewsForDetailblatt(detailID ?? -1);
                    }
                    else
                    {
                        InitDetailViewsForDetailblatt(-1);
                        InitDetailViewsForDetailblatt(-1);
                    }
                }
                else
                {
                    InitDetailViewsForDetailblatt(-1);
                    InitDetailViewsForDetailblatt(-1);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void grvPersonen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            grvPersonen.BestFitColumns();
        }

        private void grvPersonen_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (grvPersonen.FocusedColumn == colAusgeschlosseneLAs)
            {
                e.Cancel = qryPersonenInkl["Inkl"] as int? == 0;
            }
        }

        private void grvPersonen_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value is string)
            {
                string value = ((string)e.Value).Replace(" ", ""); // normalisieren
                Regex regex = new Regex("^[1-9][0-9]*(,[1-9][0-9]*)*$"); // nur eine Liste von Zahlen zulassen
                if (value.Length == 0 || regex.IsMatch(value))
                {
                    qryPersonenInkl["EffektivAbgerechneteLAs"] = getEffektivAbgerechneteLAsForAusgeschlosseneLAs(value);
                    qryPersonenInkl.Post();
                    qryPersonenInkl.Refresh();
                    grdPersonen.RefreshDataSource();
                    grvPersonen.BestFitColumns();
                    return;
                }

                KissMsg.ShowInfo("Ungültiger Eingabe: Erwartet wurde eine Liste von Zahlen (LA-Nummern)");

                e.Value = qryPersonenInkl["AusgeschlosseneLAs"]; // alten Wert übernehmen
            }
        }

        private bool HandleAddData_tpgDetail()
        {
            int whAbrechnungID = (int)qryAbrechnung["WhAbrechnungID"];

            grvPersonen.CloseEditor();
            grvPersonen.UpdateCurrentRow();
            if (qryDetailblatt.Position >= 0) // work-around für z.T. fehlerhaftes Databinding
            {
                edtDetailVon.DoValidate();
                qryDetailblatt["DatumVon"] = edtDetailVon.EditValue;
                edtDetailBis.DoValidate();
                qryDetailblatt["DatumBis"] = edtDetailBis.EditValue;
            }

            qryDetailblatt.Post();
            qryPersonenInkl.Post();
            qryDetailblaetter.Refresh();

            if (qryDetailblaetter.Count > 0)
            {
                var whDetailblattId = DBUtil.ExecuteScalarSQLThrowingException(
                    @"
                    SELECT TOP 1 WhDetailblattID
                    FROM dbo.WhDetailblatt WITH (READUNCOMMITTED)
                    WHERE WhAbrechnungID = {0}
                      AND DatumBis IS NULL",
                    whAbrechnungID);
                if (!DBUtil.IsEmpty(whDetailblattId))
                {
                    KissMsg.ShowInfo("Alle Datumsfelder müssen ausgefüllt sein bevor ein neuer Datensatz angelegt werden kann.");
                    return false;
                }
            }

            object datumVon;
            object datumBis = DBNull.Value;
            if (qryDetailblaetter.Count > 0)
            {
                // finde das erste freie Datum
                datumVon = DBUtil.ExecuteScalarSQLThrowingException(
                    @"
                    -- Voraussetzung: Es gibt bereits mindestens ein Detailblatt
                    DECLARE @WhAbrechnungID int
                    SET @WhAbrechnungID = {0}
                    --SET @WhAbrechnungID = 1991 -- TEST
                    IF ( -- Falls das erste Detailblatt fehlt, wähle das DatumVon der Abrechnung
                        NOT EXISTS (
                            SELECT WhDetailblattID
                            FROM WhAbrechnung ABR
                                INNER JOIN WhDetailblatt DET ON DET.WhAbrechnungID = ABR.WhAbrechnungID and ABR.DatumVon = DET.DatumVon
                            WHERE ABR.WhAbrechnungID = @WhAbrechnungID
                        )) BEGIN
                        (SELECT ABR.DatumVon FROM WhAbrechnung ABR WHERE ABR.WhAbrechnungID = @WhAbrechnungID)
                    END
                    ELSE BEGIN
                        SELECT TOP 1 CASE WHEN DateAdd(day, 1, DET.DatumBis) <= ABR.DatumBis THEN DateAdd(day, 1, DET.DatumBis) END -- DatumBis des letzten Detailblattes + 1
                        FROM dbo.WhDetailblatt        DET WITH (READUNCOMMITTED)
                        LEFT JOIN dbo.WhAbrechnung  ABR WITH (READUNCOMMITTED) ON ABR.WhAbrechnungID = DET.WhAbrechnungID
                        LEFT JOIN WhDetailblatt     DET2 WITH (READUNCOMMITTED) -- Nachfolge-Detailblatt
                            ON DET2.WhAbrechnungID = @WhAbrechnungID AND DateAdd(day, 1, DET.DatumBis) = DET2.DatumVon
                        WHERE DET.WhAbrechnungID = @WhAbrechnungID AND DET2.WhDetailblattID IS NULL
                        AND DET.DatumVon BETWEEN ABR.DatumVon AND ABR.DatumBis AND DET.DatumBis BETWEEN ABR.DatumVon AND ABR.DatumBis
                        ORDER BY DET.DatumBis ASC
                    END",
                    whAbrechnungID);
                if (DBUtil.IsEmpty(datumVon))
                {
                    KissMsg.ShowInfo("Es wurden bereits Detailblaetter über die ganze Abrechnungsperiode erfasst.");
                    return false;
                }
            }
            else
            {
                datumVon = qryAbrechnung["DatumVon"];
            }

            int detailblattID = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                INSERT INTO dbo.WhDetailblatt (WhAbrechnungID, DatumVon, DatumBis, Creator, Modifier) OUTPUT INSERTED.WhDetailblattID
                VALUES ({0}, {1}, {2}, {3}, {3})",
                whAbrechnungID,
                datumVon,
                datumBis,
                DBUtil.GetDBRowCreatorModifier());

            DBUtil.ExecuteScalarSQLThrowingException(@"
                -- verfuegbare LAs
                DECLARE @LAsVerfuegbar VARCHAR(MAX);
                SELECT @LAsVerfuegbar = dbo.ConcDistinctOrder(KontoNr)
                FROM dbo.BgKostenart
                WHERE ModulId = 3
                  AND KontoNr NOT LIKE '0%'
                  AND KontoNr NOT IN (SELECT SplitValue
                                      FROM dbo.fnSplitStringToValues((SELECT TOP 1 CONVERT(varchar(500), ValueVarchar)
                                                                      FROM dbo.XConfig
                                                                      WHERE KeyPath = 'System\WH\WV_VU_UB'
                                                                      ORDER BY DatumVon DESC), ',', 0)
                                      );

                INSERT INTO dbo.WhDetailblatt_BaPerson (WhDetailblattID, BaPersonID, Creator, Modifier, EffektivAbgerechneteLAs)
                  SELECT {1}, BFB.BaPersonID, {2}, {2}, @LAsVerfuegbar
                  FROM dbo.FaFall FAL
                    INNER JOIN FaLeistung LEI ON LEI.FaFallID = FAL.FaFallID
                    INNER JOIN BgFinanzplan BFP ON BFP.FaLeistungID = LEI.FaLeistungID
                    INNER JOIN BgFinanzplan_BaPerson BFB ON BFB.BgFinanzplanID = BFP.BgFinanzplanID AND BFB.IstUnterstuetzt = 1
                    --INNER JOIN VwPerson PER ON PER.BaPersonID = BFB.BaPersonID
                  WHERE FAL.BaPersonID = {0}
                  GROUP BY BFB.BaPersonID

                  UNION

                  -- ProLeist
                  SELECT {1}, MIG.BaPersonID, {2}, {2}, @LAsVerfuegbar
                  FROM dbo.FaFall FAL
                    INNER JOIN FaLeistung LEI ON LEI.FaFallID = FAL.FaFallID
                    INNER JOIN MigDetailBuchung MIG ON MIG.FaLeistungID = LEI.FaLeistungID
                    --INNER JOIN VwPerson PER ON PER.BaPersonID = MIG.BaPersonID
                  WHERE FAL.BaPersonID = {0}
                  GROUP BY MIG.BaPersonID;", _baPersonID, detailblattID, DBUtil.GetDBRowCreatorModifier());

            qryAbrechnung.Refresh();
            grdKlientenabrechnung.RefreshDataSource(); //plus kommt
            int rowHandle = grvAbrechnung.FocusedRowHandle;
            grvAbrechnung.SetMasterRowExpanded(rowHandle, true);

            InitDetailViewsForDetailblatt(detailblattID);

            UpdateDetailView();

            FocusDetailRow(detailblattID);

            return true;
        }

        private void qryAbrechnung_AfterFill(object sender, EventArgs e)
        {
            DataSet ds = qryAbrechnung.DataSet;
            ds.Relations.Add("DetailblattLevel",
                new[] { ds.Tables[0].Columns["WhAbrechnungID"] },
                new[] { ds.Tables[1].Columns["WhAbrechnungID"] });
        }

        private void qryAbrechnung_AfterInsert(object sender, EventArgs e)
        {
            qryAbrechnung["FaFallID"] = _faFallID;
            qryAbrechnung["BaPersonID"] = _baPersonID;
            qryAbrechnung["DatumVon"] = DBNull.Value;
            qryAbrechnung["DatumBis"] = DBNull.Value;
            qryAbrechnung["WhAbrechnungVisumCode"] = 1;
            qryAbrechnung["Status"] = "In Vorbereitung";
            qryAbrechnung.RowModified = true;
            qryAbrechnung.Post();
        }

        private void qryAbrechnung_BeforePost(object sender, EventArgs e)
        {
            if (ValidateVon(edtAbrechnungVon) || ValidateBis(edtAbrechnungBis))
            {
                throw new KissCancelException();
            }

            if (!DBUtil.IsEmpty(qryAbrechnung["DatumVon"])
                && !DBUtil.IsEmpty(edtAbrechnungVon.EditValue)
                && !qryAbrechnung["DatumVon"].Equals(edtAbrechnungVon.EditValue))
            {
                qryAbrechnung["DatumVon"] = edtAbrechnungVon.EditValue;
            }

            if (!DBUtil.IsEmpty(qryAbrechnung["DatumBis"])
                && !DBUtil.IsEmpty(edtAbrechnungBis.EditValue)
                && !qryAbrechnung["DatumBis"].Equals(edtAbrechnungBis.EditValue))
            {
                qryAbrechnung["DatumBis"] = edtAbrechnungBis.EditValue;
            }
        }

        private void qryAbrechnung_PositionChanged(object sender, EventArgs e)
        {
            var abrechnungID = qryAbrechnung["WhAbrechnungID"] as int?;
            InitDetailViewsForAbrechnung(abrechnungID ?? -1);

            qryDetailblatt.Post();
            qryPersonenInkl.Post();

            InitDetailViewsForDetailblatt(-1); // eine Abrechnung ist ausgewählt, also kein Detailblatt
            SetEditModeAbrechnung();
            SetEditModeDetail();
        }

        private void qryAbrechnung_PostCompleted(object sender, EventArgs e)
        {
            SetEditModeAbrechnung();
        }

        private void qryDetailblaetter_AfterFill(object sender, EventArgs e)
        {
            FillTimeline();
        }

        private void qryDetailblatt_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();

            qryAbrechnung.Refresh();
            UpdateDetailView();
        }

        private void qryDetailblatt_AfterFill(object sender, EventArgs e)
        {
        }

        private void qryDetailblatt_BeforeDelete(object sender, EventArgs e)
        {
            try
            {
                Session.BeginTransaction();

                DBUtil.ExecSQLThrowingException(@"
                    DELETE FROM dbo.WhDetailblattKorrekturPosition
                    WHERE WhDetailblattID = {0};",
                    qryDetailblatt["WhDetailblattID"]);
            }
            catch
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryDetailblatt_BeforePost(object sender, EventArgs e)
        {
            if (ValidateVon(edtDetailVon) || ValidateBis(edtDetailBis))
            {
                throw new KissCancelException();
            }
        }

        private void qryDetailblatt_PositionChanged(object sender, EventArgs e)
        {
            qryPersonenInkl.Post();
            qryPersonenInkl.Fill(qryDetailblatt["WhDetailblattID"]);
            SetEditModeAbrechnung();
            SetEditModeDetail();
        }

        private void qryDetailblatt_PostCompleted(object sender, EventArgs e)
        {
            for (int rowHandle = 0; rowHandle < grvAbrechnung.DataRowCount; rowHandle++)
            {
                //DevExpress.XtraGrid.Views.Base.ColumnView detailView = ((DevExpress.XtraGrid.Views.Base.ColumnView)grvAbrechnung.GetDetailView(rowHandle, 0));//relationIndex = 0
                DevExpress.XtraGrid.Views.Grid.GridView detailView = ((DevExpress.XtraGrid.Views.Grid.GridView)grvAbrechnung.GetDetailView(rowHandle, 0));//relationIndex = 0
                if (detailView != null && detailView.IsLoading == false)
                {
                    for (int detailRowHandle = 0; detailRowHandle < detailView.DataRowCount; detailRowHandle++)
                    {
                        DataRowView row = (DataRowView)detailView.GetRow(detailRowHandle);
                        if (row != null && (int)row["WhDetailblattID"] == (int)qryDetailblatt["WhDetailblattID"])
                        {
                            row["DatumVon"] = qryDetailblatt["DatumVon"];
                            row["DatumBis"] = qryDetailblatt["DatumBis"];
                            detailView.InvalidateRow(detailRowHandle);
                            detailView.UpdateCurrentRow();
                            break;
                        }
                    }
                }
            }

            SetEditModeDetail(); // Nachdem abspeichern der Dokumente EditMode aufrufen
            qryDetailblaetter.Refresh();
        }

        private void qryPersonenInkl_AfterFill(object sender, EventArgs e)
        {
            grvPersonen.BestFitColumns();
        }

        private void qryPersonenInkl_BeforePost(object sender, EventArgs e)
        {
            if (grvPersonen.IsEditing)
            {
                grvPersonen.CloseEditor();
                grvPersonen.UpdateCurrentRow();
            }

            if (qryPersonenInkl["Inkl"].Equals(0))
            {
                qryPersonenInkl["zusaetzlicheLAs"] = string.Empty;
            }
        }

        private void repositoryItemButtonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var dialog = new DlgWhKlientenkontoabrechnungLAAusschluss())
            {
                dialog.LAList = qryPersonenInkl["EffektivAbgerechneteLAs"] as string;
                dialog.Name = qryPersonenInkl["NameVorname"] as string;
                dialog.ShowDialog(this);
                if (dialog.DialogResult == DialogResult.OK)
                {
                    qryPersonenInkl["EffektivAbgerechneteLAs"] = dialog.SelectedLAList;
                    qryPersonenInkl.Post();
                    qryPersonenInkl.Refresh();
                    grdPersonen.RefreshDataSource();
                    grvPersonen.BestFitColumns();
                }
            }
        }

        private void tabAbrechnung_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabAbrechnung.SelectedTab == tpgAbrechnung) // Wechsel von Abrechnung auf Detail
            {
                if (qryAbrechnung.Position >= 0)
                {
                    e.Cancel = !qryAbrechnung.Post();
                }
                else
                {
                    KissMsg.ShowInfo("Es ist keine Abrechnung selektiert.");
                    e.Cancel = true;
                }
            }
            else if (tabAbrechnung.SelectedTab == tpgDetail) // Wechsel von Detail auf Abrechnung
            {
                if (qryAbrechnung.Position >= 0 && qryDetailblatt.Position >= 0)
                {
                    e.Cancel = !qryDetailblatt.Post();
                }

                if (!e.Cancel && qryAbrechnung.Position >= 0 && qryPersonenInkl.Position >= 0)
                {
                    e.Cancel = !qryPersonenInkl.Post();
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "ABSENDER":
                    SqlQuery qryUser = DBUtil.OpenSQL("Select USR.UserID, USR.LogonName FROM FaFall FAL INNER JOIN XUser USR ON FAL.UserID = USR.UserID where FaFallID = {0}", _faFallID);
                    int userid = (int)qryUser["UserID"];
                    return userid;

                case "DATUMVON":
                    if (tabAbrechnung.SelectedTab == tpgDetail)
                    {
                        return edtDetailVon.EditValue;
                    }
                    return edtAbrechnungVon.EditValue;

                case "DATUMBIS":
                    if (tabAbrechnung.SelectedTab == tpgDetail)
                    {
                        return edtDetailBis.EditValue;
                    }
                    return edtAbrechnungBis.EditValue;

                case "WHABRECHNUNGID":
                    return qryAbrechnung["WhAbrechnungID"];

                case "WHDETAILBLATTID":
                    if (tabAbrechnung.SelectedTab == tpgDetail)
                    {
                        return qryDetailblatt["WhDetailblattID"];
                    }
                    return -1;

                case "FT":
                    return _baPersonID;

                case "FAFALLID":
                    return _faFallID;

                case "FALLUSERID":
                case "LEISTUNGUSERID": // Die Klientenkontoabrechnung gibt es pro Fall, eine Aufteilung nach Leistung ist nicht nötig
                    SqlQuery qryLeistungUser = DBUtil.OpenSQL("Select USR.UserID, USR.LogonName FROM FaFall FAL INNER JOIN XUser USR ON FAL.UserID = USR.UserID where FaFallID = {0}", _faFallID);
                    return 0;

                case "ADRESSAT":
                    return qryAbrechnung["BaPersonID"];
            }

            return base.GetContextValue(fieldName);
        }

        public override bool OnAddData()
        {
            //are we allowed to add a new record?
            if (tabAbrechnung.SelectedTab == tpgDetail)
            {
                if (qryAbrechnung.Position < 0)
                {
                    KissMsg.ShowInfo("Es ist keine Abrechnung ausgewählt.");
                    return false;
                }

                if (Utils.ConvertToInt(qryAbrechnung["WhAbrechnungVisumCode"]) == 2) // angefragt
                {
                    KissMsg.ShowInfo("Das Visum für die Abrechnung wurde bereits angefragt. Sie kann nicht mehr verändert werden");
                    return false;
                }

                if (Utils.ConvertToInt(qryAbrechnung["WhAbrechnungVisumCode"]) == 3) // erteilt
                {
                    KissMsg.ShowInfo("Die Abrechnung wurde bereits visiert und kann nicht mehr verändert werden");
                    return false;
                }

                if (DBUtil.IsEmpty(qryAbrechnung["DatumVon"]))
                {
                    KissMsg.ShowInfo("Die Abrechnungsperiode muss zuerst festgelegt werden.");
                    return false;
                }

                if (!DBUtil.IsEmpty(qryAbrechnung["DocumentID"]))
                {
                    KissMsg.ShowInfo("Eine Abrechnung wurde bereits erstellt. Es können keine weiteren Detailblätter eingefügt werden.");
                    return false;
                }

                return HandleAddData_tpgDetail();
            }

            if (tabAbrechnung.SelectedTab == tpgErgaenzungen)
            {
                if (qryDetailblaetter.Position < 0)
                {
                    KissMsg.ShowInfo("Es ist kein Detailblatt ausgewählt.");
                    return false;
                }

                if (Utils.ConvertToInt(qryAbrechnung["WhAbrechnungVisumCode"]) == 2) // angefragt
                {
                    KissMsg.ShowInfo("Das Visum für die Abrechnung wurde bereits angefragt. Sie kann nicht mehr verändert werden");
                    return false;
                }

                if (Utils.ConvertToInt(qryAbrechnung["WhAbrechnungVisumCode"]) == 3) // erteilt
                {
                    KissMsg.ShowInfo("Die Abrechnung wurde bereits visiert und kann nicht mehr verändert werden");
                    return false;
                }

                if (!DBUtil.IsEmpty(qryAbrechnung["DocumentID"]))
                {
                    KissMsg.ShowInfo("Eine Abrechnung wurde bereits erstellt. Es können keine weiteren Ergänzungen eingefügt werden.");
                    return false;
                }

                return ctlErgaenzungen.OnAddData();
            }

            if (tabAbrechnung.SelectedTab == tpgOffeneForderungen)
            {
                if (qryAbrechnung.Position < 0)
                {
                    KissMsg.ShowInfo("Es ist keine Abrechnung ausgewählt.");
                    return false;
                }

                if (Utils.ConvertToInt(qryAbrechnung["WhAbrechnungVisumCode"]) == 2) // angefragt
                {
                    KissMsg.ShowInfo("Das Visum für die Abrechnung wurde bereits angefragt. Sie kann nicht mehr verändert werden");
                    return false;
                }

                if (Utils.ConvertToInt(qryAbrechnung["WhAbrechnungVisumCode"]) == 3) // erteilt
                {
                    KissMsg.ShowInfo("Die Abrechnung wurde bereits visiert und kann nicht mehr verändert werden");
                    return false;
                }

                if (!DBUtil.IsEmpty(qryAbrechnung["DocumentID"]))
                {
                    KissMsg.ShowInfo("Eine Abrechnung wurde bereits erstellt. Es können keine weiteren offenen Forderungen eingefügt werden.");
                    return false;
                }

                return ctlOffeneForderungen.OnAddData();
            }

            //else: neue Abrechnung
            qryAbrechnung.Insert();
            qryAbrechnung.Refresh();
            return true;
        }

        public override bool OnDeleteData()
        {
            if (!qryAbrechnung.IsEmpty && (int)qryAbrechnung["WhAbrechnungVisumCode"] == 2) //Bewilligung angefragt
            {
                KissMsg.ShowInfo("Die Abrechnung wurde bereits zur Bewilligung angefragt und kann nicht mehr verändert werden");
                return false;
            }

            if (!qryAbrechnung.IsEmpty && (int)qryAbrechnung["WhAbrechnungVisumCode"] == 3) // erteilt
            {
                KissMsg.ShowInfo("Die Abrechnung wurde bereits visiert und kann nicht mehr verändert werden");
                return false;
            }

            if (qryAbrechnung.Position < 0)
            {
                KissMsg.ShowInfo("Es ist keine Abrechnung ausgewählt.");
                return false;
            }

            if (tabAbrechnung.SelectedTab == tpgDetail)
            {
                if (!DBUtil.IsEmpty(qryAbrechnung["DocumentID"]))
                {
                    KissMsg.ShowInfo("Eine Abrechnung wurde bereits erstellt. Einträge zu Detailblättern können nicht mehr gelöscht werden, ohne vorher das Abrechnungsdokument zu löschen.");
                    return false;
                }

                bool resetDetailblatt = qryDetailblaetter.Count == 1;
                bool deleted = qryDetailblatt.Delete();
                if (resetDetailblatt)
                {
                    qryDetailblatt.Fill(-1); // Es wird automatisch eine andere Detailview (d.h. eine Detailview einer anderen Abrechnung)
                }

                // angesprungen. Diesen Sprung möchten wir aber nicht im Detail-Tab anzeigen.
                return deleted;
            }

            if (tabAbrechnung.SelectedTab == tpgErgaenzungen)
            {
                var success = ctlErgaenzungen.OnDeleteData();
                if (success)
                {
                    UpdateErgaenzungColumn(ctlErgaenzungen.HasErgaenzungen);
                }

                return success;
            }

            if (tabAbrechnung.SelectedTab == tpgOffeneForderungen)
            {
                var success = ctlOffeneForderungen.OnDeleteData();
                if (success)
                {
                    UpdateOffeneForderungColumn(ctlOffeneForderungen.HasOffeneForderungen);
                }

                return success;
            }

            //else: Abrechnung
            return qryAbrechnung.Delete();
        }

        public override bool OnSaveData()
        {
            if (tabAbrechnung.SelectedTab == tpgDetail)
            {
                edtDetailBis.DoValidate();
                grvPersonen.CloseEditor();
                grvPersonen.UpdateCurrentRow();
                qryDetailblatt.Post();
                qryPersonenInkl.Post();
                return true;
            }

            if (tabAbrechnung.SelectedTab == tpgErgaenzungen)
            {
                var success = ctlErgaenzungen.OnSaveData();
                if (success)
                {
                    UpdateErgaenzungColumn(ctlErgaenzungen.HasErgaenzungen);
                }
                return success;
            }

            if (tabAbrechnung.SelectedTab == tpgOffeneForderungen)
            {
                var success = ctlOffeneForderungen.OnSaveData();
                if (success)
                {
                    UpdateOffeneForderungColumn(ctlOffeneForderungen.HasOffeneForderungen);
                }
                return success;
            }

            //else: Abrechnung
            return qryAbrechnung.Post();
        }

        #endregion

        #region Private Methods

        private void CheckIfDocumentsAreOpen()
        {
            // Detailblätter
            var documentIds = (from DataRow row in qryDetailblaetter.DataTable.Rows
                               where !DBUtil.IsEmpty(row["DocumentID"])
                               select (int)row["DocumentID"]).ToList();

            var qryDoc = DBUtil.OpenSQL(
                @"
                SELECT
                  DocTypInfo = CASE
                                 WHEN DocumentID = {0} THEN 'Abrechnungsblatt'
                                 WHEN DocumentID IN (SELECT CONVERT(INT, SplitValue)
                                                     FROM dbo.fnSplitStringToValues({1}, ',', 1)) THEN 'Detailblatt'
                                 WHEN DocumentID = {2} THEN 'Ergänzungsblatt'
                                 WHEN DocumentID = {3} THEN 'Dokument ''Offene Forderungen'''
                                 ELSE 'DokumentID ' + CONVERT(VARCHAR(MAX), DocumentID)
                               END,
                  DocumentID,
                  CheckOut_Date,
                  CheckOut_Filename,
                  CheckOut_Machine,
                  CheckOut_UserID
                FROM dbo.XDocument DOC WITH (READUNCOMMITTED)
                WHERE CheckOut_UserID IS NOT NULL
                  AND (DocumentID = {0}    -- Abrechnungsblatt
                    OR DocumentID IN (SELECT CONVERT(INT, SplitValue)
                                      FROM dbo.fnSplitStringToValues({1}, ',', 1)) -- Detailblätter
                    OR DocumentID = {2}    -- Ergänzungsblat
                    OR DocumentID = {3})   -- offene Forderungen",
                docAbrechnung.DocumentID,
                string.Join(",", documentIds),
                docErgaenzung.DocumentID,
                docForderung.DocumentID);

            if (!qryDoc.IsEmpty)
            {
                var message = new StringBuilder();
                message.Append("Das Drucken ist nicht möglich da folgende Dokumente noch offen sind:");

                foreach (DataRow row in qryDoc.DataTable.Rows)
                {
                    message.AppendLine();
                    message.AppendFormat("  - {0}", row["DocTypInfo"]);
                }

                throw new KissInfoException(message.ToString());
            }
        }

        /// <summary>
        /// Druckt alle Detailblätter der Klientenkontoabrechnung
        /// </summary>
        /// <param name="drucker">Druckername</param>
        private List<Task> DruckenDetailblaetter(string drucker)
        {
            XDokument document = new XDokument();
            List<Task> tasks = new List<Task>();
            foreach (DataRow row in qryDetailblaetter.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["DocumentID"]))
                {
                    int documentId = (int)row["DocumentID"];
                    document.DocumentID = documentId;
                    tasks.Add(document.PrintDoc(drucker));
                }
            }

            return tasks;
        }

        private void FillTimeline()
        {
            SuspendLayout();
            try
            {
                List<TimelineItem> persons = new List<TimelineItem>();
                qryPersonen.Fill(_faFallID);

                timeline.ShowToday = false;
                timeline.Clear();
                timeline.Colors.Clear();
                timeline.Visible = true;
                int colorCode = 0;
                Dictionary<int, int> finanzplanFarben = new Dictionary<int, int>();
                foreach (DataRow untPerson in qryPersonen.DataTable.Rows)
                {
                    int baPersonID = (int)untPerson["BaPersonID"];
                    object id = untPerson["BgFinanzplanID"];
                    int finanzplanID;
                    if (DBUtil.IsEmpty(id))
                    {
                        finanzplanID = 0;
                    }
                    else
                    {
                        finanzplanID = (int)untPerson["BgFinanzplanID"];
                    }

                    object fromObj = untPerson["DatumVon"];
                    DateTime from = fromObj is DateTime ? (DateTime)fromObj : new DateTime(9999, 12, 31);
                    object toObj = untPerson["DatumBis"];
                    DateTime to = toObj is DateTime ? (DateTime)(toObj) : new DateTime(9999, 12, 31);
                    TimelineItem person = persons.Find(itemToSearch => itemToSearch.ID == baPersonID);
                    if (person == null)
                    {
                        person = new TimelineItem(baPersonID, untPerson["NameVorname"] as string);
                        persons.Add(person);
                    }

                    string text = "";
                    if ((int)untPerson["ProLeist"] == 1)
                    {
                        text += "ProLeist";
                    }

                    if (!DBUtil.IsEmpty(untPerson["Stat"]))
                    {
                        if (text != "")
                            text += ", ";
                        text += "Stat."; // stationär Kinder/Jugendliche
                    }

                    if (!DBUtil.IsEmpty(untPerson["FaFallID"]) && (int)untPerson["FaFallID"] != _faFallID)
                    {
                        text += ((int)untPerson["FaFallID"]).ToString();
                    }
                    int useColorCode;
                    if (finanzplanID != 0 && finanzplanFarben.ContainsKey(finanzplanID))
                    {
                        useColorCode = finanzplanFarben[finanzplanID];
                    }
                    else
                    {
                        finanzplanFarben[finanzplanID] = colorCode;
                        useColorCode = colorCode;
                        timeline.Colors[colorCode] = new KeyValuePair<string, SolidBrush>(text, new SolidBrush(_colors[colorCode]));
                        colorCode = (colorCode + 1) % _colors.Count;
                    }

                    person.Sections.Add(new TimelineSection(from, to, useColorCode));
                }

                foreach (TimelineItem person in persons)
                {
                    timeline.AddItem(person);
                }

                try
                {
                    if (!DBUtil.IsEmpty(qryAbrechnung["WhAbrechnungID"]))
                    {
                        TimelineItem blaetter = new TimelineItem(-1, "Detailblätter");
                        timeline.AddItem(blaetter);

                        foreach (DataRow detailblatt in qryDetailblaetter.DataTable.Rows)
                        {
                            object fromObj = detailblatt["DatumVon"];
                            DateTime from = fromObj is DateTime ? (DateTime)fromObj : new DateTime(9999, 12, 31);
                            object toObj = detailblatt["DatumBis"];
                            DateTime to = toObj is DateTime ? (DateTime)(toObj) : new DateTime(9999, 12, 31);
                            blaetter.Sections.Add(new TimelineSection(from, to, colorCode));
                            timeline.Colors[colorCode] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(_colors[colorCode]));
                            colorCode = (colorCode + 1) % _colors.Count;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Eintrag ins Log.
                    _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
                }

                DateTime min;
                DateTime max;
                timeline.GetBorderDates(out min, out max);
                timeline.FromDate = min;
                timeline.ToDate = max;
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
            finally
            {
                ResumeLayout();
            }
        }

        private void FocusDetailRow(int whDetailblattID)
        {
            if (grvAbrechnung.IsLoading == false)
            {
                for (int rowHandle = 0; rowHandle < grvAbrechnung.DataRowCount; rowHandle++)
                {
                    DevExpress.XtraGrid.Views.Base.ColumnView detailView = ((DevExpress.XtraGrid.Views.Base.ColumnView)grvAbrechnung.GetDetailView(rowHandle, 0));//relationIndex = 0
                    if (detailView != null && detailView.IsLoading == false)
                    {
                        for (int detailRowHandle = 0; detailRowHandle < detailView.DataRowCount; detailRowHandle++)
                        {
                            DataRowView row = (DataRowView)detailView.GetRow(detailRowHandle);
                            if (row != null && (int)row["WhDetailblattID"] == whDetailblattID)
                            {
                                grvAbrechnung.FocusedRowHandle = rowHandle;
                                detailView.FocusedRowHandle = detailRowHandle;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private string getEffektivAbgerechneteLAsForAusgeschlosseneLAs(string ausgeschlosseneLAs)
        {
            using (var dialog = new DlgWhKlientenkontoabrechnungLAAusschluss())
            {
                //Initialisiere den Dialog mit den ausgeschlossenen LAs
                dialog.AusgeschlosseneLAList = ausgeschlosseneLAs;
                //Hole die abzurechnenden LAs
                return dialog.SelectedLAList;
            }
        }

        private void InitDetailViewsForAbrechnung(int abrechnungID)
        {
            qryDetailblaetter.Fill(abrechnungID);
            ctlOffeneForderungen.Init(abrechnungID);
        }

        private void InitDetailViewsForDetailblatt(int detailblattID)
        {
            qryDetailblatt.Fill(detailblattID);
            qryPersonenInkl.Fill(detailblattID);
            ctlErgaenzungen.Init(detailblattID);
        }

        private void SetColors()
        {
            //	timeline.FromDate = new DateTime(2000, 1, 1);
            //	timeline.ToDate = new DateTime(2008, 1, 1);
            try
            {
                _colors = new Dictionary<int, Color>();
                _colors[0] = Color.LightCoral;
                _colors[1] = Color.LawnGreen;
                _colors[2] = Color.LightBlue;
                _colors[3] = Color.LightSeaGreen;
                _colors[4] = Color.IndianRed;
                _colors[5] = Color.SandyBrown;
                _colors[6] = Color.DarkOrange;
                _colors[7] = Color.Goldenrod;
                _colors[8] = Color.Olive;
                _colors[9] = Color.GreenYellow;
                _colors[10] = Color.SpringGreen;
                _colors[11] = Color.Violet;
                _colors[12] = Color.Pink;
                _colors[13] = Color.Thistle;
                _colors[14] = Color.CornflowerBlue;
                _colors[15] = Color.Yellow;
                _colors[16] = Color.LightYellow;
                _colors[17] = Color.Beige;
                _colors[18] = Color.Khaki;
                _colors[19] = Color.Gold;
                _colors[20] = Color.Wheat;
                _colors[21] = Color.NavajoWhite;
                _colors[22] = Color.Tan;
                _colors[23] = Color.LightSalmon;
                _colors[24] = Color.Tomato;
                _colors[25] = Color.RosyBrown;
                _colors[26] = Color.LightGreen;

                //SqlQuery qryWVCodes = DBUtil.OpenSQL("SELECT Code, ShortText FROM XLOVCode WHERE LOVName = 'BaWVCode'");
                /*qryFinanzplan.Fill(this.faFallID);
                for(int i = 0;i<27;i++)
                {
                    //TODO: setzte titel auf FP (Fremdplatzierung) wo nötig.
                    timeline.Colors[i] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(colors[i]));
                }*/
                /*
                foreach(DataRow codeRow in qryFinanzplan.DataTable.Rows)
                {
                    int code = (int)codeRow["BgFinanzplanID"] % 27;
                    timeline.Colors[code] = new KeyValuePair<string, SolidBrush>((string)codeRow["Bezeichnung"], new SolidBrush(colors[code]));
                }*/
                // highlight
                //timeline.Colors[100] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(Color.Crimson));
                //timeline.Colors[101] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(Color.Crimson));
                //timeline.Colors[110] = new KeyValuePair<string, SolidBrush>("", new SolidBrush(Color.Red));
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void SetEditModeAbrechnung()
        {
            bool dokumentAbrechnungVorhanden = !DBUtil.IsEmpty(docAbrechnung.DocumentID);
            SetEditModeAbrechnung(dokumentAbrechnungVorhanden);
        }

        private void SetEditModeAbrechnung(bool dokumentAbrechnungVorhanden)
        {
            btnVisumAnfragen.Enabled = false;
            btnVisumErteilen.Enabled = false;

            //Es ist eine Abrechung selektiert
            if (qryAbrechnung.Position >= 0)
            {
                if (dokumentAbrechnungVorhanden == false)
                {
                    edtAbrechnungVon.EditMode = EditModeType.Normal;
                    edtAbrechnungBis.EditMode = EditModeType.Normal;
                    edtAdressat.EditMode = EditModeType.Normal;
                    ctlOffeneForderungen.SetEditMode(EditModeType.Normal);
                }
                else
                {
                    edtAbrechnungVon.EditMode = EditModeType.ReadOnly;
                    edtAbrechnungBis.EditMode = EditModeType.ReadOnly;
                    edtAdressat.EditMode = EditModeType.ReadOnly;
                    ctlOffeneForderungen.SetEditMode(EditModeType.ReadOnly);
                }

                // Set default edit mode
                if (qryDetailblaetter.Count > 0)
                {
                    docAbrechnung.EditMode = EditModeType.Normal;
                }
                else
                {
                    docAbrechnung.EditMode = EditModeType.ReadOnly;
                }

                // Set edit mode depending on visum
                switch ((int)qryAbrechnung["WhAbrechnungVisumCode"])
                {
                    case 1:
                    case 4: //In Vorbereitung und Bewilligung Abgelehnt -> Anfragen Button soll aktiv sein
                        btnVisumAnfragen.Enabled = true;
                        edtBemerkungDetail.EditMode = EditModeType.Normal;
                        edtBemerkung.EditMode = EditModeType.Normal;
                        break;

                    case 2: // Bewilligung angefragt
                        btnVisumErteilen.Enabled = true;
                        docAbrechnung.EditMode = EditModeType.ReadOnly;
                        edtBemerkungDetail.EditMode = EditModeType.Normal;
                        edtBemerkung.EditMode = EditModeType.Normal;
                        break;

                    case 3: // erteilt
                        docAbrechnung.EditMode = EditModeType.ReadOnly;
                        edtBemerkungDetail.EditMode = EditModeType.ReadOnly;
                        edtBemerkung.EditMode = EditModeType.ReadOnly;
                        break;
                }
            }

            //Es ist keine Abrechnung selektiert.
            else
            {
                edtAbrechnungVon.EditMode = EditModeType.ReadOnly;
                edtAbrechnungBis.EditMode = EditModeType.ReadOnly;
                edtAdressat.EditMode = EditModeType.ReadOnly;
                docAbrechnung.EditMode = EditModeType.ReadOnly;
                edtBemerkungDetail.EditMode = EditModeType.ReadOnly;
                edtBemerkung.EditMode = EditModeType.ReadOnly;
                ctlOffeneForderungen.SetEditMode(EditModeType.ReadOnly);
            }
        }

        private void SetEditModeDetail()
        {
            if (qryAbrechnung.Position < 0
                || (int)qryAbrechnung["WhAbrechnungVisumCode"] == 2 //2: Bewilligung angefragt
                || (int)qryAbrechnung["WhAbrechnungVisumCode"] == 3 //3: Bewilligung erteilt
                || qryDetailblatt.Position < 0
                || !DBUtil.IsEmpty(qryAbrechnung["DocumentID"])
                || !DBUtil.IsEmpty(qryDetailblatt["DocumentID"]))
            {
                //edtDetailVon.EditMode = EditModeType.ReadOnly;
                edtDetailBis.EditMode = EditModeType.ReadOnly;
                grdPersonen.GridStyle = GridStyleType.ReadOnly;
                docErgaenzung.EditMode = EditModeType.ReadOnly;
                //this.grvPersonen.OptionsView.ColumnAutoWidth = true;
                edtGrund.EditMode = EditModeType.ReadOnly;
                ctlErgaenzungen.SetEditMode(EditModeType.ReadOnly);

                //Wenn das Detailblatt generiert ist, dann soll man es trotzdem löschen können,
                //solange es nicht im Status Bewilligung angefragt und Bewilligung erteilt ist.
                // Testrückmeldung #8396.
                if ((int)qryAbrechnung["WhAbrechnungVisumCode"] == 2    //2: Bewilligung angefragt
                    || (int)qryAbrechnung["WhAbrechnungVisumCode"] == 3    //3: Bewilligung erteilt
                    || !DBUtil.IsEmpty(qryAbrechnung["DocumentID"]))       //Abrechnungsblatt wurde bereits erstellt.
                {
                    docDetail.EditMode = EditModeType.ReadOnly;
                    docDetail.CanDeleteDocument = false;
                }
                else
                {
                    docDetail.EditMode = EditModeType.Normal;
                    docDetail.CanDeleteDocument = true;
                }
            }
            else
            {
                //edtDetailVon.EditMode = EditModeType.Normal;
                edtDetailBis.EditMode = EditModeType.Normal;
                grdPersonen.GridStyle = GridStyleType.Editable;
                docDetail.EditMode = EditModeType.Normal;
                docErgaenzung.EditMode = EditModeType.ReadOnly;
                //this.grvPersonen.OptionsView.ColumnAutoWidth = true;
                edtGrund.EditMode = EditModeType.Normal;
                ctlErgaenzungen.SetEditMode(EditModeType.Normal);
            }
        }

        private void UpdateDetailView()
        {
            //grdKlientenabrechnung.RefreshDataSource();
            for (int rowHandle = 0; rowHandle < grvAbrechnung.RowCount; rowHandle++)
            {
                if (grvAbrechnung.GetMasterRowExpandedEx(rowHandle, 0)) // relation index = 0
                {
                    // Neuladen
                    grvAbrechnung.SetMasterRowExpandedEx(rowHandle, 0, false);// relation index = 0
                    grvAbrechnung.SetMasterRowExpandedEx(rowHandle, 0, true);// relation index = 0
                }
            }
        }

        private void UpdateErgaenzungColumn(bool newState)
        {
            if (grvAbrechnung.IsLoading == false)
            {
                int focusedRowHandle = grvAbrechnung.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    DevExpress.XtraGrid.Views.Base.ColumnView detailView = ((DevExpress.XtraGrid.Views.Base.ColumnView)grvAbrechnung.GetDetailView(focusedRowHandle, 0));//relationIndex = 0
                    if (detailView != null && detailView.IsLoading == false)
                    {
                        int detailFocusedRowHandle = detailView.FocusedRowHandle;
                        if (detailFocusedRowHandle >= 0)
                        {
                            DataRowView row = (DataRowView)detailView.GetRow(detailFocusedRowHandle);
                            if (row != null && (int)row["WhDetailblattID"] == (int)qryDetailblatt["WhDetailblattID"])
                            {
                                row["Ergaenzung"] = newState;
                            }
                        }
                    }
                }
            }
        }

        private void UpdateOffeneForderungColumn(bool newState)
        {
            if (grvAbrechnung.IsLoading == false)
            {
                int focusedRowHandle = grvAbrechnung.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    DataRowView row = (DataRowView)grvAbrechnung.GetRow(focusedRowHandle);
                    if (row != null && (int)row["WhAbrechnungID"] == (int)qryAbrechnung["WhAbrechnungID"])
                    {
                        row["Forderung"] = newState;
                    }
                }
            }
        }

        private bool ValidateBis(object sender)
        {
            KissDateEdit dateEdit = (KissDateEdit)sender;
            if (!DBUtil.IsEmpty(dateEdit.EditValue))
            {
                DateTime datumBis = (DateTime)dateEdit.EditValue;
                DateTime datumVon = DateTime.MinValue;
                if (sender == edtAbrechnungBis && !DBUtil.IsEmpty(edtAbrechnungVon.EditValue))
                {
                    datumVon = (DateTime)edtAbrechnungVon.EditValue;
                }
                else if (sender == edtDetailBis)
                {
                    datumVon = (DateTime)edtDetailVon.EditValue;
                }

                if (datumBis < datumVon)
                {
                    KissMsg.ShowInfo("Warnung: Das Feld 'Datum bis' muss nach dem Feld 'Datum von' liegen.");
                    return true;
                }

                int daysInMonth = DateTime.DaysInMonth(datumBis.Year, datumBis.Month);
                if (datumBis.Day != daysInMonth)
                {
                    dateEdit.EditValue = datumBis = new DateTime(datumBis.Year, datumBis.Month, daysInMonth);
                }

                if (sender == edtDetailBis && !DBUtil.IsEmpty(qryAbrechnung["DatumBis"]) && datumBis > (DateTime)qryAbrechnung["DatumBis"])
                {
                    KissMsg.ShowInfo("Das Feld 'Datum bis' darf nicht nach dem Ende der Abrechnung liegen.");
                    return true;
                }
            }

            return false;
        }

        private bool ValidateVon(object sender)
        {
            KissDateEdit dateEdit = (KissDateEdit)sender;
            if (!DBUtil.IsEmpty(dateEdit.EditValue))
            {
                DateTime datumVon = (DateTime)dateEdit.EditValue;
                DateTime datumBis = DateTime.MaxValue;
                if (sender == edtAbrechnungVon && !DBUtil.IsEmpty(edtAbrechnungBis.EditValue))
                {
                    datumBis = (DateTime)edtAbrechnungBis.EditValue;
                }
                else if (sender == edtDetailVon && !DBUtil.IsEmpty(edtDetailBis.EditValue))
                {
                    datumBis = (DateTime)edtDetailBis.EditValue;
                }

                if (datumVon > datumBis)
                {
                    KissMsg.ShowInfo("Das Feld 'Datum bis' muss nach dem Feld 'Datum von' liegen.");
                    return true;
                }

                if (datumVon.Day != 1)
                {
                    dateEdit.EditValue = new DateTime(datumVon.Year, datumVon.Month, 1);
                }
            }

            return false;
        }

        #endregion

        #endregion
    }
}