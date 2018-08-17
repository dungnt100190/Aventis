#region Header

/*

Ich habe pragmatisch nur Tabellen ins Skript hineingenommen, bei denen mit den aktuellen Daten ein UPDATE nötig ist. In v2 sind noch mehr Tabellen drin, damit sollten auch heute (19.10.) erfasste Daten keine Probleme verursachen.
BaAdresse hat tatsächlich gefehlt.

Der v2 platziert nun die Personen im frei gelassenen Range 233785-233999, danke für den Hinweis.

Eine Einschränkung auf eine einzelne Person ist nicht möglich, ohne das Skript wesentlich zu verändern. Es gibt zwei Alternativen:
- Das Skript mit BEGIN TRANSACTION/ROLLBACK ausführen und vor dem Rollback per SQL Checks durchzuführen. Dieser Vorgang kann beliebig wiederholt werden.
- Skript ausführen und mit KiSS-Client verifizieren. Bei einem Fehler das Restore von PRODUKTION_VORTAG nochmals durchführen.

 */

#endregion

using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.ExpressionEvaluation;
using KiSS4.Gui;

namespace KiSS4.Sostat
{
    public partial class CtlBfsDossiers : KissSearchUserControl
    {
        #region Enumerations

        public enum BFSLeistungsArt
        {
            RegulaererFallohneVertrag = 1,
            RegulaererFallmitVertrag = 2,
            EinmaligeZahlungmitBudget = 3,
            EinmaligeZahlungohneBudget = 4,
            BevorschussungALV = 5,
            ZuschussnachDekret = 6,
            Beratungsfall = 10,
            ElternMutterschaftsbeihilfe = 23,
            Alimentenbevorschussung = 25,
            ZusatzleistungzuAltersrente = 32,
            ZusatzleistungzuInvalidenrente = 33,
            ZusatzleistungzuHinterlassenenrente = 34,
            KantonaleBeihilfenzuAltersrente = 35,
            KantonaleBeihilfenzuInvalidentrente = 36,
            KantonaleBeihilfenzuHinterlassenenrente = 37,
            NichtFestgestellt = 99999
        }

        #endregion

        #region Fields

        #region Private Static Fields

        /// The Log4Net logger.
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const bool HEAVY_DEBUG = false;
        private readonly Hashtable _htBFSLOVName = new Hashtable();
        private readonly ArrayList alFilterRegel = new ArrayList();

        // flag if some more logging-events have to be written

        #endregion

        #region Private Fields

        private bool _askedUserReloadData = false; // ask user only once when data has changed to reload
        private string _originalSelectStatement;

        #endregion

        #endregion

        #region Constructors

        public CtlBfsDossiers()
        {
            InitializeComponent();

            // create instances
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();

            // barManager
            barManager.DockControls.Add(barDockControlTop);
            barManager.DockControls.Add(barDockControlBottom);
            barManager.DockControls.Add(barDockControlLeft);
            barManager.DockControls.Add(barDockControlRight);
            barManager.Form = this;
            barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btnNeuesDossier, btnDossierLoeschen });
            barManager.MaxItemId = 1;

            // btnNeuesDossier
            btnNeuesDossier.Id = 0;
            btnNeuesDossier.ImageIndex = KissImageList.GetImageIndex(1);

            // btnDossierLoeschen
            btnDossierLoeschen.Id = 1;
            btnDossierLoeschen.ImageIndex = KissImageList.GetImageIndex(4);

            // popUpMenu
            popUpMenu.LinksPersistInfo.AddRange(new[] {
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnNeuesDossier, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
                new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, btnDossierLoeschen, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            popUpMenu.Manager = barManager;
            popUpMenu.Name = "popUpMenu";
            popUpMenu.BeforePopup += popUpMenu_BeforePopup;

            // barDockControls
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);

            Controls.SetChildIndex(barDockControlTop, 0);
            Controls.SetChildIndex(barDockControlBottom, 0);
            Controls.SetChildIndex(barDockControlLeft, 0);
            Controls.SetChildIndex(barDockControlRight, 0);

            // setup menu
            barManager.Items.Clear();
            barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btnNeuesDossier, btnDossierLoeschen });
            barManager.SetPopupContextMenu(treClient, popUpMenu);
            barManager.Images = KissImageList.SmallImageList;

            handler = GetFunctionValue;

            _originalSelectStatement = qryClientTree.SelectStatement;
        }

        #endregion

        #region EventHandlers

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            treClient.CollapseAll();
            treClient.Focus();
        }

        private void btnDossierLoeschen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treClient.FocusedNode != null && !DBUtil.IsEmpty(treClient.FocusedNode.GetValue("BFSDossierID")))
            {
                if (!KissMsg.ShowQuestion("CtlBfsDossiers", "DossierLoeschen", "Soll das Dossier '{0} - {1}' entfernt werden ?",
                    0, 0, true, treClient.FocusedNode.ParentNode.GetValue("Text"), treClient.FocusedNode.GetValue("Text")))
                    return;

                DBUtil.ExecSQL(@"
                    DELETE FROM dbo.BFSWert          WHERE BFSDossierID = {0}
                    DELETE FROM dbo.BFSDossierPerson WHERE BFSDossierID = {0}
                    DELETE FROM dbo.BFSDossier       WHERE BFSDossierID = {0}
                    ", treClient.FocusedNode.GetValue("BFSDossierID"));
                // data has changed
                DataHasChanged();
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            treClient.ExpandAll();
            treClient.Focus();
        }

        private void btnNeuesDossier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // create dialog
            DlgBfsNeuesDossier dlg = new DlgBfsNeuesDossier();

            // preset year
            if (treClient.FocusedNode != null && !DBUtil.IsEmpty(treClient.FocusedNode.GetValue("Jahr")))
            {
                dlg.Jahr = (int)treClient.FocusedNode.GetValue("Jahr");
            }

            // show dialog and insert data
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.BFSDossier (BFSDossierStatusCode, DatumVon, UserID, Jahr, Stichtag, BFSKatalogVersionID, BFSLeistungsartCode, ZustaendigeGemeinde, LaufNr)
                      SELECT TOP 1 BFSDossierStatusCode = 0, GETDATE(), {0}, Jahr, {2}, BFSKatalogVersionID, {3}, {5}, 0
                      FROM dbo.BFSKatalogVersion
                      WHERE Jahr = {1}
                      ORDER BY BFSKatalogVersionID DESC
                    DECLARE @NewID int
                    SET @NewID = SCOPE_IDENTITY()
                    INSERT INTO dbo.BFSDossierPerson (BFSDossierID, BFSPersonCode, PersonIndex, PersonName)
                      VALUES (@NewID, 1, 0, {4})",
                    dlg.Mitarbeiter, dlg.Jahr, dlg.Stichtag, dlg.Leistungsart, dlg.Antragsteller, dlg.Gemeinde);

                // data has changed
                DataHasChanged();
            }
        }

        private void CtlBfsDossiers_Load(object sender, EventArgs e)
        {
            // setup menu
            barManager.Items.Clear();
            barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] { btnNeuesDossier, btnDossierLoeschen });
            barManager.SetPopupContextMenu(treClient, popUpMenu);
            barManager.Images = KissImageList.SmallImageList;

            ctlBfsDossier.Visible = false;
            ShowHidePanelFragenDetail(false);
            panFragen.Dock = DockStyle.Fill;

            // setup lookup sql
            edtBaPersonIDX.LookupSQL = @"
            ----
            SELECT Code = NameVorname FROM vwPerson WHERE BaPersonID = {0}";

            edtSARX.LookupSQL = @"
            ----
            SELECT Code = LastName + ISNULL(', ' + FirstName, '')
            FROM dbo.XUser WITH (READUNCOMMITTED)
            WHERE UserID = {0}";

            // start new search
            NewSearch();
        }

        private void edtBaPersonIDX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // Suchen nach Klienten
            string searchString = edtBaPersonIDX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    // damit auch etwas zur Auswahl angezeigt wird, wenn das Suchfeld leer ist
                    searchString = "%";
                }
                else
                {
                    // zurücksetzen der vorhergehenden Auswahl,
                    // wenn das Suchfeld leer ist und es ohne anzuklicken verlassen wird
                    edtBaPersonIDX.EditValue = null;
                    edtBaPersonIDX.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                // wenn die Auswahl gemacht wurde
                edtBaPersonIDX.EditValue = dlg["Name"];
                edtBaPersonIDX.LookupID = dlg["BaPersonID"];
            }
        }

        private void edtSARX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtSARX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSARX.LookupID = dlg["UserID"];
            }
        }

        private void edtWert_Enter(object sender, EventArgs e)
        {
            Control edt = sender as Control;
            if (edt != null)
            {
                qryFrageWert.Find(string.Format("BFSFrageID = {0}", edt.Tag));
            }
        }

        private void lbl_Click(Object sender, EventArgs e)
        {
            KissLabel lbl = sender as KissLabel;

            if (lbl != null)
            {
                qryFrageWert.Find(String.Format("BFSFrageID = {0}", lbl.Tag));
            }
        }

        private void pic_Click(Object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;

            if (pic != null)
            {
                qryFrageWert.Find(String.Format("BFSFrageID = {0}", pic.Tag));
            }
        }

        private void popUpMenu_BeforePopup(object sender, EventArgs e)
        {
            btnNeuesDossier.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            // Einzelne Menus einstellen: "Person entfernen"
            bool btnVisible = false;

            if (treClient.FocusedNode != null
                && !DBUtil.IsEmpty(treClient.FocusedNode.GetValue("BFSDossierID"))
                && DBUtil.IsEmpty(treClient.FocusedNode.GetValue("BFSDossierPersonID")))
            {
                btnVisible = true;
            }

            if (btnVisible)
            {
                btnDossierLoeschen.Caption = string.Format(
                    "Dossier '{0} - {1}' entfernen",
                    treClient.FocusedNode.ParentNode.GetValue("Text"),
                    treClient.FocusedNode.GetValue("Text"));

                btnDossierLoeschen.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnDossierLoeschen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void qryDatabind_BeforePost(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                foreach (DataRow row in qryFrageWert.DataTable.Rows)
                {
                    string fieldName = string.Format("BFSFrageID_{0}", row["BFSFrageID"]);

                    if (qryDatabind.DataTable.Columns.Contains(fieldName) && qryDatabind.ColumnModified(fieldName))
                    {
                        row["Wert"] = qryDatabind[fieldName];

                        // Save Value
                        SqlQuery qrySave;

                        if (DBUtil.IsEmpty(row["BFSWertID"]))
                        {
                            qrySave = DBUtil.OpenSQL(@"
                                INSERT INTO dbo.BFSWert (BFSDossierID, BFSDossierPersonID, BFSFrageID, Wert)
                                  VALUES ({0}, {1}, {2}, {3})

                                SELECT BFSWertID, BFSDossierID, BFSDossierPersonID,
                                       BFSFrageID, Wert, PlausiFehler, BFSWertTS
                                FROM dbo.BFSWert WITH (READUNCOMMITTED)
                                WHERE BFSWertID = SCOPE_IDENTITY()",
                                row["BFSDossierID"], row["BFSDossierPersonID"], row["BFSFrageID"], row["Wert"]);

                            row["BFSWertID"] = qrySave["BFSWertID"];
                        }
                        else
                        {
                            qrySave = DBUtil.OpenSQL(@"
                                UPDATE dbo.BFSWert
                                  SET Wert = {1}
                                WHERE BFSWertID = {0}

                                SELECT BFSWertID, BFSDossierID, BFSDossierPersonID,
                                       BFSFrageID, Wert, PlausiFehler, BFSWertTS
                                FROM dbo.BFSWert WITH (READUNCOMMITTED)
                                WHERE BFSWertID = {0}",
                                row["BFSWertID"], row["Wert"]);
                        }
                    }
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                MessageBox.Show(ex.ToString());
            }

            qryDatabind.Row.AcceptChanges();
            qryDatabind.RowModified = false;
        }

        private void qryDatabind_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == string.Format("BFSFrageID_{0}", qryFrageWert["BFSFrageID"]))
            {
                qryFrageWert["Wert"] = e.ProposedValue;

                foreach (FilterRegel regel in alFilterRegel)
                {
                    try
                    {
                        regel.Evaluate(handler);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page.Equals(tpgSuchen))
            {
                ActiveSQLQuery = qryClientTree;
            }
        }

        private void treClient_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if data has changed on control
            if (ctlBfsDossier.DataHasChanged)
            {
                if (DataHasChanged())
                {
                    // logging
                    _logger.Debug("data has changed, do not refresh here, stop");

                    // do not continue loading due to refresh data --> already done
                    return;
                }
            }

            // setup controls
            ctlBfsDossier.Visible = false;
            ShowHidePanelFragenDetail(false);

            if (e.Node != null && !DBUtil.IsEmpty(e.Node.GetValue("BFSDossierID")))
            {
                // logging
                _logger.Debug(String.Format("BFSDossierID is not empty, BFSDossierID='{0}'", e.Node.GetValue("BFSDossierID")));

                int bfsDossierID = (int)e.Node.GetValue("BFSDossierID");

                // show ctlBfsDossier only if necessary
                if (DBUtil.IsEmpty(e.Node.GetValue("BFSDossierPersonID")))
                {
                    // logging
                    _logger.Debug("BFSDossierPersonID is empty");

                    ActiveSQLQuery = ctlBfsDossier.SQLQuery;
                    ctlBfsDossier.Init(bfsDossierID);
                    ctlBfsDossier.Visible = true;
                }
                else
                {
                    // logging
                    _logger.Debug(String.Format("BFSDossierPersonID is not empty, BFSDossierPersonID='{0}'", e.Node.GetValue("BFSDossierPersonID")));

                    // setup controls
                    ActiveSQLQuery = qryDatabind;
                    qryFrageWert.Fill(bfsDossierID);

                    BuildControls((int)e.Node.GetValue("BFSDossierPersonID"), (int)e.Node.GetValue("BFSKategorieCode"), (int)e.Node.GetValue("BFSLeistungsfilterCode"));
                    ShowHidePanelFragenDetail(true);
                }
            }

            // logging
            _logger.Debug("done");
        }

        private void treClient_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            // allow change focus only if data can be saved
            if (ctlBfsDossier.Visible)
            {
                e.CanFocus = ctlBfsDossier.SaveChangedData();
            }
            else
            {
                e.CanFocus = ((IKissDataNavigator)this).SaveData();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void BuildControls(Int32 bfsDossierPersonID, Int32 bfsKategorieCode, Int32 bfsLeistungsfilterCode)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("bfsDossierPersonID='{0}', bfsKategorieCode='{1}', bfsLeistungsfilterCode='{2}'", bfsDossierPersonID, bfsKategorieCode, bfsLeistungsfilterCode));

            try
            {
                alFilterRegel.Clear();

                qryDatabind.UnbindControls();
                panFragen.Controls.Clear();

                qryDatabind.DataTable.Clear();
                qryDatabind.DataTable.Columns.Clear();
                qryDatabind.DataTable.Columns.Add("Row");
                qryDatabind.Insert(String.Empty);

                // logging
                _logger.Debug("foreach row in qryFrageWert - add types");

                foreach (DataRow row in qryFrageWert.DataTable.Select(
                            String.Format("BfsDossierPersonID = {0} AND (BfsKategorieCode = {1} OR (BfsKategorieCode IS NULL AND {1} = -1))", bfsDossierPersonID, bfsKategorieCode)))
                {
                    String fieldName = String.Format("BFSFrageID_{0}", row["BFSFrageID"]);

                    // logging
                    if (HEAVY_DEBUG)
                    {
                        _logger.Debug(String.Format("fieldName='{0}'", fieldName));
                    }

                    if (!qryDatabind.DataTable.Columns.Contains(fieldName))
                    {
                        // logging
                        if (HEAVY_DEBUG)
                        {
                            _logger.Debug(String.Format("BFSFeldCode='{0}'", Convert.ToInt32(row["BFSFeldCode"])));
                        }

                        switch (Convert.ToInt32(row["BFSFeldCode"]))
                        {
                            /*
                                2 Text
                                4 Zahl
                                5 Datum
                                7 Checkbox
                                8 Auswahl
                            */
                            case 4:
                                qryDatabind.DataTable.Columns.Add(fieldName, typeof(Decimal));
                                break;

                            case 5:
                                qryDatabind.DataTable.Columns.Add(fieldName, typeof(DateTime));
                                break;

                            case 7:
                                qryDatabind.DataTable.Columns.Add(fieldName, typeof(Boolean));
                                break;

                            case 8:
                                qryDatabind.DataTable.Columns.Add(fieldName, typeof(Int32));
                                break;

                            default:
                                qryDatabind.DataTable.Columns.Add(fieldName);
                                break;
                        }
                    }

                    qryDatabind.Row[fieldName] = row["Wert"];
                } // [foreach row in qryFrageWert]
                qryDatabind.DataSet.AcceptChanges();
                qryDatabind.RowModified = false;

                // logging
                _logger.Debug("foreach row in qryFrageWert - setup controls for questions");

                Int32 top = 0;

                foreach (DataRow row in qryFrageWert.DataTable.Select(
                    String.Format("BfsDossierPersonID = {0} AND (BfsKategorieCode = {1} OR (BfsKategorieCode IS NULL AND {1} = -1))", bfsDossierPersonID, bfsKategorieCode)))
                {
                    String bfsFrageID = String.Format("{0}", row["BFSFrageID"]);

                    if (top == 0)
                    {
                        qryFrageWert.Find(String.Format("BFSFrageID = '{0}'", bfsFrageID));
                        top += 10;
                    }

                    String fieldName = String.Format("BFSFrageID_{0}", row["BFSFrageID"]);

                    // logging
                    if (HEAVY_DEBUG)
                    {
                        _logger.Debug(String.Format("bfsFrageID='{0}', fieldName='{1}', top='{2}', Variable='{3}', Frage='{4}', BFSFeldCode='{5}'", bfsFrageID, fieldName, top, row["Variable"], row["Frage"], row["BFSFeldCode"]));
                    }

                    {
                        // Variable
                        KissLabel lbl = new KissLabel();
                        lbl.Text = String.Format("{0}", row["Variable"]);
                        lbl.Tag = bfsFrageID;
                        lbl.Top = top;
                        lbl.Left = 10;
                        lbl.Width = 60;
                        panFragen.Controls.Add(lbl);

                        lbl.Click += lbl_Click;
                    }

                    {
                        // Frage
                        KissLabel lbl = new KissLabel();
                        lbl.Text = String.Format("{0}", row["Frage"]);
                        lbl.Tag = bfsFrageID;
                        lbl.Left = 75;
                        lbl.Top = top;
                        lbl.Width = 250;
                        panFragen.Controls.Add(lbl);

                        lbl.Click += lbl_Click;
                    }

                    {
                        //Control zur Frage einfügen
                        //Hier muss nun entschieden werden wie das Control dargestellt wird (Mussfeld oder nicht, ein- oder augeblendet).
                        //Dies geschieht anhand der Filterführung und der in abhängigkeit stehenden Feldern
                        Control edt;

                        switch (Convert.ToInt32(row["BFSFeldCode"]))
                        {
                            /*
                                2 Text
                                4 Zahl
                                5 Datum
                                7 Checkbox
                                8 Auswahl
                            */
                            case 2:
                                edt = new KissTextEdit();
                                ((KissTextEdit)edt).Loaded();
                                edt.Width = 250;
                                break;

                            case 4:
                                edt = new KissCalcEdit();
                                ((KissCalcEdit)edt).Loaded();
                                var properties = ((KissCalcEdit)edt).Properties;
                                properties.Buttons.Clear();
                                var devexpressFormat = TranslateBFSFormat2DevExpressFormat(row["BFSFormat"] as string);
                                if (devexpressFormat != null)
                                {
                                    properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                    properties.DisplayFormat.FormatString = devexpressFormat;
                                    properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                    properties.EditFormat.FormatString = devexpressFormat;
                                }
                                edt.Width = 250;
                                break;

                            case 5:
                                edt = new KissDateEdit();
                                ((KissDateEdit)edt).Loaded();
                                edt.Width = 250;
                                break;

                            case 7:
                                edt = new KissCheckEdit();
                                ((KissCheckEdit)edt).Loaded();
                                edt.Width = 20;
                                break;

                            case 8:
                                edt = new KissLookUpEdit();
                                ((KissLookUpEdit)edt).Loaded();

                                string bfsLOVName = row["BFSLOVName"] as string;
                                if (!string.IsNullOrEmpty(bfsLOVName))
                                {
                                    if (!_htBFSLOVName.ContainsKey(bfsLOVName) || (bfsLOVName != "BaBeruf" && bfsLOVName != "BaGemeinde" && bfsLOVName != "BaPLZ"))
                                    {
                                        SqlQuery qry;
                                        switch (bfsLOVName)
                                        {
                                            case "BaBeruf":
                                                qry = DBUtil.OpenSQL(@"
                                                    SELECT Code = BFSCode, Text = Beruf
                                                    FROM dbo.BaBeruf WITH (READUNCOMMITTED)
                                                    ORDER BY SortKey, Code",
                                                    bfsLOVName);
                                                break;

                                            case "BaGemeinde":
                                                qry = DBUtil.OpenSQL(@"
                                                    SELECT Code = BFSCode, Text = IsNull(Name, '') -- + IsNull(' (' + CONVERT(VARCHAR, PLZ) + ')', '')
                                                    FROM dbo.BaGemeinde WITH (READUNCOMMITTED)
                                                    WHERE GemeindeAufhebungDatum IS NULL
                                                    ORDER BY [Name], Code",
                                                    bfsLOVName);
                                                break;

                                            case "BaPLZ":
                                                qry = DBUtil.OpenSQL(@"
                                                    SELECT Code = BFSCode, Text = CONVERT(VARCHAR, PLZ)  -- + IsNull(' ' + Name, '')
                                                    FROM dbo.BaPLZ WITH (READUNCOMMITTED)
                                                    ORDER BY SortKey, Code",
                                                    bfsLOVName);
                                                break;

                                            default:
                                                qry = DBUtil.OpenSQL(@"
                                                    SELECT Code, Text
                                                    FROM dbo.BFSLOVCode WITH (READUNCOMMITTED)
                                                    WHERE LOVName = {0}
                                                      AND '%,' + IsNull(Filter, CONVERT(VARCHAR, {1})) + ',%' LIKE '%,'+CONVERT(VARCHAR, {1})+',%'
                                                    ORDER BY SortKey, Code",
                                                    bfsLOVName, bfsLeistungsfilterCode);
                                                break;
                                        }

                                        DataRow newRow = qry.DataTable.NewRow();
                                        newRow["Text"] = String.Empty;
                                        qry.DataTable.Rows.InsertAt(newRow, 0);
                                        newRow.AcceptChanges();

                                        _htBFSLOVName[bfsLOVName] = qry;
                                    }
                                    ((KissLookUpEdit)edt).LoadQuery((SqlQuery)_htBFSLOVName[bfsLOVName]);
                                }

                                edt.Width = 250;

                                break;

                            default:
                                edt = new KissLabel();
                                break;
                        }

                        edt.Top = top;

                        if (edt.Left == 0)
                        {
                            edt.Left = 330;
                        }

                        panFragen.Controls.Add(edt);

                        if (edt is IKissBindableEdit)
                        {
                            ((IKissBindableEdit)edt).DataSource = qryDatabind;
                            ((IKissBindableEdit)edt).DataMember = fieldName;

                            edt.Enter += edtWert_Enter;
                        }

                        edt.Tag = bfsFrageID;

                        if ((bool)row["Editierbar"])
                        {
                            try
                            {
                                int excelFarbCode = (int)row["ExcelFarbCode"];

                                FilterRegel regel = new FilterRegel((IKissEditable)edt, row["FilterRegel"] as String, excelFarbCode);
                                regel.Evaluate(handler);

                                alFilterRegel.Add(regel);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            ((IKissEditable)edt).EditMode = EditModeType.ReadOnly;
                        }
                    }

                    // logging
                    if (HEAVY_DEBUG)
                    {
                        _logger.Debug(String.Format("PlausiFehler='{0}'", row["PlausiFehler"]));
                    }

                    // falls Fehler in BFSWert --> Bildi anzeigen
                    if (row["PlausiFehler"] != DBNull.Value && row["PlausiFehler"] != null && (string)row["PlausiFehler"] != string.Empty)
                    {
                        PictureBox picFehler = new PictureBox();
                        picFehler.Image = KissImageList.GetSmallImage(83); //Ausrufezeichen
                        picFehler.Top = top + 5;
                        picFehler.Left = 600;
                        picFehler.Height = 20;
                        picFehler.Tag = bfsFrageID;

                        panFragen.Controls.Add(picFehler);

                        // attach click-event
                        picFehler.Click += pic_Click;

                        // set tooltip on picture for faster error tracking
                        ttpError.SetToolTip(picFehler, Convert.ToString(row["PlausiFehler"]));
                    }

                    top += 23;
                } // [foreach (DataRow row in qryFrageWert.DataTable.Select]
                qryDatabind.BindControls();
            }
            catch (Exception ex)
            {
                // exception occured, show error
                KissMsg.ShowError("CtlBfsDossiers", "ErrorInBuildControls", "Es ist ein Fehler in der Verarbeitung aufgetreten, die Darstellung ist möglicherweise nicht korrekt.", ex);

                // logging
                _logger.Error(String.Format("Error in BuildControls(): '{0}'", ex.Message));
            }

            // logging
            _logger.Debug("done");
        }

        private string TranslateBFSFormat2DevExpressFormat(string bfsFormat)
        {
            switch (bfsFormat)
            {
                case "F0":
                    return "N0";

                case "F1":
                    return "N1";

                case "F2":
                    return "N2";

                case "F3":
                    return "N3";

                case "F4":
                    return "N4";

                default:
                    return bfsFormat;
            }
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            ActiveSQLQuery = qryClientTree;

            edtNurAnfangszustandX.EditValue = true;
            edtNurStichtagX.EditValue = true;
            edtBaPersonIDX.LookupID = null;

            base.NewSearch();

            edtErhebungsjahrX.Text = DBUtil.GetConfigValue(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year).ToString();
            edtErhebungsjahrX.Focus();

            // setup flags
            _askedUserReloadData = false;
        }

        protected override void RunSearch()
        {
            try
            {
                ctlBfsDossier.Visible = false;
                ShowHidePanelFragenDetail(false);

                Cursor.Current = Cursors.WaitCursor;
                string selStatement = _originalSelectStatement;

                System.Diagnostics.Debug.WriteLine("selStatement " + selStatement);

                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
                {
                    if (ctl is IKissBindableEdit)
                    {
                        System.Diagnostics.Debug.WriteLine(ctl.Name);

                        string token = "{" + ctl.Name + "}";
                        if (selStatement.Contains(token))
                        {
                            object editValue = AssemblyLoader.GetPropertyValue(ctl, ((IKissBindableEdit)ctl).GetBindablePropertyName());
                            if (!DBUtil.IsEmpty(editValue))
                            {
                                selStatement = selStatement.Replace(token, DBUtil.SqlLiteral(editValue));
                            }
                            else
                            {
                                selStatement = selStatement.Replace(token, "NULL");
                            }
                        }
                    }
                }

                qryClientTree.Fill(selStatement);
            }
            catch (Exception ex)
            {
                if (ex is KissErrorException)
                {
                    ((KissErrorException)ex).ShowMessage();
                }

                this.tabControlSearch.SelectedTabIndex = tabControlSearch.TabPages.IndexOf(tpgSuchen);
            }
            finally
            {
                //expand first level
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node1 in this.treClient.Nodes)
                {
                    node1.Expanded = true;
                }

                // update counter label
                this.UpdateCounterLabel();

                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Private Methods

        private bool DataHasChanged()
        {
            // set flags

            // ask user to reload data if necessary (ask user only once per search)
            if (!_askedUserReloadData)
            {
                // user asked
                _askedUserReloadData = true;

                if (KissMsg.ShowQuestion("CtlBfsDossier", "AskUserReloadData", "Die angezeigten Daten wurden verändert. Wollen Sie die Daten neu laden?", false))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        // refresh data (reapply search)
                        treClient.SaveState();
                        RunSearch();
                        treClient.RefreshDataSource();
                        treClient.LoadState();

                        // setup flags
                        _askedUserReloadData = false;

                        // on control
                        ctlBfsDossier.DataHasChanged = false;

                        // refreshed
                        return true;
                    }
                    catch { }
                    finally { Cursor = Cursors.Default; }
                }
            }

            // not refreshed
            return false;
        }

        private void GetFunctionValue(object sender, AdditionalFunctionEventArgs e)
        {
            switch (e.Name)
            {
                case "getvalue":
                    {
                        try
                        {
                            e.ReturnValue = GetValueOfQuestion(e.GetParameters()[0] as String);
                        }
                        catch (NullReferenceException)
                        {
                            e.ReturnValue = string.Empty;
                        }

                        break;
                    }

                case "getyears":
                    {
                        try
                        {
                            DateTime dateFrom = Convert.ToDateTime(e.GetParameters()[0]);
                            DateTime dateTo = Convert.ToDateTime(e.GetParameters()[1]);
                            TimeSpan span = dateTo.Subtract(dateFrom);
                            e.ReturnValue = (int)((span.Days + 0.5) / 365.25);
                        }
                        catch
                        {
                            e.ReturnValue = 0;
                        }
                        break;
                    }

                case "getstichtag":
                    {
                        try
                        {
                            e.ReturnValue = Convert.ToDateTime(string.Format("31.12.{0}", DBUtil.GetConfigInt(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year)));
                        }
                        catch
                        {
                            e.ReturnValue = 0;
                        }

                        break;
                    }

                case "contains":
                    {
                        try
                        {
                            string valueFind = (e.GetParameters()[0]).ToString();
                            string valueList = (e.GetParameters()[1] as String);
                            bool valueFound = false;

                            foreach (string aString in valueList.Split(','))
                            {
                                if (aString == valueFind)
                                    valueFound = true;
                            }

                            e.ReturnValue = valueFound;
                        }
                        catch
                        {
                            e.ReturnValue = false;
                        }

                        break;
                    }

                case "geterhebungsjahr":
                    {
                        try
                        {
                            e.ReturnValue = Convert.ToInt32(DBUtil.GetConfigInt(@"System\Sostat\Erhebungsjahr", DateTime.Now.Year));
                        }
                        catch
                        {
                            e.ReturnValue = 0;
                        }

                        break;
                    }

                case "getgeburtsjahr":
                    {
                        try
                        {
                            e.ReturnValue = Convert.ToInt32(Convert.ToDateTime(GetValueOfQuestion(e.GetParameters()[0] as String)).Year);
                        }
                        catch
                        {
                            e.ReturnValue = 0;
                        }

                        break;
                    }

                default:
                    throw new NotSupportedException(e.Name);
            }
        }

        private object GetValueOfQuestion(string feldNummer)
        {
            object valueOfQuestion = null;

            foreach (DataRow row in qryFrageWert.DataTable.Select(string.Format("Variable = '{0}'", feldNummer)))
            {
                if (row["Wert"] == DBNull.Value)
                    valueOfQuestion = null;
                else
                    valueOfQuestion = row["Wert"];
            }

            return valueOfQuestion;
        }

        private void ShowHidePanelFragenDetail(bool visible)
        {
            panFragen.Visible = visible;
            panDetail.Visible = visible;
            splitterFrage.Visible = visible;
        }

        private void UpdateCounterLabel()
        {
            // Anzahl Dossiers anzeigen
            var counter = Utils.ConvertToInt(qryClientTree["Anzahl"]);

            // set counter label
            lblEntriesCount.Text = String.Format("Anzahl Dossiers: {0}", counter);
        }

        #endregion

        #endregion
    }
}