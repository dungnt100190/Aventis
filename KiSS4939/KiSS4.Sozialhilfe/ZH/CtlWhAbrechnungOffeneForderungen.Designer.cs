namespace KiSS4.Sozialhilfe.ZH
{
    partial class CtlWhAbrechnungOffeneForderungen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlWhAbrechnungOffeneForderungen));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colGrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.qryWhAbrechnungOffeneForderung = new KiSS4.DB.SqlQuery(this.components);
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblGrund = new KiSS4.Gui.KissLabel();
            this.edtGrund = new KiSS4.Gui.KissMemoEdit();
            this.grdWhAbrechnungOffeneForderung = new KiSS4.Gui.KissGrid();
            this.grvWhAbrechnungOffeneForderung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBetragBudget = new KiSS4.Gui.KissCalcEdit();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhAbrechnungOffeneForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWhAbrechnungOffeneForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWhAbrechnungOffeneForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBudget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.SuspendLayout();
            // 
            // colGrund
            // 
            this.colGrund.Caption = "Grund";
            this.colGrund.FieldName = "Grund";
            this.colGrund.Name = "colGrund";
            this.colGrund.Visible = true;
            this.colGrund.VisibleIndex = 0;
            this.colGrund.Width = 162;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // qryWhAbrechnungOffeneForderung
            // 
            this.qryWhAbrechnungOffeneForderung.CanDelete = true;
            this.qryWhAbrechnungOffeneForderung.CanInsert = true;
            this.qryWhAbrechnungOffeneForderung.CanUpdate = true;
            this.qryWhAbrechnungOffeneForderung.HostControl = this;
            this.qryWhAbrechnungOffeneForderung.SelectStatement = resources.GetString("qryWhAbrechnungOffeneForderung.SelectStatement");
            this.qryWhAbrechnungOffeneForderung.TableName = "WhAbrechnungOffeneForderung";
            this.qryWhAbrechnungOffeneForderung.AfterInsert += new System.EventHandler(this.qryWhDetailblattKorrekturPosition_AfterInsert);
            this.qryWhAbrechnungOffeneForderung.BeforePost += new System.EventHandler(this.qryWhDetailblattKorrekturPosition_BeforePost);
            // 
            // lblBetrag
            // 
            this.lblBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetrag.Location = new System.Drawing.Point(467, 30);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(100, 23);
            this.lblBetrag.TabIndex = 5;
            this.lblBetrag.Text = "Betrag";
            // 
            // lblGrund
            // 
            this.lblGrund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrund.Location = new System.Drawing.Point(467, 60);
            this.lblGrund.Name = "lblGrund";
            this.lblGrund.Size = new System.Drawing.Size(100, 23);
            this.lblGrund.TabIndex = 7;
            this.lblGrund.Text = "Grund";
            // 
            // edtGrund
            // 
            this.edtGrund.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrund.DataMember = "Grund";
            this.edtGrund.DataSource = this.qryWhAbrechnungOffeneForderung;
            this.edtGrund.Location = new System.Drawing.Point(573, 60);
            this.edtGrund.Name = "edtGrund";
            this.edtGrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrund.Properties.Appearance.Options.UseFont = true;
            this.edtGrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrund.Size = new System.Drawing.Size(277, 185);
            this.edtGrund.TabIndex = 8;
            // 
            // grdWhAbrechnungOffeneForderung
            // 
            this.grdWhAbrechnungOffeneForderung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWhAbrechnungOffeneForderung.DataSource = this.qryWhAbrechnungOffeneForderung;
            // 
            // 
            // 
            this.grdWhAbrechnungOffeneForderung.EmbeddedNavigator.Name = "";
            this.grdWhAbrechnungOffeneForderung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdWhAbrechnungOffeneForderung.Location = new System.Drawing.Point(3, 30);
            this.grdWhAbrechnungOffeneForderung.MainView = this.grvWhAbrechnungOffeneForderung;
            this.grdWhAbrechnungOffeneForderung.Name = "grdWhAbrechnungOffeneForderung";
            this.grdWhAbrechnungOffeneForderung.Size = new System.Drawing.Size(458, 215);
            this.grdWhAbrechnungOffeneForderung.TabIndex = 10;
            this.grdWhAbrechnungOffeneForderung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWhAbrechnungOffeneForderung});
            // 
            // grvWhAbrechnungOffeneForderung
            // 
            this.grvWhAbrechnungOffeneForderung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvWhAbrechnungOffeneForderung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.Empty.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.Empty.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.EvenRow.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupRow.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvWhAbrechnungOffeneForderung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvWhAbrechnungOffeneForderung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvWhAbrechnungOffeneForderung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvWhAbrechnungOffeneForderung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvWhAbrechnungOffeneForderung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvWhAbrechnungOffeneForderung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.OddRow.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvWhAbrechnungOffeneForderung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.Row.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.Row.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvWhAbrechnungOffeneForderung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvWhAbrechnungOffeneForderung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvWhAbrechnungOffeneForderung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvWhAbrechnungOffeneForderung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvWhAbrechnungOffeneForderung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGrund,
            this.colBetrag});
            this.grvWhAbrechnungOffeneForderung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition1.Appearance.Options.HighPriority = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colGrund;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "1";
            styleFormatCondition2.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition2.Appearance.Options.HighPriority = true;
            styleFormatCondition2.Appearance.Options.UseFont = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colGrund;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "2";
            styleFormatCondition3.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition3.Appearance.Options.HighPriority = true;
            styleFormatCondition3.Appearance.Options.UseFont = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colGrund;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "3";
            this.grvWhAbrechnungOffeneForderung.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
            this.grvWhAbrechnungOffeneForderung.GridControl = this.grdWhAbrechnungOffeneForderung;
            this.grvWhAbrechnungOffeneForderung.GroupFormat = "[#image]{1} {2}";
            this.grvWhAbrechnungOffeneForderung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvWhAbrechnungOffeneForderung.Name = "grvWhAbrechnungOffeneForderung";
            this.grvWhAbrechnungOffeneForderung.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvWhAbrechnungOffeneForderung.OptionsBehavior.Editable = false;
            this.grvWhAbrechnungOffeneForderung.OptionsCustomization.AllowFilter = false;
            this.grvWhAbrechnungOffeneForderung.OptionsCustomization.AllowSort = false;
            this.grvWhAbrechnungOffeneForderung.OptionsFilter.AllowFilterEditor = false;
            this.grvWhAbrechnungOffeneForderung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvWhAbrechnungOffeneForderung.OptionsMenu.EnableColumnMenu = false;
            this.grvWhAbrechnungOffeneForderung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvWhAbrechnungOffeneForderung.OptionsNavigation.UseTabKey = false;
            this.grvWhAbrechnungOffeneForderung.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvWhAbrechnungOffeneForderung.OptionsSelection.UseIndicatorForSelection = false;
            this.grvWhAbrechnungOffeneForderung.OptionsView.ColumnAutoWidth = false;
            this.grvWhAbrechnungOffeneForderung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvWhAbrechnungOffeneForderung.OptionsView.ShowGroupPanel = false;
            this.grvWhAbrechnungOffeneForderung.OptionsView.ShowIndicator = false;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 1;
            this.colBetrag.Width = 65;
            // 
            // edtBetragBudget
            // 
            this.edtBetragBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetragBudget.DataMember = "Betrag";
            this.edtBetragBudget.DataSource = this.qryWhAbrechnungOffeneForderung;
            this.edtBetragBudget.Location = new System.Drawing.Point(573, 30);
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
            this.lblTitel.TabIndex = 11;
            this.lblTitel.Text = "Offene Forderungen";
            // 
            // CtlWhAbrechnungOffeneForderungen
            // 
            this.ActiveSQLQuery = this.qryWhAbrechnungOffeneForderung;
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.edtBetragBudget);
            this.Controls.Add(this.grdWhAbrechnungOffeneForderung);
            this.Controls.Add(this.edtGrund);
            this.Controls.Add(this.lblGrund);
            this.Controls.Add(this.lblBetrag);
            this.Name = "CtlWhAbrechnungOffeneForderungen";
            this.Size = new System.Drawing.Size(876, 255);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryWhAbrechnungOffeneForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWhAbrechnungOffeneForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWhAbrechnungOffeneForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBudget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DB.SqlQuery qryWhAbrechnungOffeneForderung;
        private Gui.KissLabel lblBetrag;
        private Gui.KissLabel lblGrund;
        private Gui.KissMemoEdit edtGrund;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private Gui.KissGrid grdWhAbrechnungOffeneForderung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWhAbrechnungOffeneForderung;
        private DevExpress.XtraGrid.Columns.GridColumn colGrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private Gui.KissCalcEdit edtBetragBudget;
        private Gui.KissLabel lblTitel;
    }
}
