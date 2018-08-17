using System.Windows.Forms;
using DevExpress.XtraEditors;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui; 

namespace KiSS4.Arbeit
{
	public class FrmKurserfassung : KiSS4.Gui.KissChildForm
	{
		private System.ComponentModel.IContainer components = null;
		private KiSS4.DB.SqlQuery qryKurse;
		private KiSS4.Gui.KissLabel lblKursNrX;
		private KiSS4.Gui.KissLabel lblSektionX;
		private KiSS4.Gui.KissLabel lblKursnameX;
		private KiSS4.Gui.KissLabel lblKursname;
		private KiSS4.Gui.KissLabel lblDatVonBis;
		private KiSS4.Gui.KissLabel lblKursNr;
		private DevExpress.XtraGrid.Columns.GridColumn colKursname;
		private DevExpress.XtraGrid.Columns.GridColumn colKursNr;
		private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
		private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
		private KiSS4.Gui.KissTextEdit edtKursNr;
		private KiSS4.Gui.KissButtonEdit dlgKursname;
		private KiSS4.Gui.KissDateEdit datDatumVon;
		private KiSS4.Gui.KissDateEdit datDatumBis;
		private KiSS4.Gui.KissGrid grdKurse;
		private DevExpress.XtraGrid.Views.Grid.GridView gvKurse;
		private KiSS4.Gui.KissTabControlEx tabKurse;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;
		private System.Windows.Forms.Panel pnlSuche;
		private KiSS4.Gui.KissLookUpEdit ddlSektionX;
		private KiSS4.Gui.KissTextEdit edtKursNrX;
		private KiSS4.Gui.KissSearchTitel titSuche;
		private KiSS4.Gui.KissCheckEdit chkSistiert;
		private DevExpress.XtraGrid.Columns.GridColumn colSistiert;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private KiSS4.Gui.KissButtonEdit dlgKursnameX;
       
		public FrmKurserfassung()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKurserfassung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabKurse = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdKurse = new KiSS4.Gui.KissGrid();
            this.qryKurse = new KiSS4.DB.SqlQuery(this.components);
            this.gvKurse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKursname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKursNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSistiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.pnlSuche = new System.Windows.Forms.Panel();
            this.ddlSektionX = new KiSS4.Gui.KissLookUpEdit();
            this.dlgKursnameX = new KiSS4.Gui.KissButtonEdit();
            this.lblKursNrX = new KiSS4.Gui.KissLabel();
            this.edtKursNrX = new KiSS4.Gui.KissTextEdit();
            this.titSuche = new KiSS4.Gui.KissSearchTitel();
            this.lblSektionX = new KiSS4.Gui.KissLabel();
            this.lblKursnameX = new KiSS4.Gui.KissLabel();
            this.lblKursname = new KiSS4.Gui.KissLabel();
            this.lblDatVonBis = new KiSS4.Gui.KissLabel();
            this.edtKursNr = new KiSS4.Gui.KissTextEdit();
            this.lblKursNr = new KiSS4.Gui.KissLabel();
            this.dlgKursname = new KiSS4.Gui.KissButtonEdit();
            this.datDatumVon = new KiSS4.Gui.KissDateEdit();
            this.datDatumBis = new KiSS4.Gui.KissDateEdit();
            this.chkSistiert = new KiSS4.Gui.KissCheckEdit();
            this.tabKurse.SuspendLayout();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKurse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKurse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKurse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tpgSuchen.SuspendLayout();
            this.pnlSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSektionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSektionX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKursnameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursNrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursnameX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatVonBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKursname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSistiert.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKurse
            // 
            this.tabKurse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKurse.Controls.Add(this.tpgListe);
            this.tabKurse.Controls.Add(this.tpgSuchen);
            this.tabKurse.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabKurse.Location = new System.Drawing.Point(5, 10);
            this.tabKurse.Name = "tabKurse";
            this.tabKurse.ShowFixedWidthTooltip = true;
            this.tabKurse.Size = new System.Drawing.Size(656, 316);
            this.tabKurse.TabIndex = 0;
            this.tabKurse.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabKurse.TabsLineColor = System.Drawing.Color.Black;
            this.tabKurse.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabKurse.TabStop = false;
            this.tabKurse.Text = "xTabControl1";
            // 
            // tpgListe
            // 
            this.tpgListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgListe.Controls.Add(this.grdKurse);
            this.tpgListe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tpgListe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(644, 278);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            // 
            // grdKurse
            // 
            this.grdKurse.DataSource = this.qryKurse;
            this.grdKurse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKurse.EmbeddedNavigator.Name = "";
            this.grdKurse.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKurse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdKurse.Location = new System.Drawing.Point(0, 0);
            this.grdKurse.MainView = this.gvKurse;
            this.grdKurse.Name = "grdKurse";
            this.grdKurse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdKurse.Size = new System.Drawing.Size(644, 278);
            this.grdKurse.TabIndex = 0;
            this.grdKurse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvKurse});
            // 
            // qryKurse
            // 
            this.qryKurse.CanDelete = true;
            this.qryKurse.CanInsert = true;
            this.qryKurse.CanUpdate = true;
            this.qryKurse.HostControl = this;
            this.qryKurse.TableName = "KaKurserfassung";
            this.qryKurse.BeforePost += new System.EventHandler(this.qryKurse_BeforePost);
            this.qryKurse.AfterInsert += new System.EventHandler(this.qryKurse_AfterInsert);
            // 
            // gvKurse
            // 
            this.gvKurse.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvKurse.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.Empty.Options.UseBackColor = true;
            this.gvKurse.Appearance.Empty.Options.UseFont = true;
            this.gvKurse.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvKurse.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvKurse.Appearance.EvenRow.Options.UseFont = true;
            this.gvKurse.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvKurse.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvKurse.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvKurse.Appearance.FocusedCell.Options.UseFont = true;
            this.gvKurse.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvKurse.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvKurse.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvKurse.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvKurse.Appearance.FocusedRow.Options.UseFont = true;
            this.gvKurse.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvKurse.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvKurse.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvKurse.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvKurse.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvKurse.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvKurse.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvKurse.Appearance.GroupRow.Options.UseFont = true;
            this.gvKurse.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvKurse.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvKurse.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvKurse.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvKurse.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvKurse.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvKurse.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvKurse.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvKurse.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvKurse.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvKurse.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvKurse.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvKurse.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvKurse.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvKurse.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gvKurse.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.OddRow.Options.UseBackColor = true;
            this.gvKurse.Appearance.OddRow.Options.UseFont = true;
            this.gvKurse.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvKurse.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.Row.Options.UseBackColor = true;
            this.gvKurse.Appearance.Row.Options.UseFont = true;
            this.gvKurse.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gvKurse.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvKurse.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvKurse.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvKurse.Appearance.SelectedRow.Options.UseFont = true;
            this.gvKurse.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvKurse.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvKurse.Appearance.VertLine.Options.UseBackColor = true;
            this.gvKurse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvKurse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKursname,
            this.colKursNr,
            this.colDatumVon,
            this.colDatumBis,
            this.colSistiert});
            this.gvKurse.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvKurse.GridControl = this.grdKurse;
            this.gvKurse.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvKurse.Name = "gvKurse";
            this.gvKurse.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvKurse.OptionsBehavior.Editable = false;
            this.gvKurse.OptionsCustomization.AllowFilter = false;
            this.gvKurse.OptionsCustomization.AllowGroup = false;
            this.gvKurse.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvKurse.OptionsNavigation.AutoFocusNewRow = true;
            this.gvKurse.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvKurse.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvKurse.OptionsNavigation.UseTabKey = false;
            this.gvKurse.OptionsPrint.AutoWidth = false;
            this.gvKurse.OptionsPrint.UsePrintStyles = true;
            this.gvKurse.OptionsView.ColumnAutoWidth = false;
            this.gvKurse.OptionsView.ShowDetailButtons = false;
            this.gvKurse.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvKurse.OptionsView.ShowGroupPanel = false;
            this.gvKurse.OptionsView.ShowIndicator = false;
            // 
            // colKursname
            // 
            this.colKursname.AppearanceCell.Options.UseTextOptions = true;
            this.colKursname.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKursname.Caption = "Kursname";
            this.colKursname.FieldName = "Kursname";
            this.colKursname.Name = "colKursname";
            this.colKursname.Visible = true;
            this.colKursname.VisibleIndex = 0;
            this.colKursname.Width = 350;
            // 
            // colKursNr
            // 
            this.colKursNr.Caption = "Kurs Nr.";
            this.colKursNr.FieldName = "KursNr";
            this.colKursNr.Name = "colKursNr";
            this.colKursNr.Visible = true;
            this.colKursNr.VisibleIndex = 1;
            this.colKursNr.Width = 60;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 2;
            this.colDatumVon.Width = 80;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 3;
            this.colDatumBis.Width = 80;
            // 
            // colSistiert
            // 
            this.colSistiert.Caption = "sistiert";
            this.colSistiert.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSistiert.FieldName = "SistiertFlag";
            this.colSistiert.Name = "colSistiert";
            this.colSistiert.Visible = true;
            this.colSistiert.VisibleIndex = 4;
            this.colSistiert.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgSuchen.Controls.Add(this.pnlSuche);
            this.tpgSuchen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tpgSuchen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(644, 278);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Visible = false;
            // 
            // pnlSuche
            // 
            this.pnlSuche.Controls.Add(this.ddlSektionX);
            this.pnlSuche.Controls.Add(this.dlgKursnameX);
            this.pnlSuche.Controls.Add(this.lblKursNrX);
            this.pnlSuche.Controls.Add(this.edtKursNrX);
            this.pnlSuche.Controls.Add(this.titSuche);
            this.pnlSuche.Controls.Add(this.lblSektionX);
            this.pnlSuche.Controls.Add(this.lblKursnameX);
            this.pnlSuche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuche.Location = new System.Drawing.Point(0, 0);
            this.pnlSuche.Name = "pnlSuche";
            this.pnlSuche.Size = new System.Drawing.Size(644, 278);
            this.pnlSuche.TabIndex = 0;
            // 
            // ddlSektionX
            // 
            this.ddlSektionX.Location = new System.Drawing.Point(80, 108);
            this.ddlSektionX.LOVName = "KaKursSekt";
            this.ddlSektionX.Name = "ddlSektionX";
            this.ddlSektionX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlSektionX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlSektionX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlSektionX.Properties.Appearance.Options.UseBackColor = true;
            this.ddlSektionX.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlSektionX.Properties.Appearance.Options.UseFont = true;
            this.ddlSektionX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlSektionX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlSektionX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlSektionX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlSektionX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.ddlSektionX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.ddlSektionX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlSektionX.Properties.NullText = "";
            this.ddlSektionX.Properties.ShowFooter = false;
            this.ddlSektionX.Properties.ShowHeader = false;
            this.ddlSektionX.Size = new System.Drawing.Size(262, 24);
            this.ddlSektionX.TabIndex = 580;
            // 
            // dlgKursnameX
            // 
            this.dlgKursnameX.Location = new System.Drawing.Point(80, 48);
            this.dlgKursnameX.Name = "dlgKursnameX";
            this.dlgKursnameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgKursnameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgKursnameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgKursnameX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgKursnameX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgKursnameX.Properties.Appearance.Options.UseFont = true;
            this.dlgKursnameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.dlgKursnameX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.dlgKursnameX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgKursnameX.Size = new System.Drawing.Size(262, 24);
            this.dlgKursnameX.TabIndex = 579;
            this.dlgKursnameX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgKursnameX_UserModifiedFld);
            // 
            // lblKursNrX
            // 
            this.lblKursNrX.Location = new System.Drawing.Point(5, 78);
            this.lblKursNrX.Name = "lblKursNrX";
            this.lblKursNrX.Size = new System.Drawing.Size(67, 24);
            this.lblKursNrX.TabIndex = 578;
            this.lblKursNrX.Text = "Kursnummer";
            // 
            // edtKursNrX
            // 
            this.edtKursNrX.EditValue = "";
            this.edtKursNrX.Location = new System.Drawing.Point(80, 78);
            this.edtKursNrX.Name = "edtKursNrX";
            this.edtKursNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursNrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursNrX.Properties.Appearance.Options.UseFont = true;
            this.edtKursNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursNrX.Size = new System.Drawing.Size(70, 24);
            this.edtKursNrX.TabIndex = 2;
            // 
            // titSuche
            // 
            this.titSuche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.titSuche.Location = new System.Drawing.Point(9, 4);
            this.titSuche.Name = "titSuche";
            this.titSuche.Size = new System.Drawing.Size(200, 24);
            this.titSuche.TabIndex = 574;
            // 
            // lblSektionX
            // 
            this.lblSektionX.ForeColor = System.Drawing.Color.Black;
            this.lblSektionX.Location = new System.Drawing.Point(5, 108);
            this.lblSektionX.Name = "lblSektionX";
            this.lblSektionX.Size = new System.Drawing.Size(55, 24);
            this.lblSektionX.TabIndex = 571;
            this.lblSektionX.Text = "Sektion";
            // 
            // lblKursnameX
            // 
            this.lblKursnameX.Location = new System.Drawing.Point(5, 48);
            this.lblKursnameX.Name = "lblKursnameX";
            this.lblKursnameX.Size = new System.Drawing.Size(61, 24);
            this.lblKursnameX.TabIndex = 348;
            this.lblKursnameX.Text = "Kursname";
            // 
            // lblKursname
            // 
            this.lblKursname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKursname.ForeColor = System.Drawing.Color.Black;
            this.lblKursname.Location = new System.Drawing.Point(10, 332);
            this.lblKursname.Name = "lblKursname";
            this.lblKursname.Size = new System.Drawing.Size(80, 24);
            this.lblKursname.TabIndex = 568;
            this.lblKursname.Text = "Kursname";
            // 
            // lblDatVonBis
            // 
            this.lblDatVonBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatVonBis.ForeColor = System.Drawing.Color.Black;
            this.lblDatVonBis.Location = new System.Drawing.Point(10, 362);
            this.lblDatVonBis.Name = "lblDatVonBis";
            this.lblDatVonBis.Size = new System.Drawing.Size(90, 24);
            this.lblDatVonBis.TabIndex = 561;
            this.lblDatVonBis.Text = "Datum von / bis";
            // 
            // edtKursNr
            // 
            this.edtKursNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKursNr.DataMember = "KursNr";
            this.edtKursNr.DataSource = this.qryKurse;
            this.edtKursNr.Location = new System.Drawing.Point(500, 332);
            this.edtKursNr.Name = "edtKursNr";
            this.edtKursNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKursNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKursNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKursNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKursNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKursNr.Properties.Appearance.Options.UseFont = true;
            this.edtKursNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKursNr.Size = new System.Drawing.Size(100, 24);
            this.edtKursNr.TabIndex = 1;
            // 
            // lblKursNr
            // 
            this.lblKursNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKursNr.ForeColor = System.Drawing.Color.Black;
            this.lblKursNr.Location = new System.Drawing.Point(450, 332);
            this.lblKursNr.Name = "lblKursNr";
            this.lblKursNr.Size = new System.Drawing.Size(50, 24);
            this.lblKursNr.TabIndex = 575;
            this.lblKursNr.Text = "Kurs Nr.";
            // 
            // dlgKursname
            // 
            this.dlgKursname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dlgKursname.DataMember = "Kursname";
            this.dlgKursname.DataSource = this.qryKurse;
            this.dlgKursname.Location = new System.Drawing.Point(110, 332);
            this.dlgKursname.Name = "dlgKursname";
            this.dlgKursname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgKursname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgKursname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgKursname.Properties.Appearance.Options.UseBackColor = true;
            this.dlgKursname.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgKursname.Properties.Appearance.Options.UseFont = true;
            this.dlgKursname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.dlgKursname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.dlgKursname.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgKursname.Size = new System.Drawing.Size(310, 24);
            this.dlgKursname.TabIndex = 0;
            this.dlgKursname.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgKursname_UserModifiedFld);
            // 
            // datDatumVon
            // 
            this.datDatumVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datDatumVon.DataMember = "DatumVon";
            this.datDatumVon.DataSource = this.qryKurse;
            this.datDatumVon.EditValue = null;
            this.datDatumVon.Location = new System.Drawing.Point(110, 362);
            this.datDatumVon.Name = "datDatumVon";
            this.datDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumVon.Properties.Appearance.Options.UseFont = true;
            this.datDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.datDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.datDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datDatumVon.Properties.ShowToday = false;
            this.datDatumVon.Size = new System.Drawing.Size(89, 24);
            this.datDatumVon.TabIndex = 2;
            // 
            // datDatumBis
            // 
            this.datDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datDatumBis.DataMember = "DatumBis";
            this.datDatumBis.DataSource = this.qryKurse;
            this.datDatumBis.EditValue = null;
            this.datDatumBis.Location = new System.Drawing.Point(210, 362);
            this.datDatumBis.Name = "datDatumBis";
            this.datDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.datDatumBis.Properties.Appearance.Options.UseFont = true;
            this.datDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datDatumBis.Properties.ShowToday = false;
            this.datDatumBis.Size = new System.Drawing.Size(89, 24);
            this.datDatumBis.TabIndex = 3;
            // 
            // chkSistiert
            // 
            this.chkSistiert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSistiert.DataMember = "SistiertFlag";
            this.chkSistiert.DataSource = this.qryKurse;
            this.chkSistiert.Location = new System.Drawing.Point(110, 392);
            this.chkSistiert.Name = "chkSistiert";
            this.chkSistiert.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSistiert.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkSistiert.Properties.Appearance.Options.UseBackColor = true;
            this.chkSistiert.Properties.Appearance.Options.UseForeColor = true;
            this.chkSistiert.Properties.Caption = "  sistiert";
            this.chkSistiert.Size = new System.Drawing.Size(220, 19);
            this.chkSistiert.TabIndex = 576;
            // 
            // FrmKurserfassung
            // 
            this.ActiveSQLQuery = this.qryKurse;
            this.ClientSize = new System.Drawing.Size(663, 428);
            this.Controls.Add(this.chkSistiert);
            this.Controls.Add(this.datDatumBis);
            this.Controls.Add(this.datDatumVon);
            this.Controls.Add(this.dlgKursname);
            this.Controls.Add(this.edtKursNr);
            this.Controls.Add(this.lblKursNr);
            this.Controls.Add(this.lblKursname);
            this.Controls.Add(this.lblDatVonBis);
            this.Controls.Add(this.tabKurse);
            this.Name = "FrmKurserfassung";
            this.Text = "Kurserfassung";
            this.Search += new System.EventHandler(this.FrmKurserfassung_Search);
            this.Load += new System.EventHandler(this.FrmKurserfassung_Load);
            this.tabKurse.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKurse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKurse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKurse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tpgSuchen.ResumeLayout(false);
            this.pnlSuche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlSektionX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSektionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKursnameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursNrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursnameX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatVonBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKursNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKursNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKursname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSistiert.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void FrmKurserfassung_Load(object sender, System.EventArgs e)
		{	
			SetEditMode();
			FillKurse();
		}

		private void FillKurse()
		{
			Cursor.Current = Cursors.WaitCursor;

			string Sql = @"
				SELECT	KUE.*, 
						Kursname = KUR.Name
				FROM	KaKurserfassung KUE
						inner join KaKurs KUR on KUR.KaKursID = KUE.KursID
				WHERE	1 = 1 ";

			// Kurs
			if (!DBUtil.IsEmpty(dlgKursnameX.EditValue))
			{
				Sql += " and KUR.KaKursID = " + dlgKursnameX.LookupID;
			}

			// Kursnummer
			if (edtKursNrX.Text != "") 
			{
				Sql += " and KUE.KursNr like " + DBUtil.SqlLiteralLike("%" + edtKursNrX.Text + "%");
			}

			// Sektion
			if (!DBUtil.IsEmpty(ddlSektionX.EditValue))
			{			
				Sql += " and KUR.SektionCode = " + DBUtil.SqlLiteral(ddlSektionX.EditValue);
			}

			Sql += " order by Kursname, KursNr";

			qryKurse.Fill(Sql);

			tabKurse.SelectedTabIndex = 0;
			grdKurse.Focus(); 
			Cursor.Current = Cursors.Default;
		}

		private void FrmKurserfassung_Search(object sender, System.EventArgs e)
		{
			if (tabKurse.SelectedTabIndex == 1)
			{
				SetEditMode();
				FillKurse();
			}
			else
			{
				if (qryKurse.Post())
				{
					this.tabKurse.SelectedTabIndex = 1;
					NeueSuche();
				}
			}
		}

		private void NeueSuche()
		{
			foreach (Control C in UtilsGui.AllControls(tabKurse))
				if (C is BaseEdit) 
					((BaseEdit)C).EditValue = null;

			dlgKursnameX.Focus();
		}

		private void qryKurse_BeforePost(object sender, System.EventArgs e)
		{
			DBUtil.CheckNotNullField(dlgKursname, lblKursname.Text);
		}

		public override object GetContextValue(string FieldName) 
		{
//			switch (FieldName.ToUpper()) 
//			{
//				case "DMGORGANISATIONID":
//					if (qryKontakt.Count > 0)
//						return qryKontakt["DmgOrganisationID"];
//					break;
//			}

			return base.GetContextValue(FieldName);
		}

		private void qryKurse_AfterInsert(object sender, System.EventArgs e)
		{
			dlgKursname.Focus();
		}

		private void dlgKursname_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
		{
			DlgAuswahl dlg = new DlgAuswahl();
			if (dlg.KursSuchen(dlgKursname.Text,e.ButtonClicked))
			{  
				qryKurse["Kursname"] = dlg["Kurs"];
				qryKurse["KursID"] = dlg["KursID"];	

				dlgKursname.EditValue = dlg["Kurs"];
				dlgKursname.LookupID = dlg["KursID"];
			
				qryKurse.Post();
			}
			else
				e.Cancel = true;
		}

		private void dlgKursnameX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
		{
			DlgAuswahl dlg = new DlgAuswahl();
			if (dlg.KursSuchen(dlgKursnameX.Text,e.ButtonClicked))
			{  
				dlgKursnameX.EditValue = dlg["Kurs"];
				dlgKursnameX.LookupID = dlg["KursID"];
			}
			else
				e.Cancel = true;
		}
		
		private void SetEditMode()
		{			
			qryKurse.CanUpdate = DBUtil.UserHasRight("FrmKaKurserfassung", "U");
			qryKurse.CanInsert = DBUtil.UserHasRight("FrmKaKurserfassung", "I");
			qryKurse.CanDelete = DBUtil.UserHasRight("FrmKaKurserfassung", "D");
			qryKurse.EnableBoundFields();
		}
	}
}

