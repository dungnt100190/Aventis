using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using KiSS.DBScheme;

using KiSS4.DB;
using KiSS4.Common.PI;

namespace KiSS4.Fallfuehrung.PI
{
    partial class CtlFaSituationsbeschreibung 
    {
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaSituationsbeschreibung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.btnNext = new KiSS4.Gui.KissButton();
            this.btnPrevious = new KiSS4.Gui.KissButton();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tabSituationsbeschreibung = new KiSS4.Gui.KissTabControlEx();
            this.tpgSichtweisen = new SharpLibrary.WinControls.TabPageEx();
            this.tblSichtweisen = new System.Windows.Forms.TableLayoutPanel();
            this.edtSichtweisenBemerkungen = new KiSS4.Gui.KissRTFEdit();
            this.qryFaSituationsbeschreibung = new KiSS4.DB.SqlQuery(this.components);
            this.lblSichtweisenBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtSichtweisenKlient = new KiSS4.Gui.KissRTFEdit();
            this.lblSichtweisenKlientIn = new KiSS4.Gui.KissLabel();
            this.edtSichtweisenFachstellen = new KiSS4.Gui.KissRTFEdit();
            this.lblSichtweisenFachstellen = new KiSS4.Gui.KissLabel();
            this.edtSichtweisenSA = new KiSS4.Gui.KissRTFEdit();
            this.lblSichtweisenSAR = new KiSS4.Gui.KissLabel();
            this.tpgRessourcen = new SharpLibrary.WinControls.TabPageEx();
            this.tblRessourcen = new System.Windows.Forms.TableLayoutPanel();
            this.edtRessourcenInstitutionell = new KiSS4.Gui.KissRTFEdit();
            this.lblRessourcenPersoenlich = new KiSS4.Gui.KissLabel();
            this.edtRessourcenPersoenlich = new KiSS4.Gui.KissRTFEdit();
            this.lblRessourcenFaehigkeiten = new KiSS4.Gui.KissLabel();
            this.lblRessourcenSozial = new KiSS4.Gui.KissLabel();
            this.edtRessourcenSozial = new KiSS4.Gui.KissRTFEdit();
            this.lblRessourcenFreunde = new KiSS4.Gui.KissLabel();
            this.lblRessourcenMateriell = new KiSS4.Gui.KissLabel();
            this.edtRessourcenMateriell = new KiSS4.Gui.KissRTFEdit();
            this.lblRessourcenFinanziell = new KiSS4.Gui.KissLabel();
            this.lblRessourcenInstitutionell = new KiSS4.Gui.KissLabel();
            this.lblRessourcenOrganisation = new KiSS4.Gui.KissLabel();
            this.tpgLebensbereiche = new SharpLibrary.WinControls.TabPageEx();
            this.tblLebensbereiche = new System.Windows.Forms.TableLayoutPanel();
            this.lblLebensbereicheSozialversicherung = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheSozialversicherung = new KiSS4.Gui.KissRTFEdit();
            this.panLebensbereichLine = new System.Windows.Forms.Panel();
            this.edtLebensbereicheLebensplan = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheLebensplan = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheWohnen = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheWohnen = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheFreizeit = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheFreizeit = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheSituationKinder = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheSituationKinder = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheSozialeKontakte = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheSozialeKontakte = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheGesundheit = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheGesundheit = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheFinanzen = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheFinanzen = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheTagesstruktur = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheTagesstruktur = new KiSS4.Gui.KissLabel();
            this.edtLebensbereicheArbeitAusbildung = new KiSS4.Gui.KissRTFEdit();
            this.lblLebensbereicheArbeitAusbildung = new KiSS4.Gui.KissLabel();
            this.tpgUebersicht = new SharpLibrary.WinControls.TabPageEx();
            this.tblUebersicht = new System.Windows.Forms.TableLayoutPanel();
            this.lblUebersichtBeschreibung = new KiSS4.Gui.KissLabel();
            this.lblUebersichtThemen = new KiSS4.Gui.KissLabel();
            this.lblUebersichtLeistungenAndere = new KiSS4.Gui.KissLabel();
            this.lblUebersichtBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtUebersichtBeschreibung = new KiSS4.Gui.KissRTFEdit();
            this.edtUebersichtThemen = new KiSS4.Gui.KissRTFEdit();
            this.edtUebersichtBemerkungen = new KiSS4.Gui.KissRTFEdit();
            this.edtUebersichtLeistungenAndere = new KiSS4.Gui.KissRTFEdit();
            this.edtUebersichtDatumDSMerkblatt = new KiSS4.Gui.KissDateEdit();
            this.lblUebersichtDatumDSMerkblatt = new KiSS4.Gui.KissLabel();
            this.chkUebersichtCMPruefen_focus = new KiSS4.Gui.KissCheckEdit();
            this.chkUebersichtCMPruefen = new KiSS4.Gui.KissCheckEdit();
            this.docBericht = new KiSS4.Dokument.KissDocumentButton();
            this.panBottomSpacer = new System.Windows.Forms.Panel();
            this.lblLetzteAenderung = new KiSS4.Gui.KissLabel();
            this.edtLetzteAenderung = new KiSS4.Gui.KissDateEdit();
            this.btnHistorisieren = new KiSS4.Gui.KissButton();
            this.btnVerlaufAnzeigen = new KiSS4.Gui.KissButton();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tabSituationsbeschreibung.SuspendLayout();
            this.tpgSichtweisen.SuspendLayout();
            this.tblSichtweisen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaSituationsbeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenKlientIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenFachstellen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenSAR)).BeginInit();
            this.tpgRessourcen.SuspendLayout();
            this.tblRessourcen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenPersoenlich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenFaehigkeiten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenSozial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenFreunde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenMateriell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenFinanziell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenInstitutionell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenOrganisation)).BeginInit();
            this.tpgLebensbereiche.SuspendLayout();
            this.tblLebensbereiche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheSozialversicherung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheLebensplan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheWohnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheFreizeit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheSituationKinder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheSozialeKontakte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheGesundheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheFinanzen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheTagesstruktur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheArbeitAusbildung)).BeginInit();
            this.tpgUebersicht.SuspendLayout();
            this.tblUebersicht.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtThemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtLeistungenAndere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUebersichtDatumDSMerkblatt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtDatumDSMerkblatt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUebersichtCMPruefen_focus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUebersichtCMPruefen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAenderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzteAenderung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.btnNext);
            this.panTitel.Controls.Add(this.btnPrevious);
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(681, 30);
            this.panTitel.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.IconID = 13;
            this.btnNext.Location = new System.Drawing.Point(651, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 2;
            this.btnNext.UseCompatibleTextRendering = true;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.IconID = 11;
            this.btnPrevious.Location = new System.Drawing.Point(621, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(24, 24);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.UseCompatibleTextRendering = true;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(580, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Situationsbeschreibung / Assessment";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // tabSituationsbeschreibung
            // 
            this.tabSituationsbeschreibung.Controls.Add(this.tpgSichtweisen);
            this.tabSituationsbeschreibung.Controls.Add(this.tpgRessourcen);
            this.tabSituationsbeschreibung.Controls.Add(this.tpgLebensbereiche);
            this.tabSituationsbeschreibung.Controls.Add(this.tpgUebersicht);
            this.tabSituationsbeschreibung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSituationsbeschreibung.Location = new System.Drawing.Point(0, 30);
            this.tabSituationsbeschreibung.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.tabSituationsbeschreibung.Name = "tabSituationsbeschreibung";
            this.tabSituationsbeschreibung.ShowFixedWidthTooltip = true;
            this.tabSituationsbeschreibung.ShowIconOnContainingData = true;
            this.tabSituationsbeschreibung.Size = new System.Drawing.Size(681, 620);
            this.tabSituationsbeschreibung.TabIndex = 1;
            this.tabSituationsbeschreibung.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgUebersicht,
            this.tpgLebensbereiche,
            this.tpgRessourcen,
            this.tpgSichtweisen});
            this.tabSituationsbeschreibung.TabsLineColor = System.Drawing.Color.Black;
            this.tabSituationsbeschreibung.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgSichtweisen
            // 
            this.tpgSichtweisen.Controls.Add(this.tblSichtweisen);
            this.tpgSichtweisen.Location = new System.Drawing.Point(6, 6);
            this.tpgSichtweisen.Name = "tpgSichtweisen";
            this.tpgSichtweisen.Size = new System.Drawing.Size(669, 582);
            this.tpgSichtweisen.TabIndex = 4;
            this.tpgSichtweisen.Title = "Sicht&weisen";
            // 
            // tblSichtweisen
            // 
            this.tblSichtweisen.ColumnCount = 2;
            this.tblSichtweisen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblSichtweisen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSichtweisen.Controls.Add(this.edtSichtweisenBemerkungen, 1, 3);
            this.tblSichtweisen.Controls.Add(this.lblSichtweisenBemerkungen, 0, 3);
            this.tblSichtweisen.Controls.Add(this.edtSichtweisenKlient, 1, 2);
            this.tblSichtweisen.Controls.Add(this.lblSichtweisenKlientIn, 0, 2);
            this.tblSichtweisen.Controls.Add(this.edtSichtweisenFachstellen, 1, 1);
            this.tblSichtweisen.Controls.Add(this.lblSichtweisenFachstellen, 0, 1);
            this.tblSichtweisen.Controls.Add(this.edtSichtweisenSA, 1, 0);
            this.tblSichtweisen.Controls.Add(this.lblSichtweisenSAR, 0, 0);
            this.tblSichtweisen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSichtweisen.Location = new System.Drawing.Point(0, 0);
            this.tblSichtweisen.Name = "tblSichtweisen";
            this.tblSichtweisen.RowCount = 4;
            this.tblSichtweisen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSichtweisen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSichtweisen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSichtweisen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSichtweisen.Size = new System.Drawing.Size(669, 582);
            this.tblSichtweisen.TabIndex = 0;
            // 
            // edtSichtweisenBemerkungen
            // 
            this.edtSichtweisenBemerkungen.BackColor = System.Drawing.Color.White;
            this.edtSichtweisenBemerkungen.DataMember = "SichtweisenBemerkungen";
            this.edtSichtweisenBemerkungen.DataSource = this.qryFaSituationsbeschreibung;
            this.edtSichtweisenBemerkungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSichtweisenBemerkungen.Font = new System.Drawing.Font("Arial", 10F);
            this.edtSichtweisenBemerkungen.Location = new System.Drawing.Point(118, 438);
            this.edtSichtweisenBemerkungen.Name = "edtSichtweisenBemerkungen";
            this.edtSichtweisenBemerkungen.Size = new System.Drawing.Size(548, 141);
            this.edtSichtweisenBemerkungen.TabIndex = 7;
            // 
            // qryFaSituationsbeschreibung
            // 
            this.qryFaSituationsbeschreibung.HostControl = this;
            this.qryFaSituationsbeschreibung.IsIdentityInsert = false;
            this.qryFaSituationsbeschreibung.TableName = "FaSituationsbeschreibung";
            this.qryFaSituationsbeschreibung.AfterFill += new System.EventHandler(this.qryFaSituationsbeschreibung_AfterFill);
            this.qryFaSituationsbeschreibung.AfterInsert += new System.EventHandler(this.qryFaSituationsbeschreibung_AfterInsert);
            this.qryFaSituationsbeschreibung.AfterPost += new System.EventHandler(this.qryFaSituationsbeschreibung_AfterPost);
            // 
            // lblSichtweisenBemerkungen
            // 
            this.lblSichtweisenBemerkungen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSichtweisenBemerkungen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSichtweisenBemerkungen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSichtweisenBemerkungen.Location = new System.Drawing.Point(3, 441);
            this.lblSichtweisenBemerkungen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblSichtweisenBemerkungen.Name = "lblSichtweisenBemerkungen";
            this.lblSichtweisenBemerkungen.Size = new System.Drawing.Size(109, 141);
            this.lblSichtweisenBemerkungen.TabIndex = 6;
            this.lblSichtweisenBemerkungen.Text = "Bemerkungen";
            this.lblSichtweisenBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtSichtweisenKlient
            // 
            this.edtSichtweisenKlient.BackColor = System.Drawing.Color.White;
            this.edtSichtweisenKlient.DataMember = "SichtweisenKlient";
            this.edtSichtweisenKlient.DataSource = this.qryFaSituationsbeschreibung;
            this.edtSichtweisenKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSichtweisenKlient.Font = new System.Drawing.Font("Arial", 10F);
            this.edtSichtweisenKlient.Location = new System.Drawing.Point(118, 293);
            this.edtSichtweisenKlient.Name = "edtSichtweisenKlient";
            this.edtSichtweisenKlient.Size = new System.Drawing.Size(548, 139);
            this.edtSichtweisenKlient.TabIndex = 5;
            // 
            // lblSichtweisenKlientIn
            // 
            this.lblSichtweisenKlientIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSichtweisenKlientIn.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSichtweisenKlientIn.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSichtweisenKlientIn.Location = new System.Drawing.Point(3, 296);
            this.lblSichtweisenKlientIn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblSichtweisenKlientIn.Name = "lblSichtweisenKlientIn";
            this.lblSichtweisenKlientIn.Size = new System.Drawing.Size(106, 139);
            this.lblSichtweisenKlientIn.TabIndex = 4;
            this.lblSichtweisenKlientIn.Text = "Sicht Klient/in";
            this.lblSichtweisenKlientIn.UseCompatibleTextRendering = true;
            // 
            // edtSichtweisenFachstellen
            // 
            this.edtSichtweisenFachstellen.BackColor = System.Drawing.Color.White;
            this.edtSichtweisenFachstellen.DataMember = "SichtweisenFachstellen";
            this.edtSichtweisenFachstellen.DataSource = this.qryFaSituationsbeschreibung;
            this.edtSichtweisenFachstellen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSichtweisenFachstellen.Font = new System.Drawing.Font("Arial", 10F);
            this.edtSichtweisenFachstellen.Location = new System.Drawing.Point(118, 148);
            this.edtSichtweisenFachstellen.Name = "edtSichtweisenFachstellen";
            this.edtSichtweisenFachstellen.Size = new System.Drawing.Size(548, 139);
            this.edtSichtweisenFachstellen.TabIndex = 3;
            // 
            // lblSichtweisenFachstellen
            // 
            this.lblSichtweisenFachstellen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSichtweisenFachstellen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSichtweisenFachstellen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSichtweisenFachstellen.Location = new System.Drawing.Point(3, 151);
            this.lblSichtweisenFachstellen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblSichtweisenFachstellen.Name = "lblSichtweisenFachstellen";
            this.lblSichtweisenFachstellen.Size = new System.Drawing.Size(106, 139);
            this.lblSichtweisenFachstellen.TabIndex = 2;
            this.lblSichtweisenFachstellen.Text = "Sicht weitere Fachstellen";
            this.lblSichtweisenFachstellen.UseCompatibleTextRendering = true;
            // 
            // edtSichtweisenSA
            // 
            this.edtSichtweisenSA.BackColor = System.Drawing.Color.White;
            this.edtSichtweisenSA.DataMember = "SichtweisenSA";
            this.edtSichtweisenSA.DataSource = this.qryFaSituationsbeschreibung;
            this.edtSichtweisenSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSichtweisenSA.Font = new System.Drawing.Font("Arial", 10F);
            this.edtSichtweisenSA.Location = new System.Drawing.Point(118, 3);
            this.edtSichtweisenSA.Name = "edtSichtweisenSA";
            this.edtSichtweisenSA.Size = new System.Drawing.Size(548, 139);
            this.edtSichtweisenSA.TabIndex = 1;
            // 
            // lblSichtweisenSAR
            // 
            this.lblSichtweisenSAR.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSichtweisenSAR.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSichtweisenSAR.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSichtweisenSAR.Location = new System.Drawing.Point(3, 6);
            this.lblSichtweisenSAR.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblSichtweisenSAR.Name = "lblSichtweisenSAR";
            this.lblSichtweisenSAR.Size = new System.Drawing.Size(106, 139);
            this.lblSichtweisenSAR.TabIndex = 0;
            this.lblSichtweisenSAR.Text = "Sicht Sozialarbeiter/in";
            this.lblSichtweisenSAR.UseCompatibleTextRendering = true;
            // 
            // tpgRessourcen
            // 
            this.tpgRessourcen.Controls.Add(this.tblRessourcen);
            this.tpgRessourcen.Location = new System.Drawing.Point(6, 6);
            this.tpgRessourcen.Name = "tpgRessourcen";
            this.tpgRessourcen.Size = new System.Drawing.Size(669, 582);
            this.tpgRessourcen.TabIndex = 3;
            this.tpgRessourcen.Title = "&Ressourcen";
            // 
            // tblRessourcen
            // 
            this.tblRessourcen.ColumnCount = 2;
            this.tblRessourcen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblRessourcen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRessourcen.Controls.Add(this.edtRessourcenInstitutionell, 1, 7);
            this.tblRessourcen.Controls.Add(this.lblRessourcenPersoenlich, 0, 1);
            this.tblRessourcen.Controls.Add(this.edtRessourcenPersoenlich, 1, 1);
            this.tblRessourcen.Controls.Add(this.lblRessourcenFaehigkeiten, 1, 0);
            this.tblRessourcen.Controls.Add(this.lblRessourcenSozial, 0, 3);
            this.tblRessourcen.Controls.Add(this.edtRessourcenSozial, 1, 3);
            this.tblRessourcen.Controls.Add(this.lblRessourcenFreunde, 1, 2);
            this.tblRessourcen.Controls.Add(this.lblRessourcenMateriell, 0, 5);
            this.tblRessourcen.Controls.Add(this.edtRessourcenMateriell, 1, 5);
            this.tblRessourcen.Controls.Add(this.lblRessourcenFinanziell, 1, 4);
            this.tblRessourcen.Controls.Add(this.lblRessourcenInstitutionell, 0, 7);
            this.tblRessourcen.Controls.Add(this.lblRessourcenOrganisation, 1, 6);
            this.tblRessourcen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRessourcen.Location = new System.Drawing.Point(0, 0);
            this.tblRessourcen.Name = "tblRessourcen";
            this.tblRessourcen.RowCount = 8;
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblRessourcen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblRessourcen.Size = new System.Drawing.Size(669, 582);
            this.tblRessourcen.TabIndex = 0;
            // 
            // edtRessourcenInstitutionell
            // 
            this.edtRessourcenInstitutionell.BackColor = System.Drawing.Color.White;
            this.edtRessourcenInstitutionell.DataMember = "RessourcenInstitutionell";
            this.edtRessourcenInstitutionell.DataSource = this.qryFaSituationsbeschreibung;
            this.edtRessourcenInstitutionell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtRessourcenInstitutionell.Font = new System.Drawing.Font("Arial", 10F);
            this.edtRessourcenInstitutionell.Location = new System.Drawing.Point(112, 464);
            this.edtRessourcenInstitutionell.Name = "edtRessourcenInstitutionell";
            this.edtRessourcenInstitutionell.Size = new System.Drawing.Size(554, 115);
            this.edtRessourcenInstitutionell.TabIndex = 11;
            // 
            // lblRessourcenPersoenlich
            // 
            this.lblRessourcenPersoenlich.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRessourcenPersoenlich.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenPersoenlich.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenPersoenlich.Location = new System.Drawing.Point(3, 23);
            this.lblRessourcenPersoenlich.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblRessourcenPersoenlich.Name = "lblRessourcenPersoenlich";
            this.lblRessourcenPersoenlich.Size = new System.Drawing.Size(103, 113);
            this.lblRessourcenPersoenlich.TabIndex = 1;
            this.lblRessourcenPersoenlich.Text = "Persönliche Ressourcen und Kompetenzen";
            this.lblRessourcenPersoenlich.UseCompatibleTextRendering = true;
            // 
            // edtRessourcenPersoenlich
            // 
            this.edtRessourcenPersoenlich.BackColor = System.Drawing.Color.White;
            this.edtRessourcenPersoenlich.DataMember = "RessourcenPersoenlich";
            this.edtRessourcenPersoenlich.DataSource = this.qryFaSituationsbeschreibung;
            this.edtRessourcenPersoenlich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtRessourcenPersoenlich.Font = new System.Drawing.Font("Arial", 10F);
            this.edtRessourcenPersoenlich.Location = new System.Drawing.Point(112, 20);
            this.edtRessourcenPersoenlich.Name = "edtRessourcenPersoenlich";
            this.edtRessourcenPersoenlich.Size = new System.Drawing.Size(554, 113);
            this.edtRessourcenPersoenlich.TabIndex = 2;
            // 
            // lblRessourcenFaehigkeiten
            // 
            this.lblRessourcenFaehigkeiten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRessourcenFaehigkeiten.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenFaehigkeiten.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenFaehigkeiten.Location = new System.Drawing.Point(112, 0);
            this.lblRessourcenFaehigkeiten.Name = "lblRessourcenFaehigkeiten";
            this.lblRessourcenFaehigkeiten.Size = new System.Drawing.Size(554, 17);
            this.lblRessourcenFaehigkeiten.TabIndex = 0;
            this.lblRessourcenFaehigkeiten.Text = "über welche Fähigkeiten, Möglichkeiten verfügen Sie?";
            this.lblRessourcenFaehigkeiten.UseCompatibleTextRendering = true;
            // 
            // lblRessourcenSozial
            // 
            this.lblRessourcenSozial.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRessourcenSozial.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenSozial.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenSozial.Location = new System.Drawing.Point(3, 171);
            this.lblRessourcenSozial.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblRessourcenSozial.Name = "lblRessourcenSozial";
            this.lblRessourcenSozial.Size = new System.Drawing.Size(103, 113);
            this.lblRessourcenSozial.TabIndex = 4;
            this.lblRessourcenSozial.Text = "Soziale Ressourcen (Beziehungen)";
            this.lblRessourcenSozial.UseCompatibleTextRendering = true;
            // 
            // edtRessourcenSozial
            // 
            this.edtRessourcenSozial.BackColor = System.Drawing.Color.White;
            this.edtRessourcenSozial.DataMember = "RessourcenSozial";
            this.edtRessourcenSozial.DataSource = this.qryFaSituationsbeschreibung;
            this.edtRessourcenSozial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtRessourcenSozial.Font = new System.Drawing.Font("Arial", 10F);
            this.edtRessourcenSozial.Location = new System.Drawing.Point(112, 168);
            this.edtRessourcenSozial.Name = "edtRessourcenSozial";
            this.edtRessourcenSozial.Size = new System.Drawing.Size(554, 113);
            this.edtRessourcenSozial.TabIndex = 5;
            // 
            // lblRessourcenFreunde
            // 
            this.lblRessourcenFreunde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRessourcenFreunde.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenFreunde.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenFreunde.Location = new System.Drawing.Point(112, 148);
            this.lblRessourcenFreunde.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.lblRessourcenFreunde.Name = "lblRessourcenFreunde";
            this.lblRessourcenFreunde.Size = new System.Drawing.Size(554, 17);
            this.lblRessourcenFreunde.TabIndex = 3;
            this.lblRessourcenFreunde.Text = "wie können Verwandte, Freunde unterstützen?";
            this.lblRessourcenFreunde.UseCompatibleTextRendering = true;
            // 
            // lblRessourcenMateriell
            // 
            this.lblRessourcenMateriell.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRessourcenMateriell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenMateriell.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenMateriell.Location = new System.Drawing.Point(3, 319);
            this.lblRessourcenMateriell.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblRessourcenMateriell.Name = "lblRessourcenMateriell";
            this.lblRessourcenMateriell.Size = new System.Drawing.Size(103, 113);
            this.lblRessourcenMateriell.TabIndex = 7;
            this.lblRessourcenMateriell.Text = "Materielle Ressourcen";
            this.lblRessourcenMateriell.UseCompatibleTextRendering = true;
            // 
            // edtRessourcenMateriell
            // 
            this.edtRessourcenMateriell.BackColor = System.Drawing.Color.White;
            this.edtRessourcenMateriell.DataMember = "RessourcenMateriell";
            this.edtRessourcenMateriell.DataSource = this.qryFaSituationsbeschreibung;
            this.edtRessourcenMateriell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtRessourcenMateriell.Font = new System.Drawing.Font("Arial", 10F);
            this.edtRessourcenMateriell.Location = new System.Drawing.Point(112, 316);
            this.edtRessourcenMateriell.Name = "edtRessourcenMateriell";
            this.edtRessourcenMateriell.Size = new System.Drawing.Size(554, 113);
            this.edtRessourcenMateriell.TabIndex = 8;
            // 
            // lblRessourcenFinanziell
            // 
            this.lblRessourcenFinanziell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRessourcenFinanziell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenFinanziell.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenFinanziell.Location = new System.Drawing.Point(112, 296);
            this.lblRessourcenFinanziell.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.lblRessourcenFinanziell.Name = "lblRessourcenFinanziell";
            this.lblRessourcenFinanziell.Size = new System.Drawing.Size(554, 17);
            this.lblRessourcenFinanziell.TabIndex = 6;
            this.lblRessourcenFinanziell.Text = "über welche finanziellen Ressourcen verfügen Sie?";
            this.lblRessourcenFinanziell.UseCompatibleTextRendering = true;
            // 
            // lblRessourcenInstitutionell
            // 
            this.lblRessourcenInstitutionell.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRessourcenInstitutionell.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenInstitutionell.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenInstitutionell.Location = new System.Drawing.Point(3, 467);
            this.lblRessourcenInstitutionell.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblRessourcenInstitutionell.Name = "lblRessourcenInstitutionell";
            this.lblRessourcenInstitutionell.Size = new System.Drawing.Size(103, 115);
            this.lblRessourcenInstitutionell.TabIndex = 10;
            this.lblRessourcenInstitutionell.Text = "Sozialräumliche und institutionelle Ressourcen";
            this.lblRessourcenInstitutionell.UseCompatibleTextRendering = true;
            // 
            // lblRessourcenOrganisation
            // 
            this.lblRessourcenOrganisation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRessourcenOrganisation.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRessourcenOrganisation.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRessourcenOrganisation.Location = new System.Drawing.Point(112, 444);
            this.lblRessourcenOrganisation.Margin = new System.Windows.Forms.Padding(3, 12, 3, 0);
            this.lblRessourcenOrganisation.Name = "lblRessourcenOrganisation";
            this.lblRessourcenOrganisation.Size = new System.Drawing.Size(554, 17);
            this.lblRessourcenOrganisation.TabIndex = 9;
            this.lblRessourcenOrganisation.Text = "welche Organisation hat Sie unterstützt?";
            this.lblRessourcenOrganisation.UseCompatibleTextRendering = true;
            // 
            // tpgLebensbereiche
            // 
            this.tpgLebensbereiche.Controls.Add(this.tblLebensbereiche);
            this.tpgLebensbereiche.Location = new System.Drawing.Point(6, 6);
            this.tpgLebensbereiche.Name = "tpgLebensbereiche";
            this.tpgLebensbereiche.Size = new System.Drawing.Size(669, 582);
            this.tpgLebensbereiche.TabIndex = 1;
            this.tpgLebensbereiche.Title = "Lebe&nsbereiche";
            // 
            // tblLebensbereiche
            // 
            this.tblLebensbereiche.ColumnCount = 2;
            this.tblLebensbereiche.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLebensbereiche.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheSozialversicherung, 0, 10);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheSozialversicherung, 1, 10);
            this.tblLebensbereiche.Controls.Add(this.panLebensbereichLine, 0, 9);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheLebensplan, 1, 8);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheLebensplan, 0, 8);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheWohnen, 1, 7);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheWohnen, 0, 7);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheFreizeit, 1, 6);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheFreizeit, 0, 6);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheSituationKinder, 1, 5);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheSituationKinder, 0, 5);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheSozialeKontakte, 1, 4);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheSozialeKontakte, 0, 4);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheGesundheit, 1, 3);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheGesundheit, 0, 3);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheFinanzen, 1, 2);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheFinanzen, 0, 2);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheTagesstruktur, 1, 1);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheTagesstruktur, 0, 1);
            this.tblLebensbereiche.Controls.Add(this.edtLebensbereicheArbeitAusbildung, 1, 0);
            this.tblLebensbereiche.Controls.Add(this.lblLebensbereicheArbeitAusbildung, 0, 0);
            this.tblLebensbereiche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLebensbereiche.Location = new System.Drawing.Point(0, 0);
            this.tblLebensbereiche.Name = "tblLebensbereiche";
            this.tblLebensbereiche.RowCount = 11;
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLebensbereiche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLebensbereiche.Size = new System.Drawing.Size(669, 582);
            this.tblLebensbereiche.TabIndex = 0;
            // 
            // lblLebensbereicheSozialversicherung
            // 
            this.lblLebensbereicheSozialversicherung.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheSozialversicherung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheSozialversicherung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheSozialversicherung.Location = new System.Drawing.Point(3, 526);
            this.lblLebensbereicheSozialversicherung.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheSozialversicherung.Name = "lblLebensbereicheSozialversicherung";
            this.lblLebensbereicheSozialversicherung.Size = new System.Drawing.Size(159, 56);
            this.lblLebensbereicheSozialversicherung.TabIndex = 19;
            this.lblLebensbereicheSozialversicherung.Text = "Sozialversicherung / Rechtliches";
            this.lblLebensbereicheSozialversicherung.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheSozialversicherung
            // 
            this.edtLebensbereicheSozialversicherung.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheSozialversicherung.DataMember = "LebensbereicheSozialversicherung";
            this.edtLebensbereicheSozialversicherung.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheSozialversicherung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheSozialversicherung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheSozialversicherung.Location = new System.Drawing.Point(168, 523);
            this.edtLebensbereicheSozialversicherung.Name = "edtLebensbereicheSozialversicherung";
            this.edtLebensbereicheSozialversicherung.Size = new System.Drawing.Size(498, 56);
            this.edtLebensbereicheSozialversicherung.TabIndex = 20;
            // 
            // panLebensbereichLine
            // 
            this.panLebensbereichLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panLebensbereichLine.BackColor = System.Drawing.Color.Black;
            this.tblLebensbereiche.SetColumnSpan(this.panLebensbereichLine, 2);
            this.panLebensbereichLine.Location = new System.Drawing.Point(3, 516);
            this.panLebensbereichLine.Name = "panLebensbereichLine";
            this.panLebensbereichLine.Size = new System.Drawing.Size(663, 1);
            this.panLebensbereichLine.TabIndex = 18;
            // 
            // edtLebensbereicheLebensplan
            // 
            this.edtLebensbereicheLebensplan.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheLebensplan.DataMember = "LebensbereicheLebensplan";
            this.edtLebensbereicheLebensplan.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheLebensplan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheLebensplan.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheLebensplan.Location = new System.Drawing.Point(168, 459);
            this.edtLebensbereicheLebensplan.Name = "edtLebensbereicheLebensplan";
            this.edtLebensbereicheLebensplan.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheLebensplan.TabIndex = 17;
            // 
            // lblLebensbereicheLebensplan
            // 
            this.lblLebensbereicheLebensplan.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheLebensplan.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheLebensplan.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheLebensplan.Location = new System.Drawing.Point(3, 462);
            this.lblLebensbereicheLebensplan.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheLebensplan.Name = "lblLebensbereicheLebensplan";
            this.lblLebensbereicheLebensplan.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheLebensplan.TabIndex = 16;
            this.lblLebensbereicheLebensplan.Text = "Lebensplan / -sinn";
            this.lblLebensbereicheLebensplan.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheWohnen
            // 
            this.edtLebensbereicheWohnen.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheWohnen.DataMember = "LebensbereicheWohnen";
            this.edtLebensbereicheWohnen.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheWohnen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheWohnen.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheWohnen.Location = new System.Drawing.Point(168, 402);
            this.edtLebensbereicheWohnen.Name = "edtLebensbereicheWohnen";
            this.edtLebensbereicheWohnen.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheWohnen.TabIndex = 15;
            // 
            // lblLebensbereicheWohnen
            // 
            this.lblLebensbereicheWohnen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheWohnen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheWohnen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheWohnen.Location = new System.Drawing.Point(3, 405);
            this.lblLebensbereicheWohnen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheWohnen.Name = "lblLebensbereicheWohnen";
            this.lblLebensbereicheWohnen.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheWohnen.TabIndex = 14;
            this.lblLebensbereicheWohnen.Text = "Wohnen";
            this.lblLebensbereicheWohnen.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheFreizeit
            // 
            this.edtLebensbereicheFreizeit.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheFreizeit.DataMember = "LebensbereicheFreizeit";
            this.edtLebensbereicheFreizeit.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheFreizeit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheFreizeit.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheFreizeit.Location = new System.Drawing.Point(168, 345);
            this.edtLebensbereicheFreizeit.Name = "edtLebensbereicheFreizeit";
            this.edtLebensbereicheFreizeit.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheFreizeit.TabIndex = 13;
            // 
            // lblLebensbereicheFreizeit
            // 
            this.lblLebensbereicheFreizeit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheFreizeit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheFreizeit.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheFreizeit.Location = new System.Drawing.Point(3, 348);
            this.lblLebensbereicheFreizeit.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheFreizeit.Name = "lblLebensbereicheFreizeit";
            this.lblLebensbereicheFreizeit.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheFreizeit.TabIndex = 12;
            this.lblLebensbereicheFreizeit.Text = "Freizeit";
            this.lblLebensbereicheFreizeit.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheSituationKinder
            // 
            this.edtLebensbereicheSituationKinder.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheSituationKinder.DataMember = "LebensbereicheSituationKinder";
            this.edtLebensbereicheSituationKinder.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheSituationKinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheSituationKinder.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheSituationKinder.Location = new System.Drawing.Point(168, 288);
            this.edtLebensbereicheSituationKinder.Name = "edtLebensbereicheSituationKinder";
            this.edtLebensbereicheSituationKinder.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheSituationKinder.TabIndex = 11;
            // 
            // lblLebensbereicheSituationKinder
            // 
            this.lblLebensbereicheSituationKinder.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheSituationKinder.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheSituationKinder.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheSituationKinder.Location = new System.Drawing.Point(3, 291);
            this.lblLebensbereicheSituationKinder.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheSituationKinder.Name = "lblLebensbereicheSituationKinder";
            this.lblLebensbereicheSituationKinder.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheSituationKinder.TabIndex = 10;
            this.lblLebensbereicheSituationKinder.Text = "Situation der Kinder (Wohlbefinden, Betreuung, Unterstützungsbedarf)";
            this.lblLebensbereicheSituationKinder.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheSozialeKontakte
            // 
            this.edtLebensbereicheSozialeKontakte.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheSozialeKontakte.DataMember = "LebensbereicheSozialeKontakte";
            this.edtLebensbereicheSozialeKontakte.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheSozialeKontakte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheSozialeKontakte.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheSozialeKontakte.Location = new System.Drawing.Point(168, 231);
            this.edtLebensbereicheSozialeKontakte.Name = "edtLebensbereicheSozialeKontakte";
            this.edtLebensbereicheSozialeKontakte.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheSozialeKontakte.TabIndex = 9;
            // 
            // lblLebensbereicheSozialeKontakte
            // 
            this.lblLebensbereicheSozialeKontakte.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheSozialeKontakte.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheSozialeKontakte.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheSozialeKontakte.Location = new System.Drawing.Point(3, 234);
            this.lblLebensbereicheSozialeKontakte.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheSozialeKontakte.Name = "lblLebensbereicheSozialeKontakte";
            this.lblLebensbereicheSozialeKontakte.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheSozialeKontakte.TabIndex = 8;
            this.lblLebensbereicheSozialeKontakte.Text = "Soziale Kontakte, Familie";
            this.lblLebensbereicheSozialeKontakte.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheGesundheit
            // 
            this.edtLebensbereicheGesundheit.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheGesundheit.DataMember = "LebensbereicheGesundheit";
            this.edtLebensbereicheGesundheit.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheGesundheit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheGesundheit.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheGesundheit.Location = new System.Drawing.Point(168, 174);
            this.edtLebensbereicheGesundheit.Name = "edtLebensbereicheGesundheit";
            this.edtLebensbereicheGesundheit.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheGesundheit.TabIndex = 7;
            // 
            // lblLebensbereicheGesundheit
            // 
            this.lblLebensbereicheGesundheit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheGesundheit.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheGesundheit.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheGesundheit.Location = new System.Drawing.Point(3, 177);
            this.lblLebensbereicheGesundheit.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheGesundheit.Name = "lblLebensbereicheGesundheit";
            this.lblLebensbereicheGesundheit.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheGesundheit.TabIndex = 6;
            this.lblLebensbereicheGesundheit.Text = "Gesundheit, Hilfsmittel, Therapien";
            this.lblLebensbereicheGesundheit.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheFinanzen
            // 
            this.edtLebensbereicheFinanzen.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheFinanzen.DataMember = "LebensbereicheFinanzen";
            this.edtLebensbereicheFinanzen.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheFinanzen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheFinanzen.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheFinanzen.Location = new System.Drawing.Point(168, 117);
            this.edtLebensbereicheFinanzen.Name = "edtLebensbereicheFinanzen";
            this.edtLebensbereicheFinanzen.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheFinanzen.TabIndex = 5;
            // 
            // lblLebensbereicheFinanzen
            // 
            this.lblLebensbereicheFinanzen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheFinanzen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheFinanzen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheFinanzen.Location = new System.Drawing.Point(3, 120);
            this.lblLebensbereicheFinanzen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheFinanzen.Name = "lblLebensbereicheFinanzen";
            this.lblLebensbereicheFinanzen.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheFinanzen.TabIndex = 4;
            this.lblLebensbereicheFinanzen.Text = "Finanzen";
            this.lblLebensbereicheFinanzen.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheTagesstruktur
            // 
            this.edtLebensbereicheTagesstruktur.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheTagesstruktur.DataMember = "LebensbereicheTagesstruktur";
            this.edtLebensbereicheTagesstruktur.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheTagesstruktur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheTagesstruktur.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheTagesstruktur.Location = new System.Drawing.Point(168, 60);
            this.edtLebensbereicheTagesstruktur.Name = "edtLebensbereicheTagesstruktur";
            this.edtLebensbereicheTagesstruktur.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheTagesstruktur.TabIndex = 3;
            // 
            // lblLebensbereicheTagesstruktur
            // 
            this.lblLebensbereicheTagesstruktur.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheTagesstruktur.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheTagesstruktur.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheTagesstruktur.Location = new System.Drawing.Point(3, 63);
            this.lblLebensbereicheTagesstruktur.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheTagesstruktur.Name = "lblLebensbereicheTagesstruktur";
            this.lblLebensbereicheTagesstruktur.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheTagesstruktur.TabIndex = 2;
            this.lblLebensbereicheTagesstruktur.Text = "Tagesstruktur";
            this.lblLebensbereicheTagesstruktur.UseCompatibleTextRendering = true;
            // 
            // edtLebensbereicheArbeitAusbildung
            // 
            this.edtLebensbereicheArbeitAusbildung.BackColor = System.Drawing.Color.White;
            this.edtLebensbereicheArbeitAusbildung.DataMember = "LebensbereicheArbeitAusbildung";
            this.edtLebensbereicheArbeitAusbildung.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLebensbereicheArbeitAusbildung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtLebensbereicheArbeitAusbildung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtLebensbereicheArbeitAusbildung.Location = new System.Drawing.Point(168, 3);
            this.edtLebensbereicheArbeitAusbildung.Name = "edtLebensbereicheArbeitAusbildung";
            this.edtLebensbereicheArbeitAusbildung.Size = new System.Drawing.Size(498, 51);
            this.edtLebensbereicheArbeitAusbildung.TabIndex = 1;
            // 
            // lblLebensbereicheArbeitAusbildung
            // 
            this.lblLebensbereicheArbeitAusbildung.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLebensbereicheArbeitAusbildung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLebensbereicheArbeitAusbildung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLebensbereicheArbeitAusbildung.Location = new System.Drawing.Point(3, 6);
            this.lblLebensbereicheArbeitAusbildung.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLebensbereicheArbeitAusbildung.Name = "lblLebensbereicheArbeitAusbildung";
            this.lblLebensbereicheArbeitAusbildung.Size = new System.Drawing.Size(159, 51);
            this.lblLebensbereicheArbeitAusbildung.TabIndex = 0;
            this.lblLebensbereicheArbeitAusbildung.Text = "Arbeit, Ausbildung";
            this.lblLebensbereicheArbeitAusbildung.UseCompatibleTextRendering = true;
            // 
            // tpgUebersicht
            // 
            this.tpgUebersicht.Controls.Add(this.tblUebersicht);
            this.tpgUebersicht.Controls.Add(this.edtUebersichtDatumDSMerkblatt);
            this.tpgUebersicht.Controls.Add(this.lblUebersichtDatumDSMerkblatt);
            this.tpgUebersicht.Controls.Add(this.chkUebersichtCMPruefen_focus);
            this.tpgUebersicht.Controls.Add(this.chkUebersichtCMPruefen);
            this.tpgUebersicht.Controls.Add(this.docBericht);
            this.tpgUebersicht.Location = new System.Drawing.Point(6, 6);
            this.tpgUebersicht.Name = "tpgUebersicht";
            this.tpgUebersicht.Size = new System.Drawing.Size(669, 582);
            this.tpgUebersicht.TabIndex = 0;
            this.tpgUebersicht.Title = "&Übersicht";
            // 
            // tblUebersicht
            // 
            this.tblUebersicht.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblUebersicht.ColumnCount = 2;
            this.tblUebersicht.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblUebersicht.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblUebersicht.Controls.Add(this.lblUebersichtBeschreibung, 0, 0);
            this.tblUebersicht.Controls.Add(this.lblUebersichtThemen, 0, 1);
            this.tblUebersicht.Controls.Add(this.lblUebersichtLeistungenAndere, 0, 2);
            this.tblUebersicht.Controls.Add(this.lblUebersichtBemerkungen, 0, 3);
            this.tblUebersicht.Controls.Add(this.edtUebersichtBeschreibung, 1, 0);
            this.tblUebersicht.Controls.Add(this.edtUebersichtThemen, 1, 1);
            this.tblUebersicht.Controls.Add(this.edtUebersichtBemerkungen, 1, 3);
            this.tblUebersicht.Controls.Add(this.edtUebersichtLeistungenAndere, 1, 2);
            this.tblUebersicht.Location = new System.Drawing.Point(0, 3);
            this.tblUebersicht.Name = "tblUebersicht";
            this.tblUebersicht.RowCount = 4;
            this.tblUebersicht.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblUebersicht.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblUebersicht.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblUebersicht.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblUebersicht.Size = new System.Drawing.Size(666, 542);
            this.tblUebersicht.TabIndex = 0;
            // 
            // lblUebersichtBeschreibung
            // 
            this.lblUebersichtBeschreibung.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUebersichtBeschreibung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtBeschreibung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtBeschreibung.Location = new System.Drawing.Point(3, 6);
            this.lblUebersichtBeschreibung.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblUebersichtBeschreibung.Name = "lblUebersichtBeschreibung";
            this.lblUebersichtBeschreibung.Size = new System.Drawing.Size(103, 129);
            this.lblUebersichtBeschreibung.TabIndex = 0;
            this.lblUebersichtBeschreibung.Text = "Anliegen, Anlass, Beschreibung der Situation";
            this.lblUebersichtBeschreibung.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtThemen
            // 
            this.lblUebersichtThemen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUebersichtThemen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtThemen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtThemen.Location = new System.Drawing.Point(3, 141);
            this.lblUebersichtThemen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblUebersichtThemen.Name = "lblUebersichtThemen";
            this.lblUebersichtThemen.Size = new System.Drawing.Size(103, 129);
            this.lblUebersichtThemen.TabIndex = 2;
            this.lblUebersichtThemen.Text = "Zu bearbeitende Themen";
            this.lblUebersichtThemen.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtLeistungenAndere
            // 
            this.lblUebersichtLeistungenAndere.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUebersichtLeistungenAndere.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtLeistungenAndere.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtLeistungenAndere.Location = new System.Drawing.Point(3, 276);
            this.lblUebersichtLeistungenAndere.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblUebersichtLeistungenAndere.Name = "lblUebersichtLeistungenAndere";
            this.lblUebersichtLeistungenAndere.Size = new System.Drawing.Size(103, 129);
            this.lblUebersichtLeistungenAndere.TabIndex = 4;
            this.lblUebersichtLeistungenAndere.Text = "Leistungen anderer Stellen";
            this.lblUebersichtLeistungenAndere.UseCompatibleTextRendering = true;
            // 
            // lblUebersichtBemerkungen
            // 
            this.lblUebersichtBemerkungen.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUebersichtBemerkungen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUebersichtBemerkungen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblUebersichtBemerkungen.Location = new System.Drawing.Point(3, 411);
            this.lblUebersichtBemerkungen.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblUebersichtBemerkungen.Name = "lblUebersichtBemerkungen";
            this.lblUebersichtBemerkungen.Size = new System.Drawing.Size(103, 131);
            this.lblUebersichtBemerkungen.TabIndex = 6;
            this.lblUebersichtBemerkungen.Text = "Bemerkungen";
            this.lblUebersichtBemerkungen.UseCompatibleTextRendering = true;
            // 
            // edtUebersichtBeschreibung
            // 
            this.edtUebersichtBeschreibung.BackColor = System.Drawing.Color.White;
            this.edtUebersichtBeschreibung.DataMember = "UebersichtBeschreibung";
            this.edtUebersichtBeschreibung.DataSource = this.qryFaSituationsbeschreibung;
            this.edtUebersichtBeschreibung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtUebersichtBeschreibung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtUebersichtBeschreibung.Location = new System.Drawing.Point(112, 3);
            this.edtUebersichtBeschreibung.Name = "edtUebersichtBeschreibung";
            this.edtUebersichtBeschreibung.Size = new System.Drawing.Size(551, 129);
            this.edtUebersichtBeschreibung.TabIndex = 1;
            // 
            // edtUebersichtThemen
            // 
            this.edtUebersichtThemen.BackColor = System.Drawing.Color.White;
            this.edtUebersichtThemen.DataMember = "UebersichtThemen";
            this.edtUebersichtThemen.DataSource = this.qryFaSituationsbeschreibung;
            this.edtUebersichtThemen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtUebersichtThemen.Font = new System.Drawing.Font("Arial", 10F);
            this.edtUebersichtThemen.Location = new System.Drawing.Point(112, 138);
            this.edtUebersichtThemen.Name = "edtUebersichtThemen";
            this.edtUebersichtThemen.Size = new System.Drawing.Size(551, 129);
            this.edtUebersichtThemen.TabIndex = 3;
            // 
            // edtUebersichtBemerkungen
            // 
            this.edtUebersichtBemerkungen.BackColor = System.Drawing.Color.White;
            this.edtUebersichtBemerkungen.DataMember = "UebersichtBemerkungen";
            this.edtUebersichtBemerkungen.DataSource = this.qryFaSituationsbeschreibung;
            this.edtUebersichtBemerkungen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtUebersichtBemerkungen.Font = new System.Drawing.Font("Arial", 10F);
            this.edtUebersichtBemerkungen.Location = new System.Drawing.Point(112, 408);
            this.edtUebersichtBemerkungen.Name = "edtUebersichtBemerkungen";
            this.edtUebersichtBemerkungen.Size = new System.Drawing.Size(551, 131);
            this.edtUebersichtBemerkungen.TabIndex = 7;
            // 
            // edtUebersichtLeistungenAndere
            // 
            this.edtUebersichtLeistungenAndere.BackColor = System.Drawing.Color.White;
            this.edtUebersichtLeistungenAndere.DataMember = "UebersichtStellen";
            this.edtUebersichtLeistungenAndere.DataSource = this.qryFaSituationsbeschreibung;
            this.edtUebersichtLeistungenAndere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtUebersichtLeistungenAndere.Font = new System.Drawing.Font("Arial", 10F);
            this.edtUebersichtLeistungenAndere.Location = new System.Drawing.Point(112, 273);
            this.edtUebersichtLeistungenAndere.Name = "edtUebersichtLeistungenAndere";
            this.edtUebersichtLeistungenAndere.Size = new System.Drawing.Size(551, 129);
            this.edtUebersichtLeistungenAndere.TabIndex = 5;
            // 
            // edtUebersichtDatumDSMerkblatt
            // 
            this.edtUebersichtDatumDSMerkblatt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUebersichtDatumDSMerkblatt.DataMember = "UebersichtDatumMerkblatt";
            this.edtUebersichtDatumDSMerkblatt.DataSource = this.qryFaSituationsbeschreibung;
            this.edtUebersichtDatumDSMerkblatt.EditValue = null;
            this.edtUebersichtDatumDSMerkblatt.Location = new System.Drawing.Point(556, 551);
            this.edtUebersichtDatumDSMerkblatt.Name = "edtUebersichtDatumDSMerkblatt";
            this.edtUebersichtDatumDSMerkblatt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUebersichtDatumDSMerkblatt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUebersichtDatumDSMerkblatt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUebersichtDatumDSMerkblatt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUebersichtDatumDSMerkblatt.Properties.Appearance.Options.UseBackColor = true;
            this.edtUebersichtDatumDSMerkblatt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUebersichtDatumDSMerkblatt.Properties.Appearance.Options.UseFont = true;
            this.edtUebersichtDatumDSMerkblatt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUebersichtDatumDSMerkblatt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtUebersichtDatumDSMerkblatt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUebersichtDatumDSMerkblatt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUebersichtDatumDSMerkblatt.Properties.ShowToday = false;
            this.edtUebersichtDatumDSMerkblatt.Size = new System.Drawing.Size(105, 24);
            this.edtUebersichtDatumDSMerkblatt.TabIndex = 5;
            // 
            // lblUebersichtDatumDSMerkblatt
            // 
            this.lblUebersichtDatumDSMerkblatt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUebersichtDatumDSMerkblatt.Location = new System.Drawing.Point(367, 551);
            this.lblUebersichtDatumDSMerkblatt.Name = "lblUebersichtDatumDSMerkblatt";
            this.lblUebersichtDatumDSMerkblatt.Size = new System.Drawing.Size(183, 24);
            this.lblUebersichtDatumDSMerkblatt.TabIndex = 4;
            this.lblUebersichtDatumDSMerkblatt.Text = "Datenschutzmerkblatt abgegeben";
            this.lblUebersichtDatumDSMerkblatt.UseCompatibleTextRendering = true;
            // 
            // chkUebersichtCMPruefen_focus
            // 
            this.chkUebersichtCMPruefen_focus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUebersichtCMPruefen_focus.EditValue = false;
            this.chkUebersichtCMPruefen_focus.Location = new System.Drawing.Point(204, 555);
            this.chkUebersichtCMPruefen_focus.Name = "chkUebersichtCMPruefen_focus";
            this.chkUebersichtCMPruefen_focus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkUebersichtCMPruefen_focus.Properties.Appearance.Options.UseBackColor = true;
            this.chkUebersichtCMPruefen_focus.Properties.Caption = "seit Geburt";
            this.chkUebersichtCMPruefen_focus.Size = new System.Drawing.Size(24, 19);
            this.chkUebersichtCMPruefen_focus.TabIndex = 2;
            this.chkUebersichtCMPruefen_focus.Visible = false;
            // 
            // chkUebersichtCMPruefen
            // 
            this.chkUebersichtCMPruefen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUebersichtCMPruefen.DataMember = "UebersichtCMUeberpruefen";
            this.chkUebersichtCMPruefen.DataSource = this.qryFaSituationsbeschreibung;
            this.chkUebersichtCMPruefen.Location = new System.Drawing.Point(250, 555);
            this.chkUebersichtCMPruefen.Name = "chkUebersichtCMPruefen";
            this.chkUebersichtCMPruefen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkUebersichtCMPruefen.Properties.Appearance.Options.UseBackColor = true;
            this.chkUebersichtCMPruefen.Properties.Caption = "CM überprüfen";
            this.chkUebersichtCMPruefen.Size = new System.Drawing.Size(111, 19);
            this.chkUebersichtCMPruefen.TabIndex = 3;
            // 
            // docBericht
            // 
            this.docBericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.docBericht.Context = "FA_Situationsbeschreibung_Bericht";
            this.docBericht.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.docBericht.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docBericht.Image = ((System.Drawing.Image)(resources.GetObject("docBericht.Image")));
            this.docBericht.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docBericht.Location = new System.Drawing.Point(5, 551);
            this.docBericht.Name = "docBericht";
            this.docBericht.Size = new System.Drawing.Size(104, 24);
            this.docBericht.TabIndex = 1;
            this.docBericht.Text = "Bericht";
            this.docBericht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docBericht.UseCompatibleTextRendering = true;
            this.docBericht.UseVisualStyleBackColor = false;
            // 
            // panBottomSpacer
            // 
            this.panBottomSpacer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottomSpacer.Location = new System.Drawing.Point(0, 650);
            this.panBottomSpacer.Name = "panBottomSpacer";
            this.panBottomSpacer.Size = new System.Drawing.Size(681, 5);
            this.panBottomSpacer.TabIndex = 2;
            // 
            // lblLetzteAenderung
            // 
            this.lblLetzteAenderung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLetzteAenderung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLetzteAenderung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblLetzteAenderung.Location = new System.Drawing.Point(334, 627);
            this.lblLetzteAenderung.Name = "lblLetzteAenderung";
            this.lblLetzteAenderung.Size = new System.Drawing.Size(93, 24);
            this.lblLetzteAenderung.TabIndex = 3;
            this.lblLetzteAenderung.Text = "Letzte Änderung";
            this.lblLetzteAenderung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLetzteAenderung.UseCompatibleTextRendering = true;
            // 
            // edtLetzteAenderung
            // 
            this.edtLetzteAenderung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLetzteAenderung.DataMember = "LetzteAenderung";
            this.edtLetzteAenderung.DataSource = this.qryFaSituationsbeschreibung;
            this.edtLetzteAenderung.EditValue = null;
            this.edtLetzteAenderung.Location = new System.Drawing.Point(433, 627);
            this.edtLetzteAenderung.Name = "edtLetzteAenderung";
            this.edtLetzteAenderung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLetzteAenderung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLetzteAenderung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLetzteAenderung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLetzteAenderung.Properties.Appearance.Options.UseBackColor = true;
            this.edtLetzteAenderung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLetzteAenderung.Properties.Appearance.Options.UseFont = true;
            this.edtLetzteAenderung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtLetzteAenderung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtLetzteAenderung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtLetzteAenderung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLetzteAenderung.Properties.ShowToday = false;
            this.edtLetzteAenderung.Size = new System.Drawing.Size(86, 24);
            this.edtLetzteAenderung.TabIndex = 4;
            // 
            // btnHistorisieren
            // 
            this.btnHistorisieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorisieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorisieren.Location = new System.Drawing.Point(523, 627);
            this.btnHistorisieren.Name = "btnHistorisieren";
            this.btnHistorisieren.Size = new System.Drawing.Size(85, 24);
            this.btnHistorisieren.TabIndex = 5;
            this.btnHistorisieren.Text = "&Historisieren";
            this.btnHistorisieren.UseCompatibleTextRendering = true;
            this.btnHistorisieren.UseVisualStyleBackColor = false;
            this.btnHistorisieren.Click += new System.EventHandler(this.btnHistorisieren_Click);
            // 
            // btnVerlaufAnzeigen
            // 
            this.btnVerlaufAnzeigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerlaufAnzeigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerlaufAnzeigen.Location = new System.Drawing.Point(612, 627);
            this.btnVerlaufAnzeigen.Name = "btnVerlaufAnzeigen";
            this.btnVerlaufAnzeigen.Size = new System.Drawing.Size(65, 24);
            this.btnVerlaufAnzeigen.TabIndex = 6;
            this.btnVerlaufAnzeigen.Text = "&Verlauf";
            this.btnVerlaufAnzeigen.UseCompatibleTextRendering = true;
            this.btnVerlaufAnzeigen.UseVisualStyleBackColor = false;
            this.btnVerlaufAnzeigen.Click += new System.EventHandler(this.btnVerlaufAnzeigen_Click);
            // 
            // CtlFaSituationsbeschreibung
            // 
            this.ActiveSQLQuery = this.qryFaSituationsbeschreibung;
            this.AutoRefresh = false;
            this.AutoScroll = true;
            this.Controls.Add(this.btnVerlaufAnzeigen);
            this.Controls.Add(this.btnHistorisieren);
            this.Controls.Add(this.edtLetzteAenderung);
            this.Controls.Add(this.lblLetzteAenderung);
            this.Controls.Add(this.tabSituationsbeschreibung);
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.panBottomSpacer);
            this.Name = "CtlFaSituationsbeschreibung";
            this.Size = new System.Drawing.Size(681, 655);
            this.Load += new System.EventHandler(this.CtlFaSituationsbeschreibung_Load);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tabSituationsbeschreibung.ResumeLayout(false);
            this.tpgSichtweisen.ResumeLayout(false);
            this.tblSichtweisen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryFaSituationsbeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenKlientIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenFachstellen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSichtweisenSAR)).EndInit();
            this.tpgRessourcen.ResumeLayout(false);
            this.tblRessourcen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenPersoenlich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenFaehigkeiten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenSozial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenFreunde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenMateriell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenFinanziell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenInstitutionell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRessourcenOrganisation)).EndInit();
            this.tpgLebensbereiche.ResumeLayout(false);
            this.tblLebensbereiche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheSozialversicherung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheLebensplan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheWohnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheFreizeit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheSituationKinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheSozialeKontakte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheGesundheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheFinanzen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheTagesstruktur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLebensbereicheArbeitAusbildung)).EndInit();
            this.tpgUebersicht.ResumeLayout(false);
            this.tblUebersicht.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtThemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtLeistungenAndere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUebersichtDatumDSMerkblatt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUebersichtDatumDSMerkblatt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUebersichtCMPruefen_focus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUebersichtCMPruefen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzteAenderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzteAenderung.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnHistorisieren;
        private KiSS4.Gui.KissButton btnNext;
        private KiSS4.Gui.KissButton btnPrevious;
        private KiSS4.Gui.KissButton btnVerlaufAnzeigen;
        private KiSS4.Gui.KissCheckEdit chkUebersichtCMPruefen;
        private KiSS4.Gui.KissCheckEdit chkUebersichtCMPruefen_focus;
        private KiSS4.Dokument.KissDocumentButton docBericht;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheArbeitAusbildung;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheFinanzen;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheFreizeit;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheGesundheit;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheLebensplan;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheSozialeKontakte;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheSozialversicherung;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheTagesstruktur;
        private KiSS4.Gui.KissRTFEdit edtLebensbereicheWohnen;
        private KiSS4.Gui.KissDateEdit edtLetzteAenderung;
        private KiSS4.Gui.KissRTFEdit edtRessourcenInstitutionell;
        private KiSS4.Gui.KissRTFEdit edtRessourcenMateriell;
        private KiSS4.Gui.KissRTFEdit edtRessourcenPersoenlich;
        private KiSS4.Gui.KissRTFEdit edtRessourcenSozial;
        private KiSS4.Gui.KissRTFEdit edtSichtweisenBemerkungen;
        private KiSS4.Gui.KissRTFEdit edtSichtweisenFachstellen;
        private KiSS4.Gui.KissRTFEdit edtSichtweisenKlient;
        private KiSS4.Gui.KissRTFEdit edtSichtweisenSA;
        private KiSS4.Gui.KissRTFEdit edtUebersichtBemerkungen;
        private KiSS4.Gui.KissRTFEdit edtUebersichtBeschreibung;
        private KiSS4.Gui.KissDateEdit edtUebersichtDatumDSMerkblatt;
        private KiSS4.Gui.KissRTFEdit edtUebersichtLeistungenAndere;
        private KiSS4.Gui.KissRTFEdit edtUebersichtThemen;
        private KiSS4.Gui.KissLabel lblLebensbereicheArbeitAusbildung;
        private KiSS4.Gui.KissLabel lblLebensbereicheFinanzen;
        private KiSS4.Gui.KissLabel lblLebensbereicheFreizeit;
        private KiSS4.Gui.KissLabel lblLebensbereicheGesundheit;
        private KiSS4.Gui.KissLabel lblLebensbereicheLebensplan;
        private KiSS4.Gui.KissLabel lblLebensbereicheSozialeKontakte;
        private KiSS4.Gui.KissLabel lblLebensbereicheSozialversicherung;
        private KiSS4.Gui.KissLabel lblLebensbereicheTagesstruktur;
        private KiSS4.Gui.KissLabel lblLebensbereicheWohnen;
        private KiSS4.Gui.KissLabel lblLetzteAenderung;
        private KiSS4.Gui.KissLabel lblRessourcenFaehigkeiten;
        private KiSS4.Gui.KissLabel lblRessourcenFinanziell;
        private KiSS4.Gui.KissLabel lblRessourcenFreunde;
        private KiSS4.Gui.KissLabel lblRessourcenInstitutionell;
        private KiSS4.Gui.KissLabel lblRessourcenMateriell;
        private KiSS4.Gui.KissLabel lblRessourcenOrganisation;
        private KiSS4.Gui.KissLabel lblRessourcenPersoenlich;
        private KiSS4.Gui.KissLabel lblRessourcenSozial;
        private KiSS4.Gui.KissLabel lblSichtweisenBemerkungen;
        private KiSS4.Gui.KissLabel lblSichtweisenFachstellen;
        private KiSS4.Gui.KissLabel lblSichtweisenKlientIn;
        private KiSS4.Gui.KissLabel lblSichtweisenSAR;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblUebersichtBemerkungen;
        private KiSS4.Gui.KissLabel lblUebersichtBeschreibung;
        private KiSS4.Gui.KissLabel lblUebersichtDatumDSMerkblatt;
        private KiSS4.Gui.KissLabel lblUebersichtLeistungenAndere;
        private KiSS4.Gui.KissLabel lblUebersichtThemen;
        private System.Windows.Forms.Panel panBottomSpacer;
        private Panel panLebensbereichLine;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaSituationsbeschreibung;
        private KiSS4.Gui.KissTabControlEx tabSituationsbeschreibung;
        private SharpLibrary.WinControls.TabPageEx tpgLebensbereiche;
        private SharpLibrary.WinControls.TabPageEx tpgRessourcen;
        private SharpLibrary.WinControls.TabPageEx tpgSichtweisen;
        private SharpLibrary.WinControls.TabPageEx tpgUebersicht;
        private Gui.KissRTFEdit edtLebensbereicheSituationKinder;
        private Gui.KissLabel lblLebensbereicheSituationKinder;
        private TableLayoutPanel tblLebensbereiche;
        private TableLayoutPanel tblUebersicht;
        private TableLayoutPanel tblSichtweisen;
        private TableLayoutPanel tblRessourcen;
    }
}