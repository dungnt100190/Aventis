using System;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Intake
{
    /// <summary>
    /// Control, used for Intake module
    /// </summary>
    public class CtlFaIntake : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faLeistungID = 0;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Dokument.KissDocumentButton docIntakeprotokoll;
        private KiSS4.Gui.KissLookUpEdit edtAbschlussGrundCode;
        private KiSS4.Gui.KissCheckedLookupEdit edtBetroffeneLebensbereiche;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtDurchWen;
        private KiSS4.Gui.KissLookUpEdit edtEmpfohlenVon;
        private Common.KissMitarbeiterButtonEdit edtMitarbeiter;
        private KiSS4.Gui.KissDateEdit edtRueckrufBis;
        private KiSS4.Gui.KissDateEdit edtVereinbartesTreffen;
        private KiSS4.Gui.KissLabel lblAbschluss;
        private KiSS4.Gui.KissLabel lblAbschlussGrund;
        private KiSS4.Gui.KissLabel lblAnlass;
        private KiSS4.Gui.KissLabel lblBetroffeneLebensbereiche;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblDurchWen;
        private KiSS4.Gui.KissLabel lblEmpfohlenVon;
        private KiSS4.Gui.KissLabel lblEroeffnung;
        private KiSS4.Gui.KissLabel lblIntake;
        private KiSS4.Gui.KissLabel lblInvolvierteFachstellen;
        private KiSS4.Gui.KissLabel lblMitarbeiter;
        private KiSS4.Gui.KissLabel lblRueckrufBis;
        private KiSS4.Gui.KissLabel lblSituationsbeschrieb;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVereinbartesTreffen;
        private KiSS4.Gui.KissLabel lblWeiteresVorgehen;
        private KiSS4.Gui.KissMemoEdit memAnlass;
        private KiSS4.Gui.KissMemoEdit memInvolvierteFachstellen;
        private KiSS4.Gui.KissMemoEdit memSituationsbeschrieb;
        private KiSS4.Gui.KissMemoEdit memVorgehen;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaIntake;
        private KiSS4.DB.SqlQuery qryFaLeistung;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFaIntake"/> class.
        /// </summary>
        public CtlFaIntake()
        {
            InitializeComponent();

            // init with default values
            Init(null, null, -1);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaIntake));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.lblEroeffnung = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.qryFaLeistung = new KiSS4.DB.SqlQuery();
            this.lblMitarbeiter = new KiSS4.Gui.KissLabel();
            this.lblIntake = new KiSS4.Gui.KissLabel();
            this.lblEmpfohlenVon = new KiSS4.Gui.KissLabel();
            this.edtEmpfohlenVon = new KiSS4.Gui.KissLookUpEdit();
            this.qryFaIntake = new KiSS4.DB.SqlQuery();
            this.lblBetroffeneLebensbereiche = new KiSS4.Gui.KissLabel();
            this.edtBetroffeneLebensbereiche = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblAnlass = new KiSS4.Gui.KissLabel();
            this.memAnlass = new KiSS4.Gui.KissMemoEdit();
            this.lblSituationsbeschrieb = new KiSS4.Gui.KissLabel();
            this.memSituationsbeschrieb = new KiSS4.Gui.KissMemoEdit();
            this.lblWeiteresVorgehen = new KiSS4.Gui.KissLabel();
            this.memVorgehen = new KiSS4.Gui.KissMemoEdit();
            this.lblRueckrufBis = new KiSS4.Gui.KissLabel();
            this.edtRueckrufBis = new KiSS4.Gui.KissDateEdit();
            this.lblDurchWen = new KiSS4.Gui.KissLabel();
            this.edtDurchWen = new KiSS4.Gui.KissLookUpEdit();
            this.lblVereinbartesTreffen = new KiSS4.Gui.KissLabel();
            this.edtVereinbartesTreffen = new KiSS4.Gui.KissDateEdit();
            this.lblInvolvierteFachstellen = new KiSS4.Gui.KissLabel();
            this.memInvolvierteFachstellen = new KiSS4.Gui.KissMemoEdit();
            this.lblAbschluss = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblAbschlussGrund = new KiSS4.Gui.KissLabel();
            this.edtAbschlussGrundCode = new KiSS4.Gui.KissLookUpEdit();
            this.docIntakeprotokoll = new KiSS4.Dokument.KissDocumentButton();
            this.edtMitarbeiter = new KiSS4.Common.KissMitarbeiterButtonEdit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfohlenVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfohlenVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfohlenVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaIntake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffeneLebensbereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffeneLebensbereiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnlass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAnlass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSituationsbeschrieb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSituationsbeschrieb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiteresVorgehen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memVorgehen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckrufBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckrufBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDurchWen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDurchWen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDurchWen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbartesTreffen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbartesTreffen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvolvierteFachstellen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memInvolvierteFachstellen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // panTitel
            //
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 0;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(680, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Intake";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // lblEroeffnung
            //
            this.lblEroeffnung.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblEroeffnung.Location = new System.Drawing.Point(118, 38);
            this.lblEroeffnung.Name = "lblEroeffnung";
            this.lblEroeffnung.Size = new System.Drawing.Size(137, 16);
            this.lblEroeffnung.TabIndex = 1;
            this.lblEroeffnung.Text = "Eröffnung";
            this.lblEroeffnung.UseCompatibleTextRendering = true;
            //
            // lblDatumVon
            //
            this.lblDatumVon.Location = new System.Drawing.Point(10, 59);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(102, 24);
            this.lblDatumVon.TabIndex = 2;
            this.lblDatumVon.Text = "Datum";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaLeistung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(118, 59);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 3;
            //
            // qryFaLeistung
            //
            this.qryFaLeistung.HostControl = this;
            this.qryFaLeistung.TableName = "FaLeistung";
            this.qryFaLeistung.BeforePost += new System.EventHandler(this.qryFaLeistung_BeforePost);
            this.qryFaLeistung.AfterPost += new System.EventHandler(this.qryFaLeistung_AfterPost);
            this.qryFaLeistung.PostCompleted += new System.EventHandler(this.qryFaLeistung_PostCompleted);
            //
            // lblMitarbeiter
            //
            this.lblMitarbeiter.Location = new System.Drawing.Point(10, 89);
            this.lblMitarbeiter.Name = "lblMitarbeiter";
            this.lblMitarbeiter.Size = new System.Drawing.Size(102, 24);
            this.lblMitarbeiter.TabIndex = 4;
            this.lblMitarbeiter.Text = "MA";
            this.lblMitarbeiter.UseCompatibleTextRendering = true;
            //
            // lblIntake
            //
            this.lblIntake.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblIntake.Location = new System.Drawing.Point(118, 127);
            this.lblIntake.Name = "lblIntake";
            this.lblIntake.Size = new System.Drawing.Size(137, 16);
            this.lblIntake.TabIndex = 6;
            this.lblIntake.Text = "Intake";
            this.lblIntake.UseCompatibleTextRendering = true;
            //
            // lblEmpfohlenVon
            //
            this.lblEmpfohlenVon.Location = new System.Drawing.Point(10, 148);
            this.lblEmpfohlenVon.Name = "lblEmpfohlenVon";
            this.lblEmpfohlenVon.Size = new System.Drawing.Size(102, 24);
            this.lblEmpfohlenVon.TabIndex = 7;
            this.lblEmpfohlenVon.Text = "Empfohlen von";
            this.lblEmpfohlenVon.UseCompatibleTextRendering = true;
            //
            // edtEmpfohlenVon
            //
            this.edtEmpfohlenVon.AllowNull = false;
            this.edtEmpfohlenVon.DataMember = "EmpfohlenVonCode";
            this.edtEmpfohlenVon.DataSource = this.qryFaIntake;
            this.edtEmpfohlenVon.Location = new System.Drawing.Point(118, 148);
            this.edtEmpfohlenVon.LOVName = "FaIntakeEmpfohlenVon";
            this.edtEmpfohlenVon.Name = "edtEmpfohlenVon";
            this.edtEmpfohlenVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEmpfohlenVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEmpfohlenVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmpfohlenVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEmpfohlenVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEmpfohlenVon.Properties.Appearance.Options.UseFont = true;
            this.edtEmpfohlenVon.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEmpfohlenVon.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEmpfohlenVon.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEmpfohlenVon.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEmpfohlenVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtEmpfohlenVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtEmpfohlenVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEmpfohlenVon.Properties.NullText = "";
            this.edtEmpfohlenVon.Properties.ShowFooter = false;
            this.edtEmpfohlenVon.Properties.ShowHeader = false;
            this.edtEmpfohlenVon.Size = new System.Drawing.Size(297, 24);
            this.edtEmpfohlenVon.TabIndex = 8;
            //
            // qryFaIntake
            //
            this.qryFaIntake.HostControl = this;
            this.qryFaIntake.TableName = "FaIntake";
            this.qryFaIntake.AfterInsert += new System.EventHandler(this.qryFaIntake_AfterInsert);
            this.qryFaIntake.BeforePost += new System.EventHandler(this.qryFaIntake_BeforePost);
            //
            // lblBetroffeneLebensbereiche
            //
            this.lblBetroffeneLebensbereiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetroffeneLebensbereiche.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBetroffeneLebensbereiche.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblBetroffeneLebensbereiche.Location = new System.Drawing.Point(550, 156);
            this.lblBetroffeneLebensbereiche.Name = "lblBetroffeneLebensbereiche";
            this.lblBetroffeneLebensbereiche.Size = new System.Drawing.Size(163, 16);
            this.lblBetroffeneLebensbereiche.TabIndex = 9;
            this.lblBetroffeneLebensbereiche.Text = "Betroffene Lebensbereiche";
            this.lblBetroffeneLebensbereiche.UseCompatibleTextRendering = true;
            //
            // edtBetroffeneLebensbereiche
            //
            this.edtBetroffeneLebensbereiche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBetroffeneLebensbereiche.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtBetroffeneLebensbereiche.Appearance.Options.UseBackColor = true;
            this.edtBetroffeneLebensbereiche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtBetroffeneLebensbereiche.CheckOnClick = true;
            this.edtBetroffeneLebensbereiche.DataMember = "AnlassthemenCodes";
            this.edtBetroffeneLebensbereiche.DataSource = this.qryFaIntake;
            this.edtBetroffeneLebensbereiche.Location = new System.Drawing.Point(550, 178);
            this.edtBetroffeneLebensbereiche.LOVName = "FaLebensbereich";
            this.edtBetroffeneLebensbereiche.Name = "edtBetroffeneLebensbereiche";
            this.edtBetroffeneLebensbereiche.Size = new System.Drawing.Size(163, 317);
            this.edtBetroffeneLebensbereiche.TabIndex = 10;
            //
            // lblAnlass
            //
            this.lblAnlass.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblAnlass.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAnlass.Location = new System.Drawing.Point(10, 178);
            this.lblAnlass.Name = "lblAnlass";
            this.lblAnlass.Size = new System.Drawing.Size(102, 48);
            this.lblAnlass.TabIndex = 11;
            this.lblAnlass.Text = "Anlass / Fragestellungen";
            this.lblAnlass.UseCompatibleTextRendering = true;
            //
            // memAnlass
            //
            this.memAnlass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memAnlass.DataMember = "Anlass";
            this.memAnlass.DataSource = this.qryFaIntake;
            this.memAnlass.Location = new System.Drawing.Point(118, 178);
            this.memAnlass.Name = "memAnlass";
            this.memAnlass.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memAnlass.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAnlass.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAnlass.Properties.Appearance.Options.UseBackColor = true;
            this.memAnlass.Properties.Appearance.Options.UseBorderColor = true;
            this.memAnlass.Properties.Appearance.Options.UseFont = true;
            this.memAnlass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAnlass.Size = new System.Drawing.Size(421, 48);
            this.memAnlass.TabIndex = 12;
            //
            // lblSituationsbeschrieb
            //
            this.lblSituationsbeschrieb.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblSituationsbeschrieb.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSituationsbeschrieb.Location = new System.Drawing.Point(10, 232);
            this.lblSituationsbeschrieb.Name = "lblSituationsbeschrieb";
            this.lblSituationsbeschrieb.Size = new System.Drawing.Size(102, 48);
            this.lblSituationsbeschrieb.TabIndex = 13;
            this.lblSituationsbeschrieb.Text = "Kurzer Situationsbe-schrieb";
            this.lblSituationsbeschrieb.UseCompatibleTextRendering = true;
            //
            // memSituationsbeschrieb
            //
            this.memSituationsbeschrieb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memSituationsbeschrieb.DataMember = "Situationsbeschrieb";
            this.memSituationsbeschrieb.DataSource = this.qryFaIntake;
            this.memSituationsbeschrieb.Location = new System.Drawing.Point(118, 232);
            this.memSituationsbeschrieb.MinimumSize = new System.Drawing.Size(2, 10);
            this.memSituationsbeschrieb.Name = "memSituationsbeschrieb";
            this.memSituationsbeschrieb.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memSituationsbeschrieb.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memSituationsbeschrieb.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memSituationsbeschrieb.Properties.Appearance.Options.UseBackColor = true;
            this.memSituationsbeschrieb.Properties.Appearance.Options.UseBorderColor = true;
            this.memSituationsbeschrieb.Properties.Appearance.Options.UseFont = true;
            this.memSituationsbeschrieb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memSituationsbeschrieb.Size = new System.Drawing.Size(421, 48);
            this.memSituationsbeschrieb.TabIndex = 14;
            //
            // lblWeiteresVorgehen
            //
            this.lblWeiteresVorgehen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWeiteresVorgehen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblWeiteresVorgehen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblWeiteresVorgehen.Location = new System.Drawing.Point(10, 286);
            this.lblWeiteresVorgehen.Name = "lblWeiteresVorgehen";
            this.lblWeiteresVorgehen.Size = new System.Drawing.Size(102, 57);
            this.lblWeiteresVorgehen.TabIndex = 15;
            this.lblWeiteresVorgehen.Text = "Weiteres Vorgehen";
            this.lblWeiteresVorgehen.UseCompatibleTextRendering = true;
            //
            // memVorgehen
            //
            this.memVorgehen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memVorgehen.DataMember = "WeiteresVorgehen";
            this.memVorgehen.DataSource = this.qryFaIntake;
            this.memVorgehen.Location = new System.Drawing.Point(118, 286);
            this.memVorgehen.Name = "memVorgehen";
            this.memVorgehen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memVorgehen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memVorgehen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memVorgehen.Properties.Appearance.Options.UseBackColor = true;
            this.memVorgehen.Properties.Appearance.Options.UseBorderColor = true;
            this.memVorgehen.Properties.Appearance.Options.UseFont = true;
            this.memVorgehen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memVorgehen.Size = new System.Drawing.Size(421, 65);
            this.memVorgehen.TabIndex = 16;
            //
            // lblRueckrufBis
            //
            this.lblRueckrufBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRueckrufBis.Location = new System.Drawing.Point(118, 357);
            this.lblRueckrufBis.Name = "lblRueckrufBis";
            this.lblRueckrufBis.Size = new System.Drawing.Size(147, 24);
            this.lblRueckrufBis.TabIndex = 17;
            this.lblRueckrufBis.Text = "Vereinbarter Rückruf bis";
            this.lblRueckrufBis.UseCompatibleTextRendering = true;
            //
            // edtRueckrufBis
            //
            this.edtRueckrufBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtRueckrufBis.DataMember = "RueckrufBis";
            this.edtRueckrufBis.DataSource = this.qryFaIntake;
            this.edtRueckrufBis.EditValue = null;
            this.edtRueckrufBis.Location = new System.Drawing.Point(271, 357);
            this.edtRueckrufBis.Name = "edtRueckrufBis";
            this.edtRueckrufBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRueckrufBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRueckrufBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRueckrufBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRueckrufBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtRueckrufBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRueckrufBis.Properties.Appearance.Options.UseFont = true;
            this.edtRueckrufBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtRueckrufBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtRueckrufBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtRueckrufBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRueckrufBis.Properties.ShowToday = false;
            this.edtRueckrufBis.Size = new System.Drawing.Size(100, 24);
            this.edtRueckrufBis.TabIndex = 18;
            //
            // lblDurchWen
            //
            this.lblDurchWen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDurchWen.Location = new System.Drawing.Point(118, 387);
            this.lblDurchWen.Name = "lblDurchWen";
            this.lblDurchWen.Size = new System.Drawing.Size(147, 24);
            this.lblDurchWen.TabIndex = 19;
            this.lblDurchWen.Text = "Durch wen";
            this.lblDurchWen.UseCompatibleTextRendering = true;
            //
            // edtDurchWen
            //
            this.edtDurchWen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDurchWen.DataMember = "DurchWenCode";
            this.edtDurchWen.DataSource = this.qryFaIntake;
            this.edtDurchWen.Location = new System.Drawing.Point(271, 387);
            this.edtDurchWen.LOVName = "FaIntakeWer";
            this.edtDurchWen.Name = "edtDurchWen";
            this.edtDurchWen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDurchWen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDurchWen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDurchWen.Properties.Appearance.Options.UseBackColor = true;
            this.edtDurchWen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDurchWen.Properties.Appearance.Options.UseFont = true;
            this.edtDurchWen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDurchWen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDurchWen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDurchWen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDurchWen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDurchWen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDurchWen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDurchWen.Properties.NullText = "";
            this.edtDurchWen.Properties.ShowFooter = false;
            this.edtDurchWen.Properties.ShowHeader = false;
            this.edtDurchWen.Size = new System.Drawing.Size(133, 24);
            this.edtDurchWen.TabIndex = 20;
            //
            // lblVereinbartesTreffen
            //
            this.lblVereinbartesTreffen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVereinbartesTreffen.Location = new System.Drawing.Point(118, 417);
            this.lblVereinbartesTreffen.Name = "lblVereinbartesTreffen";
            this.lblVereinbartesTreffen.Size = new System.Drawing.Size(147, 24);
            this.lblVereinbartesTreffen.TabIndex = 21;
            this.lblVereinbartesTreffen.Text = "Vereinbartes Treffen";
            this.lblVereinbartesTreffen.UseCompatibleTextRendering = true;
            //
            // edtVereinbartesTreffen
            //
            this.edtVereinbartesTreffen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVereinbartesTreffen.DataMember = "VereinbartesTreffen";
            this.edtVereinbartesTreffen.DataSource = this.qryFaIntake;
            this.edtVereinbartesTreffen.EditValue = null;
            this.edtVereinbartesTreffen.Location = new System.Drawing.Point(271, 417);
            this.edtVereinbartesTreffen.Name = "edtVereinbartesTreffen";
            this.edtVereinbartesTreffen.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVereinbartesTreffen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVereinbartesTreffen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVereinbartesTreffen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVereinbartesTreffen.Properties.Appearance.Options.UseBackColor = true;
            this.edtVereinbartesTreffen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVereinbartesTreffen.Properties.Appearance.Options.UseFont = true;
            this.edtVereinbartesTreffen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtVereinbartesTreffen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVereinbartesTreffen.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtVereinbartesTreffen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVereinbartesTreffen.Properties.ShowToday = false;
            this.edtVereinbartesTreffen.Size = new System.Drawing.Size(100, 24);
            this.edtVereinbartesTreffen.TabIndex = 22;
            //
            // lblInvolvierteFachstellen
            //
            this.lblInvolvierteFachstellen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInvolvierteFachstellen.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblInvolvierteFachstellen.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblInvolvierteFachstellen.Location = new System.Drawing.Point(13, 447);
            this.lblInvolvierteFachstellen.Name = "lblInvolvierteFachstellen";
            this.lblInvolvierteFachstellen.Size = new System.Drawing.Size(102, 48);
            this.lblInvolvierteFachstellen.TabIndex = 23;
            this.lblInvolvierteFachstellen.Text = "Bereits involvierte Fachstellen";
            this.lblInvolvierteFachstellen.UseCompatibleTextRendering = true;
            //
            // memInvolvierteFachstellen
            //
            this.memInvolvierteFachstellen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memInvolvierteFachstellen.DataMember = "InvolvierteFachstellen";
            this.memInvolvierteFachstellen.DataSource = this.qryFaIntake;
            this.memInvolvierteFachstellen.Location = new System.Drawing.Point(118, 447);
            this.memInvolvierteFachstellen.Name = "memInvolvierteFachstellen";
            this.memInvolvierteFachstellen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memInvolvierteFachstellen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memInvolvierteFachstellen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memInvolvierteFachstellen.Properties.Appearance.Options.UseBackColor = true;
            this.memInvolvierteFachstellen.Properties.Appearance.Options.UseBorderColor = true;
            this.memInvolvierteFachstellen.Properties.Appearance.Options.UseFont = true;
            this.memInvolvierteFachstellen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memInvolvierteFachstellen.Size = new System.Drawing.Size(421, 48);
            this.memInvolvierteFachstellen.TabIndex = 24;
            //
            // lblAbschluss
            //
            this.lblAbschluss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbschluss.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblAbschluss.Location = new System.Drawing.Point(118, 510);
            this.lblAbschluss.Name = "lblAbschluss";
            this.lblAbschluss.Size = new System.Drawing.Size(140, 16);
            this.lblAbschluss.TabIndex = 25;
            this.lblAbschluss.Text = "Abschluss";
            this.lblAbschluss.UseCompatibleTextRendering = true;
            //
            // lblDatumBis
            //
            this.lblDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumBis.Location = new System.Drawing.Point(10, 534);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(102, 24);
            this.lblDatumBis.TabIndex = 26;
            this.lblDatumBis.Text = "Datum";
            this.lblDatumBis.UseCompatibleTextRendering = true;
            //
            // edtDatumBis
            //
            this.edtDatumBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaLeistung;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(118, 534);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 27;
            //
            // lblAbschlussGrund
            //
            this.lblAbschlussGrund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAbschlussGrund.Location = new System.Drawing.Point(10, 564);
            this.lblAbschlussGrund.Name = "lblAbschlussGrund";
            this.lblAbschlussGrund.Size = new System.Drawing.Size(102, 24);
            this.lblAbschlussGrund.TabIndex = 28;
            this.lblAbschlussGrund.Text = "Grund";
            this.lblAbschlussGrund.UseCompatibleTextRendering = true;
            //
            // edtAbschlussGrundCode
            //
            this.edtAbschlussGrundCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAbschlussGrundCode.DataMember = "AbschlussGrundCode";
            this.edtAbschlussGrundCode.DataSource = this.qryFaLeistung;
            this.edtAbschlussGrundCode.Location = new System.Drawing.Point(118, 564);
            this.edtAbschlussGrundCode.LOVName = "FaIntakeAbschlussGrund";
            this.edtAbschlussGrundCode.Name = "edtAbschlussGrundCode";
            this.edtAbschlussGrundCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussGrundCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussGrundCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussGrundCode.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussGrundCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAbschlussGrundCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAbschlussGrundCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussGrundCode.Properties.NullText = "";
            this.edtAbschlussGrundCode.Properties.ShowFooter = false;
            this.edtAbschlussGrundCode.Properties.ShowHeader = false;
            this.edtAbschlussGrundCode.Size = new System.Drawing.Size(297, 24);
            this.edtAbschlussGrundCode.TabIndex = 29;
            //
            // docIntakeprotokoll
            //
            this.docIntakeprotokoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.docIntakeprotokoll.Context = "FA_Intake";
            this.docIntakeprotokoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docIntakeprotokoll.Image = ((System.Drawing.Image)(resources.GetObject("docIntakeprotokoll.Image")));
            this.docIntakeprotokoll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docIntakeprotokoll.Location = new System.Drawing.Point(578, 564);
            this.docIntakeprotokoll.Name = "docIntakeprotokoll";
            this.docIntakeprotokoll.Size = new System.Drawing.Size(135, 24);
            this.docIntakeprotokoll.TabIndex = 30;
            this.docIntakeprotokoll.Text = "Intakeprotokoll";
            this.docIntakeprotokoll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docIntakeprotokoll.UseCompatibleTextRendering = true;
            this.docIntakeprotokoll.UseVisualStyleBackColor = false;
            //
            // edtMitarbeiter
            //
            this.edtMitarbeiter.DataMember = "Mitarbeiter";
            this.edtMitarbeiter.DataMemberUserId = "UserID";
            this.edtMitarbeiter.DataSource = this.qryFaLeistung;
            this.edtMitarbeiter.Location = new System.Drawing.Point(118, 89);
            this.edtMitarbeiter.Name = "edtMitarbeiter";
            this.edtMitarbeiter.PiMode = true;
            this.edtMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMitarbeiter.Size = new System.Drawing.Size(297, 24);
            this.edtMitarbeiter.TabIndex = 5;
            //
            // CtlFaIntake
            //
            this.ActiveSQLQuery = this.qryFaLeistung;
            this.AutoRefresh = false;
            this.Controls.Add(this.edtMitarbeiter);
            this.Controls.Add(this.docIntakeprotokoll);
            this.Controls.Add(this.edtAbschlussGrundCode);
            this.Controls.Add(this.lblAbschlussGrund);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblAbschluss);
            this.Controls.Add(this.memInvolvierteFachstellen);
            this.Controls.Add(this.lblInvolvierteFachstellen);
            this.Controls.Add(this.edtVereinbartesTreffen);
            this.Controls.Add(this.lblVereinbartesTreffen);
            this.Controls.Add(this.edtDurchWen);
            this.Controls.Add(this.lblDurchWen);
            this.Controls.Add(this.edtRueckrufBis);
            this.Controls.Add(this.lblRueckrufBis);
            this.Controls.Add(this.memVorgehen);
            this.Controls.Add(this.lblWeiteresVorgehen);
            this.Controls.Add(this.memSituationsbeschrieb);
            this.Controls.Add(this.lblSituationsbeschrieb);
            this.Controls.Add(this.memAnlass);
            this.Controls.Add(this.lblAnlass);
            this.Controls.Add(this.edtBetroffeneLebensbereiche);
            this.Controls.Add(this.lblBetroffeneLebensbereiche);
            this.Controls.Add(this.edtEmpfohlenVon);
            this.Controls.Add(this.lblEmpfohlenVon);
            this.Controls.Add(this.lblIntake);
            this.Controls.Add(this.lblMitarbeiter);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblEroeffnung);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlFaIntake";
            this.Size = new System.Drawing.Size(722, 596);
            this.Load += new System.EventHandler(this.CtlFaIntake_Load);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaLeistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIntake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEmpfohlenVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfohlenVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEmpfohlenVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaIntake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetroffeneLebensbereiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetroffeneLebensbereiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnlass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAnlass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSituationsbeschrieb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memSituationsbeschrieb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWeiteresVorgehen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memVorgehen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckrufBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckrufBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDurchWen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDurchWen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDurchWen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbartesTreffen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbartesTreffen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvolvierteFachstellen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memInvolvierteFachstellen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschluss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussGrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussGrundCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitarbeiter.Properties)).EndInit();
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

        #region EventHandlers

        private void CtlFaIntake_Load(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void qryFaIntake_AfterInsert(object sender, EventArgs e)
        {
            // setup creator/created
            qryFaIntake.SetCreator();
        }

        private void qryFaIntake_BeforePost(object sender, EventArgs e)
        {
            qryFaIntake.SetModifierModified();
        }

        private void qryFaLeistung_AfterPost(object sender, EventArgs e)
        {
            // apply lookup fields
            qryFaLeistung["Mitarbeiter"] = edtMitarbeiter.Text;
        }

        private void qryFaLeistung_BeforePost(object sender, EventArgs e)
        {
            // finish edit
            qryFaLeistung.EndCurrentEdit();

            // validate must fields
            DBUtil.CheckNotNullField(edtEmpfohlenVon, lblEmpfohlenVon.Text);
            DBUtil.CheckNotNullField(edtBetroffeneLebensbereiche, lblBetroffeneLebensbereiche.Text);

            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtMitarbeiter, lblMitarbeiter.Text);

            // if closing, user needs to enter a reason
            if (!DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                DBUtil.CheckNotNullField(edtAbschlussGrundCode, lblAbschlussGrund.Text);
            }

            // validate ModulID
            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.ModulID]))
            {
                // no valid modulid, cancel
                KissMsg.ShowError(Name, "NoValidModulIDInBeforePost_v01", "Das Intake ist keinem Modul zugewiesen und kann daher nicht gespeichert werden.");

                // cancel changes
                throw new KissCancelException();
            }

            // validate BaPersonID
            if (DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.BaPersonID]))
            {
                // no valid modulid, cancel
                KissMsg.ShowError(Name, "NoValidBaPersonIDInBeforePost_v01", "Das Intake ist keiner Person zugewiesen und kann daher nicht gespeichert werden.");

                // cancel changes
                throw new KissCancelException();
            }

            // #7827: DateTime without time
            qryFaLeistung[DBO.FaLeistung.DatumVon] = FaUtils.DateTimeWithoutTime(qryFaLeistung, DBO.FaLeistung.DatumVon);
            qryFaLeistung[DBO.FaLeistung.DatumBis] = FaUtils.DateTimeWithoutTime(qryFaLeistung, DBO.FaLeistung.DatumBis);

            // init vars
            var currentModulID = Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.ModulID]);
            var currentDatumVon = Convert.ToDateTime(qryFaLeistung[DBO.FaLeistung.DatumVon]);

            // DATUMVON:
            // validate DatumVon only if modified
            if (qryFaLeistung.ColumnModified(DBO.FaLeistung.DatumVon))
            {
                // check if DatumVon is before FV.DatumVon (only if not FV-entry)
                if (!FaUtils.IsProcessDateValid(currentModulID, _faLeistungID, true, currentDatumVon, DateTime.MinValue, true))
                {
                    // DatumVon is invalid
                    edtDatumVon.Focus();

                    // do not continue with save (message alreday shown)
                    throw new KissCancelException();
                }
            }

            // DATUMBIS:
            // validate DatumBis
            if (!DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]))
            {
                // init var
                var currentDatumBis = Convert.ToDateTime(qryFaLeistung[DBO.FaLeistung.DatumBis]);

                // validate date ranges
                if (currentDatumVon > currentDatumBis)
                {
                    // invalid range, set focus and show message
                    edtDatumBis.Focus();
                    throw new KissInfoException(KissMsg.GetMLMessage(Name, "InvalidDateOrder_v01", "Das Abschlussdatum ist ungültig - es darf nicht kleiner als das Eröffnungsdatum sein."), (Control)edtDatumBis);
                }

                // check if DatumBis is after FV.DatumBis or DatumBis does cross any other same items
                if (!FaUtils.IsProcessDateValid(currentModulID, _faLeistungID, false, currentDatumVon, currentDatumBis, true))
                {
                    // DatumBis is after FVDatumBis
                    edtDatumBis.Focus();

                    // do not continue with save (message alreday shown)
                    throw new KissCancelException();
                }

                // CONFIRM CLOSE
                var doCloseAction = KissMsg.ShowQuestion(Name, "ConfirmCloseIntakeProcess", "Wollen Sie das Intake wirklich per '{0}' schliessen?", 0, 0, false, currentDatumBis.ToString("dd.MM.yyyy"));

                // if user did not confirm closing, we do cancel
                if (!doCloseAction)
                {
                    // reset current value and set focus
                    qryFaLeistung[DBO.FaLeistung.DatumBis] = DBNull.Value;
                    edtDatumBis.Focus();

                    // cancel close
                    throw new KissCancelException();
                }
            }
        }

        private void qryFaLeistung_PostCompleted(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
            SetEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FAINTAKEID":
                    return qryFaIntake["FaIntakeID"];

                case "FALEISTUNGID":
                    return _faLeistungID;
            }

            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Init control for given FaLeistungID
        /// </summary>
        /// <param name="titleName">The title text to display</param>
        /// <param name="titleImage">The title image to display</param>
        /// <param name="faLeistungID">The FaLeistungID to use for accessing data</param>
        public void Init(string titleName, Image titleImage, int faLeistungID)
        {
            // validate
            if (faLeistungID < 1)
            {
                // do not continue
                qryFaIntake.CanUpdate = false;
                qryFaLeistung.CanUpdate = false;

                // update fields
                qryFaLeistung.EnableBoundFields(qryFaIntake.CanUpdate);
                qryFaIntake.EnableBoundFields(qryFaIntake.CanUpdate);
                return;
            }

            // apply values
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            _faLeistungID = faLeistungID;

            // get data for Leistung
            qryFaLeistung.Fill(@"
                SELECT LEI.*,
                       Mitarbeiter = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
                       ARC.FaLeistungArchivID
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XUser            USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
                  LEFT JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LEI.FaLeistungID AND
                                                                               ARC.CheckOut IS NULL
                WHERE LEI.FaLeistungID = {0};", _faLeistungID);

            // check if intake is closed, allow changes only if valid and not locked
            SetEditMode();

            // get data for Intake
            qryFaIntake.Fill(@"
                SELECT FAI.*
                FROM dbo.FaIntake FAI WITH (READUNCOMMITTED)
                WHERE FAI.FaLeistungID = {0};", faLeistungID);

            // check if need to insert an empty row
            if (qryFaIntake.Count < 1 && qryFaIntake.CanUpdate)
            {
                qryFaIntake.Insert(null);
                qryFaIntake["FaLeistungID"] = faLeistungID;		// connect FaIntake to current FaLeistungID
            }

            // set colors
            SetupColorRequiredFields();
        }

        /// <summary>
        /// Refreshes all required data
        /// </summary>
        public override void OnRefreshData()
        {
            // let base do stuff (qryFaLeistung.Refresh())
            base.OnRefreshData();

            // refresh Intake data
            qryFaIntake.Refresh();
        }

        /// <summary>
        /// Saves all required data
        /// </summary>
        /// <returns></returns>
        public override bool OnSaveData()
        {
            if (!qryFaIntake.Post())
            {
                return false;
            }

            return qryFaLeistung.Post();
        }

        /// <summary>
        /// Undo changes on main and subquery
        /// </summary>
        public override void OnUndoDataChanges()
        {
            // undo for intake
            qryFaIntake.Cancel();

            // undo for active-sql-query (qryFaLeistung)
            base.OnUndoDataChanges();
        }

        /// <summary>
        /// Setup and refresh color for required fields
        /// </summary>
        public void SetupColorRequiredFields()
        {
            // check if we have a valid id
            if (_faLeistungID < 1)
            {
                // do nothing
                return;
            }

            // check if first Intake within Fallverlauf
            bool isFirstIntakeInFV = Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(dbo.fnFaIsFirstIntake({0}), 0);", _faLeistungID));

            // handle only if first
            if (isFirstIntakeInFV)
            {
                // first Intake of Fallverlauf
                edtEmpfohlenVon.EditMode = qryFaIntake.CanUpdate ? EditModeType.Required : EditModeType.ReadOnly;
            }
            else
            {
                // any other Intake of Fallverlauf
                edtEmpfohlenVon.EditMode = qryFaIntake.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;
            }
        }

        /// <summary>
        /// Translate this control
        /// </summary>
        public override void Translate()
        {
            // apply translation
            base.Translate();

            // do sorting of LOVs A-Z
            edtEmpfohlenVon.SortByFirstColumn();
        }

        #endregion

        #region Private Methods

        private void SetEditMode()
        {
            if (qryFaLeistung.Count == 0)
            {
                return;
            }

            bool mayRead = false;
            bool mayIns = false;
            bool mayUpd = false;
            bool mayDel = false;
            bool mayClose = false;
            bool mayReopen = false;

            DBUtil.GetFallRights(Convert.ToInt32(qryFaLeistung[DBO.FaLeistung.FaLeistungID]), out mayRead, out mayIns, out mayUpd, out mayDel, out mayClose, out mayReopen);

            if (mayClose)
            {
                bool open = DBUtil.IsEmpty(qryFaLeistung[DBO.FaLeistung.DatumBis]);
                ////bool archived = !DBUtil.IsEmpty(qryFaLeistung["FaLeistungArchivID"]);

                qryFaLeistung.CanUpdate = open;

                if (open)
                {
                    edtDatumVon.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtDatumVon.EditMode = EditModeType.ReadOnly;
                }
            }
            else
            {
                qryFaLeistung.CanUpdate = false;
                edtDatumVon.EditMode = EditModeType.ReadOnly;
            }

            // handle qryFaIntake
            qryFaIntake.CanUpdate = qryFaLeistung.CanUpdate;

            // update controls
            qryFaLeistung.EnableBoundFields(qryFaLeistung.CanUpdate);
            qryFaIntake.EnableBoundFields(qryFaIntake.CanUpdate);
        }

        #endregion

        #endregion
    }
}