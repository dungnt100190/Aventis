﻿namespace KiSS4.Asyl
{
    partial class CtlAyPersonen
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
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryHeader = new KiSS4.DB.SqlQuery(this.components);
            this.qryKlientensystem = new KiSS4.DB.SqlQuery(this.components);
            this.fraAnspechperson = new KiSS4.Gui.KissGroupBox();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.fraKennzahlen = new KiSS4.Gui.KissGroupBox();
            this.kissLabel22 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.lblUeGrundbedarf = new KiSS4.Gui.KissLabel();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.lblHgGrundbedarf = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblFinanzplan = new KiSS4.Gui.KissLabel();
            this.lblKlientensystem = new KiSS4.Gui.KissLabel();
            this.lblInfo2 = new KiSS4.Gui.KissLabel();
            this.lblInfo1 = new KiSS4.Gui.KissLabel();
            this.grdHaushalt = new KiSS4.Gui.KissGrid();
            this.qryHaushalt = new KiSS4.DB.SqlQuery(this.components);
            this.grvHaushalt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonName_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung_Remove = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKlientensystem = new KiSS4.Gui.KissGrid();
            this.grvKlientensystem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonName_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung_Add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKlientensystem)).BeginInit();
            this.fraAnspechperson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            this.fraKennzahlen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHaushalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientensystem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.DataMember = "Titel";
            this.lblTitel.DataSource = this.qryHeader;
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            // 
            // qryHeader
            // 
            this.qryHeader.HostControl = this;
            // 
            // qryKlientensystem
            // 
            this.qryKlientensystem.HostControl = this;
            // 
            // fraAnspechperson
            // 
            this.fraAnspechperson.Controls.Add(this.kissLabel10);
            this.fraAnspechperson.Controls.Add(this.kissLabel9);
            this.fraAnspechperson.Controls.Add(this.kissLabel8);
            this.fraAnspechperson.Controls.Add(this.kissLabel5);
            this.fraAnspechperson.Controls.Add(this.lblGeburtsdatum);
            this.fraAnspechperson.Controls.Add(this.lblHeimatort);
            this.fraAnspechperson.Controls.Add(this.lblAdresse);
            this.fraAnspechperson.Controls.Add(this.lblName);
            this.fraAnspechperson.Controls.Add(this.kissLabel2);
            this.fraAnspechperson.Location = new System.Drawing.Point(7, 35);
            this.fraAnspechperson.Name = "fraAnspechperson";
            this.fraAnspechperson.Size = new System.Drawing.Size(359, 112);
            this.fraAnspechperson.TabIndex = 1;
            this.fraAnspechperson.TabStop = false;
            this.fraAnspechperson.Text = "Ansprechperson für dieses Masterbudget";
            // 
            // kissLabel10
            // 
            this.kissLabel10.DataMember = "Nationalitaet";
            this.kissLabel10.DataSource = this.qryHeader;
            this.kissLabel10.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel10.Location = new System.Drawing.Point(88, 88);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(200, 16);
            this.kissLabel10.TabIndex = 8;
            // 
            // kissLabel9
            // 
            this.kissLabel9.DataMember = "Geburtsdatum";
            this.kissLabel9.DataSource = this.qryHeader;
            this.kissLabel9.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel9.Location = new System.Drawing.Point(88, 72);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(200, 16);
            this.kissLabel9.TabIndex = 6;
            // 
            // kissLabel8
            // 
            this.kissLabel8.DataMember = "Ort";
            this.kissLabel8.DataSource = this.qryHeader;
            this.kissLabel8.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel8.Location = new System.Drawing.Point(88, 48);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(200, 16);
            this.kissLabel8.TabIndex = 4;
            // 
            // kissLabel5
            // 
            this.kissLabel5.DataMember = "Adresse";
            this.kissLabel5.DataSource = this.qryHeader;
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel5.Location = new System.Drawing.Point(88, 32);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(200, 16);
            this.kissLabel5.TabIndex = 3;
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblGeburtsdatum.Location = new System.Drawing.Point(8, 72);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(75, 16);
            this.lblGeburtsdatum.TabIndex = 5;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            // 
            // lblHeimatort
            // 
            this.lblHeimatort.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHeimatort.Location = new System.Drawing.Point(8, 88);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(75, 16);
            this.lblHeimatort.TabIndex = 7;
            this.lblHeimatort.Text = "Nationalität";
            // 
            // lblAdresse
            // 
            this.lblAdresse.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAdresse.Location = new System.Drawing.Point(8, 32);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(75, 16);
            this.lblAdresse.TabIndex = 2;
            this.lblAdresse.Text = "Adresse";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblName.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblName.Location = new System.Drawing.Point(8, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kissLabel2
            // 
            this.kissLabel2.DataMember = "NameVorname";
            this.kissLabel2.DataSource = this.qryHeader;
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel2.Location = new System.Drawing.Point(88, 16);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(200, 16);
            this.kissLabel2.TabIndex = 1;
            // 
            // fraKennzahlen
            // 
            this.fraKennzahlen.Controls.Add(this.kissLabel22);
            this.fraKennzahlen.Controls.Add(this.kissLabel21);
            this.fraKennzahlen.Controls.Add(this.lblUeGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.kissLabel18);
            this.fraKennzahlen.Controls.Add(this.lblHgGrundbedarf);
            this.fraKennzahlen.Controls.Add(this.kissLabel14);
            this.fraKennzahlen.Location = new System.Drawing.Point(363, 35);
            this.fraKennzahlen.Name = "fraKennzahlen";
            this.fraKennzahlen.Size = new System.Drawing.Size(352, 112);
            this.fraKennzahlen.TabIndex = 2;
            this.fraKennzahlen.TabStop = false;
            this.fraKennzahlen.Text = "Kennzahlen";
            // 
            // kissLabel22
            // 
            this.kissLabel22.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel22.Location = new System.Drawing.Point(184, 24);
            this.kissLabel22.Name = "kissLabel22";
            this.kissLabel22.Size = new System.Drawing.Size(152, 16);
            this.kissLabel22.TabIndex = 5;
            this.kissLabel22.Text = "Unterstützungseinheit";
            // 
            // kissLabel21
            // 
            this.kissLabel21.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel21.Location = new System.Drawing.Point(8, 24);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(120, 16);
            this.kissLabel21.TabIndex = 0;
            this.kissLabel21.Text = "Haushaltsgrösse";
            // 
            // lblUeGrundbedarf
            // 
            this.lblUeGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblUeGrundbedarf.Location = new System.Drawing.Point(184, 40);
            this.lblUeGrundbedarf.Name = "lblUeGrundbedarf";
            this.lblUeGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblUeGrundbedarf.TabIndex = 6;
            this.lblUeGrundbedarf.Text = "Grundbedarf";
            // 
            // kissLabel18
            // 
            this.kissLabel18.DataMember = "UeGrundbedarf";
            this.kissLabel18.DataSource = this.qryHeader;
            this.kissLabel18.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel18.Location = new System.Drawing.Point(256, 40);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(24, 16);
            this.kissLabel18.TabIndex = 7;
            // 
            // lblHgGrundbedarf
            // 
            this.lblHgGrundbedarf.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHgGrundbedarf.Location = new System.Drawing.Point(8, 40);
            this.lblHgGrundbedarf.Name = "lblHgGrundbedarf";
            this.lblHgGrundbedarf.Size = new System.Drawing.Size(72, 16);
            this.lblHgGrundbedarf.TabIndex = 1;
            this.lblHgGrundbedarf.Text = "Grundbedarf";
            // 
            // kissLabel14
            // 
            this.kissLabel14.DataMember = "HgGrundbedarf";
            this.kissLabel14.DataSource = this.qryHeader;
            this.kissLabel14.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel14.Location = new System.Drawing.Point(80, 40);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(24, 16);
            this.kissLabel14.TabIndex = 2;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            // 
            // lblFinanzplan
            // 
            this.lblFinanzplan.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblFinanzplan.Location = new System.Drawing.Point(380, 202);
            this.lblFinanzplan.Name = "lblFinanzplan";
            this.lblFinanzplan.Size = new System.Drawing.Size(328, 16);
            this.lblFinanzplan.TabIndex = 68;
            this.lblFinanzplan.Text = "Personen im Unterstützungplan (Haushaltsgrösse)";
            // 
            // lblKlientensystem
            // 
            this.lblKlientensystem.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblKlientensystem.Location = new System.Drawing.Point(7, 202);
            this.lblKlientensystem.Name = "lblKlientensystem";
            this.lblKlientensystem.Size = new System.Drawing.Size(328, 16);
            this.lblKlientensystem.TabIndex = 67;
            this.lblKlientensystem.Text = "Personen im Klientensystem";
            // 
            // lblInfo2
            // 
            this.lblInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInfo2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInfo2.Location = new System.Drawing.Point(8, 432);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(720, 16);
            this.lblInfo2.TabIndex = 66;
            this.lblInfo2.Text = "Tip: Die Altersangabe in der rechten Liste bezieht sich auf den Beginn des Unters" +
                "tützungsplanes, nicht auf das aktuelle Datum.";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInfo1.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInfo1.Location = new System.Drawing.Point(7, 165);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(720, 32);
            this.lblInfo1.TabIndex = 65;
            this.lblInfo1.Text = "Alle Personen aus dem Klientensystem, welche in diesem Unterstützungsplan im Haus" +
                "halt leben und/oder in der Unterstützungseinheit sind, müssen in das rechte Fens" +
                "ter gesetzt werden.";
            // 
            // grdHaushalt
            // 
            this.grdHaushalt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdHaushalt.DataSource = this.qryHaushalt;
            // 
            // 
            // 
            this.grdHaushalt.EmbeddedNavigator.Name = "";
            this.grdHaushalt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdHaushalt.Location = new System.Drawing.Point(380, 223);
            this.grdHaushalt.MainView = this.grvHaushalt;
            this.grdHaushalt.Name = "grdHaushalt";
            this.grdHaushalt.Size = new System.Drawing.Size(335, 193);
            this.grdHaushalt.TabIndex = 64;
            this.grdHaushalt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHaushalt});
            this.grdHaushalt.DoubleClick += new System.EventHandler(this.grdHaushalt_DoubleClick);
            // 
            // qryHaushalt
            // 
            this.qryHaushalt.HostControl = this;
            // 
            // grvHaushalt
            // 
            this.grvHaushalt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvHaushalt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.Empty.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.Empty.Options.UseFont = true;
            this.grvHaushalt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.EvenRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHaushalt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvHaushalt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvHaushalt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHaushalt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvHaushalt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHaushalt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHaushalt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHaushalt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHaushalt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.GroupRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvHaushalt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvHaushalt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHaushalt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvHaushalt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvHaushalt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvHaushalt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHaushalt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvHaushalt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvHaushalt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.OddRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvHaushalt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.Row.Options.UseBackColor = true;
            this.grvHaushalt.Appearance.Row.Options.UseFont = true;
            this.grvHaushalt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHaushalt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvHaushalt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvHaushalt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvHaushalt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvHaushalt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonName_Remove,
            this.colGeburtsdatum_Remove,
            this.colAlter_Remove,
            this.colBeziehung_Remove});
            this.grvHaushalt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvHaushalt.GridControl = this.grdHaushalt;
            this.grvHaushalt.Name = "grvHaushalt";
            this.grvHaushalt.OptionsBehavior.Editable = false;
            this.grvHaushalt.OptionsCustomization.AllowFilter = false;
            this.grvHaushalt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvHaushalt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvHaushalt.OptionsNavigation.UseTabKey = false;
            this.grvHaushalt.OptionsView.ColumnAutoWidth = false;
            this.grvHaushalt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvHaushalt.OptionsView.ShowGroupPanel = false;
            this.grvHaushalt.OptionsView.ShowIndicator = false;
            // 
            // colPersonName_Remove
            // 
            this.colPersonName_Remove.Caption = "Name";
            this.colPersonName_Remove.FieldName = "NameVorname";
            this.colPersonName_Remove.Name = "colPersonName_Remove";
            this.colPersonName_Remove.Visible = true;
            this.colPersonName_Remove.VisibleIndex = 0;
            this.colPersonName_Remove.Width = 135;
            // 
            // colGeburtsdatum_Remove
            // 
            this.colGeburtsdatum_Remove.Caption = "Geb. dat.";
            this.colGeburtsdatum_Remove.FieldName = "Geburtsdatum";
            this.colGeburtsdatum_Remove.Name = "colGeburtsdatum_Remove";
            this.colGeburtsdatum_Remove.Visible = true;
            this.colGeburtsdatum_Remove.VisibleIndex = 1;
            this.colGeburtsdatum_Remove.Width = 70;
            // 
            // colAlter_Remove
            // 
            this.colAlter_Remove.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter_Remove.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAlter_Remove.Caption = "Alter";
            this.colAlter_Remove.FieldName = "Alter";
            this.colAlter_Remove.Name = "colAlter_Remove";
            this.colAlter_Remove.Visible = true;
            this.colAlter_Remove.VisibleIndex = 2;
            this.colAlter_Remove.Width = 40;
            // 
            // colBeziehung_Remove
            // 
            this.colBeziehung_Remove.Caption = "Beziehung";
            this.colBeziehung_Remove.FieldName = "Beziehung";
            this.colBeziehung_Remove.Name = "colBeziehung_Remove";
            this.colBeziehung_Remove.Visible = true;
            this.colBeziehung_Remove.VisibleIndex = 3;
            this.colBeziehung_Remove.Width = 83;
            // 
            // grdKlientensystem
            // 
            this.grdKlientensystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdKlientensystem.DataSource = this.qryKlientensystem;
            // 
            // 
            // 
            this.grdKlientensystem.EmbeddedNavigator.Name = "";
            this.grdKlientensystem.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKlientensystem.Location = new System.Drawing.Point(7, 223);
            this.grdKlientensystem.MainView = this.grvKlientensystem;
            this.grdKlientensystem.Name = "grdKlientensystem";
            this.grdKlientensystem.Size = new System.Drawing.Size(335, 193);
            this.grdKlientensystem.TabIndex = 57;
            this.grdKlientensystem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKlientensystem});
            this.grdKlientensystem.DoubleClick += new System.EventHandler(this.grdKlientensystem_DoubleClick);
            // 
            // grvKlientensystem
            // 
            this.grvKlientensystem.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKlientensystem.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.Empty.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.Empty.Options.UseFont = true;
            this.grvKlientensystem.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.EvenRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKlientensystem.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKlientensystem.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKlientensystem.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKlientensystem.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKlientensystem.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientensystem.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKlientensystem.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientensystem.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientensystem.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.GroupRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKlientensystem.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKlientensystem.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKlientensystem.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKlientensystem.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKlientensystem.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKlientensystem.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKlientensystem.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKlientensystem.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKlientensystem.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.OddRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKlientensystem.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.Row.Options.UseBackColor = true;
            this.grvKlientensystem.Appearance.Row.Options.UseFont = true;
            this.grvKlientensystem.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKlientensystem.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKlientensystem.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKlientensystem.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKlientensystem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKlientensystem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonName_Add,
            this.colGeburtstag_Add,
            this.colAlter_Add,
            this.colBeziehung_Add});
            this.grvKlientensystem.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKlientensystem.GridControl = this.grdKlientensystem;
            this.grvKlientensystem.Name = "grvKlientensystem";
            this.grvKlientensystem.OptionsBehavior.Editable = false;
            this.grvKlientensystem.OptionsCustomization.AllowFilter = false;
            this.grvKlientensystem.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKlientensystem.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKlientensystem.OptionsNavigation.UseTabKey = false;
            this.grvKlientensystem.OptionsView.ColumnAutoWidth = false;
            this.grvKlientensystem.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKlientensystem.OptionsView.ShowGroupPanel = false;
            this.grvKlientensystem.OptionsView.ShowIndicator = false;
            // 
            // colPersonName_Add
            // 
            this.colPersonName_Add.Caption = "Name";
            this.colPersonName_Add.FieldName = "NameVorname";
            this.colPersonName_Add.Name = "colPersonName_Add";
            this.colPersonName_Add.Visible = true;
            this.colPersonName_Add.VisibleIndex = 0;
            this.colPersonName_Add.Width = 135;
            // 
            // colGeburtstag_Add
            // 
            this.colGeburtstag_Add.Caption = "Geb. dat.";
            this.colGeburtstag_Add.FieldName = "Geburtsdatum";
            this.colGeburtstag_Add.Name = "colGeburtstag_Add";
            this.colGeburtstag_Add.Visible = true;
            this.colGeburtstag_Add.VisibleIndex = 1;
            this.colGeburtstag_Add.Width = 70;
            // 
            // colAlter_Add
            // 
            this.colAlter_Add.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter_Add.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAlter_Add.Caption = "Alter";
            this.colAlter_Add.FieldName = "Alter";
            this.colAlter_Add.Name = "colAlter_Add";
            this.colAlter_Add.Visible = true;
            this.colAlter_Add.VisibleIndex = 2;
            this.colAlter_Add.Width = 40;
            // 
            // colBeziehung_Add
            // 
            this.colBeziehung_Add.Caption = "Beziehung";
            this.colBeziehung_Add.FieldName = "Beziehung";
            this.colBeziehung_Add.Name = "colBeziehung_Add";
            this.colBeziehung_Add.Visible = true;
            this.colBeziehung_Add.VisibleIndex = 3;
            this.colBeziehung_Add.Width = 84;
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(347, 317);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 71;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(347, 347);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 72;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(347, 257);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 69;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(347, 287);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 70;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnAddRemove_Click);
            // 
            // CtlAyPersonen
            // 
            this.ActiveSQLQuery = this.qryKlientensystem;
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblFinanzplan);
            this.Controls.Add(this.lblKlientensystem);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.grdHaushalt);
            this.Controls.Add(this.grdKlientensystem);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.fraKennzahlen);
            this.Controls.Add(this.fraAnspechperson);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlAyPersonen";
            this.Size = new System.Drawing.Size(721, 456);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKlientensystem)).EndInit();
            this.fraAnspechperson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            this.fraKennzahlen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUeGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHgGrundbedarf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHaushalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKlientensystem)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel22;
        private KiSS4.Gui.KissGroupBox fraAnspechperson;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblAdresse;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissGroupBox fraKennzahlen;
        private KiSS4.Gui.KissLabel lblUeGrundbedarf;
        private KiSS4.Gui.KissLabel lblHgGrundbedarf;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryHeader;
        private KiSS4.Gui.KissLabel lblFinanzplan;
        private KiSS4.Gui.KissLabel lblKlientensystem;
        private KiSS4.Gui.KissLabel lblInfo2;
        private KiSS4.Gui.KissLabel lblInfo1;
        private KiSS4.Gui.KissGrid grdHaushalt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonName_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter_Remove;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung_Remove;
        private KiSS4.Gui.KissGrid grdKlientensystem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKlientensystem;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonName_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter_Add;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung_Add;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.DB.SqlQuery qryKlientensystem;
        private KiSS4.DB.SqlQuery qryHaushalt;
    }
}
