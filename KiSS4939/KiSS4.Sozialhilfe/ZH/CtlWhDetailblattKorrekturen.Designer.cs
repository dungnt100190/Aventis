namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlWhDetailblattKorrekturen
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

        #region Windows Forms Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhDetailblattKorrekturen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colKorrekturtext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.qryWhDetailblattKorrekturPosition = new KiSS4.DB.SqlQuery();
            this.lblKorrekturTyp = new KiSS4.Gui.KissLabel();
            this.lblLeistungsart = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblKorrekturtext = new KiSS4.Gui.KissLabel();
            this.edtVorzeichen = new KiSS4.Gui.KissLookUpEdit();
            this.edtKategorie = new KiSS4.Gui.KissLookUpEdit();
            this.edtLeistungsart = new KiSS4.Gui.KissButtonEdit();
            this.edtKorrekturtext = new KiSS4.Gui.KissMemoEdit();
            this.grdWhDetailblattKorrekturen = new KiSS4.Gui.KissGrid();
            this.grvWhDetailblattKorrekturen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBgKategorie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorzeichen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgKostenartFreitext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBetragBudget = new KiSS4.Gui.KissCalcEdit();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhDetailblattKorrekturPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrekturTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrekturtext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorzeichen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorzeichen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKorrekturtext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWhDetailblattKorrekturen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWhDetailblattKorrekturen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBudget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.SuspendLayout();
            // 
            // colKorrekturtext
            // 
            this.colKorrekturtext.Caption = "Korrekturtext";
            this.colKorrekturtext.FieldName = "Korrekturtext";
            this.colKorrekturtext.Name = "colKorrekturtext";
            this.colKorrekturtext.Visible = true;
            this.colKorrekturtext.VisibleIndex = 2;
            this.colKorrekturtext.Width = 162;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // qryWhDetailblattKorrekturPosition
            // 
            this.qryWhDetailblattKorrekturPosition.CanDelete = true;
            this.qryWhDetailblattKorrekturPosition.CanInsert = true;
            this.qryWhDetailblattKorrekturPosition.CanUpdate = true;
            this.qryWhDetailblattKorrekturPosition.HostControl = this;
            this.qryWhDetailblattKorrekturPosition.SelectStatement = resources.GetString("qryWhDetailblattKorrekturPosition.SelectStatement");
            this.qryWhDetailblattKorrekturPosition.TableName = "WhDetailblattKorrekturPosition";
            this.qryWhDetailblattKorrekturPosition.AfterFill += new System.EventHandler(this.qryWhDetailblattKorrekturPosition_AfterFill);
            this.qryWhDetailblattKorrekturPosition.AfterInsert += new System.EventHandler(this.qryWhDetailblattKorrekturPosition_AfterInsert);
            this.qryWhDetailblattKorrekturPosition.BeforePost += new System.EventHandler(this.qryWhDetailblattKorrekturPosition_BeforePost);
            // 
            // lblKorrekturTyp
            // 
            this.lblKorrekturTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKorrekturTyp.Location = new System.Drawing.Point(467, 30);
            this.lblKorrekturTyp.Name = "lblKorrekturTyp";
            this.lblKorrekturTyp.Size = new System.Drawing.Size(100, 23);
            this.lblKorrekturTyp.TabIndex = 0;
            this.lblKorrekturTyp.Text = "Korrektur-Typ";
            // 
            // lblLeistungsart
            // 
            this.lblLeistungsart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeistungsart.Location = new System.Drawing.Point(467, 60);
            this.lblLeistungsart.Name = "lblLeistungsart";
            this.lblLeistungsart.Size = new System.Drawing.Size(100, 23);
            this.lblLeistungsart.TabIndex = 3;
            this.lblLeistungsart.Text = "Leistungsart";
            // 
            // lblBetrag
            // 
            this.lblBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetrag.Location = new System.Drawing.Point(467, 90);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(100, 23);
            this.lblBetrag.TabIndex = 5;
            this.lblBetrag.Text = "Betrag";
            // 
            // lblKorrekturtext
            // 
            this.lblKorrekturtext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKorrekturtext.Location = new System.Drawing.Point(467, 120);
            this.lblKorrekturtext.Name = "lblKorrekturtext";
            this.lblKorrekturtext.Size = new System.Drawing.Size(100, 23);
            this.lblKorrekturtext.TabIndex = 7;
            this.lblKorrekturtext.Text = "Korrekturtext";
            // 
            // edtVorzeichen
            // 
            this.edtVorzeichen.AllowNull = false;
            this.edtVorzeichen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVorzeichen.DataMember = "WhDetailblattKorrekturVorzeichenCode";
            this.edtVorzeichen.DataSource = this.qryWhDetailblattKorrekturPosition;
            this.edtVorzeichen.DisplayMember = "ShortText";
            this.edtVorzeichen.Location = new System.Drawing.Point(573, 30);
            this.edtVorzeichen.LOVName = "WhDetailblattKorrekturVorzeichen";
            this.edtVorzeichen.Name = "edtVorzeichen";
            this.edtVorzeichen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorzeichen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorzeichen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorzeichen.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorzeichen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorzeichen.Properties.Appearance.Options.UseFont = true;
            this.edtVorzeichen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVorzeichen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorzeichen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVorzeichen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVorzeichen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtVorzeichen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtVorzeichen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVorzeichen.Properties.NullText = "";
            this.edtVorzeichen.Properties.ShowFooter = false;
            this.edtVorzeichen.Properties.ShowHeader = false;
            this.edtVorzeichen.Size = new System.Drawing.Size(51, 24);
            this.edtVorzeichen.TabIndex = 1;
            // 
            // edtKategorie
            // 
            this.edtKategorie.AllowNull = false;
            this.edtKategorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKategorie.DataMember = "BgKategorieCode";
            this.edtKategorie.DataSource = this.qryWhDetailblattKorrekturPosition;
            this.edtKategorie.Location = new System.Drawing.Point(630, 30);
            this.edtKategorie.LOVFilter = "CODE IN (1, 2, 3)";
            this.edtKategorie.LOVFilterWhereAppend = true;
            this.edtKategorie.LOVName = "BgKategorie";
            this.edtKategorie.Name = "edtKategorie";
            this.edtKategorie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtKategorie.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKategorie.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtKategorie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtKategorie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKategorie.Properties.NullText = "";
            this.edtKategorie.Properties.ShowFooter = false;
            this.edtKategorie.Properties.ShowHeader = false;
            this.edtKategorie.Size = new System.Drawing.Size(220, 24);
            this.edtKategorie.TabIndex = 2;
            // 
            // edtLeistungsart
            // 
            this.edtLeistungsart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLeistungsart.DataMember = "Leistungsart";
            this.edtLeistungsart.DataSource = this.qryWhDetailblattKorrekturPosition;
            this.edtLeistungsart.Location = new System.Drawing.Point(573, 60);
            this.edtLeistungsart.Name = "edtLeistungsart";
            this.edtLeistungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeistungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeistungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeistungsart.Properties.Appearance.Options.UseFont = true;
            this.edtLeistungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtLeistungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtLeistungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeistungsart.Size = new System.Drawing.Size(277, 24);
            this.edtLeistungsart.TabIndex = 4;
            this.edtLeistungsart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtLeistungsart_UserModifiedFld);
            // 
            // edtKorrekturtext
            // 
            this.edtKorrekturtext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKorrekturtext.DataMember = "Korrekturtext";
            this.edtKorrekturtext.DataSource = this.qryWhDetailblattKorrekturPosition;
            this.edtKorrekturtext.Location = new System.Drawing.Point(573, 120);
            this.edtKorrekturtext.Name = "edtKorrekturtext";
            this.edtKorrekturtext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKorrekturtext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKorrekturtext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKorrekturtext.Properties.Appearance.Options.UseBackColor = true;
            this.edtKorrekturtext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKorrekturtext.Properties.Appearance.Options.UseFont = true;
            this.edtKorrekturtext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKorrekturtext.Size = new System.Drawing.Size(277, 125);
            this.edtKorrekturtext.TabIndex = 8;
            // 
            // grdWhDetailblattKorrekturen
            // 
            this.grdWhDetailblattKorrekturen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWhDetailblattKorrekturen.DataSource = this.qryWhDetailblattKorrekturPosition;
            // 
            // 
            // 
            this.grdWhDetailblattKorrekturen.EmbeddedNavigator.Name = "";
            this.grdWhDetailblattKorrekturen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdWhDetailblattKorrekturen.Location = new System.Drawing.Point(3, 30);
            this.grdWhDetailblattKorrekturen.MainView = this.grvWhDetailblattKorrekturen;
            this.grdWhDetailblattKorrekturen.Name = "grdWhDetailblattKorrekturen";
            this.grdWhDetailblattKorrekturen.Size = new System.Drawing.Size(458, 215);
            this.grdWhDetailblattKorrekturen.TabIndex = 10;
            this.grdWhDetailblattKorrekturen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWhDetailblattKorrekturen});
            // 
            // grvWhDetailblattKorrekturen
            // 
            this.grvWhDetailblattKorrekturen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvWhDetailblattKorrekturen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.Empty.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.Empty.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.EvenRow.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWhDetailblattKorrekturen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWhDetailblattKorrekturen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWhDetailblattKorrekturen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWhDetailblattKorrekturen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.GroupRow.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvWhDetailblattKorrekturen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvWhDetailblattKorrekturen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWhDetailblattKorrekturen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvWhDetailblattKorrekturen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWhDetailblattKorrekturen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvWhDetailblattKorrekturen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.OddRow.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvWhDetailblattKorrekturen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.Row.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.Appearance.Row.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhDetailblattKorrekturen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvWhDetailblattKorrekturen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvWhDetailblattKorrekturen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvWhDetailblattKorrekturen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvWhDetailblattKorrekturen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBgKategorie,
            this.colVorzeichen,
            this.colBgKostenartFreitext,
            this.colKorrekturtext,
            this.colBetrag});
            this.grvWhDetailblattKorrekturen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition1.Appearance.Options.HighPriority = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colKorrekturtext;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "1";
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition2.Appearance.Options.HighPriority = true;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colKorrekturtext;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "2";
            styleFormatCondition3.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition3.Appearance.Options.HighPriority = true;
            styleFormatCondition3.Appearance.Options.UseFont = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colKorrekturtext;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "3";
            this.grvWhDetailblattKorrekturen.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
            this.grvWhDetailblattKorrekturen.GridControl = this.grdWhDetailblattKorrekturen;
            this.grvWhDetailblattKorrekturen.GroupCount = 1;
            this.grvWhDetailblattKorrekturen.GroupFormat = "[#image]{1} {2}";
            this.grvWhDetailblattKorrekturen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvWhDetailblattKorrekturen.Name = "grvWhDetailblattKorrekturen";
            this.grvWhDetailblattKorrekturen.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvWhDetailblattKorrekturen.OptionsBehavior.Editable = false;
            this.grvWhDetailblattKorrekturen.OptionsCustomization.AllowFilter = false;
            this.grvWhDetailblattKorrekturen.OptionsCustomization.AllowSort = false;
            this.grvWhDetailblattKorrekturen.OptionsFilter.AllowFilterEditor = false;
            this.grvWhDetailblattKorrekturen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvWhDetailblattKorrekturen.OptionsMenu.EnableColumnMenu = false;
            this.grvWhDetailblattKorrekturen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvWhDetailblattKorrekturen.OptionsNavigation.UseTabKey = false;
            this.grvWhDetailblattKorrekturen.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvWhDetailblattKorrekturen.OptionsSelection.UseIndicatorForSelection = false;
            this.grvWhDetailblattKorrekturen.OptionsView.ColumnAutoWidth = false;
            this.grvWhDetailblattKorrekturen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvWhDetailblattKorrekturen.OptionsView.ShowGroupPanel = false;
            this.grvWhDetailblattKorrekturen.OptionsView.ShowIndicator = false;
            this.grvWhDetailblattKorrekturen.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBgKategorie, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colBgKategorie
            // 
            this.colBgKategorie.Caption = "Korrektur-Typ";
            this.colBgKategorie.FieldName = "BgKategorieCode";
            this.colBgKategorie.Name = "colBgKategorie";
            this.colBgKategorie.Visible = true;
            this.colBgKategorie.VisibleIndex = 0;
            this.colBgKategorie.Width = 91;
            // 
            // colVorzeichen
            // 
            this.colVorzeichen.Caption = "+ oder -";
            this.colVorzeichen.FieldName = "WhDetailblattKorrekturVorzeichenCode";
            this.colVorzeichen.Name = "colVorzeichen";
            this.colVorzeichen.Visible = true;
            this.colVorzeichen.VisibleIndex = 0;
            this.colVorzeichen.Width = 97;
            // 
            // colBgKostenartFreitext
            // 
            this.colBgKostenartFreitext.Caption = "LA";
            this.colBgKostenartFreitext.FieldName = "Leistungsart";
            this.colBgKostenartFreitext.Name = "colBgKostenartFreitext";
            this.colBgKostenartFreitext.Visible = true;
            this.colBgKostenartFreitext.VisibleIndex = 1;
            this.colBgKostenartFreitext.Width = 73;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            this.colBetrag.Width = 65;
            // 
            // edtBetragBudget
            // 
            this.edtBetragBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetragBudget.DataMember = "Betrag";
            this.edtBetragBudget.DataSource = this.qryWhDetailblattKorrekturPosition;
            this.edtBetragBudget.Location = new System.Drawing.Point(573, 90);
            this.edtBetragBudget.Name = "edtBetragBudget";
            this.edtBetragBudget.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragBudget.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragBudget.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragBudget.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragBudget.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragBudget.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragBudget.Properties.Appearance.Options.UseFont = true;
            this.edtBetragBudget.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragBudget.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragBudget.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBudget.Properties.EditFormat.FormatString = "n2";
            this.edtBetragBudget.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBudget.Properties.Mask.EditMask = "n2";
            this.edtBetragBudget.Size = new System.Drawing.Size(277, 24);
            this.edtBetragBudget.TabIndex = 6;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(3, 4);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(182, 23);
            this.lblTitel.TabIndex = 12;
            this.lblTitel.Text = "Ergänzungen";
            // 
            // CtlWhDetailblattKorrekturen
            // 
            this.ActiveSQLQuery = this.qryWhDetailblattKorrekturPosition;
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.edtBetragBudget);
            this.Controls.Add(this.grdWhDetailblattKorrekturen);
            this.Controls.Add(this.edtKorrekturtext);
            this.Controls.Add(this.edtLeistungsart);
            this.Controls.Add(this.edtKategorie);
            this.Controls.Add(this.edtVorzeichen);
            this.Controls.Add(this.lblKorrekturtext);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.lblLeistungsart);
            this.Controls.Add(this.lblKorrekturTyp);
            this.Name = "CtlWhDetailblattKorrekturen";
            this.Size = new System.Drawing.Size(876, 255);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhDetailblattKorrekturPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrekturTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrekturtext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorzeichen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorzeichen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKorrekturtext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWhDetailblattKorrekturen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWhDetailblattKorrekturen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBudget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DB.SqlQuery qryWhDetailblattKorrekturPosition;
        private Gui.KissLabel lblKorrekturTyp;
        private Gui.KissLabel lblLeistungsart;
        private Gui.KissLabel lblBetrag;
        private Gui.KissLabel lblKorrekturtext;
        private Gui.KissLookUpEdit edtKategorie;
        private Gui.KissLookUpEdit edtVorzeichen;
        private Gui.KissButtonEdit edtLeistungsart;
        private Gui.KissMemoEdit edtKorrekturtext;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private Gui.KissGrid grdWhDetailblattKorrekturen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWhDetailblattKorrekturen;
        private DevExpress.XtraGrid.Columns.GridColumn colVorzeichen;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKostenartFreitext;
        private DevExpress.XtraGrid.Columns.GridColumn colKorrekturtext;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBgKategorie;
        private Gui.KissCalcEdit edtBetragBudget;
        private Gui.KissLabel lblTitel;
    }
}
