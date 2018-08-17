using System;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso.ZH
{
    public class CtlIkRechtstitelForderung : KissUserControl
    {
        #region Fields

        #region Public Fields

        public DateTime RechtstitelDatum;
        public int RechtstitelIndexCode = 0;
        public SqlQuery qryIkForderung;
        public SqlQuery qryPerson;

        #endregion

        #region Private Fields

        private int _faLeistungID = 0;
        private int _faProzessCode = 0;
        private int _ikRechtstitelID = 0;
        private bool _leistungIstGeschlossen = true;
        private int _rtiIndexCode = 0;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAnpassungsGrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBerechnungsArt;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colForderungsTitel;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtAnpassenAb;
        private KiSS4.Gui.KissCalcEdit edtAnpassungsBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissCheckEdit edtForderungWurdeSollgest;
        private KiSS4.Gui.KissMemoEdit edtForderungenBemerkung;
        private KiSS4.Gui.KissDateEdit edtGueltigBis;
        private KiSS4.Gui.KissLookUpEdit edtIkAnpassungsGrundCode;
        private KiSS4.Gui.KissLookUpEdit edtIkAnpassungsRegelCode;
        private KiSS4.Gui.KissLookUpEdit edtIkForderungPeriodisch;
        private KiSS4.Gui.KissCalcEdit edtIndexStandBeiBerechnung;
        private KiSS4.Gui.KissDateEdit edtIndexStandDatum;
        private KiSS4.Gui.KissCheckEdit edtTeuerungseinsprache;
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
        private KiSS4.DB.SqlQuery qryDeleteKontrolle;
        private KiSS4.DB.SqlQuery qryLOVListe;
        private KiSS4.DB.SqlQuery qryLOVRegel;

        #endregion

        #endregion

        #region Constructors

        public CtlIkRechtstitelForderung()
        {
            this.InitializeComponent();
            // TODO
            // Wenn es ein KissUser-Ereigniss für KissDateEdit gibt, kann man den Indexstand auch nach dem Korrigieren des Datums holen
            // ------------------------------------------------------------------------

            colForderungsTitel.ColumnEdit = grdForderungen.GetLOVLookUpEdit("IkForderungPeriodisch");
            colAnpassungsGrund.ColumnEdit = grdForderungen.GetLOVLookUpEdit("IkAnpassungsGrund");
            colBerechnungsArt.ColumnEdit = grdForderungen.GetLOVLookUpEdit("IkAnpassungsRegel");
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkRechtstitelForderung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtForderungWurdeSollgest = new KiSS4.Gui.KissCheckEdit();
            this.qryIkForderung = new KiSS4.DB.SqlQuery(this.components);
            this.edtIndexStandBeiBerechnung = new KiSS4.Gui.KissCalcEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkForderungPeriodisch = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkAnpassungsGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtIkAnpassungsRegelCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAnpassenAb = new KiSS4.Gui.KissDateEdit();
            this.edtGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.edtAnpassungsBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtIndexStandDatum = new KiSS4.Gui.KissDateEdit();
            this.edtForderungenBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblIkAnpassungsGrundCode = new KiSS4.Gui.KissLabel();
            this.grdForderungen = new KiSS4.Gui.KissGrid();
            this.gdvForderungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForderungsTitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnpassungsGrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerechnungsArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblIkForderungPeriodisch = new KiSS4.Gui.KissLabel();
            this.lblIkAnpassungsRegelCode = new KiSS4.Gui.KissLabel();
            this.lblAnpassungsBetrag = new KiSS4.Gui.KissLabel();
            this.lblAnpassenAb = new KiSS4.Gui.KissLabel();
            this.lblForderungenBemerkung = new KiSS4.Gui.KissLabel();
            this.lblIndexStandBeiBerechnung = new KiSS4.Gui.KissLabel();
            this.lblIndexStandDatum = new KiSS4.Gui.KissLabel();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.edtTeuerungseinsprache = new KiSS4.Gui.KissCheckEdit();
            this.qryDeleteKontrolle = new KiSS4.DB.SqlQuery(this.components);
            this.qryLOVListe = new KiSS4.DB.SqlQuery(this.components);
            this.qryLOVRegel = new KiSS4.DB.SqlQuery(this.components);
            this.qryPerson = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungWurdeSollgest.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassenAb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassungsBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungenBemerkung.Properties)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeuerungseinsprache.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDeleteKontrolle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLOVListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLOVRegel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            this.SuspendLayout();
            //
            // edtForderungWurdeSollgest
            //
            this.edtForderungWurdeSollgest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtForderungWurdeSollgest.DataMember = "IstSollGestellt";
            this.edtForderungWurdeSollgest.DataSource = this.qryIkForderung;
            this.edtForderungWurdeSollgest.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtForderungWurdeSollgest.Location = new System.Drawing.Point(374, 486);
            this.edtForderungWurdeSollgest.Name = "edtForderungWurdeSollgest";
            this.edtForderungWurdeSollgest.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtForderungWurdeSollgest.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungWurdeSollgest.Properties.Caption = "Sollgestellt";
            this.edtForderungWurdeSollgest.Properties.ReadOnly = true;
            this.edtForderungWurdeSollgest.Size = new System.Drawing.Size(113, 19);
            this.edtForderungWurdeSollgest.TabIndex = 0;
            this.edtForderungWurdeSollgest.TabStop = false;
            //
            // qryIkForderung
            //
            this.qryIkForderung.CanDelete = true;
            this.qryIkForderung.CanInsert = true;
            this.qryIkForderung.CanUpdate = true;
            this.qryIkForderung.HostControl = this;
            this.qryIkForderung.SelectStatement = resources.GetString("qryIkForderung.SelectStatement");
            this.qryIkForderung.TableName = "IkForderung";
            this.qryIkForderung.AfterFill += new System.EventHandler(this.qryIkForderung_AfterFill);
            this.qryIkForderung.AfterInsert += new System.EventHandler(this.qryIkForderung_AfterInsert);
            this.qryIkForderung.BeforePost += new System.EventHandler(this.qryIkForderung_BeforePost);
            this.qryIkForderung.AfterPost += new System.EventHandler(this.qryIkForderung_AfterPost);
            this.qryIkForderung.BeforeDelete += new System.EventHandler(this.qryIkForderung_BeforeDelete);
            this.qryIkForderung.AfterDelete += new System.EventHandler(this.qryIkForderung_AfterDelete);
            this.qryIkForderung.PositionChanged += new System.EventHandler(this.qryIkForderung_PositionChanged);
            //
            // edtIndexStandBeiBerechnung
            //
            this.edtIndexStandBeiBerechnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIndexStandBeiBerechnung.DataMember = "IndexStandBeiBerechnung";
            this.edtIndexStandBeiBerechnung.DataSource = this.qryIkForderung;
            this.edtIndexStandBeiBerechnung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIndexStandBeiBerechnung.Location = new System.Drawing.Point(621, 443);
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
            this.edtIndexStandBeiBerechnung.TabIndex = 0;
            this.edtIndexStandBeiBerechnung.TabStop = false;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryIkForderung;
            this.edtBaPersonID.Location = new System.Drawing.Point(118, 309);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Person", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Alter", "Alter", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(331, 24);
            this.edtBaPersonID.TabIndex = 1;
            this.edtBaPersonID.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtBaPersonID_CloseUp);
            //
            // edtIkForderungPeriodisch
            //
            this.edtIkForderungPeriodisch.AllowNull = false;
            this.edtIkForderungPeriodisch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIkForderungPeriodisch.DataMember = "IkForderungPeriodischCode";
            this.edtIkForderungPeriodisch.DataSource = this.qryIkForderung;
            this.edtIkForderungPeriodisch.Location = new System.Drawing.Point(118, 339);
            this.edtIkForderungPeriodisch.LOVFilter = "Value3 = \'405\' and Code=2";
            this.edtIkForderungPeriodisch.LOVFilterWhereAppend = true;
            this.edtIkForderungPeriodisch.LOVName = "IkForderungPeriodisch";
            this.edtIkForderungPeriodisch.Name = "edtIkForderungPeriodisch";
            this.edtIkForderungPeriodisch.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtIkForderungPeriodisch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtIkForderungPeriodisch.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkForderungPeriodisch.Properties.NullText = "";
            this.edtIkForderungPeriodisch.Properties.ShowFooter = false;
            this.edtIkForderungPeriodisch.Properties.ShowHeader = false;
            this.edtIkForderungPeriodisch.Size = new System.Drawing.Size(331, 24);
            this.edtIkForderungPeriodisch.TabIndex = 2;
            this.edtIkForderungPeriodisch.EditValueChanged += new System.EventHandler(this.edtIkForderungPeriodisch_EditValueChanged);
            //
            // edtIkAnpassungsGrundCode
            //
            this.edtIkAnpassungsGrundCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIkAnpassungsGrundCode.DataMember = "IkAnpassungsGrundCode";
            this.edtIkAnpassungsGrundCode.DataSource = this.qryIkForderung;
            this.edtIkAnpassungsGrundCode.Location = new System.Drawing.Point(119, 370);
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtIkAnpassungsGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtIkAnpassungsGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkAnpassungsGrundCode.Properties.NullText = "";
            this.edtIkAnpassungsGrundCode.Properties.ShowFooter = false;
            this.edtIkAnpassungsGrundCode.Properties.ShowHeader = false;
            this.edtIkAnpassungsGrundCode.Size = new System.Drawing.Size(330, 24);
            this.edtIkAnpassungsGrundCode.TabIndex = 3;
            //
            // edtIkAnpassungsRegelCode
            //
            this.edtIkAnpassungsRegelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIkAnpassungsRegelCode.DataMember = "IkAnpassungsRegelCode";
            this.edtIkAnpassungsRegelCode.DataSource = this.qryIkForderung;
            this.edtIkAnpassungsRegelCode.Location = new System.Drawing.Point(118, 401);
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
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtIkAnpassungsRegelCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtIkAnpassungsRegelCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkAnpassungsRegelCode.Properties.NullText = "";
            this.edtIkAnpassungsRegelCode.Properties.ShowFooter = false;
            this.edtIkAnpassungsRegelCode.Properties.ShowHeader = false;
            this.edtIkAnpassungsRegelCode.Size = new System.Drawing.Size(331, 24);
            this.edtIkAnpassungsRegelCode.TabIndex = 4;
            this.edtIkAnpassungsRegelCode.EditValueChanged += new System.EventHandler(this.edtIkAnpassungsRegelCode_EditValueChanged);
            //
            // edtAnpassenAb
            //
            this.edtAnpassenAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnpassenAb.DataMember = "DatumAnpassenAb";
            this.edtAnpassenAb.DataSource = this.qryIkForderung;
            this.edtAnpassenAb.EditValue = null;
            this.edtAnpassenAb.Location = new System.Drawing.Point(573, 309);
            this.edtAnpassenAb.Name = "edtAnpassenAb";
            this.edtAnpassenAb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnpassenAb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnpassenAb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnpassenAb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnpassenAb.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnpassenAb.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnpassenAb.Properties.Appearance.Options.UseFont = true;
            this.edtAnpassenAb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAnpassenAb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnpassenAb.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAnpassenAb.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnpassenAb.Properties.ShowToday = false;
            this.edtAnpassenAb.Size = new System.Drawing.Size(105, 24);
            this.edtAnpassenAb.TabIndex = 6;
            this.edtAnpassenAb.EditValueChanged += new System.EventHandler(this.edtAnpassenAb_EditValueChanged);
            //
            // edtGueltigBis
            //
            this.edtGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGueltigBis.DataMember = "DatumGueltigBis";
            this.edtGueltigBis.DataSource = this.qryIkForderung;
            this.edtGueltigBis.EditValue = null;
            this.edtGueltigBis.Location = new System.Drawing.Point(573, 339);
            this.edtGueltigBis.Name = "edtGueltigBis";
            this.edtGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGueltigBis.Properties.ShowToday = false;
            this.edtGueltigBis.Size = new System.Drawing.Size(104, 24);
            this.edtGueltigBis.TabIndex = 7;
            //
            // edtAnpassungsBetrag
            //
            this.edtAnpassungsBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnpassungsBetrag.DataMember = "Betrag";
            this.edtAnpassungsBetrag.DataSource = this.qryIkForderung;
            this.edtAnpassungsBetrag.Location = new System.Drawing.Point(573, 370);
            this.edtAnpassungsBetrag.Name = "edtAnpassungsBetrag";
            this.edtAnpassungsBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnpassungsBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnpassungsBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnpassungsBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnpassungsBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnpassungsBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnpassungsBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtAnpassungsBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnpassungsBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnpassungsBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtAnpassungsBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnpassungsBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtAnpassungsBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnpassungsBetrag.Properties.Mask.EditMask = "n2";
            this.edtAnpassungsBetrag.Size = new System.Drawing.Size(105, 24);
            this.edtAnpassungsBetrag.TabIndex = 8;
            //
            // edtIndexStandDatum
            //
            this.edtIndexStandDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIndexStandDatum.DataMember = "IndexStandDatum";
            this.edtIndexStandDatum.DataSource = this.qryIkForderung;
            this.edtIndexStandDatum.EditValue = null;
            this.edtIndexStandDatum.Location = new System.Drawing.Point(484, 443);
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
            this.edtIndexStandDatum.TabIndex = 9;
            this.edtIndexStandDatum.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtDatumIndexStand_CloseUp);
            this.edtIndexStandDatum.EditValueChanged += new System.EventHandler(this.edtIndexStandDatum_EditValueChanged);
            //
            // edtForderungenBemerkung
            //
            this.edtForderungenBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtForderungenBemerkung.DataMember = "Bemerkung";
            this.edtForderungenBemerkung.DataSource = this.qryIkForderung;
            this.edtForderungenBemerkung.Location = new System.Drawing.Point(119, 438);
            this.edtForderungenBemerkung.Name = "edtForderungenBemerkung";
            this.edtForderungenBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtForderungenBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtForderungenBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtForderungenBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtForderungenBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtForderungenBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtForderungenBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtForderungenBemerkung.Size = new System.Drawing.Size(223, 67);
            this.edtForderungenBemerkung.TabIndex = 10;
            //
            // lblBaPersonID
            //
            this.lblBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaPersonID.Location = new System.Drawing.Point(9, 309);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(103, 24);
            this.lblBaPersonID.TabIndex = 21;
            this.lblBaPersonID.Text = "Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            //
            // lblIkAnpassungsGrundCode
            //
            this.lblIkAnpassungsGrundCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIkAnpassungsGrundCode.Location = new System.Drawing.Point(9, 371);
            this.lblIkAnpassungsGrundCode.Name = "lblIkAnpassungsGrundCode";
            this.lblIkAnpassungsGrundCode.Size = new System.Drawing.Size(100, 23);
            this.lblIkAnpassungsGrundCode.TabIndex = 25;
            this.lblIkAnpassungsGrundCode.Text = "Anpassungsgrund";
            this.lblIkAnpassungsGrundCode.UseCompatibleTextRendering = true;
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
            this.grdForderungen.Location = new System.Drawing.Point(9, 9);
            this.grdForderungen.MainView = this.gdvForderungen;
            this.grdForderungen.Margin = new System.Windows.Forms.Padding(9);
            this.grdForderungen.Name = "grdForderungen";
            this.grdForderungen.Size = new System.Drawing.Size(669, 288);
            this.grdForderungen.TabIndex = 27;
            this.grdForderungen.TabStop = false;
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
            this.colForderungsTitel,
            this.colAnpassungsGrund,
            this.colBerechnungsArt,
            this.colDatumVon,
            this.colDatumBis,
            this.colBetrag});
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
            this.colPerson.Caption = "Person / Geburtsdatum";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 195;
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
            // colForderungsTitel
            //
            this.colForderungsTitel.Caption = "Forderungsgrund";
            this.colForderungsTitel.FieldName = "IkForderungPeriodischCode";
            this.colForderungsTitel.Name = "colForderungsTitel";
            this.colForderungsTitel.Visible = true;
            this.colForderungsTitel.VisibleIndex = 2;
            this.colForderungsTitel.Width = 119;
            //
            // colAnpassungsGrund
            //
            this.colAnpassungsGrund.Caption = "Anpassungsgrund";
            this.colAnpassungsGrund.FieldName = "IkAnpassungsGrundCode";
            this.colAnpassungsGrund.Name = "colAnpassungsGrund";
            this.colAnpassungsGrund.Visible = true;
            this.colAnpassungsGrund.VisibleIndex = 3;
            this.colAnpassungsGrund.Width = 100;
            //
            // colBerechnungsArt
            //
            this.colBerechnungsArt.Caption = "Anpassungs Regel";
            this.colBerechnungsArt.FieldName = "AnpassungsRegel";
            this.colBerechnungsArt.Name = "colBerechnungsArt";
            this.colBerechnungsArt.Width = 102;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "ab Datum";
            this.colDatumVon.FieldName = "DatumAnpassenAb";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 4;
            this.colDatumVon.Width = 70;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "bis Datum";
            this.colDatumBis.FieldName = "DatumGueltigBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 5;
            this.colDatumBis.Width = 70;
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
            this.colBetrag.Width = 53;
            //
            // lblIkForderungPeriodisch
            //
            this.lblIkForderungPeriodisch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIkForderungPeriodisch.Location = new System.Drawing.Point(10, 340);
            this.lblIkForderungPeriodisch.Name = "lblIkForderungPeriodisch";
            this.lblIkForderungPeriodisch.Size = new System.Drawing.Size(100, 23);
            this.lblIkForderungPeriodisch.TabIndex = 29;
            this.lblIkForderungPeriodisch.Text = "Forderungsgrund";
            this.lblIkForderungPeriodisch.UseCompatibleTextRendering = true;
            //
            // lblIkAnpassungsRegelCode
            //
            this.lblIkAnpassungsRegelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIkAnpassungsRegelCode.Location = new System.Drawing.Point(9, 401);
            this.lblIkAnpassungsRegelCode.Name = "lblIkAnpassungsRegelCode";
            this.lblIkAnpassungsRegelCode.Size = new System.Drawing.Size(103, 24);
            this.lblIkAnpassungsRegelCode.TabIndex = 30;
            this.lblIkAnpassungsRegelCode.Text = "Anpassungsregel";
            this.lblIkAnpassungsRegelCode.UseCompatibleTextRendering = true;
            //
            // lblAnpassungsBetrag
            //
            this.lblAnpassungsBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnpassungsBetrag.Location = new System.Drawing.Point(474, 370);
            this.lblAnpassungsBetrag.Name = "lblAnpassungsBetrag";
            this.lblAnpassungsBetrag.Size = new System.Drawing.Size(73, 24);
            this.lblAnpassungsBetrag.TabIndex = 34;
            this.lblAnpassungsBetrag.Text = "Betrag";
            this.lblAnpassungsBetrag.UseCompatibleTextRendering = true;
            //
            // lblAnpassenAb
            //
            this.lblAnpassenAb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnpassenAb.Location = new System.Drawing.Point(474, 308);
            this.lblAnpassenAb.Name = "lblAnpassenAb";
            this.lblAnpassenAb.Size = new System.Drawing.Size(93, 24);
            this.lblAnpassenAb.TabIndex = 35;
            this.lblAnpassenAb.Text = "Gültig ab Datum";
            this.lblAnpassenAb.UseCompatibleTextRendering = true;
            //
            // lblForderungenBemerkung
            //
            this.lblForderungenBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblForderungenBemerkung.Location = new System.Drawing.Point(10, 438);
            this.lblForderungenBemerkung.Name = "lblForderungenBemerkung";
            this.lblForderungenBemerkung.Size = new System.Drawing.Size(103, 24);
            this.lblForderungenBemerkung.TabIndex = 36;
            this.lblForderungenBemerkung.Text = "Bemerkung";
            this.lblForderungenBemerkung.UseCompatibleTextRendering = true;
            //
            // lblIndexStandBeiBerechnung
            //
            this.lblIndexStandBeiBerechnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIndexStandBeiBerechnung.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIndexStandBeiBerechnung.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblIndexStandBeiBerechnung.Location = new System.Drawing.Point(578, 449);
            this.lblIndexStandBeiBerechnung.Name = "lblIndexStandBeiBerechnung";
            this.lblIndexStandBeiBerechnung.Size = new System.Drawing.Size(39, 17);
            this.lblIndexStandBeiBerechnung.TabIndex = 37;
            this.lblIndexStandBeiBerechnung.Text = "Punkte";
            this.lblIndexStandBeiBerechnung.UseCompatibleTextRendering = true;
            //
            // lblIndexStandDatum
            //
            this.lblIndexStandDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIndexStandDatum.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblIndexStandDatum.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblIndexStandDatum.Location = new System.Drawing.Point(374, 438);
            this.lblIndexStandDatum.Name = "lblIndexStandDatum";
            this.lblIndexStandDatum.Size = new System.Drawing.Size(103, 29);
            this.lblIndexStandDatum.TabIndex = 38;
            this.lblIndexStandDatum.Text = "Monat/Jahr letzte Indexanpassung";
            this.lblIndexStandDatum.UseCompatibleTextRendering = true;
            //
            // lblGueltigBis
            //
            this.lblGueltigBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGueltigBis.Location = new System.Drawing.Point(474, 339);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(90, 24);
            this.lblGueltigBis.TabIndex = 43;
            this.lblGueltigBis.Text = "Gültig bis Datum ";
            this.lblGueltigBis.UseCompatibleTextRendering = true;
            //
            // edtTeuerungseinsprache
            //
            this.edtTeuerungseinsprache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTeuerungseinsprache.DataMember = "Teuerungseinsprache";
            this.edtTeuerungseinsprache.DataSource = this.qryIkForderung;
            this.edtTeuerungseinsprache.Location = new System.Drawing.Point(474, 405);
            this.edtTeuerungseinsprache.Name = "edtTeuerungseinsprache";
            this.edtTeuerungseinsprache.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtTeuerungseinsprache.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeuerungseinsprache.Properties.Caption = "Teuerungseinsprache";
            this.edtTeuerungseinsprache.Size = new System.Drawing.Size(203, 19);
            this.edtTeuerungseinsprache.TabIndex = 44;
            //
            // qryDeleteKontrolle
            //
            this.qryDeleteKontrolle.HostControl = this;
            this.qryDeleteKontrolle.SelectStatement = resources.GetString("qryDeleteKontrolle.SelectStatement");
            //
            // qryLOVListe
            //
            this.qryLOVListe.HostControl = this;
            this.qryLOVListe.SelectStatement = "select Code, Value1 from dbo.xlovcode WITH(READUNCOMMITTED)\r\nwhere lovname = \'IkF" +
                "orderungPeriodisch\'";
            //
            // qryLOVRegel
            //
            this.qryLOVRegel.HostControl = this;
            this.qryLOVRegel.SelectStatement = "select Code, Text, Value1\r\nfrom dbo.XLovCode WITH(READUNCOMMITTED)\r\nwhere LOVName" +
                " = \'IkAnpassungsregel\'\r\norder by SortKey";
            //
            // qryPerson
            //
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            //
            // CtlIkRechtstitelForderung
            //
            this.ActiveSQLQuery = this.qryIkForderung;
            this.Controls.Add(this.edtTeuerungseinsprache);
            this.Controls.Add(this.lblGueltigBis);
            this.Controls.Add(this.lblIndexStandDatum);
            this.Controls.Add(this.lblIndexStandBeiBerechnung);
            this.Controls.Add(this.lblForderungenBemerkung);
            this.Controls.Add(this.lblAnpassenAb);
            this.Controls.Add(this.lblAnpassungsBetrag);
            this.Controls.Add(this.lblIkAnpassungsRegelCode);
            this.Controls.Add(this.lblIkForderungPeriodisch);
            this.Controls.Add(this.grdForderungen);
            this.Controls.Add(this.lblIkAnpassungsGrundCode);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.edtForderungenBemerkung);
            this.Controls.Add(this.edtIndexStandDatum);
            this.Controls.Add(this.edtAnpassungsBetrag);
            this.Controls.Add(this.edtGueltigBis);
            this.Controls.Add(this.edtAnpassenAb);
            this.Controls.Add(this.edtIkAnpassungsRegelCode);
            this.Controls.Add(this.edtIkAnpassungsGrundCode);
            this.Controls.Add(this.edtIkForderungPeriodisch);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.edtIndexStandBeiBerechnung);
            this.Controls.Add(this.edtForderungWurdeSollgest);
            this.Name = "CtlIkRechtstitelForderung";
            this.Size = new System.Drawing.Size(687, 514);
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungWurdeSollgest.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassenAb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnpassungsBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtForderungenBemerkung.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeuerungseinsprache.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDeleteKontrolle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLOVListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryLOVRegel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

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

        #region Properties

        private bool CanEdit
        {
            get
            {
                // 13.05.2008 : sozheo : Index-Felder gesperrt, wenn bei RT "keine Indexierung"
                return (
                    qryIkForderung.CanUpdate &&
                    qryIkForderung.Count > 0 &&
                    //!Utils.ConvertToBool(qryIkForderung["IstSollGestellt"], false) &&
                    !_leistungIstGeschlossen
                );
            }
        }

        private bool CanEditAnpassungsregel
        {
            get
            {
                return (
                    CanEdit &&
                    _rtiIndexCode != 99 &&
                    _rtiIndexCode != 0
                );
            }
        }

        private bool CanEditBemerkung
        {
            get
            {
                return (
                    qryIkForderung.CanUpdate &&
                    qryIkForderung.Count > 0 &&
                    !_leistungIstGeschlossen
                );
            }
        }

        private bool CanEditIndex
        {
            get
            {
                var aRegelCode = Utils.ConvertToInt(qryIkForderung["IkAnpassungsRegelCode"]);

                return (
                    CanEdit &&
                    _rtiIndexCode != 99 &&
                    _rtiIndexCode != 0 &&
                    aRegelCode != 0 &&
                    aRegelCode != 7 &&
                    aRegelCode != 8
                );
            }
        }

        /// <summary>
        /// Liefert TRUE zurück, wenn dieser Typ eine Indexierung verlangt. Diese Information ist in der LOV-Liste unter Value1 gespeichert.
        /// </summary>
        private bool HasIndex
        {
            get
            {
                if (qryLOVListe.Find("Code=" + Utils.ConvertToInt(qryIkForderung["IkForderungPeriodischCode"])))
                {
                    return (Utils.ConvertToString(qryLOVListe["Value1"]) == "1");
                }

                return false;
            }
        }

        /// <summary>
        /// Gibt an, ob es ein Aliment ist oder nicht
        /// </summary>
        private bool IstAliment
        {
            get
            {
                return (
                    Utils.ConvertToInt(qryIkForderung["IkForderungPeriodischCode"]) == 1 ||
                    Utils.ConvertToInt(qryIkForderung["IkForderungPeriodischCode"]) == 2
                );
            }
        }

        /// <summary>
        /// Gibt an, ob es ein Kinderaliment ist
        /// </summary>
        private bool IstKinderAliment
        {
            get
            {
                return (Utils.ConvertToInt(qryIkForderung["IkForderungPeriodischCode"]) == 1);
            }
        }

        #endregion

        #region EventHandlers

        private void edtAnpassenAb_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtAnpassenAb.UserModified)
            {
                return;
            }

            if (DBUtil.IsEmpty(edtAnpassenAb.EditValue))
            {
                return;
            }

            qryIkForderung["DatumAnpassenAb"] = edtAnpassenAb.DateTime;
            DatumIndexSetzen();
            IndexPunkteSetzen();
        }

        private void edtBaPersonID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;

            if (!e.CloseMode.Equals(DevExpress.XtraEditors.PopupCloseMode.Normal))
            {
                return;
            }

            qryIkForderung["Person"] = edtBaPersonID.GetDisplayText(e.Value);

            if (qryPerson.Find("BaPersonID=" + (Utils.ConvertToInt(e.Value))))
            {
                qryIkForderung["Alter"] = qryPerson["Alter"];
            }

            SetFilterLOV(Utils.ConvertToInt(e.Value));
        }

        private void edtDatumIndexStand_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;

            if (!e.CloseMode.Equals(DevExpress.XtraEditors.PopupCloseMode.Normal))
            {
                return;
            }

            // Indexstand neu holen:
            qryIkForderung["IndexStandBeiBerechnung"] = GetIndexPunkte(RechtstitelIndexCode, e.Value);
        }

        private void edtIkAnpassungsRegelCode_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtIkAnpassungsRegelCode.UserModified)
            {
                return;
            }

            qryIkForderung["IkAnpassungsRegelCode"] = Utils.ConvertToInt(edtIkAnpassungsRegelCode.EditValue);
            DatumIndexSetzen();
            IndexPunkteSetzen();
            SetEditMode();
        }

        private void edtIkForderungPeriodisch_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtIkForderungPeriodisch.UserModified)
            {
                return;
            }

            // Neuer Wert setzen
            qryIkForderung["IkForderungPeriodischCode"] = Utils.ConvertToInt(edtIkForderungPeriodisch.EditValue);

            // Editieren einstellen
            SetEditMode();

            // Einstellen je nachdem, ob die Forderung index hat oder nicht:
            if (HasIndex)
            {
                DatumIndexSetzen();
                IndexPunkteSetzen();
            }
            else
            {
                // Alles mit Index kann gelöscht werden:
                qryIkForderung["IkAnpassungsGrundCode"] = DBNull.Value;
                qryIkForderung["IkAnpassungsRegelCode"] = DBNull.Value;
                qryIkForderung["IndexStandDatum"] = DBNull.Value;
                qryIkForderung["IndexStandBeiBerechnung"] = DBNull.Value;
                qryIkForderung.RefreshDisplay();
            }

            //if (IstAliment() && DBUtil.IsEmpty(qryIkForderung["Betrag"]))
            if (IstAliment)
            {
                // Betrag aus dem Rechtstitel holen
                var qry = DBUtil.OpenSQL(@"
                  SELECT RTT.BasisKinderalimente,
                         RTT.BasisEhegattenalimente
                  FROM dbo.IkRechtstitel RTT WITH (READUNCOMMITTED)
                  WHERE RTT.IkRechtstitelID = {0};", _ikRechtstitelID);

                if (IstKinderAliment)
                {
                    qryIkForderung["Betrag"] = qry["BasisKinderalimente"];
                }
                else
                {
                    qryIkForderung["Betrag"] = qry["BasisEhegattenalimente"];
                }

                qryIkForderung.RefreshDisplay();
            }
        }

        private void edtIndexStandDatum_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtIndexStandDatum.UserModified)
            {
                return;
            }

            if (DBUtil.IsEmpty(edtIndexStandDatum.EditValue))
            {
                return;
            }

            qryIkForderung["IndexStandDatum"] = edtIndexStandDatum.DateTime;
            IndexPunkteSetzen();
        }

        private void qryIkForderung_AfterDelete(object sender, EventArgs e)
        {
            MonatszahlenNeuRechnen();
        }

        private void qryIkForderung_AfterFill(object sender, EventArgs e)
        {
            if (qryIkForderung.Count == 0)
            {
                qryIkForderung_PositionChanged(sender, e);
            }
        }

        private void qryIkForderung_AfterInsert(object sender, EventArgs e)
        {
            // 01.04.2008 : sozheo : Neues Feld Teuerungseinsprache

            qryIkForderung["FaLeistungID"] = _faLeistungID;
            qryIkForderung["IkRechtstitelID"] = _ikRechtstitelID;
            qryIkForderung["Teuerungseinsprache"] = false;
            qryIkForderung["IstSollGestellt"] = false;
            edtBaPersonID.Focus();
        }

        private void qryIkForderung_AfterPost(object sender, EventArgs e)
        {
            MonatszahlenNeuRechnen();
        }

        private void qryIkForderung_BeforeDelete(object sender, EventArgs e)
        {
            // #32: 22.07.2009, Dokument CR_Alim5_Monatszahlen_V3.0_Test4.1_22_07_2009.doc
            // Gemäss Rücksprache mit Teamleitung Alimentenstelle sollen Forderungen jederzeit
            // in der Maske Rechtstitel, Forderungen, gelöscht werden können.
            // Keine Kontrolle, ob bereits Sollstellungen erfolgt sind,
            // damit falsch erfasste Forderungen wieder gelöscht werden können.
            /*
            if (Utils.ConvertToBool(qryIkForderung["IstSollGestellt"], false))
            {
                KissMsg.ShowInfo("Teile dieser Forderung sind bereits sollgestellt.\r\nDiese Forderung kann deshalb nicht gelöscht werden.");
                throw new KissCancelException();
            }

            qryDeleteKontrolle.Fill(Utils.ConvertToInt(qryIkForderung["IkForderungID"]));
            if (Utils.ConvertToInt(qryDeleteKontrolle["Anzahl"]) > 0)
            {
                KissMsg.ShowInfo("Diese Forderung ist bereits sollgestellt.\r\nSie kann deshalb nicht gelöscht werden.");
                throw new KissCancelException();
            }
             * */
        }

        private void qryIkForderung_BeforePost(object sender, EventArgs e)
        {
            // Mussfelder checken: Codes:
            DBUtil.CheckNotNullField(edtBaPersonID, lblBaPersonID.Text);
            DBUtil.CheckNotNullField(edtIkForderungPeriodisch, lblIkForderungPeriodisch.Text);
            DBUtil.CheckNotNullField(edtAnpassenAb, lblAnpassenAb.Text);
            DBUtil.CheckNotNullField(edtAnpassungsBetrag, lblAnpassungsBetrag.Text);
            DBUtil.CheckNotNullField(edtIkAnpassungsGrundCode, lblIkAnpassungsGrundCode.Text);

            if (HasIndex && CanEditIndex)
            {
                DBUtil.CheckNotNullField(edtIkAnpassungsRegelCode, lblIkAnpassungsRegelCode.Text);
                DBUtil.CheckNotNullField(edtIndexStandDatum, lblIndexStandDatum.Text);
            }

            var vonDatum = Utils.ConvertToDateTime(qryIkForderung["DatumAnpassenAb"]);

            var frdCode = Utils.ConvertToInt(qryIkForderung["IkForderungPeriodischCode"]);

            if (frdCode == 3 && vonDatum.Day != 1)
            {
                // Kinderzulagen dürfen immer nur per 1. eines Monats erfasst werden
                KissMsg.ShowInfo("Kinderzulagen dürfen immer nur per 1. eines Monats erfasst werden.");
                throw new KissCancelException();
            }

            if (_faProzessCode >= 400 && _faProzessCode < 500 &&
                Utils.ConvertToDecimal(qryIkForderung["Betrag"]) < (Decimal)0.0
            )
            {
                // 16.07.2009 : Kontrolle vorerst nur fürs A gemacht.
                KissMsg.ShowInfo("Der Betrag darf nicht kleiner als 0.00 sein.");
                throw new KissCancelException();
            }

            // Kinderzulagen sind immer ab 1. eines Monats
            if (frdCode == 3)
            {
                vonDatum = Utils.firstDayOfMonth(vonDatum);
            }

            // Gleiche Forderungsart pro Gläubiger zu gleichem Zeitpunkt darf in einem anderen Rechtstitel
            // nicht bestehen (Betrag in anderem RT darf nicht grösser „0“).
            // Kontrollieren, ob die letzte Forderung vor der aktuellen auf 0.00 gesetzt ist
            var qryFordrg = DBUtil.OpenSQL(@"
                select top 1 F.Betrag, F.DatumGueltigBis, R.Bezeichnung, L.Text from dbo.IkForderung F
                left join dbo.IkRechtstitel R on R.IkRechtstitelID = F.IkRechtstitelID
                left join dbo.IkRechtstitelInfos RTI on RTI.IkRechtstitelInfosID = (
                  select top 1 IX.IkRechtstitelInfosID from dbo.IkRechtstitelInfos IX
                  where IX.IkRechtstitelID = R.IkRechtstitelID
                  order by IX.RechtstitelRechtskraeftig desc
                )
                left join dbo.IkRechtstitelInfos RTA on RTA.IkRechtstitelInfosID = (
                  select top 1 RX.IkRechtstitelInfosID from dbo.IkRechtstitelInfos RX
                  where RX.IkRechtstitelID = {1}
                  order by RX.RechtstitelRechtskraeftig desc
                )
                left join dbo.XLOVCode L on L.LOVName = 'IkForderungPeriodisch' and L.Code = F.IkForderungPeriodischCode
                where F.FaLeistungID = {0}
                and F.IkRechtstitelID != {1}
                and F.baPersonID = {2}
                and F.IkForderungPeriodischCode = {3}
                and RTI.RechtstitelRechtskraeftig < RTA.RechtstitelRechtskraeftig
                and case
                  when F.IkForderungPeriodischCode = 3 then dbo.fnFirstDayOf(F.DatumAnpassenAb)
                  else F.DatumAnpassenAb
                end <= {4}
                order by F.DatumAnpassenAb desc",
                _faLeistungID,
                _ikRechtstitelID,
                qryIkForderung["BaPersonID"],
                frdCode,
                vonDatum
            );

            if (qryFordrg.Count > 0 &&
                Utils.ConvertToDecimal(qryFordrg["Betrag"]) != (Decimal)0.0 &&
                Utils.ConvertToDateTime(qryFordrg["DatumGueltigBis"], DateTime.MaxValue) > vonDatum)
            {
                KissMsg.ShowInfo(string.Format(
                    "Im Rechtstitel '{0}' gibt es für diesen Gläubiger noch {1},\r\n" +
                    "welche per Beginn der {1} dieses Rechtstitels ({2}) nicht abgeschlossen sind.\r\n" +
                    "Ändern Sie den Datumsbereich dieser {1} \r\n" +
                    "oder erfassen Sie ein Gültig-Bis-Datum bei den {1} im Rechtstitel '{0}' ({2}).",
                    Utils.ConvertToString(qryFordrg["Bezeichnung"]),
                    Utils.ConvertToString(qryFordrg["Text"]),
                    vonDatum.ToString("dd.MM.yyyy")
                ));

                throw new KissCancelException();
            }

            // Indexstand neu holen:
            qryIkForderung["IndexStandBeiBerechnung"] = GetIndexPunkte(RechtstitelIndexCode, qryIkForderung["IndexStandDatum"]);
            qryIkForderung["Person"] = edtBaPersonID.GetDisplayText(edtBaPersonID.EditValue);
        }

        private void qryIkForderung_PositionChanged(object sender, EventArgs e)
        {
            qryIkForderung.EnableBoundFields(CanEdit);
            edtForderungenBemerkung.EditMode = CanEditBemerkung ? EditModeType.Normal : EditModeType.ReadOnly;

            SetEditMode();
            SetFilterLOV(Utils.ConvertToInt(qryIkForderung["BaPersonID"]));
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ForderungenOeffnen(int rtiCode)
        {
            _rtiIndexCode = rtiCode;

            qryIkForderung.UnbindControls();
            if (_rtiIndexCode == 99 || _rtiIndexCode == 0)
            {
                edtIkAnpassungsRegelCode.DataSource = null;
                edtIndexStandDatum.DataSource = null;
                edtIndexStandBeiBerechnung.DataSource = null;
                edtIkAnpassungsRegelCode.EditValue = DBNull.Value;
                edtIndexStandDatum.EditValue = DBNull.Value;
                edtIndexStandBeiBerechnung.EditValue = DBNull.Value;
            }
            else
            {
                edtIkAnpassungsRegelCode.DataSource = qryIkForderung;
                edtIndexStandDatum.DataSource = qryIkForderung;
                edtIndexStandBeiBerechnung.DataSource = qryIkForderung;
            }

            // SQL ausführen
            qryIkForderung.Fill(_ikRechtstitelID);
        }

        public object GetIndexPunkte(object objCode, object objDatum)
        {
            if (DBUtil.IsEmpty(objCode))
            {
                return DBNull.Value;
            }

            if (DBUtil.IsEmpty(objDatum))
            {
                return DBNull.Value;
            }

            int code = Utils.ConvertToInt(objCode);

            if (code == 99 || code == 0)
            {
                return DBNull.Value;
            }

            if (code == 0 || code == 7 || code == 8)
            {
                return DBNull.Value;
            }

            var jahr = int.Parse(((DateTime)objDatum).ToString("yyyy"));
            var monat = int.Parse(((DateTime)objDatum).ToString("MM"));

            return IkUtils.GetLandesIndexWert(code, jahr, monat);
        }

        public void Init(int rechtstitelID, int faLeistungID, int fallID, bool canEditRt, bool leistgGeschlossen, int rtiCode, int prozessCode)
        {
            _ikRechtstitelID = rechtstitelID;
            _faLeistungID = faLeistungID;

            // Damit Fehler im Umbau schnell bemerkt werden:(kann später entfernt werden)
            if (_faLeistungID < 1)
            {
                KissMsg.ShowInfo("Programmfehler: Leistungs-ID ist nicht gesetzt.");
            }

            _leistungIstGeschlossen = leistgGeschlossen;
            _rtiIndexCode = rtiCode;
            _faProzessCode = prozessCode;

            if (_leistungIstGeschlossen)
            {
                qryIkForderung.CanUpdate = false;
                qryIkForderung.CanInsert = false;
                qryIkForderung.CanDelete = false;
            }
            else
            {
                qryIkForderung.CanUpdate = qryIkForderung.CanUpdate && canEditRt;
                qryIkForderung.CanInsert = qryIkForderung.CanInsert && canEditRt;
                qryIkForderung.CanDelete = qryIkForderung.CanDelete && canEditRt;
            }

            // Auswahl LOV holen, damit Indexberechnung ein- und ausgeschaltet werden kann
            // Value1 = 1, dann ist Indexberechnung eingeschaltet
            // Value1 = 0, dann ist Indexberechnung ausgeschaltet
            qryLOVListe.Fill();
            qryLOVRegel.Fill();

            // Auswahl Adresse aus FallPersonen:
            PersonenOeffnen();

            edtBaPersonID.Properties.DataSource = qryPerson;
            //colPerson.ColumnEdit = grdForderungen.GetLOVLookUpEdit(qryPerson);

            // Daten neu anzeigen:
            ForderungenOeffnen(_rtiIndexCode);
        }

        public void PersonenOeffnen()
        {
            // SQL ausführen
            qryPerson.Fill(_ikRechtstitelID);
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // 22.09.2007 : sozheo : neu, damit Änderungen des Geburtsdatums aktualisiert werden

            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "Refresh":
                    qryIkForderung.Refresh();
                    return true;

                case "RefreshPerson":
                    qryPerson.Refresh();
                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Private Methods

        private void DatumIndexSetzen()
        {
            // 14.05.2008 : sozheo : neu Monat aus LOV Anpassungsregel
            // 28.10.2008 : sozheo : immer das Jahr vorher nehmen
            // 30.10.2008 : sozheo : bei Dezemberindex korrigiert

            if (!CanEdit)
            {
                return;
            }

            var aRCode = Utils.ConvertToInt(qryIkForderung["IkAnpassungsRegelCode"]);

            if (!HasIndex ||
                DBUtil.IsEmpty(qryIkForderung["DatumAnpassenAb"]) ||
                _rtiIndexCode == 99 || _rtiIndexCode == 0 ||
                aRCode == 0 || aRCode == 7 || aRCode == 8)
            {
                // Bei diesemn gibt es keine Indexierung
                qryIkForderung["IndexStandDatum"] = DBNull.Value;
                qryIkForderung.RefreshDisplay();
                return;
            }

            var monatString = "11";
            var monat = 11;

            if (qryLOVRegel.Find("Code=" + aRCode))
            {
                monatString = Utils.ConvertToString(qryLOVRegel["Value1"]);
            }

            try
            {
                monat = Convert.ToInt32(monatString);
            }
            catch (Exception ex)
            {
                XLog.Create(GetType().FullName, LogLevel.WARN, "Error converting monatString from qryLOVRegel", ex.Message);
            }

            if (monat < 1 || monat > 12)
            {
                monat = 11;
            }

            var aYear = edtAnpassenAb.DateTime.Year;

            // 28.10.2008 : sozheo : immer das Jahr vorher nehmen
            //DateTime datGrenze = Convert.ToDateTime("01." + Monat.ToString() + "." + aYear.ToString());
            //DateTime datFirst = Utils.firstDayOfMonth(edtAnpassenAb.DateTime);
            //if (datFirst < datGrenze) aYear -= 1;

            // 30.10.2008 : sozheo : bei Dezemberindex
            if (monat == 12)
            {
                var datGrenze = Convert.ToDateTime("01.02." + aYear);
                aYear -= 1;

                if (edtAnpassenAb.DateTime < datGrenze)
                {
                    aYear -= 1;
                }
            }
            else
            {
                aYear -= 1;
            }

            qryIkForderung["IndexStandDatum"] = Convert.ToDateTime("01." + monat + "." + aYear);
            qryIkForderung.RefreshDisplay();
        }

        private void IndexPunkteSetzen()
        {
            if (!CanEdit)
            {
                return;
            }

            int aRCode = Utils.ConvertToInt(qryIkForderung["IkAnpassungsRegelCode"]);

            if (!HasIndex ||
                DBUtil.IsEmpty(qryIkForderung["IndexStandDatum"]) ||
                _rtiIndexCode == 99 || _rtiIndexCode == 0 ||
                aRCode == 0 || aRCode == 7 || aRCode == 8
            )
            {
                // Bei diesen gibt es kein index
                qryIkForderung["IndexStandBeiBerechnung"] = DBNull.Value;
                return;
            }

            qryIkForderung["IndexStandBeiBerechnung"] = GetIndexPunkte(RechtstitelIndexCode, qryIkForderung["IndexStandDatum"]);
        }

        private void MonatszahlenNeuRechnen()
        {
            try
            {
                DBUtil.ExecSQLThrowingException("EXEC dbo.spIkMonatszahlen_DetailAll {0}, 1;", _faLeistungID);
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void SetEditMode()
        {
            edtIkAnpassungsRegelCode.EditMode = CanEditAnpassungsregel && HasIndex ? EditModeType.Normal : EditModeType.ReadOnly;
            edtIndexStandDatum.EditMode = CanEditIndex && HasIndex ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void SetFilterLOV(int persID)
        {
            if (!qryPerson.Find("BaPersonID=" + persID))
            {
                // kein Daten anzeigen, da Person nicht gewählt ist
                edtIkForderungPeriodisch.LOVFilter = "1 = 2";
            }
            else if ((bool)qryPerson["IstElternteil"])
            {
                edtIkForderungPeriodisch.LOVFilter = "Value3 = '405' and Code = 2";
            }
            else
            {
                edtIkForderungPeriodisch.LOVFilter = "Value3 = '405' and Code in (1,3)";
            }

            // LOV-Liste neu anzeigen
            edtIkForderungPeriodisch.LOVName = "IkForderungPeriodisch";
        }

        #endregion

        #endregion
    }
}