namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaAbklaerung
    {
        #region Dispose

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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaAbklaerung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.edtAuftragDatum = new KiSS4.Gui.KissDateEdit();
            this.qryAbklaerung = new KiSS4.DB.SqlQuery();
            this.edtAusloeserCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.qryPerson = new KiSS4.DB.SqlQuery();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.lblAuftragDatum = new KiSS4.Gui.KissLabel();
            this.lblAusloeserCode = new KiSS4.Gui.KissLabel();
            this.edtAbklaerungsberichtBeendetDatum = new KiSS4.Gui.KissDateEdit();
            this.grdAbklaerung = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAuftragDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusloeser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbklaerungsberichtBeendetDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridAuftrag = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridWer = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridWas = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridWann = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.lblAbklaerungsberichtBeendet = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtCoUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblCoUserID = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuftragDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbklaerung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusloeserCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusloeserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusloeserCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungsberichtBeendetDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbklaerung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungsberichtBeendet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCoUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoUserID)).BeginInit();
            this.SuspendLayout();
            // 
            // edtAuftragDatum
            // 
            this.edtAuftragDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAuftragDatum.DataMember = "AuftragDatum";
            this.edtAuftragDatum.DataSource = this.qryAbklaerung;
            this.edtAuftragDatum.EditValue = null;
            this.edtAuftragDatum.Location = new System.Drawing.Point(113, 420);
            this.edtAuftragDatum.Name = "edtAuftragDatum";
            this.edtAuftragDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAuftragDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuftragDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuftragDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuftragDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuftragDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuftragDatum.Properties.Appearance.Options.UseFont = true;
            this.edtAuftragDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtAuftragDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAuftragDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtAuftragDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuftragDatum.Properties.ShowToday = false;
            this.edtAuftragDatum.Size = new System.Drawing.Size(100, 24);
            this.edtAuftragDatum.TabIndex = 3;
            // 
            // qryAbklaerung
            // 
            this.qryAbklaerung.CanDelete = true;
            this.qryAbklaerung.CanInsert = true;
            this.qryAbklaerung.CanUpdate = true;
            this.qryAbklaerung.HostControl = this;
            this.qryAbklaerung.SelectStatement = resources.GetString("qryAbklaerung.SelectStatement");
            this.qryAbklaerung.TableName = "FaAbklaerung";
            this.qryAbklaerung.AfterInsert += new System.EventHandler(this.qryAbklaerung_AfterInsert);
            this.qryAbklaerung.BeforePost += new System.EventHandler(this.qryAbklaerung_BeforePost);
            this.qryAbklaerung.AfterPost += new System.EventHandler(this.qryAbklaerung_AfterPost);
            this.qryAbklaerung.PositionChanged += new System.EventHandler(this.qryAbklaerung_PositionChanged);
            // 
            // edtAusloeserCode
            // 
            this.edtAusloeserCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusloeserCode.DataMember = "AusloeserCode";
            this.edtAusloeserCode.DataSource = this.qryAbklaerung;
            this.edtAusloeserCode.Location = new System.Drawing.Point(113, 450);
            this.edtAusloeserCode.LOVName = "FaAbklaerungAusloeser";
            this.edtAusloeserCode.Name = "edtAusloeserCode";
            this.edtAusloeserCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusloeserCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusloeserCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusloeserCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusloeserCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusloeserCode.Properties.Appearance.Options.UseFont = true;
            this.edtAusloeserCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAusloeserCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusloeserCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAusloeserCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAusloeserCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtAusloeserCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtAusloeserCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusloeserCode.Properties.NullText = "";
            this.edtAusloeserCode.Properties.ShowFooter = false;
            this.edtAusloeserCode.Properties.ShowHeader = false;
            this.edtAusloeserCode.Size = new System.Drawing.Size(255, 24);
            this.edtAusloeserCode.TabIndex = 5;
            // 
            // edtUserID
            // 
            this.edtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUserID.DataMember = "LogonName";
            this.edtUserID.DataSource = this.qryAbklaerung;
            this.edtUserID.Location = new System.Drawing.Point(113, 510);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(255, 24);
            this.edtUserID.TabIndex = 9;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryAbklaerung;
            this.edtBaPersonID.Location = new System.Drawing.Point(113, 480);
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
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBaPersonID.Properties.DataSource = this.qryPerson;
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "Code";
            this.edtBaPersonID.Size = new System.Drawing.Size(255, 24);
            this.edtBaPersonID.TabIndex = 7;
            // 
            // qryPerson
            // 
            this.qryPerson.HostControl = this;
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            // 
            // lblUserID
            // 
            this.lblUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUserID.Location = new System.Drawing.Point(5, 510);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(102, 24);
            this.lblUserID.TabIndex = 8;
            this.lblUserID.Text = "Mitarbeiter/in";
            this.lblUserID.UseCompatibleTextRendering = true;
            // 
            // lblAuftragDatum
            // 
            this.lblAuftragDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuftragDatum.Location = new System.Drawing.Point(5, 420);
            this.lblAuftragDatum.Name = "lblAuftragDatum";
            this.lblAuftragDatum.Size = new System.Drawing.Size(102, 24);
            this.lblAuftragDatum.TabIndex = 2;
            this.lblAuftragDatum.Text = "Datum Auftrag";
            this.lblAuftragDatum.UseCompatibleTextRendering = true;
            // 
            // lblAusloeserCode
            // 
            this.lblAusloeserCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusloeserCode.Location = new System.Drawing.Point(5, 450);
            this.lblAusloeserCode.Name = "lblAusloeserCode";
            this.lblAusloeserCode.Size = new System.Drawing.Size(102, 24);
            this.lblAusloeserCode.TabIndex = 4;
            this.lblAusloeserCode.Text = "Auslöser";
            this.lblAusloeserCode.UseCompatibleTextRendering = true;
            // 
            // edtAbklaerungsberichtBeendetDatum
            // 
            this.edtAbklaerungsberichtBeendetDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAbklaerungsberichtBeendetDatum.DataMember = "AbklaerungsberichtBeendetDatum";
            this.edtAbklaerungsberichtBeendetDatum.DataSource = this.qryAbklaerung;
            this.edtAbklaerungsberichtBeendetDatum.EditValue = null;
            this.edtAbklaerungsberichtBeendetDatum.Location = new System.Drawing.Point(595, 420);
            this.edtAbklaerungsberichtBeendetDatum.Name = "edtAbklaerungsberichtBeendetDatum";
            this.edtAbklaerungsberichtBeendetDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAbklaerungsberichtBeendetDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbklaerungsberichtBeendetDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbklaerungsberichtBeendetDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbklaerungsberichtBeendetDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbklaerungsberichtBeendetDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbklaerungsberichtBeendetDatum.Properties.Appearance.Options.UseFont = true;
            this.edtAbklaerungsberichtBeendetDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbklaerungsberichtBeendetDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAbklaerungsberichtBeendetDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbklaerungsberichtBeendetDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbklaerungsberichtBeendetDatum.Properties.ShowToday = false;
            this.edtAbklaerungsberichtBeendetDatum.Size = new System.Drawing.Size(100, 24);
            this.edtAbklaerungsberichtBeendetDatum.TabIndex = 13;
            // 
            // grdAbklaerung
            // 
            this.grdAbklaerung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAbklaerung.DataSource = this.qryAbklaerung;
            // 
            // 
            // 
            this.grdAbklaerung.EmbeddedNavigator.Name = "kissGrid1.EmbeddedNavigator";
            this.grdAbklaerung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAbklaerung.Location = new System.Drawing.Point(5, 28);
            this.grdAbklaerung.MainView = this.gridView1;
            this.grdAbklaerung.Name = "grdAbklaerung";
            this.grdAbklaerung.Size = new System.Drawing.Size(707, 371);
            this.grdAbklaerung.TabIndex = 1;
            this.grdAbklaerung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.bandedGridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuftragDatum,
            this.colAusloeser,
            this.colAbklaerungsberichtBeendetDatum});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdAbklaerung;
            this.gridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colAuftragDatum
            // 
            this.colAuftragDatum.Caption = "Auftrag";
            this.colAuftragDatum.FieldName = "AuftragDatum";
            this.colAuftragDatum.Name = "colAuftragDatum";
            this.colAuftragDatum.Visible = true;
            this.colAuftragDatum.VisibleIndex = 0;
            this.colAuftragDatum.Width = 80;
            // 
            // colAusloeser
            // 
            this.colAusloeser.Caption = "Auslöser";
            this.colAusloeser.FieldName = "AusloeserCode";
            this.colAusloeser.Name = "colAusloeser";
            this.colAusloeser.Visible = true;
            this.colAusloeser.VisibleIndex = 1;
            this.colAusloeser.Width = 169;
            // 
            // colAbklaerungsberichtBeendetDatum
            // 
            this.colAbklaerungsberichtBeendetDatum.Caption = "Bericht beendet";
            this.colAbklaerungsberichtBeendetDatum.FieldName = "AbklaerungsberichtBeendetDatum";
            this.colAbklaerungsberichtBeendetDatum.Name = "colAbklaerungsberichtBeendetDatum";
            this.colAbklaerungsberichtBeendetDatum.Visible = true;
            this.colAbklaerungsberichtBeendetDatum.VisibleIndex = 2;
            this.colAbklaerungsberichtBeendetDatum.Width = 162;
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.bandedGridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.Empty.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Empty.Options.UseFont = true;
            this.bandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.EvenRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.bandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.bandedGridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bandedGridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.bandedGridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.bandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.bandedGridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.OddRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.Row.Options.UseBackColor = true;
            this.bandedGridView1.Appearance.Row.Options.UseFont = true;
            this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.bandedGridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.bandedGridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridWer,
            this.gridWas,
            this.gridWann,
            this.gridAuftrag});
            this.bandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.bandedGridView1.GridControl = this.grdAbklaerung;
            this.bandedGridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsCustomization.AllowFilter = false;
            this.bandedGridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.bandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.bandedGridView1.OptionsNavigation.UseTabKey = false;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsView.ShowIndicator = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Columns.Add(this.gridAuftrag);
            this.gridBand1.Columns.Add(this.gridWer);
            this.gridBand1.Columns.Add(this.gridWas);
            this.gridBand1.Columns.Add(this.gridWann);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 1604;
            // 
            // gridAuftrag
            // 
            this.gridAuftrag.Caption = "Auftrag";
            this.gridAuftrag.Name = "gridAuftrag";
            this.gridAuftrag.Visible = true;
            this.gridAuftrag.Width = 158;
            // 
            // gridWer
            // 
            this.gridWer.Caption = "wer?";
            this.gridWer.Name = "gridWer";
            this.gridWer.Visible = true;
            this.gridWer.Width = 158;
            // 
            // gridWas
            // 
            this.gridWas.Caption = "macht was? mit wem?";
            this.gridWas.Name = "gridWas";
            this.gridWas.Visible = true;
            this.gridWas.Width = 158;
            // 
            // gridWann
            // 
            this.gridWann.Caption = "bis wann?";
            this.gridWann.Name = "gridWann";
            this.gridWann.Visible = true;
            this.gridWann.Width = 166;
            // 
            // lblAbklaerungsberichtBeendet
            // 
            this.lblAbklaerungsberichtBeendet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbklaerungsberichtBeendet.Location = new System.Drawing.Point(447, 419);
            this.lblAbklaerungsberichtBeendet.Name = "lblAbklaerungsberichtBeendet";
            this.lblAbklaerungsberichtBeendet.Size = new System.Drawing.Size(141, 24);
            this.lblAbklaerungsberichtBeendet.TabIndex = 12;
            this.lblAbklaerungsberichtBeendet.Text = "Abklärungsbericht beendet";
            this.lblAbklaerungsberichtBeendet.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaPersonID.Location = new System.Drawing.Point(5, 480);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(102, 24);
            this.lblBaPersonID.TabIndex = 6;
            this.lblBaPersonID.Text = "für Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 24);
            this.panel1.TabIndex = 0;
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
            this.lblTitel.Text = "Abklärung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // edtCoUserID
            // 
            this.edtCoUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtCoUserID.DataMember = "CoLogonName";
            this.edtCoUserID.DataSource = this.qryAbklaerung;
            this.edtCoUserID.Location = new System.Drawing.Point(113, 539);
            this.edtCoUserID.Name = "edtCoUserID";
            this.edtCoUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtCoUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtCoUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtCoUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtCoUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtCoUserID.Properties.Appearance.Options.UseFont = true;
            this.edtCoUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtCoUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtCoUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtCoUserID.Size = new System.Drawing.Size(255, 24);
            this.edtCoUserID.TabIndex = 11;
            this.edtCoUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtCoUserID_UserModifiedFld);
            // 
            // lblCoUserID
            // 
            this.lblCoUserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCoUserID.Location = new System.Drawing.Point(5, 540);
            this.lblCoUserID.Name = "lblCoUserID";
            this.lblCoUserID.Size = new System.Drawing.Size(102, 24);
            this.lblCoUserID.TabIndex = 10;
            this.lblCoUserID.Text = "Co-Fallführung";
            this.lblCoUserID.UseCompatibleTextRendering = true;
            // 
            // CtlFaAbklaerung
            // 
            this.ActiveSQLQuery = this.qryAbklaerung;
            this.Controls.Add(this.lblCoUserID);
            this.Controls.Add(this.edtCoUserID);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.lblAbklaerungsberichtBeendet);
            this.Controls.Add(this.grdAbklaerung);
            this.Controls.Add(this.edtAbklaerungsberichtBeendetDatum);
            this.Controls.Add(this.lblAusloeserCode);
            this.Controls.Add(this.lblAuftragDatum);
            this.Controls.Add(this.lblUserID);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.edtUserID);
            this.Controls.Add(this.edtAusloeserCode);
            this.Controls.Add(this.edtAuftragDatum);
            this.Name = "CtlFaAbklaerung";
            this.Size = new System.Drawing.Size(715, 584);
            ((System.ComponentModel.ISupportInitialize)(this.edtAuftragDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbklaerung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusloeserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusloeserCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuftragDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusloeserCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbklaerungsberichtBeendetDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbklaerung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbklaerungsberichtBeendet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCoUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoUserID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAbklaerungsberichtBeendetDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAuftragDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAusloeser;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtAbklaerungsberichtBeendetDatum;
        private KiSS4.Gui.KissDateEdit edtAuftragDatum;
        private KiSS4.Gui.KissLookUpEdit edtAusloeserCode;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissButtonEdit edtCoUserID;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissGrid grdAbklaerung;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridAuftrag;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridWann;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridWas;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridWer;
        private KiSS4.Gui.KissLabel lblAbklaerungsberichtBeendet;
        private KiSS4.Gui.KissLabel lblAuftragDatum;
        private KiSS4.Gui.KissLabel lblAusloeserCode;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblCoUserID;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblUserID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryAbklaerung;
        private KiSS4.DB.SqlQuery qryPerson;
    }
}