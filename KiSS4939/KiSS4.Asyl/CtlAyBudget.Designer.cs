namespace KiSS4.Asyl
{
    partial class CtlAyBudget
    {
        private System.ComponentModel.IContainer components = null;

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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAyBudget));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition6 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.grvKbBuchungKostenart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKbBuchungKostenart_Betrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchungKostenart_Buchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchungKostenart_BgKostenartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchungKostenart_Kostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchungKostenart_KbBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKbBuchung = new KiSS4.Gui.KissGrid();
            this.qryKbBuchung = new KiSS4.DB.SqlQuery(this.components);
            this.grvKbBuchung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKbBuchung_KbBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_Betrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_ValutaDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_BarbelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_Text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_BeguenstigtName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_BankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_KbBuchungStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_KbAuszahlungsArtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_Belegnummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_ErstelltDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbBuchung_TransferDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStyle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.panGrid = new System.Windows.Forms.Panel();
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsmodus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbtretung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbtretung_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imgToolbar = new System.Windows.Forms.ImageList(this.components);
            this.panToolbar = new System.Windows.Forms.Panel();
            this.toolBarBudget = new System.Windows.Forms.ToolBar();
            this.tbnNew = new System.Windows.Forms.ToolBarButton();
            this.tbnReset = new System.Windows.Forms.ToolBarButton();
            this.tsp = new System.Windows.Forms.ToolBarButton();
            this.tbnVorbereitung = new System.Windows.Forms.ToolBarButton();
            this.tbnBewilligt = new System.Windows.Forms.ToolBarButton();
            this.tbnGesperrt = new System.Windows.Forms.ToolBarButton();
            this.tsp1 = new System.Windows.Forms.ToolBarButton();
            this.tbnButget = new System.Windows.Forms.ToolBarButton();
            this.tbnBelege = new System.Windows.Forms.ToolBarButton();
            this.tsp2 = new System.Windows.Forms.ToolBarButton();
            this.tbnNeu = new System.Windows.Forms.ToolBarButton();
            this.cMnuNeu = new System.Windows.Forms.ContextMenu();
            this.mnuNeu_Einnahme = new System.Windows.Forms.MenuItem();
            this.mnuNeu_Ausgaben = new System.Windows.Forms.MenuItem();
            this.mnuNeu_Vorabzug = new System.Windows.Forms.MenuItem();
            this.mnuNeu_Kuerzung = new System.Windows.Forms.MenuItem();
            this.mnuNeu_Einzelzahlung = new System.Windows.Forms.MenuItem();
            this.tsp3 = new System.Windows.Forms.ToolBarButton();
            this.tbnBewilligung = new System.Windows.Forms.ToolBarButton();
            this.qryBgBudget = new KiSS4.DB.SqlQuery(this.components);
            this.edtBgBudgetID = new KiSS4.Gui.KissCalcEdit();
            this.lblBgBudgetID = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            this.panGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colAbtretung_Edit)).BeginInit();
            this.panToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBudgetID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBudgetID)).BeginInit();
            this.SuspendLayout();
            //
            // grvKbBuchungKostenart
            //
            this.grvKbBuchungKostenart.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.grvKbBuchungKostenart.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKbBuchungKostenart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvKbBuchungKostenart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.OddRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungKostenart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungKostenart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKbBuchungKostenart_Betrag,
            this.colKbBuchungKostenart_Buchungstext,
            this.colKbBuchungKostenart_BgKostenartID,
            this.colKbBuchungKostenart_Kostenstelle,
            this.colKbBuchungKostenart_KbBuchungID});
            this.grvKbBuchungKostenart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungKostenart.GridControl = this.grdKbBuchung;
            this.grvKbBuchungKostenart.Name = "grvKbBuchungKostenart";
            this.grvKbBuchungKostenart.OptionsBehavior.Editable = false;
            this.grvKbBuchungKostenart.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungKostenart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungKostenart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungKostenart.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungKostenart.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungKostenart.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungKostenart.OptionsView.ShowIndicator = false;
            //
            // colKbBuchungKostenart_Betrag
            //
            this.colKbBuchungKostenart_Betrag.Caption = "Betrag";
            this.colKbBuchungKostenart_Betrag.DisplayFormat.FormatString = "n2";
            this.colKbBuchungKostenart_Betrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKbBuchungKostenart_Betrag.FieldName = "Betrag";
            this.colKbBuchungKostenart_Betrag.Name = "colKbBuchungKostenart_Betrag";
            this.colKbBuchungKostenart_Betrag.Visible = true;
            this.colKbBuchungKostenart_Betrag.VisibleIndex = 0;
            this.colKbBuchungKostenart_Betrag.Width = 96;
            //
            // colKbBuchungKostenart_Buchungstext
            //
            this.colKbBuchungKostenart_Buchungstext.Caption = "Text";
            this.colKbBuchungKostenart_Buchungstext.FieldName = "Buchungstext";
            this.colKbBuchungKostenart_Buchungstext.Name = "colKbBuchungKostenart_Buchungstext";
            this.colKbBuchungKostenart_Buchungstext.Visible = true;
            this.colKbBuchungKostenart_Buchungstext.VisibleIndex = 1;
            this.colKbBuchungKostenart_Buchungstext.Width = 200;
            //
            // colKbBuchungKostenart_BgKostenartID
            //
            this.colKbBuchungKostenart_BgKostenartID.Caption = "Kostenart";
            this.colKbBuchungKostenart_BgKostenartID.FieldName = "BgKostenartID";
            this.colKbBuchungKostenart_BgKostenartID.Name = "colKbBuchungKostenart_BgKostenartID";
            this.colKbBuchungKostenart_BgKostenartID.Visible = true;
            this.colKbBuchungKostenart_BgKostenartID.VisibleIndex = 2;
            this.colKbBuchungKostenart_BgKostenartID.Width = 150;
            //
            // colKbBuchungKostenart_Kostenstelle
            //
            this.colKbBuchungKostenart_Kostenstelle.Caption = "Kostenstelle";
            this.colKbBuchungKostenart_Kostenstelle.FieldName = "Kostenstelle";
            this.colKbBuchungKostenart_Kostenstelle.Name = "colKbBuchungKostenart_Kostenstelle";
            this.colKbBuchungKostenart_Kostenstelle.Visible = true;
            this.colKbBuchungKostenart_Kostenstelle.VisibleIndex = 3;
            this.colKbBuchungKostenart_Kostenstelle.Width = 200;
            //
            // colKbBuchungKostenart_KbBuchungID
            //
            this.colKbBuchungKostenart_KbBuchungID.Caption = "Fibu Belegnummer";
            this.colKbBuchungKostenart_KbBuchungID.FieldName = "KbBuchungID";
            this.colKbBuchungKostenart_KbBuchungID.Name = "colKbBuchungKostenart_KbBuchungID";
            //
            // grdKbBuchung
            //
            this.grdKbBuchung.DataSource = this.qryKbBuchung;
            this.grdKbBuchung.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdKbBuchung.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.grvKbBuchungKostenart;
            gridLevelNode1.RelationName = "BelegDetail";
            this.grdKbBuchung.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdKbBuchung.Location = new System.Drawing.Point(0, 225);
            this.grdKbBuchung.MainView = this.grvKbBuchung;
            this.grdKbBuchung.Name = "grdKbBuchung";
            this.grdKbBuchung.Size = new System.Drawing.Size(664, 231);
            this.grdKbBuchung.Styles.AddReplace("FlBelegStatus_Gesperrt", new DevExpress.Utils.ViewStyleEx("FlBelegStatus_Gesperrt", "", new System.Drawing.Font("Microsoft Sans Serif", 8F), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.DarkGray, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdKbBuchung.Styles.AddReplace("FlBelegStatus_Fehler", new DevExpress.Utils.ViewStyleEx("FlBelegStatus_Fehler", "", new System.Drawing.Font("Microsoft Sans Serif", 8F), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.LightCoral, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdKbBuchung.Styles.AddReplace("FlBelegStatus_Warnung", new DevExpress.Utils.ViewStyleEx("FlBelegStatus_Warnung", "", new System.Drawing.Font("Microsoft Sans Serif", 8F), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.Gold, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdKbBuchung.Styles.AddReplace("StyleCenter", new DevExpress.Utils.ViewStyleEx("StyleCenter", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdKbBuchung.Styles.AddReplace("StyleFar", new DevExpress.Utils.ViewStyleEx("StyleFar", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdKbBuchung.Styles.AddReplace("StyleNear", new DevExpress.Utils.ViewStyleEx("StyleNear", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdKbBuchung.Styles.AddReplace("FlBelegStatus_Verbucht", new DevExpress.Utils.ViewStyleEx("FlBelegStatus_Verbucht", "", new System.Drawing.Font("Microsoft Sans Serif", 8F), DevExpress.Utils.StyleOptions.UseBackColor, System.Drawing.Color.PaleGreen, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdKbBuchung.TabIndex = 0;
            this.grdKbBuchung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchung,
            this.grvKbBuchungKostenart});
            //
            // qryKbBuchung
            //
            this.qryKbBuchung.SelectStatement = resources.GetString("qryKbBuchung.SelectStatement");
            this.qryKbBuchung.AfterFill += new System.EventHandler(this.qryKbBuchung_AfterFill);
            //
            // grvKbBuchung
            //
            this.grvKbBuchung.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.grvKbBuchung.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKbBuchung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvKbBuchung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.OddRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchung.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBuchung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKbBuchung_KbBuchungID,
            this.colKbBuchung_Betrag,
            this.colKbBuchung_ValutaDatum,
            this.colKbBuchung_BarbelegDatum,
            this.colKbBuchung_Text,
            this.colKbBuchung_BeguenstigtName,
            this.colKbBuchung_BankName,
            this.colKbBuchung_KbBuchungStatusCode,
            this.colKbBuchung_KbAuszahlungsArtCode,
            this.colKbBuchung_Belegnummer,
            this.colKbBuchung_ErstelltDatum,
            this.colKbBuchung_TransferDatum});
            this.grvKbBuchung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.PaleGreen;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colKbBuchung_KbBuchungStatusCode;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = 102;
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Gold;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colKbBuchung_KbBuchungStatusCode;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = 103;
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.LightCoral;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colKbBuchung_KbBuchungStatusCode;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "104";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.DarkGray;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Column = this.colKbBuchung_KbBuchungStatusCode;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition4.Value1 = "106";
            this.grvKbBuchung.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4});
            this.grvKbBuchung.GridControl = this.grdKbBuchung;
            this.grvKbBuchung.Name = "grvKbBuchung";
            this.grvKbBuchung.OptionsBehavior.Editable = false;
            this.grvKbBuchung.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchung.OptionsDetail.ShowDetailTabs = false;
            this.grvKbBuchung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchung.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchung.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchung.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvKbBuchung.OptionsView.ShowFooter = true;
            this.grvKbBuchung.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchung.OptionsView.ShowIndicator = false;
            //
            // colKbBuchung_KbBuchungID
            //
            this.colKbBuchung_KbBuchungID.AppearanceCell.Options.UseTextOptions = true;
            this.colKbBuchung_KbBuchungID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colKbBuchung_KbBuchungID.FieldName = "KbBuchungID";
            this.colKbBuchung_KbBuchungID.MinWidth = 10;
            this.colKbBuchung_KbBuchungID.Name = "colKbBuchung_KbBuchungID";
            this.colKbBuchung_KbBuchungID.Visible = true;
            this.colKbBuchung_KbBuchungID.VisibleIndex = 0;
            this.colKbBuchung_KbBuchungID.Width = 10;
            //
            // colKbBuchung_Betrag
            //
            this.colKbBuchung_Betrag.AppearanceCell.Options.UseTextOptions = true;
            this.colKbBuchung_Betrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colKbBuchung_Betrag.Caption = "Betrag";
            this.colKbBuchung_Betrag.DisplayFormat.FormatString = "n2";
            this.colKbBuchung_Betrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKbBuchung_Betrag.FieldName = "Betrag";
            this.colKbBuchung_Betrag.Name = "colKbBuchung_Betrag";
            this.colKbBuchung_Betrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colKbBuchung_Betrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colKbBuchung_Betrag.Visible = true;
            this.colKbBuchung_Betrag.VisibleIndex = 1;
            //
            // colKbBuchung_ValutaDatum
            //
            this.colKbBuchung_ValutaDatum.Caption = "Fällig";
            this.colKbBuchung_ValutaDatum.FieldName = "ValutaDatum";
            this.colKbBuchung_ValutaDatum.Name = "colKbBuchung_ValutaDatum";
            this.colKbBuchung_ValutaDatum.Visible = true;
            this.colKbBuchung_ValutaDatum.VisibleIndex = 2;
            this.colKbBuchung_ValutaDatum.Width = 96;
            //
            // colKbBuchung_BarbelegDatum
            //
            this.colKbBuchung_BarbelegDatum.Caption = "Ausbezahlt am";
            this.colKbBuchung_BarbelegDatum.FieldName = "BarbelegDatum";
            this.colKbBuchung_BarbelegDatum.Name = "colKbBuchung_BarbelegDatum";
            this.colKbBuchung_BarbelegDatum.Visible = true;
            this.colKbBuchung_BarbelegDatum.VisibleIndex = 3;
            this.colKbBuchung_BarbelegDatum.Width = 92;
            //
            // colKbBuchung_Text
            //
            this.colKbBuchung_Text.Caption = "Buchungstext";
            this.colKbBuchung_Text.FieldName = "Text";
            this.colKbBuchung_Text.Name = "colKbBuchung_Text";
            this.colKbBuchung_Text.Visible = true;
            this.colKbBuchung_Text.VisibleIndex = 4;
            this.colKbBuchung_Text.Width = 135;
            //
            // colKbBuchung_BeguenstigtName
            //
            this.colKbBuchung_BeguenstigtName.Caption = "Kreditor";
            this.colKbBuchung_BeguenstigtName.FieldName = "BeguenstigtName";
            this.colKbBuchung_BeguenstigtName.Name = "colKbBuchung_BeguenstigtName";
            this.colKbBuchung_BeguenstigtName.Visible = true;
            this.colKbBuchung_BeguenstigtName.VisibleIndex = 5;
            this.colKbBuchung_BeguenstigtName.Width = 102;
            //
            // colKbBuchung_BankName
            //
            this.colKbBuchung_BankName.Caption = "Bank";
            this.colKbBuchung_BankName.FieldName = "BankName";
            this.colKbBuchung_BankName.Name = "colKbBuchung_BankName";
            this.colKbBuchung_BankName.Visible = true;
            this.colKbBuchung_BankName.VisibleIndex = 6;
            this.colKbBuchung_BankName.Width = 98;
            //
            // colKbBuchung_KbBuchungStatusCode
            //
            this.colKbBuchung_KbBuchungStatusCode.Caption = "Belegstatus";
            this.colKbBuchung_KbBuchungStatusCode.FieldName = "KbBuchungStatusCode";
            this.colKbBuchung_KbBuchungStatusCode.Name = "colKbBuchung_KbBuchungStatusCode";
            this.colKbBuchung_KbBuchungStatusCode.Visible = true;
            this.colKbBuchung_KbBuchungStatusCode.VisibleIndex = 7;
            //
            // colKbBuchung_KbAuszahlungsArtCode
            //
            this.colKbBuchung_KbAuszahlungsArtCode.Caption = "Auszahlungsart";
            this.colKbBuchung_KbAuszahlungsArtCode.FieldName = "KbAuszahlungsArtCode";
            this.colKbBuchung_KbAuszahlungsArtCode.Name = "colKbBuchung_KbAuszahlungsArtCode";
            this.colKbBuchung_KbAuszahlungsArtCode.Visible = true;
            this.colKbBuchung_KbAuszahlungsArtCode.VisibleIndex = 8;
            //
            // colKbBuchung_Belegnummer
            //
            this.colKbBuchung_Belegnummer.Caption = "Fibu Belegnummer";
            this.colKbBuchung_Belegnummer.FieldName = "Belegnummer";
            this.colKbBuchung_Belegnummer.Name = "colKbBuchung_Belegnummer";
            this.colKbBuchung_Belegnummer.Visible = true;
            this.colKbBuchung_Belegnummer.VisibleIndex = 9;
            //
            // colKbBuchung_ErstelltDatum
            //
            this.colKbBuchung_ErstelltDatum.Caption = "Generiert am";
            this.colKbBuchung_ErstelltDatum.FieldName = "ErstelltDatum";
            this.colKbBuchung_ErstelltDatum.Name = "colKbBuchung_ErstelltDatum";
            this.colKbBuchung_ErstelltDatum.Visible = true;
            this.colKbBuchung_ErstelltDatum.VisibleIndex = 10;
            //
            // colKbBuchung_TransferDatum
            //
            this.colKbBuchung_TransferDatum.Caption = "in Fibu übertragen am";
            this.colKbBuchung_TransferDatum.FieldName = "TransferDatum";
            this.colKbBuchung_TransferDatum.Name = "colKbBuchung_TransferDatum";
            this.colKbBuchung_TransferDatum.Visible = true;
            this.colKbBuchung_TransferDatum.VisibleIndex = 11;
            //
            // colStyle
            //
            this.colStyle.Caption = "Style";
            this.colStyle.FieldName = "Style";
            this.colStyle.Name = "colStyle";
            this.colStyle.Width = 253;
            //
            // lblTitel
            //
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(30, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(641, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Masterbudget";
            //
            // qryBgPosition
            //
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            //
            // panGrid
            //
            this.panGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panGrid.Controls.Add(this.grdBgPosition);
            this.panGrid.Controls.Add(this.grdKbBuchung);
            this.panGrid.Location = new System.Drawing.Point(8, 56);
            this.panGrid.Name = "panGrid";
            this.panGrid.Size = new System.Drawing.Size(664, 456);
            this.panGrid.TabIndex = 2;
            //
            // grdBgPosition
            //
            this.grdBgPosition.DataSource = this.qryBgPosition;
            this.grdBgPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.Location = new System.Drawing.Point(0, 0);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colAbtretung_Edit});
            this.grdBgPosition.Size = new System.Drawing.Size(664, 225);
            this.grdBgPosition.Styles.AddReplace("StyleFar", new DevExpress.Utils.ViewStyleEx("StyleFar", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdBgPosition.Styles.AddReplace("StyleNear", new DevExpress.Utils.ViewStyleEx("StyleNear", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdBgPosition.Styles.AddReplace("StyleCenter", new DevExpress.Utils.ViewStyleEx("StyleCenter", null, new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdBgPosition.TabIndex = 1;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            this.grdBgPosition.DoubleClick += new System.EventHandler(this.grdBudget_DoubleClick);
            //
            // grvBgPosition
            //
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStyle,
            this.colBezeichnung,
            this.colBetrag,
            this.colTotal,
            this.colKOA,
            this.colZahlungsmodus,
            this.colAbtretung,
            this.colBemerkung});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition5.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition5.Appearance.Options.UseFont = true;
            styleFormatCondition5.ApplyToRow = true;
            styleFormatCondition5.Column = this.colStyle;
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition5.Value1 = 1;
            styleFormatCondition6.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            styleFormatCondition6.Appearance.Options.UseFont = true;
            styleFormatCondition6.ApplyToRow = true;
            styleFormatCondition6.Column = this.colStyle;
            styleFormatCondition6.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition6.Value1 = 2;
            this.grvBgPosition.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition5,
            styleFormatCondition6});
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsCustomization.AllowGroup = false;
            this.grvBgPosition.OptionsCustomization.AllowSort = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            this.grvBgPosition.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvBgPosition_RowCellStyle);
            //
            // colBezeichnung
            //
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "Bezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 0;
            this.colBezeichnung.Width = 242;
            //
            // colBetrag
            //
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 1;
            this.colBetrag.Width = 78;
            //
            // colTotal
            //
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 2;
            //
            // colKOA
            //
            this.colKOA.Caption = "KOA";
            this.colKOA.FieldName = "KOA";
            this.colKOA.Name = "colKOA";
            this.colKOA.Visible = true;
            this.colKOA.VisibleIndex = 3;
            this.colKOA.Width = 36;
            //
            // colZahlungsmodus
            //
            this.colZahlungsmodus.Caption = "Zahlungsmodus";
            this.colZahlungsmodus.FieldName = "Zahlungsmodus";
            this.colZahlungsmodus.Name = "colZahlungsmodus";
            this.colZahlungsmodus.Visible = true;
            this.colZahlungsmodus.VisibleIndex = 4;
            this.colZahlungsmodus.Width = 117;
            //
            // colAbtretung
            //
            this.colAbtretung.Caption = "Abtr. AK";
            this.colAbtretung.ColumnEdit = this.colAbtretung_Edit;
            this.colAbtretung.FieldName = "Abtretung";
            this.colAbtretung.Name = "colAbtretung";
            this.colAbtretung.Visible = true;
            this.colAbtretung.VisibleIndex = 5;
            this.colAbtretung.Width = 58;
            //
            // colAbtretung_Edit
            //
            this.colAbtretung_Edit.AutoHeight = false;
            this.colAbtretung_Edit.Name = "colAbtretung_Edit";
            //
            // colBemerkung
            //
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 6;
            this.colBemerkung.Width = 322;
            //
            // imgToolbar
            //
            this.imgToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgToolbar.ImageStream")));
            this.imgToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgToolbar.Images.SetKeyName(0, "");
            this.imgToolbar.Images.SetKeyName(1, "");
            this.imgToolbar.Images.SetKeyName(2, "");
            this.imgToolbar.Images.SetKeyName(3, "");
            this.imgToolbar.Images.SetKeyName(4, "");
            this.imgToolbar.Images.SetKeyName(5, "");
            this.imgToolbar.Images.SetKeyName(6, "");
            this.imgToolbar.Images.SetKeyName(7, "");
            this.imgToolbar.Images.SetKeyName(8, "");
            this.imgToolbar.Images.SetKeyName(9, "");
            //
            // panToolbar
            //
            this.panToolbar.Controls.Add(this.toolBarBudget);
            this.panToolbar.Location = new System.Drawing.Point(8, 32);
            this.panToolbar.Name = "panToolbar";
            this.panToolbar.Size = new System.Drawing.Size(664, 26);
            this.panToolbar.TabIndex = 1;
            //
            // toolBarBudget
            //
            this.toolBarBudget.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBarBudget.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbnNew,
            this.tbnReset,
            this.tsp,
            this.tbnVorbereitung,
            this.tbnBewilligt,
            this.tbnGesperrt,
            this.tsp1,
            this.tbnButget,
            this.tbnBelege,
            this.tsp2,
            this.tbnNeu,
            this.tsp3,
            this.tbnBewilligung});
            this.toolBarBudget.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolBarBudget.DropDownArrows = true;
            this.toolBarBudget.ImageList = this.imgToolbar;
            this.toolBarBudget.Location = new System.Drawing.Point(0, -2);
            this.toolBarBudget.Name = "toolBarBudget";
            this.toolBarBudget.ShowToolTips = true;
            this.toolBarBudget.Size = new System.Drawing.Size(664, 28);
            this.toolBarBudget.TabIndex = 0;
            this.toolBarBudget.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBarBudget_ButtonClick);
            //
            // tbnNew
            //
            this.tbnNew.ImageIndex = 0;
            this.tbnNew.Name = "tbnNew";
            this.tbnNew.ToolTipText = "Neues Monatsbudget erstellen";
            //
            // tbnReset
            //
            this.tbnReset.ImageIndex = 1;
            this.tbnReset.Name = "tbnReset";
            this.tbnReset.ToolTipText = "Budget zurücksetzen";
            //
            // tsp
            //
            this.tsp.Name = "tsp";
            this.tsp.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnVorbereitung
            //
            this.tbnVorbereitung.ImageIndex = 2;
            this.tbnVorbereitung.Name = "tbnVorbereitung";
            this.tbnVorbereitung.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnVorbereitung.ToolTipText = "Planung";
            //
            // tbnBewilligt
            //
            this.tbnBewilligt.ImageIndex = 3;
            this.tbnBewilligt.Name = "tbnBewilligt";
            this.tbnBewilligt.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnBewilligt.ToolTipText = "Bewilligt";
            //
            // tbnGesperrt
            //
            this.tbnGesperrt.ImageIndex = 4;
            this.tbnGesperrt.Name = "tbnGesperrt";
            this.tbnGesperrt.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnGesperrt.ToolTipText = "Gesperrt";
            //
            // tsp1
            //
            this.tsp1.Name = "tsp1";
            this.tsp1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnButget
            //
            this.tbnButget.ImageIndex = 5;
            this.tbnButget.Name = "tbnButget";
            this.tbnButget.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnButget.ToolTipText = "Budget anzeigen";
            //
            // tbnBelege
            //
            this.tbnBelege.ImageIndex = 6;
            this.tbnBelege.Name = "tbnBelege";
            this.tbnBelege.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnBelege.ToolTipText = "Belege anzeigen";
            //
            // tsp2
            //
            this.tsp2.Name = "tsp2";
            this.tsp2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnNeu
            //
            this.tbnNeu.DropDownMenu = this.cMnuNeu;
            this.tbnNeu.ImageIndex = 7;
            this.tbnNeu.Name = "tbnNeu";
            this.tbnNeu.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbnNeu.ToolTipText = "Budgetposition einfügen";
            //
            // cMnuNeu
            //
            this.cMnuNeu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNeu_Einnahme,
            this.mnuNeu_Ausgaben,
            this.mnuNeu_Vorabzug,
            this.mnuNeu_Kuerzung,
            this.mnuNeu_Einzelzahlung});
            //
            // mnuNeu_Einnahme
            //
            this.mnuNeu_Einnahme.Index = 0;
            this.mnuNeu_Einnahme.Text = "Einnahme";
            this.mnuNeu_Einnahme.Click += new System.EventHandler(this.mnuNeu_Click);
            //
            // mnuNeu_Ausgaben
            //
            this.mnuNeu_Ausgaben.Index = 1;
            this.mnuNeu_Ausgaben.Text = "Ausgabe";
            this.mnuNeu_Ausgaben.Click += new System.EventHandler(this.mnuNeu_Click);
            //
            // mnuNeu_Vorabzug
            //
            this.mnuNeu_Vorabzug.Index = 2;
            this.mnuNeu_Vorabzug.Text = "Vorabzug";
            this.mnuNeu_Vorabzug.Click += new System.EventHandler(this.mnuNeu_Click);
            //
            // mnuNeu_Kuerzung
            //
            this.mnuNeu_Kuerzung.Index = 3;
            this.mnuNeu_Kuerzung.Text = "Kürzung";
            this.mnuNeu_Kuerzung.Click += new System.EventHandler(this.mnuNeu_Click);
            //
            // mnuNeu_Einzelzahlung
            //
            this.mnuNeu_Einzelzahlung.Index = 4;
            this.mnuNeu_Einzelzahlung.Text = "Einzelzahlung";
            this.mnuNeu_Einzelzahlung.Click += new System.EventHandler(this.mnuNeu_Einzelzahlung_Click);
            //
            // tsp3
            //
            this.tsp3.Name = "tsp3";
            this.tsp3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnBewilligung
            //
            this.tbnBewilligung.ImageIndex = 9;
            this.tbnBewilligung.Name = "tbnBewilligung";
            this.tbnBewilligung.ToolTipText = "Verlauf anzeigen";
            //
            // qryBgBudget
            //
            this.qryBgBudget.CanDelete = true;
            this.qryBgBudget.CanInsert = true;
            this.qryBgBudget.CanUpdate = true;
            this.qryBgBudget.HostControl = this;
            this.qryBgBudget.SelectStatement = @"SELECT BDG.BgBudgetID, BDG.BgBewilligungStatusCode, BDG.BgFinanzplanID, BDG.Jahr, BDG.Monat, BDG.Bemerkung, BDG.OldID, BDG.MasterBudget FROM dbo.BgBudget BDG WITH (READUNCOMMITTED) WHERE BDG.BgBudgetID = {0}";
            this.qryBgBudget.TableName = "BgBudget";
            this.qryBgBudget.BeforePost += new System.EventHandler(this.qryBgBudget_BeforePost);
            this.qryBgBudget.PositionChanged += new System.EventHandler(this.qryBgBudget_PositionChanged);
            this.qryBgBudget.BeforeInsert += new System.EventHandler(this.qryBgBudget_BeforeInsert);
            this.qryBgBudget.BeforeDeleteQuestion += new System.EventHandler(this.qryBgBudget_BeforeDeleteQuestion);
            this.qryBgBudget.AfterPost += new System.EventHandler(this.qryBgBudget_AfterPost);
            //
            // edtBgBudgetID
            //
            this.edtBgBudgetID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBgBudgetID.DataMember = "BgBudgetID";
            this.edtBgBudgetID.DataSource = this.qryBgBudget;
            this.edtBgBudgetID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgBudgetID.Location = new System.Drawing.Point(592, 27);
            this.edtBgBudgetID.Name = "edtBgBudgetID";
            this.edtBgBudgetID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBgBudgetID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgBudgetID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgBudgetID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgBudgetID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgBudgetID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgBudgetID.Properties.Appearance.Options.UseFont = true;
            this.edtBgBudgetID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgBudgetID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgBudgetID.Properties.ReadOnly = true;
            this.edtBgBudgetID.Size = new System.Drawing.Size(79, 24);
            this.edtBgBudgetID.TabIndex = 10;
            this.edtBgBudgetID.TabStop = false;
            //
            // lblBgBudgetID
            //
            this.lblBgBudgetID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBgBudgetID.Location = new System.Drawing.Point(534, 27);
            this.lblBgBudgetID.Name = "lblBgBudgetID";
            this.lblBgBudgetID.Size = new System.Drawing.Size(52, 24);
            this.lblBgBudgetID.TabIndex = 9;
            this.lblBgBudgetID.Text = "Budget-Nr.";
            this.lblBgBudgetID.UseCompatibleTextRendering = true;
            //
            // CtlAyBudget
            //
            this.ActiveSQLQuery = this.qryBgBudget;
            this.Controls.Add(this.edtBgBudgetID);
            this.Controls.Add(this.lblBgBudgetID);
            this.Controls.Add(this.panGrid);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.panToolbar);
            this.Name = "CtlAyBudget";
            this.Size = new System.Drawing.Size(680, 520);
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            this.panGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colAbtretung_Edit)).EndInit();
            this.panToolbar.ResumeLayout(false);
            this.panToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBudgetID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBudgetID)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ContextMenu cMnuNeu;
        private DevExpress.XtraGrid.Columns.GridColumn colAbtretung;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colAbtretung_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_BankName;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_BarbelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_BeguenstigtName;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_Belegnummer;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_Betrag;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_ErstelltDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_KbAuszahlungsArtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_KbBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_KbBuchungStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_Text;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_TransferDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchung_ValutaDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungKostenart_Betrag;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungKostenart_BgKostenartID;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungKostenart_Buchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungKostenart_KbBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungKostenart_Kostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colKOA;
        private DevExpress.XtraGrid.Columns.GridColumn colStyle;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsmodus;
        private KiSS4.Gui.KissCalcEdit edtBgBudgetID;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private KiSS4.Gui.KissGrid grdKbBuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungKostenart;
        private System.Windows.Forms.ImageList imgToolbar;
        private KiSS4.Gui.KissLabel lblBgBudgetID;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.MenuItem mnuNeu_Ausgaben;
        private System.Windows.Forms.MenuItem mnuNeu_Einnahme;
        private System.Windows.Forms.MenuItem mnuNeu_Einzelzahlung;
        private System.Windows.Forms.MenuItem mnuNeu_Kuerzung;
        private System.Windows.Forms.MenuItem mnuNeu_Vorabzug;
        private System.Windows.Forms.Panel panGrid;
        private System.Windows.Forms.Panel panToolbar;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBgBudget;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private KiSS4.DB.SqlQuery qryKbBuchung;
        private System.Windows.Forms.ToolBarButton tbnBelege;
        private System.Windows.Forms.ToolBarButton tbnBewilligt;
        private System.Windows.Forms.ToolBarButton tbnBewilligung;
        private System.Windows.Forms.ToolBarButton tbnButget;
        private System.Windows.Forms.ToolBarButton tbnGesperrt;
        private System.Windows.Forms.ToolBarButton tbnNeu;
        private System.Windows.Forms.ToolBarButton tbnNew;
        private System.Windows.Forms.ToolBarButton tbnReset;
        private System.Windows.Forms.ToolBarButton tbnVorbereitung;
        private System.Windows.Forms.ToolBar toolBarBudget;
        private System.Windows.Forms.ToolBarButton tsp;
        private System.Windows.Forms.ToolBarButton tsp1;
        private System.Windows.Forms.ToolBarButton tsp2;
        private System.Windows.Forms.ToolBarButton tsp3;
    }
}
