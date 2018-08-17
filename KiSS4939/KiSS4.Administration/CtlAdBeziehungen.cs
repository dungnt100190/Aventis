using System;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Administration
{
    public class CtlAdBeziehungen : KiSS4.Gui.KissUserControl
    {
        #region Fields

        private System.ComponentModel.IContainer components;
        private bool dataHasChanged = false;
        private KiSS4.Gui.KissTextEditML edtNameGenerisch1;
        private KiSS4.Gui.KissTextEditML edtNameGenerisch2;
        private KiSS4.Gui.KissTextEditML edtNameMaennlich1;
        private KiSS4.Gui.KissTextEditML edtNameMaennlich2;
        private KiSS4.Gui.KissTextEditML edtNameWeiblich1;
        private KiSS4.Gui.KissTextEditML edtNameWeiblich2;
        private KiSS4.Gui.KissGrid grdRelation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRelation;
        private bool isInRefresh = true;
        private KiSS4.Gui.KissLabel lblNameGenerisch1;
        private KiSS4.Gui.KissLabel lblNameGenerisch2;
        private KiSS4.Gui.KissLabel lblNameMaennlich1;
        private KiSS4.Gui.KissLabel lblNameMaennlich2;
        private KiSS4.Gui.KissLabel lblNameWeiblich1;
        private KiSS4.Gui.KissLabel lblNameWeiblich2;
        private KiSS4.DB.SqlQuery qryBeziehungen;

        #endregion

        #region Constructors

        public CtlAdBeziehungen()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdBeziehungen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdRelation = new KiSS4.Gui.KissGrid();
            this.lblNameGenerisch1 = new KiSS4.Gui.KissLabel();
            this.edtNameGenerisch1 = new KiSS4.Gui.KissTextEditML();
            this.lblNameGenerisch2 = new KiSS4.Gui.KissLabel();
            this.edtNameGenerisch2 = new KiSS4.Gui.KissTextEditML();
            this.lblNameMaennlich1 = new KiSS4.Gui.KissLabel();
            this.edtNameMaennlich1 = new KiSS4.Gui.KissTextEditML();
            this.lblNameWeiblich1 = new KiSS4.Gui.KissLabel();
            this.edtNameWeiblich1 = new KiSS4.Gui.KissTextEditML();
            this.lblNameMaennlich2 = new KiSS4.Gui.KissLabel();
            this.edtNameMaennlich2 = new KiSS4.Gui.KissTextEditML();
            this.lblNameWeiblich2 = new KiSS4.Gui.KissLabel();
            this.edtNameWeiblich2 = new KiSS4.Gui.KissTextEditML();
            this.grvRelation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBeziehungen = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameGenerisch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameGenerisch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameGenerisch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameGenerisch2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameMaennlich1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameMaennlich1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameWeiblich1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameWeiblich1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameMaennlich2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameMaennlich2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameWeiblich2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameWeiblich2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeziehungen)).BeginInit();
            this.SuspendLayout();
            //
            // grdRelation
            //
            this.grdRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRelation.DataSource = this.qryBeziehungen;
            this.grdRelation.EmbeddedNavigator.Name = "";
            this.grdRelation.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRelation.Location = new System.Drawing.Point(3, 3);
            this.grdRelation.MainView = this.grvRelation;
            this.grdRelation.Name = "grdRelation";
            this.grdRelation.Size = new System.Drawing.Size(771, 339);
            this.grdRelation.TabIndex = 0;
            this.grdRelation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvRelation});
            //
            // lblNameGenerisch1
            //
            this.lblNameGenerisch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameGenerisch1.Location = new System.Drawing.Point(14, 357);
            this.lblNameGenerisch1.Name = "lblNameGenerisch1";
            this.lblNameGenerisch1.Size = new System.Drawing.Size(133, 24);
            this.lblNameGenerisch1.TabIndex = 1;
            this.lblNameGenerisch1.Text = "Generisch 1 Deutsch";
            this.lblNameGenerisch1.UseCompatibleTextRendering = true;
            //
            // edtNameGenerisch1
            //
            this.edtNameGenerisch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNameGenerisch1.ApplyChangesToDefaultText = false;
            this.edtNameGenerisch1.DataMember = null;
            this.edtNameGenerisch1.DataMemberDefaultText = "NameGenerisch1$";
            this.edtNameGenerisch1.DataMemberTID = "NameGenerisch1TID";
            this.edtNameGenerisch1.DataSource = this.qryBeziehungen;
            this.edtNameGenerisch1.Location = new System.Drawing.Point(153, 357);
            this.edtNameGenerisch1.Name = "edtNameGenerisch1";
            this.edtNameGenerisch1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameGenerisch1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameGenerisch1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameGenerisch1.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameGenerisch1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameGenerisch1.Properties.Appearance.Options.UseFont = true;
            this.edtNameGenerisch1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameGenerisch1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtNameGenerisch1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameGenerisch1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtNameGenerisch1.ShowOnlyDefaultLanguage = true;
            this.edtNameGenerisch1.Size = new System.Drawing.Size(323, 24);
            this.edtNameGenerisch1.TabIndex = 2;
            this.edtNameGenerisch1.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameGenerisch1_UserModifiedFld);
            //
            // lblNameGenerisch2
            //
            this.lblNameGenerisch2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameGenerisch2.Location = new System.Drawing.Point(15, 386);
            this.lblNameGenerisch2.Name = "lblNameGenerisch2";
            this.lblNameGenerisch2.Size = new System.Drawing.Size(133, 24);
            this.lblNameGenerisch2.TabIndex = 3;
            this.lblNameGenerisch2.Text = "Generisch 2 Deutsch";
            this.lblNameGenerisch2.UseCompatibleTextRendering = true;
            //
            // edtNameGenerisch2
            //
            this.edtNameGenerisch2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNameGenerisch2.ApplyChangesToDefaultText = false;
            this.edtNameGenerisch2.DataMember = null;
            this.edtNameGenerisch2.DataMemberDefaultText = "NameGenerisch2$";
            this.edtNameGenerisch2.DataMemberTID = "NameGenerisch2TID";
            this.edtNameGenerisch2.DataSource = this.qryBeziehungen;
            this.edtNameGenerisch2.Location = new System.Drawing.Point(153, 386);
            this.edtNameGenerisch2.Name = "edtNameGenerisch2";
            this.edtNameGenerisch2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameGenerisch2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameGenerisch2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameGenerisch2.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameGenerisch2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameGenerisch2.Properties.Appearance.Options.UseFont = true;
            this.edtNameGenerisch2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtNameGenerisch2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNameGenerisch2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtNameGenerisch2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameGenerisch2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtNameGenerisch2.ShowOnlyDefaultLanguage = true;
            this.edtNameGenerisch2.Size = new System.Drawing.Size(323, 24);
            this.edtNameGenerisch2.TabIndex = 4;
            this.edtNameGenerisch2.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameGenerisch2_UserModifiedFld);
            //
            // lblNameMaennlich1
            //
            this.lblNameMaennlich1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameMaennlich1.Location = new System.Drawing.Point(14, 416);
            this.lblNameMaennlich1.Name = "lblNameMaennlich1";
            this.lblNameMaennlich1.Size = new System.Drawing.Size(133, 24);
            this.lblNameMaennlich1.TabIndex = 5;
            this.lblNameMaennlich1.Text = "Männlich 1 Deutsch";
            this.lblNameMaennlich1.UseCompatibleTextRendering = true;
            //
            // edtNameMaennlich1
            //
            this.edtNameMaennlich1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNameMaennlich1.ApplyChangesToDefaultText = false;
            this.edtNameMaennlich1.DataMember = null;
            this.edtNameMaennlich1.DataMemberDefaultText = "NameMaennlich1$";
            this.edtNameMaennlich1.DataMemberTID = "NameMaennlich1TID";
            this.edtNameMaennlich1.DataSource = this.qryBeziehungen;
            this.edtNameMaennlich1.Location = new System.Drawing.Point(153, 416);
            this.edtNameMaennlich1.Name = "edtNameMaennlich1";
            this.edtNameMaennlich1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameMaennlich1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameMaennlich1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameMaennlich1.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameMaennlich1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameMaennlich1.Properties.Appearance.Options.UseFont = true;
            this.edtNameMaennlich1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtNameMaennlich1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNameMaennlich1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtNameMaennlich1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameMaennlich1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtNameMaennlich1.ShowOnlyDefaultLanguage = true;
            this.edtNameMaennlich1.Size = new System.Drawing.Size(323, 24);
            this.edtNameMaennlich1.TabIndex = 6;
            this.edtNameMaennlich1.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameMaennlich1_UserModifiedFld);
            //
            // lblNameWeiblich1
            //
            this.lblNameWeiblich1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameWeiblich1.Location = new System.Drawing.Point(15, 446);
            this.lblNameWeiblich1.Name = "lblNameWeiblich1";
            this.lblNameWeiblich1.Size = new System.Drawing.Size(133, 24);
            this.lblNameWeiblich1.TabIndex = 7;
            this.lblNameWeiblich1.Text = "Weiblich 1 Deutsch";
            this.lblNameWeiblich1.UseCompatibleTextRendering = true;
            //
            // edtNameWeiblich1
            //
            this.edtNameWeiblich1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNameWeiblich1.ApplyChangesToDefaultText = false;
            this.edtNameWeiblich1.DataMember = null;
            this.edtNameWeiblich1.DataMemberDefaultText = "NameWeiblich1$";
            this.edtNameWeiblich1.DataMemberTID = "NameWeiblich1TID";
            this.edtNameWeiblich1.DataSource = this.qryBeziehungen;
            this.edtNameWeiblich1.Location = new System.Drawing.Point(153, 446);
            this.edtNameWeiblich1.Name = "edtNameWeiblich1";
            this.edtNameWeiblich1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameWeiblich1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameWeiblich1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameWeiblich1.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameWeiblich1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameWeiblich1.Properties.Appearance.Options.UseFont = true;
            this.edtNameWeiblich1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtNameWeiblich1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNameWeiblich1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtNameWeiblich1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameWeiblich1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtNameWeiblich1.ShowOnlyDefaultLanguage = true;
            this.edtNameWeiblich1.Size = new System.Drawing.Size(323, 24);
            this.edtNameWeiblich1.TabIndex = 8;
            this.edtNameWeiblich1.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameWeiblich1_UserModifiedFld);
            //
            // lblNameMaennlich2
            //
            this.lblNameMaennlich2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameMaennlich2.Location = new System.Drawing.Point(15, 476);
            this.lblNameMaennlich2.Name = "lblNameMaennlich2";
            this.lblNameMaennlich2.Size = new System.Drawing.Size(133, 24);
            this.lblNameMaennlich2.TabIndex = 9;
            this.lblNameMaennlich2.Text = "Männlich 2 Deutsch";
            this.lblNameMaennlich2.UseCompatibleTextRendering = true;
            //
            // edtNameMaennlich2
            //
            this.edtNameMaennlich2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNameMaennlich2.ApplyChangesToDefaultText = false;
            this.edtNameMaennlich2.DataMember = null;
            this.edtNameMaennlich2.DataMemberDefaultText = "NameMaennlich2$";
            this.edtNameMaennlich2.DataMemberTID = "NameMaennlich2TID";
            this.edtNameMaennlich2.DataSource = this.qryBeziehungen;
            this.edtNameMaennlich2.Location = new System.Drawing.Point(153, 476);
            this.edtNameMaennlich2.Name = "edtNameMaennlich2";
            this.edtNameMaennlich2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameMaennlich2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameMaennlich2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameMaennlich2.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameMaennlich2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameMaennlich2.Properties.Appearance.Options.UseFont = true;
            this.edtNameMaennlich2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtNameMaennlich2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNameMaennlich2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtNameMaennlich2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameMaennlich2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtNameMaennlich2.ShowOnlyDefaultLanguage = true;
            this.edtNameMaennlich2.Size = new System.Drawing.Size(323, 24);
            this.edtNameMaennlich2.TabIndex = 10;
            this.edtNameMaennlich2.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameMaennlich2_UserModifiedFld);
            //
            // lblNameWeiblich2
            //
            this.lblNameWeiblich2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNameWeiblich2.Location = new System.Drawing.Point(15, 506);
            this.lblNameWeiblich2.Name = "lblNameWeiblich2";
            this.lblNameWeiblich2.Size = new System.Drawing.Size(133, 24);
            this.lblNameWeiblich2.TabIndex = 11;
            this.lblNameWeiblich2.Text = "Weiblich 2 Deutsch";
            this.lblNameWeiblich2.UseCompatibleTextRendering = true;
            //
            // edtNameWeiblich2
            //
            this.edtNameWeiblich2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNameWeiblich2.ApplyChangesToDefaultText = false;
            this.edtNameWeiblich2.DataMember = null;
            this.edtNameWeiblich2.DataMemberDefaultText = "NameWeiblich2$";
            this.edtNameWeiblich2.DataMemberTID = "NameWeiblich2TID";
            this.edtNameWeiblich2.DataSource = this.qryBeziehungen;
            this.edtNameWeiblich2.Location = new System.Drawing.Point(153, 506);
            this.edtNameWeiblich2.Name = "edtNameWeiblich2";
            this.edtNameWeiblich2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameWeiblich2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameWeiblich2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameWeiblich2.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameWeiblich2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameWeiblich2.Properties.Appearance.Options.UseFont = true;
            this.edtNameWeiblich2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtNameWeiblich2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtNameWeiblich2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtNameWeiblich2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameWeiblich2.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtNameWeiblich2.ShowOnlyDefaultLanguage = true;
            this.edtNameWeiblich2.Size = new System.Drawing.Size(323, 24);
            this.edtNameWeiblich2.TabIndex = 12;
            this.edtNameWeiblich2.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameWeiblich2_UserModifiedFld);
            //
            // grvRelation
            //
            this.grvRelation.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRelation.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.Empty.Options.UseBackColor = true;
            this.grvRelation.Appearance.Empty.Options.UseFont = true;
            this.grvRelation.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.EvenRow.Options.UseFont = true;
            this.grvRelation.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRelation.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRelation.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRelation.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRelation.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRelation.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRelation.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRelation.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRelation.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRelation.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRelation.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRelation.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRelation.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRelation.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRelation.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.GroupRow.Options.UseFont = true;
            this.grvRelation.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRelation.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRelation.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRelation.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRelation.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRelation.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRelation.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRelation.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRelation.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRelation.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRelation.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRelation.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRelation.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRelation.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.OddRow.Options.UseFont = true;
            this.grvRelation.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRelation.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.Row.Options.UseBackColor = true;
            this.grvRelation.Appearance.Row.Options.UseFont = true;
            this.grvRelation.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRelation.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRelation.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRelation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRelation.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRelation.GridControl = this.grdRelation;
            this.grvRelation.Name = "grvRelation";
            this.grvRelation.OptionsBehavior.Editable = false;
            this.grvRelation.OptionsCustomization.AllowFilter = false;
            this.grvRelation.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRelation.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRelation.OptionsNavigation.UseTabKey = false;
            this.grvRelation.OptionsView.ColumnAutoWidth = false;
            this.grvRelation.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRelation.OptionsView.ShowGroupPanel = false;
            this.grvRelation.OptionsView.ShowIndicator = false;
            //
            // qryBeziehungen
            //
            this.qryBeziehungen.CanUpdate = true;
            this.qryBeziehungen.HostControl = this;
            this.qryBeziehungen.TableName = "BaRelation";
            this.qryBeziehungen.PositionChanging += new System.EventHandler(this.qryBeziehungen_PositionChanging);
            //
            // CtlAdBeziehungen
            //
            this.ActiveSQLQuery = this.qryBeziehungen;
            this.Controls.Add(this.edtNameWeiblich2);
            this.Controls.Add(this.lblNameWeiblich2);
            this.Controls.Add(this.edtNameMaennlich2);
            this.Controls.Add(this.lblNameMaennlich2);
            this.Controls.Add(this.edtNameWeiblich1);
            this.Controls.Add(this.lblNameWeiblich1);
            this.Controls.Add(this.edtNameMaennlich1);
            this.Controls.Add(this.lblNameMaennlich1);
            this.Controls.Add(this.edtNameGenerisch2);
            this.Controls.Add(this.lblNameGenerisch2);
            this.Controls.Add(this.edtNameGenerisch1);
            this.Controls.Add(this.lblNameGenerisch1);
            this.Controls.Add(this.grdRelation);
            this.Name = "CtlAdBeziehungen";
            this.Size = new System.Drawing.Size(777, 544);
            this.Load += new System.EventHandler(this.CtlAdBeziehungen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameGenerisch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameGenerisch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameGenerisch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameGenerisch2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameMaennlich1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameMaennlich1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameWeiblich1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameWeiblich1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameMaennlich2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameMaennlich2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameWeiblich2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameWeiblich2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeziehungen)).EndInit();
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

        #region Private Methods

        private void CtlAdBeziehungen_Load(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                qryBeziehungen.Fill(@"
                        -- setup var and default value
                        DECLARE @langColumnsGenerisch1 nvarchar(1000)
                        DECLARE @langColumnsGenerisch2 nvarchar(1000)
                        DECLARE @langColumnsMaennlich1 nvarchar(1000)
                        DECLARE @langColumnsMaennlich2 nvarchar(1000)
                        DECLARE @langColumnsWeiblich1 nvarchar(1000)
                        DECLARE @langColumnsWeiblich2 nvarchar(1000)
                        DECLARE @sqlString varchar(8000)

                        SET @langColumnsGenerisch1 = ''
                        SET @langColumnsGenerisch2 = ''
                        SET @langColumnsMaennlich1 = ''
                        SET @langColumnsMaennlich2 = ''
                        SET @langColumnsWeiblich1 = ''
                        SET @langColumnsWeiblich2 = ''
                        SET @sqlString = ''

                        -- get all languages as [Deutsch],[Englisch], ... including subquery for text
                        SELECT  @langColumnsGenerisch1 = @langColumnsGenerisch1+'[Generisch 1 '+SUBSTRING(LOV.Text,1,3)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = REL.NameGenerisch1TID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),',
                            @langColumnsGenerisch2 = @langColumnsGenerisch2+'[Generisch 2 '+SUBSTRING(LOV.Text,1,3)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = REL.NameGenerisch2TID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),',
                            @langColumnsMaennlich1 = @langColumnsMaennlich1+'[Männlich 1 '+SUBSTRING(LOV.Text,1,3)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = REL.NameMaennlich1TID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),',
                            @langColumnsWeiblich1 = @langColumnsWeiblich1+'[Weiblich 1 '+SUBSTRING(LOV.Text,1,3)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = REL.NameWeiblich1TID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),',
                            @langColumnsMaennlich2 = @langColumnsMaennlich2+'[Männlich 2 '+SUBSTRING(LOV.Text,1,3)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = REL.NameMaennlich2TID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),',
                            @langColumnsWeiblich2 = @langColumnsWeiblich2+'[Weiblich 2 '+SUBSTRING(LOV.Text,1,3)+']=(SELECT LNG.Text FROM XLangText LNG WHERE LNG.TID = REL.NameWeiblich2TID AND LanguageCode = '+CONVERT(VARCHAR(10),LOV.Code)+'),'
                        FROM XLOVCode LOV
                        WHERE LOV.LOVName = 'Sprache' AND LOV.Text NOT LIKE '%]%'
                        GROUP BY LOV.Text, LOV.Code, LOV.SortKey
                        ORDER BY LOV.SortKey ASC

                        -- validate for empty
                        IF (@langColumnsGenerisch1 IS NULL OR @langColumnsGenerisch1 = '')
                        BEGIN
                          SET @langColumnsGenerisch1 = 'NoLang = 1,'
                        END
                        IF (@langColumnsGenerisch2 IS NULL OR @langColumnsGenerisch2 = '')
                        BEGIN
                          SET @langColumnsGenerisch2 = 'NoLang = 1,'
                        END
                        IF (@langColumnsMaennlich1 IS NULL OR @langColumnsMaennlich1 = '')
                        BEGIN
                          SET @langColumnsMaennlich1 = 'NoLang = 1,'
                        END
                        IF (@langColumnsWeiblich1 IS NULL OR @langColumnsWeiblich1 = '')
                        BEGIN
                          SET @langColumnsWeiblich1 = 'NoLang = 1,'
                        END
                        IF (@langColumnsMaennlich2 IS NULL OR @langColumnsMaennlich2 = '')
                        BEGIN
                          SET @langColumnsMaennlich2 = 'NoLang = 1,'
                        END
                        IF (@langColumnsWeiblich2 IS NULL OR @langColumnsWeiblich2 = '')
                        BEGIN
                          SET @langColumnsWeiblich2 = 'NoLang = 1,'
                        END

                        -- remove last comma and prepare string
                        SELECT @langColumnsGenerisch1 = LEFT(@langColumnsGenerisch1, LEN(@langColumnsGenerisch1) - 1)
                        SELECT @langColumnsGenerisch2 = LEFT(@langColumnsGenerisch2, LEN(@langColumnsGenerisch2) - 1)
                        SELECT @langColumnsMaennlich1 = LEFT(@langColumnsMaennlich1, LEN(@langColumnsMaennlich1) - 1)
                        SELECT @langColumnsWeiblich1 = LEFT(@langColumnsWeiblich1, LEN(@langColumnsWeiblich1) - 1)
                        SELECT @langColumnsMaennlich2 = LEFT(@langColumnsMaennlich2, LEN(@langColumnsMaennlich2) - 1)
                        SELECT @langColumnsWeiblich2 = LEFT(@langColumnsWeiblich2, LEN(@langColumnsWeiblich2) - 1)

                        -- create query to execute with all language columns
                        SET @sqlString = 'SELECT REL.BaRelationID,
                                     ID = REL.BaRelationID,
                                     Name = REL.NameRelation,
                                     NameGenerisch1$ = REL.NameGenerisch1,
                                     REL.NameGenerisch1TID,
                                     ' + @langColumnsGenerisch1 + ',
                                     NameGenerisch2$ = REL.NameGenerisch2,
                                     REL.NameGenerisch2TID,
                                     ' + @langColumnsGenerisch2 + ',
                                     NameMaennlich1$ = REL.NameMaennlich1,
                                     REL.NameMaennlich1TID,
                                     ' + @langColumnsMaennlich1 + ',
                                     NameWeiblich1$ = REL.NameWeiblich1,
                                     REL.NameWeiblich1TID,
                                     ' + @langColumnsWeiblich1 + ',
                                     NameMaennlich2$ = REL.NameMaennlich2,
                                     REL.NameMaennlich2TID,
                                     ' + @langColumnsMaennlich2 + ',
                                     NameWeiblich2$ = REL.NameWeiblich2,
                                     REL.NameWeiblich2TID,
                                     ' + @langColumnsWeiblich2 + '
                                  FROM BaRelation REL
                                  ORDER BY REL.SortKey ASC'

                        -- execute query and show data
                        --PRINT(@sqlString)
                        EXEC(@sqlString)");

                // init validation counter
                int colsAdded = 0;

                // loop through language items and add columns to grid
                foreach (System.Data.DataColumn col in qryBeziehungen.DataTable.Columns)
                {
                    // check if need to add column
                    if (col.ColumnName.Equals("BaRelationID") || col.ColumnName.EndsWith("$") || col.ColumnName.EndsWith("TID"))
                    {
                        continue;
                    }

                    // create new column
                    DevExpress.XtraGrid.Columns.GridColumn newCol = new DevExpress.XtraGrid.Columns.GridColumn();
                    newCol.FieldName = col.ColumnName;
                    newCol.Caption = col.Caption;
                    newCol.Width = 120;
                    newCol.VisibleIndex = grvRelation.Columns.Count;

                    // setup special width
                    if (newCol.Caption.Equals("ID"))
                    {
                        newCol.Width = 30;
                    }
                    else if (newCol.Caption.Equals("Name"))
                    {
                        newCol.Width = 180;
                    }

                    // add column to view
                    grvRelation.Columns.Add(newCol);
                    colsAdded++;
                }

                // validate
                if (colsAdded < qryBeziehungen.DataTable.Columns.Count - 13 && qryBeziehungen.DataTable.Columns.Count > 0)
                {
                    throw new Exception(string.Format(@"Es konnten nicht alle Spalten in die Darstellung übernommen werden ('{0}' von '{1}' Spalten)", colsAdded, qryBeziehungen.DataTable.Columns.Count));
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError("CtlAdBeziehungen", "ErrorLoadingData", "Fehler bei der Verarbeitung. Die Daten werden womöglich nicht korrekt dargestellt.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;

                // reset flags
                this.isInRefresh = false;
            }
        }

        private void DataHasChanged()
        {
            // set flag
            this.dataHasChanged = true;
        }

        private void edtNameGenerisch1_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            this.DataHasChanged();
        }

        private void edtNameGenerisch2_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            this.DataHasChanged();
        }

        private void edtNameMaennlich1_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            this.DataHasChanged();
        }

        private void edtNameMaennlich2_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            this.DataHasChanged();
        }

        private void edtNameWeiblich1_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            this.DataHasChanged();
        }

        private void edtNameWeiblich2_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            // if user clicks the button, data may be changed
            this.DataHasChanged();
        }

        private void qryBeziehungen_PositionChanging(object sender, System.EventArgs e)
        {
            // check if need to refresh data
            if (this.dataHasChanged && !this.isInRefresh)
            {
                try
                {
                    this.isInRefresh = true;
                    qryBeziehungen.Refresh();
                }
                finally
                {
                    // reset flags
                    this.isInRefresh = false;
                    this.dataHasChanged = false;
                }
            }
        }

        #endregion
    }
}