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
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
	
	
	public class CtlKaVermittlungResultatVorschlag : KiSS4.Gui.KissUserControl
	{
		
		private KiSS4.Gui.KissButtonEdit edtEinsatzplatzBezeichnung;
		
		private KiSS4.Gui.KissGrid grdPersonen;
		
		private KiSS4.DB.SqlQuery qryKandidaten;
		
		private System.ComponentModel.IContainer components;
		
		private KiSS4.Gui.KissLabel lblDatum;
		
		private KiSS4.Gui.KissTextEdit edtZustKa;
		
		private KiSS4.Gui.KissTextEdit edtNameVorname;
		
		private KiSS4.Gui.KissLabel lblZustaendigKA;
		
		private KiSS4.Gui.KissLabel lblNameVorname;
		
		private KiSS4.Gui.KissLabel lblResultat;
		
		private KiSS4.Gui.KissLabel lblResultatErfassen;
		
		private KiSS4.Gui.KissTextEdit edtBetrieb;
		
		private KiSS4.Gui.KissButton btnSpeichern;
		
		private KiSS4.Gui.KissLookUpEdit edtVorschlagResultat;
		
		private KiSS4.Gui.KissDateEdit edtResultatDatum;
		
		private KiSS4.Gui.KissLabel lblBetrieb;
		
		private KiSS4.Gui.KissButton btnKandidatenSuchen;
		
		private KiSS4.Gui.KissLabel lblNrBezeichnung;
		
		private KiSS4.Gui.KissButton btnEinsatzplatzDetails;
		
		private KiSS4.Gui.KissLabel lblTitelEinsatzplatz;
		
		private DevExpress.XtraGrid.Views.Grid.GridView grvPersonen;
		
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		
		private DevExpress.XtraGrid.Columns.GridColumn colVorname;
		
		private DevExpress.XtraGrid.Columns.GridColumn colGebDat;
		
		private DevExpress.XtraGrid.Views.Grid.GridView grvKandidaten_alt;
		
		public CtlKaVermittlungResultatVorschlag()
		{
			this.InitializeComponent();

			btnSpeichern.Enabled = false;
			btnEinsatzplatzDetails.Enabled = false;
			btnKandidatenSuchen.Enabled = false;
		}
		
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaVermittlungResultatVorschlag));
			this.edtEinsatzplatzBezeichnung = new KiSS4.Gui.KissButtonEdit();
			this.grdPersonen = new KiSS4.Gui.KissGrid();
			this.lblTitelEinsatzplatz = new KiSS4.Gui.KissLabel();
			this.btnEinsatzplatzDetails = new KiSS4.Gui.KissButton();
			this.lblNrBezeichnung = new KiSS4.Gui.KissLabel();
			this.btnKandidatenSuchen = new KiSS4.Gui.KissButton();
			this.lblBetrieb = new KiSS4.Gui.KissLabel();
			this.edtResultatDatum = new KiSS4.Gui.KissDateEdit();
			this.edtVorschlagResultat = new KiSS4.Gui.KissLookUpEdit();
			this.btnSpeichern = new KiSS4.Gui.KissButton();
			this.edtBetrieb = new KiSS4.Gui.KissTextEdit();
			this.lblResultatErfassen = new KiSS4.Gui.KissLabel();
			this.lblResultat = new KiSS4.Gui.KissLabel();
			this.lblNameVorname = new KiSS4.Gui.KissLabel();
			this.lblZustaendigKA = new KiSS4.Gui.KissLabel();
			this.edtNameVorname = new KiSS4.Gui.KissTextEdit();
			this.edtZustKa = new KiSS4.Gui.KissTextEdit();
			this.lblDatum = new KiSS4.Gui.KissLabel();
			this.colGebDat = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grvKandidaten_alt = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.grvPersonen = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.qryKandidaten = new KiSS4.DB.SqlQuery(this.components);
			((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzBezeichnung.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTitelEinsatzplatz)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNrBezeichnung)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtVorschlagResultat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtVorschlagResultat.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblResultatErfassen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblResultat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtNameVorname.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtZustKa.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvKandidaten_alt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
			this.SuspendLayout();
			// 
			// edtEinsatzplatzBezeichnung
			// 
			this.edtEinsatzplatzBezeichnung.Location = new System.Drawing.Point(111, 24);
			this.edtEinsatzplatzBezeichnung.Name = "edtEinsatzplatzBezeichnung";
			this.edtEinsatzplatzBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.edtEinsatzplatzBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtEinsatzplatzBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtEinsatzplatzBezeichnung.Properties.Appearance.Options.UseBackColor = true;
			this.edtEinsatzplatzBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
			this.edtEinsatzplatzBezeichnung.Properties.Appearance.Options.UseFont = true;
			this.edtEinsatzplatzBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtEinsatzplatzBezeichnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
						new DevExpress.XtraEditors.Controls.EditorButton()});
			this.edtEinsatzplatzBezeichnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.edtEinsatzplatzBezeichnung.Size = new System.Drawing.Size(283, 24);
			this.edtEinsatzplatzBezeichnung.TabIndex = 0;
			this.edtEinsatzplatzBezeichnung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtEinsatzplatzBezeichnung_UserModifiedFld);
			// 
			// grdPersonen
			// 
			this.grdPersonen.DataSource = this.qryKandidaten;
			this.grdPersonen.EmbeddedNavigator.Name = "";
			this.grdPersonen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
			this.grdPersonen.Location = new System.Drawing.Point(4, 83);
			this.grdPersonen.MainView = this.grvPersonen;
			this.grdPersonen.Name = "grdPersonen";
			this.grdPersonen.Size = new System.Drawing.Size(542, 200);
			this.grdPersonen.TabIndex = 0;
			this.grdPersonen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
						this.grvKandidaten_alt,
						this.grvPersonen});
			// 
			// lblTitelEinsatzplatz
			// 
			this.lblTitelEinsatzplatz.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
			this.lblTitelEinsatzplatz.Location = new System.Drawing.Point(4, 5);
			this.lblTitelEinsatzplatz.Name = "lblTitelEinsatzplatz";
			this.lblTitelEinsatzplatz.Size = new System.Drawing.Size(98, 16);
			this.lblTitelEinsatzplatz.TabIndex = 0;
			this.lblTitelEinsatzplatz.Text = "Einsatzplatz";
			this.lblTitelEinsatzplatz.UseCompatibleTextRendering = true;
			// 
			// btnEinsatzplatzDetails
			// 
			this.btnEinsatzplatzDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEinsatzplatzDetails.Location = new System.Drawing.Point(407, 24);
			this.btnEinsatzplatzDetails.Name = "btnEinsatzplatzDetails";
			this.btnEinsatzplatzDetails.Size = new System.Drawing.Size(90, 24);
			this.btnEinsatzplatzDetails.TabIndex = 1;
			this.btnEinsatzplatzDetails.Text = "Details";
			this.btnEinsatzplatzDetails.UseCompatibleTextRendering = true;
			this.btnEinsatzplatzDetails.UseVisualStyleBackColor = true;
			this.btnEinsatzplatzDetails.Click += new System.EventHandler(this.btnEinsatzplatzDetails_Click);
			// 
			// lblNrBezeichnung
			// 
			this.lblNrBezeichnung.Location = new System.Drawing.Point(4, 24);
			this.lblNrBezeichnung.Name = "lblNrBezeichnung";
			this.lblNrBezeichnung.Size = new System.Drawing.Size(100, 23);
			this.lblNrBezeichnung.TabIndex = 1;
			this.lblNrBezeichnung.Text = "Nr./Bezeichnung";
			this.lblNrBezeichnung.UseCompatibleTextRendering = true;
			// 
			// btnKandidatenSuchen
			// 
			this.btnKandidatenSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnKandidatenSuchen.Location = new System.Drawing.Point(407, 52);
			this.btnKandidatenSuchen.Name = "btnKandidatenSuchen";
			this.btnKandidatenSuchen.Size = new System.Drawing.Size(139, 24);
			this.btnKandidatenSuchen.TabIndex = 2;
			this.btnKandidatenSuchen.Text = "KandidatInnen suchen";
			this.btnKandidatenSuchen.UseCompatibleTextRendering = true;
			this.btnKandidatenSuchen.UseVisualStyleBackColor = false;
			this.btnKandidatenSuchen.Click += new System.EventHandler(this.btnKandidatenSuchen_Click);
			// 
			// lblBetrieb
			// 
			this.lblBetrieb.Location = new System.Drawing.Point(4, 53);
			this.lblBetrieb.Name = "lblBetrieb";
			this.lblBetrieb.Size = new System.Drawing.Size(100, 23);
			this.lblBetrieb.TabIndex = 2;
			this.lblBetrieb.Text = "Betrieb";
			this.lblBetrieb.UseCompatibleTextRendering = true;
			// 
			// edtResultatDatum
			// 
			this.edtResultatDatum.EditValue = null;
			this.edtResultatDatum.Location = new System.Drawing.Point(111, 380);
			this.edtResultatDatum.Name = "edtResultatDatum";
			this.edtResultatDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.edtResultatDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.edtResultatDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtResultatDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtResultatDatum.Properties.Appearance.Options.UseBackColor = true;
			this.edtResultatDatum.Properties.Appearance.Options.UseBorderColor = true;
			this.edtResultatDatum.Properties.Appearance.Options.UseFont = true;
			this.edtResultatDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtResultatDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
						new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.edtResultatDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.edtResultatDatum.Properties.ShowToday = false;
			this.edtResultatDatum.Size = new System.Drawing.Size(100, 24);
			this.edtResultatDatum.TabIndex = 3;
			// 
			// edtVorschlagResultat
			// 
			this.edtVorschlagResultat.Location = new System.Drawing.Point(275, 380);
			this.edtVorschlagResultat.LOVName = "KaVorschlagResultat";
			this.edtVorschlagResultat.Name = "edtVorschlagResultat";
			this.edtVorschlagResultat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.edtVorschlagResultat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtVorschlagResultat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtVorschlagResultat.Properties.Appearance.Options.UseBackColor = true;
			this.edtVorschlagResultat.Properties.Appearance.Options.UseBorderColor = true;
			this.edtVorschlagResultat.Properties.Appearance.Options.UseFont = true;
			this.edtVorschlagResultat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtVorschlagResultat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
						new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.edtVorschlagResultat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.edtVorschlagResultat.Properties.NullText = "";
			this.edtVorschlagResultat.Properties.ShowFooter = false;
			this.edtVorschlagResultat.Properties.ShowHeader = false;
			this.edtVorschlagResultat.Size = new System.Drawing.Size(175, 24);
			this.edtVorschlagResultat.TabIndex = 4;
			// 
			// btnSpeichern
			// 
			this.btnSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSpeichern.Location = new System.Drawing.Point(111, 411);
			this.btnSpeichern.Name = "btnSpeichern";
			this.btnSpeichern.Size = new System.Drawing.Size(123, 24);
			this.btnSpeichern.TabIndex = 5;
			this.btnSpeichern.Text = "Resultat speichern";
			this.btnSpeichern.UseCompatibleTextRendering = true;
			this.btnSpeichern.UseVisualStyleBackColor = false;
			this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
			// 
			// edtBetrieb
			// 
			this.edtBetrieb.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
			this.edtBetrieb.Location = new System.Drawing.Point(111, 53);
			this.edtBetrieb.Name = "edtBetrieb";
			this.edtBetrieb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.edtBetrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtBetrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtBetrieb.Properties.Appearance.Options.UseBackColor = true;
			this.edtBetrieb.Properties.Appearance.Options.UseBorderColor = true;
			this.edtBetrieb.Properties.Appearance.Options.UseFont = true;
			this.edtBetrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtBetrieb.Properties.ReadOnly = true;
			this.edtBetrieb.Size = new System.Drawing.Size(283, 24);
			this.edtBetrieb.TabIndex = 5;
			// 
			// lblResultatErfassen
			// 
			this.lblResultatErfassen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
			this.lblResultatErfassen.Location = new System.Drawing.Point(2, 358);
			this.lblResultatErfassen.Name = "lblResultatErfassen";
			this.lblResultatErfassen.Size = new System.Drawing.Size(134, 16);
			this.lblResultatErfassen.TabIndex = 7;
			this.lblResultatErfassen.Text = "Resultat erfassen";
			this.lblResultatErfassen.UseCompatibleTextRendering = true;
			// 
			// lblResultat
			// 
			this.lblResultat.Location = new System.Drawing.Point(222, 380);
			this.lblResultat.Name = "lblResultat";
			this.lblResultat.Size = new System.Drawing.Size(51, 24);
			this.lblResultat.TabIndex = 10;
			this.lblResultat.Text = "Resultat";
			this.lblResultat.UseCompatibleTextRendering = true;
			// 
			// lblNameVorname
			// 
			this.lblNameVorname.Location = new System.Drawing.Point(4, 289);
			this.lblNameVorname.Name = "lblNameVorname";
			this.lblNameVorname.Size = new System.Drawing.Size(100, 23);
			this.lblNameVorname.TabIndex = 19;
			this.lblNameVorname.Text = "Name/ Vorname";
			this.lblNameVorname.UseCompatibleTextRendering = true;
			// 
			// lblZustaendigKA
			// 
			this.lblZustaendigKA.Location = new System.Drawing.Point(4, 319);
			this.lblZustaendigKA.Name = "lblZustaendigKA";
			this.lblZustaendigKA.Size = new System.Drawing.Size(100, 23);
			this.lblZustaendigKA.TabIndex = 26;
			this.lblZustaendigKA.Text = "Zust�ndig KA";
			this.lblZustaendigKA.UseCompatibleTextRendering = true;
			// 
			// edtNameVorname
			// 
			this.edtNameVorname.DataMember = "NameVorname";
			this.edtNameVorname.DataSource = this.qryKandidaten;
			this.edtNameVorname.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
			this.edtNameVorname.Location = new System.Drawing.Point(110, 288);
			this.edtNameVorname.Name = "edtNameVorname";
			this.edtNameVorname.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.edtNameVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtNameVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtNameVorname.Properties.Appearance.Options.UseBackColor = true;
			this.edtNameVorname.Properties.Appearance.Options.UseBorderColor = true;
			this.edtNameVorname.Properties.Appearance.Options.UseFont = true;
			this.edtNameVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtNameVorname.Properties.ReadOnly = true;
			this.edtNameVorname.Size = new System.Drawing.Size(284, 24);
			this.edtNameVorname.TabIndex = 27;
			// 
			// edtZustKa
			// 
			this.edtZustKa.DataMember = "ZustKa";
			this.edtZustKa.DataSource = this.qryKandidaten;
			this.edtZustKa.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
			this.edtZustKa.Location = new System.Drawing.Point(110, 318);
			this.edtZustKa.Name = "edtZustKa";
			this.edtZustKa.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.edtZustKa.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.edtZustKa.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.edtZustKa.Properties.Appearance.Options.UseBackColor = true;
			this.edtZustKa.Properties.Appearance.Options.UseBorderColor = true;
			this.edtZustKa.Properties.Appearance.Options.UseFont = true;
			this.edtZustKa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.edtZustKa.Properties.ReadOnly = true;
			this.edtZustKa.Size = new System.Drawing.Size(284, 24);
			this.edtZustKa.TabIndex = 28;
			// 
			// lblDatum
			// 
			this.lblDatum.Location = new System.Drawing.Point(4, 380);
			this.lblDatum.Name = "lblDatum";
			this.lblDatum.Size = new System.Drawing.Size(98, 24);
			this.lblDatum.TabIndex = 29;
			this.lblDatum.Text = "Datum";
			this.lblDatum.UseCompatibleTextRendering = true;
			// 
			// colGebDat
			// 
			this.colGebDat.Caption = "Geburtstag";
			this.colGebDat.DisplayFormat.FormatString = "dd.MM.yyyy";
			this.colGebDat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colGebDat.FieldName = "GebDat";
			this.colGebDat.Name = "colGebDat";
			this.colGebDat.Visible = true;
			this.colGebDat.VisibleIndex = 2;
			this.colGebDat.Width = 92;
			// 
			// colName
			// 
			this.colName.Caption = "Name";
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			this.colName.Width = 203;
			// 
			// colVorname
			// 
			this.colVorname.Caption = "Vorname";
			this.colVorname.FieldName = "Vorname";
			this.colVorname.Name = "colVorname";
			this.colVorname.Visible = true;
			this.colVorname.VisibleIndex = 1;
			this.colVorname.Width = 207;
			// 
			// grvKandidaten_alt
			// 
			this.grvKandidaten_alt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grvKandidaten_alt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.Empty.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.Empty.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.EvenRow.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvKandidaten_alt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.grvKandidaten_alt.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.FocusedCell.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grvKandidaten_alt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvKandidaten_alt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.grvKandidaten_alt.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.FocusedRow.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grvKandidaten_alt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grvKandidaten_alt.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grvKandidaten_alt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvKandidaten_alt.Appearance.GroupRow.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.GroupRow.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.GroupRow.Options.UseForeColor = true;
			this.grvKandidaten_alt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grvKandidaten_alt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grvKandidaten_alt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grvKandidaten_alt.Appearance.HeaderPanel.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.grvKandidaten_alt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvKandidaten_alt.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grvKandidaten_alt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.grvKandidaten_alt.Appearance.HorzLine.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.OddRow.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.grvKandidaten_alt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.Row.Options.UseBackColor = true;
			this.grvKandidaten_alt.Appearance.Row.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvKandidaten_alt.Appearance.SelectedRow.Options.UseFont = true;
			this.grvKandidaten_alt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.grvKandidaten_alt.Appearance.VertLine.Options.UseBackColor = true;
			this.grvKandidaten_alt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grvKandidaten_alt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grvKandidaten_alt.GridControl = this.grdPersonen;
			this.grvKandidaten_alt.Name = "grvKandidaten_alt";
			this.grvKandidaten_alt.OptionsBehavior.Editable = false;
			this.grvKandidaten_alt.OptionsCustomization.AllowFilter = false;
			this.grvKandidaten_alt.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grvKandidaten_alt.OptionsNavigation.AutoFocusNewRow = true;
			this.grvKandidaten_alt.OptionsNavigation.UseTabKey = false;
			this.grvKandidaten_alt.OptionsView.ColumnAutoWidth = false;
			this.grvKandidaten_alt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grvKandidaten_alt.OptionsView.ShowGroupPanel = false;
			this.grvKandidaten_alt.OptionsView.ShowIndicator = false;
			// 
			// grvPersonen
			// 
			this.grvPersonen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grvPersonen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.Empty.Options.UseBackColor = true;
			this.grvPersonen.Appearance.Empty.Options.UseFont = true;
			this.grvPersonen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.EvenRow.Options.UseFont = true;
			this.grvPersonen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvPersonen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			this.grvPersonen.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grvPersonen.Appearance.FocusedCell.Options.UseFont = true;
			this.grvPersonen.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grvPersonen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			this.grvPersonen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			this.grvPersonen.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvPersonen.Appearance.FocusedRow.Options.UseFont = true;
			this.grvPersonen.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grvPersonen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grvPersonen.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grvPersonen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grvPersonen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvPersonen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvPersonen.Appearance.GroupRow.Options.UseBackColor = true;
			this.grvPersonen.Appearance.GroupRow.Options.UseFont = true;
			this.grvPersonen.Appearance.GroupRow.Options.UseForeColor = true;
			this.grvPersonen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grvPersonen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grvPersonen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvPersonen.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grvPersonen.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grvPersonen.Appearance.HeaderPanel.Options.UseFont = true;
			this.grvPersonen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			this.grvPersonen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvPersonen.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvPersonen.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grvPersonen.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grvPersonen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			this.grvPersonen.Appearance.HorzLine.Options.UseBackColor = true;
			this.grvPersonen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.OddRow.Options.UseFont = true;
			this.grvPersonen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.grvPersonen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.Row.Options.UseBackColor = true;
			this.grvPersonen.Appearance.Row.Options.UseFont = true;
			this.grvPersonen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvPersonen.Appearance.SelectedRow.Options.UseFont = true;
			this.grvPersonen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			this.grvPersonen.Appearance.VertLine.Options.UseBackColor = true;
			this.grvPersonen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grvPersonen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
						this.colName,
						this.colVorname,
						this.colGebDat});
			this.grvPersonen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			this.grvPersonen.GridControl = this.grdPersonen;
			this.grvPersonen.Name = "grvPersonen";
			this.grvPersonen.OptionsBehavior.Editable = false;
			this.grvPersonen.OptionsCustomization.AllowFilter = false;
			this.grvPersonen.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grvPersonen.OptionsNavigation.AutoFocusNewRow = true;
			this.grvPersonen.OptionsNavigation.UseTabKey = false;
			this.grvPersonen.OptionsView.ColumnAutoWidth = false;
			this.grvPersonen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grvPersonen.OptionsView.ShowGroupPanel = false;
			this.grvPersonen.OptionsView.ShowIndicator = false;
			// 
			// qryKandidaten
			// 
			this.qryKandidaten.HostControl = this;
			this.qryKandidaten.SelectStatement = resources.GetString("qryKandidaten.SelectStatement");
			this.qryKandidaten.TableName = "KaVermittlungVorschlag";
			this.qryKandidaten.AfterFill += new System.EventHandler(this.qryKandidaten_AfterFill);
			// 
			// CtlKaVermittlungResultatVorschlag
			// 
			this.ActiveSQLQuery = this.qryKandidaten;
			this.Controls.Add(this.lblDatum);
			this.Controls.Add(this.edtZustKa);
			this.Controls.Add(this.edtNameVorname);
			this.Controls.Add(this.lblZustaendigKA);
			this.Controls.Add(this.lblNameVorname);
			this.Controls.Add(this.lblResultat);
			this.Controls.Add(this.lblResultatErfassen);
			this.Controls.Add(this.edtBetrieb);
			this.Controls.Add(this.btnSpeichern);
			this.Controls.Add(this.edtVorschlagResultat);
			this.Controls.Add(this.edtResultatDatum);
			this.Controls.Add(this.lblBetrieb);
			this.Controls.Add(this.btnKandidatenSuchen);
			this.Controls.Add(this.lblNrBezeichnung);
			this.Controls.Add(this.btnEinsatzplatzDetails);
			this.Controls.Add(this.lblTitelEinsatzplatz);
			this.Controls.Add(this.grdPersonen);
			this.Controls.Add(this.edtEinsatzplatzBezeichnung);
			this.Name = "CtlKaVermittlungResultatVorschlag";
			this.Size = new System.Drawing.Size(561, 446);
			((System.ComponentModel.ISupportInitialize)(this.edtEinsatzplatzBezeichnung.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblTitelEinsatzplatz)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNrBezeichnung)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblBetrieb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtResultatDatum.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtVorschlagResultat.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtVorschlagResultat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtBetrieb.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblResultatErfassen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblResultat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblZustaendigKA)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtNameVorname.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtZustKa.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvKandidaten_alt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvPersonen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
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
		
		private void qryKandidaten_AfterFill(object sender, System.EventArgs e)
		{

			btnSpeichern.Enabled = (qryKandidaten.Count > 0 && DBUtil.UserHasRight("CtlKaVermittlungResultatVorschlag", "UI"));
		}
		
		private void btnEinsatzplatzDetails_Click(object sender, System.EventArgs e)
		{

			FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", edtEinsatzplatzBezeichnung.LookupID);
		}
		
		private void btnKandidatenSuchen_Click(object sender, System.EventArgs e)
		{

			if (DBUtil.IsEmpty(edtEinsatzplatzBezeichnung.LookupID))
				qryKandidaten.Fill(-1);
			else
				qryKandidaten.Fill(edtEinsatzplatzBezeichnung.LookupID);
		}
		
		private void btnSpeichern_Click(object sender, System.EventArgs e)
		{

			if (DBUtil.IsEmpty(edtVorschlagResultat.EditValue))
			{
				KissMsg.ShowInfo("CtlKaVermittlungResultatVorschlag", "VorschlagResultatLeer", "Vorschlag Resultat darf nicht leer sein!");
				return;
			}
			
			if (DBUtil.IsEmpty(edtResultatDatum.EditValue))
			{
				KissMsg.ShowInfo("CtlKaVermittlungResultatVorschlag", "ResultatDatumLeer", "Datum Resultat darf nicht leer sein!");
				return;
			}
			
			
			DBUtil.ExecSQL(@"UPDATE KaVermittlungVorschlag SET VorschlagResultatDatum = {0}, VorschlagResultat = {1} WHERE KaVermittlungVorschlagID = {2}", edtResultatDatum.EditValue, edtVorschlagResultat.EditValue, qryKandidaten["KaVermittlungVorschlagID"]);
			
			int vermVorschlagID = Convert.ToInt32(qryKandidaten["KaVermittlungVorschlagID"]);
			int baPersonID = Convert.ToInt32(qryKandidaten["baPersID"]);
			
			switch(Utils.ConvertToInt(qryKandidaten["KaProgrammCode"]))
			{
				case 1:	
					// Inizio
					FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", baPersonID, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaInizioEinsaetze", "KaVermittlungVorschlagID", vermVorschlagID);
					break;
				case 2:
					// Qualifizierung Jugend
					FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", baPersonID, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaQJExterneEinsaetze", "KaVermittlungVorschlagID", vermVorschlagID);
					break;
				case 3:
					// Vermittlung BI
					FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", baPersonID, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungBIBIPStellenBI", "KaVermittlungVorschlagID", vermVorschlagID);
					break;
				case 4:
					// Vermittlung BIP
					FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", baPersonID, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungBIBIPEinsaetzeBIP", "KaVermittlungVorschlagID", vermVorschlagID);
					break;
				case 5:
					// Vermittlung SI
					FormController.OpenForm("FrmFall", "Action", "JumpToVermittlung", "BaPersonID", baPersonID, "ModulID", 7, "FieldName", "ClassName", "FieldValue", "CtlKaVermittlungSIEinsaetze", "KaVermittlungVorschlagID", vermVorschlagID);
					break;
			}
			
			qryKandidaten.Fill(edtEinsatzplatzBezeichnung.LookupID);
			edtResultatDatum.EditValue = DBNull.Value;
			edtVorschlagResultat.EditValue = DBNull.Value;
		}
		
		private void edtEinsatzplatzBezeichnung_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
		{

			btnEinsatzplatzDetails.Enabled = false;
			btnKandidatenSuchen.Enabled = false;
			
			string SearchString = edtEinsatzplatzBezeichnung.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");
			
			if (DBUtil.IsEmpty(SearchString))
			{
				if (e.ButtonClicked)
				{
					SearchString = "%";
				}
				else
				{
				        edtEinsatzplatzBezeichnung.EditValue = null;
			        	edtEinsatzplatzBezeichnung.LookupID = null;
					edtBetrieb.EditValue = null;
			  		return;
				}
			}
			
			KissLookupDialog dlg = new KissLookupDialog();
			e.Cancel = !dlg.SearchData(@"
			  SELECT ID$ = KaEinsatzplatzID,
				 Nr = KaEinsatzplatzID, 
			         [Bezeichnung] = EIN.Bezeichnung,         
			         Betrieb = BET.BetriebName,
				 Bez$ = Convert(varchar, EIN.KaEinsatzplatzID) + ' ' + EIN.Bezeichnung
			  FROM   KaEinsatzplatz EIN
			    LEFT JOIN KaBetrieb BET ON BET.KaBetriebID = EIN.KaBetriebID
			  WHERE  Convert(varchar, EIN.KaEinsatzplatzID) + ' ' + EIN.Bezeichnung like '%' + {0} + '%' 
			  ORDER BY EIN.Bezeichnung ASC, BET.BetriebName ASC",
			  SearchString,
			  e.ButtonClicked,null,null,null);
			
			if (!e.Cancel)
			{  
				edtEinsatzplatzBezeichnung.EditValue = dlg[4];
			        edtEinsatzplatzBezeichnung.LookupID = dlg[0];
				edtBetrieb.EditValue = dlg[3];
				btnEinsatzplatzDetails.Enabled = true;
				btnKandidatenSuchen.Enabled = true;
			}
		}
	}
}