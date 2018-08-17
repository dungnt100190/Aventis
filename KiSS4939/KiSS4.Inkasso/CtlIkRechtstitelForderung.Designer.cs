namespace KiSS4.Inkasso
{
    public partial class CtlIkRechtstitelForderung
    {
        private System.ComponentModel.IContainer components;

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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkRechtstitelForderung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtALBVBerechtigt = new KiSS4.Gui.KissCheckEdit();
            this.qryIkForderung = new KiSS4.DB.SqlQuery(this.components);
            this.edtIndexStandBeiBerechnung = new KiSS4.Gui.KissCalcEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkForderungPeriodisch = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkAnpassungsGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkAnpassungsRegelCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtForderungenBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.edtAnpassenAb = new KiSS4.Gui.KissDateEdit();
            this.edtAnpassungsBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtIndexStandDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblIkAnpassungsGrundCode = new KiSS4.Gui.KissLabel();
            this.grdForderungen = new KiSS4.Gui.KissGrid();
            this.gdvForderungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterhaltsanspruch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnpassungsGrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeilALBVBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colALV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerechnungsArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblIkForderungPeriodisch = new KiSS4.Gui.KissLabel();
            this.lblIkAnpassungsRegelCode = new KiSS4.Gui.KissLabel();
            this.lblAnpassungsBetrag = new KiSS4.Gui.KissLabel();
            this.lblAnpassenAb = new KiSS4.Gui.KissLabel();
            this.lblForderungenBemerkung = new KiSS4.Gui.KissLabel();
            this.lblIndexStandBeiBerechnung = new KiSS4.Gui.KissLabel();
            this.lblIndexStandDatum = new KiSS4.Gui.KissLabel();
            this.edtTeuerungseinssprache = new KiSS4.Gui.KissCheckEdit();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.edtGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.edtUnterstuetzungsfall = new KiSS4.Gui.KissCheckEdit();
            this.qryLOVListe = new KiSS4.DB.SqlQuery(this.components);
            this.qryPerson = new KiSS4.DB.SqlQuery(this.components);
            this.edtTeilALBVBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblTeilALBVBetrag = new KiSS4.Gui.KissLabel();
            this.edtTeilALBV = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtALBVBerechtigt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkForderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandBeiBerechnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungPeriodisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungPeriodisch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsRegelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsRegelCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungenBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassenAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassungsBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkAnpassungsGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdForderungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvForderungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungPeriodisch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkAnpassungsRegelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassungsBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassenAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungenBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandBeiBerechnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeuerungseinssprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzungsfall.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLOVListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilALBVBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilALBVBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilALBV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtALBVBerechtigt
            // 
            this.edtALBVBerechtigt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtALBVBerechtigt.DataMember = "ALBVBerechtigt";
            this.edtALBVBerechtigt.DataSource = this.qryIkForderung;
            this.edtALBVBerechtigt.Location = new System.Drawing.Point(356, 271);
            this.edtALBVBerechtigt.Name = "edtALBVBerechtigt";
            this.edtALBVBerechtigt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtALBVBerechtigt.Properties.Appearance.Options.UseBackColor = true;
            this.edtALBVBerechtigt.Properties.Caption = "ALBV berechtigt";
            this.edtALBVBerechtigt.Size = new System.Drawing.Size(133, 19);
            this.edtALBVBerechtigt.TabIndex = 7;
            this.edtALBVBerechtigt.TabStop = false;
            this.edtALBVBerechtigt.EditValueChanged += new System.EventHandler(this.edtALBVBerechtigt_EditValueChanged);
            // 
            // qryIkForderung
            // 
            this.qryIkForderung.CanDelete = true;
            this.qryIkForderung.CanInsert = true;
            this.qryIkForderung.CanUpdate = true;
            this.qryIkForderung.HostControl = this;
            this.qryIkForderung.IsIdentityInsert = false;
            this.qryIkForderung.SelectStatement = resources.GetString("qryIkForderung.SelectStatement");
            this.qryIkForderung.TableName = "IkForderung";
            this.qryIkForderung.AfterFill += new System.EventHandler(this.qryIkForderung_AfterFill);
            this.qryIkForderung.AfterInsert += new System.EventHandler(this.qryIkForderung_AfterInsert);
            this.qryIkForderung.AfterPost += new System.EventHandler(this.qryIkForderung_AfterPost);
            this.qryIkForderung.BeforeDeleteQuestion += new System.EventHandler(this.qryIkForderung_BeforeDeleteQuestion);
            this.qryIkForderung.BeforePost += new System.EventHandler(this.qryIkForderung_BeforePost);
            this.qryIkForderung.PositionChanged += new System.EventHandler(this.qryIkForderung_PositionChanged);
            // 
            // edtIndexStandBeiBerechnung
            // 
            this.edtIndexStandBeiBerechnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIndexStandBeiBerechnung.DataMember = "IndexStandBeiBerechnung";
            this.edtIndexStandBeiBerechnung.DataSource = this.qryIkForderung;
            this.edtIndexStandBeiBerechnung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIndexStandBeiBerechnung.Location = new System.Drawing.Point(646, 417);
            this.edtIndexStandBeiBerechnung.Name = "edtIndexStandBeiBerechnung";
            this.edtIndexStandBeiBerechnung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIndexStandBeiBerechnung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIndexStandBeiBerechnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexStandBeiBerechnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexStandBeiBerechnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexStandBeiBerechnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexStandBeiBerechnung.Properties.Appearance.Options.UseFont = true;
            this.edtIndexStandBeiBerechnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIndexStandBeiBerechnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIndexStandBeiBerechnung.Properties.DisplayFormat.FormatString = "n1";
            this.edtIndexStandBeiBerechnung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtIndexStandBeiBerechnung.Properties.EditFormat.FormatString = "n1";
            this.edtIndexStandBeiBerechnung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtIndexStandBeiBerechnung.Properties.ReadOnly = true;
            this.edtIndexStandBeiBerechnung.Size = new System.Drawing.Size(57, 24);
            this.edtIndexStandBeiBerechnung.TabIndex = 26;
            this.edtIndexStandBeiBerechnung.TabStop = false;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryIkForderung;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBaPersonID.Location = new System.Drawing.Point(125, 267);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Person", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Alter", "Alter", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(225, 24);
            this.edtBaPersonID.TabIndex = 2;
            this.edtBaPersonID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtBaPersonID_CloseUp);
            // 
            // edtIkForderungPeriodisch
            // 
            this.edtIkForderungPeriodisch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIkForderungPeriodisch.DataMember = "IkForderungPeriodischCode";
            this.edtIkForderungPeriodisch.DataSource = this.qryIkForderung;
            this.edtIkForderungPeriodisch.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtIkForderungPeriodisch.Location = new System.Drawing.Point(125, 297);
            this.edtIkForderungPeriodisch.LOVName = "IkForderungPeriodisch";
            this.edtIkForderungPeriodisch.Name = "edtIkForderungPeriodisch";
            this.edtIkForderungPeriodisch.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtIkForderungPeriodisch.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkForderungPeriodisch.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungPeriodisch.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkForderungPeriodisch.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkForderungPeriodisch.Properties.Appearance.Options.UseFont = true;
            this.edtIkForderungPeriodisch.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkForderungPeriodisch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkForderungPeriodisch.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkForderungPeriodisch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkForderungPeriodisch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtIkForderungPeriodisch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtIkForderungPeriodisch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkForderungPeriodisch.Properties.NullText = "";
            this.edtIkForderungPeriodisch.Properties.ShowFooter = false;
            this.edtIkForderungPeriodisch.Properties.ShowHeader = false;
            this.edtIkForderungPeriodisch.Size = new System.Drawing.Size(225, 24);
            this.edtIkForderungPeriodisch.TabIndex = 4;
            this.edtIkForderungPeriodisch.EditValueChanged += new System.EventHandler(this.edtIkForderungPeriodisch_EditValueChanged);
            // 
            // edtIkAnpassungsGrundCode
            // 
            this.edtIkAnpassungsGrundCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIkAnpassungsGrundCode.DataMember = "IkAnpassungsGrundCode";
            this.edtIkAnpassungsGrundCode.DataSource = this.qryIkForderung;
            this.edtIkAnpassungsGrundCode.Location = new System.Drawing.Point(125, 327);
            this.edtIkAnpassungsGrundCode.LOVName = "IkAnpassungsGrund";
            this.edtIkAnpassungsGrundCode.Name = "edtIkAnpassungsGrundCode";
            this.edtIkAnpassungsGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkAnpassungsGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkAnpassungsGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkAnpassungsGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkAnpassungsGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkAnpassungsGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkAnpassungsGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkAnpassungsGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkAnpassungsGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkAnpassungsGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkAnpassungsGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtIkAnpassungsGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtIkAnpassungsGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkAnpassungsGrundCode.Properties.NullText = "";
            this.edtIkAnpassungsGrundCode.Properties.ShowFooter = false;
            this.edtIkAnpassungsGrundCode.Properties.ShowHeader = false;
            this.edtIkAnpassungsGrundCode.Size = new System.Drawing.Size(225, 24);
            this.edtIkAnpassungsGrundCode.TabIndex = 6;
            // 
            // edtIkAnpassungsRegelCode
            // 
            this.edtIkAnpassungsRegelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIkAnpassungsRegelCode.DataMember = "IkAnpassungsRegelCode";
            this.edtIkAnpassungsRegelCode.DataSource = this.qryIkForderung;
            this.edtIkAnpassungsRegelCode.Location = new System.Drawing.Point(126, 387);
            this.edtIkAnpassungsRegelCode.LOVName = "IkAnpassungsRegel";
            this.edtIkAnpassungsRegelCode.Name = "edtIkAnpassungsRegelCode";
            this.edtIkAnpassungsRegelCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkAnpassungsRegelCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkAnpassungsRegelCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkAnpassungsRegelCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkAnpassungsRegelCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkAnpassungsRegelCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkAnpassungsRegelCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkAnpassungsRegelCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkAnpassungsRegelCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkAnpassungsRegelCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkAnpassungsRegelCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtIkAnpassungsRegelCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtIkAnpassungsRegelCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkAnpassungsRegelCode.Properties.NullText = "";
            this.edtIkAnpassungsRegelCode.Properties.ShowFooter = false;
            this.edtIkAnpassungsRegelCode.Properties.ShowHeader = false;
            this.edtIkAnpassungsRegelCode.Size = new System.Drawing.Size(452, 24);
            this.edtIkAnpassungsRegelCode.TabIndex = 20;
            this.edtIkAnpassungsRegelCode.EditValueChanged += new System.EventHandler(this.edtIkAnpassungsRegelCode_EditValueChanged);
            // 
            // edtForderungenBemerkung
            // 
            this.edtForderungenBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtForderungenBemerkung.DataMember = "Bemerkung";
            this.edtForderungenBemerkung.DataSource = this.qryIkForderung;
            this.edtForderungenBemerkung.Location = new System.Drawing.Point(125, 417);
            this.edtForderungenBemerkung.Name = "edtForderungenBemerkung";
            this.edtForderungenBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungenBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungenBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungenBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungenBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungenBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtForderungenBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtForderungenBemerkung.Size = new System.Drawing.Size(225, 79);
            this.edtForderungenBemerkung.TabIndex = 22;
            // 
            // edtAnpassenAb
            // 
            this.edtAnpassenAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnpassenAb.DataMember = "DatumAnpassenAb";
            this.edtAnpassenAb.DataSource = this.qryIkForderung;
            this.edtAnpassenAb.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtAnpassenAb.EditValue = null;
            this.edtAnpassenAb.Location = new System.Drawing.Point(598, 267);
            this.edtAnpassenAb.Name = "edtAnpassenAb";
            this.edtAnpassenAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnpassenAb.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtAnpassenAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnpassenAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnpassenAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnpassenAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnpassenAb.Properties.Appearance.Options.UseFont = true;
            this.edtAnpassenAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAnpassenAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnpassenAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAnpassenAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnpassenAb.Properties.ShowToday = false;
            this.edtAnpassenAb.Size = new System.Drawing.Size(105, 24);
            this.edtAnpassenAb.TabIndex = 9;
            this.edtAnpassenAb.EditValueChanged += new System.EventHandler(this.edtAnpassenAb_EditValueChanged);
            // 
            // edtAnpassungsBetrag
            // 
            this.edtAnpassungsBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnpassungsBetrag.DataMember = "Betrag";
            this.edtAnpassungsBetrag.DataSource = this.qryIkForderung;
            this.edtAnpassungsBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtAnpassungsBetrag.Location = new System.Drawing.Point(598, 327);
            this.edtAnpassungsBetrag.Name = "edtAnpassungsBetrag";
            this.edtAnpassungsBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnpassungsBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtAnpassungsBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnpassungsBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnpassungsBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnpassungsBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnpassungsBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtAnpassungsBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnpassungsBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnpassungsBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtAnpassungsBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnpassungsBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtAnpassungsBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnpassungsBetrag.Properties.Mask.EditMask = "n2";
            this.edtAnpassungsBetrag.Size = new System.Drawing.Size(105, 24);
            this.edtAnpassungsBetrag.TabIndex = 15;
            // 
            // edtIndexStandDatum
            // 
            this.edtIndexStandDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIndexStandDatum.DataMember = "IndexStandDatum";
            this.edtIndexStandDatum.DataSource = this.qryIkForderung;
            this.edtIndexStandDatum.EditValue = null;
            this.edtIndexStandDatum.Location = new System.Drawing.Point(490, 417);
            this.edtIndexStandDatum.Name = "edtIndexStandDatum";
            this.edtIndexStandDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIndexStandDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIndexStandDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexStandDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexStandDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexStandDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexStandDatum.Properties.Appearance.Options.UseFont = true;
            this.edtIndexStandDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtIndexStandDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIndexStandDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtIndexStandDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIndexStandDatum.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtIndexStandDatum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtIndexStandDatum.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtIndexStandDatum.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtIndexStandDatum.Properties.Mask.EditMask = "MM.yyyy";
            this.edtIndexStandDatum.Properties.ShowToday = false;
            this.edtIndexStandDatum.Size = new System.Drawing.Size(88, 24);
            this.edtIndexStandDatum.TabIndex = 24;
            this.edtIndexStandDatum.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtDatumIndexStand_CloseUp);
            this.edtIndexStandDatum.EditValueChanged += new System.EventHandler(this.edtIndexStandDatum_EditValueChanged);
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaPersonID.Location = new System.Drawing.Point(3, 267);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(116, 24);
            this.lblBaPersonID.TabIndex = 1;
            this.lblBaPersonID.Text = "Person, Gläubiger ";
            // 
            // lblIkAnpassungsGrundCode
            // 
            this.lblIkAnpassungsGrundCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIkAnpassungsGrundCode.Location = new System.Drawing.Point(3, 327);
            this.lblIkAnpassungsGrundCode.Name = "lblIkAnpassungsGrundCode";
            this.lblIkAnpassungsGrundCode.Size = new System.Drawing.Size(116, 24);
            this.lblIkAnpassungsGrundCode.TabIndex = 5;
            this.lblIkAnpassungsGrundCode.Text = "Anpassungsgrund";
            // 
            // grdForderungen
            // 
            this.grdForderungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdForderungen.DataSource = this.qryIkForderung;
            // 
            // 
            // 
            this.grdForderungen.EmbeddedNavigator.Name = "";
            this.grdForderungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdForderungen.Location = new System.Drawing.Point(3, 3);
            this.grdForderungen.MainView = this.gdvForderungen;
            this.grdForderungen.Name = "grdForderungen";
            this.grdForderungen.Size = new System.Drawing.Size(866, 258);
            this.grdForderungen.TabIndex = 0;
            this.grdForderungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvForderungen});
            // 
            // gdvForderungen
            // 
            this.gdvForderungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gdvForderungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.Empty.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.Empty.Options.UseFont = true;
            this.gdvForderungen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gdvForderungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.EvenRow.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.EvenRow.Options.UseFont = true;
            this.gdvForderungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdvForderungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gdvForderungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.FocusedCell.Options.UseFont = true;
            this.gdvForderungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gdvForderungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gdvForderungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gdvForderungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.FocusedRow.Options.UseFont = true;
            this.gdvForderungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gdvForderungen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gdvForderungen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gdvForderungen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gdvForderungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gdvForderungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gdvForderungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gdvForderungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gdvForderungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.GroupRow.Options.UseFont = true;
            this.gdvForderungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.gdvForderungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gdvForderungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gdvForderungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gdvForderungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gdvForderungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.gdvForderungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gdvForderungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gdvForderungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gdvForderungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gdvForderungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gdvForderungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.OddRow.Options.UseFont = true;
            this.gdvForderungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gdvForderungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.Row.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.Row.Options.UseFont = true;
            this.gdvForderungen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gdvForderungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gdvForderungen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gdvForderungen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gdvForderungen.Appearance.SelectedRow.Options.UseFont = true;
            this.gdvForderungen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gdvForderungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gdvForderungen.Appearance.VertLine.Options.UseBackColor = true;
            this.gdvForderungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gdvForderungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colAlter,
            this.colUnterhaltsanspruch,
            this.colAnpassungsGrund,
            this.colDatumVon,
            this.colDatumGueltigBis,
            this.colBetrag,
            this.colTeilALBVBetrag,
            this.colALV,
            this.colAktiv,
            this.colBerechnungsArt});
            this.gdvForderungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gdvForderungen.GridControl = this.grdForderungen;
            this.gdvForderungen.Name = "gdvForderungen";
            this.gdvForderungen.OptionsBehavior.Editable = false;
            this.gdvForderungen.OptionsCustomization.AllowFilter = false;
            this.gdvForderungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gdvForderungen.OptionsNavigation.AutoFocusNewRow = true;
            this.gdvForderungen.OptionsNavigation.UseTabKey = false;
            this.gdvForderungen.OptionsView.ColumnAutoWidth = false;
            this.gdvForderungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gdvForderungen.OptionsView.ShowGroupPanel = false;
            this.gdvForderungen.OptionsView.ShowIndicator = false;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Person";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 171;
            // 
            // colAlter
            // 
            this.colAlter.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAlter.AppearanceHeader.Options.UseTextOptions = true;
            this.colAlter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 1;
            this.colAlter.Width = 39;
            // 
            // colUnterhaltsanspruch
            // 
            this.colUnterhaltsanspruch.Caption = "Unterhaltsanspruch";
            this.colUnterhaltsanspruch.FieldName = "IkForderungPeriodischCode";
            this.colUnterhaltsanspruch.Name = "colUnterhaltsanspruch";
            this.colUnterhaltsanspruch.Visible = true;
            this.colUnterhaltsanspruch.VisibleIndex = 2;
            this.colUnterhaltsanspruch.Width = 161;
            // 
            // colAnpassungsGrund
            // 
            this.colAnpassungsGrund.Caption = "Anp.Grund";
            this.colAnpassungsGrund.FieldName = "IkAnpassungsGrundCode";
            this.colAnpassungsGrund.Name = "colAnpassungsGrund";
            this.colAnpassungsGrund.Visible = true;
            this.colAnpassungsGrund.VisibleIndex = 3;
            this.colAnpassungsGrund.Width = 127;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "ab Datum";
            this.colDatumVon.FieldName = "DatumAnpassenAb";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 4;
            // 
            // colDatumGueltigBis
            // 
            this.colDatumGueltigBis.Caption = "Gültig bis";
            this.colDatumGueltigBis.FieldName = "DatumGueltigBis";
            this.colDatumGueltigBis.Name = "colDatumGueltigBis";
            this.colDatumGueltigBis.Visible = true;
            this.colDatumGueltigBis.VisibleIndex = 5;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colBetrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            this.colBetrag.Width = 59;
            // 
            // colTeilALBVBetrag
            // 
            this.colTeilALBVBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colTeilALBVBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTeilALBVBetrag.AppearanceHeader.Options.UseTextOptions = true;
            this.colTeilALBVBetrag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTeilALBVBetrag.Caption = "Teil-ALBV";
            this.colTeilALBVBetrag.DisplayFormat.FormatString = "N2";
            this.colTeilALBVBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTeilALBVBetrag.FieldName = "TeilALBVBetrag";
            this.colTeilALBVBetrag.Name = "colTeilALBVBetrag";
            this.colTeilALBVBetrag.Visible = true;
            this.colTeilALBVBetrag.VisibleIndex = 7;
            // 
            // colALV
            // 
            this.colALV.AppearanceCell.Options.UseTextOptions = true;
            this.colALV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALV.AppearanceHeader.Options.UseTextOptions = true;
            this.colALV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colALV.Caption = "ALV";
            this.colALV.DisplayFormat.FormatString = "N2";
            this.colALV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colALV.FieldName = "ALV";
            this.colALV.Name = "colALV";
            this.colALV.Visible = true;
            this.colALV.VisibleIndex = 8;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "aktiv";
            this.colAktiv.FieldName = "ForderungAktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Width = 41;
            // 
            // colBerechnungsArt
            // 
            this.colBerechnungsArt.Caption = "Anpassungsregel";
            this.colBerechnungsArt.FieldName = "AnpassungsRegel";
            this.colBerechnungsArt.Name = "colBerechnungsArt";
            this.colBerechnungsArt.Width = 102;
            // 
            // lblIkForderungPeriodisch
            // 
            this.lblIkForderungPeriodisch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIkForderungPeriodisch.Location = new System.Drawing.Point(3, 297);
            this.lblIkForderungPeriodisch.Name = "lblIkForderungPeriodisch";
            this.lblIkForderungPeriodisch.Size = new System.Drawing.Size(116, 24);
            this.lblIkForderungPeriodisch.TabIndex = 3;
            this.lblIkForderungPeriodisch.Text = "Unterhaltsanspruch";
            // 
            // lblIkAnpassungsRegelCode
            // 
            this.lblIkAnpassungsRegelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIkAnpassungsRegelCode.Location = new System.Drawing.Point(3, 387);
            this.lblIkAnpassungsRegelCode.Name = "lblIkAnpassungsRegelCode";
            this.lblIkAnpassungsRegelCode.Size = new System.Drawing.Size(118, 24);
            this.lblIkAnpassungsRegelCode.TabIndex = 19;
            this.lblIkAnpassungsRegelCode.Text = "Anpassungs Regel";
            // 
            // lblAnpassungsBetrag
            // 
            this.lblAnpassungsBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnpassungsBetrag.Location = new System.Drawing.Point(495, 327);
            this.lblAnpassungsBetrag.Name = "lblAnpassungsBetrag";
            this.lblAnpassungsBetrag.Size = new System.Drawing.Size(97, 24);
            this.lblAnpassungsBetrag.TabIndex = 14;
            this.lblAnpassungsBetrag.Text = "Betrag";
            // 
            // lblAnpassenAb
            // 
            this.lblAnpassenAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnpassenAb.Location = new System.Drawing.Point(495, 267);
            this.lblAnpassenAb.Name = "lblAnpassenAb";
            this.lblAnpassenAb.Size = new System.Drawing.Size(97, 24);
            this.lblAnpassenAb.TabIndex = 8;
            this.lblAnpassenAb.Text = "Gültig ab ";
            // 
            // lblForderungenBemerkung
            // 
            this.lblForderungenBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblForderungenBemerkung.Location = new System.Drawing.Point(3, 417);
            this.lblForderungenBemerkung.Name = "lblForderungenBemerkung";
            this.lblForderungenBemerkung.Size = new System.Drawing.Size(118, 24);
            this.lblForderungenBemerkung.TabIndex = 21;
            this.lblForderungenBemerkung.Text = "Bemerkung";
            // 
            // lblIndexStandBeiBerechnung
            // 
            this.lblIndexStandBeiBerechnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIndexStandBeiBerechnung.Location = new System.Drawing.Point(598, 417);
            this.lblIndexStandBeiBerechnung.Name = "lblIndexStandBeiBerechnung";
            this.lblIndexStandBeiBerechnung.Size = new System.Drawing.Size(42, 24);
            this.lblIndexStandBeiBerechnung.TabIndex = 25;
            this.lblIndexStandBeiBerechnung.Text = "Punkte";
            // 
            // lblIndexStandDatum
            // 
            this.lblIndexStandDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIndexStandDatum.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIndexStandDatum.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblIndexStandDatum.Location = new System.Drawing.Point(381, 417);
            this.lblIndexStandDatum.Name = "lblIndexStandDatum";
            this.lblIndexStandDatum.Size = new System.Drawing.Size(103, 29);
            this.lblIndexStandDatum.TabIndex = 23;
            this.lblIndexStandDatum.Text = "Monat/Jahr bei der Alim Berechnung";
            // 
            // edtTeuerungseinssprache
            // 
            this.edtTeuerungseinssprache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTeuerungseinssprache.DataMember = "Teuerungseinsprache";
            this.edtTeuerungseinssprache.DataSource = this.qryIkForderung;
            this.edtTeuerungseinssprache.Location = new System.Drawing.Point(356, 331);
            this.edtTeuerungseinssprache.Name = "edtTeuerungseinssprache";
            this.edtTeuerungseinssprache.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTeuerungseinssprache.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeuerungseinssprache.Properties.Caption = "Teuerungseinsprache";
            this.edtTeuerungseinssprache.Size = new System.Drawing.Size(133, 19);
            this.edtTeuerungseinssprache.TabIndex = 13;
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigBis.Location = new System.Drawing.Point(495, 297);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(97, 24);
            this.lblGueltigBis.TabIndex = 11;
            this.lblGueltigBis.Text = "Gueltig bis";
            // 
            // edtGueltigBis
            // 
            this.edtGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGueltigBis.DataMember = "DatumGueltigBis";
            this.edtGueltigBis.DataSource = this.qryIkForderung;
            this.edtGueltigBis.EditValue = null;
            this.edtGueltigBis.Location = new System.Drawing.Point(599, 297);
            this.edtGueltigBis.Name = "edtGueltigBis";
            this.edtGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGueltigBis.Properties.ShowToday = false;
            this.edtGueltigBis.Size = new System.Drawing.Size(105, 24);
            this.edtGueltigBis.TabIndex = 12;
            // 
            // edtUnterstuetzungsfall
            // 
            this.edtUnterstuetzungsfall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUnterstuetzungsfall.DataMember = "Unterstuetzungsfall";
            this.edtUnterstuetzungsfall.DataSource = this.qryIkForderung;
            this.edtUnterstuetzungsfall.Location = new System.Drawing.Point(356, 301);
            this.edtUnterstuetzungsfall.Name = "edtUnterstuetzungsfall";
            this.edtUnterstuetzungsfall.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUnterstuetzungsfall.Properties.Appearance.Options.UseBackColor = true;
            this.edtUnterstuetzungsfall.Properties.Caption = "Unterstützungsfall";
            this.edtUnterstuetzungsfall.Size = new System.Drawing.Size(133, 19);
            this.edtUnterstuetzungsfall.TabIndex = 10;
            // 
            // qryLOVListe
            // 
            this.qryLOVListe.IsIdentityInsert = false;
            this.qryLOVListe.SelectStatement = "SELECT \r\n  Code, \r\n  Value1 \r\nFROM dbo.XLOVCode WITH (READUNCOMMITTED)\r\nWHERE LOV" +
    "Name = \'IkForderungPeriodisch\'";
            // 
            // qryPerson
            // 
            this.qryPerson.IsIdentityInsert = false;
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            // 
            // edtTeilALBVBetrag
            // 
            this.edtTeilALBVBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTeilALBVBetrag.DataMember = "TeilALBVBetrag";
            this.edtTeilALBVBetrag.DataSource = this.qryIkForderung;
            this.edtTeilALBVBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTeilALBVBetrag.Location = new System.Drawing.Point(598, 357);
            this.edtTeilALBVBetrag.Name = "edtTeilALBVBetrag";
            this.edtTeilALBVBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTeilALBVBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTeilALBVBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTeilALBVBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeilALBVBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeilALBVBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTeilALBVBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtTeilALBVBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTeilALBVBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTeilALBVBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtTeilALBVBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTeilALBVBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtTeilALBVBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTeilALBVBetrag.Properties.Mask.EditMask = "n2";
            this.edtTeilALBVBetrag.Properties.ReadOnly = true;
            this.edtTeilALBVBetrag.Size = new System.Drawing.Size(105, 24);
            this.edtTeilALBVBetrag.TabIndex = 18;
            // 
            // lblTeilALBVBetrag
            // 
            this.lblTeilALBVBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTeilALBVBetrag.Location = new System.Drawing.Point(495, 357);
            this.lblTeilALBVBetrag.Name = "lblTeilALBVBetrag";
            this.lblTeilALBVBetrag.Size = new System.Drawing.Size(97, 24);
            this.lblTeilALBVBetrag.TabIndex = 17;
            this.lblTeilALBVBetrag.Text = "Teil-ALBV-Betrag";
            // 
            // edtTeilALBV
            // 
            this.edtTeilALBV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTeilALBV.DataMember = "TeilALBV";
            this.edtTeilALBV.DataSource = this.qryIkForderung;
            this.edtTeilALBV.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTeilALBV.Location = new System.Drawing.Point(356, 361);
            this.edtTeilALBV.Name = "edtTeilALBV";
            this.edtTeilALBV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTeilALBV.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeilALBV.Properties.Caption = "Teil-ALBV";
            this.edtTeilALBV.Properties.ReadOnly = true;
            this.edtTeilALBV.Size = new System.Drawing.Size(113, 19);
            this.edtTeilALBV.TabIndex = 16;
            this.edtTeilALBV.EditValueChanged += new System.EventHandler(this.edtTeilALBV_EditValueChanged);
            // 
            // CtlIkRechtstitelForderung
            // 
            this.ActiveSQLQuery = this.qryIkForderung;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(710, 321);
            this.Controls.Add(this.edtUnterstuetzungsfall);
            this.Controls.Add(this.edtGueltigBis);
            this.Controls.Add(this.lblGueltigBis);
            this.Controls.Add(this.edtTeilALBV);
            this.Controls.Add(this.edtTeuerungseinssprache);
            this.Controls.Add(this.lblIndexStandDatum);
            this.Controls.Add(this.lblIndexStandBeiBerechnung);
            this.Controls.Add(this.lblForderungenBemerkung);
            this.Controls.Add(this.lblAnpassenAb);
            this.Controls.Add(this.lblTeilALBVBetrag);
            this.Controls.Add(this.lblAnpassungsBetrag);
            this.Controls.Add(this.lblIkAnpassungsRegelCode);
            this.Controls.Add(this.lblIkForderungPeriodisch);
            this.Controls.Add(this.grdForderungen);
            this.Controls.Add(this.lblIkAnpassungsGrundCode);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.edtIndexStandDatum);
            this.Controls.Add(this.edtTeilALBVBetrag);
            this.Controls.Add(this.edtAnpassungsBetrag);
            this.Controls.Add(this.edtAnpassenAb);
            this.Controls.Add(this.edtForderungenBemerkung);
            this.Controls.Add(this.edtIkAnpassungsRegelCode);
            this.Controls.Add(this.edtIkAnpassungsGrundCode);
            this.Controls.Add(this.edtIkForderungPeriodisch);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.edtIndexStandBeiBerechnung);
            this.Controls.Add(this.edtALBVBerechtigt);
            this.Name = "CtlIkRechtstitelForderung";
            this.Size = new System.Drawing.Size(872, 499);
            ((System.ComponentModel.ISupportInitialize)(this.edtALBVBerechtigt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkForderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandBeiBerechnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungPeriodisch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkForderungPeriodisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsRegelCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkAnpassungsRegelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungenBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassenAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassungsBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkAnpassungsGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdForderungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvForderungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkForderungPeriodisch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkAnpassungsRegelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassungsBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnpassenAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblForderungenBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandBeiBerechnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeuerungseinssprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUnterstuetzungsfall.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLOVListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilALBVBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeilALBVBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeilALBV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnpassungsGrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBerechnungsArt;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumGueltigBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterhaltsanspruch;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private KiSS4.Gui.KissCheckEdit edtALBVBerechtigt;
        private KiSS4.Gui.KissDateEdit edtAnpassenAb;
        private KiSS4.Gui.KissCalcEdit edtAnpassungsBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissMemoEdit edtForderungenBemerkung;
        private KiSS4.Gui.KissDateEdit edtGueltigBis;
        private KiSS4.Gui.KissLookUpEdit edtIkAnpassungsGrundCode;
        private KiSS4.Gui.KissLookUpEdit edtIkAnpassungsRegelCode;
        private KiSS4.Gui.KissLookUpEdit edtIkForderungPeriodisch;
        private KiSS4.Gui.KissCalcEdit edtIndexStandBeiBerechnung;
        private KiSS4.Gui.KissDateEdit edtIndexStandDatum;
        private KiSS4.Gui.KissCheckEdit edtTeuerungseinssprache;
        private KiSS4.Gui.KissCheckEdit edtUnterstuetzungsfall;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvForderungen;
        private KiSS4.Gui.KissGrid grdForderungen;
        private KiSS4.Gui.KissLabel lblAnpassenAb;
        private KiSS4.Gui.KissLabel lblAnpassungsBetrag;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblForderungenBemerkung;
        private KiSS4.Gui.KissLabel lblGueltigBis;
        private KiSS4.Gui.KissLabel lblIkAnpassungsGrundCode;
        private KiSS4.Gui.KissLabel lblIkAnpassungsRegelCode;
        private KiSS4.Gui.KissLabel lblIkForderungPeriodisch;
        private KiSS4.Gui.KissLabel lblIndexStandBeiBerechnung;
        private KiSS4.Gui.KissLabel lblIndexStandDatum;
        private KiSS4.DB.SqlQuery qryLOVListe;
        public KiSS4.DB.SqlQuery qryIkForderung;
        public KiSS4.DB.SqlQuery qryPerson;
        private Gui.KissCheckEdit edtTeilALBV;
        private Gui.KissCalcEdit edtTeilALBVBetrag;
        private Gui.KissLabel lblTeilALBVBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colTeilALBVBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colALV;
    }
}