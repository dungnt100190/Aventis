using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiSS4.Inkasso
{
    partial class CtlIkForderungen
    {
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkForderungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabIkForderung = new KiSS4.Gui.KissTabControlEx();
            this.tbpEinmalig = new SharpLibrary.WinControls.TabPageEx();
            this.ctlIkMonatszahlenEinmalig = new KiSS4.Inkasso.CtlIkMonatszahlenEinmalig();
            this.tbpPeriodischeForderungen = new SharpLibrary.WinControls.TabPageEx();
            this.lblDatumGueltigBis = new KiSS4.Gui.KissLabel();
            this.edtDatumGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.qryIkForderung = new KiSS4.DB.SqlQuery();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblDatumAnpassenAb = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblForderungPeriodisch = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtUnterstuetzung = new KiSS4.Gui.KissCheckEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtDatumAnpassenAb = new KiSS4.Gui.KissDateEdit();
            this.edtForderungPeriodisch = new KiSS4.Gui.KissLookUpEdit();
            this.grdIkForderung = new KiSS4.Gui.KissGrid();
            this.gvwIkForderung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForderungPeriodisch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryPerson = new KiSS4.DB.SqlQuery();
            this.tabIkForderung.SuspendLayout();
            this.tbpEinmalig.SuspendLayout();
            this.tbpPeriodischeForderungen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAnpassenAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungPeriodisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAnpassenAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungPeriodisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungPeriodisch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwIkForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // tabIkForderung
            // 
            this.tabIkForderung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabIkForderung.Controls.Add(this.tbpEinmalig);
            this.tabIkForderung.Controls.Add(this.tbpPeriodischeForderungen);
            this.tabIkForderung.Location = new System.Drawing.Point(5, 27);
            this.tabIkForderung.Name = "tabIkForderung";
            this.tabIkForderung.SelectedTabIndex = 1;
            this.tabIkForderung.ShowFixedWidthTooltip = true;
            this.tabIkForderung.Size = new System.Drawing.Size(692, 551);
            this.tabIkForderung.TabIndex = 0;
            this.tabIkForderung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tbpPeriodischeForderungen,
            this.tbpEinmalig});
            this.tabIkForderung.TabsLineColor = System.Drawing.Color.Black;
            this.tabIkForderung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabIkForderung.Text = "kissTabControlEx1";
            this.tabIkForderung.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabIkForderung_SelectedTabChanging);
            // 
            // tbpEinmalig
            // 
            this.tbpEinmalig.Controls.Add(this.ctlIkMonatszahlenEinmalig);
            this.tbpEinmalig.Location = new System.Drawing.Point(6, 6);
            this.tbpEinmalig.Name = "tbpEinmalig";
            this.tbpEinmalig.Size = new System.Drawing.Size(680, 513);
            this.tbpEinmalig.TabIndex = 5;
            this.tbpEinmalig.Title = "Einmalige Forderung";
            // 
            // ctlIkMonatszahlenEinmalig
            // 
            this.ctlIkMonatszahlenEinmalig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkMonatszahlenEinmalig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlIkMonatszahlenEinmalig.Location = new System.Drawing.Point(0, 0);
            this.ctlIkMonatszahlenEinmalig.Name = "ctlIkMonatszahlenEinmalig";
            this.ctlIkMonatszahlenEinmalig.Size = new System.Drawing.Size(680, 513);
            this.ctlIkMonatszahlenEinmalig.TabIndex = 0;
            // 
            // tbpPeriodischeForderungen
            // 
            this.tbpPeriodischeForderungen.Controls.Add(this.lblDatumGueltigBis);
            this.tbpPeriodischeForderungen.Controls.Add(this.edtDatumGueltigBis);
            this.tbpPeriodischeForderungen.Controls.Add(this.lblBaPersonID);
            this.tbpPeriodischeForderungen.Controls.Add(this.lblDatumAnpassenAb);
            this.tbpPeriodischeForderungen.Controls.Add(this.lblBetrag);
            this.tbpPeriodischeForderungen.Controls.Add(this.lblBemerkung);
            this.tbpPeriodischeForderungen.Controls.Add(this.lblForderungPeriodisch);
            this.tbpPeriodischeForderungen.Controls.Add(this.edtBemerkung);
            this.tbpPeriodischeForderungen.Controls.Add(this.edtUnterstuetzung);
            this.tbpPeriodischeForderungen.Controls.Add(this.edtBetrag);
            this.tbpPeriodischeForderungen.Controls.Add(this.edtDatumAnpassenAb);
            this.tbpPeriodischeForderungen.Controls.Add(this.edtForderungPeriodisch);
            this.tbpPeriodischeForderungen.Controls.Add(this.grdIkForderung);
            this.tbpPeriodischeForderungen.Controls.Add(this.edtBaPersonID);
            this.tbpPeriodischeForderungen.Location = new System.Drawing.Point(6, 6);
            this.tbpPeriodischeForderungen.Name = "tbpPeriodischeForderungen";
            this.tbpPeriodischeForderungen.Size = new System.Drawing.Size(680, 513);
            this.tbpPeriodischeForderungen.TabIndex = 0;
            this.tbpPeriodischeForderungen.Title = "Periodische Forderungen";
            // 
            // lblDatumGueltigBis
            // 
            this.lblDatumGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumGueltigBis.Location = new System.Drawing.Point(473, 407);
            this.lblDatumGueltigBis.Name = "lblDatumGueltigBis";
            this.lblDatumGueltigBis.Size = new System.Drawing.Size(72, 24);
            this.lblDatumGueltigBis.TabIndex = 26;
            this.lblDatumGueltigBis.Text = "Gültig bis";
            this.lblDatumGueltigBis.UseCompatibleTextRendering = true;
            // 
            // edtDatumGueltigBis
            // 
            this.edtDatumGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumGueltigBis.DataMember = "DatumGueltigBis";
            this.edtDatumGueltigBis.DataSource = this.qryIkForderung;
            this.edtDatumGueltigBis.EditValue = null;
            this.edtDatumGueltigBis.Location = new System.Drawing.Point(547, 407);
            this.edtDatumGueltigBis.Name = "edtDatumGueltigBis";
            this.edtDatumGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumGueltigBis.Properties.ShowToday = false;
            this.edtDatumGueltigBis.Size = new System.Drawing.Size(123, 24);
            this.edtDatumGueltigBis.TabIndex = 25;
            // 
            // qryIkForderung
            // 
            this.qryIkForderung.CanDelete = true;
            this.qryIkForderung.CanInsert = true;
            this.qryIkForderung.CanUpdate = true;
            this.qryIkForderung.HostControl = this;
            this.qryIkForderung.IsIdentityInsert = false;
            this.qryIkForderung.SelectStatement = "SELECT FRD.*,\r\n       LeistungPersonID = LST.BaPersonID\r\nFROM IkForderung        " +
    "FRD\r\n  INNER JOIN FaLeistung LST ON LST.FaLeistungID = FRD.FaLeistungID\r\nWHERE F" +
    "RD.FaLeistungID = {0}";
            this.qryIkForderung.TableName = "IkForderung";
            this.qryIkForderung.AfterFill += new System.EventHandler(this.qryIkForderung_AfterFill);
            this.qryIkForderung.AfterInsert += new System.EventHandler(this.qryIkForderung_AfterInsert);
            this.qryIkForderung.AfterPost += new System.EventHandler(this.qryIkForderung_AfterPost);
            this.qryIkForderung.BeforePost += new System.EventHandler(this.qryIkForderung_BeforePost);
            this.qryIkForderung.PositionChanged += new System.EventHandler(this.qryIkForderung_PositionChanged);
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaPersonID.Location = new System.Drawing.Point(12, 348);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(100, 23);
            this.lblBaPersonID.TabIndex = 24;
            this.lblBaPersonID.Text = "Person, Gläubiger ";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // lblDatumAnpassenAb
            // 
            this.lblDatumAnpassenAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumAnpassenAb.Location = new System.Drawing.Point(473, 377);
            this.lblDatumAnpassenAb.Name = "lblDatumAnpassenAb";
            this.lblDatumAnpassenAb.Size = new System.Drawing.Size(72, 24);
            this.lblDatumAnpassenAb.TabIndex = 22;
            this.lblDatumAnpassenAb.Text = "Gültig ab";
            this.lblDatumAnpassenAb.UseCompatibleTextRendering = true;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrag.Location = new System.Drawing.Point(473, 437);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(72, 24);
            this.lblBetrag.TabIndex = 21;
            this.lblBetrag.Text = "Betrag ";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(12, 415);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(106, 24);
            this.lblBemerkung.TabIndex = 18;
            this.lblBemerkung.Text = "Bemerkung";
            this.lblBemerkung.UseCompatibleTextRendering = true;
            // 
            // lblForderungPeriodisch
            // 
            this.lblForderungPeriodisch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblForderungPeriodisch.Location = new System.Drawing.Point(12, 377);
            this.lblForderungPeriodisch.Name = "lblForderungPeriodisch";
            this.lblForderungPeriodisch.Size = new System.Drawing.Size(106, 24);
            this.lblForderungPeriodisch.TabIndex = 17;
            this.lblForderungPeriodisch.Text = "Forderungs Titel";
            this.lblForderungPeriodisch.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryIkForderung;
            this.edtBemerkung.Location = new System.Drawing.Point(124, 407);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(317, 92);
            this.edtBemerkung.TabIndex = 5;
            // 
            // edtUnterstuetzung
            // 
            this.edtUnterstuetzung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUnterstuetzung.DataMember = "Unterstuetzungsfall";
            this.edtUnterstuetzung.DataSource = this.qryIkForderung;
            this.edtUnterstuetzung.Location = new System.Drawing.Point(473, 350);
            this.edtUnterstuetzung.Name = "edtUnterstuetzung";
            this.edtUnterstuetzung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUnterstuetzung.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetzung.Properties.Caption = "Unterstützungsfall";
            this.edtUnterstuetzung.Size = new System.Drawing.Size(197, 19);
            this.edtUnterstuetzung.TabIndex = 4;
            // 
            // edtBetrag
            // 
            this.edtBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryIkForderung;
            this.edtBetrag.Location = new System.Drawing.Point(547, 437);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.Mask.EditMask = "N2";
            this.edtBetrag.Size = new System.Drawing.Size(123, 24);
            this.edtBetrag.TabIndex = 3;
            // 
            // edtDatumAnpassenAb
            // 
            this.edtDatumAnpassenAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumAnpassenAb.DataMember = "DatumAnpassenAb";
            this.edtDatumAnpassenAb.DataSource = this.qryIkForderung;
            this.edtDatumAnpassenAb.EditValue = null;
            this.edtDatumAnpassenAb.Location = new System.Drawing.Point(547, 377);
            this.edtDatumAnpassenAb.Name = "edtDatumAnpassenAb";
            this.edtDatumAnpassenAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumAnpassenAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumAnpassenAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumAnpassenAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumAnpassenAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumAnpassenAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumAnpassenAb.Properties.Appearance.Options.UseFont = true;
            this.edtDatumAnpassenAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumAnpassenAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumAnpassenAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumAnpassenAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumAnpassenAb.Properties.ShowToday = false;
            this.edtDatumAnpassenAb.Size = new System.Drawing.Size(123, 24);
            this.edtDatumAnpassenAb.TabIndex = 2;
            // 
            // edtForderungPeriodisch
            // 
            this.edtForderungPeriodisch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtForderungPeriodisch.DataMember = "IkForderungPeriodischCode";
            this.edtForderungPeriodisch.DataSource = this.qryIkForderung;
            this.edtForderungPeriodisch.Location = new System.Drawing.Point(124, 377);
            this.edtForderungPeriodisch.LOVName = "IkForderungPeriodisch";
            this.edtForderungPeriodisch.Name = "edtForderungPeriodisch";
            this.edtForderungPeriodisch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungPeriodisch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungPeriodisch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungPeriodisch.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungPeriodisch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungPeriodisch.Properties.Appearance.Options.UseFont = true;
            this.edtForderungPeriodisch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtForderungPeriodisch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungPeriodisch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtForderungPeriodisch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtForderungPeriodisch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtForderungPeriodisch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtForderungPeriodisch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtForderungPeriodisch.Properties.NullText = "";
            this.edtForderungPeriodisch.Properties.ShowFooter = false;
            this.edtForderungPeriodisch.Properties.ShowHeader = false;
            this.edtForderungPeriodisch.Size = new System.Drawing.Size(315, 24);
            this.edtForderungPeriodisch.TabIndex = 1;
            // 
            // grdIkForderung
            // 
            this.grdIkForderung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdIkForderung.DataSource = this.qryIkForderung;
            // 
            // 
            // 
            this.grdIkForderung.EmbeddedNavigator.Name = "";
            this.grdIkForderung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdIkForderung.Location = new System.Drawing.Point(5, 3);
            this.grdIkForderung.MainView = this.gvwIkForderung;
            this.grdIkForderung.Name = "grdIkForderung";
            this.grdIkForderung.Size = new System.Drawing.Size(674, 324);
            this.grdIkForderung.TabIndex = 0;
            this.grdIkForderung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwIkForderung});
            // 
            // gvwIkForderung
            // 
            this.gvwIkForderung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvwIkForderung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.Empty.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.Empty.Options.UseFont = true;
            this.gvwIkForderung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvwIkForderung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.EvenRow.Options.UseFont = true;
            this.gvwIkForderung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwIkForderung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvwIkForderung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.FocusedCell.Options.UseFont = true;
            this.gvwIkForderung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvwIkForderung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvwIkForderung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvwIkForderung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.FocusedRow.Options.UseFont = true;
            this.gvwIkForderung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvwIkForderung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwIkForderung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvwIkForderung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwIkForderung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwIkForderung.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.GroupRow.Options.UseFont = true;
            this.gvwIkForderung.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvwIkForderung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvwIkForderung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvwIkForderung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvwIkForderung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvwIkForderung.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvwIkForderung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvwIkForderung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvwIkForderung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvwIkForderung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvwIkForderung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvwIkForderung.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.OddRow.Options.UseFont = true;
            this.gvwIkForderung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvwIkForderung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.Row.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.Row.Options.UseFont = true;
            this.gvwIkForderung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvwIkForderung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvwIkForderung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvwIkForderung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvwIkForderung.Appearance.SelectedRow.Options.UseFont = true;
            this.gvwIkForderung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvwIkForderung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvwIkForderung.Appearance.VertLine.Options.UseBackColor = true;
            this.gvwIkForderung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvwIkForderung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colForderungPeriodisch,
            this.colBemerkung,
            this.colBetrag});
            this.gvwIkForderung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvwIkForderung.GridControl = this.grdIkForderung;
            this.gvwIkForderung.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gvwIkForderung.Name = "gvwIkForderung";
            this.gvwIkForderung.OptionsBehavior.Editable = false;
            this.gvwIkForderung.OptionsCustomization.AllowFilter = false;
            this.gvwIkForderung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvwIkForderung.OptionsNavigation.AutoFocusNewRow = true;
            this.gvwIkForderung.OptionsNavigation.UseTabKey = false;
            this.gvwIkForderung.OptionsView.ColumnAutoWidth = false;
            this.gvwIkForderung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwIkForderung.OptionsView.ShowGroupPanel = false;
            this.gvwIkForderung.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "gültig ab";
            this.colDatum.FieldName = "DatumAnpassenAb";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowEdit = false;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 83;
            // 
            // colForderungPeriodisch
            // 
            this.colForderungPeriodisch.Caption = "Forderung";
            this.colForderungPeriodisch.FieldName = "IkForderungPeriodischCode";
            this.colForderungPeriodisch.Name = "colForderungPeriodisch";
            this.colForderungPeriodisch.OptionsColumn.AllowEdit = false;
            this.colForderungPeriodisch.Visible = true;
            this.colForderungPeriodisch.VisibleIndex = 1;
            this.colForderungPeriodisch.Width = 208;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 3;
            this.colBemerkung.Width = 255;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colBetrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 2;
            this.colBetrag.Width = 91;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryIkForderung;
            this.edtBaPersonID.Location = new System.Drawing.Point(124, 347);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Person", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Alter", "Alter", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(315, 24);
            this.edtBaPersonID.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 24);
            this.panel1.TabIndex = 1;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Inkasso";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // qryPerson
            // 
            this.qryPerson.IsIdentityInsert = false;
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            // 
            // CtlIkForderungen
            // 
            this.ActiveSQLQuery = this.qryIkForderung;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabIkForderung);
            this.Name = "CtlIkForderungen";
            this.Size = new System.Drawing.Size(706, 589);
            this.tabIkForderung.ResumeLayout(false);
            this.tbpEinmalig.ResumeLayout(false);
            this.tbpPeriodischeForderungen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumAnpassenAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungPeriodisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumAnpassenAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungPeriodisch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungPeriodisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwIkForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissTabControlEx tabIkForderung;
        private SharpLibrary.WinControls.TabPageEx tbpEinmalig;
        private KiSS4.Inkasso.CtlIkMonatszahlenEinmalig ctlIkMonatszahlenEinmalig;
        private SharpLibrary.WinControls.TabPageEx tbpPeriodischeForderungen;
        private KiSS4.Gui.KissLabel lblDatumGueltigBis;
        private KiSS4.Gui.KissDateEdit edtDatumGueltigBis;
        private KiSS4.DB.SqlQuery qryIkForderung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblDatumAnpassenAb;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblForderungPeriodisch;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCheckEdit edtUnterstuetzung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissDateEdit edtDatumAnpassenAb;
        private KiSS4.Gui.KissLookUpEdit edtForderungPeriodisch;
        private KiSS4.Gui.KissGrid grdIkForderung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwIkForderung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colForderungPeriodisch;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        public KiSS4.DB.SqlQuery qryPerson;
    }
}
