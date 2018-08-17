using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    partial class CtlFibuKontoblatt
    {
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuKontoblatt));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryKontoblaetter = new KiSS4.DB.SqlQuery(this.components);
            this.TabControlEx1 = new KiSS4.Gui.KissTabControlEx();
            this.tabListe = new SharpLibrary.WinControls.TabPageEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdKontoblaetter = new KiSS4.Gui.KissGrid();
            this.grvKontoblaetter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKtoName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.tabSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.lblDatumBereichPeriodenX = new KiSS4.Gui.KissLabel();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.lblOrtX = new KiSS4.Gui.KissLabel();
            this.lblMTraegerX = new KiSS4.Gui.KissLabel();
            this.edtMTX = new KiSS4.Gui.KissTextEdit();
            this.edtMandantX = new KiSS4.Gui.KissButtonEdit();
            this.editMandantNrX = new KiSS4.Gui.KissTextEdit();
            this.edtPlzOrtX = new KiSS4.Gui.KissTextEdit();
            this.lblMandantX = new KiSS4.Gui.KissLabel();
            this.grdPeriodenX = new KiSS4.Gui.KissGrid();
            this.qryPeriodeX = new KiSS4.DB.SqlQuery(this.components);
            this.grvPeriodeX = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtKontoVonX = new KiSS4.Gui.KissButtonEdit();
            this.edtKontonameBisX = new KiSS4.Gui.KissTextEdit();
            this.edtKontonameVonX = new KiSS4.Gui.KissTextEdit();
            this.lblKontoNrBisX = new KiSS4.Gui.KissLabel();
            this.lblKontoVonX = new KiSS4.Gui.KissLabel();
            this.edtKontoBisX = new KiSS4.Gui.KissButtonEdit();
            this.lblDatumBisX = new KiSS4.Gui.KissLabel();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVonX = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoblaetter)).BeginInit();
            this.TabControlEx1.SuspendLayout();
            this.tabListe.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoblaetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontoblaetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            this.tabSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBereichPeriodenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrtX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMTraegerX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMTX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlzOrtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriodenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNrBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).BeginInit();
            this.SuspendLayout();
            // 
            // qryKontoblaetter
            // 
            this.qryKontoblaetter.HostControl = this;
            this.qryKontoblaetter.IsIdentityInsert = false;
            this.qryKontoblaetter.AfterFill += new System.EventHandler(this.qryKontoblaetter_AfterFill);
            // 
            // TabControlEx1
            // 
            this.TabControlEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlEx1.Controls.Add(this.tabListe);
            this.TabControlEx1.Controls.Add(this.tabSuchen);
            this.TabControlEx1.Location = new System.Drawing.Point(7, 10);
            this.TabControlEx1.Name = "TabControlEx1";
            this.TabControlEx1.SelectedTabIndex = 1;
            this.TabControlEx1.ShowFixedWidthTooltip = true;
            this.TabControlEx1.Size = new System.Drawing.Size(823, 525);
            this.TabControlEx1.TabIndex = 0;
            this.TabControlEx1.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabListe,
            this.tabSuchen});
            this.TabControlEx1.TabsLineColor = System.Drawing.Color.Black;
            this.TabControlEx1.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tabListe
            // 
            this.tabListe.Controls.Add(this.panel1);
            this.tabListe.Controls.Add(this.lblMandant);
            this.tabListe.Location = new System.Drawing.Point(6, 6);
            this.tabListe.Name = "tabListe";
            this.tabListe.Size = new System.Drawing.Size(811, 487);
            this.tabListe.TabIndex = 0;
            this.tabListe.Title = "Liste";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdKontoblaetter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 462);
            this.panel1.TabIndex = 3;
            // 
            // grdKontoblaetter
            // 
            this.grdKontoblaetter.DataSource = this.qryKontoblaetter;
            this.grdKontoblaetter.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKontoblaetter.EmbeddedNavigator.Name = "";
            this.grdKontoblaetter.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKontoblaetter.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdKontoblaetter.Location = new System.Drawing.Point(0, 0);
            this.grdKontoblaetter.MainView = this.grvKontoblaetter;
            this.grdKontoblaetter.Name = "grdKontoblaetter";
            this.grdKontoblaetter.Size = new System.Drawing.Size(811, 462);
            this.grdKontoblaetter.TabIndex = 2;
            this.grdKontoblaetter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKontoblaetter});
            // 
            // grvKontoblaetter
            // 
            this.grvKontoblaetter.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKontoblaetter.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.Empty.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.Empty.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKontoblaetter.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.EvenRow.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontoblaetter.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKontoblaetter.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKontoblaetter.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKontoblaetter.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKontoblaetter.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKontoblaetter.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontoblaetter.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKontoblaetter.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontoblaetter.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvKontoblaetter.Appearance.GroupFooter.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontoblaetter.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKontoblaetter.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontoblaetter.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontoblaetter.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.GroupRow.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKontoblaetter.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKontoblaetter.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKontoblaetter.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKontoblaetter.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKontoblaetter.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKontoblaetter.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKontoblaetter.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKontoblaetter.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontoblaetter.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvKontoblaetter.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.OddRow.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.OddRow.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKontoblaetter.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.Row.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.Row.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvKontoblaetter.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKontoblaetter.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKontoblaetter.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKontoblaetter.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKontoblaetter.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKontoblaetter.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKontoblaetter.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKontoblaetter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKontoblaetter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKtoName,
            this.colDatum,
            this.colBelegNr,
            this.colMandant,
            this.colGKtoNr,
            this.colText,
            this.colBetragSoll,
            this.colBetragHaben,
            this.colSaldo});
            this.grvKontoblaetter.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKontoblaetter.GridControl = this.grdKontoblaetter;
            this.grvKontoblaetter.GroupCount = 1;
            this.grvKontoblaetter.GroupRowHeight = 25;
            this.grvKontoblaetter.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragSoll", this.colBetragSoll, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragHaben", this.colBetragHaben, "{0:N2}")});
            this.grvKontoblaetter.Name = "grvKontoblaetter";
            this.grvKontoblaetter.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvKontoblaetter.OptionsBehavior.Editable = false;
            this.grvKontoblaetter.OptionsCustomization.AllowFilter = false;
            this.grvKontoblaetter.OptionsCustomization.AllowGroup = false;
            this.grvKontoblaetter.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKontoblaetter.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKontoblaetter.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvKontoblaetter.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvKontoblaetter.OptionsNavigation.UseTabKey = false;
            this.grvKontoblaetter.OptionsPrint.AutoWidth = false;
            this.grvKontoblaetter.OptionsPrint.UsePrintStyles = true;
            this.grvKontoblaetter.OptionsView.ColumnAutoWidth = false;
            this.grvKontoblaetter.OptionsView.ShowDetailButtons = false;
            this.grvKontoblaetter.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKontoblaetter.OptionsView.ShowGroupPanel = false;
            this.grvKontoblaetter.OptionsView.ShowIndicator = false;
            this.grvKontoblaetter.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKtoName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colKtoName
            // 
            this.colKtoName.Caption = "Konto";
            this.colKtoName.FieldName = "KtoName";
            this.colKtoName.Name = "colKtoName";
            this.colKtoName.Width = 59;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.DisplayFormat.FormatString = "d";
            this.colDatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatum.FieldName = "BuchungsDatum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 106;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg";
            this.colBelegNr.DisplayFormat.FormatString = "BelegNr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            this.colBelegNr.Width = 69;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Mandant";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 2;
            this.colMandant.Width = 115;
            // 
            // colGKtoNr
            // 
            this.colGKtoNr.Caption = "GKto";
            this.colGKtoNr.FieldName = "GKtoNr";
            this.colGKtoNr.Name = "colGKtoNr";
            this.colGKtoNr.Visible = true;
            this.colGKtoNr.VisibleIndex = 3;
            this.colGKtoNr.Width = 57;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 4;
            this.colText.Width = 180;
            // 
            // colBetragSoll
            // 
            this.colBetragSoll.Caption = "Soll";
            this.colBetragSoll.DisplayFormat.FormatString = "N";
            this.colBetragSoll.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragSoll.FieldName = "BetragSoll";
            this.colBetragSoll.Name = "colBetragSoll";
            this.colBetragSoll.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragSoll.Visible = true;
            this.colBetragSoll.VisibleIndex = 5;
            this.colBetragSoll.Width = 90;
            // 
            // colBetragHaben
            // 
            this.colBetragHaben.Caption = "Haben";
            this.colBetragHaben.DisplayFormat.FormatString = "N";
            this.colBetragHaben.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragHaben.FieldName = "BetragHaben";
            this.colBetragHaben.Name = "colBetragHaben";
            this.colBetragHaben.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragHaben.Visible = true;
            this.colBetragHaben.VisibleIndex = 6;
            this.colBetragHaben.Width = 90;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "N";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 7;
            this.colSaldo.Width = 90;
            // 
            // lblMandant
            // 
            this.lblMandant.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMandant.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblMandant.Location = new System.Drawing.Point(0, 0);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(811, 25);
            this.lblMandant.TabIndex = 2;
            this.lblMandant.Text = "Mandant";
            // 
            // tabSuchen
            // 
            this.tabSuchen.Controls.Add(this.lblDatumBereichPeriodenX);
            this.tabSuchen.Controls.Add(this.kissSearchTitel1);
            this.tabSuchen.Controls.Add(this.lblOrtX);
            this.tabSuchen.Controls.Add(this.lblMTraegerX);
            this.tabSuchen.Controls.Add(this.edtMTX);
            this.tabSuchen.Controls.Add(this.edtMandantX);
            this.tabSuchen.Controls.Add(this.editMandantNrX);
            this.tabSuchen.Controls.Add(this.edtPlzOrtX);
            this.tabSuchen.Controls.Add(this.lblMandantX);
            this.tabSuchen.Controls.Add(this.grdPeriodenX);
            this.tabSuchen.Controls.Add(this.edtKontoVonX);
            this.tabSuchen.Controls.Add(this.edtKontonameBisX);
            this.tabSuchen.Controls.Add(this.edtKontonameVonX);
            this.tabSuchen.Controls.Add(this.lblKontoNrBisX);
            this.tabSuchen.Controls.Add(this.lblKontoVonX);
            this.tabSuchen.Controls.Add(this.edtKontoBisX);
            this.tabSuchen.Controls.Add(this.lblDatumBisX);
            this.tabSuchen.Controls.Add(this.edtDatumVonX);
            this.tabSuchen.Controls.Add(this.edtDatumBisX);
            this.tabSuchen.Controls.Add(this.lblDatumVonX);
            this.tabSuchen.Location = new System.Drawing.Point(6, 6);
            this.tabSuchen.Name = "tabSuchen";
            this.tabSuchen.Size = new System.Drawing.Size(811, 487);
            this.tabSuchen.TabIndex = 1;
            this.tabSuchen.Title = "Suchen";
            this.tabSuchen.Visible = false;
            // 
            // lblDatumBereichPeriodenX
            // 
            this.lblDatumBereichPeriodenX.ForeColor = System.Drawing.Color.Black;
            this.lblDatumBereichPeriodenX.Location = new System.Drawing.Point(353, 230);
            this.lblDatumBereichPeriodenX.Name = "lblDatumBereichPeriodenX";
            this.lblDatumBereichPeriodenX.Size = new System.Drawing.Size(241, 24);
            this.lblDatumBereichPeriodenX.TabIndex = 364;
            this.lblDatumBereichPeriodenX.Text = "(Datumbereich darf periodenübergreifend sein)";
            // 
            // kissSearchTitel1
            // 
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(10, 4);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 363;
            // 
            // lblOrtX
            // 
            this.lblOrtX.ForeColor = System.Drawing.Color.Black;
            this.lblOrtX.Location = new System.Drawing.Point(5, 72);
            this.lblOrtX.Name = "lblOrtX";
            this.lblOrtX.Size = new System.Drawing.Size(63, 24);
            this.lblOrtX.TabIndex = 362;
            this.lblOrtX.Text = "Ort";
            // 
            // lblMTraegerX
            // 
            this.lblMTraegerX.ForeColor = System.Drawing.Color.Black;
            this.lblMTraegerX.Location = new System.Drawing.Point(5, 95);
            this.lblMTraegerX.Name = "lblMTraegerX";
            this.lblMTraegerX.Size = new System.Drawing.Size(61, 24);
            this.lblMTraegerX.TabIndex = 361;
            this.lblMTraegerX.Text = "M.Träger";
            // 
            // edtMTX
            // 
            this.edtMTX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMTX.Location = new System.Drawing.Point(84, 95);
            this.edtMTX.Name = "edtMTX";
            this.edtMTX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMTX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMTX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMTX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMTX.Properties.Appearance.Options.UseBackColor = true;
            this.edtMTX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMTX.Properties.Appearance.Options.UseFont = true;
            this.edtMTX.Properties.Appearance.Options.UseForeColor = true;
            this.edtMTX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMTX.Properties.ReadOnly = true;
            this.edtMTX.Size = new System.Drawing.Size(285, 24);
            this.edtMTX.TabIndex = 360;
            this.edtMTX.TabStop = false;
            // 
            // edtMandantX
            // 
            this.edtMandantX.Location = new System.Drawing.Point(84, 33);
            this.edtMandantX.Name = "edtMandantX";
            this.edtMandantX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandantX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtMandantX.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantX.Properties.Appearance.Options.UseFont = true;
            this.edtMandantX.Properties.Appearance.Options.UseForeColor = true;
            this.edtMandantX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMandantX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMandantX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandantX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMandantX.Size = new System.Drawing.Size(205, 24);
            this.edtMandantX.TabIndex = 0;
            this.edtMandantX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandantX_UserModifiedFld);
            // 
            // editMandantNrX
            // 
            this.editMandantNrX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMandantNrX.Location = new System.Drawing.Point(300, 33);
            this.editMandantNrX.Name = "editMandantNrX";
            this.editMandantNrX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editMandantNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandantNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandantNrX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editMandantNrX.Properties.Appearance.Options.UseBackColor = true;
            this.editMandantNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandantNrX.Properties.Appearance.Options.UseFont = true;
            this.editMandantNrX.Properties.Appearance.Options.UseForeColor = true;
            this.editMandantNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editMandantNrX.Properties.ReadOnly = true;
            this.editMandantNrX.Size = new System.Drawing.Size(70, 24);
            this.editMandantNrX.TabIndex = 359;
            this.editMandantNrX.TabStop = false;
            // 
            // edtPlzOrtX
            // 
            this.edtPlzOrtX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPlzOrtX.Location = new System.Drawing.Point(84, 72);
            this.edtPlzOrtX.Name = "edtPlzOrtX";
            this.edtPlzOrtX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPlzOrtX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPlzOrtX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPlzOrtX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtPlzOrtX.Properties.Appearance.Options.UseBackColor = true;
            this.edtPlzOrtX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPlzOrtX.Properties.Appearance.Options.UseFont = true;
            this.edtPlzOrtX.Properties.Appearance.Options.UseForeColor = true;
            this.edtPlzOrtX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPlzOrtX.Properties.ReadOnly = true;
            this.edtPlzOrtX.Size = new System.Drawing.Size(285, 24);
            this.edtPlzOrtX.TabIndex = 358;
            this.edtPlzOrtX.TabStop = false;
            // 
            // lblMandantX
            // 
            this.lblMandantX.ForeColor = System.Drawing.Color.Black;
            this.lblMandantX.Location = new System.Drawing.Point(5, 33);
            this.lblMandantX.Name = "lblMandantX";
            this.lblMandantX.Size = new System.Drawing.Size(63, 24);
            this.lblMandantX.TabIndex = 357;
            this.lblMandantX.Text = "Mandant";
            // 
            // grdPeriodenX
            // 
            this.grdPeriodenX.DataSource = this.qryPeriodeX;
            // 
            // 
            // 
            this.grdPeriodenX.EmbeddedNavigator.Name = "";
            this.grdPeriodenX.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPeriodenX.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdPeriodenX.Location = new System.Drawing.Point(408, 33);
            this.grdPeriodenX.MainView = this.grvPeriodeX;
            this.grdPeriodenX.Name = "grdPeriodenX";
            this.grdPeriodenX.Size = new System.Drawing.Size(384, 89);
            this.grdPeriodenX.TabIndex = 5;
            this.grdPeriodenX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPeriodeX});
            // 
            // qryPeriodeX
            // 
            this.qryPeriodeX.HostControl = this;
            this.qryPeriodeX.IsIdentityInsert = false;
            this.qryPeriodeX.TableName = "FbBuchungCode";
            this.qryPeriodeX.PositionChanged += new System.EventHandler(this.qryPeriodeX_PositionChanged);
            // 
            // grvPeriodeX
            // 
            this.grvPeriodeX.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvPeriodeX.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.Empty.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.Empty.Options.UseFont = true;
            this.grvPeriodeX.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvPeriodeX.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.EvenRow.Options.UseFont = true;
            this.grvPeriodeX.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriodeX.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvPeriodeX.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.FocusedCell.Options.UseFont = true;
            this.grvPeriodeX.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvPeriodeX.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvPeriodeX.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvPeriodeX.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.FocusedRow.Options.UseFont = true;
            this.grvPeriodeX.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvPeriodeX.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriodeX.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPeriodeX.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvPeriodeX.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriodeX.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvPeriodeX.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPeriodeX.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriodeX.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.GroupRow.Options.UseFont = true;
            this.grvPeriodeX.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvPeriodeX.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvPeriodeX.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvPeriodeX.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvPeriodeX.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvPeriodeX.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvPeriodeX.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvPeriodeX.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvPeriodeX.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvPeriodeX.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvPeriodeX.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriodeX.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvPeriodeX.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.OddRow.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.OddRow.Options.UseFont = true;
            this.grvPeriodeX.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvPeriodeX.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.Row.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.Row.Options.UseFont = true;
            this.grvPeriodeX.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvPeriodeX.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvPeriodeX.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvPeriodeX.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPeriodeX.Appearance.SelectedRow.Options.UseFont = true;
            this.grvPeriodeX.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPeriodeX.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvPeriodeX.Appearance.VertLine.Options.UseBackColor = true;
            this.grvPeriodeX.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvPeriodeX.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colBis,
            this.colStatus,
            this.colID});
            this.grvPeriodeX.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvPeriodeX.GridControl = this.grdPeriodenX;
            this.grvPeriodeX.Name = "grvPeriodeX";
            this.grvPeriodeX.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvPeriodeX.OptionsBehavior.Editable = false;
            this.grvPeriodeX.OptionsCustomization.AllowFilter = false;
            this.grvPeriodeX.OptionsCustomization.AllowGroup = false;
            this.grvPeriodeX.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvPeriodeX.OptionsNavigation.AutoFocusNewRow = true;
            this.grvPeriodeX.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvPeriodeX.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvPeriodeX.OptionsNavigation.UseTabKey = false;
            this.grvPeriodeX.OptionsView.ColumnAutoWidth = false;
            this.grvPeriodeX.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvPeriodeX.OptionsView.ShowGroupPanel = false;
            this.grvPeriodeX.OptionsView.ShowIndicator = false;
            // 
            // colVon
            // 
            this.colVon.Caption = "Periode Von";
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 90;
            // 
            // colBis
            // 
            this.colBis.Caption = "Periode Bis";
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            this.colBis.Width = 90;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 100;
            // 
            // colID
            // 
            this.colID.Caption = "PeriodeID";
            this.colID.FieldName = "FbPeriodeID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 3;
            // 
            // edtKontoVonX
            // 
            this.edtKontoVonX.Location = new System.Drawing.Point(84, 145);
            this.edtKontoVonX.Name = "edtKontoVonX";
            this.edtKontoVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoVonX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtKontoVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoVonX.Properties.Appearance.Options.UseFont = true;
            this.edtKontoVonX.Properties.Appearance.Options.UseForeColor = true;
            this.edtKontoVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKontoVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKontoVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoVonX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoVonX.Size = new System.Drawing.Size(106, 24);
            this.edtKontoVonX.TabIndex = 1;
            this.edtKontoVonX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoVonX_UserModifiedFld);
            // 
            // edtKontonameBisX
            // 
            this.edtKontonameBisX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontonameBisX.EditValue = "";
            this.edtKontonameBisX.Location = new System.Drawing.Point(198, 180);
            this.edtKontonameBisX.Name = "edtKontonameBisX";
            this.edtKontonameBisX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontonameBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontonameBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontonameBisX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtKontonameBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontonameBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontonameBisX.Properties.Appearance.Options.UseFont = true;
            this.edtKontonameBisX.Properties.Appearance.Options.UseForeColor = true;
            this.edtKontonameBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontonameBisX.Properties.ReadOnly = true;
            this.edtKontonameBisX.Size = new System.Drawing.Size(346, 24);
            this.edtKontonameBisX.TabIndex = 354;
            this.edtKontonameBisX.TabStop = false;
            // 
            // edtKontonameVonX
            // 
            this.edtKontonameVonX.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKontonameVonX.EditValue = "";
            this.edtKontonameVonX.Location = new System.Drawing.Point(198, 145);
            this.edtKontonameVonX.Name = "edtKontonameVonX";
            this.edtKontonameVonX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKontonameVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontonameVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontonameVonX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtKontonameVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontonameVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontonameVonX.Properties.Appearance.Options.UseFont = true;
            this.edtKontonameVonX.Properties.Appearance.Options.UseForeColor = true;
            this.edtKontonameVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontonameVonX.Properties.ReadOnly = true;
            this.edtKontonameVonX.Size = new System.Drawing.Size(346, 24);
            this.edtKontonameVonX.TabIndex = 353;
            this.edtKontonameVonX.TabStop = false;
            // 
            // lblKontoNrBisX
            // 
            this.lblKontoNrBisX.ForeColor = System.Drawing.Color.Black;
            this.lblKontoNrBisX.Location = new System.Drawing.Point(5, 180);
            this.lblKontoNrBisX.Name = "lblKontoNrBisX";
            this.lblKontoNrBisX.Size = new System.Drawing.Size(73, 24);
            this.lblKontoNrBisX.TabIndex = 352;
            this.lblKontoNrBisX.Text = "Konto-Nr. bis";
            // 
            // lblKontoVonX
            // 
            this.lblKontoVonX.ForeColor = System.Drawing.Color.Black;
            this.lblKontoVonX.Location = new System.Drawing.Point(5, 145);
            this.lblKontoVonX.Name = "lblKontoVonX";
            this.lblKontoVonX.Size = new System.Drawing.Size(73, 24);
            this.lblKontoVonX.TabIndex = 351;
            this.lblKontoVonX.Text = "Konto-Nr von";
            // 
            // edtKontoBisX
            // 
            this.edtKontoBisX.Location = new System.Drawing.Point(84, 180);
            this.edtKontoBisX.Name = "edtKontoBisX";
            this.edtKontoBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoBisX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtKontoBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoBisX.Properties.Appearance.Options.UseFont = true;
            this.edtKontoBisX.Properties.Appearance.Options.UseForeColor = true;
            this.edtKontoBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKontoBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKontoBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoBisX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoBisX.Size = new System.Drawing.Size(106, 24);
            this.edtKontoBisX.TabIndex = 2;
            this.edtKontoBisX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoBisX_UserModifiedFld);
            // 
            // lblDatumBisX
            // 
            this.lblDatumBisX.ForeColor = System.Drawing.Color.Black;
            this.lblDatumBisX.Location = new System.Drawing.Point(204, 230);
            this.lblDatumBisX.Name = "lblDatumBisX";
            this.lblDatumBisX.Size = new System.Drawing.Size(18, 24);
            this.lblDatumBisX.TabIndex = 4;
            this.lblDatumBisX.Text = "-";
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = "";
            this.edtDatumVonX.Location = new System.Drawing.Point(84, 230);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseForeColor = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.NullDate = "";
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(106, 24);
            this.edtDatumVonX.TabIndex = 3;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = "";
            this.edtDatumBisX.Location = new System.Drawing.Point(228, 230);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseForeColor = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(106, 24);
            this.edtDatumBisX.TabIndex = 4;
            // 
            // lblDatumVonX
            // 
            this.lblDatumVonX.ForeColor = System.Drawing.Color.Black;
            this.lblDatumVonX.Location = new System.Drawing.Point(5, 230);
            this.lblDatumVonX.Name = "lblDatumVonX";
            this.lblDatumVonX.Size = new System.Drawing.Size(44, 24);
            this.lblDatumVonX.TabIndex = 332;
            this.lblDatumVonX.Text = "Datum";
            // 
            // CtlFibuKontoblatt
            // 
            this.ActiveSQLQuery = this.qryKontoblaetter;
            this.AutoRefresh = false;
            this.Controls.Add(this.TabControlEx1);
            this.Name = "CtlFibuKontoblatt";
            this.Size = new System.Drawing.Size(840, 535);
            this.Print += new System.EventHandler(this.CtlFibuKontoblatt_Print);
            this.Search += new System.EventHandler(this.CtlFibuKontoblatt_Search);
            this.Load += new System.EventHandler(this.CtlFibuKontoblatt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoblaetter)).EndInit();
            this.TabControlEx1.ResumeLayout(false);
            this.tabListe.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKontoblaetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKontoblaetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            this.tabSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBereichPeriodenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrtX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMTraegerX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMTX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPlzOrtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPeriodenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPeriodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontonameVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoNrBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTabControlEx TabControlEx1;
        private SharpLibrary.WinControls.TabPageEx tabListe;
        private SharpLibrary.WinControls.TabPageEx tabSuchen;
        private KiSS4.Gui.KissLabel lblDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissLabel lblDatumVonX;
        private KiSS4.Gui.KissLabel lblKontoNrBisX;
        private KiSS4.Gui.KissLabel lblKontoVonX;
        private KiSS4.Gui.KissLabel lblOrtX;
        private KiSS4.Gui.KissLabel lblMTraegerX;
        private KiSS4.Gui.KissTextEdit edtMTX;
        private KiSS4.Gui.KissButtonEdit edtMandantX;
        private KiSS4.Gui.KissTextEdit editMandantNrX;
        private KiSS4.Gui.KissTextEdit edtPlzOrtX;
        private KiSS4.Gui.KissLabel lblMandantX;
        private KiSS4.Gui.KissGrid grdPeriodenX;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPeriodeX;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private KiSS4.Gui.KissButtonEdit edtKontoVonX;
        private KiSS4.Gui.KissTextEdit edtKontonameBisX;
        private KiSS4.Gui.KissTextEdit edtKontonameVonX;
        private KiSS4.Gui.KissButtonEdit edtKontoBisX;
        private KiSS4.DB.SqlQuery qryKontoblaetter;
        private KiSS4.DB.SqlQuery qryPeriodeX;
        private KiSS4.Gui.KissLabel lblMandant;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.Gui.KissGrid grdKontoblaetter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKontoblaetter;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoName;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colGKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissLabel lblDatumBereichPeriodenX;
    }
}