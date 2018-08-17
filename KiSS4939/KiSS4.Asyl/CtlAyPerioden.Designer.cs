namespace KiSS4.Asyl
{
    partial class CtlAyPerioden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAyPerioden));
            this.grdBgFinanzplan = new KiSS4.Gui.KissGrid();
            this.qryBgFinanzplan = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgFinanzplan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUeB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGeplantVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeplantBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnthaeltMonatsbudgets = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgFinanzplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBgFinanzplan
            // 
            this.grdBgFinanzplan.DataSource = this.qryBgFinanzplan;
            this.grdBgFinanzplan.EmbeddedNavigator.Name = "";
            this.grdBgFinanzplan.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgFinanzplan.Location = new System.Drawing.Point(8, 48);
            this.grdBgFinanzplan.MainView = this.grvBgFinanzplan;
            this.grdBgFinanzplan.Name = "grdBgFinanzplan";
            this.grdBgFinanzplan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdBgFinanzplan.Size = new System.Drawing.Size(664, 464);
            this.grdBgFinanzplan.TabIndex = 0;
            this.grdBgFinanzplan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgFinanzplan});
            // 
            // qryBgFinanzplan
            // 
            this.qryBgFinanzplan.CanDelete = true;
            this.qryBgFinanzplan.CanInsert = true;
            this.qryBgFinanzplan.DeleteQuestion = "Soll dieses Masterbudget gelöscht werden ?";
            this.qryBgFinanzplan.HostControl = this;
            this.qryBgFinanzplan.SelectStatement = resources.GetString("qryBgFinanzplan.SelectStatement");
            this.qryBgFinanzplan.TableName = "BgFinanzplan";
            this.qryBgFinanzplan.BeforeDelete += new System.EventHandler(this.qryBgFinanzplan_BeforeDelete);
            this.qryBgFinanzplan.BeforeInsert += new System.EventHandler(this.qryBgFinanzplan_BeforeInsert);
            this.qryBgFinanzplan.AfterDelete += new System.EventHandler(this.qryBgFinanzplan_AfterDelete);
            // 
            // grvBgFinanzplan
            // 
            this.grvBgFinanzplan.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgFinanzplan.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.Empty.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgFinanzplan.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgFinanzplan.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgFinanzplan.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgFinanzplan.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgFinanzplan.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgFinanzplan.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgFinanzplan.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgFinanzplan.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgFinanzplan.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgFinanzplan.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgFinanzplan.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgFinanzplan.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgFinanzplan.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgFinanzplan.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.OddRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgFinanzplan.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.Row.Options.UseBackColor = true;
            this.grvBgFinanzplan.Appearance.Row.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgFinanzplan.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgFinanzplan.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgFinanzplan.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgFinanzplan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgFinanzplan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.colUeB,
            this.colGeplantVon,
            this.colGeplantBis,
            this.colGueltigVon,
            this.colGueltigBis,
            this.colHg,
            this.colUe,
            this.colEnthaeltMonatsbudgets});
            this.grvBgFinanzplan.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgFinanzplan.GridControl = this.grdBgFinanzplan;
            this.grvBgFinanzplan.Name = "grvBgFinanzplan";
            this.grvBgFinanzplan.OptionsBehavior.Editable = false;
            this.grvBgFinanzplan.OptionsCustomization.AllowFilter = false;
            this.grvBgFinanzplan.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgFinanzplan.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgFinanzplan.OptionsNavigation.UseTabKey = false;
            this.grvBgFinanzplan.OptionsView.ColumnAutoWidth = false;
            this.grvBgFinanzplan.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgFinanzplan.OptionsView.ShowGroupPanel = false;
            this.grvBgFinanzplan.OptionsView.ShowIndicator = false;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            this.colStatus.Width = 90;
            // 
            // colUeB
            // 
            this.colUeB.Caption = "ÜB";
            this.colUeB.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUeB.FieldName = "UB";
            this.colUeB.Name = "colUeB";
            this.colUeB.Visible = true;
            this.colUeB.VisibleIndex = 1;
            this.colUeB.Width = 30;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colGeplantVon
            // 
            this.colGeplantVon.Caption = "Geplant von";
            this.colGeplantVon.FieldName = "GeplantVon";
            this.colGeplantVon.Name = "colGeplantVon";
            this.colGeplantVon.Visible = true;
            this.colGeplantVon.VisibleIndex = 2;
            this.colGeplantVon.Width = 78;
            // 
            // colGeplantBis
            // 
            this.colGeplantBis.Caption = "Geplant bis";
            this.colGeplantBis.FieldName = "GeplantBis";
            this.colGeplantBis.Name = "colGeplantBis";
            this.colGeplantBis.Visible = true;
            this.colGeplantBis.VisibleIndex = 3;
            // 
            // colGueltigVon
            // 
            this.colGueltigVon.Caption = "Gültig von";
            this.colGueltigVon.FieldName = "DatumVon";
            this.colGueltigVon.Name = "colGueltigVon";
            this.colGueltigVon.Visible = true;
            this.colGueltigVon.VisibleIndex = 4;
            // 
            // colGueltigBis
            // 
            this.colGueltigBis.Caption = "Gültig bis";
            this.colGueltigBis.FieldName = "DatumBis";
            this.colGueltigBis.Name = "colGueltigBis";
            this.colGueltigBis.Visible = true;
            this.colGueltigBis.VisibleIndex = 5;
            // 
            // colHg
            // 
            this.colHg.AppearanceCell.Options.UseTextOptions = true;
            this.colHg.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHg.Caption = "Hg";
            this.colHg.FieldName = "Hg";
            this.colHg.Name = "colHg";
            this.colHg.Visible = true;
            this.colHg.VisibleIndex = 6;
            this.colHg.Width = 30;
            // 
            // colUe
            // 
            this.colUe.AppearanceCell.Options.UseTextOptions = true;
            this.colUe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUe.Caption = "Ue";
            this.colUe.FieldName = "Ue";
            this.colUe.Name = "colUe";
            this.colUe.Visible = true;
            this.colUe.VisibleIndex = 7;
            this.colUe.Width = 30;
            // 
            // colEnthaeltMonatsbudgets
            // 
            this.colEnthaeltMonatsbudgets.Caption = "enthält Monatsbudgets";
            this.colEnthaeltMonatsbudgets.FieldName = "FinanzPlaene";
            this.colEnthaeltMonatsbudgets.Name = "colEnthaeltMonatsbudgets";
            this.colEnthaeltMonatsbudgets.Visible = true;
            this.colEnthaeltMonatsbudgets.VisibleIndex = 8;
            this.colEnthaeltMonatsbudgets.Width = 177;
            // 
            // lblTitel
            // 
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Übersicht über die Masterbudgets";
            // 
            // kissLabel2
            // 
            this.kissLabel2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel2.Location = new System.Drawing.Point(8, 32);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(192, 16);
            this.kissLabel2.TabIndex = 2;
            this.kissLabel2.Text = "Masterbudgets";
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            // 
            // CtlAyPerioden
            // 
            this.ActiveSQLQuery = this.qryBgFinanzplan;
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdBgFinanzplan);
            this.Name = "CtlAyPerioden";
            this.Size = new System.Drawing.Size(680, 520);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgFinanzplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissGrid grdBgFinanzplan;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgFinanzplan;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel lblTitel;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUeB;
        private DevExpress.XtraGrid.Columns.GridColumn colGeplantVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGeplantBis;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigVon;
        private DevExpress.XtraGrid.Columns.GridColumn colGueltigBis;
        private DevExpress.XtraGrid.Columns.GridColumn colHg;
        private DevExpress.XtraGrid.Columns.GridColumn colUe;
        private DevExpress.XtraGrid.Columns.GridColumn colEnthaeltMonatsbudgets;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgFinanzplan;
    }
}
