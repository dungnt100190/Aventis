using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Query.ZH
{
    partial class CtlQueryBaPersonen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaPersonen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblKlientensystem = new KiSS4.Gui.KissLabel();
            this.qryBaPerson = new KiSS4.DB.SqlQuery();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheAHV = new KiSS4.Gui.KissLabel();
            this.lblSucheGeburt = new KiSS4.Gui.KissLabel();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.lblSuchePLZOrt = new KiSS4.Gui.KissLabel();
            this.lblSucheStrasse = new KiSS4.Gui.KissLabel();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburt = new KiSS4.Gui.KissDateEdit();
            this.edtSucheAHV = new KiSS4.Gui.KissTextEdit();
            this.edtSucheStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtSuchePLZ = new KiSS4.Gui.KissTextEdit();
            this.edtSucheOrt = new KiSS4.Gui.KissTextEdit();
            this.edtSucheEinwohnerregisterId = new KiSS4.Gui.KissCalcEdit();
            this.lblPID = new KiSS4.Gui.KissLabel();
            this.edtSucheBaPersonID = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtSucheFaFallID = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheFalltraeger = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtSucheLeistungstraeger = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheResoNr = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheAltePNr = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheAlteFallNr = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.edtSucheGruppe = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheTeam = new KiSS4.Gui.KissLookUpEdit();
            this.ctlOrgUnitTeamUser = new KiSS4.Common.ZH.CtlOrgUnitTeamUser();
            this.grdKlientensystem = new KiSS4.Gui.KissGrid();
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grdPersonen = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlientensystemVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinwohnerregisterId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufenthalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltePNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlteFallNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFVMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFVSB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnFallzuteilung = new KiSS4.Gui.KissButton();
            this.ctlGotoFallZH = new KiSS4.Common.ZH.CtlGotoFall();
            this.edtSucheVersichertenNr = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVersichertenNr = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAHV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinwohnerregisterId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaFallID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFalltraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungstraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheResoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAltePNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAlteFallNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNr)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.FillTimeOut = 30;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
            // 
            // xDocument
            // 
            this.xDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(182, 1199);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.TabIndex = 9;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(-3, -1);
            this.ctlGotoFall.Size = new System.Drawing.Size(157, 27);
            this.ctlGotoFall.TabIndex = 8;
            this.ctlGotoFall.Visible = false;
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(762, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(786, 551);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.ctlGotoFallZH);
            this.tpgListe.Controls.Add(this.btnFallzuteilung);
            this.tpgListe.Controls.Add(this.grdPersonen);
            this.tpgListe.Controls.Add(this.grdKlientensystem);
            this.tpgListe.Controls.Add(this.lblKlientensystem);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(774, 513);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblKlientensystem, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdKlientensystem, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdPersonen, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnFallzuteilung, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFallZH, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheVersichertenNr);
            this.tpgSuchen.Controls.Add(this.lblSucheVersichertenNr);
            this.tpgSuchen.Controls.Add(this.ctlOrgUnitTeamUser);
            this.tpgSuchen.Controls.Add(this.edtSucheTeam);
            this.tpgSuchen.Controls.Add(this.edtSucheGruppe);
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.edtSucheAlteFallNr);
            this.tpgSuchen.Controls.Add(this.edtSucheAltePNr);
            this.tpgSuchen.Controls.Add(this.edtSucheResoNr);
            this.tpgSuchen.Controls.Add(this.edtSucheLeistungstraeger);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.edtSucheFalltraeger);
            this.tpgSuchen.Controls.Add(this.edtSucheFaFallID);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.edtSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.lblPID);
            this.tpgSuchen.Controls.Add(this.edtSucheEinwohnerregisterId);
            this.tpgSuchen.Controls.Add(this.edtSucheOrt);
            this.tpgSuchen.Controls.Add(this.edtSuchePLZ);
            this.tpgSuchen.Controls.Add(this.edtSucheStrasse);
            this.tpgSuchen.Controls.Add(this.edtSucheAHV);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburt);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheStrasse);
            this.tpgSuchen.Controls.Add(this.lblSuchePLZOrt);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburt);
            this.tpgSuchen.Controls.Add(this.lblSucheAHV);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(774, 513);
            this.tpgSuchen.TabIndex = 3;
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAHV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePLZOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGeburt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAHV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheEinwohnerregisterId, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFaFallID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFalltraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLeistungstraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheResoNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAltePNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAlteFallNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel6, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel7, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTeam, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ctlOrgUnitTeamUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVersichertenNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVersichertenNr, 0);
            // 
            // lblKlientensystem
            // 
            this.lblKlientensystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKlientensystem.Location = new System.Drawing.Point(3, 444);
            this.lblKlientensystem.Name = "lblKlientensystem";
            this.lblKlientensystem.Size = new System.Drawing.Size(132, 24);
            this.lblKlientensystem.TabIndex = 10;
            this.lblKlientensystem.Text = "Auswahl Klientensystem:";
            this.lblKlientensystem.UseCompatibleTextRendering = true;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.BatchUpdate = true;
            this.qryBaPerson.CanUpdate = true;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = "-- Select Statement wird im Code gesetzt\r\n";
            this.qryBaPerson.AfterFill += new System.EventHandler(this.qryBaPerson_AfterFill);
            this.qryBaPerson.PositionChanged += new System.EventHandler(this.qryBaPerson_PositionChanged);
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(127, 134);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(260, 24);
            this.edtSucheName.TabIndex = 0;
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(127, 164);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(260, 24);
            this.edtSucheVorname.TabIndex = 1;
            // 
            // lblSucheAHV
            // 
            this.lblSucheAHV.Location = new System.Drawing.Point(14, 224);
            this.lblSucheAHV.Name = "lblSucheAHV";
            this.lblSucheAHV.Size = new System.Drawing.Size(100, 24);
            this.lblSucheAHV.TabIndex = 1;
            this.lblSucheAHV.Text = "AHV";
            this.lblSucheAHV.UseCompatibleTextRendering = true;
            // 
            // lblSucheGeburt
            // 
            this.lblSucheGeburt.Location = new System.Drawing.Point(14, 194);
            this.lblSucheGeburt.Name = "lblSucheGeburt";
            this.lblSucheGeburt.Size = new System.Drawing.Size(100, 23);
            this.lblSucheGeburt.TabIndex = 1;
            this.lblSucheGeburt.Text = "Geburtsdatum";
            this.lblSucheGeburt.UseCompatibleTextRendering = true;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(14, 134);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(100, 23);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // lblSuchePLZOrt
            // 
            this.lblSuchePLZOrt.Location = new System.Drawing.Point(14, 314);
            this.lblSuchePLZOrt.Name = "lblSuchePLZOrt";
            this.lblSuchePLZOrt.Size = new System.Drawing.Size(100, 23);
            this.lblSuchePLZOrt.TabIndex = 1;
            this.lblSuchePLZOrt.Text = "PLZ / Ort";
            this.lblSuchePLZOrt.UseCompatibleTextRendering = true;
            // 
            // lblSucheStrasse
            // 
            this.lblSucheStrasse.Location = new System.Drawing.Point(14, 285);
            this.lblSucheStrasse.Name = "lblSucheStrasse";
            this.lblSucheStrasse.Size = new System.Drawing.Size(100, 23);
            this.lblSucheStrasse.TabIndex = 1;
            this.lblSucheStrasse.Text = "Strasse";
            this.lblSucheStrasse.UseCompatibleTextRendering = true;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.Location = new System.Drawing.Point(14, 164);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(100, 23);
            this.lblSucheVorname.TabIndex = 1;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            // 
            // edtSucheGeburt
            // 
            this.edtSucheGeburt.EditValue = null;
            this.edtSucheGeburt.Location = new System.Drawing.Point(127, 194);
            this.edtSucheGeburt.Name = "edtSucheGeburt";
            this.edtSucheGeburt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGeburt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeburt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeburt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeburt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeburt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeburt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeburt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheGeburt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGeburt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheGeburt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeburt.Properties.ShowToday = false;
            this.edtSucheGeburt.Size = new System.Drawing.Size(103, 24);
            this.edtSucheGeburt.TabIndex = 2;
            // 
            // edtSucheAHV
            // 
            this.edtSucheAHV.Location = new System.Drawing.Point(127, 224);
            this.edtSucheAHV.Name = "edtSucheAHV";
            this.edtSucheAHV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAHV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAHV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAHV.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAHV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAHV.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAHV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAHV.Size = new System.Drawing.Size(260, 24);
            this.edtSucheAHV.TabIndex = 3;
            // 
            // edtSucheStrasse
            // 
            this.edtSucheStrasse.Location = new System.Drawing.Point(127, 284);
            this.edtSucheStrasse.Name = "edtSucheStrasse";
            this.edtSucheStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStrasse.Size = new System.Drawing.Size(260, 24);
            this.edtSucheStrasse.TabIndex = 4;
            // 
            // edtSuchePLZ
            // 
            this.edtSuchePLZ.Location = new System.Drawing.Point(127, 314);
            this.edtSuchePLZ.Name = "edtSuchePLZ";
            this.edtSuchePLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePLZ.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePLZ.Size = new System.Drawing.Size(60, 24);
            this.edtSuchePLZ.TabIndex = 5;
            // 
            // edtSucheOrt
            // 
            this.edtSucheOrt.Location = new System.Drawing.Point(190, 314);
            this.edtSucheOrt.Name = "edtSucheOrt";
            this.edtSucheOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheOrt.Size = new System.Drawing.Size(197, 24);
            this.edtSucheOrt.TabIndex = 6;
            // 
            // edtSucheEinwohnerregisterId
            // 
            this.edtSucheEinwohnerregisterId.Location = new System.Drawing.Point(502, 72);
            this.edtSucheEinwohnerregisterId.Name = "edtSucheEinwohnerregisterId";
            this.edtSucheEinwohnerregisterId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheEinwohnerregisterId.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheEinwohnerregisterId.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheEinwohnerregisterId.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEinwohnerregisterId.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheEinwohnerregisterId.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheEinwohnerregisterId.Properties.Appearance.Options.UseFont = true;
            this.edtSucheEinwohnerregisterId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheEinwohnerregisterId.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheEinwohnerregisterId.Properties.DisplayFormat.FormatString = "N0";
            this.edtSucheEinwohnerregisterId.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheEinwohnerregisterId.Properties.EditFormat.FormatString = "N0";
            this.edtSucheEinwohnerregisterId.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheEinwohnerregisterId.Size = new System.Drawing.Size(100, 24);
            this.edtSucheEinwohnerregisterId.TabIndex = 7;
            // 
            // lblPID
            // 
            this.lblPID.Location = new System.Drawing.Point(412, 71);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(84, 24);
            this.lblPID.TabIndex = 7;
            this.lblPID.Text = "PID";
            this.lblPID.UseCompatibleTextRendering = true;
            // 
            // edtSucheBaPersonID
            // 
            this.edtSucheBaPersonID.Location = new System.Drawing.Point(502, 103);
            this.edtSucheBaPersonID.Name = "edtSucheBaPersonID";
            this.edtSucheBaPersonID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBaPersonID.Properties.DisplayFormat.FormatString = "N0";
            this.edtSucheBaPersonID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBaPersonID.Properties.EditFormat.FormatString = "N0";
            this.edtSucheBaPersonID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBaPersonID.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBaPersonID.TabIndex = 8;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(412, 103);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(75, 24);
            this.kissLabel2.TabIndex = 8;
            this.kissLabel2.Text = "Personen-Nr.";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtSucheFaFallID
            // 
            this.edtSucheFaFallID.Location = new System.Drawing.Point(502, 134);
            this.edtSucheFaFallID.Name = "edtSucheFaFallID";
            this.edtSucheFaFallID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheFaFallID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFaFallID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFaFallID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFaFallID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFaFallID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFaFallID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFaFallID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFaFallID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFaFallID.Size = new System.Drawing.Size(100, 24);
            this.edtSucheFaFallID.TabIndex = 9;
            // 
            // edtSucheFalltraeger
            // 
            this.edtSucheFalltraeger.EditValue = false;
            this.edtSucheFalltraeger.Location = new System.Drawing.Point(502, 168);
            this.edtSucheFalltraeger.Name = "edtSucheFalltraeger";
            this.edtSucheFalltraeger.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheFalltraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFalltraeger.Properties.Caption = "Nur Fallträger";
            this.edtSucheFalltraeger.Size = new System.Drawing.Size(135, 19);
            this.edtSucheFalltraeger.TabIndex = 10;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(412, 134);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(75, 24);
            this.kissLabel3.TabIndex = 10;
            this.kissLabel3.Text = "Fall-Nr.";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // edtSucheLeistungstraeger
            // 
            this.edtSucheLeistungstraeger.EditValue = false;
            this.edtSucheLeistungstraeger.Location = new System.Drawing.Point(502, 193);
            this.edtSucheLeistungstraeger.Name = "edtSucheLeistungstraeger";
            this.edtSucheLeistungstraeger.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheLeistungstraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLeistungstraeger.Properties.Caption = "Nur Leistungsträger";
            this.edtSucheLeistungstraeger.Size = new System.Drawing.Size(135, 19);
            this.edtSucheLeistungstraeger.TabIndex = 11;
            // 
            // edtSucheResoNr
            // 
            this.edtSucheResoNr.Location = new System.Drawing.Point(502, 224);
            this.edtSucheResoNr.Name = "edtSucheResoNr";
            this.edtSucheResoNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheResoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheResoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheResoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheResoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheResoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheResoNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheResoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheResoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheResoNr.Properties.DisplayFormat.FormatString = "N0";
            this.edtSucheResoNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheResoNr.Properties.EditFormat.FormatString = "N0";
            this.edtSucheResoNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheResoNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheResoNr.TabIndex = 12;
            // 
            // edtSucheAltePNr
            // 
            this.edtSucheAltePNr.Location = new System.Drawing.Point(502, 254);
            this.edtSucheAltePNr.Name = "edtSucheAltePNr";
            this.edtSucheAltePNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheAltePNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAltePNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAltePNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAltePNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAltePNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAltePNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAltePNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAltePNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAltePNr.Properties.DisplayFormat.FormatString = "N0";
            this.edtSucheAltePNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheAltePNr.Properties.EditFormat.FormatString = "N0";
            this.edtSucheAltePNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheAltePNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheAltePNr.TabIndex = 13;
            // 
            // edtSucheAlteFallNr
            // 
            this.edtSucheAlteFallNr.Location = new System.Drawing.Point(502, 284);
            this.edtSucheAlteFallNr.Name = "edtSucheAlteFallNr";
            this.edtSucheAlteFallNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheAlteFallNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAlteFallNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAlteFallNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAlteFallNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAlteFallNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAlteFallNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAlteFallNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAlteFallNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAlteFallNr.Properties.DisplayFormat.FormatString = "N0";
            this.edtSucheAlteFallNr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheAlteFallNr.Properties.EditFormat.FormatString = "N0";
            this.edtSucheAlteFallNr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheAlteFallNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheAlteFallNr.TabIndex = 14;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(412, 224);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(75, 24);
            this.kissLabel5.TabIndex = 312;
            this.kissLabel5.Text = "Reso-Nr.";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(412, 254);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(75, 24);
            this.kissLabel6.TabIndex = 314;
            this.kissLabel6.Text = "alte PNr";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(412, 284);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(75, 24);
            this.kissLabel7.TabIndex = 316;
            this.kissLabel7.Text = "alte Fall-Nr.";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // edtSucheGruppe
            // 
            this.edtSucheGruppe.EditValue = "";
            this.edtSucheGruppe.Location = new System.Drawing.Point(127, 369);
            this.edtSucheGruppe.LOVName = "QuOrgUnitGroup";
            this.edtSucheGruppe.Name = "edtSucheGruppe";
            this.edtSucheGruppe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGruppe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGruppe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheGruppe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheGruppe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGruppe.Properties.NullText = "";
            this.edtSucheGruppe.Properties.ShowFooter = false;
            this.edtSucheGruppe.Properties.ShowHeader = false;
            this.edtSucheGruppe.Size = new System.Drawing.Size(260, 24);
            this.edtSucheGruppe.TabIndex = 317;
            this.edtSucheGruppe.Visible = false;
            // 
            // edtSucheTeam
            // 
            this.edtSucheTeam.EditValue = "";
            this.edtSucheTeam.Location = new System.Drawing.Point(127, 401);
            this.edtSucheTeam.LOVFilter = "FF";
            this.edtSucheTeam.LOVName = "QuOrgUnitTeam";
            this.edtSucheTeam.Name = "edtSucheTeam";
            this.edtSucheTeam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTeam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTeam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTeam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheTeam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTeam.Properties.NullText = "";
            this.edtSucheTeam.Properties.ShowFooter = false;
            this.edtSucheTeam.Properties.ShowHeader = false;
            this.edtSucheTeam.Size = new System.Drawing.Size(260, 24);
            this.edtSucheTeam.TabIndex = 318;
            this.edtSucheTeam.Tag = "";
            this.edtSucheTeam.Visible = false;
            // 
            // ctlOrgUnitTeamUser
            // 
            this.ctlOrgUnitTeamUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlOrgUnitTeamUser.LableWidth = 113;
            this.ctlOrgUnitTeamUser.Location = new System.Drawing.Point(14, 43);
            this.ctlOrgUnitTeamUser.Name = "ctlOrgUnitTeamUser";
            this.ctlOrgUnitTeamUser.SetUserOnNewSearch = false;
            this.ctlOrgUnitTeamUser.ShowUser = true;
            this.ctlOrgUnitTeamUser.Size = new System.Drawing.Size(373, 84);
            this.ctlOrgUnitTeamUser.TabIndex = 319;
            // 
            // grdKlientensystem
            // 
            this.grdKlientensystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKlientensystem.ColumnFilterActivated = true;
            this.grdKlientensystem.DataSource = this.qryBaPerson;
            // 
            // 
            // 
            this.grdKlientensystem.EmbeddedNavigator.Name = "";
            this.grdKlientensystem.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdKlientensystem.Location = new System.Drawing.Point(131, 400);
            this.grdKlientensystem.MainView = this.gridView15;
            this.grdKlientensystem.Name = "grdKlientensystem";
            this.grdKlientensystem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox5});
            this.grdKlientensystem.Size = new System.Drawing.Size(643, 113);
            this.grdKlientensystem.TabIndex = 130;
            this.grdKlientensystem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView15});
            // 
            // gridView15
            // 
            this.gridView15.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView15.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.Empty.Options.UseBackColor = true;
            this.gridView15.Appearance.Empty.Options.UseFont = true;
            this.gridView15.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView15.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView15.Appearance.EvenRow.Options.UseFont = true;
            this.gridView15.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView15.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView15.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView15.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView15.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView15.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView15.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView15.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView15.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView15.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView15.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView15.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView15.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView15.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView15.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView15.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView15.Appearance.GroupRow.Options.UseFont = true;
            this.gridView15.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView15.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView15.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView15.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView15.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView15.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView15.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView15.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView15.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView15.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView15.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView15.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView15.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView15.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView15.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.OddRow.Options.UseFont = true;
            this.gridView15.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView15.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.Row.Options.UseBackColor = true;
            this.gridView15.Appearance.Row.Options.UseFont = true;
            this.gridView15.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView15.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView15.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView15.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView15.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView15.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView15.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView15.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView15.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView15.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colVorname,
            this.colDatumVon,
            this.colDatumBis,
            this.colKFallNr,
            this.colPersonID});
            this.gridView15.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView15.GridControl = this.grdKlientensystem;
            this.gridView15.Name = "gridView15";
            this.gridView15.OptionsBehavior.Editable = false;
            this.gridView15.OptionsCustomization.AllowGroup = false;
            this.gridView15.OptionsCustomization.AllowSort = false;
            this.gridView15.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView15.OptionsFilter.AllowFilterEditor = false;
            this.gridView15.OptionsFilter.AllowMRUFilterList = false;
            this.gridView15.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView15.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView15.OptionsNavigation.UseTabKey = false;
            this.gridView15.OptionsView.ColumnAutoWidth = false;
            this.gridView15.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView15.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView15.OptionsView.ShowGroupPanel = false;
            this.gridView15.OptionsView.ShowIndicator = false;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 157;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.OptionsColumn.AllowEdit = false;
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 1;
            this.colVorname.Width = 111;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Datum von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.OptionsColumn.AllowEdit = false;
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 4;
            this.colDatumVon.Width = 80;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Datum bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.OptionsColumn.AllowEdit = false;
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 5;
            this.colDatumBis.Width = 77;
            // 
            // colKFallNr
            // 
            this.colKFallNr.Caption = "Fall Nr";
            this.colKFallNr.FieldName = "FaFallID";
            this.colKFallNr.Name = "colKFallNr";
            this.colKFallNr.Visible = true;
            this.colKFallNr.VisibleIndex = 3;
            this.colKFallNr.Width = 53;
            // 
            // colPersonID
            // 
            this.colPersonID.Caption = "Person Nr";
            this.colPersonID.FieldName = "BaPersonID";
            this.colPersonID.Name = "colPersonID";
            this.colPersonID.Visible = true;
            this.colPersonID.VisibleIndex = 2;
            this.colPersonID.Width = 77;
            // 
            // repositoryItemImageComboBox5
            // 
            this.repositoryItemImageComboBox5.AutoHeight = false;
            this.repositoryItemImageComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox5.Name = "repositoryItemImageComboBox5";
            // 
            // grdPersonen
            // 
            this.grdPersonen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPersonen.ColumnFilterActivated = true;
            this.grdPersonen.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdPersonen.EmbeddedNavigator.Name = "";
            this.grdPersonen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdPersonen.Location = new System.Drawing.Point(3, 0);
            this.grdPersonen.MainView = this.gridView1;
            this.grdPersonen.Name = "grdPersonen";
            this.grdPersonen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdPersonen.Size = new System.Drawing.Size(771, 394);
            this.grdPersonen.TabIndex = 131;
            this.grdPersonen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
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
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFT1,
            this.colLT,
            this.colName1,
            this.colVorname1,
            this.colKlientensystemVon,
            this.colGeburtsdatum1,
            this.colGeschlecht,
            this.colEinwohnerregisterId,
            this.colBaPersonID,
            this.colFallNr,
            this.colOrgUnit,
            this.colVersichertennummer,
            this.colAHVNummer,
            this.colStrasse1,
            this.colPLZ1,
            this.colAufenthalt,
            this.colHeimatort1,
            this.colResoNr,
            this.colAltePNr,
            this.colAlteFallNr,
            this.colFVMA,
            this.colFVSB});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdPersonen;
            this.gridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.ExpandAllDetails = true;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colFT1
            // 
            this.colFT1.Caption = "FT";
            this.colFT1.FieldName = "FT";
            this.colFT1.Name = "colFT1";
            this.colFT1.Visible = true;
            this.colFT1.VisibleIndex = 0;
            this.colFT1.Width = 35;
            // 
            // colLT
            // 
            this.colLT.Caption = "LT";
            this.colLT.FieldName = "LT";
            this.colLT.Name = "colLT";
            this.colLT.Visible = true;
            this.colLT.VisibleIndex = 1;
            this.colLT.Width = 36;
            // 
            // colName1
            // 
            this.colName1.Caption = "Name";
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 2;
            this.colName1.Width = 53;
            // 
            // colVorname1
            // 
            this.colVorname1.Caption = "Vorname";
            this.colVorname1.FieldName = "Vorname";
            this.colVorname1.Name = "colVorname1";
            this.colVorname1.Visible = true;
            this.colVorname1.VisibleIndex = 3;
            this.colVorname1.Width = 73;
            // 
            // colKlientensystemVon
            // 
            this.colKlientensystemVon.Caption = "Im Klientensystem von";
            this.colKlientensystemVon.FieldName = "KlientensystemVon";
            this.colKlientensystemVon.Name = "colKlientensystemVon";
            this.colKlientensystemVon.Visible = true;
            this.colKlientensystemVon.VisibleIndex = 13;
            this.colKlientensystemVon.Width = 106;
            // 
            // colGeburtsdatum1
            // 
            this.colGeburtsdatum1.Caption = "Geburt";
            this.colGeburtsdatum1.DisplayFormat.FormatString = "d";
            this.colGeburtsdatum1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGeburtsdatum1.FieldName = "Geburtsdatum";
            this.colGeburtsdatum1.Name = "colGeburtsdatum1";
            this.colGeburtsdatum1.Visible = true;
            this.colGeburtsdatum1.VisibleIndex = 5;
            this.colGeburtsdatum1.Width = 77;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Caption = "m/w";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 4;
            this.colGeschlecht.Width = 46;
            // 
            // colEinwohnerregisterId
            // 
            this.colEinwohnerregisterId.Caption = "PID";
            this.colEinwohnerregisterId.FieldName = "EinwohnerregisterIDOhne0er";
            this.colEinwohnerregisterId.Name = "colEinwohnerregisterId";
            this.colEinwohnerregisterId.Visible = true;
            this.colEinwohnerregisterId.VisibleIndex = 14;
            this.colEinwohnerregisterId.Width = 63;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Pers.Nr";
            this.colBaPersonID.FieldName = "PersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 6;
            this.colBaPersonID.Width = 63;
            // 
            // colFallNr
            // 
            this.colFallNr.Caption = "FallNr";
            this.colFallNr.FieldName = "FallNr";
            this.colFallNr.Name = "colFallNr";
            this.colFallNr.Visible = true;
            this.colFallNr.VisibleIndex = 7;
            this.colFallNr.Width = 52;
            // 
            // colOrgUnit
            // 
            this.colOrgUnit.Caption = "Org. Einheit";
            this.colOrgUnit.FieldName = "OrgUnit";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 8;
            this.colOrgUnit.Width = 89;
            // 
            // colVersichertennummer
            // 
            this.colVersichertennummer.Caption = "Versichertennr.";
            this.colVersichertennummer.FieldName = "Versichertennummer";
            this.colVersichertennummer.Name = "colVersichertennummer";
            this.colVersichertennummer.Visible = true;
            this.colVersichertennummer.VisibleIndex = 15;
            this.colVersichertennummer.Width = 100;
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Caption = "AHVNummer";
            this.colAHVNummer.FieldName = "AHVNummer";
            this.colAHVNummer.Name = "colAHVNummer";
            this.colAHVNummer.Visible = true;
            this.colAHVNummer.VisibleIndex = 16;
            this.colAHVNummer.Width = 93;
            // 
            // colStrasse1
            // 
            this.colStrasse1.Caption = "Strasse";
            this.colStrasse1.FieldName = "WohnsitzStrasseHausNr";
            this.colStrasse1.Name = "colStrasse1";
            this.colStrasse1.Visible = true;
            this.colStrasse1.VisibleIndex = 11;
            this.colStrasse1.Width = 65;
            // 
            // colPLZ1
            // 
            this.colPLZ1.Caption = "PLZ";
            this.colPLZ1.FieldName = "WohnsitzPLZ";
            this.colPLZ1.Name = "colPLZ1";
            this.colPLZ1.Visible = true;
            this.colPLZ1.VisibleIndex = 12;
            this.colPLZ1.Width = 43;
            // 
            // colAufenthalt
            // 
            this.colAufenthalt.Caption = "Aufenthalt";
            this.colAufenthalt.FieldName = "Aufenthalt";
            this.colAufenthalt.Name = "colAufenthalt";
            this.colAufenthalt.Visible = true;
            this.colAufenthalt.VisibleIndex = 17;
            this.colAufenthalt.Width = 79;
            // 
            // colHeimatort1
            // 
            this.colHeimatort1.Caption = "Heimatort";
            this.colHeimatort1.FieldName = "Heimatort";
            this.colHeimatort1.Name = "colHeimatort1";
            this.colHeimatort1.Visible = true;
            this.colHeimatort1.VisibleIndex = 18;
            this.colHeimatort1.Width = 76;
            // 
            // colResoNr
            // 
            this.colResoNr.Caption = "Reso-Nr.";
            this.colResoNr.FieldName = "ResoNr";
            this.colResoNr.Name = "colResoNr";
            this.colResoNr.Visible = true;
            this.colResoNr.VisibleIndex = 19;
            // 
            // colAltePNr
            // 
            this.colAltePNr.Caption = "alte PNr.";
            this.colAltePNr.FieldName = "AltePNr";
            this.colAltePNr.Name = "colAltePNr";
            this.colAltePNr.Visible = true;
            this.colAltePNr.VisibleIndex = 20;
            // 
            // colAlteFallNr
            // 
            this.colAlteFallNr.Caption = "alteFallNr";
            this.colAlteFallNr.FieldName = "AlteFallNr";
            this.colAlteFallNr.Name = "colAlteFallNr";
            this.colAlteFallNr.Visible = true;
            this.colAlteFallNr.VisibleIndex = 21;
            // 
            // colFVMA
            // 
            this.colFVMA.Caption = "FV (# LV)";
            this.colFVMA.FieldName = "FallVerantwortlicheMA";
            this.colFVMA.Name = "colFVMA";
            this.colFVMA.Visible = true;
            this.colFVMA.VisibleIndex = 9;
            this.colFVMA.Width = 62;
            // 
            // colFVSB
            // 
            this.colFVSB.Caption = "FV SB";
            this.colFVSB.FieldName = "FallVerantwortlicheSB";
            this.colFVSB.Name = "colFVSB";
            this.colFVSB.Visible = true;
            this.colFVSB.VisibleIndex = 10;
            this.colFVSB.Width = 58;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // btnFallzuteilung
            // 
            this.btnFallzuteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFallzuteilung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFallzuteilung.Location = new System.Drawing.Point(3, 486);
            this.btnFallzuteilung.Name = "btnFallzuteilung";
            this.btnFallzuteilung.Size = new System.Drawing.Size(110, 24);
            this.btnFallzuteilung.TabIndex = 132;
            this.btnFallzuteilung.Text = "Fallzuteilung...";
            this.btnFallzuteilung.UseVisualStyleBackColor = false;
            this.btnFallzuteilung.Click += new System.EventHandler(this.btnFallzuteilung_Click);
            // 
            // ctlGotoFallZH
            // 
            this.ctlGotoFallZH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallZH.DataSource = this.qryQuery;
            this.ctlGotoFallZH.Location = new System.Drawing.Point(3, 402);
            this.ctlGotoFallZH.Name = "ctlGotoFallZH";
            this.ctlGotoFallZH.Size = new System.Drawing.Size(122, 26);
            this.ctlGotoFallZH.TabIndex = 133;
            // 
            // edtSucheVersichertenNr
            // 
            this.edtSucheVersichertenNr.Location = new System.Drawing.Point(127, 254);
            this.edtSucheVersichertenNr.Name = "edtSucheVersichertenNr";
            this.edtSucheVersichertenNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVersichertenNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVersichertenNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVersichertenNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVersichertenNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVersichertenNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVersichertenNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVersichertenNr.Size = new System.Drawing.Size(260, 24);
            this.edtSucheVersichertenNr.TabIndex = 323;
            // 
            // lblSucheVersichertenNr
            // 
            this.lblSucheVersichertenNr.Location = new System.Drawing.Point(14, 254);
            this.lblSucheVersichertenNr.Name = "lblSucheVersichertenNr";
            this.lblSucheVersichertenNr.Size = new System.Drawing.Size(107, 24);
            this.lblSucheVersichertenNr.TabIndex = 322;
            this.lblSucheVersichertenNr.Text = "Versichertennr.";
            this.lblSucheVersichertenNr.UseCompatibleTextRendering = true;
            // 
            // CtlQueryBaPersonen
            // 
            this.Name = "CtlQueryBaPersonen";
            this.Size = new System.Drawing.Size(801, 589);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAHV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAHV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEinwohnerregisterId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFaFallID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFalltraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLeistungstraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheResoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAltePNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAlteFallNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKlientensystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersichertenNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersichertenNr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Common.ZH.CtlGotoFall ctlGotoFallZH;
        private KiSS4.Gui.KissGrid grdKlientensystem;
        private KiSS4.Gui.KissGrid grdPersonen;
        private KiSS4.Gui.KissButton btnFallzuteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAlteFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAltePNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthalt;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFT1;
        private DevExpress.XtraGrid.Columns.GridColumn colFVMA;
        private DevExpress.XtraGrid.Columns.GridColumn colFVSB;
        private DevExpress.XtraGrid.Columns.GridColumn colFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum1;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort1;
        private DevExpress.XtraGrid.Columns.GridColumn colKFallNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKlientensystemVon;
        private DevExpress.XtraGrid.Columns.GridColumn colLT;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ1;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colResoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse1;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname1;
        private DevExpress.XtraGrid.Columns.GridColumn colEinwohnerregisterId;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.ZH.CtlOrgUnitTeamUser ctlOrgUnitTeamUser;
        private KiSS4.Gui.KissTextEdit edtSucheAHV;
        private KiSS4.Gui.KissCalcEdit edtSucheAlteFallNr;
        private KiSS4.Gui.KissCalcEdit edtSucheAltePNr;
        private KiSS4.Gui.KissCalcEdit edtSucheBaPersonID;
        private KiSS4.Gui.KissCalcEdit edtSucheFaFallID;
        private KiSS4.Gui.KissCheckEdit edtSucheFalltraeger;
        private KiSS4.Gui.KissDateEdit edtSucheGeburt;
        private KiSS4.Gui.KissLookUpEdit edtSucheGruppe;
        private KiSS4.Gui.KissCheckEdit edtSucheLeistungstraeger;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KiSS4.Gui.KissTextEdit edtSucheOrt;
        private KiSS4.Gui.KissTextEdit edtSuchePLZ;
        private KiSS4.Gui.KissCalcEdit edtSucheResoNr;
        private KiSS4.Gui.KissTextEdit edtSucheStrasse;
        private KiSS4.Gui.KissLookUpEdit edtSucheTeam;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KiSS4.Gui.KissCalcEdit edtSucheEinwohnerregisterId;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private KiSS4.Gui.KissLabel lblPID;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel lblKlientensystem;
        private KiSS4.Gui.KissLabel lblSucheAHV;
        private KiSS4.Gui.KissLabel lblSucheGeburt;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSuchePLZOrt;
        private KiSS4.Gui.KissLabel lblSucheStrasse;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private KiSS4.Gui.KissTextEdit edtSucheVersichertenNr;
        private KiSS4.Gui.KissLabel lblSucheVersichertenNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertennummer;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox5;
    }
}
