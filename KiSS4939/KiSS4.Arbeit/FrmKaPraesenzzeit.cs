using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    public partial class FrmKaPraesenzzeit : KissSearchForm
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly Pen _blackLine = new Pen(Color.Black, 1);
        private readonly RepositoryItemTextEdit _repositoryItemDisabled = new RepositoryItemTextEdit();

        #endregion

        #region Private Fields

        private int _anzTage;
        private bool _askedToChange;
        private bool _isActMonth;
        private int _repApvNr;
        private int _repCoach;
        private int _repFachbereich;
        private int _repFachleitung;
        private int _repKlientID;
        private int _repKurs;
        private int _repUserKA;
        private int _repZusatz;
        private int _selMonth;
        private int _selYear;

        #endregion

        #endregion

        #region Constructors

        public FrmKaPraesenzzeit()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var prms = new NamedPrm[10];

            prms[0] = new NamedPrm("UserKA", _repUserKA);
            prms[1] = new NamedPrm("Monat", _selMonth);
            prms[2] = new NamedPrm("Jahr", _selYear);
            prms[3] = new NamedPrm("KlientID", _repKlientID);
            prms[4] = new NamedPrm("APVNr", _repApvNr);
            prms[5] = new NamedPrm("Zusatz", _repZusatz);
            prms[6] = new NamedPrm("CoachID", _repCoach);
            prms[7] = new NamedPrm("FachbereichID", _repFachbereich);
            prms[8] = new NamedPrm("FachleitungID", _repFachleitung);
            prms[9] = new NamedPrm("KursID", _repKurs);

            RepUtil.ExecuteReport("KAPraesenzzeitAlle", KissReportDestination.Viewer, prms);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void ddlMonatX_EditValueChanged(object sender, EventArgs e)
        {
            if (qryPraesenz.IsFilling)
            {
                return;
            }

            RefreshView();
        }

        private void dlgFachbereichX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                if (dlg.FachbereichSuchen(dlgFachbereichX.Text, e.ButtonClicked))
                {
                    dlgFachbereichX.EditValue = dlg["Text"];
                    dlgFachbereichX.LookupID = dlg["Code"];
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void dlgKlientX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                if (dlg.KAPersonSuchen(dlgKlientX.Text, e.ButtonClicked))
                {
                    dlgKlientX.EditValue = dlg["Name"];
                    dlgKlientX.LookupID = dlg["BaPersonID"];
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void dlgKursX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            using (var dlg = new DlgAuswahl())
            {
                if (dlg.KurserfassungSuchen(dlgKursX.Text, e.ButtonClicked, KaKurssucheCaller.Praesenzzeiterfassung))
                {
                    dlgKursX.EditValue = dlg["KursNrName"];
                    dlgKursX.LookupID = dlg["KaKurserfassungID"];
                    dlgKursX.Focus();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void FrmKaPraesenzzeit_KeyDown(object sender, KeyEventArgs e)
        {
            ctlGotoFall.CtlGotoFall_KeyDown(sender, e);
        }

        private void FrmKaPraesenzzeit_Load(object sender, EventArgs e)
        {
            gvPraesenz.Appearance.HorzLine.BackColor = Color.DarkGray;
            gvPraesenz.Appearance.VertLine.BackColor = Color.DarkGray;
            //gvPraesenz.Appearance.OddRow.Font.Underline = true;

            // Monate
            var qry = DBUtil.OpenSQL(@"
                SELECT  Code = 1, Text = 'Jan' UNION ALL
                SELECT  2, 'Feb'  UNION ALL
                SELECT  3, 'März' UNION ALL
                SELECT  4, 'Apr'  UNION ALL
                SELECT  5, 'Mai'  UNION ALL
                SELECT  6, 'Juni' UNION ALL
                SELECT  7, 'Juli' UNION ALL
                SELECT  8, 'Aug'  UNION ALL
                SELECT  9, 'Sep'  UNION ALL
                SELECT 10, 'Okt'  UNION ALL
                SELECT 11, 'Nov'  UNION ALL
                SELECT 12, 'Dez' ");

            ddlMonatX.Properties.DataSource = qry;
            _isActMonth = true;

            foreach (Control ctl in UtilsGui.AllControls(tabControlSearch))
            {
                if (ctl is BaseEdit)
                {
                    ((BaseEdit)ctl).EditValue = null;
                }
            }

            ddlMonatX.EditValue = DateTime.Today.Month;
            edtJahr.EditValue = DateTime.Today.Year;

            _selYear = DateTime.Today.Year;
            _selMonth = DateTime.Today.Month;

            var qry1 = DBUtil.OpenSQL(@"
                SELECT Code = null, Text = null

                UNION

                SELECT Code = KaEinsatzplatzID, Text = dbo.fnLOVText('KaAPV', APVCode)
                FROM dbo.KaEinsatzplatz2 WITH (READUNCOMMITTED)
                WHERE CONVERT(DateTime, DatumVon, 104) <= CONVERT(DateTime, {0} , 104)
                AND (DatumBis IS NULL OR CONVERT(DateTime, DatumBis, 104) >= DATEADD(DAY, -1, DATEADD(MONTH, 1, CONVERT(DateTime, {0} , 104))))
                ORDER BY Text", "01." + _selMonth + "." + _selYear);

            ddlAPVNrX.Properties.DataSource = qry1;
            ddlAPVNrX.Properties.DropDownRows = 7;

            repItemKaPraesenzCode = grdPraesenz.GetLOVLookUpEdit("KaPraesenzCode", true);
            repItemKaPraesenzCode.PopupWidth = 250;
            repItemKaPraesenzCode.DropDownRows = 12;
            repItemKaPraesenzCode.Columns.Clear();
            repItemKaPraesenzCode.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShortText", 20));
            repItemKaPraesenzCode.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", 230));
            repItemKaPraesenzCode.DisplayMember = "ShortText";
            repItemKaPraesenzCode.ReadOnly = !DBUtil.UserHasRight(Name, "U");

            _repositoryItemDisabled.Enabled = false;

            col01.ColumnEdit = repItemKaPraesenzCode;
            col02.ColumnEdit = repItemKaPraesenzCode;
            col03.ColumnEdit = repItemKaPraesenzCode;
            col04.ColumnEdit = repItemKaPraesenzCode;
            col05.ColumnEdit = repItemKaPraesenzCode;
            col06.ColumnEdit = repItemKaPraesenzCode;
            col07.ColumnEdit = repItemKaPraesenzCode;
            col08.ColumnEdit = repItemKaPraesenzCode;
            col09.ColumnEdit = repItemKaPraesenzCode;
            col10.ColumnEdit = repItemKaPraesenzCode;
            col11.ColumnEdit = repItemKaPraesenzCode;
            col12.ColumnEdit = repItemKaPraesenzCode;
            col13.ColumnEdit = repItemKaPraesenzCode;
            col14.ColumnEdit = repItemKaPraesenzCode;
            col15.ColumnEdit = repItemKaPraesenzCode;
            col16.ColumnEdit = repItemKaPraesenzCode;
            col17.ColumnEdit = repItemKaPraesenzCode;
            col18.ColumnEdit = repItemKaPraesenzCode;
            col19.ColumnEdit = repItemKaPraesenzCode;
            col20.ColumnEdit = repItemKaPraesenzCode;
            col21.ColumnEdit = repItemKaPraesenzCode;
            col22.ColumnEdit = repItemKaPraesenzCode;
            col23.ColumnEdit = repItemKaPraesenzCode;
            col24.ColumnEdit = repItemKaPraesenzCode;
            col25.ColumnEdit = repItemKaPraesenzCode;
            col26.ColumnEdit = repItemKaPraesenzCode;
            col27.ColumnEdit = repItemKaPraesenzCode;
            col28.ColumnEdit = repItemKaPraesenzCode;
            col29.ColumnEdit = repItemKaPraesenzCode;
            col30.ColumnEdit = repItemKaPraesenzCode;
            col31.ColumnEdit = repItemKaPraesenzCode;

            FillData();
            SetEditMode();
        }

        private void gvPraesenz_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!_isActMonth && !_askedToChange)
            {
                // HACK: Get flag if editor was open
                bool wasEditorOpen = gvPraesenz.ActiveEditor != null;

                if (wasEditorOpen)
                {
                    // close any open editor to prevent further display problems
                    gvPraesenz.CloseEditor();
                }

                if (!KissMsg.ShowQuestion(Name, "WertNichtInAktMonat_v01", "Geänderter Wert ist nicht im aktuellen Monat!\r\nWert trotzdem ändern?"))
                {
                    gvPraesenz.CancelUpdateCurrentRow();
                }
                else
                {
                    if (DBUtil.IsEmpty(e.Value))
                    {
                        qryPraesenz[e.Column.FieldName] = -1;
                    }
                    else
                    {
                        qryPraesenz[e.Column.FieldName] = e.Value;
                    }
                }

                if (wasEditorOpen)
                {
                    // reshow any open editor to prevent further display problems (the editor will close again later on its own)
                    gvPraesenz.ShowEditor();
                }
            }
            else
            {
                if (DBUtil.IsEmpty(e.Value))
                {
                    qryPraesenz[e.Column.FieldName] = -1;
                }
                else
                {
                    qryPraesenz[e.Column.FieldName] = e.Value;
                }
            }

            if (e.Column != colKlient && e.Column != colBG && e.Column != colVN
                && e.Column != statA && e.Column != statB && e.Column != statC
                && e.Column != statE && e.Column != statF && e.Column != statH
                && e.Column != statG && e.Column != statX && e.Column != statI
                && e.Column != statY && e.Column != statZ)
            {
                if (!DBUtil.IsEmpty(e.Value))
                {
                    if (Convert.ToInt32(e.Value) == 7)
                    {
                        KissMsg.ShowInfo(Name, "BemerkungNichtAusgefuellt", "Code 'H' gewählt.\r\nBemerkung muss ausgefüllt werden!");
                        memBemerkungRTF.Focus();
                    }
                }
            }

            // HACK: (re)apply datasource after closing popup to prevent strange behaviour as reported in #5346
            if (repItemKaPraesenzCode.DataSource != null && repItemKaPraesenzCode.DataSource is SqlQuery)
            {
                var qry = ((SqlQuery)repItemKaPraesenzCode.DataSource);
                repItemKaPraesenzCode.DataSource = null;
                repItemKaPraesenzCode.DataSource = qry;
            }
        }

        private void gvPraesenz_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            Color actCol;

            if (e.Column == be01 || e.Column == be02 || e.Column == be03 ||
                e.Column == be04 || e.Column == be05 || e.Column == be06 ||
                e.Column == be07 || e.Column == be08 || e.Column == be09 ||
                e.Column == be10 || e.Column == be11 || e.Column == be12 ||
                e.Column == be13 || e.Column == be14 || e.Column == be15 ||
                e.Column == be16 || e.Column == be17 || e.Column == be18 ||
                e.Column == be19 || e.Column == be20 || e.Column == be21 ||
                e.Column == be22 || e.Column == be23 || e.Column == be24 ||
                e.Column == be25 || e.Column == be26 || e.Column == be27 ||
                e.Column == be28 || e.Column == be29 || e.Column == be30 ||
                e.Column == be31)
            {
                return;
            }

            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;

            if (e.Column == colKlient || e.Column == colVN || e.Column == colBG)
            {
                actCol = KaUtil.ColReadOnly;
            }
            else if (e.Column == statA || e.Column == statB || e.Column == statC ||
                     e.Column == statE || e.Column == statF || e.Column == statH ||
                     e.Column == statG || e.Column == statX || e.Column == statI ||
                     e.Column == statY || e.Column == statZ)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                actCol = KaUtil.ColStatistics;
            }
            else
            {
                string dayNr = e.Column.Name.Remove(0, 3);
                bool saturdayActive = Utils.ConvertToBool(gvPraesenz.GetRowCellValue(e.RowHandle, "SamstagAktiv" + dayNr));
                bool sundayActive = Utils.ConvertToBool(gvPraesenz.GetRowCellValue(e.RowHandle, "SonntagAktiv" + dayNr));

                var day = DayOfWeek(Convert.ToInt32(dayNr));
                if (day.Equals(System.DayOfWeek.Saturday) && !saturdayActive || day.Equals(System.DayOfWeek.Sunday) && !sundayActive)
                {
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    actCol = KaUtil.ColWeekend;
                }
                else
                {
                    if (gvPraesenz.GetRowCellValue(e.RowHandle, e.Column) == DBNull.Value)
                    {
                        actCol = KaUtil.ColReadOnly;
                    }
                    else
                    {
                        GridColumn tmpGridCol = new GridColumn();

                        switch (Convert.ToInt32(dayNr))
                        {
                            case 1:
                                tmpGridCol = be01;
                                break;

                            case 2:
                                tmpGridCol = be02;
                                break;

                            case 3:
                                tmpGridCol = be03;
                                break;

                            case 4:
                                tmpGridCol = be04;
                                break;

                            case 5:
                                tmpGridCol = be05;
                                break;

                            case 6:
                                tmpGridCol = be06;
                                break;

                            case 7:
                                tmpGridCol = be07;
                                break;

                            case 8:
                                tmpGridCol = be08;
                                break;

                            case 9:
                                tmpGridCol = be09;
                                break;

                            case 10:
                                tmpGridCol = be10;
                                break;

                            case 11:
                                tmpGridCol = be11;
                                break;

                            case 12:
                                tmpGridCol = be12;
                                break;

                            case 13:
                                tmpGridCol = be13;
                                break;

                            case 14:
                                tmpGridCol = be14;
                                break;

                            case 15:
                                tmpGridCol = be15;
                                break;

                            case 16:
                                tmpGridCol = be16;
                                break;

                            case 17:
                                tmpGridCol = be17;
                                break;

                            case 18:
                                tmpGridCol = be18;
                                break;

                            case 19:
                                tmpGridCol = be19;
                                break;

                            case 20:
                                tmpGridCol = be20;
                                break;

                            case 21:
                                tmpGridCol = be21;
                                break;

                            case 22:
                                tmpGridCol = be22;
                                break;

                            case 23:
                                tmpGridCol = be23;
                                break;

                            case 24:
                                tmpGridCol = be24;
                                break;

                            case 25:
                                tmpGridCol = be25;
                                break;

                            case 26:
                                tmpGridCol = be26;
                                break;

                            case 27:
                                tmpGridCol = be27;
                                break;

                            case 28:
                                tmpGridCol = be28;
                                break;

                            case 29:
                                tmpGridCol = be29;
                                break;

                            case 30:
                                tmpGridCol = be30;
                                break;

                            case 31:
                                tmpGridCol = be31;
                                break;
                        }

                        if (gvPraesenz.GetRowCellValue(e.RowHandle, tmpGridCol) == DBNull.Value)
                        {
                            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                            actCol = KaUtil.ColNormal;
                        }
                        else
                        {
                            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                            actCol = KaUtil.ColRemarks;
                        }
                    }
                }
            }

            e.Graphics.FillRectangle(new SolidBrush(actCol), e.Bounds);

            // Set a line at each second row in the grid!
            if ((e.RowHandle % 2) == 1)
            {
                e.Graphics.DrawLine(_blackLine, e.Bounds.Left - 1, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom);
            }
        }

        private void gvPraesenz_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (!(e.Column == col01 || e.Column == col02 || e.Column == col03 ||
                  e.Column == col04 || e.Column == col05 || e.Column == col06 ||
                  e.Column == col07 || e.Column == col08 || e.Column == col09 ||
                  e.Column == col10 || e.Column == col11 || e.Column == col12 ||
                  e.Column == col13 || e.Column == col14 || e.Column == col15 ||
                  e.Column == col16 || e.Column == col17 || e.Column == col18 ||
                  e.Column == col19 || e.Column == col20 || e.Column == col21 ||
                  e.Column == col22 || e.Column == col23 || e.Column == col24 ||
                  e.Column == col25 || e.Column == col26 || e.Column == col27 ||
                  e.Column == col28 || e.Column == col29 || e.Column == col30 ||
                  e.Column == col31))
            {
                return;
            }

            if (gvPraesenz.GetRowCellValue(e.RowHandle, e.Column) == DBNull.Value)
            {
                //set an ineditable editor
                e.RepositoryItem = _repositoryItemDisabled;
            }
            else
            {
                e.RepositoryItem = repItemKaPraesenzCode;
            }
        }

        private void gvPraesenz_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                if (e.FocusedColumn != colKlient && e.FocusedColumn != colBG && e.FocusedColumn != colVN &&
                    e.FocusedColumn != statA && e.FocusedColumn != statB && e.FocusedColumn != statC &&
                    e.FocusedColumn != statE && e.FocusedColumn != statF && e.FocusedColumn != statH &&
                    e.FocusedColumn != statG && e.FocusedColumn != statX && e.FocusedColumn != statI &&
                    e.FocusedColumn != statY && e.FocusedColumn != statZ)
                {
                    if (e.FocusedColumn != null)
                    {
                        string dayNr = e.FocusedColumn.Name.Remove(0, 3);
                        bool saturdayActive = Utils.ConvertToBool(qryPraesenz["SamstagAktiv" + dayNr]);
                        bool sundayActive = Utils.ConvertToBool(qryPraesenz["SonntagAktiv" + dayNr]);

                        var day = DayOfWeek(Convert.ToInt32(dayNr));
                        if ((day.Equals(System.DayOfWeek.Saturday) && !saturdayActive) || (day.Equals(System.DayOfWeek.Sunday) && !sundayActive) || (DBUtil.IsEmpty(qryPraesenz["Code" + dayNr])))
                        {
                            memBemerkungRTF.EditValue = null;
                            memBemerkungRTF.EditMode = EditModeType.ReadOnly;
                        }
                        else
                        {
                            memBemerkungRTF.EditMode = (DBUtil.UserHasRight(Name, "U")) ? EditModeType.Normal : EditModeType.ReadOnly;
                            memBemerkungRTF.DataMember = "Bem" + dayNr;
                            memBemerkungRTF.EditValue = qryPraesenz["Bem" + dayNr].ToString();
                        }
                    }
                }
                else
                {
                    memBemerkungRTF.EditValue = null;
                    memBemerkungRTF.EditMode = EditModeType.ReadOnly;
                }
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error in gvPraesenz_FocusedColumnChanged(...)", ex.Message);
            }
        }

        private void gvPraesenz_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvPraesenz.FocusedColumn != colKlient && gvPraesenz.FocusedColumn != colBG && gvPraesenz.FocusedColumn != colVN &&
                    gvPraesenz.FocusedColumn != statA && gvPraesenz.FocusedColumn != statB && gvPraesenz.FocusedColumn != statC &&
                    gvPraesenz.FocusedColumn != statE && gvPraesenz.FocusedColumn != statF && gvPraesenz.FocusedColumn != statH &&
                    gvPraesenz.FocusedColumn != statG && gvPraesenz.FocusedColumn != statX && gvPraesenz.FocusedColumn != statI &&
                    gvPraesenz.FocusedColumn != statY && gvPraesenz.FocusedColumn != statZ)
                {
                    if (gvPraesenz.FocusedColumn != null)
                    {
                        string dayNr = gvPraesenz.FocusedColumn.Name.Remove(0, 3);
                        bool saturdayActive = Utils.ConvertToBool(gvPraesenz.GetRowCellValue(e.FocusedRowHandle, "SamstagAktiv" + dayNr));
                        bool sundayActive = Utils.ConvertToBool(gvPraesenz.GetRowCellValue(e.FocusedRowHandle, "SonntagAktiv" + dayNr));

                        var day = DayOfWeek(Convert.ToInt32(dayNr));
                        if ((day.Equals(System.DayOfWeek.Saturday) && !saturdayActive) || (day.Equals(System.DayOfWeek.Sunday) && !sundayActive) || (DBUtil.IsEmpty(qryPraesenz["Code" + dayNr])))
                        {
                            memBemerkungRTF.EditValue = null;
                            memBemerkungRTF.EditMode = EditModeType.ReadOnly;
                        }
                        else
                        {
                            memBemerkungRTF.EditMode = (DBUtil.UserHasRight(Name, "U")) ? EditModeType.Normal : EditModeType.ReadOnly;
                            memBemerkungRTF.DataMember = "Bem" + dayNr;
                            memBemerkungRTF.EditValue = qryPraesenz["Bem" + dayNr].ToString();
                        }

                        _askedToChange = false;
                    }
                }
                else
                {
                    memBemerkungRTF.EditValue = null;
                    memBemerkungRTF.EditMode = EditModeType.ReadOnly;
                }

                LoadInfo();
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error in gvPraesenz_FocusedRowChanged(...)", ex.Message);
            }
        }

        private void gvPraesenz_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //Die Bemerkungs-Spalten sind sowieso nicht sichtbar
            if (e.Column == be01 || e.Column == be02 || e.Column == be03 ||
                e.Column == be04 || e.Column == be05 || e.Column == be06 ||
                e.Column == be07 || e.Column == be08 || e.Column == be09 ||
                e.Column == be10 || e.Column == be11 || e.Column == be12 ||
                e.Column == be13 || e.Column == be14 || e.Column == be15 ||
                e.Column == be16 || e.Column == be17 || e.Column == be18 ||
                e.Column == be19 || e.Column == be20 || e.Column == be21 ||
                e.Column == be22 || e.Column == be23 || e.Column == be24 ||
                e.Column == be25 || e.Column == be26 || e.Column == be27 ||
                e.Column == be28 || e.Column == be29 || e.Column == be30 ||
                e.Column == be31)
            {
                return;
            }

            if (e.Column == colKlient || e.Column == colBG || e.Column == colVN)
            {
                if (e.RowHandle < 1)
                {
                    e.Column.OptionsColumn.ReadOnly = true;
                    e.Column.OptionsColumn.AllowEdit = false;
                }
            }
            else if (e.Column == statA || e.Column == statB || e.Column == statC ||
                     e.Column == statE || e.Column == statF || e.Column == statH ||
                     e.Column == statG || e.Column == statX || e.Column == statI ||
                     e.Column == statY || e.Column == statZ)
            {
                if (e.RowHandle < 1)
                {
                    e.Column.OptionsColumn.ReadOnly = true;
                    e.Column.OptionsColumn.AllowEdit = false;
                }
            }
        }

        private void gvPraesenz_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (gvPraesenz.GetRowCellValue(gvPraesenz.FocusedRowHandle, gvPraesenz.FocusedColumn) == DBNull.Value)
            {
                //make sure the cell is not editable
                e.Cancel = true;
            }
        }

        private void memBemerkungRTF_Leave(object sender, EventArgs e)
        {
            SaveBemerkung();
        }

        private void qryPraesenz_BeforePost(object sender, EventArgs e)
        {
            if (!DBUtil.UserHasRight(Name, "U"))
            {
                return;
            }

            UpdateColPraesenz("Code01");
            UpdateColPraesenz("Code02");
            UpdateColPraesenz("Code03");
            UpdateColPraesenz("Code04");
            UpdateColPraesenz("Code05");
            UpdateColPraesenz("Code06");
            UpdateColPraesenz("Code07");
            UpdateColPraesenz("Code08");
            UpdateColPraesenz("Code09");
            UpdateColPraesenz("Code10");
            UpdateColPraesenz("Code11");
            UpdateColPraesenz("Code12");
            UpdateColPraesenz("Code13");
            UpdateColPraesenz("Code14");
            UpdateColPraesenz("Code15");
            UpdateColPraesenz("Code16");
            UpdateColPraesenz("Code17");
            UpdateColPraesenz("Code18");
            UpdateColPraesenz("Code19");
            UpdateColPraesenz("Code20");
            UpdateColPraesenz("Code21");
            UpdateColPraesenz("Code22");
            UpdateColPraesenz("Code23");
            UpdateColPraesenz("Code24");
            UpdateColPraesenz("Code25");
            UpdateColPraesenz("Code26");
            UpdateColPraesenz("Code27");
            UpdateColPraesenz("Code28");

            if (_anzTage > 28)
            {
                UpdateColPraesenz("Code29");
            }

            if (_anzTage > 29)
            {
                UpdateColPraesenz("Code30");
            }

            if (_anzTage > 30)
            {
                UpdateColPraesenz("Code31");
            }

            qryPraesenz.Row.AcceptChanges();
            qryPraesenz.RowModified = false;
        }

        private void qryPraesenz_PositionChanged(object sender, EventArgs e)
        {
            ctlGotoFall.BaPersonID = qryPraesenz["BaPersonID"];
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            RefreshView();
        }

        public override bool OnSaveData()
        {
            SaveBemerkung();

            return base.OnSaveData();
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Containing all necessary parameters as key/value pairs</param>
        /// <returns>True, if successfully handles message or nothing done, false if something went wrong</returns>
        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "JumpToPath":
                    if (!param.Contains("BaPersonID"))
                    {
                        return false;
                    }

                    SetKlientX(Convert.ToInt32(param["BaPersonID"]));
                    return true;
            }

            // did not understand message
            return base.ReceiveMessage(param);
        }

        public void SetKlientX(int aKlientID)
        {
            try
            {
                if (aKlientID > 0)
                {
                    dlgKlientX.EditValue = DBUtil.ExecuteScalarSQL(@"
                        SELECT Name = PRS.NameVorname
                        FROM dbo.vwPerson PRS WITH (READUNCOMMITTED)
                        WHERE PRS.BaPersonID = {0};", aKlientID);

                    dlgKlientX.LookupID = aKlientID;
                }

                FillData();
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, string.Format("Error in SetKlientX({0})", aKlientID), ex.Message);
            }
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            FillData();
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private DayOfWeek DayOfWeek(int aDay)
        {
            var rslt = System.DayOfWeek.Monday;

            if (_anzTage < aDay)
            {
                return System.DayOfWeek.Monday;
            }

            try
            {
                var actDate = new DateTime(_selYear, _selMonth, aDay);

                switch (actDate.DayOfWeek)
                {
                    case System.DayOfWeek.Saturday:
                        rslt = System.DayOfWeek.Saturday;
                        break;

                    case System.DayOfWeek.Sunday:
                        rslt = System.DayOfWeek.Sunday;
                        break;
                }
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, string.Format("Error in DayOfWeek({0})", aDay), ex.Message);
            }

            return rslt;
        }

        private void FillData()
        {
            ctlGotoFall.ResetFallIcons();

            Cursor.Current = Cursors.WaitCursor;

            _anzTage = DateTime.DaysInMonth(_selYear, _selMonth);

            int userKA = Session.User.IsUserKA ? 0 : 1;

            string sql = @"EXEC dbo.spKaGetPraesenzzeit " + userKA + "," + _selMonth + "," + _selYear;
            _repUserKA = userKA;

            // Programm / Projekt
            if (!DBUtil.IsEmpty(dlgKlientX.EditValue))
            {
                sql += "," + dlgKlientX.LookupID;
                _repKlientID = Convert.ToInt32(dlgKlientX.LookupID);
            }
            else
            {
                sql += ",null";
                _repKlientID = 0;
            }

            // APV-Nr
            if (!DBUtil.IsEmpty(ddlAPVNrX.EditValue))
            {
                sql += "," + ddlAPVNrX.EditValue;
                _repApvNr = Convert.ToInt32(ddlAPVNrX.EditValue);
            }
            else
            {
                sql += ",null";
                _repApvNr = 0;
            }

            // Zusatz
            if (!DBUtil.IsEmpty(ddlZusatzX.EditValue))
            {
                sql += "," + ddlZusatzX.EditValue;
                _repZusatz = Convert.ToInt32(ddlZusatzX.EditValue);
            }
            else
            {
                sql += ",null";
                _repZusatz = 0;
            }

            // Coach
            if (!DBUtil.IsEmpty(dlgCoachX.EditValue))
            {
                sql += "," + dlgCoachX.LookupID;
                _repCoach = Convert.ToInt32(dlgCoachX.LookupID);
            }
            else
            {
                sql += ",null";
                _repCoach = 0;
            }

            // Fachbereich
            if (!DBUtil.IsEmpty(dlgFachbereichX.EditValue))
            {
                sql += "," + dlgFachbereichX.LookupID;
                _repFachbereich = Convert.ToInt32(dlgFachbereichX.LookupID);
            }
            else
            {
                sql += ",null";
                _repFachbereich = 0;
            }

            // Fachleitung
            if (!DBUtil.IsEmpty(dlgFachleitungX.EditValue))
            {
                sql += "," + dlgFachleitungX.LookupID;
                _repFachleitung = Convert.ToInt32(dlgFachleitungX.LookupID);
            }
            else
            {
                sql += ",null";
                _repFachleitung = 0;
            }

            // Kurs
            if (!DBUtil.IsEmpty(dlgKursX.EditValue))
            {
                sql += "," + dlgKursX.LookupID;
                _repKurs = Convert.ToInt32(dlgKursX.LookupID);
            }
            else
            {
                sql += ",null";
                _repKurs = 0;
            }

            qryPraesenz.Fill(sql);
            LoadInfo();

            ////tabControlSearch.SelectedTabIndex = 0;
            lblRowCount.Text = (qryPraesenz.Count / 2).ToString();
            grdPraesenz.Focus();
            Cursor.Current = Cursors.Default;

            col29.VisibleIndex = _anzTage > 28 ? col28.VisibleIndex + 1 : -1;
            col30.VisibleIndex = _anzTage > 29 ? col28.VisibleIndex + 2 : -1;
            col31.VisibleIndex = _anzTage > 30 ? col28.VisibleIndex + 3 : -1;

            if (!DBUtil.IsEmpty(qryPraesenz["BaPersonID"]))
            {
                ctlGotoFall.BaPersonID = qryPraesenz["BaPersonID"];
            }
        }

        private void LoadInfo()
        {
            if (qryPraesenz.IsFilling)
            {
                return;
            }

            try
            {
                var actDateFrom = new DateTime(_selYear, _selMonth, 1);
                var isBaPersonSichtbarSd = KaUtil.GetSichtbarSDFlag(Convert.ToInt32(qryPraesenz["BaPersonID"]));

                qryInfo.Fill(
                    @"
                    SELECT Info     = dbo.fnLOVText('KaAnweisung', AnweisungCode) +
                                      ' von ' + CONVERT(VARCHAR, Day(DatumVon)) + '.' + CONVERT(VARCHAR, Month(DatumVon)) + '.' + CONVERT(VARCHAR, Year(DatumVon)) +
                                      ' bis ' + CONVERT(VARCHAR, Day(DatumBis)) + '.' + CONVERT(VARCHAR, Month(DatumBis)) + '.' + CONVERT(VARCHAR, Year(DatumBis)) +
                                      '; Beschäftigungsgrad ' + CONVERT(VARCHAR, IsNull(BeschGrad, 0)) + '%',
                           Austritt = (SELECT FCN.AustrittDatum
                                       FROM dbo.fnKaGetAustrittDatumCode(KAE.FaLeistungID, KAE.KaEinsatzID) FCN),
                           Zuweiser = CASE
                                        WHEN KAE.ZuweiserID < 0 THEN XUR1.LastName + ISNULL(' ' + XUR1.FirstName, '') + ISNULL(', ' + XOU.ItemName, '')
                                        ELSE OKO.Name + ISNULL(' ' + OKO.Vorname,'') + ISNULL(', ' + ORG1.Name, '')
                                      END,
                          SamstagAktiv = ISNULL(KAE.SamstagAktiv, 0),
                          SonntagAktiv = ISNULL(KAE.SonntagAktiv, 0)
                    FROM dbo.KaEinsatz                   KAE  WITH (READUNCOMMITTED)
                        LEFT JOIN dbo.XUser                XUR1 WITH (READUNCOMMITTED) ON XUR1.UserID = -KAE.ZuweiserID
                        LEFT JOIN dbo.BaInstitutionKontakt OKO  WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID
                        LEFT JOIN dbo.BaInstitution        ORG1 WITH (READUNCOMMITTED) ON ORG1.BaInstitutionID =  OKO.BaInstitutionID
                        LEFT JOIN dbo.XOrgUnit_User        OUU  WITH (READUNCOMMITTED) ON OUU.UserID = -KAE.ZuweiserID
                                                                                      AND (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
                        LEFT JOIN dbo.XOrgUnit             XOU  WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                    WHERE BaPersonID = {0}
                        AND (SichtbarSDFlag = {2} OR SichtbarSDFlag = 1)
                        AND ((KAE.DatumVon >= {1} AND KAE.DatumBis < DATEADD(MONTH, 1, {1}))
                          OR (KAE.DatumVon >= {1} AND KAE.DatumVon < DATEADD(MONTH, 1, {1}))
                          OR (KAE.DatumBis >= {1} AND KAE.DatumBis < DATEADD(MONTH, 1, {1}))
                          OR (KAE.DatumVon <  {1} AND KAE.DatumBis > {1}))
                    ORDER BY DatumVon ASC;",
                    qryPraesenz["BaPersonID"],
                    actDateFrom,
                    isBaPersonSichtbarSd);

                qryFachbereich.Fill(@"
                    SELECT Info = ISNULL('Von ' + CONVERT(VARCHAR, DAY(ZUT.ZuteilungVon)) + '.' + CONVERT(VARCHAR, MONTH(ZUT.ZuteilungVon)) + '.' + CONVERT(VARCHAR, YEAR(ZUT.ZuteilungVon)), ' ') +
                                  ISNULL(' bis ' + CONVERT(VARCHAR, DAY(ZUT.ZuteilungBis)) + '.' + CONVERT(VARCHAR, MONTH(ZUT.ZuteilungBis)) + '.' + CONVERT(VARCHAR, YEAR(ZUT.ZuteilungBis)), ' ') +
                                  '; ' + dbo.fnLOVText('KaFachbereich', ZUT.FachbereichID)
                    FROM dbo.KaZuteilFachbereich ZUT WITH (READUNCOMMITTED)
                    WHERE ZUT.BaPersonID = {0}
                      AND (SichtbarSDFlag = {2} OR SichtbarSDFlag = 1)
                      AND ((ZUT.ZuteilungVon >= {1} AND ZUT.ZuteilungBis < DATEADD(MONTH, 1, {1}))
                        OR (ZUT.ZuteilungVon >= {1} AND ZUT.ZuteilungVon < DATEADD(MONTH, 1, {1}))
                        OR (ZUT.ZuteilungBis >= {1} AND ZUT.ZuteilungBis < DATEADD(MONTH, 1, {1}))
                        OR (ZUT.ZuteilungVon <  {1} AND ((ZUT.ZuteilungBis > {1}) OR ZUT.ZuteilungBis IS NULL )))
                    ORDER BY ZUT.ZuteilungVon ASC;", qryPraesenz["BaPersonID"], actDateFrom, isBaPersonSichtbarSd);
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error in LoadInfo()", ex.Message);
            }
        }

        private void RefreshView()
        {
            if (Convert.ToInt32(edtJahr.EditValue) < 1 || DBUtil.IsEmpty(edtJahr.EditValue))
            {
                return;
            }

            try
            {
                qryPraesenz.Post();
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error in qryPraesenz.Post() at RefreshView()", ex.Message);
            }

            _selMonth = Convert.ToInt32(ddlMonatX.EditValue);
            _selYear = Convert.ToInt32(edtJahr.EditValue);

            _isActMonth = DateTime.Today.Month <= _selMonth && DateTime.Today.Year <= _selYear;

            var qry1 = DBUtil.OpenSQL(@"
                SELECT Code = null, Text = null

                UNION

                SELECT Code = KaEinsatzplatzID, Text = dbo.fnLOVText('KaAPV', APVCode)
                FROM dbo.KaEinsatzplatz2 WITH (READUNCOMMITTED)
                WHERE CONVERT(DateTime, DatumVon, 104) < CONVERT(DateTime, {0} , 104)
                  AND (DatumBis IS NULL OR CONVERT(DateTime, DatumBis, 104) >= DATEADD(DAY, -1, DATEADD(MONTH, 1, CONVERT(DateTime, {0} , 104))))
                ORDER BY Text", "01." + _selMonth + "." + _selYear);

            ddlAPVNrX.Properties.DataSource = qry1;
            ddlAPVNrX.Properties.DropDownRows = 7;

            FillData();

            if (qryPraesenz.Count < 1)
            {
                KissMsg.ShowInfo(Name, "KeinErgebnis", "Suche liefert kein Ergebnis.");
            }
        }

        private void SaveBemerkung()
        {
            if (!DBUtil.UserHasRight(Name, "U") || !memBemerkungRTF.UserModified)
            {
                return;
            }

            memBemerkungRTF.UserModified = false;

            if (!_isActMonth)
            {
                if (!KissMsg.ShowQuestion(Name, "WertNichtInAktMonat_v01", "Geänderter Wert ist nicht im aktuellen Monat!\r\nWert trotzdem ändern?"))
                {
                    return;
                }
            }

            try
            {
                qryPraesenz.Row[memBemerkungRTF.DataMember] = memBemerkungRTF.Text;

                int actDay = Convert.ToInt32(memBemerkungRTF.DataMember.Remove(0, 3));

                DBUtil.ExecSQL(@"
                    IF ({0} = 'V')
                    BEGIN
                        UPDATE dbo.KaArbeitsrapport
                        SET AM_Bemerkung = {1}
                        WHERE BaPersonID = {2}
                        AND DAY(Datum) = {5}
                        AND MONTH(Datum) = {3}
                        AND YEAR(Datum) = {4}
                    END
                    ELSE
                    BEGIN
                        UPDATE dbo.KaArbeitsrapport
                        SET PM_Bemerkung = {1}
                        WHERE BaPersonID = {2}
                        AND DAY(Datum) = {5}
                        AND MONTH(Datum) = {3}
                        AND YEAR(Datum) = {4}
                    END;", qryPraesenz.Row["VN"],
                           qryPraesenz.Row[memBemerkungRTF.DataMember],
                           qryPraesenz.Row["BaPersonID"],
                           _selMonth.ToString(),
                           _selYear.ToString(),
                           actDay);
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error in SaveBemerkung()", ex.Message);
            }
        }

        private void SetEditMode()
        {
            qryPraesenz.CanUpdate = DBUtil.UserHasRight(Name, "U");
            memBemerkungRTF.EditMode = (DBUtil.UserHasRight(Name, "U")) && !string.IsNullOrEmpty(memBemerkungRTF.DataMember) ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void UpdateColPraesenz(string colName)
        {
            var actDay = 0;
            var cnt = 0;

            if (!qryPraesenz.ColumnModified(colName))
            {
                return;
            }

            try
            {
                actDay = Convert.ToInt32(colName.Remove(0, 4));

                cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(1)
                        FROM dbo.KaArbeitsrapport WITH (READUNCOMMITTED)
                        WHERE BaPersonID = {0}
                          AND DAY(Datum) = {1}
                          AND MONTH(Datum) = {2}
                          AND YEAR(Datum) = {3}", qryPraesenz.Row["BaPersonID"], actDay, _selMonth.ToString(), _selYear.ToString()));
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, string.Format("Error in UpdateColPraesenz({0})", colName), ex.Message);
            }

            if (cnt > 0)
            {
                DBUtil.ExecSQL(@"
                    IF ({0} = 'V')
                    BEGIN
                        UPDATE dbo.KaArbeitsrapport
                        SET AM_AnwCode = ISNULL({1}, -1)
                        WHERE BaPersonID = {2}
                        AND DAY(Datum) = {5}
                        AND MONTH(Datum) = {3}
                        AND YEAR(Datum) = {4}
                    END
                    ELSE
                    BEGIN
                        UPDATE dbo.KaArbeitsrapport
                        SET PM_AnwCode = ISNULL({1}, -1)
                        WHERE BaPersonID = {2}
                        AND DAY(Datum) = {5}
                        AND MONTH(Datum) = {3}
                        AND YEAR(Datum) = {4}
                    END;",
                    qryPraesenz.Row["VN"],
                    qryPraesenz.Row[colName],
                    qryPraesenz.Row["BaPersonID"],
                    _selMonth.ToString(),
                    _selYear.ToString(),
                    actDay);
            }
        }

        #endregion

        #endregion
    }
}