#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQuerySysGleicheZahlwege : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnInstitution;
        private DevExpress.XtraGrid.Columns.GridColumn colAHV;
        private DevExpress.XtraGrid.Columns.GridColumn colAName;
        private DevExpress.XtraGrid.Columns.GridColumn colANr;
        private DevExpress.XtraGrid.Columns.GridColumn colAOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colAStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colATelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colAZahlinfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colArt;
        private DevExpress.XtraGrid.Columns.GridColumn colBName;
        private DevExpress.XtraGrid.Columns.GridColumn colBNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colBStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colBTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colBZahlinfo;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFT;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colInstitutionName;
        private DevExpress.XtraGrid.Columns.GridColumn colMAAssistenz;
        private DevExpress.XtraGrid.Columns.GridColumn colMAIntake;
        private DevExpress.XtraGrid.Columns.GridColumn colMASozialberatung;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlwegID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblSucheName;

        #endregion

        #region Constructors

        public CtlQuerySysGleicheZahlwege()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQuerySysGleicheZahlwege));
			  DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			  this.btnInstitution = new KiSS4.Gui.KissButton();
			  this.lblSucheName = new KiSS4.Gui.KissLabel();
			  this.colAHV = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colAName = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colANr = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colAOrt = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colArt = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colAStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colATelefon = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colAZahlinfo = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colBName = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colBNr = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colBOrt = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colBStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colBTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colBZahlinfo = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colFT = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colInstitutionName = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colMAAssistenz = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colMAIntake = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colMASozialberatung = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.colZahlwegID = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			  this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			  ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
			  this.tabControlSearch.SuspendLayout();
			  this.tpgListe.SuspendLayout();
			  this.tpgSuchen.SuspendLayout();
			  ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
			  ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			  this.SuspendLayout();
			  // 
			  // qryQuery
			  // 
			  this.qryQuery.FillTimeOut = 500;
			  this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
			  this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
			  // 
			  // grvQuery1
			  // 
			  this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			  this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.Empty.Options.UseFont = true;
			  this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
			  this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
			  this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
			  this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
			  this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
			  this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
			  this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
			  this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
			  this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
			  this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
			  this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			  this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			  this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			  this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			  this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
			  this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
			  this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			  this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			  this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			  this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
			  this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
			  this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
			  this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			  this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
			  this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
			  this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
			  this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
			  this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
			  this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
			  this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.Row.Options.UseFont = true;
			  this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
			  this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
			  this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
			  this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
			  this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
			  this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
			  this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
			  this.grvQuery1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
			  this.grvQuery1.OptionsBehavior.Editable = false;
			  this.grvQuery1.OptionsFilter.AllowFilterEditor = false;
			  this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
			  this.grvQuery1.OptionsMenu.EnableColumnMenu = false;
			  this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
			  this.grvQuery1.OptionsNavigation.UseTabKey = false;
			  this.grvQuery1.OptionsPrint.AutoWidth = false;
			  this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
			  this.grvQuery1.OptionsPrint.UsePrintStyles = true;
			  this.grvQuery1.OptionsView.ColumnAutoWidth = false;
			  this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			  this.grvQuery1.OptionsView.ShowGroupPanel = false;
			  this.grvQuery1.OptionsView.ShowIndicator = false;
			  // 
			  // grdQuery1
			  // 
			  this.grdQuery1.EmbeddedNavigator.Name = "";
			  this.grdQuery1.Location = new System.Drawing.Point(3, -3);
			  this.grdQuery1.Size = new System.Drawing.Size(767, 392);
			  this.grdQuery1.TabIndex = 7;
			  this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			  // 
			  // xDocument
			  // 
			  this.xDocument.DataMember = null;
			  this.xDocument.EditValue = null;
			  this.xDocument.Location = new System.Drawing.Point(513, 397);
			  this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			  this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			  this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			  this.xDocument.Properties.Appearance.Options.UseBackColor = true;
			  this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
			  this.xDocument.Properties.Appearance.Options.UseFont = true;
			  serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
			  serializableAppearanceObject2.Options.UseBackColor = true;
			  this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument �ffnen")});
			  this.xDocument.TabIndex = 9;
			  this.xDocument.Visible = false;
			  // 
			  // ctlGotoFall
			  // 
			  this.ctlGotoFall.DataMember = "FallBaPersonID$";
			  this.ctlGotoFall.Location = new System.Drawing.Point(3, 395);
			  this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
			  this.ctlGotoFall.TabIndex = 8;
			  // 
			  // searchTitle
			  // 
			  this.searchTitle.Size = new System.Drawing.Size(761, 24);
			  // 
			  // tabControlSearch
			  // 
			  this.tabControlSearch.Size = new System.Drawing.Size(785, 462);
			  // 
			  // tpgListe
			  // 
			  this.tpgListe.Controls.Add(this.btnInstitution);
			  this.tpgListe.Location = new System.Drawing.Point(6, 6);
			  this.tpgListe.Size = new System.Drawing.Size(773, 424);
			  this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
			  this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
			  this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
			  this.tpgListe.Controls.SetChildIndex(this.btnInstitution, 0);
			  // 
			  // tpgSuchen
			  // 
			  this.tpgSuchen.Controls.Add(this.lblSucheName);
			  this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
			  this.tpgSuchen.Size = new System.Drawing.Size(773, 424);
			  this.tpgSuchen.TabIndex = 3;
			  this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
			  this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
			  // 
			  // btnInstitution
			  // 
			  this.btnInstitution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			  this.btnInstitution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			  this.btnInstitution.Location = new System.Drawing.Point(119, 395);
			  this.btnInstitution.Name = "btnInstitution";
			  this.btnInstitution.Size = new System.Drawing.Size(122, 24);
			  this.btnInstitution.TabIndex = 10;
			  this.btnInstitution.Text = "> Institution";
			  this.btnInstitution.UseCompatibleTextRendering = true;
			  this.btnInstitution.UseVisualStyleBackColor = false;
			  this.btnInstitution.Click += new System.EventHandler(this.btnInstitution_Click);
			  // 
			  // lblSucheName
			  // 
			  this.lblSucheName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			  this.lblSucheName.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
			  this.lblSucheName.Location = new System.Drawing.Point(8, 48);
			  this.lblSucheName.Name = "lblSucheName";
			  this.lblSucheName.Size = new System.Drawing.Size(313, 71);
			  this.lblSucheName.TabIndex = 1;
			  this.lblSucheName.Text = "Liste von Institutionen oder Personen, die 2 gleiche Zahlwege haben. Achtung: Die" +
					" Abfrage kann ein paar Minuten dauern";
			  this.lblSucheName.UseCompatibleTextRendering = true;
			  // 
			  // colAHV
			  // 
			  this.colAHV.Caption = "AHV";
			  this.colAHV.FieldName = "AHV";
			  this.colAHV.Name = "colAHV";
			  this.colAHV.Visible = true;
			  this.colAHV.VisibleIndex = 6;
			  this.colAHV.Width = 45;
			  // 
			  // colAlter
			  // 
			  this.colAlter.Caption = "Alter";
			  this.colAlter.FieldName = "Alter";
			  this.colAlter.Name = "colAlter";
			  this.colAlter.Visible = true;
			  this.colAlter.VisibleIndex = 4;
			  this.colAlter.Width = 49;
			  // 
			  // colAName
			  // 
			  this.colAName.Name = "colAName";
			  // 
			  // colANr
			  // 
			  this.colANr.Name = "colANr";
			  // 
			  // colAOrt
			  // 
			  this.colAOrt.Name = "colAOrt";
			  // 
			  // colArt
			  // 
			  this.colArt.Name = "colArt";
			  // 
			  // colAStrasse
			  // 
			  this.colAStrasse.Name = "colAStrasse";
			  // 
			  // colATelefon
			  // 
			  this.colATelefon.Name = "colATelefon";
			  // 
			  // colAZahlinfo
			  // 
			  this.colAZahlinfo.Name = "colAZahlinfo";
			  // 
			  // colBName
			  // 
			  this.colBName.Name = "colBName";
			  // 
			  // colBNr
			  // 
			  this.colBNr.Name = "colBNr";
			  // 
			  // colBOrt
			  // 
			  this.colBOrt.Name = "colBOrt";
			  // 
			  // colBStrasse
			  // 
			  this.colBStrasse.Name = "colBStrasse";
			  // 
			  // colBTelefon
			  // 
			  this.colBTelefon.Name = "colBTelefon";
			  // 
			  // colBZahlinfo
			  // 
			  this.colBZahlinfo.Name = "colBZahlinfo";
			  // 
			  // colDatumBis
			  // 
			  this.colDatumBis.Name = "colDatumBis";
			  // 
			  // colDatumVon
			  // 
			  this.colDatumVon.Name = "colDatumVon";
			  // 
			  // colFT
			  // 
			  this.colFT.Caption = "FT";
			  this.colFT.FieldName = "FT";
			  this.colFT.Name = "colFT";
			  this.colFT.Visible = true;
			  this.colFT.VisibleIndex = 0;
			  this.colFT.Width = 35;
			  // 
			  // colGeburtsdatum
			  // 
			  this.colGeburtsdatum.Caption = "Geburtsdatum";
			  this.colGeburtsdatum.DisplayFormat.FormatString = "d";
			  this.colGeburtsdatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			  this.colGeburtsdatum.FieldName = "Geburtsdatum";
			  this.colGeburtsdatum.Name = "colGeburtsdatum";
			  this.colGeburtsdatum.Visible = true;
			  this.colGeburtsdatum.VisibleIndex = 3;
			  this.colGeburtsdatum.Width = 102;
			  // 
			  // colHeimatort
			  // 
			  this.colHeimatort.Caption = "Heimatort";
			  this.colHeimatort.FieldName = "Heimatort";
			  this.colHeimatort.Name = "colHeimatort";
			  this.colHeimatort.Visible = true;
			  this.colHeimatort.VisibleIndex = 10;
			  this.colHeimatort.Width = 76;
			  // 
			  // colID
			  // 
			  this.colID.Name = "colID";
			  // 
			  // colInstitutionName
			  // 
			  this.colInstitutionName.Name = "colInstitutionName";
			  // 
			  // colMAAssistenz
			  // 
			  this.colMAAssistenz.Caption = "MA Assistenz";
			  this.colMAAssistenz.FieldName = "MA Assistenz";
			  this.colMAAssistenz.Name = "colMAAssistenz";
			  this.colMAAssistenz.Visible = true;
			  this.colMAAssistenz.VisibleIndex = 14;
			  this.colMAAssistenz.Width = 99;
			  // 
			  // colMAIntake
			  // 
			  this.colMAIntake.Caption = "MA Intake";
			  this.colMAIntake.FieldName = "MA Intake";
			  this.colMAIntake.Name = "colMAIntake";
			  this.colMAIntake.Visible = true;
			  this.colMAIntake.VisibleIndex = 11;
			  this.colMAIntake.Width = 77;
			  // 
			  // colMASozialberatung
			  // 
			  this.colMASozialberatung.Caption = "MA Sozialberatung";
			  this.colMASozialberatung.FieldName = "MA Sozialberatung";
			  this.colMASozialberatung.Name = "colMASozialberatung";
			  this.colMASozialberatung.Visible = true;
			  this.colMASozialberatung.VisibleIndex = 12;
			  this.colMASozialberatung.Width = 125;
			  // 
			  // colName
			  // 
			  this.colName.Caption = "Name";
			  this.colName.FieldName = "Name";
			  this.colName.Name = "colName";
			  this.colName.Visible = true;
			  this.colName.VisibleIndex = 1;
			  this.colName.Width = 53;
			  // 
			  // colOrt
			  // 
			  this.colOrt.Caption = "Ort";
			  this.colOrt.FieldName = "Ort";
			  this.colOrt.Name = "colOrt";
			  this.colOrt.Visible = true;
			  this.colOrt.VisibleIndex = 9;
			  this.colOrt.Width = 39;
			  // 
			  // colPLZ
			  // 
			  this.colPLZ.Caption = "PLZ";
			  this.colPLZ.FieldName = "PLZ";
			  this.colPLZ.Name = "colPLZ";
			  this.colPLZ.Visible = true;
			  this.colPLZ.VisibleIndex = 8;
			  this.colPLZ.Width = 43;
			  // 
			  // colStatus
			  // 
			  this.colStatus.Name = "colStatus";
			  // 
			  // colStrasse
			  // 
			  this.colStrasse.Caption = "Strasse";
			  this.colStrasse.FieldName = "Strasse";
			  this.colStrasse.Name = "colStrasse";
			  this.colStrasse.Visible = true;
			  this.colStrasse.VisibleIndex = 7;
			  this.colStrasse.Width = 65;
			  // 
			  // colText
			  // 
			  this.colText.Name = "colText";
			  // 
			  // colTyp
			  // 
			  this.colTyp.Name = "colTyp";
			  // 
			  // colVorname
			  // 
			  this.colVorname.Caption = "Vorname";
			  this.colVorname.FieldName = "Vorname";
			  this.colVorname.Name = "colVorname";
			  this.colVorname.Visible = true;
			  this.colVorname.VisibleIndex = 2;
			  this.colVorname.Width = 73;
			  // 
			  // colZahlwegID
			  // 
			  this.colZahlwegID.Name = "colZahlwegID";
			  // 
			  // gridColumn1
			  // 
			  this.gridColumn1.Caption = "m/w";
			  this.gridColumn1.FieldName = "m/w";
			  this.gridColumn1.Name = "gridColumn1";
			  this.gridColumn1.Visible = true;
			  this.gridColumn1.VisibleIndex = 5;
			  this.gridColumn1.Width = 46;
			  // 
			  // gridColumn2
			  // 
			  this.gridColumn2.Caption = "MA Case Mgmt.";
			  this.gridColumn2.FieldName = "MA Case Mgmt.";
			  this.gridColumn2.Name = "gridColumn2";
			  this.gridColumn2.Visible = true;
			  this.gridColumn2.VisibleIndex = 13;
			  this.gridColumn2.Width = 109;
			  // 
			  // gridColumn3
			  // 
			  this.gridColumn3.Caption = "DmgPersonID$";
			  this.gridColumn3.FieldName = "DmgPersonID$";
			  this.gridColumn3.Name = "gridColumn3";
			  this.gridColumn3.Width = 93;
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
			  this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			  this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			  this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
			  this.gridView1.Appearance.GroupRow.Options.UseFont = true;
			  this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
			  this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			  this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			  this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.colFT,
            this.colName,
            this.colVorname,
            this.colGeburtsdatum,
            this.colAlter,
            this.gridColumn1,
            this.colAHV,
            this.colStrasse,
            this.colPLZ,
            this.colOrt,
            this.colHeimatort,
            this.colMAIntake,
            this.colMASozialberatung,
            this.gridColumn2,
            this.colMAAssistenz,
            this.gridColumn3});
			  this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
			  this.gridView1.GridControl = this.grdQuery1;
			  this.gridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
			  this.gridView1.Name = "gridView1";
			  this.gridView1.OptionsBehavior.Editable = false;
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
			  // CtlQuerySysGleicheZahlwege
			  // 
			  this.Name = "CtlQuerySysGleicheZahlwege";
			  ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
			  ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
			  ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
			  ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
			  this.tabControlSearch.ResumeLayout(false);
			  this.tpgListe.ResumeLayout(false);
			  this.tpgSuchen.ResumeLayout(false);
			  ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
			  ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			  this.ResumeLayout(false);
			  this.PerformLayout();

        }

        #endregion

        #region Private Methods

        private void btnInstitution_Click(object sender, System.EventArgs e)
        {
            if (qryQuery.Count == 0) return;

            // Sprung zum InstitutionenStamm
            FormController.OpenForm("FrmInstitutionenStamm", "Action", "ShowZahlweg",
                "BaInstitutionID", qryQuery["BaInstitutionID$"],
                "BaZahlungswegID", qryQuery["BaZahlungswegID$"]);
        }

        private void qryQuery_PositionChanged(object sender, System.EventArgs e)
        {
            btnInstitution.Enabled = !DBUtil.IsEmpty(qryQuery["BaInstitutionID$"]);
        }

        #endregion
    }
}