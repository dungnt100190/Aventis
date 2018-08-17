using System;
using System.Data;
using System.Drawing;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
	/// <summary>
	/// Summary description for CtlKaQJExtern.
	/// </summary>
	public class CtlKaQJExtern : KissUserControl
	{
		private System.ComponentModel.IContainer components;

		private int FaLeistungID = 0;
		private KiSS4.DB.SqlQuery qryExtern;
		private KiSS4.Gui.KissGrid grdExtern;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPhasen;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private System.Windows.Forms.Label lblTitel;
		private System.Windows.Forms.PictureBox picTitle;
		private KiSS4.Gui.KissLookUpEdit ddlEinsatzAls;
		private KiSS4.Gui.KissLabel lblEinsatzAls;
		private KiSS4.Gui.KissLabel lblEinsatzBis;
		private KiSS4.Gui.KissDateEdit datEinsatzBis;
		private KiSS4.Gui.KissLabel lblEinsatzVon;
		private KiSS4.Gui.KissDateEdit datEinsatzVon;
		private System.Windows.Forms.Label lblBetrieb;
		private KiSS4.Gui.KissButtonEdit dlgBetrieb;
		private KiSS4.Gui.KissLabel lblBetriebName;
		private KiSS4.Dokument.XDokument docStage;
		private KiSS4.Gui.KissLabel lblStage;
		private KiSS4.Gui.KissLabel lblEinladung;
		private KiSS4.Dokument.XDokument docEinladung;
		private KiSS4.Gui.KissTextEdit edtBetriebStrasse;
		private KiSS4.Gui.KissLabel lblBetriebStrasse;
		private KiSS4.Gui.KissTextEdit edtBetriebZusatz;
		private KiSS4.Gui.KissLabel lblBetriebZusatz;
		private KiSS4.Gui.KissTextEdit edtBetriebOrt;
		private KiSS4.Gui.KissLabel lblBetriebOrt;
		private KiSS4.Gui.KissTextEdit edtBetriebKontakt;
		private KiSS4.Gui.KissLabel lblBetriebKontakt;
		private KiSS4.Gui.KissTextEdit edtBetriebTelEmail;
		private KiSS4.Gui.KissLabel lblBetriebTelEmail;
		private DevExpress.XtraGrid.Columns.GridColumn colEinsatzVon;
		private DevExpress.XtraGrid.Columns.GridColumn colEinsatzBis;
		private DevExpress.XtraGrid.Columns.GridColumn colEinsatzAls;
		private DevExpress.XtraGrid.Columns.GridColumn colBetriebName;
		private DevExpress.XtraGrid.Columns.GridColumn colKontaktPers;
		private DevExpress.XtraGrid.Columns.GridColumn colTelEmail;
		private KiSS4.Gui.KissLabel lblBerufswunsch;
		private KiSS4.Gui.KissTextEdit edtBerufswunsch;
		private int BaPersonID = 0;
		private string BerufWunsch = string.Empty;

		public CtlKaQJExtern()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaQJExtern));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryExtern = new KiSS4.DB.SqlQuery(this.components);
            this.grdExtern = new KiSS4.Gui.KissGrid();
            this.gvPhasen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEinsatzVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinsatzAls = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetriebName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontaktPers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.docStage = new KiSS4.Dokument.XDokument();
            this.ddlEinsatzAls = new KiSS4.Gui.KissLookUpEdit();
            this.lblEinsatzAls = new KiSS4.Gui.KissLabel();
            this.lblEinsatzBis = new KiSS4.Gui.KissLabel();
            this.datEinsatzBis = new KiSS4.Gui.KissDateEdit();
            this.lblEinsatzVon = new KiSS4.Gui.KissLabel();
            this.datEinsatzVon = new KiSS4.Gui.KissDateEdit();
            this.dlgBetrieb = new KiSS4.Gui.KissButtonEdit();
            this.lblBetriebName = new KiSS4.Gui.KissLabel();
            this.lblBetrieb = new System.Windows.Forms.Label();
            this.lblStage = new KiSS4.Gui.KissLabel();
            this.lblEinladung = new KiSS4.Gui.KissLabel();
            this.docEinladung = new KiSS4.Dokument.XDokument();
            this.edtBetriebTelEmail = new KiSS4.Gui.KissTextEdit();
            this.lblBetriebTelEmail = new KiSS4.Gui.KissLabel();
            this.edtBetriebKontakt = new KiSS4.Gui.KissTextEdit();
            this.lblBetriebKontakt = new KiSS4.Gui.KissLabel();
            this.edtBetriebOrt = new KiSS4.Gui.KissTextEdit();
            this.lblBetriebOrt = new KiSS4.Gui.KissLabel();
            this.edtBetriebZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblBetriebZusatz = new KiSS4.Gui.KissLabel();
            this.edtBetriebStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblBetriebStrasse = new KiSS4.Gui.KissLabel();
            this.edtBerufswunsch = new KiSS4.Gui.KissTextEdit();
            this.lblBerufswunsch = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryExtern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExtern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhasen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docStage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEinsatzAls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEinsatzAls.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzAls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinsatzBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinsatzVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgBetrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinladung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebTelEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebTelEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebKontakt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebKontakt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufswunsch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerufswunsch)).BeginInit();
            this.SuspendLayout();
            // 
            // qryExtern
            // 
            this.qryExtern.CanDelete = true;
            this.qryExtern.CanInsert = true;
            this.qryExtern.CanUpdate = true;
            this.qryExtern.HostControl = this;
            this.qryExtern.TableName = "KaQJExtern";
            this.qryExtern.BeforePost += new System.EventHandler(this.qryExtern_BeforePost);
            this.qryExtern.AfterInsert += new System.EventHandler(this.qryExtern_AfterInsert);
            // 
            // grdExtern
            // 
            this.grdExtern.DataSource = this.qryExtern;
            this.grdExtern.EmbeddedNavigator.Name = "";
            this.grdExtern.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdExtern.Location = new System.Drawing.Point(10, 75);
            this.grdExtern.MainView = this.gvPhasen;
            this.grdExtern.Name = "grdExtern";
            this.grdExtern.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdExtern.Size = new System.Drawing.Size(885, 130);
            this.grdExtern.TabIndex = 203;
            this.grdExtern.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPhasen});
            // 
            // gvPhasen
            // 
            this.gvPhasen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvPhasen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.Empty.Options.UseBackColor = true;
            this.gvPhasen.Appearance.Empty.Options.UseFont = true;
            this.gvPhasen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.EvenRow.Options.UseFont = true;
            this.gvPhasen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvPhasen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvPhasen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvPhasen.Appearance.FocusedCell.Options.UseFont = true;
            this.gvPhasen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvPhasen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvPhasen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvPhasen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPhasen.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPhasen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPhasen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPhasen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvPhasen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPhasen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvPhasen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvPhasen.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvPhasen.Appearance.GroupRow.Options.UseFont = true;
            this.gvPhasen.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvPhasen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvPhasen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvPhasen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvPhasen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvPhasen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvPhasen.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPhasen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvPhasen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvPhasen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvPhasen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvPhasen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvPhasen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvPhasen.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvPhasen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.OddRow.Options.UseFont = true;
            this.gvPhasen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvPhasen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.Row.Options.UseBackColor = true;
            this.gvPhasen.Appearance.Row.Options.UseFont = true;
            this.gvPhasen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPhasen.Appearance.SelectedRow.Options.UseFont = true;
            this.gvPhasen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvPhasen.Appearance.VertLine.Options.UseBackColor = true;
            this.gvPhasen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvPhasen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEinsatzVon,
            this.colEinsatzBis,
            this.colEinsatzAls,
            this.colBetriebName,
            this.colKontaktPers,
            this.colTelEmail});
            this.gvPhasen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvPhasen.GridControl = this.grdExtern;
            this.gvPhasen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvPhasen.Name = "gvPhasen";
            this.gvPhasen.OptionsBehavior.Editable = false;
            this.gvPhasen.OptionsCustomization.AllowFilter = false;
            this.gvPhasen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvPhasen.OptionsNavigation.AutoFocusNewRow = true;
            this.gvPhasen.OptionsNavigation.UseTabKey = false;
            this.gvPhasen.OptionsView.ColumnAutoWidth = false;
            this.gvPhasen.OptionsView.RowAutoHeight = true;
            this.gvPhasen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvPhasen.OptionsView.ShowGroupPanel = false;
            this.gvPhasen.OptionsView.ShowIndicator = false;
            // 
            // colEinsatzVon
            // 
            this.colEinsatzVon.Caption = "Einsatz von";
            this.colEinsatzVon.FieldName = "EinsatzVon";
            this.colEinsatzVon.Name = "colEinsatzVon";
            this.colEinsatzVon.Visible = true;
            this.colEinsatzVon.VisibleIndex = 0;
            this.colEinsatzVon.Width = 80;
            // 
            // colEinsatzBis
            // 
            this.colEinsatzBis.Caption = "Einsatz bis";
            this.colEinsatzBis.FieldName = "EinsatzBis";
            this.colEinsatzBis.Name = "colEinsatzBis";
            this.colEinsatzBis.Visible = true;
            this.colEinsatzBis.VisibleIndex = 1;
            this.colEinsatzBis.Width = 80;
            // 
            // colEinsatzAls
            // 
            this.colEinsatzAls.Caption = "Einsatz als";
            this.colEinsatzAls.FieldName = "EinsatzCode";
            this.colEinsatzAls.Name = "colEinsatzAls";
            this.colEinsatzAls.Visible = true;
            this.colEinsatzAls.VisibleIndex = 2;
            this.colEinsatzAls.Width = 150;
            // 
            // colBetriebName
            // 
            this.colBetriebName.Caption = "Name Betrieb";
            this.colBetriebName.FieldName = "Betrieb";
            this.colBetriebName.Name = "colBetriebName";
            this.colBetriebName.Visible = true;
            this.colBetriebName.VisibleIndex = 3;
            this.colBetriebName.Width = 180;
            // 
            // colKontaktPers
            // 
            this.colKontaktPers.Caption = "Kontaktperson";
            this.colKontaktPers.FieldName = "BetriebKontakt";
            this.colKontaktPers.Name = "colKontaktPers";
            this.colKontaktPers.Visible = true;
            this.colKontaktPers.VisibleIndex = 4;
            this.colKontaktPers.Width = 180;
            // 
            // colTelEmail
            // 
            this.colTelEmail.Caption = "Telefon / Email";
            this.colTelEmail.FieldName = "BetriebTelEmail";
            this.colTelEmail.Name = "colTelEmail";
            this.colTelEmail.Visible = true;
            this.colTelEmail.VisibleIndex = 5;
            this.colTelEmail.Width = 180;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 205;
            this.lblTitel.Text = "Titel";
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 204;
            this.picTitle.TabStop = false;
            // 
            // docStage
            // 
            this.docStage.AllowDrop = true;
            this.docStage.Context = "KaQJExternStage";
            this.docStage.DataMember = "StageDokID";
            this.docStage.DataSource = this.qryExtern;
            this.docStage.Location = new System.Drawing.Point(120, 530);
            this.docStage.Name = "docStage";
            this.docStage.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docStage.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docStage.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docStage.Properties.Appearance.Options.UseBackColor = true;
            this.docStage.Properties.Appearance.Options.UseBorderColor = true;
            this.docStage.Properties.Appearance.Options.UseFont = true;
            this.docStage.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docStage.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docStage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.docStage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docStage.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docStage.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docStage.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docStage.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "Dokument importieren")});
            this.docStage.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docStage.Properties.ReadOnly = true;
            this.docStage.Size = new System.Drawing.Size(136, 24);
            this.docStage.TabIndex = 5;
            // 
            // ddlEinsatzAls
            // 
            this.ddlEinsatzAls.DataMember = "EinsatzCode";
            this.ddlEinsatzAls.DataSource = this.qryExtern;
            this.ddlEinsatzAls.Location = new System.Drawing.Point(120, 245);
            this.ddlEinsatzAls.LOVName = "KaQjExternEinsatzals";
            this.ddlEinsatzAls.Name = "ddlEinsatzAls";
            this.ddlEinsatzAls.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlEinsatzAls.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlEinsatzAls.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlEinsatzAls.Properties.Appearance.Options.UseBackColor = true;
            this.ddlEinsatzAls.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlEinsatzAls.Properties.Appearance.Options.UseFont = true;
            this.ddlEinsatzAls.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlEinsatzAls.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlEinsatzAls.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlEinsatzAls.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlEinsatzAls.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.ddlEinsatzAls.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.ddlEinsatzAls.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlEinsatzAls.Properties.NullText = "";
            this.ddlEinsatzAls.Properties.ShowFooter = false;
            this.ddlEinsatzAls.Properties.ShowHeader = false;
            this.ddlEinsatzAls.Size = new System.Drawing.Size(220, 24);
            this.ddlEinsatzAls.TabIndex = 3;
            // 
            // lblEinsatzAls
            // 
            this.lblEinsatzAls.Location = new System.Drawing.Point(10, 245);
            this.lblEinsatzAls.Name = "lblEinsatzAls";
            this.lblEinsatzAls.Size = new System.Drawing.Size(75, 24);
            this.lblEinsatzAls.TabIndex = 597;
            this.lblEinsatzAls.Text = "Einsatz als";
            // 
            // lblEinsatzBis
            // 
            this.lblEinsatzBis.Location = new System.Drawing.Point(220, 215);
            this.lblEinsatzBis.Name = "lblEinsatzBis";
            this.lblEinsatzBis.Size = new System.Drawing.Size(20, 24);
            this.lblEinsatzBis.TabIndex = 596;
            this.lblEinsatzBis.Text = "bis";
            // 
            // datEinsatzBis
            // 
            this.datEinsatzBis.DataMember = "EinsatzBis";
            this.datEinsatzBis.DataSource = this.qryExtern;
            this.datEinsatzBis.EditValue = null;
            this.datEinsatzBis.Location = new System.Drawing.Point(250, 215);
            this.datEinsatzBis.Name = "datEinsatzBis";
            this.datEinsatzBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEinsatzBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datEinsatzBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEinsatzBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEinsatzBis.Properties.Appearance.Options.UseBackColor = true;
            this.datEinsatzBis.Properties.Appearance.Options.UseBorderColor = true;
            this.datEinsatzBis.Properties.Appearance.Options.UseFont = true;
            this.datEinsatzBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.datEinsatzBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEinsatzBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.datEinsatzBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEinsatzBis.Properties.ShowToday = false;
            this.datEinsatzBis.Size = new System.Drawing.Size(90, 24);
            this.datEinsatzBis.TabIndex = 2;
            // 
            // lblEinsatzVon
            // 
            this.lblEinsatzVon.Location = new System.Drawing.Point(10, 215);
            this.lblEinsatzVon.Name = "lblEinsatzVon";
            this.lblEinsatzVon.Size = new System.Drawing.Size(101, 24);
            this.lblEinsatzVon.TabIndex = 595;
            this.lblEinsatzVon.Text = "Einsatz von";
            // 
            // datEinsatzVon
            // 
            this.datEinsatzVon.DataMember = "EinsatzVon";
            this.datEinsatzVon.DataSource = this.qryExtern;
            this.datEinsatzVon.EditValue = null;
            this.datEinsatzVon.Location = new System.Drawing.Point(120, 215);
            this.datEinsatzVon.Name = "datEinsatzVon";
            this.datEinsatzVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datEinsatzVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datEinsatzVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datEinsatzVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datEinsatzVon.Properties.Appearance.Options.UseBackColor = true;
            this.datEinsatzVon.Properties.Appearance.Options.UseBorderColor = true;
            this.datEinsatzVon.Properties.Appearance.Options.UseFont = true;
            this.datEinsatzVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.datEinsatzVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datEinsatzVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.datEinsatzVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datEinsatzVon.Properties.ShowToday = false;
            this.datEinsatzVon.Size = new System.Drawing.Size(89, 24);
            this.datEinsatzVon.TabIndex = 1;
            // 
            // dlgBetrieb
            // 
            this.dlgBetrieb.DataMember = "Betrieb";
            this.dlgBetrieb.DataSource = this.qryExtern;
            this.dlgBetrieb.Location = new System.Drawing.Point(120, 310);
            this.dlgBetrieb.Name = "dlgBetrieb";
            this.dlgBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgBetrieb.Properties.Appearance.Options.UseBackColor = true;
            this.dlgBetrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgBetrieb.Properties.Appearance.Options.UseFont = true;
            this.dlgBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.dlgBetrieb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.dlgBetrieb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgBetrieb.Size = new System.Drawing.Size(310, 24);
            this.dlgBetrieb.TabIndex = 4;
            this.dlgBetrieb.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgBetrieb_UserModifiedFld);
            // 
            // lblBetriebName
            // 
            this.lblBetriebName.Location = new System.Drawing.Point(10, 310);
            this.lblBetriebName.Name = "lblBetriebName";
            this.lblBetriebName.Size = new System.Drawing.Size(111, 24);
            this.lblBetriebName.TabIndex = 594;
            this.lblBetriebName.Text = "Name";
            // 
            // lblBetrieb
            // 
            this.lblBetrieb.AutoSize = true;
            this.lblBetrieb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblBetrieb.ForeColor = System.Drawing.Color.Black;
            this.lblBetrieb.Location = new System.Drawing.Point(10, 290);
            this.lblBetrieb.Name = "lblBetrieb";
            this.lblBetrieb.Size = new System.Drawing.Size(48, 15);
            this.lblBetrieb.TabIndex = 598;
            this.lblBetrieb.Text = "Betrieb";
            // 
            // lblStage
            // 
            this.lblStage.Location = new System.Drawing.Point(10, 530);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(105, 24);
            this.lblStage.TabIndex = 599;
            this.lblStage.Text = "Stage Vereinbarung";
            // 
            // lblEinladung
            // 
            this.lblEinladung.Location = new System.Drawing.Point(10, 560);
            this.lblEinladung.Name = "lblEinladung";
            this.lblEinladung.Size = new System.Drawing.Size(105, 24);
            this.lblEinladung.TabIndex = 601;
            this.lblEinladung.Text = "Einladung";
            // 
            // docEinladung
            // 
            this.docEinladung.AllowDrop = true;
            this.docEinladung.Context = "KaQJExternEinladung";
            this.docEinladung.DataMember = "EinladungDokID";
            this.docEinladung.DataSource = this.qryExtern;
            this.docEinladung.Location = new System.Drawing.Point(120, 560);
            this.docEinladung.Name = "docEinladung";
            this.docEinladung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docEinladung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docEinladung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladung.Properties.Appearance.Options.UseBackColor = true;
            this.docEinladung.Properties.Appearance.Options.UseBorderColor = true;
            this.docEinladung.Properties.Appearance.Options.UseFont = true;
            this.docEinladung.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docEinladung.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docEinladung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.docEinladung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docEinladung.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.docEinladung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docEinladung.Properties.ReadOnly = true;
            this.docEinladung.Size = new System.Drawing.Size(136, 24);
            this.docEinladung.TabIndex = 6;
            // 
            // edtBetriebTelEmail
            // 
            this.edtBetriebTelEmail.DataMember = "BetriebTelEmail";
            this.edtBetriebTelEmail.DataSource = this.qryExtern;
            this.edtBetriebTelEmail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetriebTelEmail.Location = new System.Drawing.Point(120, 470);
            this.edtBetriebTelEmail.Name = "edtBetriebTelEmail";
            this.edtBetriebTelEmail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetriebTelEmail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebTelEmail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebTelEmail.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebTelEmail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebTelEmail.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebTelEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetriebTelEmail.Properties.ReadOnly = true;
            this.edtBetriebTelEmail.Size = new System.Drawing.Size(310, 24);
            this.edtBetriebTelEmail.TabIndex = 610;
            // 
            // lblBetriebTelEmail
            // 
            this.lblBetriebTelEmail.Location = new System.Drawing.Point(10, 470);
            this.lblBetriebTelEmail.Name = "lblBetriebTelEmail";
            this.lblBetriebTelEmail.Size = new System.Drawing.Size(95, 24);
            this.lblBetriebTelEmail.TabIndex = 611;
            this.lblBetriebTelEmail.Text = "Telefon / Email";
            // 
            // edtBetriebKontakt
            // 
            this.edtBetriebKontakt.DataMember = "BetriebKontakt";
            this.edtBetriebKontakt.DataSource = this.qryExtern;
            this.edtBetriebKontakt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetriebKontakt.Location = new System.Drawing.Point(120, 440);
            this.edtBetriebKontakt.Name = "edtBetriebKontakt";
            this.edtBetriebKontakt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetriebKontakt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebKontakt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebKontakt.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebKontakt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebKontakt.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebKontakt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetriebKontakt.Properties.ReadOnly = true;
            this.edtBetriebKontakt.Size = new System.Drawing.Size(310, 24);
            this.edtBetriebKontakt.TabIndex = 608;
            // 
            // lblBetriebKontakt
            // 
            this.lblBetriebKontakt.Location = new System.Drawing.Point(10, 440);
            this.lblBetriebKontakt.Name = "lblBetriebKontakt";
            this.lblBetriebKontakt.Size = new System.Drawing.Size(90, 24);
            this.lblBetriebKontakt.TabIndex = 609;
            this.lblBetriebKontakt.Text = "Kontaktperson";
            // 
            // edtBetriebOrt
            // 
            this.edtBetriebOrt.DataMember = "BetriebOrt";
            this.edtBetriebOrt.DataSource = this.qryExtern;
            this.edtBetriebOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetriebOrt.Location = new System.Drawing.Point(120, 400);
            this.edtBetriebOrt.Name = "edtBetriebOrt";
            this.edtBetriebOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetriebOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebOrt.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetriebOrt.Properties.ReadOnly = true;
            this.edtBetriebOrt.Size = new System.Drawing.Size(310, 24);
            this.edtBetriebOrt.TabIndex = 606;
            // 
            // lblBetriebOrt
            // 
            this.lblBetriebOrt.Location = new System.Drawing.Point(10, 400);
            this.lblBetriebOrt.Name = "lblBetriebOrt";
            this.lblBetriebOrt.Size = new System.Drawing.Size(60, 24);
            this.lblBetriebOrt.TabIndex = 607;
            this.lblBetriebOrt.Text = "PLZ / Ort";
            // 
            // edtBetriebZusatz
            // 
            this.edtBetriebZusatz.DataMember = "BetriebZusatz";
            this.edtBetriebZusatz.DataSource = this.qryExtern;
            this.edtBetriebZusatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetriebZusatz.Location = new System.Drawing.Point(120, 370);
            this.edtBetriebZusatz.Name = "edtBetriebZusatz";
            this.edtBetriebZusatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetriebZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetriebZusatz.Properties.ReadOnly = true;
            this.edtBetriebZusatz.Size = new System.Drawing.Size(310, 24);
            this.edtBetriebZusatz.TabIndex = 604;
            // 
            // lblBetriebZusatz
            // 
            this.lblBetriebZusatz.Location = new System.Drawing.Point(10, 370);
            this.lblBetriebZusatz.Name = "lblBetriebZusatz";
            this.lblBetriebZusatz.Size = new System.Drawing.Size(60, 24);
            this.lblBetriebZusatz.TabIndex = 605;
            this.lblBetriebZusatz.Text = "Zusatz";
            // 
            // edtBetriebStrasse
            // 
            this.edtBetriebStrasse.DataMember = "BetriebStrasse";
            this.edtBetriebStrasse.DataSource = this.qryExtern;
            this.edtBetriebStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBetriebStrasse.Location = new System.Drawing.Point(120, 340);
            this.edtBetriebStrasse.Name = "edtBetriebStrasse";
            this.edtBetriebStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBetriebStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetriebStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetriebStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetriebStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetriebStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtBetriebStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetriebStrasse.Properties.ReadOnly = true;
            this.edtBetriebStrasse.Size = new System.Drawing.Size(310, 24);
            this.edtBetriebStrasse.TabIndex = 602;
            // 
            // lblBetriebStrasse
            // 
            this.lblBetriebStrasse.Location = new System.Drawing.Point(10, 340);
            this.lblBetriebStrasse.Name = "lblBetriebStrasse";
            this.lblBetriebStrasse.Size = new System.Drawing.Size(65, 24);
            this.lblBetriebStrasse.TabIndex = 603;
            this.lblBetriebStrasse.Text = "Strasse";
            // 
            // edtBerufswunsch
            // 
            this.edtBerufswunsch.DataMember = "Berufswunsch";
            this.edtBerufswunsch.DataSource = this.qryExtern;
            this.edtBerufswunsch.Location = new System.Drawing.Point(105, 40);
            this.edtBerufswunsch.Name = "edtBerufswunsch";
            this.edtBerufswunsch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBerufswunsch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerufswunsch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerufswunsch.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerufswunsch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerufswunsch.Properties.Appearance.Options.UseFont = true;
            this.edtBerufswunsch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBerufswunsch.Size = new System.Drawing.Size(340, 24);
            this.edtBerufswunsch.TabIndex = 0;
            this.edtBerufswunsch.Leave += new System.EventHandler(this.edtBerufswunsch_Leave);
            // 
            // lblBerufswunsch
            // 
            this.lblBerufswunsch.Location = new System.Drawing.Point(10, 40);
            this.lblBerufswunsch.Name = "lblBerufswunsch";
            this.lblBerufswunsch.Size = new System.Drawing.Size(80, 24);
            this.lblBerufswunsch.TabIndex = 615;
            this.lblBerufswunsch.Text = "Berufswunsch";
            // 
            // CtlKaQJExtern
            // 
            this.ActiveSQLQuery = this.qryExtern;
            this.Controls.Add(this.edtBerufswunsch);
            this.Controls.Add(this.lblBerufswunsch);
            this.Controls.Add(this.edtBetriebTelEmail);
            this.Controls.Add(this.lblBetriebTelEmail);
            this.Controls.Add(this.edtBetriebKontakt);
            this.Controls.Add(this.lblBetriebKontakt);
            this.Controls.Add(this.edtBetriebOrt);
            this.Controls.Add(this.lblBetriebOrt);
            this.Controls.Add(this.edtBetriebZusatz);
            this.Controls.Add(this.lblBetriebZusatz);
            this.Controls.Add(this.edtBetriebStrasse);
            this.Controls.Add(this.lblBetriebStrasse);
            this.Controls.Add(this.lblEinladung);
            this.Controls.Add(this.docEinladung);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.lblBetrieb);
            this.Controls.Add(this.docStage);
            this.Controls.Add(this.ddlEinsatzAls);
            this.Controls.Add(this.lblEinsatzAls);
            this.Controls.Add(this.lblEinsatzBis);
            this.Controls.Add(this.datEinsatzBis);
            this.Controls.Add(this.lblEinsatzVon);
            this.Controls.Add(this.datEinsatzVon);
            this.Controls.Add(this.dlgBetrieb);
            this.Controls.Add(this.lblBetriebName);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.grdExtern);
            this.Name = "CtlKaQJExtern";
            this.Size = new System.Drawing.Size(925, 600);
            this.Load += new System.EventHandler(this.CtlKaQJExtern_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryExtern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExtern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhasen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docStage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEinsatzAls.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlEinsatzAls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzAls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinsatzBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinsatzVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datEinsatzVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgBetrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinladung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docEinladung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebTelEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebTelEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebKontakt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebKontakt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetriebStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetriebStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufswunsch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerufswunsch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void Init(string TitleName, Image TitleImage, int FaLeistungID, int BaPersonID)
		{
			this.lblTitel.Text = TitleName;
			this.picTitle.Image = TitleImage;			
			this.FaLeistungID = FaLeistungID;	
			this.BaPersonID = BaPersonID;

			this.colEinsatzAls.ColumnEdit = grdExtern.GetLOVLookUpEdit("KaQjExternEinsatzals");
		}

		public override bool OnSaveData()
		{
			bool rslt = base.OnSaveData ();

			SetEditMode();
			FillExtern();

			return rslt;
		}


		private void FillExtern()
		{
			qryExtern.Fill(@"
				select	EXT.*,
						Betrieb = BET.FirmaName,
						BetriebStrasse = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
						BetriebZusatz = ADR.Zusatz,
						BetriebOrt = ADR.PLZ + IsNull(' ' + ADR.Ort, ''),
						BetriebKontakt = BET.KontaktPerson,
						BetriebTelEmail = BET.Telefon + IsNull(' / ' + BET.EMail, '')
				from	KaQJExtern EXT 
					left join KaBetrieb			BET on BET.KaBetriebID = EXT.BetriebID
					left join BaAdresse			ADR on ADR.KaBetriebID = BET.KaBetriebID
					left join KaZuteilFachbereich	ZUT on ZUT.BaPersonID = {1}
				      									   and ZUT.ZuteilungBis = (select max(ZUT1.ZuteilungBis) from KaZuteilFachbereich ZUT1 where ZUT1.BaPersonID = ZUT.BaPersonID)
				where	EXT.FaLeistungID = {0}
				and		(EXT.SichtbarSDFlag = {2} or EXT.SichtbarSDFlag = 1)
				order by EXT.EinsatzVon DESC",
                FaLeistungID, BaPersonID, Session.User.IsUserKA ? 0 : 1);

			if (qryExtern.Count > 0)
				this.BerufWunsch = qryExtern["Berufswunsch"].ToString();
		}

		private void SetEditMode()
		{
			DBUtil.ApplyFallRightsToSqlQuery(this.FaLeistungID, qryExtern);
			DBUtil.ApplyUserRightsToSqlQuery("CtlKaQJExtern", qryExtern);	

			qryExtern.EnableBoundFields();
		}

		public override object GetContextValue(string FieldName) 
		{ 
			switch (FieldName.ToUpper()) 
			{
				case "BAPERSONID":
					return this.BaPersonID;

				case "FALEISTUNGID":
					return this.FaLeistungID;		

				case "KAQJEXTERNID":
					return Convert.ToInt32(qryExtern["KaQJExternID"]);
			
				case "OWNERUSERID":
					return (int) DBUtil.ExecuteScalarSQL("select UserID from FaLeistung where FaLeistungID = {0}",FaLeistungID);
			}

			return base.GetContextValue(FieldName);
		}

		private void CtlKaQJExtern_Load(object sender, System.EventArgs e)
		{
			SetEditMode();
			FillExtern();
		}

		private void qryExtern_AfterInsert(object sender, System.EventArgs e)
		{
			qryExtern["FaLeistungID"] = this.FaLeistungID;
			qryExtern["Berufswunsch"] = this.BerufWunsch;
            qryExtern["SichtbarSDFlag"] = KaUtil.IsVisibleSD(this.BaPersonID);
		}

		private void dlgBetrieb_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
		{
			DlgAuswahl dlg = new DlgAuswahl();			
			if (dlg.BetriebKASuchen(dlgBetrieb.Text, e.ButtonClicked))
			{  
				qryExtern["Betrieb"] = dlg["Betrieb"];
				qryExtern["BetriebID"] = dlg["BetriebID"];

				dlgBetrieb.EditValue = dlg["Betrieb"];
				dlgBetrieb.LookupID = dlg["BetriebID"];

				qryExtern.Post();
			}
			else
				e.Cancel = true;
		}

		private void qryExtern_BeforePost(object sender, System.EventArgs e)
		{
			SaveBerufswunsch();
		}

		private void SaveBerufswunsch()
		{
			try
			{
				if (edtBerufswunsch.IsModified)
				{
					DBUtil.ExecSQL(@"
								update KaQJExtern 
								set    Berufswunsch = {0}
								where  FaLeistungID = {1}",
						edtBerufswunsch.Text,
						this.FaLeistungID);

					foreach (DataRow row in qryExtern.DataTable.Rows)
					{
						row["Berufswunsch"] = edtBerufswunsch.Text;
					}
				}
			}
			catch {}
		}

		private void edtBerufswunsch_Leave(object sender, System.EventArgs e)
		{
			SaveBerufswunsch();
		}
	}
}
