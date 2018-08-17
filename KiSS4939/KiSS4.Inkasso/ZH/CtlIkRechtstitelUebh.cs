using System;
using System.ComponentModel;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Inkasso.ZH
{
    public class CtlIkRechtstitelUebh : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faFallID = 0;
        private int _faLeistungID = 0;
        private int _faProzessCode;
        private int _ikRechtstitelID = 0;
        private bool _leistungIstGeschlossen = true;
        private bool _rechtstitelDetailsSindKorrigiert = false;
        private bool _rechtstitelIstKorrigiert = false;
        private IContainer components;
        private CtlIkGlaeubiger ctlIkGlaeubiger;
        private KiSS4.Gui.KissLookUpEdit edtAmIndexTypCode;
        private KiSS4.Gui.KissTextEdit edtBezeichnung;
        private KiSS4.Gui.KissMemoEdit edtElterlicheSorgeBemerkung;
        private KiSS4.Gui.KissLookUpEdit edtElterlicheVertretung;
        private KiSS4.Gui.KissCheckEdit edtGanzesKlientensystem;
        private KiSS4.Gui.KissLookUpEdit edtIkRechtstitelCode;
        private KiSS4.Gui.KissDateEdit edtIkRechtstitelGueltigBis;
        private KiSS4.Gui.KissDateEdit edtIkRechtstitelGueltigVon;
        private KiSS4.Gui.KissTextEdit edtIndexStandPunkte;
        private KiSS4.Gui.KissDateEdit edtIndexStandVom;
        private KiSS4.Gui.KissMemoEdit edtInfodesRechtstitel;
        private KiSS4.Gui.KissDateEdit edtRechtstitelDatumVon;
        private KiSS4.Gui.KissDateEdit edtRechtstitelRechtskraeftig;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblAmIndexTypCode;
        private KiSS4.Gui.KissLabel lblBezeichnung;
        private KiSS4.Gui.KissLabel lblElterlicheSorgeBemerkung;
        private KiSS4.Gui.KissLabel lblElterlicheVertretung;
        private KiSS4.Gui.KissLabel lblIkRechtstitelCode;
        private KiSS4.Gui.KissLabel lblIkRechtstitelGueltigBis;
        private KiSS4.Gui.KissLabel lblIkRechtstitelGueltigVon;
        private KiSS4.Gui.KissLabel lblIndexStandPunkte;
        private KiSS4.Gui.KissLabel lblIndexStandVom;
        private KiSS4.Gui.KissLabel lblInfodesRechtstitel;
        private KiSS4.Gui.KissLabel lblRechtstitelDatumVon;
        private KiSS4.Gui.KissLabel lblRechtstitelRechtskraeftig;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryIkRechtstitel;
        private KiSS4.DB.SqlQuery qryIkRechtstitelInfos;
        private KiSS4.DB.SqlQuery qryPerson;

        #endregion

        #endregion

        #region Constructors

        public CtlIkRechtstitelUebh(
            int LeistungID, int FallID, System.Drawing.Image icon,
            bool Gesperrt, int RechtstitelID, int ProzessCode, bool LeistgGeschlossen)
            : this()
        {
            picTitle.Image = icon;
            _faLeistungID = LeistungID;
            _faFallID = FallID;
            _ikRechtstitelID = RechtstitelID;
            _faProzessCode = ProzessCode;
            _leistungIstGeschlossen = LeistgGeschlossen;
            if (_leistungIstGeschlossen)
            {
                qryIkRechtstitel.CanUpdate = false;
                qryIkRechtstitel.CanInsert = false;
                qryIkRechtstitel.CanDelete = false;
                qryIkRechtstitelInfos.CanUpdate = false;
                qryIkRechtstitelInfos.CanInsert = false;
                qryIkRechtstitelInfos.CanDelete = false;
            }

            // Personen aus FaFallPerson:
            qryPerson.Fill(_faFallID);

            // Gläubiger
            ctlIkGlaeubiger.Init(RechtstitelID, _faFallID, Gesperrt, false,
                _faLeistungID, _faProzessCode, 0, _leistungIstGeschlossen
            );

            // Ereignisse manuell hizufügen, sonst funzen sie nicht
            ctlIkGlaeubiger.AddData += new System.EventHandler(this.CtlIkRechtstitelUebh_AddData);
            ctlIkGlaeubiger.DeleteData += new System.EventHandler(this.CtlIkRechtstitelUebh_DeleteData);
            ctlIkGlaeubiger.MoveFirst += new System.EventHandler(this.CtlIkRechtstitelUebh_MoveFirst);
            ctlIkGlaeubiger.MoveNext += new System.EventHandler(this.CtlIkRechtstitelUebh_MoveNext);
            ctlIkGlaeubiger.MovePrevious += new System.EventHandler(this.CtlIkRechtstitelUebh_MovePrevious);
            ctlIkGlaeubiger.MoveLast += new System.EventHandler(this.CtlIkRechtstitelUebh_MoveLast);
            ctlIkGlaeubiger.RefreshData += new System.EventHandler(this.CtlIkRechtstitelUebh_RefreshData);
            ctlIkGlaeubiger.SaveData += new System.EventHandler(this.CtlIkRechtstitelUebh_SaveData);
            ctlIkGlaeubiger.UndoDataChanges += new System.EventHandler(this.CtlIkRechtstitelUebh_UndoDataChanges);

            // Daten zeigen:
            qryIkRechtstitel.Fill(_ikRechtstitelID);
        }

        public CtlIkRechtstitelUebh()
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkRechtstitelUebh));
            this.edtBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.qryIkRechtstitel = new KiSS4.DB.SqlQuery(this.components);
            this.edtIkRechtstitelGueltigVon = new KiSS4.Gui.KissDateEdit();
            this.edtIkRechtstitelGueltigBis = new KiSS4.Gui.KissDateEdit();
            this.edtIkRechtstitelCode = new KiSS4.Gui.KissLookUpEdit();
            this.qryIkRechtstitelInfos = new KiSS4.DB.SqlQuery(this.components);
            this.edtRechtstitelDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtRechtstitelRechtskraeftig = new KiSS4.Gui.KissDateEdit();
            this.lblIkRechtstitelCode = new KiSS4.Gui.KissLabel();
            this.edtInfodesRechtstitel = new KiSS4.Gui.KissMemoEdit();
            this.edtAmIndexTypCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtIndexStandVom = new KiSS4.Gui.KissDateEdit();
            this.lblRechtstitelDatumVon = new KiSS4.Gui.KissLabel();
            this.edtIndexStandPunkte = new KiSS4.Gui.KissTextEdit();
            this.edtElterlicheVertretung = new KiSS4.Gui.KissLookUpEdit();
            this.qryPerson = new KiSS4.DB.SqlQuery(this.components);
            this.edtElterlicheSorgeBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblRechtstitelRechtskraeftig = new KiSS4.Gui.KissLabel();
            this.edtGanzesKlientensystem = new KiSS4.Gui.KissCheckEdit();
            this.ctlIkGlaeubiger = new KiSS4.Inkasso.ZH.CtlIkGlaeubiger();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblElterlicheSorgeBemerkung = new KiSS4.Gui.KissLabel();
            this.lblInfodesRechtstitel = new KiSS4.Gui.KissLabel();
            this.lblElterlicheVertretung = new KiSS4.Gui.KissLabel();
            this.lblIkRechtstitelGueltigVon = new KiSS4.Gui.KissLabel();
            this.lblIkRechtstitelGueltigBis = new KiSS4.Gui.KissLabel();
            this.lblAmIndexTypCode = new KiSS4.Gui.KissLabel();
            this.lblIndexStandPunkte = new KiSS4.Gui.KissLabel();
            this.lblIndexStandVom = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.lblBezeichnung = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkRechtstitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkRechtstitelInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelRechtskraeftig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfodesRechtstitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmIndexTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmIndexTypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandVom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandPunkte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelRechtskraeftig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGanzesKlientensystem.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfodesRechtstitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheVertretung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAmIndexTypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandPunkte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandVom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).BeginInit();
            this.SuspendLayout();
            //
            // edtBezeichnung
            //
            this.edtBezeichnung.DataMember = "Bezeichnung";
            this.edtBezeichnung.DataSource = this.qryIkRechtstitel;
            this.edtBezeichnung.Location = new System.Drawing.Point(130, 35);
            this.edtBezeichnung.Name = "edtBezeichnung";
            this.edtBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezeichnung.Size = new System.Drawing.Size(269, 24);
            this.edtBezeichnung.TabIndex = 0;
            //
            // qryIkRechtstitel
            //
            this.qryIkRechtstitel.BatchUpdate = true;
            this.qryIkRechtstitel.CanUpdate = true;
            this.qryIkRechtstitel.HostControl = this;
            this.qryIkRechtstitel.SelectStatement = resources.GetString("qryIkRechtstitel.SelectStatement");
            this.qryIkRechtstitel.TableName = "IkRechtstitel";
            this.qryIkRechtstitel.AfterFill += new System.EventHandler(this.qryIkRechtstitel_AfterFill);
            this.qryIkRechtstitel.BeforePost += new System.EventHandler(this.qryIkRechtstitel_BeforePost);
            this.qryIkRechtstitel.PositionChanged += new System.EventHandler(this.qryIkRechtstitel_PositionChanged);
            //
            // edtIkRechtstitelGueltigVon
            //
            this.edtIkRechtstitelGueltigVon.DataMember = "IkRechtstitelGueltigVon";
            this.edtIkRechtstitelGueltigVon.DataSource = this.qryIkRechtstitel;
            this.edtIkRechtstitelGueltigVon.EditValue = null;
            this.edtIkRechtstitelGueltigVon.Location = new System.Drawing.Point(130, 74);
            this.edtIkRechtstitelGueltigVon.Name = "edtIkRechtstitelGueltigVon";
            this.edtIkRechtstitelGueltigVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRechtstitelGueltigVon.Properties.Appearance.Options.UseFont = true;
            this.edtIkRechtstitelGueltigVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIkRechtstitelGueltigVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtIkRechtstitelGueltigVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRechtstitelGueltigVon.Properties.ShowToday = false;
            this.edtIkRechtstitelGueltigVon.Size = new System.Drawing.Size(95, 24);
            this.edtIkRechtstitelGueltigVon.TabIndex = 1;
            //
            // edtIkRechtstitelGueltigBis
            //
            this.edtIkRechtstitelGueltigBis.DataMember = "IkRechtstitelGueltigBis";
            this.edtIkRechtstitelGueltigBis.DataSource = this.qryIkRechtstitel;
            this.edtIkRechtstitelGueltigBis.EditValue = null;
            this.edtIkRechtstitelGueltigBis.Location = new System.Drawing.Point(304, 74);
            this.edtIkRechtstitelGueltigBis.Name = "edtIkRechtstitelGueltigBis";
            this.edtIkRechtstitelGueltigBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRechtstitelGueltigBis.Properties.Appearance.Options.UseFont = true;
            this.edtIkRechtstitelGueltigBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtIkRechtstitelGueltigBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIkRechtstitelGueltigBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtIkRechtstitelGueltigBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRechtstitelGueltigBis.Properties.ShowToday = false;
            this.edtIkRechtstitelGueltigBis.Size = new System.Drawing.Size(95, 24);
            this.edtIkRechtstitelGueltigBis.TabIndex = 2;
            //
            // edtIkRechtstitelCode
            //
            this.edtIkRechtstitelCode.DataMember = "IkRechtstitelCode";
            this.edtIkRechtstitelCode.DataSource = this.qryIkRechtstitelInfos;
            this.edtIkRechtstitelCode.Location = new System.Drawing.Point(130, 126);
            this.edtIkRechtstitelCode.LOVFilter = "UeBH";
            this.edtIkRechtstitelCode.LOVName = "IkRechtstitel";
            this.edtIkRechtstitelCode.Name = "edtIkRechtstitelCode";
            this.edtIkRechtstitelCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRechtstitelCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRechtstitelCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRechtstitelCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRechtstitelCode.Properties.Appearance.Options.UseFont = true;
            this.edtIkRechtstitelCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkRechtstitelCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRechtstitelCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkRechtstitelCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkRechtstitelCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtIkRechtstitelCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtIkRechtstitelCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRechtstitelCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtIkRechtstitelCode.Properties.DisplayMember = "Text";
            this.edtIkRechtstitelCode.Properties.DropDownRows = 1;
            this.edtIkRechtstitelCode.Properties.NullText = "";
            this.edtIkRechtstitelCode.Properties.ShowFooter = false;
            this.edtIkRechtstitelCode.Properties.ShowHeader = false;
            this.edtIkRechtstitelCode.Properties.ValueMember = "Code";
            this.edtIkRechtstitelCode.Size = new System.Drawing.Size(270, 24);
            this.edtIkRechtstitelCode.TabIndex = 3;
            //
            // qryIkRechtstitelInfos
            //
            this.qryIkRechtstitelInfos.BatchUpdate = true;
            this.qryIkRechtstitelInfos.CanDelete = true;
            this.qryIkRechtstitelInfos.CanInsert = true;
            this.qryIkRechtstitelInfos.CanUpdate = true;
            this.qryIkRechtstitelInfos.HostControl = this;
            this.qryIkRechtstitelInfos.SelectStatement = resources.GetString("qryIkRechtstitelInfos.SelectStatement");
            this.qryIkRechtstitelInfos.TableName = "IkRechtstitelInfos";
            this.qryIkRechtstitelInfos.AfterInsert += new System.EventHandler(this.qryIkRechtstitelInfos_AfterInsert);
            this.qryIkRechtstitelInfos.BeforePost += new System.EventHandler(this.qryIkRechtstitelInfos_BeforePost);
            //
            // edtRechtstitelDatumVon
            //
            this.edtRechtstitelDatumVon.DataMember = "RechtstitelDatumVon";
            this.edtRechtstitelDatumVon.DataSource = this.qryIkRechtstitelInfos;
            this.edtRechtstitelDatumVon.EditValue = null;
            this.edtRechtstitelDatumVon.Location = new System.Drawing.Point(131, 157);
            this.edtRechtstitelDatumVon.Name = "edtRechtstitelDatumVon";
            this.edtRechtstitelDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechtstitelDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechtstitelDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechtstitelDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechtstitelDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechtstitelDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechtstitelDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtRechtstitelDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtRechtstitelDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRechtstitelDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtRechtstitelDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechtstitelDatumVon.Properties.ShowToday = false;
            this.edtRechtstitelDatumVon.Size = new System.Drawing.Size(97, 24);
            this.edtRechtstitelDatumVon.TabIndex = 4;
            //
            // edtRechtstitelRechtskraeftig
            //
            this.edtRechtstitelRechtskraeftig.DataMember = "RechtstitelRechtskraeftig";
            this.edtRechtstitelRechtskraeftig.DataSource = this.qryIkRechtstitelInfos;
            this.edtRechtstitelRechtskraeftig.EditValue = null;
            this.edtRechtstitelRechtskraeftig.Location = new System.Drawing.Point(131, 187);
            this.edtRechtstitelRechtskraeftig.Name = "edtRechtstitelRechtskraeftig";
            this.edtRechtstitelRechtskraeftig.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechtstitelRechtskraeftig.Properties.Appearance.Options.UseFont = true;
            this.edtRechtstitelRechtskraeftig.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtRechtstitelRechtskraeftig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRechtstitelRechtskraeftig.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtRechtstitelRechtskraeftig.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechtstitelRechtskraeftig.Properties.ShowToday = false;
            this.edtRechtstitelRechtskraeftig.Size = new System.Drawing.Size(97, 24);
            this.edtRechtstitelRechtskraeftig.TabIndex = 5;
            //
            // lblIkRechtstitelCode
            //
            this.lblIkRechtstitelCode.Location = new System.Drawing.Point(6, 126);
            this.lblIkRechtstitelCode.Name = "lblIkRechtstitelCode";
            this.lblIkRechtstitelCode.Size = new System.Drawing.Size(108, 24);
            this.lblIkRechtstitelCode.TabIndex = 5;
            this.lblIkRechtstitelCode.Text = "Rechtstitel Bez";
            this.lblIkRechtstitelCode.UseCompatibleTextRendering = true;
            //
            // edtInfodesRechtstitel
            //
            this.edtInfodesRechtstitel.DataMember = "RechtstitelInfo";
            this.edtInfodesRechtstitel.DataSource = this.qryIkRechtstitelInfos;
            this.edtInfodesRechtstitel.Location = new System.Drawing.Point(421, 122);
            this.edtInfodesRechtstitel.Name = "edtInfodesRechtstitel";
            this.edtInfodesRechtstitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInfodesRechtstitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInfodesRechtstitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInfodesRechtstitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtInfodesRechtstitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInfodesRechtstitel.Properties.Appearance.Options.UseFont = true;
            this.edtInfodesRechtstitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInfodesRechtstitel.Size = new System.Drawing.Size(256, 104);
            this.edtInfodesRechtstitel.TabIndex = 6;
            //
            // edtAmIndexTypCode
            //
            this.edtAmIndexTypCode.DataMember = "IkIndexTypCode";
            this.edtAmIndexTypCode.DataSource = this.qryIkRechtstitel;
            this.edtAmIndexTypCode.Location = new System.Drawing.Point(131, 255);
            this.edtAmIndexTypCode.LOVName = "IkIndexTyp";
            this.edtAmIndexTypCode.Name = "edtAmIndexTypCode";
            this.edtAmIndexTypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAmIndexTypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAmIndexTypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAmIndexTypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAmIndexTypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAmIndexTypCode.Properties.Appearance.Options.UseFont = true;
            this.edtAmIndexTypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAmIndexTypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAmIndexTypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAmIndexTypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAmIndexTypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAmIndexTypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAmIndexTypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAmIndexTypCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtAmIndexTypCode.Properties.DisplayMember = "Text";
            this.edtAmIndexTypCode.Properties.NullText = "";
            this.edtAmIndexTypCode.Properties.ShowFooter = false;
            this.edtAmIndexTypCode.Properties.ShowHeader = false;
            this.edtAmIndexTypCode.Properties.ValueMember = "Code";
            this.edtAmIndexTypCode.Size = new System.Drawing.Size(269, 24);
            this.edtAmIndexTypCode.TabIndex = 7;
            this.edtAmIndexTypCode.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.edtAmIndexTypCode_CloseUp);
            //
            // edtIndexStandVom
            //
            this.edtIndexStandVom.DataMember = "IndexStandVom";
            this.edtIndexStandVom.DataSource = this.qryIkRechtstitel;
            this.edtIndexStandVom.EditValue = null;
            this.edtIndexStandVom.Location = new System.Drawing.Point(131, 285);
            this.edtIndexStandVom.Name = "edtIndexStandVom";
            this.edtIndexStandVom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtIndexStandVom.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIndexStandVom.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexStandVom.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexStandVom.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexStandVom.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexStandVom.Properties.Appearance.Options.UseFont = true;
            this.edtIndexStandVom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtIndexStandVom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtIndexStandVom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtIndexStandVom.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIndexStandVom.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtIndexStandVom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtIndexStandVom.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtIndexStandVom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtIndexStandVom.Properties.Mask.EditMask = "MM.yyyy";
            this.edtIndexStandVom.Properties.ShowToday = false;
            this.edtIndexStandVom.Size = new System.Drawing.Size(97, 24);
            this.edtIndexStandVom.TabIndex = 8;
            this.edtIndexStandVom.EditValueChanged += new System.EventHandler(this.edtIndexStandVom_EditValueChanged);
            //
            // lblRechtstitelDatumVon
            //
            this.lblRechtstitelDatumVon.Location = new System.Drawing.Point(6, 158);
            this.lblRechtstitelDatumVon.Name = "lblRechtstitelDatumVon";
            this.lblRechtstitelDatumVon.Size = new System.Drawing.Size(100, 23);
            this.lblRechtstitelDatumVon.TabIndex = 8;
            this.lblRechtstitelDatumVon.Text = "Rechtstitel von";
            this.lblRechtstitelDatumVon.UseCompatibleTextRendering = true;
            //
            // edtIndexStandPunkte
            //
            this.edtIndexStandPunkte.DataMember = "IndexStandPunkte";
            this.edtIndexStandPunkte.DataSource = this.qryIkRechtstitel;
            this.edtIndexStandPunkte.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIndexStandPunkte.Location = new System.Drawing.Point(309, 285);
            this.edtIndexStandPunkte.Name = "edtIndexStandPunkte";
            this.edtIndexStandPunkte.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIndexStandPunkte.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexStandPunkte.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexStandPunkte.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexStandPunkte.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexStandPunkte.Properties.Appearance.Options.UseFont = true;
            this.edtIndexStandPunkte.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIndexStandPunkte.Properties.ReadOnly = true;
            this.edtIndexStandPunkte.Size = new System.Drawing.Size(91, 24);
            this.edtIndexStandPunkte.TabIndex = 9;
            this.edtIndexStandPunkte.TabStop = false;
            //
            // edtElterlicheVertretung
            //
            this.edtElterlicheVertretung.DataMember = "BaPersonID";
            this.edtElterlicheVertretung.DataSource = this.qryIkRechtstitel;
            this.edtElterlicheVertretung.Location = new System.Drawing.Point(132, 338);
            this.edtElterlicheVertretung.Name = "edtElterlicheVertretung";
            this.edtElterlicheVertretung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtElterlicheVertretung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtElterlicheVertretung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheVertretung.Properties.Appearance.Options.UseBackColor = true;
            this.edtElterlicheVertretung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtElterlicheVertretung.Properties.Appearance.Options.UseFont = true;
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtElterlicheVertretung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtElterlicheVertretung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtElterlicheVertretung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtElterlicheVertretung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtElterlicheVertretung.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtElterlicheVertretung.Properties.DataSource = this.qryPerson;
            this.edtElterlicheVertretung.Properties.DisplayMember = "Text";
            this.edtElterlicheVertretung.Properties.NullText = "";
            this.edtElterlicheVertretung.Properties.ShowFooter = false;
            this.edtElterlicheVertretung.Properties.ShowHeader = false;
            this.edtElterlicheVertretung.Properties.ValueMember = "BaPersonID";
            this.edtElterlicheVertretung.Size = new System.Drawing.Size(268, 24);
            this.edtElterlicheVertretung.TabIndex = 10;
            //
            // qryPerson
            //
            this.qryPerson.SelectStatement = resources.GetString("qryPerson.SelectStatement");
            //
            // edtElterlicheSorgeBemerkung
            //
            this.edtElterlicheSorgeBemerkung.DataMember = "ElterlicheSorgeBemerkung";
            this.edtElterlicheSorgeBemerkung.DataSource = this.qryIkRechtstitel;
            this.edtElterlicheSorgeBemerkung.Location = new System.Drawing.Point(421, 255);
            this.edtElterlicheSorgeBemerkung.Name = "edtElterlicheSorgeBemerkung";
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtElterlicheSorgeBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtElterlicheSorgeBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtElterlicheSorgeBemerkung.Size = new System.Drawing.Size(256, 107);
            this.edtElterlicheSorgeBemerkung.TabIndex = 11;
            //
            // lblRechtstitelRechtskraeftig
            //
            this.lblRechtstitelRechtskraeftig.Location = new System.Drawing.Point(6, 188);
            this.lblRechtstitelRechtskraeftig.Name = "lblRechtstitelRechtskraeftig";
            this.lblRechtstitelRechtskraeftig.Size = new System.Drawing.Size(88, 24);
            this.lblRechtstitelRechtskraeftig.TabIndex = 11;
            this.lblRechtstitelRechtskraeftig.Text = "Rechtskräftig ab";
            this.lblRechtstitelRechtskraeftig.UseCompatibleTextRendering = true;
            //
            // edtGanzesKlientensystem
            //
            this.edtGanzesKlientensystem.EditValue = true;
            this.edtGanzesKlientensystem.Location = new System.Drawing.Point(6, 396);
            this.edtGanzesKlientensystem.Name = "edtGanzesKlientensystem";
            this.edtGanzesKlientensystem.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtGanzesKlientensystem.Properties.Appearance.Options.UseBackColor = true;
            this.edtGanzesKlientensystem.Properties.Caption = "Ganzes Klientensystem anzeigen";
            this.edtGanzesKlientensystem.Size = new System.Drawing.Size(221, 19);
            this.edtGanzesKlientensystem.TabIndex = 12;
            this.edtGanzesKlientensystem.EditValueChanged += new System.EventHandler(this.edtGanzesKlientensystem_EditValueChanged);
            this.edtGanzesKlientensystem.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edtGanzesKlientensystem_EditValueChanging);
            //
            // ctlIkGlaeubiger
            //
            this.ctlIkGlaeubiger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlIkGlaeubiger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlIkGlaeubiger.Location = new System.Drawing.Point(0, 421);
            this.ctlIkGlaeubiger.Name = "ctlIkGlaeubiger";
            this.ctlIkGlaeubiger.Size = new System.Drawing.Size(707, 156);
            this.ctlIkGlaeubiger.TabIndex = 13;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.picTitle);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 24);
            this.panel1.TabIndex = 30;
            //
            // picTitle
            //
            this.picTitle.Location = new System.Drawing.Point(5, 5);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(16, 16);
            this.picTitle.TabIndex = 293;
            this.picTitle.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Rechtstitel ÜbH";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // lblElterlicheSorgeBemerkung
            //
            this.lblElterlicheSorgeBemerkung.Location = new System.Drawing.Point(421, 228);
            this.lblElterlicheSorgeBemerkung.Name = "lblElterlicheSorgeBemerkung";
            this.lblElterlicheSorgeBemerkung.Size = new System.Drawing.Size(254, 24);
            this.lblElterlicheSorgeBemerkung.TabIndex = 35;
            this.lblElterlicheSorgeBemerkung.Text = "Bemerkung ";
            this.lblElterlicheSorgeBemerkung.UseCompatibleTextRendering = true;
            //
            // lblInfodesRechtstitel
            //
            this.lblInfodesRechtstitel.Location = new System.Drawing.Point(421, 95);
            this.lblInfodesRechtstitel.Name = "lblInfodesRechtstitel";
            this.lblInfodesRechtstitel.Size = new System.Drawing.Size(127, 24);
            this.lblInfodesRechtstitel.TabIndex = 36;
            this.lblInfodesRechtstitel.Text = "Info / Gericht, Rechtstitel";
            this.lblInfodesRechtstitel.UseCompatibleTextRendering = true;
            //
            // lblElterlicheVertretung
            //
            this.lblElterlicheVertretung.Location = new System.Drawing.Point(6, 338);
            this.lblElterlicheVertretung.Name = "lblElterlicheVertretung";
            this.lblElterlicheVertretung.Size = new System.Drawing.Size(121, 24);
            this.lblElterlicheVertretung.TabIndex = 39;
            this.lblElterlicheVertretung.Text = "Gesetzlicher Vertreter";
            this.lblElterlicheVertretung.UseCompatibleTextRendering = true;
            //
            // lblIkRechtstitelGueltigVon
            //
            this.lblIkRechtstitelGueltigVon.Location = new System.Drawing.Point(6, 74);
            this.lblIkRechtstitelGueltigVon.Name = "lblIkRechtstitelGueltigVon";
            this.lblIkRechtstitelGueltigVon.Size = new System.Drawing.Size(89, 24);
            this.lblIkRechtstitelGueltigVon.TabIndex = 43;
            this.lblIkRechtstitelGueltigVon.Text = "Erfasst am";
            this.lblIkRechtstitelGueltigVon.UseCompatibleTextRendering = true;
            //
            // lblIkRechtstitelGueltigBis
            //
            this.lblIkRechtstitelGueltigBis.Location = new System.Drawing.Point(240, 74);
            this.lblIkRechtstitelGueltigBis.Name = "lblIkRechtstitelGueltigBis";
            this.lblIkRechtstitelGueltigBis.Size = new System.Drawing.Size(60, 24);
            this.lblIkRechtstitelGueltigBis.TabIndex = 45;
            this.lblIkRechtstitelGueltigBis.Text = "Gültig bis";
            this.lblIkRechtstitelGueltigBis.UseCompatibleTextRendering = true;
            //
            // lblAmIndexTypCode
            //
            this.lblAmIndexTypCode.Location = new System.Drawing.Point(6, 255);
            this.lblAmIndexTypCode.Name = "lblAmIndexTypCode";
            this.lblAmIndexTypCode.Size = new System.Drawing.Size(79, 24);
            this.lblAmIndexTypCode.TabIndex = 51;
            this.lblAmIndexTypCode.Text = "Basierend auf ";
            this.lblAmIndexTypCode.UseCompatibleTextRendering = true;
            //
            // lblIndexStandPunkte
            //
            this.lblIndexStandPunkte.Location = new System.Drawing.Point(252, 287);
            this.lblIndexStandPunkte.Name = "lblIndexStandPunkte";
            this.lblIndexStandPunkte.Size = new System.Drawing.Size(46, 24);
            this.lblIndexStandPunkte.TabIndex = 52;
            this.lblIndexStandPunkte.Text = " Punkte";
            this.lblIndexStandPunkte.UseCompatibleTextRendering = true;
            //
            // lblIndexStandVom
            //
            this.lblIndexStandVom.Location = new System.Drawing.Point(6, 287);
            this.lblIndexStandVom.Name = "lblIndexStandVom";
            this.lblIndexStandVom.Size = new System.Drawing.Size(86, 24);
            this.lblIndexStandVom.TabIndex = 53;
            this.lblIndexStandVom.Text = "Indexstand vom";
            this.lblIndexStandVom.UseCompatibleTextRendering = true;
            //
            // kissLabel4
            //
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel4.Location = new System.Drawing.Point(131, 236);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(100, 16);
            this.kissLabel4.TabIndex = 54;
            this.kissLabel4.Text = "Indexierung";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // lblBezeichnung
            //
            this.lblBezeichnung.Location = new System.Drawing.Point(6, 37);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(101, 24);
            this.lblBezeichnung.TabIndex = 56;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.UseCompatibleTextRendering = true;
            //
            // CtlIkRechtstitelUebh
            //
            this.Controls.Add(this.lblBezeichnung);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.lblIndexStandVom);
            this.Controls.Add(this.lblIndexStandPunkte);
            this.Controls.Add(this.lblAmIndexTypCode);
            this.Controls.Add(this.lblIkRechtstitelGueltigBis);
            this.Controls.Add(this.lblIkRechtstitelGueltigVon);
            this.Controls.Add(this.lblElterlicheVertretung);
            this.Controls.Add(this.lblInfodesRechtstitel);
            this.Controls.Add(this.lblElterlicheSorgeBemerkung);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctlIkGlaeubiger);
            this.Controls.Add(this.edtGanzesKlientensystem);
            this.Controls.Add(this.lblRechtstitelRechtskraeftig);
            this.Controls.Add(this.edtElterlicheSorgeBemerkung);
            this.Controls.Add(this.edtElterlicheVertretung);
            this.Controls.Add(this.edtIndexStandPunkte);
            this.Controls.Add(this.lblRechtstitelDatumVon);
            this.Controls.Add(this.edtIndexStandVom);
            this.Controls.Add(this.edtAmIndexTypCode);
            this.Controls.Add(this.edtInfodesRechtstitel);
            this.Controls.Add(this.lblIkRechtstitelCode);
            this.Controls.Add(this.edtRechtstitelRechtskraeftig);
            this.Controls.Add(this.edtRechtstitelDatumVon);
            this.Controls.Add(this.edtIkRechtstitelCode);
            this.Controls.Add(this.edtIkRechtstitelGueltigBis);
            this.Controls.Add(this.edtIkRechtstitelGueltigVon);
            this.Controls.Add(this.edtBezeichnung);
            this.Name = "CtlIkRechtstitelUebh";
            this.Size = new System.Drawing.Size(710, 580);
            this.AddData += new System.EventHandler(this.CtlIkRechtstitelUebh_AddData);
            this.SaveData += new System.EventHandler(this.CtlIkRechtstitelUebh_SaveData);
            this.DeleteData += new System.EventHandler(this.CtlIkRechtstitelUebh_DeleteData);
            this.UndoDataChanges += new System.EventHandler(this.CtlIkRechtstitelUebh_UndoDataChanges);
            this.RefreshData += new System.EventHandler(this.CtlIkRechtstitelUebh_RefreshData);
            this.MoveFirst += new System.EventHandler(this.CtlIkRechtstitelUebh_MoveFirst);
            this.MovePrevious += new System.EventHandler(this.CtlIkRechtstitelUebh_MovePrevious);
            this.MoveNext += new System.EventHandler(this.CtlIkRechtstitelUebh_MoveNext);
            this.MoveLast += new System.EventHandler(this.CtlIkRechtstitelUebh_MoveLast);
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkRechtstitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelGueltigBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRechtstitelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryIkRechtstitelInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtstitelRechtskraeftig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfodesRechtstitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmIndexTypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAmIndexTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandVom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexStandPunkte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheVertretung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtElterlicheSorgeBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtstitelRechtskraeftig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGanzesKlientensystem.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheSorgeBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInfodesRechtstitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblElterlicheVertretung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIkRechtstitelGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAmIndexTypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandPunkte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIndexStandVom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).EndInit();
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

        // Letzte Bearbeitung
        // 02.04.2008 : sozheo : neu
        // ------------------------------------------------------------------------
        private bool CanEdit
        {
            get
            {
                return (
                    qryIkRechtstitel.CanUpdate &&
                    qryIkRechtstitel.Count > 0 &&
                    !_leistungIstGeschlossen
                );
            }
        }

        #endregion

        #region EventHandlers

        private void CtlIkRechtstitelUebh_AddData(object sender, EventArgs e)
        {
            KissMsg.ShowInfo("Das Einfügen von Daten ist nicht möglich.");
        }

        private void CtlIkRechtstitelUebh_DeleteData(object sender, EventArgs e)
        {
            KissMsg.ShowInfo("Das Löschen von Daten ist nicht möglich.");
        }

        private void CtlIkRechtstitelUebh_MoveFirst(object sender, EventArgs e)
        {
            ctlIkGlaeubiger.qryIkGlaeubiger.First();
        }

        private void CtlIkRechtstitelUebh_MoveLast(object sender, EventArgs e)
        {
            ctlIkGlaeubiger.qryIkGlaeubiger.Last();
        }

        private void CtlIkRechtstitelUebh_MoveNext(object sender, EventArgs e)
        {
            ctlIkGlaeubiger.qryIkGlaeubiger.Next();
        }

        private void CtlIkRechtstitelUebh_MovePrevious(object sender, EventArgs e)
        {
            ctlIkGlaeubiger.qryIkGlaeubiger.Previous();
        }

        private void CtlIkRechtstitelUebh_RefreshData(object sender, EventArgs e)
        {
            if (!AllesSpeichern())
            {
                return;
            }

            qryIkRechtstitel.Fill(_ikRechtstitelID);
        }

        private void CtlIkRechtstitelUebh_SaveData(object sender, EventArgs e)
        {
            if (!AllesSpeichern())
            {
                throw new KissCancelException();
            }
        }

        private void CtlIkRechtstitelUebh_UndoDataChanges(object sender, EventArgs e)
        {
            // Alles rückgängig
            qryIkRechtstitel.Cancel();
            qryIkRechtstitelInfos.Cancel();
            ctlIkGlaeubiger.qryIkGlaeubiger.Cancel();

            // Alles neu laden
            _rechtstitelDetailsSindKorrigiert = false;
            _rechtstitelIstKorrigiert = false;
            qryIkRechtstitel.Fill(_ikRechtstitelID);
        }

        private void edtAmIndexTypCode_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            e.AcceptValue = true;

            if (!e.CloseMode.Equals(DevExpress.XtraEditors.PopupCloseMode.Normal))
            {
                return;
            }

            if (DBUtil.IsEmpty(e.Value))
            {
                qryIkRechtstitel["IkIndexTypCode"] = DBNull.Value;
                qryIkRechtstitel["IndexStandPunkte"] = DBNull.Value;
            }
            else
            {
                qryIkRechtstitel["IkIndexTypCode"] = (int)e.Value;

                // Default Wert HEUTE füllen, wenn leer:
                if (DBUtil.IsEmpty(qryIkRechtstitel["IndexStandVom"]))
                {
                    qryIkRechtstitel["IndexStandVom"] = DateTime.Today;
                }

                // Indexstand neu holen:
                qryIkRechtstitel["IndexStandPunkte"] = GetIndexPunkte((int)e.Value, qryIkRechtstitel["IndexStandVom"]);
            }
        }

        private void edtGanzesKlientensystem_EditValueChanged(object sender, EventArgs e)
        {
            ctlIkGlaeubiger.GlaeubigerOeffnen(edtGanzesKlientensystem.Checked);
        }

        private void edtGanzesKlientensystem_EditValueChanging(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            if (!AllesSpeichern())
            {
                return;
            }

            e.Cancel = false;
        }

        private void edtIndexStandVom_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtIndexStandVom.UserModified)
            {
                return;
            }

            // Indexstand neu holen:
            if (!DBUtil.IsEmpty(edtIndexStandVom.EditValue))
            {
                qryIkRechtstitel["IndexStandVom"] = edtIndexStandVom.EditValue;
            }
            else
            {
                qryIkRechtstitel["IndexStandVom"] = DateTime.Today;
            }

            qryIkRechtstitel["IndexStandPunkte"] = GetIndexPunkte(qryIkRechtstitel["IkIndexTypCode"], qryIkRechtstitel["IndexStandVom"]);
        }

        private void qryIkRechtstitelInfos_AfterInsert(object sender, EventArgs e)
        {
            qryIkRechtstitelInfos["IkRechtstitelID"] = _ikRechtstitelID;
            qryIkRechtstitelInfos["Teuerungseinsprache"] = 0;
            _rechtstitelDetailsSindKorrigiert = true;
        }

        private void qryIkRechtstitelInfos_BeforePost(object sender, EventArgs e)
        {
            qryIkRechtstitelInfos.EndCurrentEdit();
            _rechtstitelDetailsSindKorrigiert = true;
        }

        private void qryIkRechtstitel_AfterFill(object sender, EventArgs e)
        {
            // Details öffnen
            qryIkRechtstitelInfos.Fill(Utils.ConvertToInt(qryIkRechtstitel["IkRechtstitelID"]));

            if (qryIkRechtstitelInfos.Count == 0)
            {
                qryIkRechtstitelInfos.Insert(qryIkRechtstitelInfos.TableName);
                _rechtstitelDetailsSindKorrigiert = true;
            }

            // Gläubiger öffnen
            ctlIkGlaeubiger.GlaeubigerOeffnen(edtGanzesKlientensystem.Checked);

            if (qryIkRechtstitel.Count == 0)
            {
                qryIkRechtstitel_PositionChanged(sender, e);
            }
        }

        private void qryIkRechtstitel_BeforePost(object sender, EventArgs e)
        {
            qryIkRechtstitel.EndCurrentEdit();

            // Mussfelder checken: Codes:
            DBUtil.CheckNotNullField(edtBezeichnung, lblBezeichnung.Text);
            DBUtil.CheckNotNullField(edtIkRechtstitelGueltigVon, lblIkRechtstitelGueltigVon.Text);
            DBUtil.CheckNotNullField(edtIkRechtstitelCode, lblIkRechtstitelCode.Text);
            //DBUtil.CheckNotNullField(edtInfodesRechtstitel, lblInfodesRechtstitel.Text);
            DBUtil.CheckNotNullField(edtRechtstitelRechtskraeftig, lblRechtstitelRechtskraeftig.Text);
            //DBUtil.CheckNotNullField(edtElterlicheVertretung, lblElterlicheVertretung.Text);

            /*
            DBUtil.CheckNotNullField(edtAmIndexTypCode, lblAmIndexTypCode.Text);
            DBUtil.CheckNotNullField(edtIndexStandVom, lblIndexStandVom.Text);
            DBUtil.CheckNotNullField(edtIndexRundenCode, lblIndexRundenCode.Text);
            */

            // Kontrolle der Datum VON BIS
            // Beim Eröffnen eines neuen RT wird kontrolliert, ob der alte RT abgeschlossen ist
            // (das Startdatum des neuen RT kann höchstens der nachfolgende Tag des Abschlusses des alten RT sein).
            var qryRt = DBUtil.OpenSQL(@"
                SELECT TOP 1 Bezeichnung
                FROM dbo.IkRechtstitel
                WHERE FaLeistungID = {0}
                  AND IkRechtstitelID != {1}
                  AND (IkRechtstitelGueltigVon BETWEEN {2} AND ISNULL({3}, CONVERT(DATETIME, '99990101')) OR
                       ISNULL(IkRechtstitelGueltigBis, CONVERT(DATETIME, '99990101')) BETWEEN {2} AND ISNULL({3}, CONVERT(DATETIME, '99990101')));",
                    _faLeistungID,
                    _ikRechtstitelID,
                    qryIkRechtstitel["IkRechtstitelGueltigVon"],
                    qryIkRechtstitel["IkRechtstitelGueltigBis"]
            );

            if (qryRt.Count > 0)
            {
                KissMsg.ShowInfo(
                    "Der Gültigkeitsbereich überschneidet den Bereich mindestens eines anderen Rechtstitels.\r\n" +
                    "Ändern Sie den Gültigkeitsbereich oder verwefen Sie die Änderungen.");

                throw new KissCancelException();
            }

            // Default Wert HEUTE füllen, wenn leer:
            if (DBUtil.IsEmpty(qryIkRechtstitel["IndexStandVom"]))
            {
                qryIkRechtstitel["IndexStandVom"] = DateTime.Today;
            }

            // Indexstand neu holen:
            qryIkRechtstitel["IndexStandPunkte"] = GetIndexPunkte(qryIkRechtstitel["IkIndexTypCode"], qryIkRechtstitel["IndexStandVom"]);

            _rechtstitelIstKorrigiert = true;

            // Transaktion starten
        }

        private void qryIkRechtstitel_PositionChanged(object sender, EventArgs e)
        {
            qryIkRechtstitel.EnableBoundFields(CanEdit);
            qryIkRechtstitelInfos.EnableBoundFields(CanEdit);
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static object GetIndexPunkte(object objCode, object objDatum)
        {
            if (DBUtil.IsEmpty(objCode))
            {
                return DBNull.Value;
            }

            if (DBUtil.IsEmpty(objDatum))
            {
                return DBNull.Value;
            }

            var code = Utils.ConvertToInt(objCode);
            var jahr = int.Parse(((DateTime)objDatum).ToString("yyyy"));
            var monat = int.Parse(((DateTime)objDatum).ToString("MM"));

            return IkUtils.GetLandesIndexWert(code, jahr, monat);
        }

        #endregion

        #region Private Methods

        private bool AllesSpeichern()
        {
            // Speichern der Haupttabelle
            var monatszahlenNeuRechnenIstNotwendig = false;

            qryIkRechtstitel.EndCurrentEdit();
            qryIkRechtstitelInfos.EndCurrentEdit();
            ctlIkGlaeubiger.qryIkGlaeubiger.EndCurrentEdit();

            // Zuerst aktuelle Bearbeitungen speichern, wenn notwendig
            // Check eines Datensatzes wird damit ausgeführt
            if (!qryIkRechtstitel.Post())
            {
                return false;
            }

            if (!qryIkRechtstitelInfos.Post())
            {
                return false;
            }

            if (!ctlIkGlaeubiger.qryIkGlaeubiger.Post())
            {
                return false;
            }

            // Dann Gesamtcheck der Dtailtabelle ausführen
            if (ctlIkGlaeubiger.DatenGlaeubigerWurdenKorrigiert)
            {
                if (!ctlIkGlaeubiger.CheckData())
                {
                    return false;
                }
            }

            // Nicht geändert, also nichts machen
            if (!_rechtstitelIstKorrigiert &&
                !_rechtstitelDetailsSindKorrigiert &&
                !ctlIkGlaeubiger.DatenGlaeubigerWurdenKorrigiert)
            {
                return true;
            }

            Session.BeginTransaction();

            try
            {
                // Alles speichern:
                // Zuerst Haupt-Tabelle: IkRechtstitel
                if (_rechtstitelIstKorrigiert)
                {
                    RechtstitelSpeichern();
                    monatszahlenNeuRechnenIstNotwendig = true;
                }

                // Dann Detail-Tabelle: IkRechtstitelInfos
                if (_rechtstitelDetailsSindKorrigiert)
                {
                    InfosSpeichern();
                }

                // Dann Detail-Tabelle: IkGlaeubiger
                if (ctlIkGlaeubiger.DatenGlaeubigerWurdenKorrigiert)
                {
                    ctlIkGlaeubiger.AllesSpeichern_OhneTransaktion();
                    monatszahlenNeuRechnenIstNotwendig = true;
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return false;
            }

            qryIkRechtstitel.Fill(_ikRechtstitelID);

            // Monatszahlen müssen neu berechnet werden:
            if (monatszahlenNeuRechnenIstNotwendig)
            {
                MonatszahlenNeuRechnen();
            }

            // Navigator Trees aktualisieren:
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            return true;
        }

        private void InfosSpeichern()
        {
            if (!_rechtstitelDetailsSindKorrigiert)
            {
                return;
            }

            foreach (System.Data.DataRow row in qryIkRechtstitelInfos.DataTable.Rows)
            {
                switch (row.RowState)
                {
                    case System.Data.DataRowState.Deleted:
                        DBUtil.ExecSQL(@"
                            DELETE dbo.IkRechtstitelInfos
                            WHERE IkRechtstitelInfosID = {0};",
                            Utils.ConvertToInt(row["IkRechtstitelInfosID"]));
                        break;

                    case System.Data.DataRowState.Modified:
                        DBUtil.ExecSQL(@"
                            UPDATE dbo.IkRechtstitelInfos
                            SET IkRechtstitelCode = {0},
                                RechtstitelInfo = {1},
                                RechtstitelDatumVon = {2},
                                RechtstitelRechtskraeftig = {3},
                                Teuerungseinsprache = {4}
                            WHERE IkRechtstitelInfosID = {5};",
                            row["IkRechtstitelCode"],
                            row["RechtstitelInfo"],
                            row["RechtstitelDatumVon"],
                            row["RechtstitelRechtskraeftig"],
                            row["Teuerungseinsprache"],
                            row["IkRechtstitelInfosID"]);
                        break;

                    case System.Data.DataRowState.Added:
                        DBUtil.ExecSQL(@"
                            INSERT INTO dbo.IkRechtstitelInfos (IkRechtstitelID, IkRechtstitelCode, RechtstitelInfo,
                                                                RechtstitelDatumVon, RechtstitelRechtskraeftig, Teuerungseinsprache)
                            VALUES ({0}, {1}, {2}, {3}, {4}, {5});",
                            _ikRechtstitelID,
                            row["IkRechtstitelCode"],
                            row["RechtstitelInfo"],
                            row["RechtstitelDatumVon"],
                            row["RechtstitelRechtskraeftig"],
                            row["Teuerungseinsprache"]
                            );
                        break;
                }
            }

            _rechtstitelDetailsSindKorrigiert = false;
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

        private void RechtstitelSpeichern()
        {
            if (!_rechtstitelIstKorrigiert)
            {
                return;
            }

            DBUtil.ExecSQL(@"
                UPDATE dbo.IkRechtstitel
                SET Bezeichnung = {0},
                    ElterlicheSorgeCode = {1},
                    ElterlicheSorgeBemerkung = {2},
                    BaPersonID = {3},
                    IkIndexTypCode = {4},
                    IndexStandPunkte = {5},
                    IndexStandVom = {6},
                    IkRechtstitelGueltigVon = {7},
                    IkRechtstitelGueltigBis = {8}
                WHERE IkRechtstitelID = {9};",
                qryIkRechtstitel["Bezeichnung"],
                qryIkRechtstitel["ElterlicheSorgeCode"],
                qryIkRechtstitel["ElterlicheSorgeBemerkung"],
                qryIkRechtstitel["BaPersonID"],
                qryIkRechtstitel["IkIndexTypCode"],
                qryIkRechtstitel["IndexStandPunkte"],
                qryIkRechtstitel["IndexStandVom"],
                qryIkRechtstitel["IkRechtstitelGueltigVon"],
                qryIkRechtstitel["IkRechtstitelGueltigBis"],
                qryIkRechtstitel["IkRechtstitelID"]
            );

            _rechtstitelIstKorrigiert = false;
        }

        #endregion

        #endregion
    }
}