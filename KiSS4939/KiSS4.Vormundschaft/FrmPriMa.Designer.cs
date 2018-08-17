using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Vormundschaft
{
    partial class FrmPriMa
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPriMa));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryPriMa = new KiSS4.DB.SqlQuery(this.components);
            this.qryAdresse = new KiSS4.DB.SqlQuery(this.components);
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.edtPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtNummer = new KiSS4.Gui.KissTextEdit();
            this.edtAdressZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblAdressZusatz = new KiSS4.Gui.KissLabel();
            this.lblPostfach = new KiSS4.Gui.KissLabel();
            this.lblPLZOrt = new KiSS4.Gui.KissLabel();
            this.lblLandCode = new KiSS4.Gui.KissLabel();
            this.lblStrasseNr = new KiSS4.Gui.KissLabel();
            this.edtVmPriMaID = new KiSS4.Gui.KissTextEdit();
            this.lblVmPriMaID = new KiSS4.Gui.KissLabel();
            this.edtSprachCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtMobilTel = new KiSS4.Gui.KissTextEdit();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon_G = new KiSS4.Gui.KissTextEdit();
            this.edtTelefon_P = new KiSS4.Gui.KissTextEdit();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.lblSpracheCode = new KiSS4.Gui.KissLabel();
            this.lblTelefon_P = new KiSS4.Gui.KissLabel();
            this.lblTelefon_G = new KiSS4.Gui.KissLabel();
            this.lblMobilTel = new KiSS4.Gui.KissLabel();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.lblNameVorname = new KiSS4.Gui.KissLabel();
            this.lblBemerkungRTF = new KiSS4.Gui.KissLabel();
            this.edtTitel = new KiSS4.Gui.KissTextEdit();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtBankKontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtBankName = new KiSS4.Gui.KissTextEdit();
            this.lblBankName = new KiSS4.Gui.KissLabel();
            this.lblBankKontoNr = new KiSS4.Gui.KissLabel();
            this.edtIsActive = new KiSS4.Gui.KissCheckEdit();
            this.lblVersicherterNr = new KiSS4.Gui.KissLabel();
            this.edtVersichertennummer = new KiSS4.Gui.KissVersichertenNrEdit();
            this.lblGeburt = new KiSS4.Gui.KissLabel();
            this.lblAHVNr = new KiSS4.Gui.KissLabel();
            this.edtGeburtstag = new KiSS4.Gui.KissDateEdit();
            this.edtAHVNr = new KiSS4.Gui.KissTextEdit();
            this.edtPLZOrt = new KiSS4.Common.KissPLZOrt();
            this.edtVmPriMaIDX = new KiSS4.Gui.KissCalcEdit();
            this.lblPriMaNrX = new KiSS4.Gui.KissLabel();
            this.edtOrtX = new KiSS4.Gui.KissTextEdit();
            this.edtPLZX = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseX = new KiSS4.Gui.KissTextEdit();
            this.lblStrasseX = new KiSS4.Gui.KissLabel();
            this.lblPLZX = new KiSS4.Gui.KissLabel();
            this.lblNameX = new KiSS4.Gui.KissLabel();
            this.lblVornameX = new KiSS4.Gui.KissLabel();
            this.edtVornameX = new KiSS4.Gui.KissTextEdit();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.grdVmPriMa = new KiSS4.Gui.KissGrid();
            this.grvVmPriMa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVmPriMaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHausNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryPriMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmPriMaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_G.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_P.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSpracheCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_P)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobilTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungRTF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersicherterNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPriMaNrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornameX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmPriMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmPriMa)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(762, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(786, 228);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdVmPriMa);
            this.tpgListe.Size = new System.Drawing.Size(774, 190);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtVmPriMaIDX);
            this.tpgSuchen.Controls.Add(this.lblPriMaNrX);
            this.tpgSuchen.Controls.Add(this.edtOrtX);
            this.tpgSuchen.Controls.Add(this.edtPLZX);
            this.tpgSuchen.Controls.Add(this.edtStrasseX);
            this.tpgSuchen.Controls.Add(this.lblStrasseX);
            this.tpgSuchen.Controls.Add(this.lblPLZX);
            this.tpgSuchen.Controls.Add(this.lblNameX);
            this.tpgSuchen.Controls.Add(this.lblVornameX);
            this.tpgSuchen.Controls.Add(this.edtVornameX);
            this.tpgSuchen.Controls.Add(this.edtNameX);
            this.tpgSuchen.Size = new System.Drawing.Size(774, 190);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVornameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVornameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPLZX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStrasseX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStrasseX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPLZX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrtX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblPriMaNrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVmPriMaIDX, 0);
            //
            // qryPriMa
            //
            this.qryPriMa.CanDelete = true;
            this.qryPriMa.CanInsert = true;
            this.qryPriMa.CanUpdate = true;
            this.qryPriMa.HostControl = this;
            this.qryPriMa.SelectStatement = resources.GetString("qryPriMa.SelectStatement");
            this.qryPriMa.TableName = "VmPriMa";
            this.qryPriMa.BeforePost += new System.EventHandler(this.qryPriMa_BeforePost);
            this.qryPriMa.PositionChanged += new System.EventHandler(this.qryPriMa_PositionChanged);
            this.qryPriMa.AfterFill += new System.EventHandler(this.qryPriMa_AfterFill);
            this.qryPriMa.AfterInsert += new System.EventHandler(this.qryPriMa_AfterInsert);
            this.qryPriMa.AfterPost += new System.EventHandler(this.qryPriMa_AfterPost);
            this.qryPriMa.AfterDelete += new System.EventHandler(this.qryPriMa_AfterDelete);
            //
            // qryAdresse
            //
            this.qryAdresse.CanUpdate = true;
            this.qryAdresse.HostControl = this;
            this.qryAdresse.TableName = "BaAdresse";
            this.qryAdresse.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryAdresse_ColumnChanged);
            this.qryAdresse.BeforePost += new EventHandler(qryAdresse_BeforePost);
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryPriMa;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(100, 505);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(692, 95);
            this.edtBemerkung.TabIndex = 36;
            //
            // edtPostfach
            //
            this.edtPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPostfach.DataMember = "Postfach";
            this.edtPostfach.DataSource = this.qryAdresse;
            this.edtPostfach.Location = new System.Drawing.Point(100, 348);
            this.edtPostfach.Name = "edtPostfach";
            this.edtPostfach.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfach.Size = new System.Drawing.Size(300, 24);
            this.edtPostfach.TabIndex = 13;
            //
            // edtNummer
            //
            this.edtNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNummer.DataMember = "HausNr";
            this.edtNummer.DataSource = this.qryAdresse;
            this.edtNummer.Location = new System.Drawing.Point(351, 325);
            this.edtNummer.Name = "edtNummer";
            this.edtNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNummer.Properties.Appearance.Options.UseFont = true;
            this.edtNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNummer.Size = new System.Drawing.Size(49, 24);
            this.edtNummer.TabIndex = 11;
            //
            // edtAdressZusatz
            //
            this.edtAdressZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdressZusatz.DataMember = "AdressZusatz";
            this.edtAdressZusatz.DataSource = this.qryAdresse;
            this.edtAdressZusatz.Location = new System.Drawing.Point(100, 302);
            this.edtAdressZusatz.Name = "edtAdressZusatz";
            this.edtAdressZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAdressZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdressZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressZusatz.Size = new System.Drawing.Size(300, 24);
            this.edtAdressZusatz.TabIndex = 8;
            //
            // edtStrasse
            //
            this.edtStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryAdresse;
            this.edtStrasse.Location = new System.Drawing.Point(100, 325);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(252, 24);
            this.edtStrasse.TabIndex = 10;
            //
            // lblAdressZusatz
            //
            this.lblAdressZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdressZusatz.ForeColor = System.Drawing.Color.Black;
            this.lblAdressZusatz.Location = new System.Drawing.Point(8, 302);
            this.lblAdressZusatz.Name = "lblAdressZusatz";
            this.lblAdressZusatz.Size = new System.Drawing.Size(77, 24);
            this.lblAdressZusatz.TabIndex = 7;
            this.lblAdressZusatz.Text = "Zusatz";
            //
            // lblPostfach
            //
            this.lblPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPostfach.ForeColor = System.Drawing.Color.Black;
            this.lblPostfach.Location = new System.Drawing.Point(8, 348);
            this.lblPostfach.Name = "lblPostfach";
            this.lblPostfach.Size = new System.Drawing.Size(77, 24);
            this.lblPostfach.TabIndex = 12;
            this.lblPostfach.Text = "Postfach";
            //
            // lblPLZOrt
            //
            this.lblPLZOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPLZOrt.ForeColor = System.Drawing.Color.Black;
            this.lblPLZOrt.Location = new System.Drawing.Point(8, 371);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(67, 24);
            this.lblPLZOrt.TabIndex = 14;
            this.lblPLZOrt.Text = "PLZ / Ort / Kt";
            //
            // lblLandCode
            //
            this.lblLandCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLandCode.ForeColor = System.Drawing.Color.Black;
            this.lblLandCode.Location = new System.Drawing.Point(8, 394);
            this.lblLandCode.Name = "lblLandCode";
            this.lblLandCode.Size = new System.Drawing.Size(86, 24);
            this.lblLandCode.TabIndex = 16;
            this.lblLandCode.Text = "Land";
            //
            // lblStrasseNr
            //
            this.lblStrasseNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrasseNr.ForeColor = System.Drawing.Color.Black;
            this.lblStrasseNr.Location = new System.Drawing.Point(8, 325);
            this.lblStrasseNr.Name = "lblStrasseNr";
            this.lblStrasseNr.Size = new System.Drawing.Size(87, 24);
            this.lblStrasseNr.TabIndex = 9;
            this.lblStrasseNr.Text = "Strasse / Nr";
            //
            // edtVmPriMaID
            //
            this.edtVmPriMaID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVmPriMaID.DataMember = "VmPriMaID";
            this.edtVmPriMaID.DataSource = this.qryPriMa;
            this.edtVmPriMaID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVmPriMaID.Location = new System.Drawing.Point(300, 242);
            this.edtVmPriMaID.Name = "edtVmPriMaID";
            this.edtVmPriMaID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVmPriMaID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmPriMaID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmPriMaID.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmPriMaID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmPriMaID.Properties.Appearance.Options.UseFont = true;
            this.edtVmPriMaID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVmPriMaID.Properties.ReadOnly = true;
            this.edtVmPriMaID.Size = new System.Drawing.Size(100, 24);
            this.edtVmPriMaID.TabIndex = 3;
            //
            // lblVmPriMaID
            //
            this.lblVmPriMaID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVmPriMaID.ForeColor = System.Drawing.Color.Black;
            this.lblVmPriMaID.Location = new System.Drawing.Point(280, 242);
            this.lblVmPriMaID.Name = "lblVmPriMaID";
            this.lblVmPriMaID.Size = new System.Drawing.Size(18, 24);
            this.lblVmPriMaID.TabIndex = 2;
            this.lblVmPriMaID.Text = "Nr";
            //
            // edtSprachCode
            //
            this.edtSprachCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSprachCode.DataMember = "SprachCode";
            this.edtSprachCode.DataSource = this.qryPriMa;
            this.edtSprachCode.Location = new System.Drawing.Point(527, 364);
            this.edtSprachCode.LOVName = "Sprache";
            this.edtSprachCode.Name = "edtSprachCode";
            this.edtSprachCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSprachCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSprachCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtSprachCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSprachCode.Properties.Appearance.Options.UseFont = true;
            this.edtSprachCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSprachCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSprachCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSprachCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSprachCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSprachCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSprachCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSprachCode.Properties.NullText = "";
            this.edtSprachCode.Properties.ShowFooter = false;
            this.edtSprachCode.Properties.ShowHeader = false;
            this.edtSprachCode.Size = new System.Drawing.Size(265, 24);
            this.edtSprachCode.TabIndex = 36;
            //
            // edtMobilTel
            //
            this.edtMobilTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMobilTel.DataMember = "MobilTel";
            this.edtMobilTel.DataSource = this.qryPriMa;
            this.edtMobilTel.Location = new System.Drawing.Point(527, 288);
            this.edtMobilTel.Name = "edtMobilTel";
            this.edtMobilTel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMobilTel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMobilTel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMobilTel.Properties.Appearance.Options.UseBackColor = true;
            this.edtMobilTel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMobilTel.Properties.Appearance.Options.UseFont = true;
            this.edtMobilTel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMobilTel.Size = new System.Drawing.Size(265, 24);
            this.edtMobilTel.TabIndex = 30;
            //
            // edtEMail
            //
            this.edtEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryPriMa;
            this.edtEMail.Location = new System.Drawing.Point(527, 341);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Size = new System.Drawing.Size(265, 24);
            this.edtEMail.TabIndex = 34;
            //
            // edtFax
            //
            this.edtFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryPriMa;
            this.edtFax.Location = new System.Drawing.Point(527, 318);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Size = new System.Drawing.Size(265, 24);
            this.edtFax.TabIndex = 32;
            //
            // edtTelefon_G
            //
            this.edtTelefon_G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTelefon_G.DataMember = "Telefon_G";
            this.edtTelefon_G.DataSource = this.qryPriMa;
            this.edtTelefon_G.Location = new System.Drawing.Point(527, 265);
            this.edtTelefon_G.Name = "edtTelefon_G";
            this.edtTelefon_G.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon_G.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon_G.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon_G.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon_G.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon_G.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon_G.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon_G.Size = new System.Drawing.Size(265, 24);
            this.edtTelefon_G.TabIndex = 27;
            //
            // edtTelefon_P
            //
            this.edtTelefon_P.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTelefon_P.DataMember = "Telefon_P";
            this.edtTelefon_P.DataSource = this.qryPriMa;
            this.edtTelefon_P.Location = new System.Drawing.Point(527, 242);
            this.edtTelefon_P.Name = "edtTelefon_P";
            this.edtTelefon_P.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefon_P.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon_P.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon_P.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon_P.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon_P.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon_P.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon_P.Size = new System.Drawing.Size(265, 24);
            this.edtTelefon_P.TabIndex = 25;
            //
            // edtVorname
            //
            this.edtVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVorname.DataMember = "Vorname";
            this.edtVorname.DataSource = this.qryPriMa;
            this.edtVorname.Location = new System.Drawing.Point(277, 272);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(123, 24);
            this.edtVorname.TabIndex = 6;
            //
            // edtName
            //
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtName.DataMember = "Name";
            this.edtName.DataSource = this.qryPriMa;
            this.edtName.Location = new System.Drawing.Point(100, 272);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(178, 24);
            this.edtName.TabIndex = 5;
            //
            // lblSpracheCode
            //
            this.lblSpracheCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSpracheCode.ForeColor = System.Drawing.Color.Black;
            this.lblSpracheCode.Location = new System.Drawing.Point(420, 364);
            this.lblSpracheCode.Name = "lblSpracheCode";
            this.lblSpracheCode.Size = new System.Drawing.Size(45, 24);
            this.lblSpracheCode.TabIndex = 35;
            this.lblSpracheCode.Text = "Sprache";
            //
            // lblTelefon_P
            //
            this.lblTelefon_P.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTelefon_P.ForeColor = System.Drawing.Color.Black;
            this.lblTelefon_P.Location = new System.Drawing.Point(420, 242);
            this.lblTelefon_P.Name = "lblTelefon_P";
            this.lblTelefon_P.Size = new System.Drawing.Size(101, 24);
            this.lblTelefon_P.TabIndex = 24;
            this.lblTelefon_P.Text = "Telefon privat";
            //
            // lblTelefon_G
            //
            this.lblTelefon_G.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTelefon_G.ForeColor = System.Drawing.Color.Black;
            this.lblTelefon_G.Location = new System.Drawing.Point(420, 265);
            this.lblTelefon_G.Name = "lblTelefon_G";
            this.lblTelefon_G.Size = new System.Drawing.Size(101, 24);
            this.lblTelefon_G.TabIndex = 26;
            this.lblTelefon_G.Text = "Telefon gesch.";
            //
            // lblMobilTel
            //
            this.lblMobilTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMobilTel.ForeColor = System.Drawing.Color.Black;
            this.lblMobilTel.Location = new System.Drawing.Point(420, 288);
            this.lblMobilTel.Name = "lblMobilTel";
            this.lblMobilTel.Size = new System.Drawing.Size(101, 24);
            this.lblMobilTel.TabIndex = 29;
            this.lblMobilTel.Text = "Telefon mobil";
            //
            // lblFax
            //
            this.lblFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFax.ForeColor = System.Drawing.Color.Black;
            this.lblFax.Location = new System.Drawing.Point(420, 318);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(31, 24);
            this.lblFax.TabIndex = 31;
            this.lblFax.Text = "Fax";
            //
            // lblEMail
            //
            this.lblEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEMail.ForeColor = System.Drawing.Color.Black;
            this.lblEMail.Location = new System.Drawing.Point(420, 341);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(31, 24);
            this.lblEMail.TabIndex = 33;
            this.lblEMail.Text = "EMail";
            //
            // lblNameVorname
            //
            this.lblNameVorname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameVorname.ForeColor = System.Drawing.Color.Black;
            this.lblNameVorname.Location = new System.Drawing.Point(8, 272);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Size = new System.Drawing.Size(87, 24);
            this.lblNameVorname.TabIndex = 4;
            this.lblNameVorname.Text = "Name / Vorname";
            //
            // lblBemerkungRTF
            //
            this.lblBemerkungRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkungRTF.Location = new System.Drawing.Point(8, 505);
            this.lblBemerkungRTF.Name = "lblBemerkungRTF";
            this.lblBemerkungRTF.Size = new System.Drawing.Size(72, 24);
            this.lblBemerkungRTF.TabIndex = 35;
            this.lblBemerkungRTF.Text = "Bemerkung";
            //
            // edtTitel
            //
            this.edtTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTitel.DataMember = "Titel";
            this.edtTitel.DataSource = this.qryPriMa;
            this.edtTitel.Location = new System.Drawing.Point(100, 242);
            this.edtTitel.Name = "edtTitel";
            this.edtTitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTitel.Properties.Appearance.Options.UseFont = true;
            this.edtTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTitel.Size = new System.Drawing.Size(140, 24);
            this.edtTitel.TabIndex = 1;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(8, 242);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(77, 24);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Anrede / Titel";
            //
            // edtBankKontoNr
            //
            this.edtBankKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBankKontoNr.DataMember = "BankKontoNr";
            this.edtBankKontoNr.DataSource = this.qryPriMa;
            this.edtBankKontoNr.Location = new System.Drawing.Point(527, 417);
            this.edtBankKontoNr.Name = "edtBankKontoNr";
            this.edtBankKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtBankKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankKontoNr.Size = new System.Drawing.Size(265, 24);
            this.edtBankKontoNr.TabIndex = 40;
            //
            // edtBankName
            //
            this.edtBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBankName.DataMember = "BankName";
            this.edtBankName.DataSource = this.qryPriMa;
            this.edtBankName.Location = new System.Drawing.Point(527, 394);
            this.edtBankName.Name = "edtBankName";
            this.edtBankName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankName.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankName.Properties.Appearance.Options.UseFont = true;
            this.edtBankName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankName.Size = new System.Drawing.Size(265, 24);
            this.edtBankName.TabIndex = 38;
            //
            // lblBankName
            //
            this.lblBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBankName.ForeColor = System.Drawing.Color.Black;
            this.lblBankName.Location = new System.Drawing.Point(420, 394);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(50, 24);
            this.lblBankName.TabIndex = 37;
            this.lblBankName.Text = "Bank/PC";
            //
            // lblBankKontoNr
            //
            this.lblBankKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBankKontoNr.ForeColor = System.Drawing.Color.Black;
            this.lblBankKontoNr.Location = new System.Drawing.Point(420, 417);
            this.lblBankKontoNr.Name = "lblBankKontoNr";
            this.lblBankKontoNr.Size = new System.Drawing.Size(50, 24);
            this.lblBankKontoNr.TabIndex = 39;
            this.lblBankKontoNr.Text = "Konto-Nr.";
            //
            // edtIsActive
            //
            this.edtIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIsActive.DataMember = "IsActive";
            this.edtIsActive.DataSource = this.qryPriMa;
            this.edtIsActive.Location = new System.Drawing.Point(100, 476);
            this.edtIsActive.Name = "edtIsActive";
            this.edtIsActive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtIsActive.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtIsActive.Properties.Appearance.Options.UseBackColor = true;
            this.edtIsActive.Properties.Appearance.Options.UseFont = true;
            this.edtIsActive.Properties.Caption = "aktiv";
            this.edtIsActive.Size = new System.Drawing.Size(58, 19);
            this.edtIsActive.TabIndex = 23;
            //
            // lblVersicherterNr
            //
            this.lblVersicherterNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersicherterNr.Location = new System.Drawing.Point(8, 446);
            this.lblVersicherterNr.Name = "lblVersicherterNr";
            this.lblVersicherterNr.Size = new System.Drawing.Size(86, 24);
            this.lblVersicherterNr.TabIndex = 21;
            this.lblVersicherterNr.Text = "Versichertennr.";
            this.lblVersicherterNr.UseCompatibleTextRendering = true;
            //
            // edtVersichertennummer
            //
            this.edtVersichertennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVersichertennummer.DataMember = "Versichertennummer";
            this.edtVersichertennummer.DataSource = this.qryPriMa;
            this.edtVersichertennummer.Location = new System.Drawing.Point(100, 446);
            this.edtVersichertennummer.Name = "edtVersichertennummer";
            this.edtVersichertennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersichertennummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersichertennummer.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersichertennummer.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersichertennummer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersichertennummer.Properties.MaxLength = 13;
            this.edtVersichertennummer.Properties.Precision = 0;
            this.edtVersichertennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersichertennummer.Size = new System.Drawing.Size(135, 24);
            this.edtVersichertennummer.TabIndex = 22;
            //
            // lblGeburt
            //
            this.lblGeburt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGeburt.Location = new System.Drawing.Point(258, 423);
            this.lblGeburt.Name = "lblGeburt";
            this.lblGeburt.Size = new System.Drawing.Size(45, 24);
            this.lblGeburt.TabIndex = 19;
            this.lblGeburt.Text = "Geburt";
            this.lblGeburt.UseCompatibleTextRendering = true;
            //
            // lblAHVNr
            //
            this.lblAHVNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAHVNr.Location = new System.Drawing.Point(8, 423);
            this.lblAHVNr.Name = "lblAHVNr";
            this.lblAHVNr.Size = new System.Drawing.Size(86, 24);
            this.lblAHVNr.TabIndex = 17;
            this.lblAHVNr.Text = "AHV-Nr";
            this.lblAHVNr.UseCompatibleTextRendering = true;
            //
            // edtGeburtstag
            //
            this.edtGeburtstag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGeburtstag.DataMember = "Geburtsdatum";
            this.edtGeburtstag.DataSource = this.qryPriMa;
            this.edtGeburtstag.EditValue = null;
            this.edtGeburtstag.Location = new System.Drawing.Point(305, 423);
            this.edtGeburtstag.Name = "edtGeburtstag";
            this.edtGeburtstag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtstag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtstag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtstag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtstag.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtstag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtstag.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtstag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtstag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtstag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtstag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtstag.Properties.ShowToday = false;
            this.edtGeburtstag.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtstag.TabIndex = 20;
            //
            // edtAHVNr
            //
            this.edtAHVNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAHVNr.DataMember = "AHVNummer";
            this.edtAHVNr.DataSource = this.qryPriMa;
            this.edtAHVNr.Location = new System.Drawing.Point(100, 423);
            this.edtAHVNr.Name = "edtAHVNr";
            this.edtAHVNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNr.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNr.Size = new System.Drawing.Size(135, 24);
            this.edtAHVNr.TabIndex = 18;
            //
            // edtPLZOrt
            //
            this.edtPLZOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPLZOrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZOrt.DataSource = this.qryAdresse;
            this.edtPLZOrt.Location = new System.Drawing.Point(100, 371);
            this.edtPLZOrt.Name = "edtPLZOrt";
            this.edtPLZOrt.Size = new System.Drawing.Size(300, 47);
            this.edtPLZOrt.TabIndex = 15;
            //
            // edtVmPriMaIDX
            //
            this.edtVmPriMaIDX.Location = new System.Drawing.Point(102, 160);
            this.edtVmPriMaIDX.Name = "edtVmPriMaIDX";
            this.edtVmPriMaIDX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVmPriMaIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmPriMaIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmPriMaIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmPriMaIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmPriMaIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmPriMaIDX.Properties.Appearance.Options.UseFont = true;
            this.edtVmPriMaIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVmPriMaIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmPriMaIDX.Properties.Mask.EditMask = "##,###,##0.##";
            this.edtVmPriMaIDX.Size = new System.Drawing.Size(95, 24);
            this.edtVmPriMaIDX.TabIndex = 582;
            //
            // lblPriMaNrX
            //
            this.lblPriMaNrX.Location = new System.Drawing.Point(30, 158);
            this.lblPriMaNrX.Name = "lblPriMaNrX";
            this.lblPriMaNrX.Size = new System.Drawing.Size(66, 24);
            this.lblPriMaNrX.TabIndex = 587;
            this.lblPriMaNrX.Text = "PriMa-Nr";
            //
            // edtOrtX
            //
            this.edtOrtX.EditValue = "";
            this.edtOrtX.Location = new System.Drawing.Point(157, 130);
            this.edtOrtX.Name = "edtOrtX";
            this.edtOrtX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrtX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtX.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtX.Properties.Appearance.Options.UseFont = true;
            this.edtOrtX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrtX.Size = new System.Drawing.Size(151, 24);
            this.edtOrtX.TabIndex = 581;
            //
            // edtPLZX
            //
            this.edtPLZX.EditValue = "";
            this.edtPLZX.Location = new System.Drawing.Point(102, 130);
            this.edtPLZX.Name = "edtPLZX";
            this.edtPLZX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZX.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZX.Properties.Appearance.Options.UseFont = true;
            this.edtPLZX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZX.Size = new System.Drawing.Size(56, 24);
            this.edtPLZX.TabIndex = 580;
            //
            // edtStrasseX
            //
            this.edtStrasseX.EditValue = "";
            this.edtStrasseX.Location = new System.Drawing.Point(102, 100);
            this.edtStrasseX.Name = "edtStrasseX";
            this.edtStrasseX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasseX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseX.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseX.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseX.Size = new System.Drawing.Size(206, 24);
            this.edtStrasseX.TabIndex = 579;
            //
            // lblStrasseX
            //
            this.lblStrasseX.Location = new System.Drawing.Point(30, 98);
            this.lblStrasseX.Name = "lblStrasseX";
            this.lblStrasseX.Size = new System.Drawing.Size(66, 24);
            this.lblStrasseX.TabIndex = 586;
            this.lblStrasseX.Text = "Strasse";
            //
            // lblPLZX
            //
            this.lblPLZX.Location = new System.Drawing.Point(30, 128);
            this.lblPLZX.Name = "lblPLZX";
            this.lblPLZX.Size = new System.Drawing.Size(66, 24);
            this.lblPLZX.TabIndex = 585;
            this.lblPLZX.Text = "PLZ / Ort";
            //
            // lblNameX
            //
            this.lblNameX.Location = new System.Drawing.Point(30, 40);
            this.lblNameX.Name = "lblNameX";
            this.lblNameX.Size = new System.Drawing.Size(66, 24);
            this.lblNameX.TabIndex = 584;
            this.lblNameX.Text = "Name";
            //
            // lblVornameX
            //
            this.lblVornameX.Location = new System.Drawing.Point(30, 68);
            this.lblVornameX.Name = "lblVornameX";
            this.lblVornameX.Size = new System.Drawing.Size(66, 24);
            this.lblVornameX.TabIndex = 583;
            this.lblVornameX.Text = "Vorname";
            //
            // edtVornameX
            //
            this.edtVornameX.EditValue = "";
            this.edtVornameX.Location = new System.Drawing.Point(102, 70);
            this.edtVornameX.Name = "edtVornameX";
            this.edtVornameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVornameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVornameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtVornameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVornameX.Properties.Appearance.Options.UseFont = true;
            this.edtVornameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVornameX.Size = new System.Drawing.Size(206, 24);
            this.edtVornameX.TabIndex = 578;
            //
            // edtNameX
            //
            this.edtNameX.EditValue = "";
            this.edtNameX.Location = new System.Drawing.Point(102, 40);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Size = new System.Drawing.Size(206, 24);
            this.edtNameX.TabIndex = 577;
            //
            // grdVmPriMa
            //
            this.grdVmPriMa.DataSource = this.qryPriMa;
            this.grdVmPriMa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVmPriMa.EmbeddedNavigator.Name = "";
            this.grdVmPriMa.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmPriMa.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdVmPriMa.Location = new System.Drawing.Point(0, 0);
            this.grdVmPriMa.MainView = this.grvVmPriMa;
            this.grdVmPriMa.Name = "grdVmPriMa";
            this.grdVmPriMa.Size = new System.Drawing.Size(774, 190);
            this.grdVmPriMa.TabIndex = 1;
            this.grdVmPriMa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmPriMa});
            //
            // grvVmPriMa
            //
            this.grvVmPriMa.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmPriMa.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.Empty.Options.UseFont = true;
            this.grvVmPriMa.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvVmPriMa.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmPriMa.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmPriMa.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmPriMa.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmPriMa.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmPriMa.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmPriMa.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmPriMa.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmPriMa.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmPriMa.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmPriMa.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmPriMa.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmPriMa.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmPriMa.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmPriMa.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmPriMa.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmPriMa.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmPriMa.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmPriMa.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmPriMa.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmPriMa.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmPriMa.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmPriMa.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmPriMa.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmPriMa.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmPriMa.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvVmPriMa.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.OddRow.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.OddRow.Options.UseFont = true;
            this.grvVmPriMa.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmPriMa.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.Row.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.Row.Options.UseFont = true;
            this.grvVmPriMa.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvVmPriMa.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmPriMa.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvVmPriMa.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvVmPriMa.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmPriMa.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvVmPriMa.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmPriMa.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmPriMa.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmPriMa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVmPriMaID,
            this.colName,
            this.colVorname,
            this.colStrasse,
            this.colHausNr,
            this.colPLZ,
            this.colOrt,
            this.colAktiv});
            this.grvVmPriMa.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmPriMa.GridControl = this.grdVmPriMa;
            this.grvVmPriMa.Name = "grvVmPriMa";
            this.grvVmPriMa.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvVmPriMa.OptionsBehavior.Editable = false;
            this.grvVmPriMa.OptionsCustomization.AllowFilter = false;
            this.grvVmPriMa.OptionsCustomization.AllowGroup = false;
            this.grvVmPriMa.OptionsFilter.AllowFilterEditor = false;
            this.grvVmPriMa.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmPriMa.OptionsMenu.EnableColumnMenu = false;
            this.grvVmPriMa.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmPriMa.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvVmPriMa.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvVmPriMa.OptionsNavigation.UseTabKey = false;
            this.grvVmPriMa.OptionsPrint.AutoWidth = false;
            this.grvVmPriMa.OptionsPrint.UsePrintStyles = true;
            this.grvVmPriMa.OptionsView.ColumnAutoWidth = false;
            this.grvVmPriMa.OptionsView.ShowDetailButtons = false;
            this.grvVmPriMa.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmPriMa.OptionsView.ShowGroupPanel = false;
            this.grvVmPriMa.OptionsView.ShowIndicator = false;
            //
            // colVmPriMaID
            //
            this.colVmPriMaID.AppearanceCell.Options.UseTextOptions = true;
            this.colVmPriMaID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colVmPriMaID.Caption = "Nr";
            this.colVmPriMaID.FieldName = "VmPriMaID";
            this.colVmPriMaID.Name = "colVmPriMaID";
            this.colVmPriMaID.Visible = true;
            this.colVmPriMaID.VisibleIndex = 0;
            this.colVmPriMaID.Width = 45;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 166;
            //
            // colVorname
            //
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 2;
            this.colVorname.Width = 98;
            //
            // colStrasse
            //
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 3;
            this.colStrasse.Width = 125;
            //
            // colHausNr
            //
            this.colHausNr.Caption = "Nr.";
            this.colHausNr.FieldName = "HausNr";
            this.colHausNr.Name = "colHausNr";
            this.colHausNr.Visible = true;
            this.colHausNr.VisibleIndex = 4;
            this.colHausNr.Width = 48;
            //
            // colPLZ
            //
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 5;
            this.colPLZ.Width = 60;
            //
            // colOrt
            //
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 6;
            this.colOrt.Width = 152;
            //
            // colAktiv
            //
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "IsActive";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 7;
            this.colAktiv.Width = 40;
            //
            // FrmPriMa
            //
            this.ActiveSQLQuery = this.qryPriMa;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 610);
            this.ClientSize = new System.Drawing.Size(801, 612);
            this.Controls.Add(this.edtPLZOrt);
            this.Controls.Add(this.lblVersicherterNr);
            this.Controls.Add(this.lblGeburt);
            this.Controls.Add(this.edtVersichertennummer);
            this.Controls.Add(this.lblAHVNr);
            this.Controls.Add(this.edtGeburtstag);
            this.Controls.Add(this.edtAHVNr);
            this.Controls.Add(this.edtIsActive);
            this.Controls.Add(this.edtBankKontoNr);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.edtBankName);
            this.Controls.Add(this.lblBankKontoNr);
            this.Controls.Add(this.edtTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.edtPostfach);
            this.Controls.Add(this.lblBemerkungRTF);
            this.Controls.Add(this.edtNummer);
            this.Controls.Add(this.edtAdressZusatz);
            this.Controls.Add(this.edtStrasse);
            this.Controls.Add(this.lblAdressZusatz);
            this.Controls.Add(this.lblPostfach);
            this.Controls.Add(this.lblPLZOrt);
            this.Controls.Add(this.lblLandCode);
            this.Controls.Add(this.lblStrasseNr);
            this.Controls.Add(this.edtVmPriMaID);
            this.Controls.Add(this.lblVmPriMaID);
            this.Controls.Add(this.edtVorname);
            this.Controls.Add(this.edtSprachCode);
            this.Controls.Add(this.edtMobilTel);
            this.Controls.Add(this.edtEMail);
            this.Controls.Add(this.edtFax);
            this.Controls.Add(this.edtTelefon_G);
            this.Controls.Add(this.edtTelefon_P);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.lblSpracheCode);
            this.Controls.Add(this.lblTelefon_P);
            this.Controls.Add(this.lblTelefon_G);
            this.Controls.Add(this.lblMobilTel);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.lblEMail);
            this.Controls.Add(this.lblNameVorname);
            this.Controls.Add(this.edtBemerkung);
            this.Name = "FrmPriMa";
            this.Text = "Private Mandatsträger";
            this.Load += new System.EventHandler(this.FrmPriMa_Load);
            this.Controls.SetChildIndex(this.edtBemerkung, 0);
            this.Controls.SetChildIndex(this.lblNameVorname, 0);
            this.Controls.SetChildIndex(this.lblEMail, 0);
            this.Controls.SetChildIndex(this.lblFax, 0);
            this.Controls.SetChildIndex(this.lblMobilTel, 0);
            this.Controls.SetChildIndex(this.lblTelefon_G, 0);
            this.Controls.SetChildIndex(this.lblTelefon_P, 0);
            this.Controls.SetChildIndex(this.lblSpracheCode, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.edtTelefon_P, 0);
            this.Controls.SetChildIndex(this.edtTelefon_G, 0);
            this.Controls.SetChildIndex(this.edtFax, 0);
            this.Controls.SetChildIndex(this.edtEMail, 0);
            this.Controls.SetChildIndex(this.edtMobilTel, 0);
            this.Controls.SetChildIndex(this.edtSprachCode, 0);
            this.Controls.SetChildIndex(this.edtVorname, 0);
            this.Controls.SetChildIndex(this.lblVmPriMaID, 0);
            this.Controls.SetChildIndex(this.edtVmPriMaID, 0);
            this.Controls.SetChildIndex(this.lblStrasseNr, 0);
            this.Controls.SetChildIndex(this.lblLandCode, 0);
            this.Controls.SetChildIndex(this.lblPLZOrt, 0);
            this.Controls.SetChildIndex(this.lblPostfach, 0);
            this.Controls.SetChildIndex(this.lblAdressZusatz, 0);
            this.Controls.SetChildIndex(this.edtStrasse, 0);
            this.Controls.SetChildIndex(this.edtAdressZusatz, 0);
            this.Controls.SetChildIndex(this.edtNummer, 0);
            this.Controls.SetChildIndex(this.lblBemerkungRTF, 0);
            this.Controls.SetChildIndex(this.edtPostfach, 0);
            this.Controls.SetChildIndex(this.lblTitel, 0);
            this.Controls.SetChildIndex(this.edtTitel, 0);
            this.Controls.SetChildIndex(this.lblBankKontoNr, 0);
            this.Controls.SetChildIndex(this.edtBankName, 0);
            this.Controls.SetChildIndex(this.lblBankName, 0);
            this.Controls.SetChildIndex(this.edtBankKontoNr, 0);
            this.Controls.SetChildIndex(this.edtIsActive, 0);
            this.Controls.SetChildIndex(this.edtAHVNr, 0);
            this.Controls.SetChildIndex(this.edtGeburtstag, 0);
            this.Controls.SetChildIndex(this.lblAHVNr, 0);
            this.Controls.SetChildIndex(this.edtVersichertennummer, 0);
            this.Controls.SetChildIndex(this.lblGeburt, 0);
            this.Controls.SetChildIndex(this.lblVersicherterNr, 0);
            this.Controls.SetChildIndex(this.edtPLZOrt, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryPriMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLandCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmPriMaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSprachCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMobilTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_G.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon_P.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSpracheCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_P)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefon_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMobilTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungRTF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersicherterNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmPriMaIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPriMaNrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornameX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmPriMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmPriMa)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colHausNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colVmPriMaID;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private KiSS4.Gui.KissTextEdit edtAHVNr;
        private KiSS4.Gui.KissTextEdit edtAdressZusatz;
        private KiSS4.Gui.KissTextEdit edtBankKontoNr;
        private KiSS4.Gui.KissTextEdit edtBankName;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissTextEdit edtFax;
        private KiSS4.Gui.KissDateEdit edtGeburtstag;
        private KiSS4.Gui.KissCheckEdit edtIsActive;
        private KiSS4.Gui.KissTextEdit edtMobilTel;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KiSS4.Gui.KissTextEdit edtNummer;
        private KiSS4.Gui.KissTextEdit edtOrtX;
        private KiSS4.Common.KissPLZOrt edtPLZOrt;
        private KiSS4.Gui.KissTextEdit edtPLZX;
        private KiSS4.Gui.KissTextEdit edtPostfach;
        private KiSS4.Gui.KissLookUpEdit edtSprachCode;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissTextEdit edtStrasseX;
        private KiSS4.Gui.KissTextEdit edtTelefon_G;
        private KiSS4.Gui.KissTextEdit edtTelefon_P;
        private KiSS4.Gui.KissTextEdit edtTitel;
        private KiSS4.Gui.KissVersichertenNrEdit edtVersichertennummer;
        private KiSS4.Gui.KissTextEdit edtVmPriMaID;
        private KiSS4.Gui.KissCalcEdit edtVmPriMaIDX;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissTextEdit edtVornameX;
        private KiSS4.Gui.KissGrid grdVmPriMa;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmPriMa;
        private KiSS4.Gui.KissLabel lblAHVNr;
        private KiSS4.Gui.KissLabel lblAdressZusatz;
        private KiSS4.Gui.KissLabel lblBankKontoNr;
        private KiSS4.Gui.KissLabel lblBankName;
        private KiSS4.Gui.KissLabel lblBemerkungRTF;
        private KiSS4.Gui.KissLabel lblEMail;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblGeburt;
        private KiSS4.Gui.KissLabel lblLandCode;
        private KiSS4.Gui.KissLabel lblMobilTel;
        private KiSS4.Gui.KissLabel lblNameVorname;
        private KiSS4.Gui.KissLabel lblNameX;
        private KiSS4.Gui.KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblPLZX;
        private KiSS4.Gui.KissLabel lblPostfach;
        private KiSS4.Gui.KissLabel lblPriMaNrX;
        private KiSS4.Gui.KissLabel lblSpracheCode;
        private KiSS4.Gui.KissLabel lblStrasseNr;
        private KiSS4.Gui.KissLabel lblStrasseX;
        private KiSS4.Gui.KissLabel lblTelefon_G;
        private KiSS4.Gui.KissLabel lblTelefon_P;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVersicherterNr;
        private KiSS4.Gui.KissLabel lblVmPriMaID;
        private KiSS4.Gui.KissLabel lblVornameX;
        private KiSS4.DB.SqlQuery qryAdresse;
        private KiSS4.DB.SqlQuery qryPriMa;
    }
}
