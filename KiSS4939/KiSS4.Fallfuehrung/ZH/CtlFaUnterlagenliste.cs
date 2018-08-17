using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using SharpLibrary.WinControls;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace KiSS4.Fallfuehrung.ZH
{
    public partial class CtlFaUnterlagenliste : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int ANZAHL_REITER = 10; // Anzahl Reiter die im Layout vorerfasst sind. Name= tbpReiterN
        const string CLASSNAME = "CtlFaUnterlagenliste";

        #endregion

        #region Private Fields

        private int _faFallID;
        private int? _faLeistungID;
        private string _filter = "";
        private bool _isLoading = true;
        private bool _istAlim;
        private bool _transactionExistsBeforePost;

        #endregion

        #endregion

        #region Constructors

        public CtlFaUnterlagenliste()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlFaUnterlagenliste_Load(object sender, EventArgs e)
        {
            //qryUnterlagen.Last();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            gvwAll.CollapseAllGroups();
        }

        private void btnDrucken_Click(object sender, EventArgs e)
        {
            GetKissMainForm().ContextPrint(this, "FaUnterlagenlisteNeu");
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            gvwAll.ExpandAllGroups();
        }

        private void gvwAll_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!qryUnterlagenliste.CanUpdate)
            {
                return;
            }

            qryUnterlagen.RowModified = true;
        }

        private void gvwAll_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (!qryUnterlagenliste.CanUpdate)
            {
                return;
            }

            if (e.Column.FieldName == "Erhalten") // Checkbox
            {
                if (e.Value.ToString() == "True")
                {
                    qryUnterlagenliste["ErhaltenDatum"] = DateTime.Now;
                    qryUnterlagenliste["Erhalten"] = 1;
                }
                else
                {
                    qryUnterlagenliste["ErhaltenDatum"] = null;
                    qryUnterlagenliste["Erhalten"] = 0;
                }

                gvwAll.SetRowCellValue(e.RowHandle, gvwAll.Columns["ErhaltenDatum"], qryUnterlagenliste["ErhaltenDatum"]);
                gvwAll.SetRowCellValue(e.RowHandle, gvwAll.Columns["Erhalten"], qryUnterlagenliste["Erhalten"]);
            }
            else if (e.Column.FieldName == "ErhaltenDatum") // Datum
            {
                if (e.Value == null)
                {
                    qryUnterlagenliste["ErhaltenDatum"] = null;
                    qryUnterlagenliste["Erhalten"] = 0;
                }
                else
                {
                    try // Datum aus e.Value in Datasource einfüllen will nur so klappen (im Zusammenhang mit dem Leerschlag wird sonst nicht geupdatet)
                    {
                        IFormatProvider culture = new CultureInfo("en-US", true);
                        qryUnterlagenliste["ErhaltenDatum"] = DateTime.Parse(e.Value.ToString(), culture, DateTimeStyles.NoCurrentDateDefault);
                        gvwAll.SetRowCellValue(e.RowHandle, gvwAll.Columns["ErhaltenDatum"], qryUnterlagenliste["ErhaltenDatum"]);
                    }
                    catch (FormatException)
                    {
                        ;
                    }

                    qryUnterlagenliste["Erhalten"] = 1;
                }

                gvwAll.SetRowCellValue(e.RowHandle, gvwAll.Columns["Erhalten"], qryUnterlagenliste["Erhalten"]);
                gvwAll.SetRowCellValue(e.RowHandle, gvwAll.Columns["ErhaltenDatum"], qryUnterlagenliste["ErhaltenDatum"]);
            }
        }

        private void gvwAll_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Handled = false;

            if (e.Column.FieldName == "Zusatz")
            {
                bool hasZusatz = false;
                object hz = gvwAll.GetRowCellValue(e.RowHandle, gvwAll.Columns["HatZusatzFeld"]);
                if (hz is bool)
                {
                    hasZusatz = (bool)hz;
                }

                if (hasZusatz && qryUnterlagen.CanUpdate)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.Bisque;
                }
            }
        }

        private void gvwAll_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info == null)
            {
                return;
            }

            if (info.Column.FieldName == "GruppeID")
            {
                int notwendig = 0;
                int erhalten = 0;

                string gruppeName = "";
                int gruppeId = Convert.ToInt32(gvwAll.GetGroupRowDisplayText(e.RowHandle));

                for (int i = 0; i < gvwAll.DataRowCount; i++)
                {
                    if (gruppeId == (int)gvwAll.GetRowCellValue(i, gvwAll.Columns["GruppeID"]))
                    {
                        gruppeName = gvwAll.GetRowCellValue(i, gvwAll.Columns["Gruppe"]).ToString();
                        if ((bool)gvwAll.GetRowCellValue(i, gvwAll.Columns["Notwendig"]))
                        {
                            notwendig++;
                        }

                        if ((bool)gvwAll.GetRowCellValue(i, gvwAll.Columns["Erhalten"]))
                        {
                            erhalten++;
                        }
                    }
                }

                info.GroupText = gruppeName + "  (" + notwendig.ToString() + "/" + erhalten.ToString() + ")";
            }
        }

        private void gvwAll_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvwAll.IsGroupRow(gvwAll.FocusedRowHandle) || qryUnterlagenliste["Name"] == null)
            {
                lblName.Text = "";
            }
            else
            {
                lblName.Text = qryUnterlagenliste["Name"].ToString();
            }
        }

        private void gvwAll_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gvwAll.FocusedColumn.FieldName == "Zusatz")
            {
                e.Cancel = (!HatEinZusatzFeld() || !qryUnterlagen.CanUpdate);
            }
            else if (gvwAll.FocusedColumn.FieldName == "Kurzname")
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = !qryUnterlagen.CanUpdate;
            }
        }

        private void qryUnterlagenKategorie_AfterFill(object sender, EventArgs e)
        {
            for (int reiterNr = 0; reiterNr < ANZAHL_REITER; reiterNr++)
            {
                qryUnterlagenKategorie.Find("ReiterNr=" + Convert.ToString(reiterNr));
                Control objControl = FindControlByName("tbpReiter" + reiterNr, this);
                if (objControl != null)
                {
                    if (Convert.ToString(qryUnterlagenKategorie["ReiterNr"]) == Convert.ToString(reiterNr))
                    {
                        ((TabPageEx)objControl).Title = Convert.ToString(qryUnterlagenKategorie["ReiterText"]);
                        ((TabPageEx)objControl).HideTab = false;
                        grdMain.Visible = true;
                    }
                    else
                    {
                        if (reiterNr == 0)
                        {
                            // Reiter 0 muss immer sichtbar sein, weil sich die Gruppierung des Grids deaktiviert
                            ((TabPageEx)objControl).Title = "         ";
                            ((TabPageEx)objControl).HideTab = false;
                            grdMain.Visible = false;
                        }
                        else
                        {
                            ((TabPageEx)objControl).HideTab = true;
                        }
                    }
                }
            }

            //tabMain.SelectedTabIndex = 0;
            qryUnterlagenKategorie.Find("ReiterNr=" + Convert.ToString(tabMain.SelectedTabIndex));
        }

        private void qryUnterlagen_AfterDelete(object sender, EventArgs e)
        {
            // Löschen mit Transaktion:
            if (Session.Transaction == null)
            {
                return;
            }

            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryUnterlagen_AfterFill(object sender, EventArgs e)
        {
            // Weil PositionChanged nicht kommt, wenn Query leer ist:
            if (qryUnterlagen.Count == 0)
            {
                qryUnterlagen_PositionChanged(sender, e);
            }
        }

        private void qryUnterlagen_AfterPost(object sender, EventArgs e)
        {
            // Speichern mit Transaktion:
            try
            {
                SaveAllListen();
                if (!_transactionExistsBeforePost)
                {
                    Session.Commit();
                }
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowInfo("Error AfterPost:\r\n" + ex.Message);
                throw ex;
            }
            finally
            {
                _transactionExistsBeforePost = false;
            }

            qryUnterlagenliste.Fill(qryUnterlagen["FaUnterlagenID"]);
        }

        private void qryUnterlagen_BeforeDelete(object sender, EventArgs e)
        {
            int tmpID = 0;
            if (!DBUtil.IsEmpty(qryUnterlagen["FaUnterlagenID"]))
            {
                tmpID = (int)qryUnterlagen["FaUnterlagenID"];
            }

            // Löschen mit Transaktion:
            Session.BeginTransaction();
            try
            {
                string sql = "DELETE FaUnterlagenliste where FaUnterlagenID=" + tmpID.ToString();
                sql += ";DELETE FaUnterlagenKategorie where FaUnterlagenID=" + tmpID.ToString();
                DBUtil.ExecSQL(sql);
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryUnterlagen_BeforePost(object sender, EventArgs e)
        {
            qryUnterlagen["MutiertUserID"] = Session.User.UserID;
            qryUnterlagen["MutiertUser"] = Session.User.LogonName;
            qryUnterlagen["MutiertDatum"] = DateTime.Now;
            if (Session.Transaction != null)
            {
                _transactionExistsBeforePost = true;
            }
            else
            {
                // Speichern mit Transaktion:
                Session.BeginTransaction();
                _transactionExistsBeforePost = false;
            }
        }

        private void qryUnterlagen_DeleteError(object sender, UnhandledExceptionEventArgs e)
        {
            // Fehler beim Löschen:
            if (Session.Transaction != null)
            {
                Session.Rollback();
            }

            KissMsg.ShowInfo(
                CLASSNAME,
                "DeleteFehler",
                "Beim Löschen ist ein unbekannter Fehler aufgetreten.");
        }

        private void qryUnterlagen_PositionChanged(object sender, EventArgs e)
        {
            // Details neu anzeigen:
            qryUnterlagen.ApplyUserRights();
            qryUnterlagen.CanUpdate &= DBUtil.IsEmpty(qryUnterlagen["LeistungDatumBis"]);
            repedtCheckBox.Enabled = qryUnterlagen.CanUpdate;
            qryUnterlagenKategorie.Fill(qryUnterlagen["FaUnterlagenID"], _filter);
            qryUnterlagenliste.Fill(qryUnterlagen["FaUnterlagenID"]);
            qryUnterlagenliste.CanUpdate = qryUnterlagen.CanUpdate;
        }

        private void qryUnterlagen_PostError(object sender, UnhandledExceptionEventArgs e)
        {
            // Fehler beim Posten:
            if (Session.Transaction != null)
            {
                Session.Rollback();
            }

            KissMsg.ShowInfo(
                CLASSNAME,
                "PostFehler",
                "Beim Speichern ist ein unbekannter Fehler aufgetreten.");
        }

        private void qryUnterlagenliste_AfterFill(object sender, EventArgs e)
        {
            gvwAll.ActiveFilterString = "FaUnterlagenKategorieID=" + Convert.ToString(qryUnterlagenKategorie["FaUnterlagenKategorieID"]);
            gvwAll.ExpandAllGroups();
        }

        private void qryUnterlagenliste_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (qryUnterlagen.CanUpdate)
            {
                qryUnterlagen.RowModified = true;
            }
        }

        private void repedtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!qryUnterlagen.CanUpdate)
            {
                return;
            }

            qryUnterlagen.RowModified = true;
        }

        private void tabMain_SelectedTabChanged(TabPageEx page)
        {
            if (_isLoading)
            {
                return;
            }

            qryUnterlagenKategorie.Find("ReiterNr=" + Convert.ToString(tabMain.SelectedTabIndex));
            SetGridParent();
            gvwAll.ActiveFilterString = "FaUnterlagenKategorieID=" + Convert.ToString(qryUnterlagenKategorie["FaUnterlagenKategorieID"]);
            gvwAll.ExpandAllGroups();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FAUNTERLAGENID":
                    return Utils.ConvertToInt(qryUnterlagen["FaUnterlagenID"]);
                case "FAUNTERLAGENKATEGORIEID":
                    return Utils.ConvertToInt(qryUnterlagenKategorie["FaUnterlagenKategorieID"]);
                case "ANGEMUSERID":
                    return Session.User.UserID;
                case "ANGEMUSERLOGON":
                    return Session.User.LogonName;
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string name, Image titleImage, int leistungId, int fallId, bool istAlim)
        {
            if (_faLeistungID.HasValue && _faLeistungID.Value.Equals(leistungId))
            {
                return; // Maske nur bei anderer Leistung neu laden
            }

            _faLeistungID = leistungId;
            picTitel.Image = titleImage;
            lblTitel.Text = name;

            _faFallID = fallId;
            _istAlim = istAlim;
            if (_istAlim)
            {
                _filter = "FA";
            }
            else
            {
                _filter = "F";
            }

            tabMain.SelectedTabIndex = 0;

            SetGridParent();

            // Set values to true here; they will be set to false by the modul tree if the user has not enough rights.
            qryUnterlagen.CanDelete = true;
            qryUnterlagen.CanInsert = true;
            qryUnterlagen.CanUpdate = true;

            // Daten öffnen:
            qryUnterlagen.Fill(_faLeistungID.Value);
            qryUnterlagenKategorie.Fill(qryUnterlagen["FaUnterlagenID"], _filter);
            //KissMsg.ShowInfo(Convert.ToString(qryUnterlagenKategorie["ReiterNr"]));

            _isLoading = false;
            tabMain_SelectedTabChanged(null);
        }

        public override bool OnAddData()
        {
            if (!qryUnterlagen.Post())
            {
                return false;
            }

            // Prüfen ob bereits Unterlagenlisten vorhanden sind. Falls ja, fragen ob eine weitere Liste erstellt werden muss
            var hasUnterlagen = DBUtil.ExecuteScalarSQLThrowingException(@"
                IF EXISTS(SELECT TOP 1 1
                          FROM dbo.FaUnterlagen UNT WITH (READUNCOMMITTED)
                          WHERE FaLeistungID = {0})
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                _faLeistungID) as bool? ?? false;

            if (hasUnterlagen)
            {
                var answeredYes = KissMsg.ShowQuestion(
                    CLASSNAME,
                    "UnterlagenlisteBereitsVorhanden",
                    "Es besteht bereits eine Unterlagenliste, soll eine weitere eröffnet werden?");

                if (!answeredYes)
                {
                    return false;
                }
            }

            // Neue Unterlagenliste erstellen
            object faUnterlagenID;
            try
            {
                Session.BeginTransaction();
                DataRow row = qryUnterlagen.Insert();
                qryUnterlagen["FaLeistungID"] = _faLeistungID.Value;
                qryUnterlagen["ErstelltUserID"] = Session.User.UserID;
                qryUnterlagen["ErstelltDatum"] = DateTime.Now;
                qryUnterlagen["MutiertUserID"] = Session.User.UserID;
                qryUnterlagen["MutiertDatum"] = DateTime.Now;
                if (!qryUnterlagen.Post())
                {
                    throw new Exception("Eintrag konnte nicht gespeichert werden.");
                }

                faUnterlagenID = row["FaUnterlagenID"];
                DBUtil.ExecSQLThrowingException(@"
                    -- FaUnterlagenKategorie Eintraege erstellen
                    INSERT INTO FaUnterlagenKategorie (FaUnterlagenID, Bezeichnung, Sortierung, Beschreibung, ReiterText, Filter, FaUnterlagenKategorieVorgabeCode)
                    SELECT {0}, Text, SortKey, Value1, Value2, Value3, Code
                    FROM XLOVCode UC
                    WHERE UC.LOVName = 'FaUnterlagenKategorieVorgabe'
                    AND UC.Value3 = {1};

                    INSERT FaUnterlagenliste
                    (FaUnterlagenID,
                    FaUnterlagenKategorieID,
                    Kurzname,
                    Name,
                    Gruppe,
                    Sortierung,
                    Notwendig,
                    Erhalten,
                    HatZusatzFeld,
                    FaUnterlagenlisteVorgabeID,
                    TabSeite)
                    SELECT
                    {0},
                    UK.FaUnterlagenKategorieID,
                    UV.Kurzname,
                    UV.Name,
                    UV.Gruppe,
                    UV.Sortierung,
                    UV.Default_Notwendig,
                    0,
                    UV.HatZusatzFeld,
                    UV.FaUnterlagenlisteVorgabeID,
                    UV.TabSeite
                    FROM dbo.FaUnterlagenlisteVorgabe UV
                    JOIN dbo.FaUnterlagenKategorie UK
                    ON UK.FaUnterlagenID = {0} AND UV.TabSeite = UK.FaUnterlagenKategorieVorgabeCode;",
                    faUnterlagenID,
                    _filter);
                Session.Commit();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowInfo(ex.Message);
                return false;
            }

            qryUnterlagen.Refresh();
            qryUnterlagenKategorie.Refresh();
            qryUnterlagen.Find(string.Format("FaUnterlagenID = {0}", faUnterlagenID));
            return true;
        }

        public override bool OnSaveData()
        {
            return qryUnterlagen.Post();
        }

        #endregion

        #region Private Methods

        // Findet ein Control mit dem übergegenen Namen und liefert dieses zurück. Ist rekursiv. Wenn nichts gefunden, wird null zurückgegeben
        private Control FindControlByName(string name, Control objParent)
        {
            Control objFound;
            if (objParent == null)
            {
                objParent = this;
            }

            ControlCollection objControls = objParent.Controls;
            foreach (Control  objControl in objControls)
            {
                if (objControl.Name == name)
                {
                    return objControl;
                }

                objFound = FindControlByName(name, objControl);
                if (objFound != null)
                {
                    return objFound;
                }
            }

            return null;
        }

        private bool HatEinZusatzFeld()
        {
            bool hasZusatz = false;
            object hz = qryUnterlagenliste["HatZusatzFeld"];
            if (hz is bool)
            {
                hasZusatz = (bool)hz;
            }

            return hasZusatz;
        }

        private void SaveAllListen()
        {
            // Details speichern:
            qryUnterlagenliste.Post();
            foreach (DataRow row in qryUnterlagenliste.DataTable.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    DBUtil.ExecSQL(@"
                        UPDATE dbo.FaUnterlagenliste
                          SET Notwendig = {0},
                              Erhalten  = {1},
                              ErhaltenDatum = {2},
                              Zusatz    = {3}
                        WHERE FaUnterlagenListeID = {4}",
                        row["Notwendig"],
                        row["Erhalten"],
                        row["ErhaltenDatum"],
                        row["Zusatz"],
                        row["FaUnterlagenListeID"]);
                }
            }
        }

        private void SetGridParent()
        {
            // das Grid dem neuen Reiter zuordnen
            Control objControl = FindControlByName("tbpReiter" + tabMain.SelectedTabIndex, this);
            if (objControl != null)
            {
                grdMain.Parent = objControl;
            }
        }

        #endregion

        #endregion
    }
}