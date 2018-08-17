//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Drawing;
using KiSS4.DB;


namespace KiSS4.Inkasso
{
	
	
	public class CtlIkRechtlicheMassnahmenInkassofall : KiSS4.Gui.KissUserControl
	{
		
		private System.Windows.Forms.Panel panel2;
		
		private KiSS4.Gui.KissMemoEdit edtBemerkungen;
		
		private KiSS4.DB.SqlQuery qryIkAnzeige;
		
		private System.ComponentModel.IContainer components;
		
		private System.Windows.Forms.Panel pnTitle;
		
		private System.Windows.Forms.PictureBox picTitle;
		
		private KiSS4.Gui.KissLabel lblTitel;
		
		private KiSS4.Gui.KissGrid grdIkAnzeige;
		
		private DevExpress.XtraGrid.Views.Grid.GridView grvIkAnzeige;
		
		private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
		
		private DevExpress.XtraGrid.Columns.GridColumn colIkAnzeigeTyp;
		
		private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
		
		private KiSS4.Gui.KissLabel lblBemerkungen;
		
		private KiSS4.Gui.KissLookUpEdit edtGrundAbschluss;
		
		private KiSS4.Gui.KissLabel edtAbschlussGrund;
		
		private KiSS4.Gui.KissDateEdit edtAbgeschlossen;
		
		private KiSS4.Gui.KissLabel lblAbgeschlossenAm;
		
		private KiSS4.Gui.KissLookUpEdit edtAnzeigeTyp;
		
		private KiSS4.Gui.KissLabel lblAnzeigetyp;
		
		private KiSS4.Gui.KissTextEdit edtGrundEroeffnet;
		
		private KiSS4.Gui.KissLabel lblEroeffnungsGrund;
		
		private KiSS4.Gui.KissDateEdit edtEroeffnet;
		
		private KiSS4.Gui.KissLabel lblEroeffnetAm;
		

		private int FaLeistungID;
		
		public override string GetContextName() 
		{
			return "Ik";
		}

		public CtlIkRechtlicheMassnahmenInkassofall(Image titelImage, string titelText, int faLeistungID) : this()
		{
			this.picTitle.Image = titelImage;
			this.lblTitel.Text = titelText;
			this.FaLeistungID = faLeistungID;
			colIkAnzeigeTyp.ColumnEdit = grdIkAnzeige.GetLOVLookUpEdit("IkAnzeigeTyp");
			qryIkAnzeige.Fill(this.FaLeistungID);
		}
		
		public CtlIkRechtlicheMassnahmenInkassofall()
		{
			this.InitializeComponent();
		}
		
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkRechtlicheMassnahmenInkassofall));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.qryIkAnzeige = new KiSS4.DB.SqlQuery(this.components);
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtGrundAbschluss = new KiSS4.Gui.KissLookUpEdit();
            this.edtAbschlussGrund = new KiSS4.Gui.KissLabel();
            this.edtAbgeschlossen = new KiSS4.Gui.KissDateEdit();
            this.lblAbgeschlossenAm = new KiSS4.Gui.KissLabel();
            this.edtAnzeigeTyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblAnzeigetyp = new KiSS4.Gui.KissLabel();
            this.edtGrundEroeffnet = new KiSS4.Gui.KissTextEdit();
            this.lblEroeffnungsGrund = new KiSS4.Gui.KissLabel();
            this.edtEroeffnet = new KiSS4.Gui.KissDateEdit();
            this.lblEroeffnetAm = new KiSS4.Gui.KissLabel();
            this.grdIkAnzeige = new KiSS4.Gui.KissGrid();
            this.grvIkAnzeige = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkAnzeigeTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkAnzeige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundAbschluss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlossen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossenAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzeigeTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzeigeTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzeigetyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundEroeffnet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnetAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkAnzeige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIkAnzeige)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.edtBemerkungen);
            this.panel2.Controls.Add(this.lblBemerkungen);
            this.panel2.Controls.Add(this.edtGrundAbschluss);
            this.panel2.Controls.Add(this.edtAbschlussGrund);
            this.panel2.Controls.Add(this.edtAbgeschlossen);
            this.panel2.Controls.Add(this.lblAbgeschlossenAm);
            this.panel2.Controls.Add(this.edtAnzeigeTyp);
            this.panel2.Controls.Add(this.lblAnzeigetyp);
            this.panel2.Controls.Add(this.edtGrundEroeffnet);
            this.panel2.Controls.Add(this.lblEroeffnungsGrund);
            this.panel2.Controls.Add(this.edtEroeffnet);
            this.panel2.Controls.Add(this.lblEroeffnetAm);
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 200);
            this.panel2.TabIndex = 11;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkungen.DataMember = "Bemerkung";
            this.edtBemerkungen.DataSource = this.qryIkAnzeige;
            this.edtBemerkungen.Location = new System.Drawing.Point(112, 104);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Properties.Name = "txtBemerkungen.Properties";
            this.edtBemerkungen.Size = new System.Drawing.Size(551, 88);
            this.edtBemerkungen.TabIndex = 13;
            // 
            // qryIkAnzeige
            // 
            this.qryIkAnzeige.CanDelete = true;
            this.qryIkAnzeige.CanInsert = true;
            this.qryIkAnzeige.CanUpdate = true;
            this.qryIkAnzeige.HostControl = this;
            this.qryIkAnzeige.SelectStatement = resources.GetString("qryIkAnzeige.SelectStatement");
            this.qryIkAnzeige.TableName = "IkAnzeige";
            this.qryIkAnzeige.BeforePost += new System.EventHandler(this.qryIkAnzeige_BeforePost);
            this.qryIkAnzeige.AfterInsert += new System.EventHandler(this.qryIkAnzeige_AfterInsert);
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(8, 104);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(96, 24);
            this.lblBemerkungen.TabIndex = 12;
            this.lblBemerkungen.Text = "Bemerkung";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtGrundAbschluss
            // 
            this.edtGrundAbschluss.DataMember = "IkAnzeigeAbschlussGrundCode";
            this.edtGrundAbschluss.DataSource = this.qryIkAnzeige;
            this.edtGrundAbschluss.Location = new System.Drawing.Point(256, 72);
            this.edtGrundAbschluss.LOVName = "IkAnzeigeAbschlussGrund";
            this.edtGrundAbschluss.Name = "edtGrundAbschluss";
            this.edtGrundAbschluss.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundAbschluss.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundAbschluss.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundAbschluss.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundAbschluss.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundAbschluss.Properties.Appearance.Options.UseFont = true;
            this.edtGrundAbschluss.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrundAbschluss.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundAbschluss.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrundAbschluss.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrundAbschluss.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGrundAbschluss.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGrundAbschluss.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundAbschluss.Properties.Name = "cboGrundAbschluss.Properties";
            this.edtGrundAbschluss.Properties.NullText = "";
            this.edtGrundAbschluss.Properties.ShowFooter = false;
            this.edtGrundAbschluss.Properties.ShowHeader = false;
            this.edtGrundAbschluss.Size = new System.Drawing.Size(407, 24);
            this.edtGrundAbschluss.TabIndex = 11;
            // 
            // edtAbschlussGrund
            // 
            this.edtAbschlussGrund.Location = new System.Drawing.Point(216, 72);
            this.edtAbschlussGrund.Name = "edtAbschlussGrund";
            this.edtAbschlussGrund.Size = new System.Drawing.Size(40, 24);
            this.edtAbschlussGrund.TabIndex = 10;
            this.edtAbschlussGrund.Text = "Grund";
            this.edtAbschlussGrund.UseCompatibleTextRendering = true;
            // 
            // edtAbgeschlossen
            // 
            this.edtAbgeschlossen.DataMember = "DatumBis";
            this.edtAbgeschlossen.DataSource = this.qryIkAnzeige;
            this.edtAbgeschlossen.EditValue = null;
            this.edtAbgeschlossen.Location = new System.Drawing.Point(112, 72);
            this.edtAbgeschlossen.Name = "edtAbgeschlossen";
            this.edtAbgeschlossen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAbgeschlossen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbgeschlossen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbgeschlossen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbgeschlossen.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbgeschlossen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbgeschlossen.Properties.Appearance.Options.UseFont = true;
            this.edtAbgeschlossen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbgeschlossen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAbgeschlossen.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbgeschlossen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbgeschlossen.Properties.Name = "dateAbgeschlossen.Properties";
            this.edtAbgeschlossen.Properties.ShowToday = false;
            this.edtAbgeschlossen.Size = new System.Drawing.Size(96, 24);
            this.edtAbgeschlossen.TabIndex = 9;
            // 
            // lblAbgeschlossenAm
            // 
            this.lblAbgeschlossenAm.Location = new System.Drawing.Point(8, 72);
            this.lblAbgeschlossenAm.Name = "lblAbgeschlossenAm";
            this.lblAbgeschlossenAm.Size = new System.Drawing.Size(96, 24);
            this.lblAbgeschlossenAm.TabIndex = 8;
            this.lblAbgeschlossenAm.Text = "Abgeschlossen am";
            this.lblAbgeschlossenAm.UseCompatibleTextRendering = true;
            // 
            // edtAnzeigeTyp
            // 
            this.edtAnzeigeTyp.DataMember = "IkAnzeigeTypCode";
            this.edtAnzeigeTyp.DataSource = this.qryIkAnzeige;
            this.edtAnzeigeTyp.Location = new System.Drawing.Point(112, 40);
            this.edtAnzeigeTyp.LOVName = "IkAnzeigeTyp";
            this.edtAnzeigeTyp.Name = "edtAnzeigeTyp";
            this.edtAnzeigeTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnzeigeTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzeigeTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzeigeTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzeigeTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzeigeTyp.Properties.Appearance.Options.UseFont = true;
            this.edtAnzeigeTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAnzeigeTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzeigeTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAnzeigeTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAnzeigeTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAnzeigeTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAnzeigeTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzeigeTyp.Properties.Name = "cboAnzeigeTyp.Properties";
            this.edtAnzeigeTyp.Properties.NullText = "";
            this.edtAnzeigeTyp.Properties.ShowFooter = false;
            this.edtAnzeigeTyp.Properties.ShowHeader = false;
            this.edtAnzeigeTyp.Size = new System.Drawing.Size(551, 24);
            this.edtAnzeigeTyp.TabIndex = 7;
            // 
            // lblAnzeigetyp
            // 
            this.lblAnzeigetyp.Location = new System.Drawing.Point(8, 40);
            this.lblAnzeigetyp.Name = "lblAnzeigetyp";
            this.lblAnzeigetyp.Size = new System.Drawing.Size(96, 24);
            this.lblAnzeigetyp.TabIndex = 6;
            this.lblAnzeigetyp.Text = "Anzeigetyp";
            this.lblAnzeigetyp.UseCompatibleTextRendering = true;
            // 
            // edtGrundEroeffnet
            // 
            this.edtGrundEroeffnet.DataMember = "IkAnzeigeEroeffnungGrundCode";
            this.edtGrundEroeffnet.DataSource = this.qryIkAnzeige;
            this.edtGrundEroeffnet.Location = new System.Drawing.Point(256, 8);
            this.edtGrundEroeffnet.Name = "edtGrundEroeffnet";
            this.edtGrundEroeffnet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundEroeffnet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundEroeffnet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundEroeffnet.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundEroeffnet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundEroeffnet.Properties.Appearance.Options.UseFont = true;
            this.edtGrundEroeffnet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundEroeffnet.Properties.Name = "txtGrundEroeffnet.Properties";
            this.edtGrundEroeffnet.Size = new System.Drawing.Size(407, 24);
            this.edtGrundEroeffnet.TabIndex = 5;
            // 
            // lblEroeffnungsGrund
            // 
            this.lblEroeffnungsGrund.Location = new System.Drawing.Point(216, 8);
            this.lblEroeffnungsGrund.Name = "lblEroeffnungsGrund";
            this.lblEroeffnungsGrund.Size = new System.Drawing.Size(40, 24);
            this.lblEroeffnungsGrund.TabIndex = 4;
            this.lblEroeffnungsGrund.Text = "Grund";
            this.lblEroeffnungsGrund.UseCompatibleTextRendering = true;
            // 
            // edtEroeffnet
            // 
            this.edtEroeffnet.DataMember = "DatumVon";
            this.edtEroeffnet.DataSource = this.qryIkAnzeige;
            this.edtEroeffnet.EditValue = null;
            this.edtEroeffnet.Location = new System.Drawing.Point(112, 8);
            this.edtEroeffnet.Name = "edtEroeffnet";
            this.edtEroeffnet.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEroeffnet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnet.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnet.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEroeffnet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnet.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEroeffnet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnet.Properties.Name = "dateEroeffnet.Properties";
            this.edtEroeffnet.Properties.ShowToday = false;
            this.edtEroeffnet.Size = new System.Drawing.Size(96, 24);
            this.edtEroeffnet.TabIndex = 3;
            // 
            // lblEroeffnetAm
            // 
            this.lblEroeffnetAm.Location = new System.Drawing.Point(8, 8);
            this.lblEroeffnetAm.Name = "lblEroeffnetAm";
            this.lblEroeffnetAm.Size = new System.Drawing.Size(96, 24);
            this.lblEroeffnetAm.TabIndex = 2;
            this.lblEroeffnetAm.Text = "Eröffnet am";
            this.lblEroeffnetAm.UseCompatibleTextRendering = true;
            // 
            // grdIkAnzeige
            // 
            this.grdIkAnzeige.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdIkAnzeige.DataSource = this.qryIkAnzeige;
            // 
            // 
            // 
            this.grdIkAnzeige.EmbeddedNavigator.Name = "grdIkAnzeige.EmbeddedNavigator";
            this.grdIkAnzeige.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdIkAnzeige.Location = new System.Drawing.Point(0, 44);
            this.grdIkAnzeige.MainView = this.grvIkAnzeige;
            this.grdIkAnzeige.Name = "grdIkAnzeige";
            this.grdIkAnzeige.Size = new System.Drawing.Size(663, 308);
            this.grdIkAnzeige.TabIndex = 12;
            this.grdIkAnzeige.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIkAnzeige});
            // 
            // grvIkAnzeige
            // 
            this.grvIkAnzeige.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvIkAnzeige.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.Empty.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.Empty.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.EvenRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIkAnzeige.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvIkAnzeige.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.FocusedCell.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvIkAnzeige.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvIkAnzeige.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.FocusedRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIkAnzeige.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvIkAnzeige.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIkAnzeige.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIkAnzeige.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.GroupRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvIkAnzeige.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvIkAnzeige.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvIkAnzeige.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvIkAnzeige.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvIkAnzeige.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvIkAnzeige.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.OddRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvIkAnzeige.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.Row.Options.UseBackColor = true;
            this.grvIkAnzeige.Appearance.Row.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvIkAnzeige.Appearance.SelectedRow.Options.UseFont = true;
            this.grvIkAnzeige.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvIkAnzeige.Appearance.VertLine.Options.UseBackColor = true;
            this.grvIkAnzeige.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvIkAnzeige.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colIkAnzeigeTyp,
            this.colDatumBis});
            this.grvIkAnzeige.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvIkAnzeige.GridControl = this.grdIkAnzeige;
            this.grvIkAnzeige.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvIkAnzeige.Name = "grvIkAnzeige";
            this.grvIkAnzeige.OptionsBehavior.Editable = false;
            this.grvIkAnzeige.OptionsCustomization.AllowFilter = false;
            this.grvIkAnzeige.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvIkAnzeige.OptionsNavigation.AutoFocusNewRow = true;
            this.grvIkAnzeige.OptionsNavigation.UseTabKey = false;
            this.grvIkAnzeige.OptionsView.ColumnAutoWidth = false;
            this.grvIkAnzeige.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvIkAnzeige.OptionsView.ShowGroupPanel = false;
            this.grvIkAnzeige.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Eröffnet am";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 120;
            // 
            // colIkAnzeigeTyp
            // 
            this.colIkAnzeigeTyp.Caption = "Typ";
            this.colIkAnzeigeTyp.FieldName = "IkAnzeigeTypCode";
            this.colIkAnzeigeTyp.Name = "colIkAnzeigeTyp";
            this.colIkAnzeigeTyp.Visible = true;
            this.colIkAnzeigeTyp.VisibleIndex = 1;
            this.colIkAnzeigeTyp.Width = 422;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Abgeschlossen am";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 2;
            this.colDatumBis.Width = 120;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.picTitle);
            this.pnTitle.Controls.Add(this.lblTitel);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(680, 38);
            this.pnTitle.TabIndex = 13;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 1;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(500, 20);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "FaLeistung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // CtlIkRechtlicheMassnahmenInkassofall
            // 
            this.ActiveSQLQuery = this.qryIkAnzeige;
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.grdIkAnzeige);
            this.Controls.Add(this.panel2);
            this.Name = "CtlIkRechtlicheMassnahmenInkassofall";
            this.Size = new System.Drawing.Size(680, 552);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkAnzeige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundAbschluss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlossen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbgeschlossenAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzeigeTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzeigeTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzeigetyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundEroeffnet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungsGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnetAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIkAnzeige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIkAnzeige)).EndInit();
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
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
		
		private void qryIkAnzeige_AfterInsert(object sender, System.EventArgs e)
		{

			qryIkAnzeige["FaLeistungID"] = this.FaLeistungID;
			edtEroeffnet.Focus();
		}
		
		private void qryIkAnzeige_BeforePost(object sender, System.EventArgs e)
		{

			if (DBNull.Value == qryIkAnzeige["DatumVon"]) 
			{
				edtEroeffnet.Focus();
				throw new KissInfoException(KissMsg.GetMLMessage("CtlIkRechtlicheMassnahmenInkassofall", "EroeffnungsDatumEingeben", "Bitte geben Sie das Eröffnungsdatum ein.", KissMsgCode.MsgInfo));
			}
			if (DBNull.Value == qryIkAnzeige["IkAnzeigeTypCode"]) 
			{
				edtAnzeigeTyp.Focus();
				throw new KissInfoException(KissMsg.GetMLMessage("CtlIkRechtlicheMassnahmenInkassofall", "AnzeigetypWaehlen", "Bitte wählen Sie einen Anzeigetyp aus.", KissMsgCode.MsgInfo));
			}
			if (DBNull.Value != qryIkAnzeige["DatumBis"]) 
			{
			    if ((DateTime)qryIkAnzeige["DatumBis"] < (DateTime)qryIkAnzeige["DatumVon"]) 
				{
					edtAbgeschlossen.Focus();
					throw new KissInfoException(KissMsg.GetMLMessage("CtlIkRechtlicheMassnahmenInkassofall", "AbschlussDatVorEroeffDat", "Das Abschlussdatum kann nicht vor dem Eröffnungsdatum liegen.", KissMsgCode.MsgInfo));
				}
			}
		}
	}
}