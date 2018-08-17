using System;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryFaFalltraeger‹bersicht : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbgeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAltertyp;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthaltstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBranche;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colerlernterBeruf;
        private DevExpress.XtraGrid.Columns.GridColumn colErwerbssituation;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colKonfession;
        private DevExpress.XtraGrid.Columns.GridColumn colLetzteTtigkeit;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasseNr;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colWohnungsgrsse;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private KiSS4.Gui.KissLookUpEdit edtAlterCode;
        private KiSS4.Gui.KissLookUpEdit edtAufenthaltstatusCode;
        private KiSS4.Gui.KissLookUpEdit edtBerufCode;
        private KiSS4.Gui.KissLookUpEdit edtBrancheCode;
        private KiSS4.Gui.KissDateEdit edtFallAbschlussBis;
        private KiSS4.Gui.KissDateEdit edtFallAbschlussVon;
        private KiSS4.Gui.KissDateEdit edtFallAktivBis;
        private KiSS4.Gui.KissDateEdit edtFallAktivVon;
        private KiSS4.Gui.KissDateEdit edtFallAufnahmeBis;
        private KiSS4.Gui.KissDateEdit edtFallAufnahmeVon;
        private KiSS4.Gui.KissLookUpEdit edtGeschlechtCode;
        private KiSS4.Gui.KissTextEdit edtGetLogonName;
        private KiSS4.Gui.KissLookUpEdit edtKonfessionCode;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaetCode;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissLookUpEdit edtWohnstatus;
        private KiSS4.Gui.KissLookUpEdit edtWohnungsgroesse;
        private KiSS4.Gui.KissLookUpEdit edtZivilstandCode;
        private KiSS4.Gui.KissLabel lbl;
        private KiSS4.Gui.KissLabel lbl1;
        private KiSS4.Gui.KissLabel lbl10;
        private KiSS4.Gui.KissLabel lbl11;
        private KiSS4.Gui.KissLabel lbl12;
        private KiSS4.Gui.KissLabel lbl13;
        private KiSS4.Gui.KissLabel lbl14;
        private KiSS4.Gui.KissLabel lbl15;
        private KiSS4.Gui.KissLabel lbl16;
        private KiSS4.Gui.KissLabel lbl17;
        private KiSS4.Gui.KissLabel lbl2;
        private KiSS4.Gui.KissLabel lbl3;
        private KiSS4.Gui.KissLabel lbl4;
        private KiSS4.Gui.KissLabel lbl5;
        private KiSS4.Gui.KissLabel lbl6;
        private KiSS4.Gui.KissLabel lbl7;
        private KiSS4.Gui.KissLabel lbl8;
        private KiSS4.Gui.KissLabel lbl9;

        private System.Data.DataRow NewRow;
        private SqlQuery qry;

        #endregion

        #region Constructors

        public CtlQueryFaFalltraeger‹bersicht()
        {
            this.InitializeComponent();

            qry = DBUtil.OpenSQL(@"
                DECLARE @LanguageCode INT;
                SET @LanguageCode = {0};
                select [Code] = 1, [Text] = '0-17'
                union
                select [Code] = 2, [Text] = '18-25'
                union
                select [Code] = 3, [Text] = '26-35'
                union
                select [Code] = 4, [Text] = '36-50'
                union
                select [Code] = 5, [Text] = '51-65'
                union
                select [Code] = 6, [Text] = dbo.fnGetMLTextFromName('CtlQueryFaFalltraeger‹bersicht', 'Ab66', @LanguageCode)",
                Session.User.LanguageCode);
            NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtAlterCode.Properties.Columns.Clear();
            edtAlterCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtAlterCode.Properties.ShowFooter = false;
            edtAlterCode.Properties.ShowHeader = false;
            edtAlterCode.Properties.DisplayMember = "Text";
            edtAlterCode.Properties.ValueMember = "Code";
            edtAlterCode.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtAlterCode.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL(@"select Code = OrgUnitID, Text = ItemName from XOrgUnit
            order by ItemName");
            NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtOrgUnitID.Properties.DataSource = qry;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaFalltraeger‹bersicht));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject19 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject18 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject17 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lbl = new KiSS4.Gui.KissLabel();
            this.lbl1 = new KiSS4.Gui.KissLabel();
            this.lbl10 = new KiSS4.Gui.KissLabel();
            this.lbl11 = new KiSS4.Gui.KissLabel();
            this.lbl12 = new KiSS4.Gui.KissLabel();
            this.lbl13 = new KiSS4.Gui.KissLabel();
            this.lbl14 = new KiSS4.Gui.KissLabel();
            this.lbl15 = new KiSS4.Gui.KissLabel();
            this.lbl16 = new KiSS4.Gui.KissLabel();
            this.lbl17 = new KiSS4.Gui.KissLabel();
            this.lbl2 = new KiSS4.Gui.KissLabel();
            this.lbl3 = new KiSS4.Gui.KissLabel();
            this.lbl4 = new KiSS4.Gui.KissLabel();
            this.lbl5 = new KiSS4.Gui.KissLabel();
            this.lbl6 = new KiSS4.Gui.KissLabel();
            this.lbl7 = new KiSS4.Gui.KissLabel();
            this.lbl8 = new KiSS4.Gui.KissLabel();
            this.lbl9 = new KiSS4.Gui.KissLabel();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtFallAufnahmeVon = new KiSS4.Gui.KissDateEdit();
            this.edtFallAufnahmeBis = new KiSS4.Gui.KissDateEdit();
            this.edtFallAbschlussVon = new KiSS4.Gui.KissDateEdit();
            this.edtFallAbschlussBis = new KiSS4.Gui.KissDateEdit();
            this.edtFallAktivVon = new KiSS4.Gui.KissDateEdit();
            this.edtFallAktivBis = new KiSS4.Gui.KissDateEdit();
            this.edtAlterCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtGeschlechtCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtZivilstandCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtNationalitaetCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAufenthaltstatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtKonfessionCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBerufCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtBrancheCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtWohnstatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtWohnungsgroesse = new KiSS4.Gui.KissLookUpEdit();
            this.edtGetLogonName = new KiSS4.Gui.KissTextEdit();
            this.colAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltertyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufenthaltstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBranche = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colerlernterBeruf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErwerbssituation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonfession = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetzteTtigkeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasseNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWohnungsgrsse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAufnahmeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAufnahmeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAbschlussVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAbschlussBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAktivVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAktivBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlterCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlterCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltstatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltstatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonfessionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonfessionCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBrancheCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBrancheCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGetLogonName.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grvQuery1
            //
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument ˆffnen")});
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtGetLogonName);
            this.tpgSuchen.Controls.Add(this.edtWohnungsgroesse);
            this.tpgSuchen.Controls.Add(this.edtWohnstatus);
            this.tpgSuchen.Controls.Add(this.edtBrancheCode);
            this.tpgSuchen.Controls.Add(this.edtBerufCode);
            this.tpgSuchen.Controls.Add(this.edtKonfessionCode);
            this.tpgSuchen.Controls.Add(this.edtAufenthaltstatusCode);
            this.tpgSuchen.Controls.Add(this.edtNationalitaetCode);
            this.tpgSuchen.Controls.Add(this.edtZivilstandCode);
            this.tpgSuchen.Controls.Add(this.edtGeschlechtCode);
            this.tpgSuchen.Controls.Add(this.edtAlterCode);
            this.tpgSuchen.Controls.Add(this.edtFallAktivBis);
            this.tpgSuchen.Controls.Add(this.edtFallAktivVon);
            this.tpgSuchen.Controls.Add(this.edtFallAbschlussBis);
            this.tpgSuchen.Controls.Add(this.edtFallAbschlussVon);
            this.tpgSuchen.Controls.Add(this.edtFallAufnahmeBis);
            this.tpgSuchen.Controls.Add(this.edtFallAufnahmeVon);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Controls.Add(this.lbl9);
            this.tpgSuchen.Controls.Add(this.lbl8);
            this.tpgSuchen.Controls.Add(this.lbl7);
            this.tpgSuchen.Controls.Add(this.lbl6);
            this.tpgSuchen.Controls.Add(this.lbl5);
            this.tpgSuchen.Controls.Add(this.lbl4);
            this.tpgSuchen.Controls.Add(this.lbl3);
            this.tpgSuchen.Controls.Add(this.lbl2);
            this.tpgSuchen.Controls.Add(this.lbl17);
            this.tpgSuchen.Controls.Add(this.lbl16);
            this.tpgSuchen.Controls.Add(this.lbl15);
            this.tpgSuchen.Controls.Add(this.lbl14);
            this.tpgSuchen.Controls.Add(this.lbl13);
            this.tpgSuchen.Controls.Add(this.lbl12);
            this.tpgSuchen.Controls.Add(this.lbl11);
            this.tpgSuchen.Controls.Add(this.lbl10);
            this.tpgSuchen.Controls.Add(this.lbl1);
            this.tpgSuchen.Controls.Add(this.lbl);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl11, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl12, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl13, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl14, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl15, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl16, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl17, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl6, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl7, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl8, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbl9, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallAufnahmeVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallAufnahmeBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallAbschlussVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallAbschlussBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallAktivVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallAktivBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAlterCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeschlechtCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZivilstandCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNationalitaetCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAufenthaltstatusCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKonfessionCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBerufCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBrancheCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWohnstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWohnungsgroesse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGetLogonName, 0);
            //
            // lbl
            //
            this.lbl.Location = new System.Drawing.Point(10, 40);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(134, 24);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Sektion";
            this.lbl.UseCompatibleTextRendering = true;
            //
            // lbl1
            //
            this.lbl1.Location = new System.Drawing.Point(10, 70);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(134, 24);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "SAR";
            this.lbl1.UseCompatibleTextRendering = true;
            //
            // lbl10
            //
            this.lbl10.Location = new System.Drawing.Point(10, 250);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(134, 24);
            this.lbl10.TabIndex = 1;
            this.lbl10.Text = "Zivilstand";
            this.lbl10.UseCompatibleTextRendering = true;
            //
            // lbl11
            //
            this.lbl11.Location = new System.Drawing.Point(10, 280);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(134, 24);
            this.lbl11.TabIndex = 1;
            this.lbl11.Text = "Nationalit‰t";
            this.lbl11.UseCompatibleTextRendering = true;
            //
            // lbl12
            //
            this.lbl12.Location = new System.Drawing.Point(10, 310);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(134, 24);
            this.lbl12.TabIndex = 1;
            this.lbl12.Text = "Aufenthaltstatus";
            this.lbl12.UseCompatibleTextRendering = true;
            //
            // lbl13
            //
            this.lbl13.Location = new System.Drawing.Point(10, 340);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(134, 24);
            this.lbl13.TabIndex = 1;
            this.lbl13.Text = "Konfession";
            this.lbl13.UseCompatibleTextRendering = true;
            //
            // lbl14
            //
            this.lbl14.Location = new System.Drawing.Point(10, 370);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(134, 24);
            this.lbl14.TabIndex = 1;
            this.lbl14.Text = "Erlernter Beruf";
            this.lbl14.UseCompatibleTextRendering = true;
            //
            // lbl15
            //
            this.lbl15.Location = new System.Drawing.Point(10, 400);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(134, 24);
            this.lbl15.TabIndex = 1;
            this.lbl15.Text = "Branche";
            this.lbl15.UseCompatibleTextRendering = true;
            //
            // lbl16
            //
            this.lbl16.Location = new System.Drawing.Point(10, 430);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(134, 24);
            this.lbl16.TabIndex = 1;
            this.lbl16.Text = "Wohnstatus";
            this.lbl16.UseCompatibleTextRendering = true;
            //
            // lbl17
            //
            this.lbl17.Location = new System.Drawing.Point(10, 460);
            this.lbl17.Name = "lbl17";
            this.lbl17.Size = new System.Drawing.Size(134, 24);
            this.lbl17.TabIndex = 1;
            this.lbl17.Text = "Wohnungsgrˆsse";
            this.lbl17.UseCompatibleTextRendering = true;
            //
            // lbl2
            //
            this.lbl2.Location = new System.Drawing.Point(10, 100);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(134, 24);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "Fallaufnahme von";
            this.lbl2.UseCompatibleTextRendering = true;
            //
            // lbl3
            //
            this.lbl3.Location = new System.Drawing.Point(270, 100);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(24, 24);
            this.lbl3.TabIndex = 1;
            this.lbl3.Text = "bis";
            this.lbl3.UseCompatibleTextRendering = true;
            //
            // lbl4
            //
            this.lbl4.Location = new System.Drawing.Point(10, 130);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(134, 24);
            this.lbl4.TabIndex = 1;
            this.lbl4.Text = "Fallabschluss von";
            this.lbl4.UseCompatibleTextRendering = true;
            //
            // lbl5
            //
            this.lbl5.Location = new System.Drawing.Point(270, 130);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(24, 24);
            this.lbl5.TabIndex = 1;
            this.lbl5.Text = "bis";
            this.lbl5.UseCompatibleTextRendering = true;
            //
            // lbl6
            //
            this.lbl6.Location = new System.Drawing.Point(10, 160);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(134, 24);
            this.lbl6.TabIndex = 1;
            this.lbl6.Text = "Fall aktiv von";
            this.lbl6.UseCompatibleTextRendering = true;
            //
            // lbl7
            //
            this.lbl7.Location = new System.Drawing.Point(270, 160);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(24, 24);
            this.lbl7.TabIndex = 1;
            this.lbl7.Text = "bis";
            this.lbl7.UseCompatibleTextRendering = true;
            //
            // lbl8
            //
            this.lbl8.Location = new System.Drawing.Point(10, 190);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(134, 24);
            this.lbl8.TabIndex = 1;
            this.lbl8.Text = "Alter";
            this.lbl8.UseCompatibleTextRendering = true;
            //
            // lbl9
            //
            this.lbl9.Location = new System.Drawing.Point(10, 220);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(134, 24);
            this.lbl9.TabIndex = 1;
            this.lbl9.Text = "Geschlecht";
            this.lbl9.UseCompatibleTextRendering = true;
            //
            // edtOrgUnitID
            //
            this.edtOrgUnitID.Location = new System.Drawing.Point(150, 40);
            this.edtOrgUnitID.Name = "edtOrgUnitID";
            this.edtOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject19.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject19.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject19)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(250, 24);
            this.edtOrgUnitID.TabIndex = 20;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 70);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject18.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject18.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject18)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(250, 24);
            this.edtUserID.TabIndex = 21;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // edtFallAufnahmeVon
            //
            this.edtFallAufnahmeVon.EditValue = null;
            this.edtFallAufnahmeVon.Location = new System.Drawing.Point(150, 100);
            this.edtFallAufnahmeVon.Name = "edtFallAufnahmeVon";
            this.edtFallAufnahmeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallAufnahmeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallAufnahmeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallAufnahmeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallAufnahmeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallAufnahmeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallAufnahmeVon.Properties.Appearance.Options.UseFont = true;
            this.edtFallAufnahmeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject17.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject17.Options.UseBackColor = true;
            this.edtFallAufnahmeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFallAufnahmeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject17)});
            this.edtFallAufnahmeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallAufnahmeVon.Properties.ShowToday = false;
            this.edtFallAufnahmeVon.Size = new System.Drawing.Size(100, 24);
            this.edtFallAufnahmeVon.TabIndex = 22;
            //
            // edtFallAufnahmeBis
            //
            this.edtFallAufnahmeBis.EditValue = null;
            this.edtFallAufnahmeBis.Location = new System.Drawing.Point(300, 100);
            this.edtFallAufnahmeBis.Name = "edtFallAufnahmeBis";
            this.edtFallAufnahmeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallAufnahmeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallAufnahmeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallAufnahmeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallAufnahmeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallAufnahmeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallAufnahmeBis.Properties.Appearance.Options.UseFont = true;
            this.edtFallAufnahmeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject16.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject16.Options.UseBackColor = true;
            this.edtFallAufnahmeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFallAufnahmeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject16)});
            this.edtFallAufnahmeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallAufnahmeBis.Properties.ShowToday = false;
            this.edtFallAufnahmeBis.Size = new System.Drawing.Size(100, 24);
            this.edtFallAufnahmeBis.TabIndex = 23;
            //
            // edtFallAbschlussVon
            //
            this.edtFallAbschlussVon.EditValue = null;
            this.edtFallAbschlussVon.Location = new System.Drawing.Point(150, 130);
            this.edtFallAbschlussVon.Name = "edtFallAbschlussVon";
            this.edtFallAbschlussVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallAbschlussVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallAbschlussVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallAbschlussVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallAbschlussVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallAbschlussVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallAbschlussVon.Properties.Appearance.Options.UseFont = true;
            this.edtFallAbschlussVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtFallAbschlussVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFallAbschlussVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtFallAbschlussVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallAbschlussVon.Properties.ShowToday = false;
            this.edtFallAbschlussVon.Size = new System.Drawing.Size(100, 24);
            this.edtFallAbschlussVon.TabIndex = 24;
            //
            // edtFallAbschlussBis
            //
            this.edtFallAbschlussBis.EditValue = null;
            this.edtFallAbschlussBis.Location = new System.Drawing.Point(300, 130);
            this.edtFallAbschlussBis.Name = "edtFallAbschlussBis";
            this.edtFallAbschlussBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallAbschlussBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallAbschlussBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallAbschlussBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallAbschlussBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallAbschlussBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallAbschlussBis.Properties.Appearance.Options.UseFont = true;
            this.edtFallAbschlussBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtFallAbschlussBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFallAbschlussBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtFallAbschlussBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallAbschlussBis.Properties.ShowToday = false;
            this.edtFallAbschlussBis.Size = new System.Drawing.Size(100, 24);
            this.edtFallAbschlussBis.TabIndex = 25;
            //
            // edtFallAktivVon
            //
            this.edtFallAktivVon.EditValue = null;
            this.edtFallAktivVon.Location = new System.Drawing.Point(150, 160);
            this.edtFallAktivVon.Name = "edtFallAktivVon";
            this.edtFallAktivVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallAktivVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallAktivVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallAktivVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallAktivVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallAktivVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallAktivVon.Properties.Appearance.Options.UseFont = true;
            this.edtFallAktivVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtFallAktivVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFallAktivVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtFallAktivVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallAktivVon.Properties.ShowToday = false;
            this.edtFallAktivVon.Size = new System.Drawing.Size(100, 24);
            this.edtFallAktivVon.TabIndex = 26;
            //
            // edtFallAktivBis
            //
            this.edtFallAktivBis.EditValue = null;
            this.edtFallAktivBis.Location = new System.Drawing.Point(300, 160);
            this.edtFallAktivBis.Name = "edtFallAktivBis";
            this.edtFallAktivBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFallAktivBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallAktivBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallAktivBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallAktivBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallAktivBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallAktivBis.Properties.Appearance.Options.UseFont = true;
            this.edtFallAktivBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtFallAktivBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFallAktivBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtFallAktivBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallAktivBis.Properties.ShowToday = false;
            this.edtFallAktivBis.Size = new System.Drawing.Size(100, 24);
            this.edtFallAktivBis.TabIndex = 27;
            //
            // edtAlterCode
            //
            this.edtAlterCode.Location = new System.Drawing.Point(150, 190);
            this.edtAlterCode.Name = "edtAlterCode";
            this.edtAlterCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAlterCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAlterCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAlterCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAlterCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAlterCode.Properties.Appearance.Options.UseFont = true;
            this.edtAlterCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAlterCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAlterCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAlterCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAlterCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtAlterCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtAlterCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAlterCode.Properties.NullText = "";
            this.edtAlterCode.Properties.ShowFooter = false;
            this.edtAlterCode.Properties.ShowHeader = false;
            this.edtAlterCode.Size = new System.Drawing.Size(250, 24);
            this.edtAlterCode.TabIndex = 28;
            //
            // edtGeschlechtCode
            //
            this.edtGeschlechtCode.Location = new System.Drawing.Point(150, 220);
            this.edtGeschlechtCode.LOVName = "Geschlecht";
            this.edtGeschlechtCode.Name = "edtGeschlechtCode";
            this.edtGeschlechtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeschlechtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtCode.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeschlechtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeschlechtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeschlechtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtGeschlechtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtGeschlechtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeschlechtCode.Properties.NullText = "";
            this.edtGeschlechtCode.Properties.ShowFooter = false;
            this.edtGeschlechtCode.Properties.ShowHeader = false;
            this.edtGeschlechtCode.Size = new System.Drawing.Size(250, 24);
            this.edtGeschlechtCode.TabIndex = 29;
            //
            // edtZivilstandCode
            //
            this.edtZivilstandCode.Location = new System.Drawing.Point(150, 250);
            this.edtZivilstandCode.LOVName = "Zivilstand";
            this.edtZivilstandCode.Name = "edtZivilstandCode";
            this.edtZivilstandCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZivilstandCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandCode.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZivilstandCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtZivilstandCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtZivilstandCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZivilstandCode.Properties.NullText = "";
            this.edtZivilstandCode.Properties.ShowFooter = false;
            this.edtZivilstandCode.Properties.ShowHeader = false;
            this.edtZivilstandCode.Size = new System.Drawing.Size(250, 24);
            this.edtZivilstandCode.TabIndex = 30;
            //
            // edtNationalitaetCode
            //
            this.edtNationalitaetCode.Location = new System.Drawing.Point(150, 280);
            this.edtNationalitaetCode.LOVName = "BaLand";
            this.edtNationalitaetCode.Name = "edtNationalitaetCode";
            this.edtNationalitaetCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNationalitaetCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaetCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaetCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaetCode.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaetCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNationalitaetCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaetCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaetCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaetCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtNationalitaetCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtNationalitaetCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaetCode.Properties.NullText = "";
            this.edtNationalitaetCode.Properties.ShowFooter = false;
            this.edtNationalitaetCode.Properties.ShowHeader = false;
            this.edtNationalitaetCode.Size = new System.Drawing.Size(250, 24);
            this.edtNationalitaetCode.TabIndex = 31;
            //
            // edtAufenthaltstatusCode
            //
            this.edtAufenthaltstatusCode.Location = new System.Drawing.Point(150, 310);
            this.edtAufenthaltstatusCode.LOVName = "Aufenthaltsstatus";
            this.edtAufenthaltstatusCode.Name = "edtAufenthaltstatusCode";
            this.edtAufenthaltstatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAufenthaltstatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAufenthaltstatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltstatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAufenthaltstatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAufenthaltstatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtAufenthaltstatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAufenthaltstatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAufenthaltstatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAufenthaltstatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAufenthaltstatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAufenthaltstatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAufenthaltstatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAufenthaltstatusCode.Properties.NullText = "";
            this.edtAufenthaltstatusCode.Properties.ShowFooter = false;
            this.edtAufenthaltstatusCode.Properties.ShowHeader = false;
            this.edtAufenthaltstatusCode.Size = new System.Drawing.Size(250, 24);
            this.edtAufenthaltstatusCode.TabIndex = 32;
            //
            // edtKonfessionCode
            //
            this.edtKonfessionCode.Location = new System.Drawing.Point(150, 340);
            this.edtKonfessionCode.LOVName = "Konfession\r\n";
            this.edtKonfessionCode.Name = "edtKonfessionCode";
            this.edtKonfessionCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKonfessionCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKonfessionCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonfessionCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtKonfessionCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKonfessionCode.Properties.Appearance.Options.UseFont = true;
            this.edtKonfessionCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKonfessionCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonfessionCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKonfessionCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKonfessionCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtKonfessionCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtKonfessionCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKonfessionCode.Properties.NullText = "";
            this.edtKonfessionCode.Properties.ShowFooter = false;
            this.edtKonfessionCode.Properties.ShowHeader = false;
            this.edtKonfessionCode.Size = new System.Drawing.Size(250, 24);
            this.edtKonfessionCode.TabIndex = 33;
            //
            // edtBerufCode
            //
            this.edtBerufCode.Location = new System.Drawing.Point(150, 370);
            this.edtBerufCode.LOVName = "Beruf";
            this.edtBerufCode.Name = "edtBerufCode";
            this.edtBerufCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBerufCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerufCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerufCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerufCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerufCode.Properties.Appearance.Options.UseFont = true;
            this.edtBerufCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBerufCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerufCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBerufCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBerufCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBerufCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBerufCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBerufCode.Properties.NullText = "";
            this.edtBerufCode.Properties.ShowFooter = false;
            this.edtBerufCode.Properties.ShowHeader = false;
            this.edtBerufCode.Size = new System.Drawing.Size(250, 24);
            this.edtBerufCode.TabIndex = 34;
            //
            // edtBrancheCode
            //
            this.edtBrancheCode.Location = new System.Drawing.Point(150, 400);
            this.edtBrancheCode.LOVName = "Branche";
            this.edtBrancheCode.Name = "edtBrancheCode";
            this.edtBrancheCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBrancheCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBrancheCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBrancheCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBrancheCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBrancheCode.Properties.Appearance.Options.UseFont = true;
            this.edtBrancheCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBrancheCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBrancheCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBrancheCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBrancheCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBrancheCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBrancheCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBrancheCode.Properties.NullText = "";
            this.edtBrancheCode.Properties.ShowFooter = false;
            this.edtBrancheCode.Properties.ShowHeader = false;
            this.edtBrancheCode.Size = new System.Drawing.Size(250, 24);
            this.edtBrancheCode.TabIndex = 35;
            //
            // edtWohnstatus
            //
            this.edtWohnstatus.Location = new System.Drawing.Point(150, 430);
            this.edtWohnstatus.LOVName = "Wohnstatus";
            this.edtWohnstatus.Name = "edtWohnstatus";
            this.edtWohnstatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnstatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnstatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnstatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnstatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnstatus.Properties.Appearance.Options.UseFont = true;
            this.edtWohnstatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnstatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnstatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnstatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnstatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtWohnstatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtWohnstatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnstatus.Properties.NullText = "";
            this.edtWohnstatus.Properties.ShowFooter = false;
            this.edtWohnstatus.Properties.ShowHeader = false;
            this.edtWohnstatus.Size = new System.Drawing.Size(250, 24);
            this.edtWohnstatus.TabIndex = 36;
            //
            // edtWohnungsgroesse
            //
            this.edtWohnungsgroesse.Location = new System.Drawing.Point(150, 460);
            this.edtWohnungsgroesse.LOVName = "Wohnungsgroesse";
            this.edtWohnungsgroesse.Name = "edtWohnungsgroesse";
            this.edtWohnungsgroesse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWohnungsgroesse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWohnungsgroesse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnungsgroesse.Properties.Appearance.Options.UseBackColor = true;
            this.edtWohnungsgroesse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWohnungsgroesse.Properties.Appearance.Options.UseFont = true;
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWohnungsgroesse.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWohnungsgroesse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtWohnungsgroesse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtWohnungsgroesse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWohnungsgroesse.Properties.NullText = "";
            this.edtWohnungsgroesse.Properties.ShowFooter = false;
            this.edtWohnungsgroesse.Properties.ShowHeader = false;
            this.edtWohnungsgroesse.Size = new System.Drawing.Size(250, 24);
            this.edtWohnungsgroesse.TabIndex = 37;
            //
            // edtGetLogonName
            //
            this.edtGetLogonName.Location = new System.Drawing.Point(150, 32767);
            this.edtGetLogonName.Name = "edtGetLogonName";
            this.edtGetLogonName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGetLogonName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGetLogonName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGetLogonName.Properties.Appearance.Options.UseBackColor = true;
            this.edtGetLogonName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGetLogonName.Properties.Appearance.Options.UseFont = true;
            this.edtGetLogonName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGetLogonName.Size = new System.Drawing.Size(0, 24);
            this.edtGetLogonName.TabIndex = 200;
            //
            // colAbgeschlossen
            //
            this.colAbgeschlossen.Name = "colAbgeschlossen";
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
            //
            // colAltertyp
            //
            this.colAltertyp.Name = "colAltertyp";
            //
            // colAufenthaltstatus
            //
            this.colAufenthaltstatus.Name = "colAufenthaltstatus";
            //
            // colBranche
            //
            this.colBranche.Name = "colBranche";
            //
            // colErffnet
            //
            this.colErffnet.Name = "colErffnet";
            //
            // colerlernterBeruf
            //
            this.colerlernterBeruf.Name = "colerlernterBeruf";
            //
            // colErwerbssituation
            //
            this.colErwerbssituation.Name = "colErwerbssituation";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colGeschlecht
            //
            this.colGeschlecht.Name = "colGeschlecht";
            //
            // colKonfession
            //
            this.colKonfession.Name = "colKonfession";
            //
            // colLetzteTtigkeit
            //
            this.colLetzteTtigkeit.Name = "colLetzteTtigkeit";
            //
            // colNationalitt
            //
            this.colNationalitt.Name = "colNationalitt";
            //
            // colOrt
            //
            this.colOrt.Name = "colOrt";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colPLZ
            //
            this.colPLZ.Name = "colPLZ";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colStrasse
            //
            this.colStrasse.Name = "colStrasse";
            //
            // colStrasseNr
            //
            this.colStrasseNr.Name = "colStrasseNr";
            //
            // colWohnstatus
            //
            this.colWohnstatus.Name = "colWohnstatus";
            //
            // colWohnungsgrsse
            //
            this.colWohnungsgrsse.Name = "colWohnungsgrsse";
            //
            // colZivilstand
            //
            this.colZivilstand.Name = "colZivilstand";
            //
            // CtlQueryFaFalltraeger‹bersicht
            //
            this.Name = "CtlQueryFaFalltraeger‹bersicht";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAufnahmeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAufnahmeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAbschlussVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAbschlussBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAktivVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallAktivBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlterCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlterCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaetCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltstatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltstatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonfessionCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonfessionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBrancheCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBrancheCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnungsgroesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGetLogonName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { Session.User.LogonName, Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;
            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}