﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Vormundschaft
{
    partial class CtlVmRevisionen
    {
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

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmRevisionen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryVmBericht = new KiSS4.DB.SqlQuery(this.components);
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.grdVmBericht = new KiSS4.Gui.KissGrid();
            this.grvVmBericht = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBerichtsperiodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassation1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassation2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBerichtsperiode = new KiSS4.Gui.KissLabel();
            this.edtBerichtsperiodeVon = new KiSS4.Gui.KissDateEdit();
            this.edtBerichtsperiodeBis = new KiSS4.Gui.KissDateEdit();
            this.lblPassation2 = new KiSS4.Gui.KissLabel();
            this.edtPassation2 = new KiSS4.Gui.KissDateEdit();
            this.lblPassation1 = new KiSS4.Gui.KissLabel();
            this.edtPassation1 = new KiSS4.Gui.KissDateEdit();
            this.lblErstellung = new KiSS4.Gui.KissLabel();
            this.edtErstellung = new KiSS4.Gui.KissDateEdit();
            this.qryInfoMandant = new KiSS4.DB.SqlQuery(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.kissLabel47 = new KiSS4.Gui.KissLabel();
            this.kissLabel46 = new KiSS4.Gui.KissLabel();
            this.kissLabel45 = new KiSS4.Gui.KissLabel();
            this.kissLabel38 = new KiSS4.Gui.KissLabel();
            this.kissLabel28 = new KiSS4.Gui.KissLabel();
            this.kissLabel39 = new KiSS4.Gui.KissLabel();
            this.kissLabel41 = new KiSS4.Gui.KissLabel();
            this.kissLabel32 = new KiSS4.Gui.KissLabel();
            this.kissLabel31 = new KiSS4.Gui.KissLabel();
            this.kissLabel30 = new KiSS4.Gui.KissLabel();
            this.kissLabel26 = new KiSS4.Gui.KissLabel();
            this.kissLabel25 = new KiSS4.Gui.KissLabel();
            this.kissLabel40 = new KiSS4.Gui.KissLabel();
            this.kissLabel23 = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.label9 = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kissLabel29 = new KiSS4.Gui.KissLabel();
            this.qryInfoMassnahme = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel27 = new KiSS4.Gui.KissLabel();
            this.lblZGB = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.qryInfoMt = new KiSS4.DB.SqlQuery(this.components);
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.editPrivat = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel42 = new KiSS4.Gui.KissLabel();
            this.kissLabel43 = new KiSS4.Gui.KissLabel();
            this.kissLabel37 = new KiSS4.Gui.KissLabel();
            this.kissLabel36 = new KiSS4.Gui.KissLabel();
            this.kissLabel35 = new KiSS4.Gui.KissLabel();
            this.kissLabel34 = new KiSS4.Gui.KissLabel();
            this.kissLabel33 = new KiSS4.Gui.KissLabel();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.kissLabel24 = new KiSS4.Gui.KissLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.kissLabel44 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.lblMahnung = new KiSS4.Gui.KissLabel();
            this.edtVersand = new KiSS4.Gui.KissDateEdit();
            this.edtMahnung = new KiSS4.Gui.KissDateEdit();
            this.lblVersand = new KiSS4.Gui.KissLabel();
            this.lblEntschaedigung = new KiSS4.Gui.KissLabel();
            this.edtEntschaedigung = new KiSS4.Gui.KissCalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmBericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsperiode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassation2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassation2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassation1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfoMandant)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfoMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfoMt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPrivat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMahnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMahnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntschaedigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEntschaedigung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryVmBericht
            // 
            this.qryVmBericht.CanDelete = true;
            this.qryVmBericht.CanInsert = true;
            this.qryVmBericht.CanUpdate = true;
            this.qryVmBericht.HostControl = this;
            this.qryVmBericht.SelectStatement = "SELECT * FROM VmBericht WHERE FaLeistungID = {0}";
            this.qryVmBericht.TableName = "VmBericht";
            this.qryVmBericht.AfterInsert += new System.EventHandler(this.qryVmBericht_AfterInsert);
            this.qryVmBericht.BeforePost += new System.EventHandler(this.qryVmBericht_BeforePost);
            this.qryVmBericht.AfterPost += new System.EventHandler(this.qryVmBericht_AfterPost);
            this.qryVmBericht.PositionChanged += new System.EventHandler(this.qryVmBericht_PositionChanged);
            this.qryVmBericht.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryVmBericht_ColumnChanged);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Location = new System.Drawing.Point(8, 500);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(66, 24);
            this.lblBemerkung.TabIndex = 8;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
            // 
            // picTitel
            // 
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmBericht;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBemerkung.Location = new System.Drawing.Point(105, 500);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(596, 33);
            this.edtBemerkung.TabIndex = 8;
            // 
            // grdVmBericht
            // 
            this.grdVmBericht.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVmBericht.DataSource = this.qryVmBericht;
            // 
            // 
            // 
            this.grdVmBericht.EmbeddedNavigator.Name = "";
            this.grdVmBericht.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmBericht.Location = new System.Drawing.Point(5, 275);
            this.grdVmBericht.MainView = this.grvVmBericht;
            this.grdVmBericht.Name = "grdVmBericht";
            this.grdVmBericht.Size = new System.Drawing.Size(694, 99);
            this.grdVmBericht.TabIndex = 0;
            this.grdVmBericht.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmBericht});
            // 
            // grvVmBericht
            // 
            this.grvVmBericht.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmBericht.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.Empty.Options.UseFont = true;
            this.grvVmBericht.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmBericht.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmBericht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmBericht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmBericht.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmBericht.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmBericht.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmBericht.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmBericht.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmBericht.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmBericht.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmBericht.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmBericht.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmBericht.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmBericht.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmBericht.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmBericht.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmBericht.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmBericht.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.OddRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmBericht.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.Row.Options.UseBackColor = true;
            this.grvVmBericht.Appearance.Row.Options.UseFont = true;
            this.grvVmBericht.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBericht.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmBericht.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmBericht.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmBericht.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmBericht.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBerichtsperiodeVon,
            this.colDatumBis,
            this.colMahnung,
            this.colErstellung,
            this.colPassation1,
            this.colPassation2,
            this.colVersand});
            this.grvVmBericht.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmBericht.GridControl = this.grdVmBericht;
            this.grvVmBericht.Name = "grvVmBericht";
            this.grvVmBericht.OptionsBehavior.Editable = false;
            this.grvVmBericht.OptionsCustomization.AllowFilter = false;
            this.grvVmBericht.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmBericht.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmBericht.OptionsNavigation.UseTabKey = false;
            this.grvVmBericht.OptionsView.ColumnAutoWidth = false;
            this.grvVmBericht.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmBericht.OptionsView.ShowGroupPanel = false;
            this.grvVmBericht.OptionsView.ShowIndicator = false;
            // 
            // colBerichtsperiodeVon
            // 
            this.colBerichtsperiodeVon.Caption = "Periode von";
            this.colBerichtsperiodeVon.FieldName = "BerichtsperiodeVon";
            this.colBerichtsperiodeVon.Name = "colBerichtsperiodeVon";
            this.colBerichtsperiodeVon.Visible = true;
            this.colBerichtsperiodeVon.VisibleIndex = 0;
            this.colBerichtsperiodeVon.Width = 95;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Periode bis";
            this.colDatumBis.FieldName = "BerichtsperiodeBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            this.colDatumBis.Width = 95;
            // 
            // colMahnung
            // 
            this.colMahnung.Caption = "Mahnung";
            this.colMahnung.FieldName = "Mahnung";
            this.colMahnung.Name = "colMahnung";
            this.colMahnung.Visible = true;
            this.colMahnung.VisibleIndex = 2;
            this.colMahnung.Width = 95;
            // 
            // colErstellung
            // 
            this.colErstellung.Caption = "Eingang";
            this.colErstellung.FieldName = "Erstellung";
            this.colErstellung.Name = "colErstellung";
            this.colErstellung.Visible = true;
            this.colErstellung.VisibleIndex = 3;
            this.colErstellung.Width = 95;
            // 
            // colPassation1
            // 
            this.colPassation1.Caption = "erstinstanzlich";
            this.colPassation1.FieldName = "Passation1";
            this.colPassation1.Name = "colPassation1";
            this.colPassation1.Visible = true;
            this.colPassation1.VisibleIndex = 4;
            this.colPassation1.Width = 95;
            // 
            // colPassation2
            // 
            this.colPassation2.Caption = "oberinstanzlich";
            this.colPassation2.FieldName = "Passation2";
            this.colPassation2.Name = "colPassation2";
            this.colPassation2.Visible = true;
            this.colPassation2.VisibleIndex = 5;
            this.colPassation2.Width = 95;
            // 
            // colVersand
            // 
            this.colVersand.Caption = "Versand";
            this.colVersand.FieldName = "Versand";
            this.colVersand.Name = "colVersand";
            this.colVersand.Visible = true;
            this.colVersand.VisibleIndex = 6;
            this.colVersand.Width = 95;
            // 
            // lblBerichtsperiode
            // 
            this.lblBerichtsperiode.Location = new System.Drawing.Point(8, 377);
            this.lblBerichtsperiode.Name = "lblBerichtsperiode";
            this.lblBerichtsperiode.Size = new System.Drawing.Size(90, 24);
            this.lblBerichtsperiode.TabIndex = 23;
            this.lblBerichtsperiode.Text = "Berichtsperiode";
            // 
            // edtBerichtsperiodeVon
            // 
            this.edtBerichtsperiodeVon.DataMember = "BerichtsperiodeVon";
            this.edtBerichtsperiodeVon.DataSource = this.qryVmBericht;
            this.edtBerichtsperiodeVon.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtBerichtsperiodeVon.Location = new System.Drawing.Point(168, 380);
            this.edtBerichtsperiodeVon.Name = "edtBerichtsperiodeVon";
            this.edtBerichtsperiodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBerichtsperiodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBerichtsperiodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerichtsperiodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerichtsperiodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerichtsperiodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerichtsperiodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtBerichtsperiodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBerichtsperiodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBerichtsperiodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBerichtsperiodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBerichtsperiodeVon.Properties.ShowToday = false;
            this.edtBerichtsperiodeVon.Size = new System.Drawing.Size(89, 24);
            this.edtBerichtsperiodeVon.TabIndex = 1;
            this.edtBerichtsperiodeVon.EditValueChanged += new System.EventHandler(this.edtBerichtsperiodeVon_EditValueChanged);
            // 
            // edtBerichtsperiodeBis
            // 
            this.edtBerichtsperiodeBis.DataMember = "BerichtsperiodeBis";
            this.edtBerichtsperiodeBis.DataSource = this.qryVmBericht;
            this.edtBerichtsperiodeBis.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtBerichtsperiodeBis.Location = new System.Drawing.Point(279, 380);
            this.edtBerichtsperiodeBis.Name = "edtBerichtsperiodeBis";
            this.edtBerichtsperiodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBerichtsperiodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBerichtsperiodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerichtsperiodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerichtsperiodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerichtsperiodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerichtsperiodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtBerichtsperiodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBerichtsperiodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBerichtsperiodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBerichtsperiodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBerichtsperiodeBis.Properties.ShowToday = false;
            this.edtBerichtsperiodeBis.Size = new System.Drawing.Size(89, 24);
            this.edtBerichtsperiodeBis.TabIndex = 2;
            // 
            // lblPassation2
            // 
            this.lblPassation2.Location = new System.Drawing.Point(437, 410);
            this.lblPassation2.Name = "lblPassation2";
            this.lblPassation2.Size = new System.Drawing.Size(166, 24);
            this.lblPassation2.TabIndex = 30;
            this.lblPassation2.Text = "Genehmigung oberinstanzlich";
            // 
            // edtPassation2
            // 
            this.edtPassation2.DataMember = "Passation2";
            this.edtPassation2.DataSource = this.qryVmBericht;
            this.edtPassation2.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtPassation2.Location = new System.Drawing.Point(609, 410);
            this.edtPassation2.Name = "edtPassation2";
            this.edtPassation2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPassation2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPassation2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPassation2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPassation2.Properties.Appearance.Options.UseBackColor = true;
            this.edtPassation2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPassation2.Properties.Appearance.Options.UseFont = true;
            this.edtPassation2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtPassation2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPassation2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtPassation2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPassation2.Properties.ShowToday = false;
            this.edtPassation2.Size = new System.Drawing.Size(89, 24);
            this.edtPassation2.TabIndex = 6;
            // 
            // lblPassation1
            // 
            this.lblPassation1.Location = new System.Drawing.Point(437, 380);
            this.lblPassation1.Name = "lblPassation1";
            this.lblPassation1.Size = new System.Drawing.Size(166, 24);
            this.lblPassation1.TabIndex = 28;
            this.lblPassation1.Text = "Genehmigung erstinstanzlich";
            // 
            // edtPassation1
            // 
            this.edtPassation1.DataMember = "Passation1";
            this.edtPassation1.DataSource = this.qryVmBericht;
            this.edtPassation1.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtPassation1.Location = new System.Drawing.Point(609, 380);
            this.edtPassation1.Name = "edtPassation1";
            this.edtPassation1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPassation1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPassation1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPassation1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPassation1.Properties.Appearance.Options.UseBackColor = true;
            this.edtPassation1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPassation1.Properties.Appearance.Options.UseFont = true;
            this.edtPassation1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtPassation1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtPassation1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtPassation1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPassation1.Properties.ShowToday = false;
            this.edtPassation1.Size = new System.Drawing.Size(89, 24);
            this.edtPassation1.TabIndex = 5;
            // 
            // lblErstellung
            // 
            this.lblErstellung.Location = new System.Drawing.Point(8, 437);
            this.lblErstellung.Name = "lblErstellung";
            this.lblErstellung.Size = new System.Drawing.Size(92, 24);
            this.lblErstellung.TabIndex = 32;
            this.lblErstellung.Text = "Berichtseingang";
            // 
            // edtErstellung
            // 
            this.edtErstellung.DataMember = "Erstellung";
            this.edtErstellung.DataSource = this.qryVmBericht;
            this.edtErstellung.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtErstellung.Location = new System.Drawing.Point(168, 440);
            this.edtErstellung.Name = "edtErstellung";
            this.edtErstellung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstellung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErstellung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstellung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstellung.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstellung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstellung.Properties.Appearance.Options.UseFont = true;
            this.edtErstellung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtErstellung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstellung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtErstellung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstellung.Properties.ShowToday = false;
            this.edtErstellung.Size = new System.Drawing.Size(89, 24);
            this.edtErstellung.TabIndex = 4;
            // 
            // qryInfoMandant
            // 
            this.qryInfoMandant.HostControl = this;
            this.qryInfoMandant.SelectStatement = resources.GetString("qryInfoMandant.SelectStatement");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.kissLabel47);
            this.panel2.Controls.Add(this.kissLabel46);
            this.panel2.Controls.Add(this.kissLabel45);
            this.panel2.Controls.Add(this.kissLabel38);
            this.panel2.Controls.Add(this.kissLabel28);
            this.panel2.Controls.Add(this.kissLabel39);
            this.panel2.Controls.Add(this.kissLabel41);
            this.panel2.Controls.Add(this.kissLabel32);
            this.panel2.Controls.Add(this.kissLabel31);
            this.panel2.Controls.Add(this.kissLabel30);
            this.panel2.Controls.Add(this.kissLabel26);
            this.panel2.Controls.Add(this.kissLabel25);
            this.panel2.Controls.Add(this.kissLabel40);
            this.panel2.Controls.Add(this.kissLabel23);
            this.panel2.Controls.Add(this.kissLabel20);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(5, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 214);
            this.panel2.TabIndex = 656;
            // 
            // kissLabel47
            // 
            this.kissLabel47.DataMember = "MandantMutter";
            this.kissLabel47.DataSource = this.qryInfoMandant;
            this.kissLabel47.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel47.Location = new System.Drawing.Point(63, 177);
            this.kissLabel47.Name = "kissLabel47";
            this.kissLabel47.Size = new System.Drawing.Size(224, 32);
            this.kissLabel47.TabIndex = 667;
            // 
            // kissLabel46
            // 
            this.kissLabel46.DataMember = "MandantVater";
            this.kissLabel46.DataSource = this.qryInfoMandant;
            this.kissLabel46.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel46.Location = new System.Drawing.Point(63, 145);
            this.kissLabel46.Name = "kissLabel46";
            this.kissLabel46.Size = new System.Drawing.Size(224, 32);
            this.kissLabel46.TabIndex = 666;
            // 
            // kissLabel45
            // 
            this.kissLabel45.AutoSize = true;
            this.kissLabel45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel45.ForeColor = System.Drawing.Color.Black;
            this.kissLabel45.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel45.Location = new System.Drawing.Point(5, 179);
            this.kissLabel45.Name = "kissLabel45";
            this.kissLabel45.Size = new System.Drawing.Size(37, 13);
            this.kissLabel45.TabIndex = 665;
            this.kissLabel45.Text = "Mutter";
            // 
            // kissLabel38
            // 
            this.kissLabel38.AutoSize = true;
            this.kissLabel38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel38.ForeColor = System.Drawing.Color.Black;
            this.kissLabel38.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel38.Location = new System.Drawing.Point(5, 147);
            this.kissLabel38.Name = "kissLabel38";
            this.kissLabel38.Size = new System.Drawing.Size(32, 13);
            this.kissLabel38.TabIndex = 664;
            this.kissLabel38.Text = "Vater";
            // 
            // kissLabel28
            // 
            this.kissLabel28.AutoSize = true;
            this.kissLabel28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel28.ForeColor = System.Drawing.Color.Black;
            this.kissLabel28.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel28.Location = new System.Drawing.Point(5, 59);
            this.kissLabel28.Name = "kissLabel28";
            this.kissLabel28.Size = new System.Drawing.Size(46, 13);
            this.kissLabel28.TabIndex = 663;
            this.kissLabel28.Text = "PLZ/Ort";
            // 
            // kissLabel39
            // 
            this.kissLabel39.DataMember = "MandantHeimatort";
            this.kissLabel39.DataSource = this.qryInfoMandant;
            this.kissLabel39.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel39.Location = new System.Drawing.Point(63, 123);
            this.kissLabel39.Name = "kissLabel39";
            this.kissLabel39.Size = new System.Drawing.Size(188, 22);
            this.kissLabel39.TabIndex = 662;
            // 
            // kissLabel41
            // 
            this.kissLabel41.AutoSize = true;
            this.kissLabel41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel41.ForeColor = System.Drawing.Color.Black;
            this.kissLabel41.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel41.Location = new System.Drawing.Point(5, 125);
            this.kissLabel41.Name = "kissLabel41";
            this.kissLabel41.Size = new System.Drawing.Size(52, 13);
            this.kissLabel41.TabIndex = 661;
            this.kissLabel41.Text = "Heimatort";
            // 
            // kissLabel32
            // 
            this.kissLabel32.DataMember = "MandantOrt";
            this.kissLabel32.DataSource = this.qryInfoMandant;
            this.kissLabel32.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel32.Location = new System.Drawing.Point(63, 57);
            this.kissLabel32.Name = "kissLabel32";
            this.kissLabel32.Size = new System.Drawing.Size(224, 22);
            this.kissLabel32.TabIndex = 660;
            // 
            // kissLabel31
            // 
            this.kissLabel31.DataMember = "MandantGeburt";
            this.kissLabel31.DataSource = this.qryInfoMandant;
            this.kissLabel31.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel31.Location = new System.Drawing.Point(63, 79);
            this.kissLabel31.Name = "kissLabel31";
            this.kissLabel31.Size = new System.Drawing.Size(188, 22);
            this.kissLabel31.TabIndex = 659;
            // 
            // kissLabel30
            // 
            this.kissLabel30.DataMember = "MandantZivilstand";
            this.kissLabel30.DataSource = this.qryInfoMandant;
            this.kissLabel30.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel30.Location = new System.Drawing.Point(63, 101);
            this.kissLabel30.Name = "kissLabel30";
            this.kissLabel30.Size = new System.Drawing.Size(188, 22);
            this.kissLabel30.TabIndex = 658;
            // 
            // kissLabel26
            // 
            this.kissLabel26.DataMember = "MandantStrasse";
            this.kissLabel26.DataSource = this.qryInfoMandant;
            this.kissLabel26.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel26.Location = new System.Drawing.Point(63, 35);
            this.kissLabel26.Name = "kissLabel26";
            this.kissLabel26.Size = new System.Drawing.Size(225, 22);
            this.kissLabel26.TabIndex = 657;
            // 
            // kissLabel25
            // 
            this.kissLabel25.DataMember = "MandantName";
            this.kissLabel25.DataSource = this.qryInfoMandant;
            this.kissLabel25.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel25.Location = new System.Drawing.Point(63, 3);
            this.kissLabel25.Name = "kissLabel25";
            this.kissLabel25.Size = new System.Drawing.Size(224, 32);
            this.kissLabel25.TabIndex = 656;
            // 
            // kissLabel40
            // 
            this.kissLabel40.AutoSize = true;
            this.kissLabel40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel40.ForeColor = System.Drawing.Color.Black;
            this.kissLabel40.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel40.Location = new System.Drawing.Point(5, 37);
            this.kissLabel40.Name = "kissLabel40";
            this.kissLabel40.Size = new System.Drawing.Size(61, 13);
            this.kissLabel40.TabIndex = 655;
            this.kissLabel40.Text = "Strasse/Nr.";
            // 
            // kissLabel23
            // 
            this.kissLabel23.AutoSize = true;
            this.kissLabel23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel23.ForeColor = System.Drawing.Color.Black;
            this.kissLabel23.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel23.Location = new System.Drawing.Point(5, 81);
            this.kissLabel23.Name = "kissLabel23";
            this.kissLabel23.Size = new System.Drawing.Size(39, 13);
            this.kissLabel23.TabIndex = 654;
            this.kissLabel23.Text = "Geburt";
            // 
            // kissLabel20
            // 
            this.kissLabel20.AutoSize = true;
            this.kissLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel20.ForeColor = System.Drawing.Color.Black;
            this.kissLabel20.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel20.Location = new System.Drawing.Point(5, 103);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(52, 13);
            this.kissLabel20.TabIndex = 653;
            this.kissLabel20.Text = "Zivilstand";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.label9.Location = new System.Drawing.Point(5, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 652;
            this.label9.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.kissLabel9);
            this.panel1.Location = new System.Drawing.Point(5, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 19);
            this.panel1.TabIndex = 657;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel9.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel9.Location = new System.Drawing.Point(2, 1);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(145, 14);
            this.kissLabel9.TabIndex = 35;
            this.kissLabel9.Text = "Mandant/in";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.kissLabel29);
            this.panel3.Controls.Add(this.kissLabel27);
            this.panel3.Controls.Add(this.lblZGB);
            this.panel3.Controls.Add(this.kissLabel12);
            this.panel3.Controls.Add(this.kissLabel11);
            this.panel3.Controls.Add(this.kissLabel10);
            this.panel3.Location = new System.Drawing.Point(293, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 214);
            this.panel3.TabIndex = 658;
            // 
            // kissLabel29
            // 
            this.kissLabel29.DataMember = "DatumVon";
            this.kissLabel29.DataSource = this.qryInfoMassnahme;
            this.kissLabel29.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel29.Location = new System.Drawing.Point(50, 5);
            this.kissLabel29.Name = "kissLabel29";
            this.kissLabel29.Size = new System.Drawing.Size(96, 22);
            this.kissLabel29.TabIndex = 645;
            // 
            // qryInfoMassnahme
            // 
            this.qryInfoMassnahme.HostControl = this;
            // 
            // kissLabel27
            // 
            this.kissLabel27.DataMember = "DatumBis";
            this.kissLabel27.DataSource = this.qryInfoMassnahme;
            this.kissLabel27.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel27.Location = new System.Drawing.Point(49, 25);
            this.kissLabel27.Name = "kissLabel27";
            this.kissLabel27.Size = new System.Drawing.Size(100, 22);
            this.kissLabel27.TabIndex = 644;
            // 
            // lblZGB
            // 
            this.lblZGB.DataSource = this.qryInfoMassnahme;
            this.lblZGB.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblZGB.Location = new System.Drawing.Point(49, 45);
            this.lblZGB.Name = "lblZGB";
            this.lblZGB.Size = new System.Drawing.Size(118, 88);
            this.lblZGB.TabIndex = 643;
            this.lblZGB.Text = "ZGB";
            // 
            // kissLabel12
            // 
            this.kissLabel12.AutoSize = true;
            this.kissLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel12.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel12.Location = new System.Drawing.Point(5, 27);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(20, 13);
            this.kissLabel12.TabIndex = 642;
            this.kissLabel12.Text = "bis";
            // 
            // kissLabel11
            // 
            this.kissLabel11.AutoSize = true;
            this.kissLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel11.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel11.Location = new System.Drawing.Point(5, 47);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(43, 13);
            this.kissLabel11.TabIndex = 641;
            this.kissLabel11.Text = "gemäss";
            // 
            // kissLabel10
            // 
            this.kissLabel10.AutoSize = true;
            this.kissLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel10.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel10.Location = new System.Drawing.Point(5, 7);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(25, 13);
            this.kissLabel10.TabIndex = 640;
            this.kissLabel10.Text = "von";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.kissLabel14);
            this.panel4.Controls.Add(this.kissLabel15);
            this.panel4.Controls.Add(this.kissLabel8);
            this.panel4.Controls.Add(this.kissLabel13);
            this.panel4.Controls.Add(this.editPrivat);
            this.panel4.Controls.Add(this.kissLabel42);
            this.panel4.Controls.Add(this.kissLabel43);
            this.panel4.Controls.Add(this.kissLabel37);
            this.panel4.Controls.Add(this.kissLabel36);
            this.panel4.Controls.Add(this.kissLabel35);
            this.panel4.Controls.Add(this.kissLabel34);
            this.panel4.Controls.Add(this.kissLabel33);
            this.panel4.Controls.Add(this.kissLabel19);
            this.panel4.Controls.Add(this.kissLabel22);
            this.panel4.Controls.Add(this.kissLabel21);
            this.panel4.Controls.Add(this.kissLabel18);
            this.panel4.Controls.Add(this.kissLabel16);
            this.panel4.Location = new System.Drawing.Point(447, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 214);
            this.panel4.TabIndex = 659;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel14.DataMember = "MTOrt";
            this.kissLabel14.DataSource = this.qryInfoMt;
            this.kissLabel14.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel14.Location = new System.Drawing.Point(65, 57);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(174, 22);
            this.kissLabel14.TabIndex = 671;
            // 
            // qryInfoMt
            // 
            this.qryInfoMt.HostControl = this;
            this.qryInfoMt.SelectStatement = resources.GetString("qryInfoMt.SelectStatement");
            // 
            // kissLabel15
            // 
            this.kissLabel15.AutoSize = true;
            this.kissLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel15.ForeColor = System.Drawing.Color.Black;
            this.kissLabel15.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel15.Location = new System.Drawing.Point(5, 59);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(46, 13);
            this.kissLabel15.TabIndex = 670;
            this.kissLabel15.Text = "PLZ/Ort";
            // 
            // kissLabel8
            // 
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel8.DataMember = "MTStrasse";
            this.kissLabel8.DataSource = this.qryInfoMt;
            this.kissLabel8.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel8.Location = new System.Drawing.Point(65, 35);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(174, 22);
            this.kissLabel8.TabIndex = 669;
            // 
            // kissLabel13
            // 
            this.kissLabel13.AutoSize = true;
            this.kissLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel13.ForeColor = System.Drawing.Color.Black;
            this.kissLabel13.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel13.Location = new System.Drawing.Point(5, 37);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(61, 13);
            this.kissLabel13.TabIndex = 668;
            this.kissLabel13.Text = "Strasse/Nr.";
            // 
            // editPrivat
            // 
            this.editPrivat.DataMember = "MTPrivat";
            this.editPrivat.DataSource = this.qryInfoMt;
            this.editPrivat.Location = new System.Drawing.Point(186, 167);
            this.editPrivat.Name = "editPrivat";
            this.editPrivat.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.editPrivat.Properties.Appearance.Options.UseBackColor = true;
            this.editPrivat.Properties.Caption = "privat";
            this.editPrivat.Size = new System.Drawing.Size(53, 19);
            this.editPrivat.TabIndex = 667;
            // 
            // kissLabel42
            // 
            this.kissLabel42.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel42.DataMember = "MTTelefonP";
            this.kissLabel42.DataSource = this.qryInfoMt;
            this.kissLabel42.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel42.Location = new System.Drawing.Point(65, 101);
            this.kissLabel42.Name = "kissLabel42";
            this.kissLabel42.Size = new System.Drawing.Size(174, 22);
            this.kissLabel42.TabIndex = 666;
            // 
            // kissLabel43
            // 
            this.kissLabel43.AutoSize = true;
            this.kissLabel43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel43.ForeColor = System.Drawing.Color.Black;
            this.kissLabel43.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel43.Location = new System.Drawing.Point(5, 103);
            this.kissLabel43.Name = "kissLabel43";
            this.kissLabel43.Size = new System.Drawing.Size(53, 13);
            this.kissLabel43.TabIndex = 665;
            this.kissLabel43.Text = "Telefon P";
            // 
            // kissLabel37
            // 
            this.kissLabel37.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel37.DataMember = "MTName";
            this.kissLabel37.DataSource = this.qryInfoMt;
            this.kissLabel37.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel37.Location = new System.Drawing.Point(65, 3);
            this.kissLabel37.Name = "kissLabel37";
            this.kissLabel37.Size = new System.Drawing.Size(174, 32);
            this.kissLabel37.TabIndex = 664;
            // 
            // kissLabel36
            // 
            this.kissLabel36.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel36.DataMember = "MTTelefonG";
            this.kissLabel36.DataSource = this.qryInfoMt;
            this.kissLabel36.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel36.Location = new System.Drawing.Point(65, 79);
            this.kissLabel36.Name = "kissLabel36";
            this.kissLabel36.Size = new System.Drawing.Size(174, 22);
            this.kissLabel36.TabIndex = 663;
            // 
            // kissLabel35
            // 
            this.kissLabel35.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel35.DataMember = "MTNatel";
            this.kissLabel35.DataSource = this.qryInfoMt;
            this.kissLabel35.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel35.Location = new System.Drawing.Point(65, 123);
            this.kissLabel35.Name = "kissLabel35";
            this.kissLabel35.Size = new System.Drawing.Size(174, 22);
            this.kissLabel35.TabIndex = 662;
            // 
            // kissLabel34
            // 
            this.kissLabel34.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel34.DataMember = "MTEMail";
            this.kissLabel34.DataSource = this.qryInfoMt;
            this.kissLabel34.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel34.Location = new System.Drawing.Point(65, 145);
            this.kissLabel34.Name = "kissLabel34";
            this.kissLabel34.Size = new System.Drawing.Size(174, 22);
            this.kissLabel34.TabIndex = 661;
            // 
            // kissLabel33
            // 
            this.kissLabel33.DataMember = "MTErnennung";
            this.kissLabel33.DataSource = this.qryInfoMt;
            this.kissLabel33.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel33.Location = new System.Drawing.Point(65, 167);
            this.kissLabel33.Name = "kissLabel33";
            this.kissLabel33.Size = new System.Drawing.Size(84, 22);
            this.kissLabel33.TabIndex = 660;
            // 
            // kissLabel19
            // 
            this.kissLabel19.AutoSize = true;
            this.kissLabel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel19.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel19.Location = new System.Drawing.Point(5, 169);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(59, 13);
            this.kissLabel19.TabIndex = 659;
            this.kissLabel19.Text = "Ernennung";
            // 
            // kissLabel22
            // 
            this.kissLabel22.AutoSize = true;
            this.kissLabel22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel22.ForeColor = System.Drawing.Color.Black;
            this.kissLabel22.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel22.Location = new System.Drawing.Point(5, 147);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(36, 13);
            this.kissLabel22.TabIndex = 658;
            this.kissLabel22.Text = "E-Mail";
            // 
            // kissLabel21
            // 
            this.kissLabel21.AutoSize = true;
            this.kissLabel21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel21.ForeColor = System.Drawing.Color.Black;
            this.kissLabel21.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel21.Location = new System.Drawing.Point(5, 125);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(32, 13);
            this.kissLabel21.TabIndex = 657;
            this.kissLabel21.Text = "Natel";
            // 
            // kissLabel18
            // 
            this.kissLabel18.AutoSize = true;
            this.kissLabel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel18.ForeColor = System.Drawing.Color.Black;
            this.kissLabel18.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel18.Location = new System.Drawing.Point(5, 81);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(54, 13);
            this.kissLabel18.TabIndex = 656;
            this.kissLabel18.Text = "Telefon G";
            // 
            // kissLabel16
            // 
            this.kissLabel16.AutoSize = true;
            this.kissLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel16.ForeColor = System.Drawing.Color.Black;
            this.kissLabel16.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel16.Location = new System.Drawing.Point(5, 7);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(35, 13);
            this.kissLabel16.TabIndex = 655;
            this.kissLabel16.Text = "Name";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Tan;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.kissLabel24);
            this.panel5.Location = new System.Drawing.Point(293, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(155, 19);
            this.panel5.TabIndex = 660;
            // 
            // kissLabel24
            // 
            this.kissLabel24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel24.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel24.Location = new System.Drawing.Point(2, 1);
            this.kissLabel24.Name = "kissLabel24";
            this.kissLabel24.Size = new System.Drawing.Size(108, 14);
            this.kissLabel24.TabIndex = 35;
            this.kissLabel24.Text = "Massnahme";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Tan;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.kissLabel44);
            this.panel6.Location = new System.Drawing.Point(447, 37);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(252, 19);
            this.panel6.TabIndex = 661;
            // 
            // kissLabel44
            // 
            this.kissLabel44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel44.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel44.Location = new System.Drawing.Point(2, 1);
            this.kissLabel44.Name = "kissLabel44";
            this.kissLabel44.Size = new System.Drawing.Size(156, 14);
            this.kissLabel44.TabIndex = 35;
            this.kissLabel44.Text = "Mandatsträger/in";
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(263, 381);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(8, 24);
            this.kissLabel1.TabIndex = 3;
            this.kissLabel1.Text = "-";
            // 
            // lblMahnung
            // 
            this.lblMahnung.Location = new System.Drawing.Point(8, 407);
            this.lblMahnung.Name = "lblMahnung";
            this.lblMahnung.Size = new System.Drawing.Size(76, 24);
            this.lblMahnung.TabIndex = 665;
            this.lblMahnung.Text = "Mahnung";
            // 
            // edtVersand
            // 
            this.edtVersand.DataMember = "Versand";
            this.edtVersand.DataSource = this.qryVmBericht;
            this.edtVersand.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtVersand.Location = new System.Drawing.Point(609, 440);
            this.edtVersand.Name = "edtVersand";
            this.edtVersand.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersand.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersand.Properties.Appearance.Options.UseFont = true;
            this.edtVersand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVersand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVersand.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVersand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersand.Properties.ShowToday = false;
            this.edtVersand.Size = new System.Drawing.Size(89, 24);
            this.edtVersand.TabIndex = 7;
            // 
            // edtMahnung
            // 
            this.edtMahnung.DataMember = "Mahnung";
            this.edtMahnung.DataSource = this.qryVmBericht;
            this.edtMahnung.EditValue = new System.DateTime(2004, 6, 6, 0, 0, 0, 0);
            this.edtMahnung.Location = new System.Drawing.Point(168, 410);
            this.edtMahnung.Name = "edtMahnung";
            this.edtMahnung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMahnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMahnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMahnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMahnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtMahnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMahnung.Properties.Appearance.Options.UseFont = true;
            this.edtMahnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMahnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtMahnung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMahnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMahnung.Properties.ShowToday = false;
            this.edtMahnung.Size = new System.Drawing.Size(89, 24);
            this.edtMahnung.TabIndex = 3;
            // 
            // lblVersand
            // 
            this.lblVersand.Location = new System.Drawing.Point(437, 440);
            this.lblVersand.Name = "lblVersand";
            this.lblVersand.Size = new System.Drawing.Size(166, 24);
            this.lblVersand.TabIndex = 668;
            this.lblVersand.Text = "Versand";
            // 
            // lblEntschaedigung
            // 
            this.lblEntschaedigung.Location = new System.Drawing.Point(8, 470);
            this.lblEntschaedigung.Name = "lblEntschaedigung";
            this.lblEntschaedigung.Size = new System.Drawing.Size(143, 24);
            this.lblEntschaedigung.TabIndex = 675;
            this.lblEntschaedigung.Text = "Vereinbarte Entschädigung";
            // 
            // edtEntschaedigung
            // 
            this.edtEntschaedigung.DataSource = this.qryVmBericht;
            this.edtEntschaedigung.Location = new System.Drawing.Point(168, 470);
            this.edtEntschaedigung.Name = "edtEntschaedigung";
            this.edtEntschaedigung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEntschaedigung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEntschaedigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEntschaedigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEntschaedigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtEntschaedigung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEntschaedigung.Properties.Appearance.Options.UseFont = true;
            this.edtEntschaedigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEntschaedigung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEntschaedigung.Properties.DisplayFormat.FormatString = "n2";
            this.edtEntschaedigung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtEntschaedigung.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtEntschaedigung.Size = new System.Drawing.Size(89, 24);
            this.edtEntschaedigung.TabIndex = 674;
            // 
            // CtlVmRevisionen
            // 
            this.ActiveSQLQuery = this.qryVmBericht;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(690, 530);
            
            this.Controls.Add(this.lblEntschaedigung);
            this.Controls.Add(this.edtEntschaedigung);
            this.Controls.Add(this.lblVersand);
            this.Controls.Add(this.edtMahnung);
            this.Controls.Add(this.edtVersand);
            this.Controls.Add(this.lblMahnung);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.grdVmBericht);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblErstellung);
            this.Controls.Add(this.edtErstellung);
            this.Controls.Add(this.lblPassation2);
            this.Controls.Add(this.edtPassation2);
            this.Controls.Add(this.lblPassation1);
            this.Controls.Add(this.edtPassation1);
            this.Controls.Add(this.edtBerichtsperiodeBis);
            this.Controls.Add(this.lblBerichtsperiode);
            this.Controls.Add(this.edtBerichtsperiodeVon);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblBemerkung);
            this.Name = "CtlVmRevisionen";
            this.Size = new System.Drawing.Size(707, 540);
            this.Load += new System.EventHandler(this.CtlVmRevisionen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmBericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerichtsperiode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerichtsperiodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassation2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassation2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPassation1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfoMandant)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfoMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfoMt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPrivat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel24)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMahnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMahnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEntschaedigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEntschaedigung.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtsperiodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellung;
        private DevExpress.XtraGrid.Columns.GridColumn colMahnung;
        private DevExpress.XtraGrid.Columns.GridColumn colPassation1;
        private DevExpress.XtraGrid.Columns.GridColumn colPassation2;
        private DevExpress.XtraGrid.Columns.GridColumn colVersand;
        private KiSS4.Gui.KissCheckEdit editPrivat;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtBerichtsperiodeBis;
        private KiSS4.Gui.KissDateEdit edtBerichtsperiodeVon;
        private KiSS4.Gui.KissCalcEdit edtEntschaedigung;
        private KiSS4.Gui.KissDateEdit edtErstellung;
        private KiSS4.Gui.KissDateEdit edtMahnung;
        private KiSS4.Gui.KissDateEdit edtPassation1;
        private KiSS4.Gui.KissDateEdit edtPassation2;
        private KiSS4.Gui.KissDateEdit edtVersand;
        private KiSS4.Gui.KissGrid grdVmBericht;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmBericht;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissLabel kissLabel23;
        private KiSS4.Gui.KissLabel kissLabel24;
        private KiSS4.Gui.KissLabel kissLabel25;
        private KiSS4.Gui.KissLabel kissLabel26;
        private KiSS4.Gui.KissLabel kissLabel27;
        private KiSS4.Gui.KissLabel kissLabel28;
        private KiSS4.Gui.KissLabel kissLabel29;
        private KiSS4.Gui.KissLabel kissLabel30;
        private KiSS4.Gui.KissLabel kissLabel31;
        private KiSS4.Gui.KissLabel kissLabel32;
        private KiSS4.Gui.KissLabel kissLabel33;
        private KiSS4.Gui.KissLabel kissLabel34;
        private KiSS4.Gui.KissLabel kissLabel35;
        private KiSS4.Gui.KissLabel kissLabel36;
        private KiSS4.Gui.KissLabel kissLabel37;
        private KiSS4.Gui.KissLabel kissLabel38;
        private KiSS4.Gui.KissLabel kissLabel39;
        private KiSS4.Gui.KissLabel kissLabel40;
        private KiSS4.Gui.KissLabel kissLabel41;
        private KiSS4.Gui.KissLabel kissLabel42;
        private KiSS4.Gui.KissLabel kissLabel43;
        private KiSS4.Gui.KissLabel kissLabel44;
        private KiSS4.Gui.KissLabel kissLabel45;
        private KiSS4.Gui.KissLabel kissLabel46;
        private KiSS4.Gui.KissLabel kissLabel47;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel label9;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBerichtsperiode;
        private KiSS4.Gui.KissLabel lblEntschaedigung;
        private KiSS4.Gui.KissLabel lblErstellung;
        private KiSS4.Gui.KissLabel lblMahnung;
        private KiSS4.Gui.KissLabel lblPassation1;
        private KiSS4.Gui.KissLabel lblPassation2;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblVersand;
        private KiSS4.Gui.KissLabel lblZGB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryInfoMandant;
        private KiSS4.DB.SqlQuery qryInfoMassnahme;
        private KiSS4.DB.SqlQuery qryInfoMt;
        private KiSS4.DB.SqlQuery qryVmBericht;
    }
}
