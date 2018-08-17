using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Inkasso
{
    partial class CtlIkLandesindex
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkLandesindex));
            this.grdLandesindexWert = new KiSS4.Gui.KissGrid();
            this.qryLandesindexWert = new KiSS4.DB.SqlQuery(this.components);
            this.grvLandesindexWert = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtColWert = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryLandesindex = new KiSS4.DB.SqlQuery(this.components);
            this.btnBfsLandesindex = new KiSS4.Gui.KissHyperlinkButton();
            this.grdLandesindex = new KiSS4.Gui.KissGrid();
            this.grvLandesindex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkLandesindexID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCreateIndex = new KiSS4.Gui.KissButton();
            this.btnDeleteIndex = new KiSS4.Gui.KissButton();
            this.lblIndexWerteTitel = new KiSS4.Gui.KissLabel();
            this.lblHintTop = new KiSS4.Gui.KissLabel();
            this.btnCreateValues = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdLandesindexWert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLandesindexWert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLandesindexWert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColWert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLandesindex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLandesindex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLandesindex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexWerteTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHintTop)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLandesindexWert
            // 
            this.grdLandesindexWert.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLandesindexWert.DataSource = this.qryLandesindexWert;
            // 
            // 
            // 
            this.grdLandesindexWert.EmbeddedNavigator.Name = "";
            this.grdLandesindexWert.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdLandesindexWert.Location = new System.Drawing.Point(3, 257);
            this.grdLandesindexWert.MainView = this.grvLandesindexWert;
            this.grdLandesindexWert.Name = "grdLandesindexWert";
            this.grdLandesindexWert.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.edtColWert});
            this.grdLandesindexWert.Size = new System.Drawing.Size(818, 216);
            this.grdLandesindexWert.TabIndex = 2;
            this.grdLandesindexWert.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLandesindexWert,
            this.gridView1});
            // 
            // qryLandesindexWert
            // 
            this.qryLandesindexWert.CanDelete = true;
            this.qryLandesindexWert.CanInsert = true;
            this.qryLandesindexWert.CanUpdate = true;
            this.qryLandesindexWert.HostControl = this;
            this.qryLandesindexWert.SelectStatement = resources.GetString("qryLandesindexWert.SelectStatement");
            this.qryLandesindexWert.TableName = "IkLandesindexWert";
            this.qryLandesindexWert.AfterFill += new System.EventHandler(this.qryLandesindexWert_AfterFill);
            this.qryLandesindexWert.AfterInsert += new System.EventHandler(this.qryLandesindexWert_AfterInsert);
            // 
            // grvLandesindexWert
            // 
            this.grvLandesindexWert.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvLandesindexWert.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.Empty.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.Empty.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvLandesindexWert.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.EvenRow.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindexWert.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvLandesindexWert.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.FocusedCell.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvLandesindexWert.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindexWert.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvLandesindexWert.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.FocusedRow.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvLandesindexWert.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLandesindexWert.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLandesindexWert.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLandesindexWert.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLandesindexWert.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.GroupRow.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvLandesindexWert.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvLandesindexWert.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvLandesindexWert.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLandesindexWert.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvLandesindexWert.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindexWert.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLandesindexWert.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvLandesindexWert.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvLandesindexWert.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.OddRow.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindexWert.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.Row.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.Row.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindexWert.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindexWert.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvLandesindexWert.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvLandesindexWert.Appearance.SelectedRow.Options.UseFont = true;
            this.grvLandesindexWert.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvLandesindexWert.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvLandesindexWert.Appearance.VertLine.Options.UseBackColor = true;
            this.grvLandesindexWert.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvLandesindexWert.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJahr,
            this.colMonat,
            this.colWert});
            this.grvLandesindexWert.GridControl = this.grdLandesindexWert;
            this.grvLandesindexWert.Name = "grvLandesindexWert";
            this.grvLandesindexWert.OptionsCustomization.AllowFilter = false;
            this.grvLandesindexWert.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvLandesindexWert.OptionsNavigation.AutoFocusNewRow = true;
            this.grvLandesindexWert.OptionsView.ColumnAutoWidth = false;
            this.grvLandesindexWert.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvLandesindexWert.OptionsView.ShowGroupPanel = false;
            // 
            // colJahr
            // 
            this.colJahr.Caption = "Jahr";
            this.colJahr.FieldName = "Jahr";
            this.colJahr.Name = "colJahr";
            this.colJahr.Visible = true;
            this.colJahr.VisibleIndex = 0;
            this.colJahr.Width = 60;
            // 
            // colMonat
            // 
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "Monat";
            this.colMonat.Name = "colMonat";
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 1;
            this.colMonat.Width = 49;
            // 
            // colWert
            // 
            this.colWert.Caption = "Wert";
            this.colWert.ColumnEdit = this.edtColWert;
            this.colWert.DisplayFormat.FormatString = "f";
            this.colWert.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWert.FieldName = "Wert";
            this.colWert.Name = "colWert";
            this.colWert.Visible = true;
            this.colWert.VisibleIndex = 2;
            this.colWert.Width = 100;
            // 
            // edtColWert
            // 
            this.edtColWert.AutoHeight = false;
            this.edtColWert.Mask.EditMask = "f";
            this.edtColWert.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtColWert.Mask.UseMaskAsDisplayFormat = true;
            this.edtColWert.Name = "edtColWert";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.GridControl = this.grdLandesindexWert;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // qryLandesindex
            // 
            this.qryLandesindex.CanDelete = true;
            this.qryLandesindex.CanInsert = true;
            this.qryLandesindex.CanUpdate = true;
            this.qryLandesindex.HostControl = this;
            this.qryLandesindex.SelectStatement = "SELECT IkLandesindexID,\r\n       Name,\r\n       Creator,\r\n       Created,\r\n       M" +
    "odifier,\r\n       Modified\r\nFROM dbo.IkLandesindex WITH(READUNCOMMITTED)\r\nORDER B" +
    "Y IkLandesindexID ASC;";
            this.qryLandesindex.TableName = "IkLandesIndex";
            this.qryLandesindex.AfterFill += new System.EventHandler(this.qryLandesindex_AfterFill);
            this.qryLandesindex.BeforeDelete += new System.EventHandler(this.qryLandesindex_BeforeDelete);
            this.qryLandesindex.PositionChanged += new System.EventHandler(this.qryLandesindex_PositionChanged);
            // 
            // btnBfsLandesindex
            // 
            this.btnBfsLandesindex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBfsLandesindex.BackColor = System.Drawing.Color.Bisque;
            this.btnBfsLandesindex.ButtonStyle = KiSS4.Gui.ButtonStyleType.Custom;
            this.btnBfsLandesindex.Context = "BfsLandesindex";
            this.btnBfsLandesindex.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBfsLandesindex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBfsLandesindex.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Pixel);
            this.btnBfsLandesindex.ForeColor = System.Drawing.Color.Blue;
            this.btnBfsLandesindex.Location = new System.Drawing.Point(3, 479);
            this.btnBfsLandesindex.Name = "btnBfsLandesindex";
            this.btnBfsLandesindex.Size = new System.Drawing.Size(100, 24);
            this.btnBfsLandesindex.TabIndex = 3;
            this.btnBfsLandesindex.Text = "BFS-Webseite";
            this.btnBfsLandesindex.URL = "http://www.bfs.admin.ch/bfs/portal/de/index/themen/05/02/blank/key/basis_aktuell." +
    "html";
            this.btnBfsLandesindex.UseVisualStyleBackColor = false;
            // 
            // grdLandesindex
            // 
            this.grdLandesindex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLandesindex.DataSource = this.qryLandesindex;
            // 
            // 
            // 
            this.grdLandesindex.EmbeddedNavigator.Name = "";
            this.grdLandesindex.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdLandesindex.Location = new System.Drawing.Point(3, 33);
            this.grdLandesindex.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.grdLandesindex.MainView = this.grvLandesindex;
            this.grdLandesindex.Name = "grdLandesindex";
            this.grdLandesindex.Size = new System.Drawing.Size(818, 164);
            this.grdLandesindex.TabIndex = 1;
            this.grdLandesindex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLandesindex});
            // 
            // grvLandesindex
            // 
            this.grvLandesindex.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvLandesindex.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.Empty.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.Empty.Options.UseFont = true;
            this.grvLandesindex.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvLandesindex.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.EvenRow.Options.UseFont = true;
            this.grvLandesindex.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindex.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvLandesindex.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.FocusedCell.Options.UseFont = true;
            this.grvLandesindex.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvLandesindex.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindex.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvLandesindex.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.FocusedRow.Options.UseFont = true;
            this.grvLandesindex.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvLandesindex.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLandesindex.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvLandesindex.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLandesindex.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLandesindex.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.GroupRow.Options.UseFont = true;
            this.grvLandesindex.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvLandesindex.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvLandesindex.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvLandesindex.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvLandesindex.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvLandesindex.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLandesindex.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindex.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvLandesindex.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvLandesindex.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvLandesindex.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvLandesindex.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.OddRow.Options.UseFont = true;
            this.grvLandesindex.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindex.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.Row.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.Row.Options.UseFont = true;
            this.grvLandesindex.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvLandesindex.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvLandesindex.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvLandesindex.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvLandesindex.Appearance.SelectedRow.Options.UseFont = true;
            this.grvLandesindex.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvLandesindex.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvLandesindex.Appearance.VertLine.Options.UseBackColor = true;
            this.grvLandesindex.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvLandesindex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colIkLandesindexID});
            this.grvLandesindex.GridControl = this.grdLandesindex;
            this.grvLandesindex.Name = "grvLandesindex";
            this.grvLandesindex.OptionsCustomization.AllowFilter = false;
            this.grvLandesindex.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvLandesindex.OptionsNavigation.AutoFocusNewRow = true;
            this.grvLandesindex.OptionsView.ColumnAutoWidth = false;
            this.grvLandesindex.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvLandesindex.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "Landesindex-Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 200;
            // 
            // colIkLandesindexID
            // 
            this.colIkLandesindexID.Caption = "ID";
            this.colIkLandesindexID.FieldName = "IkLandesindexID";
            this.colIkLandesindexID.Name = "colIkLandesindexID";
            this.colIkLandesindexID.OptionsColumn.AllowEdit = false;
            this.colIkLandesindexID.OptionsColumn.AllowFocus = false;
            this.colIkLandesindexID.OptionsColumn.ReadOnly = true;
            this.colIkLandesindexID.Visible = true;
            this.colIkLandesindexID.VisibleIndex = 1;
            // 
            // btnCreateIndex
            // 
            this.btnCreateIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateIndex.Location = new System.Drawing.Point(3, 3);
            this.btnCreateIndex.Name = "btnCreateIndex";
            this.btnCreateIndex.Size = new System.Drawing.Size(150, 24);
            this.btnCreateIndex.TabIndex = 0;
            this.btnCreateIndex.Text = "Neuer Landesindex";
            this.btnCreateIndex.UseVisualStyleBackColor = false;
            this.btnCreateIndex.Click += new System.EventHandler(this.btnCreateLandesindex_Click);
            // 
            // btnDeleteIndex
            // 
            this.btnDeleteIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteIndex.Location = new System.Drawing.Point(159, 3);
            this.btnDeleteIndex.Name = "btnDeleteIndex";
            this.btnDeleteIndex.Size = new System.Drawing.Size(150, 24);
            this.btnDeleteIndex.TabIndex = 4;
            this.btnDeleteIndex.Text = "Landesindex löschen";
            this.btnDeleteIndex.UseVisualStyleBackColor = false;
            this.btnDeleteIndex.Click += new System.EventHandler(this.btnDeleteIndex_Click);
            // 
            // lblIndexWerteTitel
            // 
            this.lblIndexWerteTitel.Location = new System.Drawing.Point(3, 230);
            this.lblIndexWerteTitel.Name = "lblIndexWerteTitel";
            this.lblIndexWerteTitel.Size = new System.Drawing.Size(250, 24);
            this.lblIndexWerteTitel.TabIndex = 5;
            this.lblIndexWerteTitel.Text = "Werte für den ausgewählten Landesindex:";
            // 
            // lblHintTop
            // 
            this.lblHintTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHintTop.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHintTop.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblHintTop.Location = new System.Drawing.Point(315, 3);
            this.lblHintTop.Name = "lblHintTop";
            this.lblHintTop.Size = new System.Drawing.Size(506, 24);
            this.lblHintTop.TabIndex = 6;
            this.lblHintTop.Text = "Achtung: Die LOV \'IkIndexTyp\' muss bei Änderungen angepasst werden.";
            this.lblHintTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCreateValues
            // 
            this.btnCreateValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateValues.Location = new System.Drawing.Point(3, 203);
            this.btnCreateValues.Name = "btnCreateValues";
            this.btnCreateValues.Size = new System.Drawing.Size(175, 24);
            this.btnCreateValues.TabIndex = 7;
            this.btnCreateValues.Text = "Neue Monatswerte erfassen";
            this.btnCreateValues.UseVisualStyleBackColor = false;
            this.btnCreateValues.Click += new System.EventHandler(this.btnCreateValues_Click);
            // 
            // CtlIkLandesindex
            // 
            this.ActiveSQLQuery = this.qryLandesindexWert;
            this.Controls.Add(this.btnCreateValues);
            this.Controls.Add(this.lblHintTop);
            this.Controls.Add(this.lblIndexWerteTitel);
            this.Controls.Add(this.btnDeleteIndex);
            this.Controls.Add(this.btnCreateIndex);
            this.Controls.Add(this.grdLandesindex);
            this.Controls.Add(this.btnBfsLandesindex);
            this.Controls.Add(this.grdLandesindexWert);
            this.Name = "CtlIkLandesindex";
            this.Size = new System.Drawing.Size(824, 506);
            this.Load += new System.EventHandler(this.CtlIkLandesIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLandesindexWert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLandesindexWert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLandesindexWert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtColWert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLandesindex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLandesindex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLandesindex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexWerteTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHintTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdLandesindexWert;
        private KiSS4.DB.SqlQuery qryLandesindex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLandesindexWert;
        private DevExpress.XtraGrid.Columns.GridColumn colJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colMonat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Gui.KissHyperlinkButton btnBfsLandesindex;
        private DevExpress.XtraGrid.Columns.GridColumn colWert;
        private DB.SqlQuery qryLandesindexWert;
        private Gui.KissGrid grdLandesindex;
        private Gui.KissButton btnCreateIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLandesindex;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private Gui.KissButton btnDeleteIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colIkLandesindexID;
        private Gui.KissLabel lblIndexWerteTitel;
        private Gui.KissLabel lblHintTop;
        private Gui.KissButton btnCreateValues;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edtColWert;
    }
}
