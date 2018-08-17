namespace KiSS4.Vormundschaft
{
    partial class CtlVmSteuern
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmSteuern));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panDetail = new System.Windows.Forms.Panel();
            this.edtBemerkungen = new KiSS4.Gui.KissRTFEdit();
            this.qryVmSteuern = new KiSS4.DB.SqlQuery(this.components);
            this.grpEntscheid = new KiSS4.Gui.KissGroupBox();
            this.chkAbgelehnt = new KiSS4.Gui.KissCheckEdit();
            this.chkTeilerlass = new KiSS4.Gui.KissCheckEdit();
            this.chkErlass = new KiSS4.Gui.KissCheckEdit();
            this.lblDatumEntscheidErlass = new KiSS4.Gui.KissLabel();
            this.edtDatumEntscheidErlass = new KiSS4.Gui.KissDateEdit();
            this.grpErledigung = new KiSS4.Gui.KissGroupBox();
            this.edtErledigungDurch = new KiSS4.Gui.KissTextEdit();
            this.lblErledigungDurch = new KiSS4.Gui.KissLabel();
            this.chkSteuererklaerungInternErledigt = new KiSS4.Gui.KissCheckEdit();
            this.chkSteuererklaerungExternErledigt = new KiSS4.Gui.KissCheckEdit();
            this.chkArtikel41 = new KiSS4.Gui.KissCheckEdit();
            this.edtEingangDefinitiveVeranlagung = new KiSS4.Gui.KissDateEdit();
            this.lblEingangDefinitiveVeranlagung = new KiSS4.Gui.KissLabel();
            this.edtSteuerjahr = new KiSS4.Gui.KissIntEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.ctlLogischLoeschen = new KiSS4.Common.CtlLogischesLoeschen();
            this.lblDocument = new KiSS4.Gui.KissLabel();
            this.edtSteuererklaerungEingereicht = new KiSS4.Gui.KissDateEdit();
            this.edtDocument = new KiSS4.Dokument.XDokument();
            this.edtFristverlaengerungBeantragt = new KiSS4.Gui.KissDateEdit();
            this.lblFristverlaengerungBeantragt = new KiSS4.Gui.KissLabel();
            this.lblSteuerjahr = new KiSS4.Gui.KissLabel();
            this.lblSteuererklaerungEingereicht = new KiSS4.Gui.KissLabel();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdVmSteuern = new KiSS4.Gui.KissGrid();
            this.grvVmSteuern = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSteuerJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErledigungExtern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErledigungIntern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSteuererklaerungEingereicht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFristverlaengerungBeantragt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingangDefVeranlagung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSearchSteuerJahrVon = new KiSS4.Gui.KissLabel();
            this.lblSearchSteuerJahrBis = new KiSS4.Gui.KissLabel();
            this.edtSearchSteuererklaerungEingereichtBis = new KiSS4.Gui.KissDateEdit();
            this.edtSearchSteuererklaerungEingereichtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSearchSteuererklaerungEingereichtVon = new KiSS4.Gui.KissLabel();
            this.lblSearchSteuererklaerungEingereichtBis = new KiSS4.Gui.KissLabel();
            this.edtSearchBemerkungen = new KiSS4.Gui.KissTextEdit();
            this.lblSearchBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtSearchSteuerJahrVon = new KiSS4.Gui.KissIntEdit();
            this.edtSearchSteuerJahrBis = new KiSS4.Gui.KissIntEdit();
            this.chkSearchSteuererklaerungInternErledigt = new KiSS4.Gui.KissCheckEdit();
            this.chkSearchSteuererklaerungExternErledigt = new KiSS4.Gui.KissCheckEdit();
            this.edtSearchFristverlaengerungBeantragtBis = new KiSS4.Gui.KissDateEdit();
            this.edtSearchFristverlaengerungBeantragtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSearchFristverlaengerungBeantragtVon = new KiSS4.Gui.KissLabel();
            this.lblSearchFristverlaengerungBeantragtBis = new KiSS4.Gui.KissLabel();
            this.edtSearchEingangDefinitiveVeranlagungBis = new KiSS4.Gui.KissDateEdit();
            this.edtSearchEingangDefinitiveVeranlagungVon = new KiSS4.Gui.KissDateEdit();
            this.lblSearchEingangDefinitiveVeranlagungVon = new KiSS4.Gui.KissLabel();
            this.lblSearchEingangDefinitiveVeranlagungBis = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmSteuern)).BeginInit();
            this.grpEntscheid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgelehnt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTeilerlass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErlass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumEntscheidErlass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumEntscheidErlass.Properties)).BeginInit();
            this.grpErledigung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtErledigungDurch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErledigungDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSteuererklaerungInternErledigt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSteuererklaerungExternErledigt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArtikel41.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangDefinitiveVeranlagung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangDefinitiveVeranlagung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSteuerjahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSteuererklaerungEingereicht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFristverlaengerungBeantragt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFristverlaengerungBeantragt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSteuerjahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSteuererklaerungEingereicht)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmSteuern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmSteuern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuerJahrVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuerJahrBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuererklaerungEingereichtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuererklaerungEingereichtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuererklaerungEingereichtVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuererklaerungEingereichtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuerJahrVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuerJahrBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSteuererklaerungInternErledigt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSteuererklaerungExternErledigt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchFristverlaengerungBeantragtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchFristverlaengerungBeantragtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchFristverlaengerungBeantragtVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchFristverlaengerungBeantragtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchEingangDefinitiveVeranlagungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchEingangDefinitiveVeranlagungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchEingangDefinitiveVeranlagungVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchEingangDefinitiveVeranlagungBis)).BeginInit();
            this.SuspendLayout();
            // 
            // radGrpDeleted
            // 
            this.radGrpDeleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.radGrpDeleted.Location = new System.Drawing.Point(450, 100);
            this.radGrpDeleted.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.Appearance.Options.UseBackColor = true;
            this.radGrpDeleted.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.radGrpDeleted.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.radGrpDeleted.TabIndex = 21;
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(715, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 30);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(739, 249);
            this.tabControlSearch.TabIndex = 1;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdVmSteuern);
            this.tpgListe.Size = new System.Drawing.Size(727, 211);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSearchEingangDefinitiveVeranlagungBis);
            this.tpgSuchen.Controls.Add(this.edtSearchEingangDefinitiveVeranlagungVon);
            this.tpgSuchen.Controls.Add(this.lblSearchEingangDefinitiveVeranlagungVon);
            this.tpgSuchen.Controls.Add(this.lblSearchEingangDefinitiveVeranlagungBis);
            this.tpgSuchen.Controls.Add(this.edtSearchFristverlaengerungBeantragtBis);
            this.tpgSuchen.Controls.Add(this.edtSearchFristverlaengerungBeantragtVon);
            this.tpgSuchen.Controls.Add(this.lblSearchFristverlaengerungBeantragtVon);
            this.tpgSuchen.Controls.Add(this.lblSearchFristverlaengerungBeantragtBis);
            this.tpgSuchen.Controls.Add(this.chkSearchSteuererklaerungInternErledigt);
            this.tpgSuchen.Controls.Add(this.chkSearchSteuererklaerungExternErledigt);
            this.tpgSuchen.Controls.Add(this.edtSearchSteuerJahrBis);
            this.tpgSuchen.Controls.Add(this.edtSearchSteuerJahrVon);
            this.tpgSuchen.Controls.Add(this.edtSearchBemerkungen);
            this.tpgSuchen.Controls.Add(this.lblSearchBemerkungen);
            this.tpgSuchen.Controls.Add(this.edtSearchSteuererklaerungEingereichtBis);
            this.tpgSuchen.Controls.Add(this.edtSearchSteuererklaerungEingereichtVon);
            this.tpgSuchen.Controls.Add(this.lblSearchSteuererklaerungEingereichtVon);
            this.tpgSuchen.Controls.Add(this.lblSearchSteuererklaerungEingereichtBis);
            this.tpgSuchen.Controls.Add(this.lblSearchSteuerJahrVon);
            this.tpgSuchen.Controls.Add(this.lblSearchSteuerJahrBis);
            this.tpgSuchen.Size = new System.Drawing.Size(727, 211);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.radGrpDeleted, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchSteuerJahrBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchSteuerJahrVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchSteuererklaerungEingereichtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchSteuererklaerungEingereichtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchSteuererklaerungEingereichtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchSteuererklaerungEingereichtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchSteuerJahrVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchSteuerJahrBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSearchSteuererklaerungExternErledigt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSearchSteuererklaerungInternErledigt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchFristverlaengerungBeantragtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchFristverlaengerungBeantragtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchFristverlaengerungBeantragtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchFristverlaengerungBeantragtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchEingangDefinitiveVeranlagungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSearchEingangDefinitiveVeranlagungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchEingangDefinitiveVeranlagungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSearchEingangDefinitiveVeranlagungBis, 0);
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.edtBemerkungen);
            this.panDetail.Controls.Add(this.grpEntscheid);
            this.panDetail.Controls.Add(this.grpErledigung);
            this.panDetail.Controls.Add(this.chkArtikel41);
            this.panDetail.Controls.Add(this.edtEingangDefinitiveVeranlagung);
            this.panDetail.Controls.Add(this.lblEingangDefinitiveVeranlagung);
            this.panDetail.Controls.Add(this.edtSteuerjahr);
            this.panDetail.Controls.Add(this.lblBemerkungen);
            this.panDetail.Controls.Add(this.ctlLogischLoeschen);
            this.panDetail.Controls.Add(this.lblDocument);
            this.panDetail.Controls.Add(this.edtSteuererklaerungEingereicht);
            this.panDetail.Controls.Add(this.edtDocument);
            this.panDetail.Controls.Add(this.edtFristverlaengerungBeantragt);
            this.panDetail.Controls.Add(this.lblFristverlaengerungBeantragt);
            this.panDetail.Controls.Add(this.lblSteuerjahr);
            this.panDetail.Controls.Add(this.lblSteuererklaerungEingereicht);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetail.Enabled = false;
            this.panDetail.Location = new System.Drawing.Point(0, 279);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(739, 390);
            this.panDetail.TabIndex = 2;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.BackColor = System.Drawing.Color.White;
            this.edtBemerkungen.DataSource = this.qryVmSteuern;
            this.edtBemerkungen.EditValue = ((object)(resources.GetObject("edtBemerkungen.EditValue")));
            this.edtBemerkungen.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkungen.Location = new System.Drawing.Point(184, 197);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Size = new System.Drawing.Size(513, 125);
            this.edtBemerkungen.TabIndex = 14;
            // 
            // qryVmSteuern
            // 
            this.qryVmSteuern.CanDelete = true;
            this.qryVmSteuern.CanInsert = true;
            this.qryVmSteuern.CanUpdate = true;
            this.qryVmSteuern.HostControl = this;
            this.qryVmSteuern.SelectStatement = resources.GetString("qryVmSteuern.SelectStatement");
            this.qryVmSteuern.TableName = "VmSteuern";
            this.qryVmSteuern.AfterFill += new System.EventHandler(this.qryVmSteuern_AfterFill);
            this.qryVmSteuern.AfterInsert += new System.EventHandler(this.qryVmSteuern_AfterInsert);
            this.qryVmSteuern.BeforePost += new System.EventHandler(this.qryVmSteuern_BeforePost);
            this.qryVmSteuern.PositionChanged += new System.EventHandler(this.qryVmSteuern_PositionChanged);
            // 
            // grpEntscheid
            // 
            this.grpEntscheid.Controls.Add(this.chkAbgelehnt);
            this.grpEntscheid.Controls.Add(this.chkTeilerlass);
            this.grpEntscheid.Controls.Add(this.chkErlass);
            this.grpEntscheid.Controls.Add(this.lblDatumEntscheidErlass);
            this.grpEntscheid.Controls.Add(this.edtDatumEntscheidErlass);
            this.grpEntscheid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpEntscheid.Location = new System.Drawing.Point(360, 120);
            this.grpEntscheid.Name = "grpEntscheid";
            this.grpEntscheid.Size = new System.Drawing.Size(337, 71);
            this.grpEntscheid.TabIndex = 10;
            this.grpEntscheid.TabStop = false;
            this.grpEntscheid.Text = "Entscheid";
            // 
            // chkAbgelehnt
            // 
            this.chkAbgelehnt.DataSource = this.qryVmSteuern;
            this.chkAbgelehnt.EditValue = false;
            this.chkAbgelehnt.Location = new System.Drawing.Point(184, 44);
            this.chkAbgelehnt.Name = "chkAbgelehnt";
            this.chkAbgelehnt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAbgelehnt.Properties.Appearance.Options.UseBackColor = true;
            this.chkAbgelehnt.Properties.Caption = "Abgelehnt";
            this.chkAbgelehnt.Size = new System.Drawing.Size(80, 19);
            this.chkAbgelehnt.TabIndex = 4;
            // 
            // chkTeilerlass
            // 
            this.chkTeilerlass.DataSource = this.qryVmSteuern;
            this.chkTeilerlass.EditValue = false;
            this.chkTeilerlass.Location = new System.Drawing.Point(98, 44);
            this.chkTeilerlass.Name = "chkTeilerlass";
            this.chkTeilerlass.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkTeilerlass.Properties.Appearance.Options.UseBackColor = true;
            this.chkTeilerlass.Properties.Caption = "Teilerlass";
            this.chkTeilerlass.Size = new System.Drawing.Size(80, 19);
            this.chkTeilerlass.TabIndex = 3;
            // 
            // chkErlass
            // 
            this.chkErlass.DataSource = this.qryVmSteuern;
            this.chkErlass.EditValue = false;
            this.chkErlass.Location = new System.Drawing.Point(12, 44);
            this.chkErlass.Name = "chkErlass";
            this.chkErlass.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkErlass.Properties.Appearance.Options.UseBackColor = true;
            this.chkErlass.Properties.Caption = "Erlass";
            this.chkErlass.Size = new System.Drawing.Size(80, 19);
            this.chkErlass.TabIndex = 2;
            // 
            // lblDatumEntscheidErlass
            // 
            this.lblDatumEntscheidErlass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatumEntscheidErlass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblDatumEntscheidErlass.ForeColor = System.Drawing.Color.Black;
            this.lblDatumEntscheidErlass.Location = new System.Drawing.Point(9, 15);
            this.lblDatumEntscheidErlass.Name = "lblDatumEntscheidErlass";
            this.lblDatumEntscheidErlass.Size = new System.Drawing.Size(210, 24);
            this.lblDatumEntscheidErlass.TabIndex = 0;
            this.lblDatumEntscheidErlass.Text = "Datum Entscheid Steuererlass";
            // 
            // edtDatumEntscheidErlass
            // 
            this.edtDatumEntscheidErlass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDatumEntscheidErlass.DataSource = this.qryVmSteuern;
            this.edtDatumEntscheidErlass.EditValue = null;
            this.edtDatumEntscheidErlass.Location = new System.Drawing.Point(225, 15);
            this.edtDatumEntscheidErlass.Name = "edtDatumEntscheidErlass";
            this.edtDatumEntscheidErlass.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumEntscheidErlass.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumEntscheidErlass.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumEntscheidErlass.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumEntscheidErlass.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtDatumEntscheidErlass.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumEntscheidErlass.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumEntscheidErlass.Properties.Appearance.Options.UseFont = true;
            this.edtDatumEntscheidErlass.Properties.Appearance.Options.UseForeColor = true;
            this.edtDatumEntscheidErlass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumEntscheidErlass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumEntscheidErlass.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumEntscheidErlass.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumEntscheidErlass.Properties.ShowToday = false;
            this.edtDatumEntscheidErlass.Size = new System.Drawing.Size(100, 24);
            this.edtDatumEntscheidErlass.TabIndex = 1;
            // 
            // grpErledigung
            // 
            this.grpErledigung.Controls.Add(this.edtErledigungDurch);
            this.grpErledigung.Controls.Add(this.lblErledigungDurch);
            this.grpErledigung.Controls.Add(this.chkSteuererklaerungInternErledigt);
            this.grpErledigung.Controls.Add(this.chkSteuererklaerungExternErledigt);
            this.grpErledigung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpErledigung.Location = new System.Drawing.Point(360, 9);
            this.grpErledigung.Name = "grpErledigung";
            this.grpErledigung.Size = new System.Drawing.Size(337, 105);
            this.grpErledigung.TabIndex = 2;
            this.grpErledigung.TabStop = false;
            this.grpErledigung.Text = "Erledigung";
            // 
            // edtErledigungDurch
            // 
            this.edtErledigungDurch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtErledigungDurch.DataSource = this.qryVmSteuern;
            this.edtErledigungDurch.Location = new System.Drawing.Point(127, 70);
            this.edtErledigungDurch.Name = "edtErledigungDurch";
            this.edtErledigungDurch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErledigungDurch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErledigungDurch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErledigungDurch.Properties.Appearance.Options.UseBackColor = true;
            this.edtErledigungDurch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErledigungDurch.Properties.Appearance.Options.UseFont = true;
            this.edtErledigungDurch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErledigungDurch.Size = new System.Drawing.Size(198, 24);
            this.edtErledigungDurch.TabIndex = 3;
            // 
            // lblErledigungDurch
            // 
            this.lblErledigungDurch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblErledigungDurch.ForeColor = System.Drawing.Color.Black;
            this.lblErledigungDurch.Location = new System.Drawing.Point(9, 70);
            this.lblErledigungDurch.Name = "lblErledigungDurch";
            this.lblErledigungDurch.Size = new System.Drawing.Size(112, 24);
            this.lblErledigungDurch.TabIndex = 2;
            this.lblErledigungDurch.Text = "Erledigung durch";
            // 
            // chkSteuererklaerungInternErledigt
            // 
            this.chkSteuererklaerungInternErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSteuererklaerungInternErledigt.DataSource = this.qryVmSteuern;
            this.chkSteuererklaerungInternErledigt.EditValue = false;
            this.chkSteuererklaerungInternErledigt.Location = new System.Drawing.Point(9, 45);
            this.chkSteuererklaerungInternErledigt.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.chkSteuererklaerungInternErledigt.Name = "chkSteuererklaerungInternErledigt";
            this.chkSteuererklaerungInternErledigt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSteuererklaerungInternErledigt.Properties.Appearance.Options.UseBackColor = true;
            this.chkSteuererklaerungInternErledigt.Properties.Caption = "Erledigung Steuererklaerung -- Intern";
            this.chkSteuererklaerungInternErledigt.Size = new System.Drawing.Size(316, 19);
            this.chkSteuererklaerungInternErledigt.TabIndex = 1;
            // 
            // chkSteuererklaerungExternErledigt
            // 
            this.chkSteuererklaerungExternErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSteuererklaerungExternErledigt.DataSource = this.qryVmSteuern;
            this.chkSteuererklaerungExternErledigt.EditValue = false;
            this.chkSteuererklaerungExternErledigt.Location = new System.Drawing.Point(9, 20);
            this.chkSteuererklaerungExternErledigt.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.chkSteuererklaerungExternErledigt.Name = "chkSteuererklaerungExternErledigt";
            this.chkSteuererklaerungExternErledigt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSteuererklaerungExternErledigt.Properties.Appearance.Options.UseBackColor = true;
            this.chkSteuererklaerungExternErledigt.Properties.Caption = "Erledigung Steuererklaerung -- Extern";
            this.chkSteuererklaerungExternErledigt.Size = new System.Drawing.Size(316, 19);
            this.chkSteuererklaerungExternErledigt.TabIndex = 0;
            // 
            // chkArtikel41
            // 
            this.chkArtikel41.DataSource = this.qryVmSteuern;
            this.chkArtikel41.EditValue = false;
            this.chkArtikel41.Location = new System.Drawing.Point(184, 69);
            this.chkArtikel41.Name = "chkArtikel41";
            this.chkArtikel41.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkArtikel41.Properties.Appearance.Options.UseBackColor = true;
            this.chkArtikel41.Properties.Caption = "Artikel 41";
            this.chkArtikel41.Size = new System.Drawing.Size(100, 19);
            this.chkArtikel41.TabIndex = 5;
            // 
            // edtEingangDefinitiveVeranlagung
            // 
            this.edtEingangDefinitiveVeranlagung.DataSource = this.qryVmSteuern;
            this.edtEingangDefinitiveVeranlagung.EditValue = null;
            this.edtEingangDefinitiveVeranlagung.Location = new System.Drawing.Point(184, 124);
            this.edtEingangDefinitiveVeranlagung.Name = "edtEingangDefinitiveVeranlagung";
            this.edtEingangDefinitiveVeranlagung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.Options.UseBackColor = true;
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.Options.UseFont = true;
            this.edtEingangDefinitiveVeranlagung.Properties.Appearance.Options.UseForeColor = true;
            this.edtEingangDefinitiveVeranlagung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtEingangDefinitiveVeranlagung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEingangDefinitiveVeranlagung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtEingangDefinitiveVeranlagung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEingangDefinitiveVeranlagung.Properties.ShowToday = false;
            this.edtEingangDefinitiveVeranlagung.Size = new System.Drawing.Size(100, 24);
            this.edtEingangDefinitiveVeranlagung.TabIndex = 9;
            // 
            // lblEingangDefinitiveVeranlagung
            // 
            this.lblEingangDefinitiveVeranlagung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblEingangDefinitiveVeranlagung.ForeColor = System.Drawing.Color.Black;
            this.lblEingangDefinitiveVeranlagung.Location = new System.Drawing.Point(9, 124);
            this.lblEingangDefinitiveVeranlagung.Name = "lblEingangDefinitiveVeranlagung";
            this.lblEingangDefinitiveVeranlagung.Size = new System.Drawing.Size(169, 24);
            this.lblEingangDefinitiveVeranlagung.TabIndex = 8;
            this.lblEingangDefinitiveVeranlagung.Text = "Eingang definitive Veranlagung";
            // 
            // edtSteuerjahr
            // 
            this.edtSteuerjahr.DataSource = this.qryVmSteuern;
            this.edtSteuerjahr.Location = new System.Drawing.Point(184, 9);
            this.edtSteuerjahr.Name = "edtSteuerjahr";
            this.edtSteuerjahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSteuerjahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSteuerjahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSteuerjahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSteuerjahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSteuerjahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSteuerjahr.Properties.Appearance.Options.UseFont = true;
            this.edtSteuerjahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSteuerjahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSteuerjahr.Properties.DisplayFormat.FormatString = "####";
            this.edtSteuerjahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSteuerjahr.Properties.EditFormat.FormatString = "####";
            this.edtSteuerjahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSteuerjahr.Properties.Mask.EditMask = "####";
            this.edtSteuerjahr.Size = new System.Drawing.Size(100, 24);
            this.edtSteuerjahr.TabIndex = 1;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblBemerkungen.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 199);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(169, 24);
            this.lblBemerkungen.TabIndex = 13;
            this.lblBemerkungen.Text = "Bemerkungen";
            // 
            // ctlLogischLoeschen
            // 
            this.ctlLogischLoeschen.ActiveSQLQuery = this.qryVmSteuern;
            this.ctlLogischLoeschen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlLogischLoeschen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlLogischLoeschen.Location = new System.Drawing.Point(9, 321);
            this.ctlLogischLoeschen.Name = "ctlLogischLoeschen";
            this.ctlLogischLoeschen.Size = new System.Drawing.Size(721, 57);
            this.ctlLogischLoeschen.TabIndex = 17;
            this.ctlLogischLoeschen.RestoreClick += new System.EventHandler(this.btnRestoreDocument_Click);
            // 
            // lblDocument
            // 
            this.lblDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblDocument.ForeColor = System.Drawing.Color.Black;
            this.lblDocument.Location = new System.Drawing.Point(9, 167);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(169, 24);
            this.lblDocument.TabIndex = 11;
            this.lblDocument.Text = "Korrespondenz";
            // 
            // edtSteuererklaerungEingereicht
            // 
            this.edtSteuererklaerungEingereicht.DataSource = this.qryVmSteuern;
            this.edtSteuererklaerungEingereicht.EditValue = null;
            this.edtSteuererklaerungEingereicht.Location = new System.Drawing.Point(184, 39);
            this.edtSteuererklaerungEingereicht.Name = "edtSteuererklaerungEingereicht";
            this.edtSteuererklaerungEingereicht.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSteuererklaerungEingereicht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSteuererklaerungEingereicht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSteuererklaerungEingereicht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSteuererklaerungEingereicht.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSteuererklaerungEingereicht.Properties.Appearance.Options.UseBackColor = true;
            this.edtSteuererklaerungEingereicht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSteuererklaerungEingereicht.Properties.Appearance.Options.UseFont = true;
            this.edtSteuererklaerungEingereicht.Properties.Appearance.Options.UseForeColor = true;
            this.edtSteuererklaerungEingereicht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSteuererklaerungEingereicht.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSteuererklaerungEingereicht.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSteuererklaerungEingereicht.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSteuererklaerungEingereicht.Properties.ShowToday = false;
            this.edtSteuererklaerungEingereicht.Size = new System.Drawing.Size(100, 24);
            this.edtSteuererklaerungEingereicht.TabIndex = 4;
            // 
            // edtDocument
            // 
            this.edtDocument.AllowDrop = true;
            this.edtDocument.Context = null;
            this.edtDocument.DataSource = this.qryVmSteuern;
            this.edtDocument.EditValue = "";
            this.edtDocument.Location = new System.Drawing.Point(184, 167);
            this.edtDocument.Name = "edtDocument";
            this.edtDocument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDocument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDocument.Properties.Appearance.Options.UseFont = true;
            this.edtDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDocument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument importieren")});
            this.edtDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDocument.Properties.ReadOnly = true;
            this.edtDocument.Size = new System.Drawing.Size(124, 24);
            this.edtDocument.TabIndex = 12;
            // 
            // edtFristverlaengerungBeantragt
            // 
            this.edtFristverlaengerungBeantragt.DataSource = this.qryVmSteuern;
            this.edtFristverlaengerungBeantragt.EditValue = null;
            this.edtFristverlaengerungBeantragt.Location = new System.Drawing.Point(184, 94);
            this.edtFristverlaengerungBeantragt.Name = "edtFristverlaengerungBeantragt";
            this.edtFristverlaengerungBeantragt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFristverlaengerungBeantragt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFristverlaengerungBeantragt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFristverlaengerungBeantragt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFristverlaengerungBeantragt.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtFristverlaengerungBeantragt.Properties.Appearance.Options.UseBackColor = true;
            this.edtFristverlaengerungBeantragt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFristverlaengerungBeantragt.Properties.Appearance.Options.UseFont = true;
            this.edtFristverlaengerungBeantragt.Properties.Appearance.Options.UseForeColor = true;
            this.edtFristverlaengerungBeantragt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtFristverlaengerungBeantragt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFristverlaengerungBeantragt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtFristverlaengerungBeantragt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFristverlaengerungBeantragt.Properties.ShowToday = false;
            this.edtFristverlaengerungBeantragt.Size = new System.Drawing.Size(100, 24);
            this.edtFristverlaengerungBeantragt.TabIndex = 7;
            // 
            // lblFristverlaengerungBeantragt
            // 
            this.lblFristverlaengerungBeantragt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblFristverlaengerungBeantragt.ForeColor = System.Drawing.Color.Black;
            this.lblFristverlaengerungBeantragt.Location = new System.Drawing.Point(9, 94);
            this.lblFristverlaengerungBeantragt.Name = "lblFristverlaengerungBeantragt";
            this.lblFristverlaengerungBeantragt.Size = new System.Drawing.Size(169, 24);
            this.lblFristverlaengerungBeantragt.TabIndex = 6;
            this.lblFristverlaengerungBeantragt.Text = "Fristverlängerung beantragt";
            // 
            // lblSteuerjahr
            // 
            this.lblSteuerjahr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSteuerjahr.ForeColor = System.Drawing.Color.Black;
            this.lblSteuerjahr.Location = new System.Drawing.Point(9, 9);
            this.lblSteuerjahr.Name = "lblSteuerjahr";
            this.lblSteuerjahr.Size = new System.Drawing.Size(169, 24);
            this.lblSteuerjahr.TabIndex = 0;
            this.lblSteuerjahr.Text = "Steuerjahr";
            // 
            // lblSteuererklaerungEingereicht
            // 
            this.lblSteuererklaerungEingereicht.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSteuererklaerungEingereicht.ForeColor = System.Drawing.Color.Black;
            this.lblSteuererklaerungEingereicht.Location = new System.Drawing.Point(9, 39);
            this.lblSteuererklaerungEingereicht.Name = "lblSteuererklaerungEingereicht";
            this.lblSteuererklaerungEingereicht.Size = new System.Drawing.Size(169, 24);
            this.lblSteuererklaerungEingereicht.TabIndex = 3;
            this.lblSteuererklaerungEingereicht.Text = "Steuererklärung eingereicht";
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(739, 30);
            this.panTitel.TabIndex = 0;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 366;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(695, 19);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Titel";
            // 
            // grdVmSteuern
            // 
            this.grdVmSteuern.DataSource = this.qryVmSteuern;
            this.grdVmSteuern.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVmSteuern.EmbeddedNavigator.Name = "";
            this.grdVmSteuern.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmSteuern.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdVmSteuern.Location = new System.Drawing.Point(0, 0);
            this.grdVmSteuern.MainView = this.grvVmSteuern;
            this.grdVmSteuern.Name = "grdVmSteuern";
            this.grdVmSteuern.Size = new System.Drawing.Size(727, 211);
            this.grdVmSteuern.TabIndex = 1;
            this.grdVmSteuern.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmSteuern});
            // 
            // grvVmSteuern
            // 
            this.grvVmSteuern.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmSteuern.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.Empty.Options.UseFont = true;
            this.grvVmSteuern.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvVmSteuern.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmSteuern.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmSteuern.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmSteuern.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmSteuern.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmSteuern.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmSteuern.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmSteuern.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmSteuern.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmSteuern.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmSteuern.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmSteuern.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmSteuern.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmSteuern.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmSteuern.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmSteuern.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmSteuern.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmSteuern.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmSteuern.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmSteuern.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmSteuern.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmSteuern.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmSteuern.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmSteuern.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmSteuern.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmSteuern.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvVmSteuern.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.OddRow.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.OddRow.Options.UseFont = true;
            this.grvVmSteuern.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmSteuern.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.Row.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.Row.Options.UseFont = true;
            this.grvVmSteuern.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvVmSteuern.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmSteuern.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvVmSteuern.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvVmSteuern.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmSteuern.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvVmSteuern.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmSteuern.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmSteuern.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmSteuern.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSteuerJahr,
            this.colErledigungExtern,
            this.colErledigungIntern,
            this.colSteuererklaerungEingereicht,
            this.colFristverlaengerungBeantragt,
            this.colEingangDefVeranlagung,
            this.colBemerkungen,
            this.colIsDeleted});
            this.grvVmSteuern.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmSteuern.GridControl = this.grdVmSteuern;
            this.grvVmSteuern.Name = "grvVmSteuern";
            this.grvVmSteuern.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvVmSteuern.OptionsBehavior.Editable = false;
            this.grvVmSteuern.OptionsCustomization.AllowFilter = false;
            this.grvVmSteuern.OptionsCustomization.AllowGroup = false;
            this.grvVmSteuern.OptionsFilter.AllowFilterEditor = false;
            this.grvVmSteuern.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmSteuern.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmSteuern.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvVmSteuern.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvVmSteuern.OptionsNavigation.UseTabKey = false;
            this.grvVmSteuern.OptionsPrint.AutoWidth = false;
            this.grvVmSteuern.OptionsPrint.UsePrintStyles = true;
            this.grvVmSteuern.OptionsView.ColumnAutoWidth = false;
            this.grvVmSteuern.OptionsView.ShowDetailButtons = false;
            this.grvVmSteuern.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmSteuern.OptionsView.ShowGroupPanel = false;
            this.grvVmSteuern.OptionsView.ShowIndicator = false;
            // 
            // colSteuerJahr
            // 
            this.colSteuerJahr.Caption = "Steuerjahr";
            this.colSteuerJahr.Name = "colSteuerJahr";
            this.colSteuerJahr.Visible = true;
            this.colSteuerJahr.VisibleIndex = 0;
            // 
            // colErledigungExtern
            // 
            this.colErledigungExtern.Caption = "Erledigung -- Extern";
            this.colErledigungExtern.Name = "colErledigungExtern";
            this.colErledigungExtern.Visible = true;
            this.colErledigungExtern.VisibleIndex = 1;
            this.colErledigungExtern.Width = 120;
            // 
            // colErledigungIntern
            // 
            this.colErledigungIntern.Caption = "Erledigung -- Intern";
            this.colErledigungIntern.Name = "colErledigungIntern";
            this.colErledigungIntern.Visible = true;
            this.colErledigungIntern.VisibleIndex = 2;
            this.colErledigungIntern.Width = 120;
            // 
            // colSteuererklaerungEingereicht
            // 
            this.colSteuererklaerungEingereicht.Caption = "Steuererkl. eing.";
            this.colSteuererklaerungEingereicht.Name = "colSteuererklaerungEingereicht";
            this.colSteuererklaerungEingereicht.Visible = true;
            this.colSteuererklaerungEingereicht.VisibleIndex = 3;
            this.colSteuererklaerungEingereicht.Width = 120;
            // 
            // colFristverlaengerungBeantragt
            // 
            this.colFristverlaengerungBeantragt.Caption = "Fristverl. beantragt";
            this.colFristverlaengerungBeantragt.Name = "colFristverlaengerungBeantragt";
            this.colFristverlaengerungBeantragt.Visible = true;
            this.colFristverlaengerungBeantragt.VisibleIndex = 4;
            this.colFristverlaengerungBeantragt.Width = 120;
            // 
            // colEingangDefVeranlagung
            // 
            this.colEingangDefVeranlagung.Caption = "Eingang def. Veranl.";
            this.colEingangDefVeranlagung.Name = "colEingangDefVeranlagung";
            this.colEingangDefVeranlagung.Visible = true;
            this.colEingangDefVeranlagung.VisibleIndex = 5;
            this.colEingangDefVeranlagung.Width = 120;
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 6;
            this.colBemerkungen.Width = 200;
            // 
            // colIsDeleted
            // 
            this.colIsDeleted.Caption = "Gelöscht";
            this.colIsDeleted.Name = "colIsDeleted";
            this.colIsDeleted.Visible = true;
            this.colIsDeleted.VisibleIndex = 7;
            // 
            // lblSearchSteuerJahrVon
            // 
            this.lblSearchSteuerJahrVon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchSteuerJahrVon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchSteuerJahrVon.Location = new System.Drawing.Point(30, 40);
            this.lblSearchSteuerJahrVon.Name = "lblSearchSteuerJahrVon";
            this.lblSearchSteuerJahrVon.Size = new System.Drawing.Size(124, 24);
            this.lblSearchSteuerJahrVon.TabIndex = 1;
            this.lblSearchSteuerJahrVon.Text = "Steuerjahr von";
            // 
            // lblSearchSteuerJahrBis
            // 
            this.lblSearchSteuerJahrBis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchSteuerJahrBis.ForeColor = System.Drawing.Color.Black;
            this.lblSearchSteuerJahrBis.Location = new System.Drawing.Point(277, 40);
            this.lblSearchSteuerJahrBis.Name = "lblSearchSteuerJahrBis";
            this.lblSearchSteuerJahrBis.Size = new System.Drawing.Size(27, 24);
            this.lblSearchSteuerJahrBis.TabIndex = 3;
            this.lblSearchSteuerJahrBis.Text = "bis";
            // 
            // edtSearchSteuererklaerungEingereichtBis
            // 
            this.edtSearchSteuererklaerungEingereichtBis.EditValue = "";
            this.edtSearchSteuererklaerungEingereichtBis.Location = new System.Drawing.Point(310, 70);
            this.edtSearchSteuererklaerungEingereichtBis.Name = "edtSearchSteuererklaerungEingereichtBis";
            this.edtSearchSteuererklaerungEingereichtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.Options.UseFont = true;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchSteuererklaerungEingereichtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSearchSteuererklaerungEingereichtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchSteuererklaerungEingereichtBis.Properties.ShowToday = false;
            this.edtSearchSteuererklaerungEingereichtBis.Size = new System.Drawing.Size(100, 24);
            this.edtSearchSteuererklaerungEingereichtBis.TabIndex = 8;
            // 
            // edtSearchSteuererklaerungEingereichtVon
            // 
            this.edtSearchSteuererklaerungEingereichtVon.EditValue = null;
            this.edtSearchSteuererklaerungEingereichtVon.Location = new System.Drawing.Point(160, 70);
            this.edtSearchSteuererklaerungEingereichtVon.Name = "edtSearchSteuererklaerungEingereichtVon";
            this.edtSearchSteuererklaerungEingereichtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.Options.UseFont = true;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchSteuererklaerungEingereichtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtSearchSteuererklaerungEingereichtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchSteuererklaerungEingereichtVon.Properties.ShowToday = false;
            this.edtSearchSteuererklaerungEingereichtVon.Size = new System.Drawing.Size(100, 24);
            this.edtSearchSteuererklaerungEingereichtVon.TabIndex = 6;
            // 
            // lblSearchSteuererklaerungEingereichtVon
            // 
            this.lblSearchSteuererklaerungEingereichtVon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchSteuererklaerungEingereichtVon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchSteuererklaerungEingereichtVon.Location = new System.Drawing.Point(30, 70);
            this.lblSearchSteuererklaerungEingereichtVon.Name = "lblSearchSteuererklaerungEingereichtVon";
            this.lblSearchSteuererklaerungEingereichtVon.Size = new System.Drawing.Size(124, 24);
            this.lblSearchSteuererklaerungEingereichtVon.TabIndex = 5;
            this.lblSearchSteuererklaerungEingereichtVon.Text = "Steuererkl. eingereicht";
            // 
            // lblSearchSteuererklaerungEingereichtBis
            // 
            this.lblSearchSteuererklaerungEingereichtBis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchSteuererklaerungEingereichtBis.ForeColor = System.Drawing.Color.Black;
            this.lblSearchSteuererklaerungEingereichtBis.Location = new System.Drawing.Point(277, 70);
            this.lblSearchSteuererklaerungEingereichtBis.Name = "lblSearchSteuererklaerungEingereichtBis";
            this.lblSearchSteuererklaerungEingereichtBis.Size = new System.Drawing.Size(27, 24);
            this.lblSearchSteuererklaerungEingereichtBis.TabIndex = 7;
            this.lblSearchSteuererklaerungEingereichtBis.Text = "bis";
            // 
            // edtSearchBemerkungen
            // 
            this.edtSearchBemerkungen.Location = new System.Drawing.Point(160, 160);
            this.edtSearchBemerkungen.Name = "edtSearchBemerkungen";
            this.edtSearchBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtSearchBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchBemerkungen.Size = new System.Drawing.Size(250, 24);
            this.edtSearchBemerkungen.TabIndex = 18;
            // 
            // lblSearchBemerkungen
            // 
            this.lblSearchBemerkungen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchBemerkungen.ForeColor = System.Drawing.Color.Black;
            this.lblSearchBemerkungen.Location = new System.Drawing.Point(30, 160);
            this.lblSearchBemerkungen.Name = "lblSearchBemerkungen";
            this.lblSearchBemerkungen.Size = new System.Drawing.Size(124, 24);
            this.lblSearchBemerkungen.TabIndex = 17;
            this.lblSearchBemerkungen.Text = "Bemerkungen";
            // 
            // edtSearchSteuerJahrVon
            // 
            this.edtSearchSteuerJahrVon.Location = new System.Drawing.Point(160, 40);
            this.edtSearchSteuerJahrVon.Name = "edtSearchSteuerJahrVon";
            this.edtSearchSteuerJahrVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchSteuerJahrVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchSteuerJahrVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchSteuerJahrVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchSteuerJahrVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchSteuerJahrVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchSteuerJahrVon.Properties.Appearance.Options.UseFont = true;
            this.edtSearchSteuerJahrVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchSteuerJahrVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchSteuerJahrVon.Properties.DisplayFormat.FormatString = "####";
            this.edtSearchSteuerJahrVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSearchSteuerJahrVon.Properties.EditFormat.FormatString = "####";
            this.edtSearchSteuerJahrVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSearchSteuerJahrVon.Properties.Mask.EditMask = "####";
            this.edtSearchSteuerJahrVon.Size = new System.Drawing.Size(100, 24);
            this.edtSearchSteuerJahrVon.TabIndex = 2;
            // 
            // edtSearchSteuerJahrBis
            // 
            this.edtSearchSteuerJahrBis.Location = new System.Drawing.Point(310, 40);
            this.edtSearchSteuerJahrBis.Name = "edtSearchSteuerJahrBis";
            this.edtSearchSteuerJahrBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchSteuerJahrBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchSteuerJahrBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchSteuerJahrBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchSteuerJahrBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchSteuerJahrBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchSteuerJahrBis.Properties.Appearance.Options.UseFont = true;
            this.edtSearchSteuerJahrBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSearchSteuerJahrBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchSteuerJahrBis.Properties.DisplayFormat.FormatString = "####";
            this.edtSearchSteuerJahrBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSearchSteuerJahrBis.Properties.EditFormat.FormatString = "####";
            this.edtSearchSteuerJahrBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSearchSteuerJahrBis.Properties.Mask.EditMask = "####";
            this.edtSearchSteuerJahrBis.Size = new System.Drawing.Size(100, 24);
            this.edtSearchSteuerJahrBis.TabIndex = 4;
            // 
            // chkSearchSteuererklaerungInternErledigt
            // 
            this.chkSearchSteuererklaerungInternErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchSteuererklaerungInternErledigt.EditValue = false;
            this.chkSearchSteuererklaerungInternErledigt.Location = new System.Drawing.Point(450, 68);
            this.chkSearchSteuererklaerungInternErledigt.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.chkSearchSteuererklaerungInternErledigt.Name = "chkSearchSteuererklaerungInternErledigt";
            this.chkSearchSteuererklaerungInternErledigt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSearchSteuererklaerungInternErledigt.Properties.Appearance.Options.UseBackColor = true;
            this.chkSearchSteuererklaerungInternErledigt.Properties.Caption = "Erledigung Steuererkl. -- Intern";
            this.chkSearchSteuererklaerungInternErledigt.Size = new System.Drawing.Size(181, 19);
            this.chkSearchSteuererklaerungInternErledigt.TabIndex = 20;
            // 
            // chkSearchSteuererklaerungExternErledigt
            // 
            this.chkSearchSteuererklaerungExternErledigt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchSteuererklaerungExternErledigt.EditValue = false;
            this.chkSearchSteuererklaerungExternErledigt.Location = new System.Drawing.Point(450, 44);
            this.chkSearchSteuererklaerungExternErledigt.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.chkSearchSteuererklaerungExternErledigt.Name = "chkSearchSteuererklaerungExternErledigt";
            this.chkSearchSteuererklaerungExternErledigt.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSearchSteuererklaerungExternErledigt.Properties.Appearance.Options.UseBackColor = true;
            this.chkSearchSteuererklaerungExternErledigt.Properties.Caption = "Erledigung Steuererkl. -- Extern";
            this.chkSearchSteuererklaerungExternErledigt.Size = new System.Drawing.Size(181, 19);
            this.chkSearchSteuererklaerungExternErledigt.TabIndex = 19;
            // 
            // edtSearchFristverlaengerungBeantragtBis
            // 
            this.edtSearchFristverlaengerungBeantragtBis.EditValue = "";
            this.edtSearchFristverlaengerungBeantragtBis.Location = new System.Drawing.Point(310, 100);
            this.edtSearchFristverlaengerungBeantragtBis.Name = "edtSearchFristverlaengerungBeantragtBis";
            this.edtSearchFristverlaengerungBeantragtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.Options.UseFont = true;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchFristverlaengerungBeantragtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSearchFristverlaengerungBeantragtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchFristverlaengerungBeantragtBis.Properties.ShowToday = false;
            this.edtSearchFristverlaengerungBeantragtBis.Size = new System.Drawing.Size(100, 24);
            this.edtSearchFristverlaengerungBeantragtBis.TabIndex = 12;
            // 
            // edtSearchFristverlaengerungBeantragtVon
            // 
            this.edtSearchFristverlaengerungBeantragtVon.EditValue = null;
            this.edtSearchFristverlaengerungBeantragtVon.Location = new System.Drawing.Point(160, 100);
            this.edtSearchFristverlaengerungBeantragtVon.Name = "edtSearchFristverlaengerungBeantragtVon";
            this.edtSearchFristverlaengerungBeantragtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.Options.UseFont = true;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchFristverlaengerungBeantragtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSearchFristverlaengerungBeantragtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchFristverlaengerungBeantragtVon.Properties.ShowToday = false;
            this.edtSearchFristverlaengerungBeantragtVon.Size = new System.Drawing.Size(100, 24);
            this.edtSearchFristverlaengerungBeantragtVon.TabIndex = 10;
            // 
            // lblSearchFristverlaengerungBeantragtVon
            // 
            this.lblSearchFristverlaengerungBeantragtVon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchFristverlaengerungBeantragtVon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchFristverlaengerungBeantragtVon.Location = new System.Drawing.Point(30, 100);
            this.lblSearchFristverlaengerungBeantragtVon.Name = "lblSearchFristverlaengerungBeantragtVon";
            this.lblSearchFristverlaengerungBeantragtVon.Size = new System.Drawing.Size(124, 24);
            this.lblSearchFristverlaengerungBeantragtVon.TabIndex = 9;
            this.lblSearchFristverlaengerungBeantragtVon.Text = "Fristverl. beantragt";
            // 
            // lblSearchFristverlaengerungBeantragtBis
            // 
            this.lblSearchFristverlaengerungBeantragtBis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchFristverlaengerungBeantragtBis.ForeColor = System.Drawing.Color.Black;
            this.lblSearchFristverlaengerungBeantragtBis.Location = new System.Drawing.Point(277, 100);
            this.lblSearchFristverlaengerungBeantragtBis.Name = "lblSearchFristverlaengerungBeantragtBis";
            this.lblSearchFristverlaengerungBeantragtBis.Size = new System.Drawing.Size(27, 24);
            this.lblSearchFristverlaengerungBeantragtBis.TabIndex = 11;
            this.lblSearchFristverlaengerungBeantragtBis.Text = "bis";
            // 
            // edtSearchEingangDefinitiveVeranlagungBis
            // 
            this.edtSearchEingangDefinitiveVeranlagungBis.EditValue = "";
            this.edtSearchEingangDefinitiveVeranlagungBis.Location = new System.Drawing.Point(310, 130);
            this.edtSearchEingangDefinitiveVeranlagungBis.Name = "edtSearchEingangDefinitiveVeranlagungBis";
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.Options.UseFont = true;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchEingangDefinitiveVeranlagungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchEingangDefinitiveVeranlagungBis.Properties.ShowToday = false;
            this.edtSearchEingangDefinitiveVeranlagungBis.Size = new System.Drawing.Size(100, 24);
            this.edtSearchEingangDefinitiveVeranlagungBis.TabIndex = 16;
            // 
            // edtSearchEingangDefinitiveVeranlagungVon
            // 
            this.edtSearchEingangDefinitiveVeranlagungVon.EditValue = null;
            this.edtSearchEingangDefinitiveVeranlagungVon.Location = new System.Drawing.Point(160, 130);
            this.edtSearchEingangDefinitiveVeranlagungVon.Name = "edtSearchEingangDefinitiveVeranlagungVon";
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.Options.UseFont = true;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Appearance.Options.UseForeColor = true;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSearchEingangDefinitiveVeranlagungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSearchEingangDefinitiveVeranlagungVon.Properties.ShowToday = false;
            this.edtSearchEingangDefinitiveVeranlagungVon.Size = new System.Drawing.Size(100, 24);
            this.edtSearchEingangDefinitiveVeranlagungVon.TabIndex = 14;
            // 
            // lblSearchEingangDefinitiveVeranlagungVon
            // 
            this.lblSearchEingangDefinitiveVeranlagungVon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchEingangDefinitiveVeranlagungVon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchEingangDefinitiveVeranlagungVon.Location = new System.Drawing.Point(30, 130);
            this.lblSearchEingangDefinitiveVeranlagungVon.Name = "lblSearchEingangDefinitiveVeranlagungVon";
            this.lblSearchEingangDefinitiveVeranlagungVon.Size = new System.Drawing.Size(124, 24);
            this.lblSearchEingangDefinitiveVeranlagungVon.TabIndex = 13;
            this.lblSearchEingangDefinitiveVeranlagungVon.Text = "Eingang def. Veranl.";
            // 
            // lblSearchEingangDefinitiveVeranlagungBis
            // 
            this.lblSearchEingangDefinitiveVeranlagungBis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblSearchEingangDefinitiveVeranlagungBis.ForeColor = System.Drawing.Color.Black;
            this.lblSearchEingangDefinitiveVeranlagungBis.Location = new System.Drawing.Point(277, 130);
            this.lblSearchEingangDefinitiveVeranlagungBis.Name = "lblSearchEingangDefinitiveVeranlagungBis";
            this.lblSearchEingangDefinitiveVeranlagungBis.Size = new System.Drawing.Size(27, 24);
            this.lblSearchEingangDefinitiveVeranlagungBis.TabIndex = 15;
            this.lblSearchEingangDefinitiveVeranlagungBis.Text = "bis";
            // 
            // CtlVmSteuern
            // 
            this.ActiveSQLQuery = this.qryVmSteuern;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.panDetail);
            this.MinimumSize = new System.Drawing.Size(625, 400);
            this.Name = "CtlVmSteuern";
            this.Size = new System.Drawing.Size(739, 669);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            ((System.ComponentModel.ISupportInitialize)(this.radGrpDeleted.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmSteuern)).EndInit();
            this.grpEntscheid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAbgelehnt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTeilerlass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErlass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumEntscheidErlass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumEntscheidErlass.Properties)).EndInit();
            this.grpErledigung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtErledigungDurch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErledigungDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSteuererklaerungInternErledigt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSteuererklaerungExternErledigt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkArtikel41.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangDefinitiveVeranlagung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangDefinitiveVeranlagung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSteuerjahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSteuererklaerungEingereicht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFristverlaengerungBeantragt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFristverlaengerungBeantragt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSteuerjahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSteuererklaerungEingereicht)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmSteuern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmSteuern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuerJahrVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuerJahrBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuererklaerungEingereichtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuererklaerungEingereichtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuererklaerungEingereichtVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchSteuererklaerungEingereichtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuerJahrVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchSteuerJahrBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSteuererklaerungInternErledigt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchSteuererklaerungExternErledigt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchFristverlaengerungBeantragtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchFristverlaengerungBeantragtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchFristverlaengerungBeantragtVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchFristverlaengerungBeantragtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchEingangDefinitiveVeranlagungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSearchEingangDefinitiveVeranlagungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchEingangDefinitiveVeranlagungVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSearchEingangDefinitiveVeranlagungBis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panDetail;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private Gui.KissLabel lblTitel;
        private Gui.KissGrid grdVmSteuern;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmSteuern;
        private Gui.KissLabel lblSearchSteuerJahrVon;
        private Gui.KissLabel lblSearchSteuerJahrBis;
        private Gui.KissDateEdit edtSearchSteuererklaerungEingereichtBis;
        private Gui.KissDateEdit edtSearchSteuererklaerungEingereichtVon;
        private Gui.KissLabel lblSearchSteuererklaerungEingereichtVon;
        private Gui.KissLabel lblSearchSteuererklaerungEingereichtBis;
        private Gui.KissLabel lblSteuererklaerungEingereicht;
        private Gui.KissLabel lblDocument;
        private Gui.KissDateEdit edtSteuererklaerungEingereicht;
        private Dokument.XDokument edtDocument;
        private Gui.KissDateEdit edtFristverlaengerungBeantragt;
        private Gui.KissLabel lblFristverlaengerungBeantragt;
        private Gui.KissLabel lblSteuerjahr;
        private DB.SqlQuery qryVmSteuern;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
        private Common.CtlLogischesLoeschen ctlLogischLoeschen;
        private Gui.KissLabel lblBemerkungen;
        private Gui.KissTextEdit edtSearchBemerkungen;
        private Gui.KissLabel lblSearchBemerkungen;
        private Gui.KissIntEdit edtSteuerjahr;
        private Gui.KissDateEdit edtEingangDefinitiveVeranlagung;
        private Gui.KissLabel lblEingangDefinitiveVeranlagung;
        private Gui.KissCheckEdit chkArtikel41;
        private Gui.KissGroupBox grpErledigung;
        private Gui.KissTextEdit edtErledigungDurch;
        private Gui.KissLabel lblErledigungDurch;
        private Gui.KissCheckEdit chkSteuererklaerungInternErledigt;
        private Gui.KissCheckEdit chkSteuererklaerungExternErledigt;
        private Gui.KissGroupBox grpEntscheid;
        private Gui.KissLabel lblDatumEntscheidErlass;
        private Gui.KissDateEdit edtDatumEntscheidErlass;
        private Gui.KissCheckEdit chkAbgelehnt;
        private Gui.KissCheckEdit chkTeilerlass;
        private Gui.KissCheckEdit chkErlass;
        private Gui.KissRTFEdit edtBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colSteuerJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colErledigungExtern;
        private DevExpress.XtraGrid.Columns.GridColumn colErledigungIntern;
        private DevExpress.XtraGrid.Columns.GridColumn colSteuererklaerungEingereicht;
        private DevExpress.XtraGrid.Columns.GridColumn colFristverlaengerungBeantragt;
        private DevExpress.XtraGrid.Columns.GridColumn colEingangDefVeranlagung;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private Gui.KissIntEdit edtSearchSteuerJahrBis;
        private Gui.KissIntEdit edtSearchSteuerJahrVon;
        private Gui.KissCheckEdit chkSearchSteuererklaerungInternErledigt;
        private Gui.KissCheckEdit chkSearchSteuererklaerungExternErledigt;
        private Gui.KissDateEdit edtSearchFristverlaengerungBeantragtBis;
        private Gui.KissDateEdit edtSearchFristverlaengerungBeantragtVon;
        private Gui.KissLabel lblSearchFristverlaengerungBeantragtVon;
        private Gui.KissLabel lblSearchFristverlaengerungBeantragtBis;
        private Gui.KissDateEdit edtSearchEingangDefinitiveVeranlagungBis;
        private Gui.KissDateEdit edtSearchEingangDefinitiveVeranlagungVon;
        private Gui.KissLabel lblSearchEingangDefinitiveVeranlagungVon;
        private Gui.KissLabel lblSearchEingangDefinitiveVeranlagungBis;
    }
}
